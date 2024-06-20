#if WINUI
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;
#elif WPF
using System.Windows.Markup;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humbatt.UI.Toolkit.Desktop.Converters
{
	public abstract class BaseConverter : MarkupExtension
	{

#if WINUI
		protected override object ProvideValue(IXamlServiceProvider serviceProvider)
		{
			return this;
		}

		protected override object ProvideValue()
		{
			return this;
		}
#elif WPF
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
#endif
	}
}
