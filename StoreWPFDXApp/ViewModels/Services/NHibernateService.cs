using System.Configuration;
using System.Reflection;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace StoreWPFDXApp.ViewModels.Services {
  static class NHibernateService {
    public static ISessionFactory BuildSessionFactory() {
      var config = new NHibernate.Cfg.Configuration();
      var databaseServerLocalAdress = ConfigurationManager.AppSettings["DatabaseConnectionString"];

      config.DataBaseIntegration(x => {
        x.ConnectionString = databaseServerLocalAdress;
        x.Driver<SqlClientDriver>();
        x.Dialect<MsSql2012Dialect>();
      });

      config.AddAssembly(Assembly.GetExecutingAssembly());

      return config.BuildSessionFactory();
    }
  }
}
