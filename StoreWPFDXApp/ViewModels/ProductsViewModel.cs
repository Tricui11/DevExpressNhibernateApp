﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using DevExpress.Xpf.Data;
using NHibernate;
using NHibernate.Util;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels {
  public class ProductsViewModel : ViewModelBase {
    private readonly ISession _session;
    private readonly IProductsService _productsService;

    public ProductsViewModel(ISession session, IProductsService productsService) {
      _session = session;
      _productsService = productsService;
    }

    [Command]
    public void FetchRows(FetchRowsAsyncArgs args) {
      args.Result = Task.Run<FetchRowsResult>(() => {
        using (var tx = _session.BeginTransaction()) {
          var query = _session.Query<Products>()
              .SortBy(args.SortOrder, defaultUniqueSortPropertyName: nameof(ProductGridItemViewModel.ID))
              .Where(MakeFilterExpression((CriteriaOperator)args.Filter));
          var products = query.Skip(args.Skip).Take(args.Take ?? 100).ToArray();
          tx.Commit();
          foreach (var product in products) {
            product.BrandID = product.Brands.ID;
            product.CategoryID = product.Categories.ID;
          }
          var vms = products.Select(x => new ProductGridItemViewModel(x)).ToArray();
          return vms;
        }
      });
    }

    Expression<Func<Products, bool>> MakeFilterExpression(CriteriaOperator filter) {
      var converter = new GridFilterCriteriaToExpressionConverter<Products>();
      return converter.Convert(filter);
    }
    [Command]
    public async Task ValidateRowAsync(RowValidationArgs args) {
      var productVM = (ProductGridItemViewModel)args.Item;
      var product = productVM.GetModel();
      product.Brands = Brands.First(x => x.ID == product.BrandID);
      product.Categories = Categories.First(x => x.ID == product.CategoryID);
      if (product.ID == 0) {
        var createdId = await _productsService.CreateAsync(product);
        product.ID = createdId;
      } else {
        await _productsService.UpdateAsync(product);
      }
    }
    [Command]
    public async Task ValidateRowDeletionAsync(ValidateRowDeletionArgs args) {
      var product = (ProductGridItemViewModel)args.Items.Single();
      await _productsService.DeleteAsync(product.ID);
    }

    ICollection<Brands> _brands;
    public ICollection<Brands> Brands {
      get {
        if (_brands == null && !IsInDesignMode) {
          using (var tx = _session.BeginTransaction()) {
            _brands = _session.Query<Brands>().ToArray();
            tx.Commit();
          }
        }
        return _brands;
      }
    }

    ICollection<Categories> _categories;
    public ICollection<Categories> Categories {
      get {
        if (_categories == null && !IsInDesignMode) {
          using (var tx = _session.BeginTransaction()) {
            _categories = _session.Query<Categories>().ToArray();
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
  }
}