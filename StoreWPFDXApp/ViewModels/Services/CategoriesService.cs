using System.Collections.Generic;
using System.Threading.Tasks;
using StoreWPFDXApp.ViewModels.Services.Abstract;
using Categories = StoreWPFDXApp.Data.Categories;

namespace StoreWPFDXApp.ViewModels.Services {
  class CategoriesService : ICategoriesService {

    public CategoriesService() {
    }

    public async Task<IEnumerable<Categories>> GetAllAsync() {
      var sessionFactory = NHibernateService.BuildSessionFactory();
      using (var session = sessionFactory.OpenSession()) {
        using (var tx = session.BeginTransaction()) {
          var categories = await session.CreateCriteria<Categories>().ListAsync<Categories>();
          tx.Commit();
          return categories;
        }
      }
    }
  }
}
