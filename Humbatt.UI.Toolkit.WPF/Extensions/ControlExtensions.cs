using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Controls
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Begins the specified action on the UI thread.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="exec">The execute.</param>
        public static void BeginOnUiThread(this Control target, Action exec)
        {
            target.Dispatcher.BeginInvoke(exec);
        }

        /// <summary>
        /// Begins the specified action on the UI thread and await
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="exec">The execute.</param>
        public static async Task BeginOnUiThreadAsync(this Control target, Action exec)
        {
            await target.Dispatcher.BeginInvoke(exec);
        }
    }
}
