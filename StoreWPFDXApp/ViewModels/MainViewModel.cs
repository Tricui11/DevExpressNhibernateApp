﻿using DevExpress.Mvvm;
using StoreWPFDXApp.Views;

namespace StoreWPFDXApp.ViewModels {
  public class MainViewModel : ViewModelBase {
    public MainViewModel() {
      OpenCategoriesWindowCommand = new DelegateCommand(OpenCategoriesWindowCommandExecute);
    }
    public DelegateCommand OpenCategoriesWindowCommand { get; }
    void OpenCategoriesWindowCommandExecute() {
      var win = new CategoriesView();
      win.Show();
    }
  }
}
