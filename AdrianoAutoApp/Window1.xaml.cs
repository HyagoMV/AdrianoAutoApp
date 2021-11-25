using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace AdrianoAutoApp {


  public partial class Window1 : Window {

    private class Item {
      public string Name { get; set; }
      public string Category { get; set; }
    }

    public Window1() {
      InitializeComponent();

      List<Item> items = new List<Item>();
      items.Add(new Item() { Name = "Photoshop", Category = "Adobe" });
      items.Add(new Item() { Name = "CorelDRAW", Category = "Corel" });
      items.Add(new Item() { Name = "Lumion", Category = "Lumion" });

      ListCollectionView lcv = new ListCollectionView(items);
      lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

      this.comboBox.ItemsSource = lcv;

    }

    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      #region Carrega a logo do app de acordo como item selecionado
      switch (((Item) e.AddedItems[0]).Name) {
        case "Photoshop":
          imgProgram.Source = new BitmapImage(new Uri("pack://application:,,,/Images/photoshop.png"));
          break;
        case "CorelDRAW":
          imgProgram.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coreldraw.png"));
          break;
        case "Lumion":
          imgProgram.Source = new BitmapImage(new Uri("pack://application:,,,/Images/lumion.png"));
          break;
      }
      #endregion

      #region Reset nos controles
      cBoxHost.IsChecked = false;
      cBoxFirewall.IsChecked = false;
      MSG.Visibility = Visibility.Hidden;
      #endregion
    }

    private void CheckBoxHost_Checked(object sender, RoutedEventArgs e) {
      #region Lógica do arquivo HOST
      switch (((Item) comboBox.Items.CurrentItem).Name) {
        case "Photoshop":
          HostLogic.ApplyLogic(HostLogic.PorgramSupport.ADOBLE_PHOTOSHOP);
          break;
        case "CorelDRAW":
          HostLogic.ApplyLogic(HostLogic.PorgramSupport.COREL_DRAW);
          break;
        case "Lumion":
          HostLogic.ApplyLogic(HostLogic.PorgramSupport.LUMION);
          break;
      }
      #endregion

      MSG.Visibility = Visibility.Visible;
    }

    private void CheckBoxFirewall_Checked(object sender, RoutedEventArgs e) {
      System.Diagnostics.Process.Start( @"C:\WINDOWS\system32\wf.msc");
    }

    private void Button_Click(object sender, RoutedEventArgs e) {

      MSG.Visibility = Visibility.Hidden;

    }

    private void Button_Click_1(object sender, RoutedEventArgs e) {
      MSG.Visibility = Visibility.Hidden;
        System.Diagnostics.Process.Start("explorer.exe", Environment
      .GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\Drivers\Etc\Hosts");
      }
  }
}
