using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Xpf;
using DevExpress.Xpf.Data;
using DevExpress.Data.Filtering;
using DevExpress.Mvvm.DataAnnotations;
using NHibernate;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels {
  public class BrandsViewModel : ViewModelBase {
    private readonly ISession _session;
    private readonly IBrandService _brandsService;

    public BrandsViewModel(ISession session, IBrandService brandsService) {
      _session = session;
      _brandsService = brandsService;
    }

    [Command]
    public void FetchRows(FetchRowsAsyncArgs args) {
      args.Result = Task.Run<FetchRowsResult>(() => {
        using (var tx = _session.BeginTransaction()) {
          var query = _session.Query<Brand>().Where(x => !x.IsDeleted)
          .SortBy(args.SortOrder, defaultUniqueSortPropertyName: nameof(BrandGridItemViewModel.Name))
          .Where(MakeFilterExpression((CriteriaOperator)args.Filter));
          var brands = query.Skip(args.Skip).Take(args.Take ?? 100).ToArray();
          tx.Commit();
          var vms = brands.Select(x => new BrandGridItemViewModel(x)).ToArray();
          return vms;
        }
      });
    }
    Expression<Func<Brand, bool>> MakeFilterExpression(CriteriaOperator filter) {
      var converter = new GridFilterCriteriaToExpressionConverter<Brand>();
      return converter.Convert(filter);
    }

    [Command]
    public async Task ValidateRowAsync(RowValidationArgs args) {
      var brandVM = (BrandGridItemViewModel)args.Item;
      var brand = brandVM.GetModel();
      if (brand.UuId == default(Guid)) {
        var createdUuId = await _brandsService.CreateAsync(brand);
        brand.UuId = createdUuId;
      } else {
        await _brandsService.UpdateAsync(brand);
      }
    }
    [Command]
    public async Task ValidateRowDeletionAsync(ValidateRowDeletionArgs args) {
      var brandVM = (BrandGridItemViewModel)args.Items.Single();
      await _brandsService.DeleteAsync(brandVM.UuId);
    }
  }
}