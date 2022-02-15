using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels {
  public class ProductGridItemViewModel {
    private readonly Products _model;

    public ProductGridItemViewModel(Products model) {
      _model = model;
    }

    public int ID => _model.ID;
    public string Name {
      get => _model.Name;
      set => _model.Name = value;
    }
  }
}
