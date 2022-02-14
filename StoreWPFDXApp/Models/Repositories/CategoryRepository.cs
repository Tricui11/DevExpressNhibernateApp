using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using StoreWPFDXApp.Data;
using StoreWPFDXApp.Models.Repositories.Abstract;

namespace StoreWPFDXApp.Models.Repositories {
  public class CategoryRepository : ICategoryRepository {
    private readonly ISession _sessionFactory;

    public CategoryRepository(ISession sessionFactory) {
      _sessionFactory = sessionFactory;
    }

    public async Task<IEnumerable<Categories>> GetAllAsync() {
      using (var tx = _sessionFactory.BeginTransaction()) {
        var categories = await _sessionFactory.CreateCriteria<Categories>().ListAsync<Categories>();
        tx.Commit();
        return categories;
      }
    }
  }
}
