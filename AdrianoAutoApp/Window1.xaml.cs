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
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window {
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

      #region Desmarca os Checkbox para a próxima seleção
      cBoxHost.IsChecked = false;
      cBoxFirewall.IsChecked = false;
      #endregion
    }

    #region Lógica do HOST
    private void CheckBox_Checked(object sender, RoutedEventArgs e) {
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
    }
    #endregion
  }

  public class Item {
    public string Name { get; set; }
    public string Category { get; set; }
  }
}
