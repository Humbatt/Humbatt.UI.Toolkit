﻿using System.Windows;
using System.Windows.Markup;

[assembly: ThemeInfo(
	ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
									 //(used if a resource is not found in the page,
									 // or application resource dictionaries)
	ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
											  //(used if a resource is not found in the page,
											  // app, or any theme specific resource dictionaries)
)]


[assembly: XmlnsDefinition("http://wpf.humbatt.com/winfx/xaml/editors", "Humbatt.UI.Toolkit.Desktop.Editors", AssemblyName = "Humbatt.UI.Toolkit.Desktop")]
[assembly: XmlnsDefinition("http://wpf.humbatt.com/winfx/xaml/converters", "Humbatt.UI.Toolkit.Desktop.Converters", AssemblyName = "Humbatt.UI.Toolkit.Desktop")]
[assembly: XmlnsDefinition("http://wpf.humbatt.com/winfx/xaml/controls", "Humbatt.UI.Toolkit.Desktop.Controls", AssemblyName = "Humbatt.UI.Toolkit.Desktop")]