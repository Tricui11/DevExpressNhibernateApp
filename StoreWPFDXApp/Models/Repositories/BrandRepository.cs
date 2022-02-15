using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class BrandRepository : IBrandRepository {
    private readonly ISession _session;

    public BrandRepository(ISession session) {
      _session = session;
    }

    public async Task<int> AddAsync(Brands entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.SaveAsync(entity);
        tx.Commit();
        return entity.ID;
      }
    }

    public async Task DeleteAsync(int id) {
      using (var tx = _session.BeginTransaction()) {
        var brand = _session.Get<Brands>(id);
        brand.IsDeleted = true;
        await _session.UpdateAsync(brand);
        tx.Commit();
      }
    }

    public Task<IEnumerable<Brands>> GetAllAsync() {
      throw new System.NotImplementedException();
    }

    public async Task UpdateAsync(Brands entity) {
      using (var tx = _session.BeginTransaction()) {
        var brand = _session.Get<Brands>(entity.ID);
        brand.Name = entity.Name;
        await _session.UpdateAsync(brand);
        tx.Commit();
      }
    }
  }
}
