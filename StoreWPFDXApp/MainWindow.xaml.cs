using System;
using System.Configuration;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Core;

namespace StoreWPFDXApp {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : ThemedWindow {
    public MainWindow() {
      InitializeComponent();

      SetBackgroundImage();
    }
    private void SetBackgroundImage() {
      var myBrush = new ImageBrush();
      var backgroundImagepath = ConfigurationManager.AppSettings["BackgroundImagepath"];
      myBrush.ImageSource = new BitmapImage(new Uri(backgroundImagepath, UriKind.Relative));
      Background = myBrush;
    }
  }
}
