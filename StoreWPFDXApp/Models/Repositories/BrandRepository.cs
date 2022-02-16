using System;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class BrandRepository : BaseRepository<Brand>, IBrandRepository {
    public BrandRepository(ISession session) : base(session) { }

    public async Task DeleteAsync(Guid uuId) {
      using (var tx = _session.BeginTransaction()) {
        var brand = _session.Get<Brand>(uuId);
        brand.IsDeleted = true;
        await _session.UpdateAsync(brand);
        tx.Commit();
      }
    }
  }
}
