using System;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using StoreWPFDXApp.Common;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels {
  public class ProductGridItemViewModel : ViewModelBase {
    private readonly Products _model;

    public ProductGridItemViewModel() {
      _model = new Products();
      _model.Brands = new Brands();
      _model.Categories = new Categories();
    }

    public ProductGridItemViewModel(Products model) {
      _model = model;
    }

    public Guid UuId => _model.UuId;
    public string Name {
      get => _model.Name;
      set => _model.Name = value;
    }
    public string Article {
      get => _model.Article;
      set => _model.Article = value;
    }
    public string Description {
      get => _model.Description;
      set => _model.Description = value;
    }
    public decimal? Price {
      get => _model.Price;
      set => _model.Price = value;
    }
    public Guid BrandUuId {
      get => _model.BrandUuId;
      set => _model.BrandUuId = value;
    }
    public Guid CategoryUuId {
      get => _model.CategoryUuId;
      set => _model.CategoryUuId = value;
    }
    public byte[] ImageData {
      get => _model.ImageData;
      set {
        _model.ImageData = value;
        RaisePropertiesChanged();
      }
    }

    public bool HasImage => _model.ImageData != null;

    public BitmapImage Image => HasImage ? BitmapImageHelper.GetFromByteArray(_model.ImageData) : null;

    public Products GetModel() => _model;
  }
}