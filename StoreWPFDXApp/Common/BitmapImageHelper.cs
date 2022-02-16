using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace StoreWPFDXApp.Common {
  static class BitmapImageHelper {
    static public BitmapImage GetFromByteArray(byte[] array) {
      BitmapImage image = new BitmapImage();
      image.BeginInit();
      image.StreamSource = new System.IO.MemoryStream(array);
      image.EndInit();
      return image;
    }

    static public string OpenImageFromFileAndReturnPath() {
      var openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.webp";
      if (openFileDialog.ShowDialog() == false) {
        return string.Empty;
      }
      return openFileDialog.FileName;
    }
  }
}