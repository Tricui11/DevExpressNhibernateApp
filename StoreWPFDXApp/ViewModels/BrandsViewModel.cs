using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Xpf.Data;
using NHibernate;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels {
  public class BrandsViewModel : ViewModelBase {
    private readonly ISession _session;
    private readonly IBrandsService _brandsService;

    public BrandsViewModel(ISession session, IBrandsService brandsService) {
      _session = session;
      _brandsService = brandsService;
    }

    [DevExpress.Mvvm.DataAnnotations.Command]
    public void FetchRows(DevExpress.Mvvm.Xpf.FetchRowsAsyncArgs args) {
      args.Result = Task.Run<FetchRowsResult>(() => {
        using (var tx = _session.BeginTransaction()) {
          var brands = _session.Query<Brands>().Where(x => !x.IsDeleted)
          .SortBy(args.SortOrder, defaultUniqueSortPropertyName: nameof(Brands.Name))
          .Where(MakeFilterExpression((DevExpress.Data.Filtering.CriteriaOperator)args.Filter)).ToArray();
          tx.Commit();
          return brands;
        }
      });
    }
    System.Linq.Expressions.Expression<System.Func<Brands, bool>> MakeFilterExpression(DevExpress.Data.Filtering.CriteriaOperator filter) {
      var converter = new GridFilterCriteriaToExpressionConverter<Brands>();
      return converter.Convert(filter);
    }

    [DevExpress.Mvvm.DataAnnotations.Command]
    public async Task ValidateRowAsync(DevExpress.Mvvm.Xpf.RowValidationArgs args) {
      var brand = (Brands)args.Item;
      if (brand.ID == 0) {
        var createdId = await _brandsService.CreateAsync(brand);
        brand.ID = createdId;
      } else {
        await _brandsService.UpdateAsync(brand);
      }
    }
    [DevExpress.Mvvm.DataAnnotations.Command]
    public async Task ValidateRowDeletionAsync(DevExpress.Mvvm.Xpf.ValidateRowDeletionArgs args) {
      var brand = (Brands)args.Items.Single();
      await _brandsService.DeleteAsync(brand.ID);
    }
  }
}