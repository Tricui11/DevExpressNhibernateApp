using System;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class BaseRepository<T> where T : IUniqueIdentifier {
    protected readonly ISession _session;

    public BaseRepository(ISession session) {
      _session = session;
    }

    public async Task<Guid> AddAsync(T entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.SaveAsync(entity);
        tx.Commit();
        return entity.UuId;
      }
    }

    public async Task UpdateAsync(T entity) {
      using (var tx = _session.BeginTransaction()) {
        await _session.UpdateAsync(entity);
        tx.Commit();
      }
    }
  }
}
