#if WINUI
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Microsoft.Xaml.Interactivity;
using CommunityToolkit.WinUI.UI.Controls;
#elif WPF
using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
#endif
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Humbatt.UI.Toolkit.Desktop
{
	public class DataGridSelectedItemsBlendBehavior : Behavior<DataGrid>
	{
		public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(IEnumerable), typeof(DataGridSelectedItemsBlendBehavior), new PropertyMetadata(null)
		{

		});

		public IEnumerable SelectedItems
		{
			get
			{
				return (IEnumerable)GetValue(SelectedItemsProperty);
			}
			set
			{
				SetValue(SelectedItemsProperty, value);
			}
		}

		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.SelectionChanged += OnSelectionChanged;
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();
			if (this.AssociatedObject != null)
				this.AssociatedObject.SelectionChanged -= OnSelectionChanged;
		}

		private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems != null && e.AddedItems.Count > 0 && this.SelectedItems != null)
			{
				if (this.SelectedItems is ICollection)
				{
					foreach (object obj in e.AddedItems)
						((IList)this.SelectedItems).Add(obj);
				}


			}

			if (e.RemovedItems != null && e.RemovedItems.Count > 0 && this.SelectedItems != null)
			{
				if (this.SelectedItems is ICollection)
				{
					foreach (object obj in e.RemovedItems)
						((IList)this.SelectedItems).Remove(obj);
				}
			}

		}
	}
}
