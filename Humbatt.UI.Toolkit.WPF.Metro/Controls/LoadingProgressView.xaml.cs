using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Humbatt.UI.Toolkit.WPF.Controls
{
    /// <summary>
    /// Interaction logic for LoadingProgressView.xaml
    /// </summary>
    public partial class LoadingProgressView : UserControl
    {
         public readonly static DependencyProperty LoadingMessageProperty = DependencyProperty.Register(nameof(LoadingMessage), typeof(string), typeof(LoadingProgressView), new PropertyMetadata("Loading..", OnLoadingMessageChanged));

        public string LoadingMessage
        {
            get { return (string)GetValue(LoadingMessageProperty); }
            set { SetValue(LoadingMessageProperty, value); }
        }

        /// <summary>
        /// Handles changes to the TotalDuration property.
        /// </summary>
        /// <param name="d">FluidProgressBar</param>
        /// <param name="e">DependencyProperty changed event arguments</param>
        private static void OnLoadingMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pBar = (LoadingProgressView)d;
            var oldMessage = (string)e.OldValue;
            var newMessage = pBar.LoadingMessage;
            pBar.OnLoadingMessageChanged(oldMessage, newMessage);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the TotalDuration property.
        /// </summary>
        /// <param name="oldMessage">Old Value</param>
        /// <param name="newMessage">New Value</param>
        protected void OnLoadingMessageChanged(string oldMessage, string newMessage)
        {
            if (!oldMessage.Equals(newMessage))
                txtLabel.Text = newMessage;
        }

        public LoadingProgressView()
        {
            InitializeComponent();

            this.IsVisibleChanged += LoadingProgressView_IsVisibleChanged;
        }

        void LoadingProgressView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var newVisib = (bool)e.NewValue;

            rngActive.IsActive = newVisib;

            

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var msg = LoadingMessage;

            txtLabel.Text = msg;
        }
    }
}
