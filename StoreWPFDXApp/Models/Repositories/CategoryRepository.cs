using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class CategoryRepository : BaseRepository<Category>, ICategoryRepository {
    public CategoryRepository(ISession session) : base(session) { }

    public async Task<IEnumerable<Category>> GetAllAsync() {
      using (var tx = _session.BeginTransaction()) {
        var categories = await _session.CreateCriteria<Category>().ListAsync<Category>();
        tx.Commit();
        return categories.Where(x => !x.IsDeleted);
      }
    }

    public async Task UpdateParentAsync(Guid entityUuId, Guid parentUuId) {
      using (var tx = _session.BeginTransaction()) {
        var category = _session.Get<Category>(entityUuId);
        category.ParentUuId = parentUuId;
        await _session.UpdateAsync(category);
        tx.Commit();
      }
    }

    public async Task DeleteAsync(IEnumerable<Guid> uuIds) {
      using (var tx = _session.BeginTransaction()) {
        var categories = await _session.QueryOver<Category>()
          .WhereRestrictionOn(val => val.UuId)
          .IsIn(uuIds.ToArray())
          .ListAsync();

        foreach (var category in categories) {
          category.IsDeleted = true;
        }

        await _session.UpdateAsync(categories);
        tx.Commit();
      }
    }

    public Task DeleteAsync(Guid uuId) {
      throw new NotImplementedException();
    }
  }
}
