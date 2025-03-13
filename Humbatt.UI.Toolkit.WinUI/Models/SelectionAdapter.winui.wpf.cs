#if WINUI
using Microsoft.UI.Xaml.Controls.Primitives;
using Windows.UI.Core;
using Key = Windows.System.VirtualKey;
#elif WPF
using System.Windows.Controls.Primitives;
#endif

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Humbatt.UI.Toolkit.WinUI.Models
{
	public class SelectionAdapter
	{

#region "Fields"

#endregion

#region "Constructors"

		public SelectionAdapter(Selector selector)
		{
			SelectorControl = selector;

#if WINUI
			
#elif WPF
			SelectorControl.PreviewMouseUp += OnSelectorMouseDown;
#endif
		}

		#endregion

		#region "Events"

		public delegate void CancelEventHandler();

		public delegate void CommitEventHandler();

		public delegate void SelectionChangedEventHandler();

		public event CancelEventHandler Cancel;
		public event CommitEventHandler Commit;
		public event SelectionChangedEventHandler SelectionChanged;
#endregion

#region "Properties"

		public Selector SelectorControl { get; set; }

#endregion

#region "Methods"

		public void HandleKeyDown(KeyEventArgs key)
		{
#if WINUI
			var keyValue = key.VirtualKey;
#elif WPF
			var keyValue = key.Key;
#endif
			switch (keyValue)
			{
				case Key.Down:
					IncrementSelection();
					break;
				case Key.Up:
					DecrementSelection();
					break;
				case Key.Enter:
					if (Commit != null)
					{
						Commit();
					}

					break;
				case Key.Escape:
					if (Cancel != null)
					{
						Cancel();
					}

					break;
				case Key.Tab:
					if (Commit != null)
					{
						Commit();
					}

					break;
			}
		}

		private void DecrementSelection()
		{
			if (SelectorControl.SelectedIndex == -1)
			{
				SelectorControl.SelectedIndex = SelectorControl.Items.Count - 1;
			}
			else
			{
				SelectorControl.SelectedIndex -= 1;
			}
			if (SelectionChanged != null)
			{
				SelectionChanged();
			}
		}

		private void IncrementSelection()
		{
			if (SelectorControl.SelectedIndex == SelectorControl.Items.Count - 1)
			{
				SelectorControl.SelectedIndex = -1;
			}
			else
			{
				SelectorControl.SelectedIndex += 1;
			}
			if (SelectionChanged != null)
			{
				SelectionChanged();
			}
		}

#if WINUI

#elif WPF
			

		private void OnSelectorMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Commit != null)
			{
				Commit();
			}
		}
#endif
#endregion

	}
}
