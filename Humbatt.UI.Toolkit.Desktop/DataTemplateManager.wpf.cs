﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;

namespace Humbatt.UI.Toolkit.Desktop
{
	public class DataTemplateManager
	{
		#region Static Methods
		private static Lazy<DataTemplateManager> _instance = new Lazy<DataTemplateManager>(() => new DataTemplateManager());

		/// <summary>
		/// Gets the shared instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static DataTemplateManager Instance => _instance.Value;

		#endregion

		#region Methods
		public void RegisterDataTemplate<TViewModel, TView>() where TView : FrameworkElement
		{
			RegisterDataTemplate(typeof(TViewModel), typeof(TView));
		}

		public void RegisterDataTemplate(Type viewModelType, Type viewType)
		{
			var template = CreateTemplate(viewModelType, viewType);
			var key = template.DataTemplateKey;

			if (!Application.Current.Resources.Contains(key))
				Application.Current.Resources.Add(key, template);
		}

		private DataTemplate CreateTemplate(Type viewModelType, Type viewType)
		{
			const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
			var xaml = String.Format(xamlTemplate, viewModelType.Name, viewType.Name, viewModelType.Namespace, viewType.Namespace);

			var context = new ParserContext();

			context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
			context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
			context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);

			context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
			context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
			context.XmlnsDictionary.Add("vm", "vm");
			context.XmlnsDictionary.Add("v", "v");

			var template = (DataTemplate)XamlReader.Parse(xaml, context);
			return template;
		}

		#endregion
	}
}
