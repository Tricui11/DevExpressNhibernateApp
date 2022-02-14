using System;
using System.Configuration;
using System.Reflection;
using System.Windows;
using Autofac;
using Autofac.Features.ResolveAnything;
using DevExpress.Mvvm;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using StoreWPFDXApp.Common;
using StoreWPFDXApp.Models.Repositories;
using StoreWPFDXApp.Models.Repositories.Abstract;
using StoreWPFDXApp.ViewModels.Services;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application {
    IContainer Container { get; set; }
    protected override void OnStartup(StartupEventArgs e) {
      base.OnStartup(e);
      Container = BuildUpContainer();
      DISource.Resolver = Resolve;
    }
    object Resolve(Type type, object key, string name) {
      if (type == null)
        return null;
      if (key != null)
        return Container.ResolveKeyed(key, type);
      if (name != null)
        return Container.ResolveNamed(name, type);
      return Container.Resolve(type);
    }

    static IContainer BuildUpContainer() {
      var builder = new ContainerBuilder();
      builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
      builder.RegisterType<CategoriesService>().As<ICategoriesService>().InstancePerDependency();
      builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerDependency();

      RegisterNHibernate(builder);

      return builder.Build();
    }

    static void RegisterNHibernate(ContainerBuilder builder) {
      var config = new NHibernate.Cfg.Configuration();
      var databaseServerLocalAdress = ConfigurationManager.AppSettings["DatabaseConnectionString"];

      config.DataBaseIntegration(x => {
        x.ConnectionString = databaseServerLocalAdress;
        x.Driver<SqlClientDriver>();
        x.Dialect<MsSql2012Dialect>();
      });
      config.AddAssembly(Assembly.GetExecutingAssembly());
      var sessionFactory = config.BuildSessionFactory();
      builder.RegisterInstance(config).As<NHibernate.Cfg.Configuration>().SingleInstance();
      builder.RegisterInstance(sessionFactory).As<ISessionFactory>().SingleInstance();
      builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).As<ISession>().InstancePerLifetimeScope();
    }
  }
}
