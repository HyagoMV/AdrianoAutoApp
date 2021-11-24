    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Collections;

namespace AdrianoAutoApp {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    string hostFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\Drivers\Etc\Hosts";

    public MainWindow() {
      InitializeComponent();

      if (!File.Exists(hostFilePath))
        File.Create(hostFilePath);
    }


    private void Adobe_Checked(object sender, RoutedEventArgs e) {
      string hostContent = File.ReadAllText(hostFilePath);

      File.AppendAllText(hostFilePath, "\n");

      if (!hostContent.Contains("#Adobe")) {
        File.AppendAllText(hostFilePath, "\n#Adobe\n" + Properties.Resources.Adobe + "\n");
      }
    }

    private void CorelDraw_Checked(object sender, RoutedEventArgs e) {
      string hostContent = File.ReadAllText(hostFilePath);

      File.AppendAllText(hostFilePath, "\n");

      if (!hostContent.Contains("#CorelDraw")) {
        File.AppendAllText(hostFilePath, "\n#CorelDraw\n" + Properties.Resources.CorelDraw + "\n");
      }
    }
    private void Lumion_Checked(object sender, RoutedEventArgs e) {
      string hostContent = File.ReadAllText(hostFilePath);

      File.AppendAllText(hostFilePath, "\n");

      if (!hostContent.Contains("#Lumion")) {
        File.AppendAllText(hostFilePath, "\n#Lumion\n" + Properties.Resources.Lumion + "\n");
      }
    }
  }
}
