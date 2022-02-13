using System.ComponentModel;

namespace StoreWPFDXApp.Data {
  public class CategoryNodeItemViewModel : IEditableObject {
    private readonly Categories _model;
    public CategoryNodeItemViewModel(Categories model) {
      _model = model;
    }
    public int ID => _model.ID;
    public int ParentID {
      get => _model.ParentID;
      set => _model.ParentID = value;
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
    void IEditableObject.EndEdit() { IsUpdated = true; }
  }
}
