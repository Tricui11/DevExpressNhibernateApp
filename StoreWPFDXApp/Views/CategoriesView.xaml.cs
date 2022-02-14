using System.Windows;
using DevExpress.Xpf.Grid;

namespace StoreWPFDXApp.Views {
  /// <summary>
  /// Interaction logic for CategoriesView.xaml
  /// </summary>
  public partial class CategoriesView : Window {
    public CategoriesView() {
      InitializeComponent();
    }

    private void DeleteNodeClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e) {
      GridCommands.DeleteFocusedRow.Execute(sender, e.Item);
    }
  }
}
