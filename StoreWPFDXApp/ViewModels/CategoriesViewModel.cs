using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels {
  public class CategoriesViewModel : ViewModelBase {
    private readonly ICategoryService _categoriesService;
    private List<Guid> _actualUndeletedCategoriesUuIds;

    public CategoriesViewModel(ICategoryService categoriesService) {
      _categoriesService = categoriesService;

      var categories = Task.Run(async () => await _categoriesService.GetAllAsync()).Result;
      foreach (var category in categories) {
        var vm = new CategoryNodeItemViewModel(category, _categoriesService);
        Categories.Add(vm);
      }
      Categories.CollectionChanged += Categories_CollectionChanged;

      DeleteSelectedItemCommand = new AsyncCommand(DeleteSelectedItemCommandExecuteAsync);
      _actualUndeletedCategoriesUuIds = Categories.Select(x => x.UuId).ToList();
    }

    public ObservableCollection<CategoryNodeItemViewModel> Categories { get; } = new ObservableCollection<CategoryNodeItemViewModel>();
    public CategoryNodeItemViewModel SelectedCategory { get; set; }

    public AsyncCommand DeleteSelectedItemCommand { get; }
    async Task DeleteSelectedItemCommandExecuteAsync() {
      var updatedUndeletedCategoriesUuIds = Categories.Select(x => x.UuId).ToList();
      var uuIdsToDelete = _actualUndeletedCategoriesUuIds.Except(updatedUndeletedCategoriesUuIds);
      _actualUndeletedCategoriesUuIds = updatedUndeletedCategoriesUuIds;
      await _categoriesService.DeleteAsync(uuIdsToDelete);
    }

    void Categories_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      if (e.Action == NotifyCollectionChangedAction.Add) {
        Categories.Last().CategoriesService = _categoriesService;
        _actualUndeletedCategoriesUuIds = Categories.Select(x => x.UuId).ToList();
      }
    }
  }
}
