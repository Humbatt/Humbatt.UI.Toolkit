using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Humbatt.UI.Toolkit.Core.Models;

/// <summary>
/// Option Item for type
/// Implements the <see cref="INotifyPropertyChanged" />
/// </summary>
/// <seealso cref="INotifyPropertyChanged" />
public struct OptionItem<T> : INotifyPropertyChanged
{
    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged = delegate { };


    /// <summary>
    /// The name
    /// </summary>
    private string _name;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Title
    {
        get { return _name; }
        set { _name = value; NotifyPropertyChanged(nameof(Title)); }
    }

    /// <summary>
    /// The value
    /// </summary>
    private T _value;

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    public T Value
    {
        get { return _value; }
        set { _value = value; NotifyPropertyChanged(nameof(Value)); }
    }

    /// <summary>
    /// The sub title
    /// </summary>
    private string _subTitle;

    /// <summary>
    /// Gets or sets the sub title.
    /// </summary>
    /// <value>The sub title.</value>
    public string SubTitle
    {
        get { return _subTitle; }
        set { _subTitle = value; NotifyPropertyChanged(nameof(SubTitle)); }
    }

    public OptionItem()
    {
        
    }

    /// <summary>
    /// Notifies the property changed.
    /// </summary>
    /// <param name="name">The name.</param>
    public void NotifyPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
