using HumbattUIKitSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Mvvm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HumbattUIKitSample
{
    public class MainViewModel : SearchViewModel<ItemModel, ObservableCollection<ItemModel>>
    {
        public override async Task RefreshAsync()
        {
            Items = new ObservableCollection<ItemModel>()
            {
                new ItemModel()
                {
                    Name = "Test Item",
                    Count = 1,

                },
                new ItemModel()
                {
                    Name = "Test Item 2",
                    Count = 1,

                },
            };
        }

        private bool _showAddButton;

        public bool ShowAddButton
        {
            get { return _showAddButton; }
            set { _showAddButton = value; NotifyPropertyChanged(nameof(ShowAddButton)); }
        }

        private ItemModel _selectedItem;

        public new ItemModel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; NotifyPropertyChanged(nameof(SelectedItem)); }
        }



        public ICommand DoubleClickCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        if (SelectedItem == null)
                            throw new Exception("SelectedItem cannot be null");

                        MessageBox.Show($"Clicked {SelectedItem.Name}", "Double Clicked");

                    }
                    catch (Exception ex)
                    {

                        NotifyErrorOccurred(ex);
                    }
                });
            }
        }



        protected override ObservableCollection<ItemModel> ApplyFilter(ObservableCollection<ItemModel> data)
        {

            if (string.IsNullOrWhiteSpace(SearchText))
                return data;

            return data.Where(x => x.Name.ToLower().Contains(SearchText.ToLower())).ToObservable();
        }

        public MainViewModel()
        {
            ShowAddButton = true;
        }
    }
}
