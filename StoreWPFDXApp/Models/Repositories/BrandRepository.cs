using System;
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

    public async Task<Guid> AddAsync(Brand entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.SaveAsync(entity);
        tx.Commit();
        return entity.UuId;
      }
    }

    public async Task DeleteAsync(Guid uuId) {
      using (var tx = _session.BeginTransaction()) {
        var brand = _session.Get<Brand>(uuId);
        brand.IsDeleted = true;
        await _session.UpdateAsync(brand);
        tx.Commit();
      }
    }

    public Task<IEnumerable<Brand>> GetAllAsync() {
      throw new System.NotImplementedException();
    }

    public async Task UpdateAsync(Brand entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.UpdateAsync(entity);
        tx.Commit();
      }
    }
  }
}
