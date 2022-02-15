using System;
using System.ComponentModel;
using System.Threading.Tasks;
using StoreWPFDXApp.Models;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels {
  public class CategoryNodeItemViewModel : IEditableObject {
    private readonly Categories _model;

    public CategoryNodeItemViewModel() {
      _model = new Categories();
    }

    public CategoryNodeItemViewModel(Categories model, ICategoriesService categoriesService) {
      _model = model;
      CategoriesService = categoriesService;
    }

    public ICategoriesService CategoriesService { get; set; }

    public Guid UuId => _model.UuId;
    public Guid ParentUuId {
      get => _model.ParentUuId;
      set {
        if (_model.UuId != default(Guid)) {
          Task.Run(async () => await CategoriesService.UpdateParentAsync(_model.UuId, value));
        }
        _model.ParentUuId = value;
      }
    }
    public string Name {
      get => _model.Name;
      set => _model.Name = value;
    }
    public string Description {
      get => _model.Description;
      set => _model.Description = value;
    }
    public string KeyWords {
      get => _model.KeyWords;
      set => _model.KeyWords = value;
    }

    public bool IsUpdated { get; set; }

    void IEditableObject.BeginEdit() { IsUpdated = false; }
    void IEditableObject.CancelEdit() { IsUpdated = false; }
    void IEditableObject.EndEdit() {
      if (IsUpdated) { return; }
      IsUpdated = true;
      if (_model.UuId == default(Guid)) {
        var newUuId = Task.Run(async () => await CategoriesService.CreateAsync(_model)).Result;
        _model.UuId = newUuId;
      } else {
        Task.Run(async () => await CategoriesService.UpdateAsync(_model));
      }
    }
  }
}
