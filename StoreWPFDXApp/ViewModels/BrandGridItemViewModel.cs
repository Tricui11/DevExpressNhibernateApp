﻿using StoreWPFDXApp.Models;

namespace StoreWPFDXApp.ViewModels {
  public class BrandGridItemViewModel {
    private readonly Brands _model;

    public BrandGridItemViewModel() {
      _model = new Brands();
    }

    public BrandGridItemViewModel(Brands model) {
      _model = model;
    }

    public int ID => _model.ID;
    public string Name {
      get => _model.Name;
      set => _model.Name = value;
    }

    public Brands GetModel() => _model;
  }
}