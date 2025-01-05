using System;
using System.Collections.Generic;
using System.Linq;
using System.Mvvm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Humbatt.UI.Toolkit.Desktop.Controls
{
     public class MVVMUserControl : UserControl
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


        protected void RunOnUIThread(Action action)
        {
            this.Dispatcher.BeginInvoke(action);
        }

        public void SetViewModel(ViewModel model)
        {
            ViewModel = model;

        }

        public MVVMUserControl() : base()
        {
            
        }

    }

}
