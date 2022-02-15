using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Xpf;
using DevExpress.Xpf.Data;
using NHibernate;
using StoreWPFDXApp.Models;
using System.Collections;

namespace StoreWPFDXApp.ViewModels {
  public class ProductsViewModel : ViewModelBase {
    private readonly ISession _session;

    public ProductsViewModel(ISession session) {
      _session = session;
    }

    [DevExpress.Mvvm.DataAnnotations.Command]
    public void FetchRows(FetchRowsAsyncArgs args) {
      args.Result = Task.Run<FetchRowsResult>(() => {
        using (var tx = _session.BeginTransaction()) {
          var query = _session.Query<Products>()
              .SortBy(args.SortOrder, defaultUniqueSortPropertyName: nameof(Products.Name))
              .Where(MakeFilterExpression((DevExpress.Data.Filtering.CriteriaOperator)args.Filter));
          var products = query.Skip(args.Skip).Take(args.Take ?? 100).ToArray();
          tx.Commit();
          return products;
        }
      });
    }

    System.Linq.Expressions.Expression<System.Func<Products, bool>> MakeFilterExpression(DevExpress.Data.Filtering.CriteriaOperator filter) {
      var converter = new GridFilterCriteriaToExpressionConverter<Products>();
      return converter.Convert(filter);
    }
    [DevExpress.Mvvm.DataAnnotations.Command]
    public void ValidateRow(RowValidationArgs args) {
      //var item = (Products)args.Item;
      //var context = new ProductsContext();
      //context.Entry(item).State = args.IsNewItem ? EntityState.Added : EntityState.Modified;
      //try {
      //  context.SaveChanges();
      //}
      //finally {
      //  context.Entry(item).State = EntityState.Detached;
      //}
    }
    [DevExpress.Mvvm.DataAnnotations.Command]
    public void ValidateRowDeletion(ValidateRowDeletionArgs args) {
      //var item = (Products)args.Items.Single();
      //var context = new ProductsContext();
      //context.Entry(item).State = EntityState.Deleted;
      //context.SaveChanges();
    }

    IList _brands;
    public IList Brands {
      get {
        if (_brands == null && !IsInDesignMode) {
          using (var tx = _session.BeginTransaction()) {
            var query = from b in _session.Query<Brands>()
                        select new {
                          ID = b.ID,
                          Name = b.Name
                        };
            _brands = query.ToArray();
            tx.Commit();
          }
        }
        return _brands;
      }
    }

    IList _categories;
    public IList Categories {
      get {
        if (_categories == null && !IsInDesignMode) {
          using (var tx = _session.BeginTransaction()) {
            var query = from b in _session.Query<Categories>()
                        select new {
                          ID = b.ID,
                          Name = b.Name
                        };
            _categories = query.ToArray();
            tx.Commit();
          }
        }
        return _categories;
      }
    }

    [DevExpress.Mvvm.DataAnnotations.Command]
    public void DataSourceRefresh(DataSourceRefreshArgs args) {
      _brands = null;
      RaisePropertyChanged(nameof(Brands));
    }
  }
}