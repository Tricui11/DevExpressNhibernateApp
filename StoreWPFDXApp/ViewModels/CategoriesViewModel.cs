using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels {
  public class CategoriesViewModel : ViewModelBase {
    private readonly ICategoriesService _categoriesService;
    private List<int> _actualUndeletedCategoriesIds;

    public CategoriesViewModel(ICategoriesService categoriesService) {
      _categoriesService = categoriesService;

      var categories = Task.Run(async () => await _categoriesService.GetAllAsync()).Result;
      foreach (var category in categories) {
        var vm = new CategoryNodeItemViewModel(category, _categoriesService);
        Categories.Add(vm);
      }
      Categories.CollectionChanged += Categories_CollectionChanged;
      _actualUndeletedCategoriesIds = Categories.Select(x => x.ID).ToList();

      DeleteSelectedItemCommand = new AsyncCommand(DeleteSelectedItemCommandExecuteAsync);
    }

    public ObservableCollection<CategoryNodeItemViewModel> Categories { get; } = new ObservableCollection<CategoryNodeItemViewModel>();
    public CategoryNodeItemViewModel SelectedCategory { get; set; }

    public AsyncCommand DeleteSelectedItemCommand { get; }
    async Task DeleteSelectedItemCommandExecuteAsync() {
      var updatedUndeletedCategoriesIds = Categories.Select(x => x.ID).ToList();
      var iDsToDelete = _actualUndeletedCategoriesIds.Except(updatedUndeletedCategoriesIds);
      _actualUndeletedCategoriesIds = updatedUndeletedCategoriesIds;
      await _categoriesService.DeleteAsync(iDsToDelete);
    }

    void Categories_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      // Понимаю что криво, но Property Injection через PropertiesAutowired почему-то не работает
      if (e.Action == NotifyCollectionChangedAction.Add) {
        Categories.Last().CategoriesService = _categoriesService;
      }
    }
  }
}
