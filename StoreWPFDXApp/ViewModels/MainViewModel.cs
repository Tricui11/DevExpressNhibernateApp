using DevExpress.Mvvm;
using StoreWPFDXApp.Views;

namespace StoreWPFDXApp.ViewModels {
  public class MainViewModel : ViewModelBase {
    public MainViewModel() {
      OpenCategoriesWindowCommand = new DelegateCommand(OpenCategoriesWindowCommandExecute);
      OpenBrandsWindowCommand = new DelegateCommand(OpenBrandsWindowCommandExecute);
      OpenProductsWindowCommand = new DelegateCommand(OpenProductsWindowCommandExecute);
    }
    public DelegateCommand OpenCategoriesWindowCommand { get; }
    public DelegateCommand OpenBrandsWindowCommand { get; }
    public DelegateCommand OpenProductsWindowCommand { get; }

    void OpenCategoriesWindowCommandExecute() {
      var win = new CategoriesView();
      win.ShowDialog();
    }

    void OpenBrandsWindowCommandExecute() {
      var win = new BrandsView();
      win.ShowDialog();
    }

    void OpenProductsWindowCommandExecute() {
      var win = new ProductsView();
      win.ShowDialog();
    }
  }
}
