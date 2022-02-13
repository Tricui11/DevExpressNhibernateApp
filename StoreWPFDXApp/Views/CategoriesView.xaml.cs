using System;
using System.Windows;

namespace StoreWPFDXApp.Views {
  /// <summary>
  /// Interaction logic for CategoriesView.xaml
  /// </summary>
  public partial class CategoriesView : Window {
    public CategoriesView() {
      InitializeComponent();
    }

    void OnInitNewNode(object sender, DevExpress.Xpf.Grid.TreeList.TreeListNodeEventArgs e) {
      tlView.SetNodeValue(e.Node, "ID", tlView.TotalNodesCount + 1);
    }
  }
}
