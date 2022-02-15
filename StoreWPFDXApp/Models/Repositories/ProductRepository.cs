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

    public Task<int> AddAsync(Products entity) {
      throw new System.NotImplementedException();
    }

    public Task DeleteAsync(int id) {
      throw new System.NotImplementedException();
    }

    public Task<IEnumerable<Products>> GetAllAsync() {
      throw new System.NotImplementedException();
    }

    public Task UpdateAsync(Products entity) {
      throw new System.NotImplementedException();
    }
  }
}
