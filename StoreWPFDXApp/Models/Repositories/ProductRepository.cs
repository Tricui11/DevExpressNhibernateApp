using System;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class ProductRepository : BaseRepository<Product>, IProductRepository {
    public ProductRepository(ISession session) : base(session) { }

    public async Task DeleteAsync(Guid uuId) {
      using (var tx = _session.BeginTransaction()) {
        var product = _session.Get<Product>(uuId);
        await _session.DeleteAsync(product);
        tx.Commit();
      }
    }
  }
}
