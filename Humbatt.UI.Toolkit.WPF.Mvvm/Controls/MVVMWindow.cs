using System;
using System.Collections.Generic;
using System.Linq;
using System.Mvvm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Humbatt.UI.Toolkit.WPF.Mvvm.Controls
{
    public class MVVMWindow : Window
    {
        private ViewModel viewModel;

        public ViewModel ViewModel
        {
            get { return viewModel; }
           private set { viewModel = value; DataContext = value; }
        }

        public T GetTypeViewModel<T>() where T : ViewModel
        {
            return (T)ViewModel;
        }

        public void SetViewModel(ViewModel model)
        {
            ViewModel = model;

            ViewModel.OnComplete += ViewModel_OnCloseRequested;
        }

        protected void RunOnUIThread(Action action)
        {
            this.Dispatcher.BeginInvoke(action);
        }

        public MVVMWindow() : base()
        {
            
        }

        private void ViewModel_OnCloseRequested(object sender, bool e)
        {
            this.RunOnUIThread(() =>
            {
                if (System.Windows.Interop.ComponentDispatcher.IsThreadModal)
                {
                    this.DialogResult = e;
                }
                else
                {
                    this.Close();
                }
            });

        }
    }
}
