using Wpf.Ui.Controls;
using WPFUISample.ViewModels.Pages;

namespace WPFUISample.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.IsLoaded)
            {
                await ViewModel.RefreshAsync();

                ViewModel.IsLoaded = true;
            }
        }
    }
}
