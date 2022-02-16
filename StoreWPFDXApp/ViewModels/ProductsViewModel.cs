using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using DevExpress.Xpf.Data;
using NHibernate;
using NHibernate.Util;
using StoreWPFDXApp.Common;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels {
  public class ProductsViewModel : ViewModelBase {
    private readonly ISession _session;
    private readonly IProductService _productsService;

    public ProductsViewModel(ISession session, IProductService productsService) {
      _session = session;
      _productsService = productsService;
    }

    [Command]
    public void FetchRows(FetchRowsAsyncArgs args) {
      args.Result = Task.Run<FetchRowsResult>(() => {
        using (var tx = _session.BeginTransaction()) {
          var query = _session.Query<Product>()
              .SortBy(args.SortOrder, defaultUniqueSortPropertyName: nameof(ProductGridItemViewModel.UuId))
              .Where(MakeFilterExpression((CriteriaOperator)args.Filter));
          var products = query.Skip(args.Skip).Take(args.Take ?? 100).ToArray();
          tx.Commit();
          foreach (var product in products) {
            product.BrandUuId = product.Brands?.UuId;
            product.CategoryUuId = product.Categories?.UuId;
          }
          var vms = products.Select(x => new ProductGridItemViewModel(x)).ToArray();
          return vms;
        }
      });
    }

    Expression<Func<Product, bool>> MakeFilterExpression(CriteriaOperator filter) {
      var converter = new GridFilterCriteriaToExpressionConverter<Product>();
      return converter.Convert(filter);
    }
    [Command]
    public async Task ValidateRowAsync(RowValidationArgs args) {
      var productVM = (ProductGridItemViewModel)args.Item;
      var product = productVM.GetModel();
      product.Brands = Brands.FirstOrDefault(x => x.UuId == product.BrandUuId);
      product.Categories = Categories.FirstOrDefault(x => x.UuId == product.CategoryUuId);
      if (product.UuId == default(Guid)) {
        var createdUuId = await _productsService.CreateAsync(product);
        product.UuId = createdUuId;
      } else {
        await _productsService.UpdateAsync(product);
      }
    }
    [Command]
    public async Task ValidateRowDeletionAsync(ValidateRowDeletionArgs args) {
      var product = (ProductGridItemViewModel)args.Items.Single();
      await _productsService.DeleteAsync(product.UuId);
    }

    ICollection<Brand> _brands;
    public ICollection<Brand> Brands {
      get {
        if (_brands == null && !IsInDesignMode) {
          using (var tx = _session.BeginTransaction()) {
            _brands = _session.Query<Brand>().ToArray();
            tx.Commit();
          }
        }
        return _brands;
      }
    }

    ICollection<Category> _categories;
    public ICollection<Category> Categories {
      get {
        if (_categories == null && !IsInDesignMode) {
          using (var tx = _session.BeginTransaction()) {
            _categories = _session.Query<Category>().ToArray();
            tx.Commit();
          }
        }
        return _categories;
      }
    }

    [Command]
    public void DataSourceRefresh(DataSourceRefreshArgs args) {
      _brands = null;
      RaisePropertyChanged(nameof(Brands));
    }

    [Command]
    public async Task SetImageAsync(object param) {
      var productVM = param as ProductGridItemViewModel;
      if (productVM == null) { return; }
      if (productVM.UuId == default(Guid)) {
        MessageBox.Show("Сначала создайте продукт, потом выберите фотографию.");
        return;
      }
      var imagePath = BitmapImageHelper.OpenImageFromFileAndReturnPath();
      if (string.IsNullOrEmpty(imagePath)) {
        return;
      }

      try {
        var imageData = File.ReadAllBytes(imagePath);
        productVM.ImageData = imageData;
        var product = productVM.GetModel();
        await _productsService.UpdateAsync(product);
      }
      catch (Exception ex) {
        MessageBox.Show(ex.ToString());
      }
    }
  }
}