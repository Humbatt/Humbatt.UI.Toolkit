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
using Humbatt.UI.Toolkit.Core;
using HumbattUIKitSample.Models;

namespace HumbattUIKitSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; DataContext = _viewModel; }
        }


        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainViewModel();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.IsLoaded)
            {
                await ViewModel.RefreshAsync();

                ViewModel.IsLoaded = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var items = EnumHelper.BuildOptions<ItemTypes>();

            ItemTypes[] exclude = [ItemTypes.NotDone];

            var items2 = EnumHelper.BuildOptions(exclude);

            Dictionary<ItemTypes, string> mapping = [];

            mapping.Add(ItemTypes.NotDone, "Not Done");
            mapping.Add(ItemTypes.Done, "Did Do");
            mapping.Add(ItemTypes.Things, "Some Things");
            mapping.Add(ItemTypes.MoreThings, "More Things");

            var items3 = EnumHelper.BuildOptions(mapping);

            var items4 = EnumHelper.BuildOptions(mapping, exclude);

            var items5 = ViewModel.Items.BuildOptionItems(obj => obj.Name);

            var items6 = ViewModel.Items.BuildOptionItems(obj => obj.Name, obj => "Sub-Title");

            if (items6.Any())
            {

            }

        }
    }
}
