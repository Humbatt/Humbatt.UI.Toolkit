using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Humbatt.UI.Toolkit.Desktop.Editors
{
	public class DecimalTextBox : TextBox
	{
		private readonly string[] _acceptedCurrencies = new string[] { "£", "$", "€" };
		internal string _currencySymbol;

		public DecimalTextBox()
		{
			TextChanged += DecimalTextBox_TextChanged;
			LostFocus += DecimalTextBox_LostFocus;
		}

		void DecimalTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
			Text = Number.ToString(NumberFormat);
		}

		void DecimalTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			_currencySymbol = null;

			decimal zahl;
			if (string.IsNullOrWhiteSpace(Text))
			{
				Number = 0;
			}
			else if (decimal.TryParse(Text, out zahl))
			{
				Number = decimal.Parse(zahl.ToString(NumberFormat));
			}
			else if (AllowCurrency == true && _acceptedCurrencies.Contains(Text[0].ToString()))
			{
				_currencySymbol = Text[0].ToString();

				var cleanText = Text.Substring(1);

				if (Text.Length <= 1)
				{
					//do nothing with the number
				}
				else if (decimal.TryParse(cleanText, out zahl))
				{
					Number = decimal.Parse(zahl.ToString(NumberFormat));
				}
				else
				{
					ValidationError validationError =
					new ValidationError(new ExceptionValidationRule(), GetBindingExpression(NumberProperty));

					validationError.ErrorContent = "No at valid number";

					Validation.MarkInvalid(
						GetBindingExpression(NumberProperty),
						validationError);
				}

			}
			else
			{
				ValidationError validationError =
					new ValidationError(new ExceptionValidationRule(), GetBindingExpression(NumberProperty));

				validationError.ErrorContent = "No at valid number";

				Validation.MarkInvalid(
					GetBindingExpression(NumberProperty),
					validationError);

			}
		}

		private static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

			var c = (DecimalTextBox)d;

			decimal zahl;

			if (string.IsNullOrWhiteSpace(c.Text))
			{
				zahl = 0;
			}
			else if (decimal.TryParse(c.Text, out zahl))
			{

			}

			if (!c.Number.Equals(zahl))
			{
				if (c.AllowCurrency)
				{
					c.Text = $"{c._currencySymbol}" + ((decimal)e.NewValue).ToString(c.NumberFormat);
				}
				else
				{
					c.Text = ((decimal)e.NewValue).ToString(c.NumberFormat);
				}


			}

		}

		public string NumberFormat
		{
			get { return (string)this.GetValue(NumberFormatProperty); }
			set { this.SetValue(NumberFormatProperty, value); }
		}

		public decimal Number
		{
			get { return (decimal)this.GetValue(NumberProperty); }
			set { this.SetValue(NumberProperty, value); }
		}

		public string StringValue
		{
			get { return (string)this.GetValue(StringValueProperty); }
			set { this.SetValue(StringValueProperty, value); }
		}


		public bool AllowCurrency
		{
			get { return (bool)this.GetValue(AllowCurrencyProperty); }
			set { this.SetValue(AllowCurrencyProperty, value); }
		}

		public static readonly DependencyProperty NumberProperty = DependencyProperty.Register(
			"Number", typeof(decimal), typeof(DecimalTextBox),
			new FrameworkPropertyMetadata
				(
					0m,
					FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnNumberChanged
				)
		);

		public static readonly DependencyProperty StringValueProperty = DependencyProperty.Register(
		   "StringValue", typeof(string), typeof(DecimalTextBox),
		   new FrameworkPropertyMetadata
			   (
				   string.Empty,
				   FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
			   )
	   );

		public static readonly DependencyProperty NumberFormatProperty = DependencyProperty.Register(
			"NumberFormat", typeof(string), typeof(DecimalTextBox),
			new FrameworkPropertyMetadata
				(
					"N2",
					FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
				)
		);

		public static readonly DependencyProperty AllowCurrencyProperty = DependencyProperty.Register(
			"AllowCurrency", typeof(bool), typeof(DecimalTextBox),
			new FrameworkPropertyMetadata
				(
					false,
					FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
				)
		);

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			this.VerticalAlignment = VerticalAlignment.Center;
			this.VerticalContentAlignment = VerticalAlignment.Center;

			this.PreviewTextInput += DecimalTextBox_PreviewTextInput;
		}

		private void DecimalTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{

			Regex regex = new Regex("[^0-9.]+");

			var isValid = false;

			if (this.AllowCurrency && _acceptedCurrencies.Contains(e.Text) && this.CaretIndex == 0)
			{

				isValid = false;
			}
			else
			{
				isValid = regex.IsMatch(e.Text);

				if (e.Text.Equals(".") && this.Text.Contains("."))
					isValid = true;
			}

			e.Handled = isValid;
		}

	}
}
