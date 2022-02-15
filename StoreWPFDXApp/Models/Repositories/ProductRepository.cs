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

    public async Task<int> AddAsync(Products entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.SaveAsync(entity);
        tx.Commit();
        return entity.ID;
      }
    }

    public async Task DeleteAsync(int id) {
      using (var tx = _session.BeginTransaction()) {
        var product = _session.Get<Products>(id);
        await _session.DeleteAsync(product);
        tx.Commit();
      }
    }

    public Task<IEnumerable<Products>> GetAllAsync() {
      throw new System.NotImplementedException();
    }

    public async Task UpdateAsync(Products entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.UpdateAsync(entity);
        tx.Commit();
      }
    }
  }
}
