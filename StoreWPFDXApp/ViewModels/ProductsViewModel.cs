using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Xpf;
using DevExpress.Xpf.Data;
using NHibernate;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels {
  public class ProductsViewModel : ViewModelBase {


    private readonly ISession _session;



    public ProductsViewModel(ISession session) {
      _session = session;

    }


    [DevExpress.Mvvm.DataAnnotations.Command]
    public void FetchRows(FetchRowsAsyncArgs args) {




      using (var tx = _session.BeginTransaction()) {
        var products = Task.Run(async () => await _session.CreateCriteria<Products>().ListAsync<Products>()).Result;
        tx.Commit();
        //   return brands.Where(x => !x.IsDeleted);
      }







      //args.Result = Task.Run<FetchRowsResult>(() => {
      //  var context = new ProductsContext();
      //  var queryable = context.Products.AsNoTracking()
      //      .SortBy(args.SortOrder, defaultUniqueSortPropertyName: nameof(Products.Id))
      //      .Where(MakeFilterExpression((DevExpress.Data.Filtering.CriteriaOperator)args.Filter));
      //  return queryable.Skip(args.Skip).Take(args.Take ?? 100).ToArray();
      //  });
    }
    [DevExpress.Mvvm.DataAnnotations.Command]
    public void GetTotalSummaries(GetSummariesAsyncArgs args) {
      //args.Result = Task.Run(() => {
      //  var context = new ProductsContext();
      //  var queryable = context.Products.Where(MakeFilterExpression((DevExpress.Data.Filtering.CriteriaOperator)args.Filter));
      //  return queryable.GetSummaries(args.Summaries);
      //});
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
    System.Collections.IList _Brands;

    public System.Collections.IList Brands {
      get {
        return null;
        //if (_Brands == null && !IsInDesignMode) {
        //  var context = new ProductsContext();
        //  _Brands = context.Brands.Select(user => new { Id = user.Id, Name = user.Name }).ToArray();
        //}
        //return _Brands;
      }
    }
    [DevExpress.Mvvm.DataAnnotations.Command]
    public void DataSourceRefresh(DataSourceRefreshArgs args) {
      //_Brands = null;
      //RaisePropertyChanged(nameof(Brands));
    }
  }
}