using System;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using StoreWPFDXApp.Common;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels {
  public class ProductGridItemViewModel : ViewModelBase {
    private readonly Product _model;

    public ProductGridItemViewModel() {
      _model = new Product();
      _model.Brands = new Brand();
      _model.Categories = new Category();
    }

    public ProductGridItemViewModel(Product model) {
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
    public Guid? BrandUuId {
      get => _model.BrandUuId;
      set => _model.BrandUuId = value;
    }
    public Guid? CategoryUuId {
      get => _model.CategoryUuId;
      set => _model.CategoryUuId = value;
    }
    public byte[] ImageData {
      get => _model.ImageData;
      set {
        _model.ImageData = value;
        RaisePropertyChanged(nameof(Image));
      }
    }

    public BitmapImage Image => _model.ImageData != null ? BitmapImageHelper.GetFromByteArray(_model.ImageData) : null;

    public Product GetModel() => _model;
  }
}