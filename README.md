# Humbatt.UI.Toolkit

UI toolkit(controls and helper functions) for WPF and WinUI (Experimental).

This toolkit includes

 - Behaviours
 - Converters
 - Controls
 - Editors

### Converters (WinUI, WPF and MAUI)

- BooleanToReverseVisibilityConverter
- BooleanToVisibilityConverter
- BoolToColorConverter
- BoolToFontWeight
- BytesToBitmapConverter
- DateToStringConverter
- EnumMatchToBooleanConverter
- HexStringToColorConverter
- PercentValueConverter

### Controls (WPF)

- FluidProgressBar
- SearchableListControl

### Editors (WPF)

- AutoCompleteTextBox
- BindableListBox
- DecimalTextBox
- MultiComboBox

## Package Changes

We have changed the packages to provide a more consistent naming mechanism and to allow the WinUI and WPF component to exist in a single package.

We have also addded MAUI support.

 

### Humbatt.UI.Toolkit.Desktop
The dekstop package includes both WinUI and WPF assemblies and it will automatically apply the correct one based on the  target framework moniker (TFM) of your project or app.

For WinUI make your TFM - {netversion}-windows10.0  

		E.g. net9.0-windows10.0.19041.0, net8.0-windows10.0.19041.0

For WPF use - {netversion}-net9.0-windows or {netversion}-net9.0-windows7.0  

		E.g.  net9.0-windows

### Package Info (Old)

Platform/Feature               | Package name                              | Stable                              | Beta
-----------------------|-------------------------------------------|------------------------------------------------|----------------
WPF             | `Humbatt.UI.Toolkit.WPF` | [![NuGet](https://img.shields.io/nuget/v/Humbatt.UI.Toolkit.WPF.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.WPF/) | [![NuGet](https://img.shields.io/nuget/vpre/Humbatt.UI.Toolkit.WPF.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.WPF/) |
Metro(MahApps)           | `Humbatt.UI.Toolkit.WPF.Metro` | [![NuGet](https://img.shields.io/nuget/v/Humbatt.UI.Toolkit.WPF.Metro.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.WPF.Metro/) |  [![NuGet](https://img.shields.io/nuget/vpre/Humbatt.UI.Toolkit.WPF.Metro.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.WPF.Metro/) |
MVVM             | `Humbatt.UI.Toolkit.WPF.Mvvm` | [![NuGet](https://img.shields.io/nuget/v/Humbatt.UI.Toolkit.WPF.Mvvm.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.WPF.Mvvm/) |[![NuGet](https://img.shields.io/nuget/vpre/Humbatt.UI.Toolkit.WPF.Mvvm.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.WPF.Mvvm/) |

### Package Info (New)

Platform/Feature               | Package name                              | Stable                              | Beta
-----------------------|-------------------------------------------|------------------------------------------------|----------------
Desktop (WinUI and WPF)  | `Humbatt.UI.Toolkit.Desktop` | [![NuGet](https://img.shields.io/nuget/v/Humbatt.UI.Toolkit.Desktop.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.Desktop/) | [![NuGet](https://img.shields.io/nuget/vpre/Humbatt.UI.Toolkit.Desktop.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.Desktop/) |
MahApps           | `Humbatt.UI.Toolkit.Desktop.MahApps` | [![NuGet](https://img.shields.io/nuget/v/Humbatt.UI.Toolkit.Desktop.MahApps.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.Desktop.MahApps/) |  [![NuGet](https://img.shields.io/nuget/vpre/Humbatt.UI.Toolkit.Desktop.MahApps.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.Desktop.MahApps/) |
MVVM             | `Humbatt.UI.Toolkit.Desktop.Mvvm` | [![NuGet](https://img.shields.io/nuget/v/Humbatt.UI.Toolkit.Desktop.Mvvm.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.Desktop.Mvvm/) |[![NuGet](https://img.shields.io/nuget/vpre/Humbatt.UI.Toolkit.Desktop.Mvvm.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.Desktop.Mvvm/) |
MAUI             | `Humbatt.UI.Toolkit.Mobile` | [![NuGet](https://img.shields.io/nuget/v/Humbatt.UI.Toolkit.Mobile.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.Mobile/) |[![NuGet](https://img.shields.io/nuget/vpre/Humbatt.UI.Toolkit.Mobile.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Humbatt.UI.Toolkit.Mobile/) |
  

