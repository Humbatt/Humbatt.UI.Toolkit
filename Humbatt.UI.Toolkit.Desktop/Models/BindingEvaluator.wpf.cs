using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Humbatt.UI.Toolkit.Desktop.Models
{
	public class BindingEvaluator : FrameworkElement
	{

		#region "Fields"


		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(BindingEvaluator), new FrameworkPropertyMetadata(string.Empty));

		#endregion

		#region "Constructors"

		public BindingEvaluator(Binding binding)
		{
			ValueBinding = binding;
		}

		#endregion

		#region "Properties"

		public string Value
		{
			get { return (string)GetValue(ValueProperty); }

			set { SetValue(ValueProperty, value); }
		}

		public Binding ValueBinding { get; set; }

		#endregion

		#region "Methods"

		public string Evaluate(object dataItem)
		{
			DataContext = dataItem;
			SetBinding(ValueProperty, ValueBinding);
			return Value;
		}

		#endregion

	}

}
