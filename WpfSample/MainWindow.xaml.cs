﻿using System;
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

namespace WpfSample
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
	}
}
