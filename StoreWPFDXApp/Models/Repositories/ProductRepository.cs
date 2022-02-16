using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class ProductRepository : IProductRepository {
    private readonly ISession _session;

    public ProductRepository(ISession session) {
      _session = session;
    }

    public async Task<Guid> AddAsync(Product entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.SaveAsync(entity);
        tx.Commit();
        return entity.UuId;
      }
    }

    public async Task DeleteAsync(Guid uuId) {
      using (var tx = _session.BeginTransaction()) {
        var product = _session.Get<Product>(uuId);
        await _session.DeleteAsync(product);
        tx.Commit();
      }
    }

    public Task<IEnumerable<Product>> GetAllAsync() {
      throw new System.NotImplementedException();
    }

    public async Task UpdateAsync(Product entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.UpdateAsync(entity);
        tx.Commit();
      }
    }
  }
}
