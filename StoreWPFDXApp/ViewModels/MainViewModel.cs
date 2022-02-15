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
      win.Show();
    }

    void OpenBrandsWindowCommandExecute() {
      var win = new BrandsView();
      win.Show();
    }

    void OpenProductsWindowCommandExecute() {
      var win = new ProductsView();
      win.Show();
    }
  }
}
