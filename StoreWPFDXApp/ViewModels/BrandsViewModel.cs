using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Xpf.Data;
using NHibernate;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels {
  public class BrandsViewModel : ViewModelBase {



    private readonly ISession _session;


    public BrandsViewModel(ISession session) {
      _session = session;

    }




    [DevExpress.Mvvm.DataAnnotations.Command]
    public void FetchRows(DevExpress.Mvvm.Xpf.FetchRowsAsyncArgs args) {




      using (var tx = _session.BeginTransaction()) {
        var brands = Task.Run(async () => await _session.CreateCriteria<Brands>().ListAsync<Brands>()).Result;
        tx.Commit();
        //   return brands.Where(x => !x.IsDeleted);
      }









      //args.Result = Task.Run<FetchRowsResult>(() => {
      //  var context = new BrandsContext();
      //  return context.Brands.AsNoTracking()
      //      .SortBy(args.SortOrder, defaultUniqueSortPropertyName: nameof(Brands.Id))
      //      .Where(MakeFilterExpression((DevExpress.Data.Filtering.CriteriaOperator)args.Filter)).ToArray();
      //});
    }

    System.Linq.Expressions.Expression<System.Func<Brands, bool>> MakeFilterExpression(DevExpress.Data.Filtering.CriteriaOperator filter) {
      var converter = new GridFilterCriteriaToExpressionConverter<Brands>();
      return converter.Convert(filter);
    }
    [DevExpress.Mvvm.DataAnnotations.Command]
    public void ValidateRow(DevExpress.Mvvm.Xpf.RowValidationArgs args) {
      //var item = (Brands)args.Item;
      //var context = new BrandsContext();
      //context.Entry(item).State = args.IsNewItem ? EntityState.Added : EntityState.Modified;
      //try {
      //  context.SaveChanges();
      //}
      //finally {
      //  context.Entry(item).State = EntityState.Detached;
      //}
    }
    [DevExpress.Mvvm.DataAnnotations.Command]
    public void ValidateRowDeletion(DevExpress.Mvvm.Xpf.ValidateRowDeletionArgs args) {
      //var item = (Brands)args.Items.Single();
      //var context = new BrandsContext();
      //context.Entry(item).State = EntityState.Deleted;
      //context.SaveChanges();
    }
  }
}