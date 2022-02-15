using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class CategoryRepository : ICategoryRepository {
    private readonly ISession _session;

    public CategoryRepository(ISession session) {
      _session = session;
    }

    public async Task<IEnumerable<Categories>> GetAllAsync() {
      using (var tx = _session.BeginTransaction()) {
        var categories = await _session.CreateCriteria<Categories>().ListAsync<Categories>();
        tx.Commit();
        return categories.Where(x => !x.IsDeleted);
      }
    }

    public async Task<int> AddAsync(Categories entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.SaveAsync(entity);
        tx.Commit();
        return entity.ID;
      }
    }

    public async Task UpdateAsync(Categories entity) {
      using (var tx = _session.BeginTransaction()) {
        var category = _session.Get<Categories>(entity.ID);
        if (category.Name != entity.Name) {
          category.Name = entity.Name;
        }
        if (category.Description != entity.Description) {
          category.Description = entity.Description;
        }
        if (category.KeyWords != entity.KeyWords) {
          category.KeyWords = entity.KeyWords;
        }
        await _session.UpdateAsync(category);
        tx.Commit();
      }
    }

    public async Task UpdateParentAsync(int entityId, int parentId) {
      using (var tx = _session.BeginTransaction()) {
        var category = _session.Get<Categories>(entityId);
        category.ParentID = parentId;
        await _session.UpdateAsync(category);
        tx.Commit();
      }
    }

    public async Task DeleteAsync(IEnumerable<int> iDs) {
      using (var tx = _session.BeginTransaction()) {
        var categories = await _session.QueryOver<Categories>()
          .WhereRestrictionOn(val => val.ID)
          .IsIn(iDs.ToArray())
          .ListAsync();

        foreach (var category in categories) {
          category.IsDeleted = true;
        }

        await _session.UpdateAsync(categories);
        tx.Commit();
      }
    }

    public Task DeleteAsync(int id) {
      throw new System.NotImplementedException();
    }
  }
}
