using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using StoreWPFDXApp.Data;
using StoreWPFDXApp.ViewModels.Services;
using StoreWPFDXApp.ViewModels.Services.Abstract;

namespace StoreWPFDXApp.ViewModels {
  public class CategoriesViewModel : ViewModelBase {
    private readonly ICategoriesService _categoriesService;

    public CategoriesViewModel() {
      _categoriesService = new CategoriesService();

      var data = Task.Run(async () => await _categoriesService.GetAllAsync()).Result;
      Categories.AddRange(data.Select(x => new CategoryNodeItemViewModel(x)));
    }

    public List<CategoryNodeItemViewModel> Categories { get; } = new List<CategoryNodeItemViewModel>();
  }
}
