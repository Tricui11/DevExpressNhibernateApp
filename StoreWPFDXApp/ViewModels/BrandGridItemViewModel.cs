using System;
using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels {
  public class BrandGridItemViewModel {
    private readonly Brand _model;

    public BrandGridItemViewModel() {
      _model = new Brand();
    }

    public BrandGridItemViewModel(Brand model) {
      _model = model;
    }

    public Guid UuId => _model.UuId;
    public string Name {
      get => _model.Name;
      set => _model.Name = value;
    }

    public Brand GetModel() => _model;
  }
}