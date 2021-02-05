using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Humbatt.UI.Toolkit.WPF.Controls
{
    [TemplatePart(Name = PartHeader, Type = typeof(StackPanel))]
    [TemplatePart(Name = PartList, Type = typeof(DataGrid))]
    [TemplatePart(Name = PartFooter, Type = typeof(Border))]
    [TemplatePart(Name = PartSearchField, Type = typeof(TextBox))]
    [TemplatePart(Name = PartClearButton, Type = typeof(Button))]
    [TemplatePart(Name = PartReloadButton, Type = typeof(Button))]
    [TemplatePart(Name = PartAddButton, Type = typeof(Button))]
    [TemplatePart(Name = PartItemCount, Type = typeof(TextBlock))]
    public class SearchableListControl : Control
    {
        #region Constants


        public const string PartHeader = "PART_Header";
        public const string PartList = "PART_List";
        public const string PartFooter = "PART_Footer";
        public const string PartSearchField = "PART_SearchField";
        public const string PartClearButton = "PART_ClearButton";
        public const string PartReloadButton = "PART_ReloadButton";
        public const string PartAddButton = "PART_AddButton";
        public const string PartItemCount = "PART_ItemCount";
        #endregion

        #region Fields

        Border _header;
        DataGrid _list;
        Border _footer;
        TextBox _searcghField;

        Button _clearButton;
        Button _addButton;
        Button _refreshButton;
        TextBlock _itemCountLabel;
        private bool _labelCountInternal;

        #endregion

        #region Add Button

        public static readonly DependencyProperty AddButtonContentProperty = DependencyProperty.Register(nameof(AddButtonContent), typeof(object), typeof(SearchableListControl), new FrameworkPropertyMetadata("Add"));

        public ICommand AddCommand
        {
            get { return (ICommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }



        public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register(nameof(AddCommand), typeof(ICommand), typeof(SearchableListControl));

        public static readonly DependencyProperty ShowAddButtonProperty = DependencyProperty.Register(nameof(ShowAddButton), typeof(bool), typeof(SearchableListControl), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnShowAddButtonChanged)
        {
            DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,

        });



        public bool ShowAddButton
        {
            get { return (bool)GetValue(ShowAddButtonProperty); }
            set { SetValue(ShowAddButtonProperty, value); }
        }

        private static void OnShowAddButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sh = (SearchableListControl)d;

            sh._addButton.Visibility = ((bool)e.NewValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        

        public object AddButtonContent
        {
            get { return GetValue(AddButtonContentProperty); }
            set { SetValue(AddButtonContentProperty, value); }
        }

        #endregion

        #region Reload Button
        public static readonly DependencyProperty ReloadButtonContentProperty = DependencyProperty.Register(nameof(ReloadButtonContent), typeof(object), typeof(SearchableListControl), new FrameworkPropertyMetadata("Reload"));

        public ICommand ReloadCommand
        {
            get { return (ICommand)GetValue(ReloadCommandProperty); }
            set { SetValue(ReloadCommandProperty, value); }
        }

        public object ReloadButtonContent
        {
            get { return GetValue(ReloadButtonContentProperty); }
            set { SetValue(ReloadButtonContentProperty, value); }
        }

        public static readonly DependencyProperty ReloadCommandProperty = DependencyProperty.Register(nameof(ReloadCommand), typeof(ICommand), typeof(SearchableListControl));

        #endregion

        #region Clear Button

        public static readonly DependencyProperty ClearButtonContentProperty = DependencyProperty.Register(nameof(ClearButtonContent), typeof(object), typeof(SearchableListControl), new FrameworkPropertyMetadata("Clear"));

        public object ClearButtonContent
        {
            get { return GetValue(ClearButtonContentProperty); }
            set { SetValue(ClearButtonContentProperty, value); }
        }

        private void OnClearClicked(object sender, RoutedEventArgs e)
        {
            SearchText = null;
        }
        #endregion

        #region Double click

        public event EventHandler<object> OnDoubleClickItem = delegate { };

        public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.Register(nameof(DoubleClickCommand), typeof(ICommand), typeof(SearchableListControl));

        public ICommand DoubleClickCommand
        {
            get { return (ICommand)GetValue(DoubleClickCommandProperty); }
            set { SetValue(DoubleClickCommandProperty, value); }
        }

        #endregion

        #region Items

        public event EventHandler<object> SelectionChanged = delegate { };

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(SearchableListControl), new FrameworkPropertyMetadata(null, OnItemsSourceChanged));
        public static readonly DependencyProperty ItemCountTextProperty = DependencyProperty.Register(nameof(ItemCountText), typeof(object), typeof(SearchableListControl), new FrameworkPropertyMetadata(null)
        {
            DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
        });

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(SearchableListControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        {
            DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
        });

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sh = (SearchableListControl)d;

            var items = ((IEnumerable)e.NewValue);

            bool ifItemCountSet = sh.ReadLocalValue(ItemCountTextProperty) != DependencyProperty.UnsetValue;

            if (!ifItemCountSet)
            {
                sh._labelCountInternal = true;

                sh._itemCountLabel.Text = $"Found {items.Cast<object>().Count()} item(s)";
            }
            else if (sh._labelCountInternal == true)
            {
                sh._itemCountLabel.Text = $"Found {items.Cast<object>().Count()} item(s)";
            }
            //if (string.IsNullOrWhiteSpace(sh.ItemCountText))
            //    

            //sh._addButton.Visibility = ((bool)e.NewValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public string ItemCountText
        {
            get { return (string)GetValue(ItemCountTextProperty); }

            set { SetValue(ItemCountTextProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }

            set { SetValue(SelectedItemProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #endregion

        #region Search

        public static readonly DependencyProperty DisplayMemberProperty = DependencyProperty.Register(nameof(DisplayMember), typeof(string), typeof(SearchableListControl), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty HeaderTitleProperty = DependencyProperty.Register(nameof(HeaderTitle), typeof(string), typeof(SearchableListControl), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty SearchLabelProperty = DependencyProperty.Register(nameof(SearchLabel), typeof(string), typeof(SearchableListControl), new FrameworkPropertyMetadata("Search"));

        public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(nameof(SearchText), typeof(string), typeof(SearchableListControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        {
            DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
        });

        public static readonly DependencyProperty FilterPanelProperty = DependencyProperty.Register(nameof(FilterPanel), typeof(FrameworkElement), typeof(SearchableListControl));

        public FrameworkElement FilterPanel
        {
            get { return (FrameworkElement)GetValue(FilterPanelProperty); }
            set { SetValue(FilterPanelProperty, value); }
        }

        /// <summary>
        /// Gets or sets the display member.
        /// </summary>
        /// <value>
        /// The display member.
        /// </value>
        public string DisplayMember
        {
            get { return (string)GetValue(DisplayMemberProperty); }

            set { SetValue(DisplayMemberProperty, value); }
        }

        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }

            set { SetValue(SearchTextProperty, value); }
        }

        public string HeaderTitle
        {
            get { return (string)GetValue(HeaderTitleProperty); }

            set { SetValue(HeaderTitleProperty, value); }
        }

        public string SearchLabel
        {
            get { return (string)GetValue(SearchLabelProperty); }

            set { SetValue(SearchLabelProperty, value); }
        }

        #endregion

        #region Constructors


        static SearchableListControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchableListControl), new FrameworkPropertyMetadata(typeof(SearchableListControl)));
        }

        #endregion

        #region Style

        public static readonly DependencyProperty HeaderBorderStyleProperty = DependencyProperty.Register(nameof(HeaderBorderStyle), typeof(Style), typeof(SearchableListControl));
        public static readonly DependencyProperty FooterBorderStyleProperty = DependencyProperty.Register(nameof(FooterBorderStyle), typeof(Style), typeof(SearchableListControl));
        public static readonly DependencyProperty ButtonStyleProperty = DependencyProperty.Register(nameof(ButtonStyle), typeof(Style), typeof(SearchableListControl));

        public Style HeaderBorderStyle
        {
            get { return (Style)GetValue(HeaderBorderStyleProperty); }

            set { SetValue(HeaderBorderStyleProperty, value); }
        }

        public Style FooterBorderStyle
        {
            get { return (Style)GetValue(FooterBorderStyleProperty); }

            set { SetValue(FooterBorderStyleProperty, value); }
        }

        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }

            set { SetValue(ButtonStyleProperty, value); }
        }
        #endregion
        #region Internals


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _header = Template.FindName(PartHeader, this) as Border;
            _list = Template.FindName(PartList, this) as DataGrid;
            _footer = Template.FindName(PartFooter, this) as Border;
            _searcghField = Template.FindName(PartSearchField, this) as TextBox;
            _clearButton = Template.FindName(PartClearButton, this) as Button;
            _addButton = Template.FindName(PartAddButton, this) as Button;
            _refreshButton = Template.FindName(PartReloadButton, this) as Button;
            _itemCountLabel = Template.FindName(PartItemCount, this) as TextBlock;

            var dispMember = DisplayMember;

            if (!string.IsNullOrWhiteSpace(dispMember))
            {
                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Header = HeaderTitle;
                textColumn.Binding = new Binding(dispMember);
                textColumn.IsReadOnly = true;
                textColumn.Width = new DataGridLength(1, DataGridLengthUnitType.Star);

                Style columnStyle = new Style(typeof(TextBlock));
                columnStyle.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center));
                columnStyle.Setters.Add(new Setter(TextBlock.MarginProperty, new Thickness(0, 0, 5, 0)));

                textColumn.ElementStyle = columnStyle;

                _list.Columns.Add(textColumn);
            }

            if (string.IsNullOrWhiteSpace(HeaderTitle))
                _list.HeadersVisibility = DataGridHeadersVisibility.None;

            if (_searcghField != null)
            {
                _searcghField.TextChanged += OnTextChanged;

                if (!string.IsNullOrWhiteSpace(SearchText))
                    _searcghField.Text = SearchText;
            }

            if (_list != null)
            {
                Style rowStyle = new Style(typeof(DataGridRow), _list.RowStyle);
                rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                         new MouseButtonEventHandler(OnRowDoubleClickl)));


                _list.RowStyle = rowStyle;

            }

            if (_clearButton != null)
                _clearButton.Click += OnClearClicked;

            if (_addButton != null)
            {
                _addButton.Visibility = (ShowAddButton) ? Visibility.Visible : Visibility.Collapsed;
            }

            if (HeaderBorderStyle != null)
                _header.Style = HeaderBorderStyle;

            if (FooterBorderStyle != null)
                _footer.Style = FooterBorderStyle;

            if (ButtonStyle != null)
            {
                _clearButton.Style = ButtonStyle;
                _addButton.Style = ButtonStyle;
                _refreshButton.Style = ButtonStyle;
            }
            _list.SelectionChanged += OnItemChanged;
        }

        private void OnItemChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            var obj = row?.Item;

            SelectionChanged.Invoke(this, obj);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchText = _searcghField.Text;
        }

        private void OnRowDoubleClickl(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            var obj = row?.Item;

            OnDoubleClickItem?.Invoke(this, obj);
            // Some operations with this row

            if (DoubleClickCommand != null && DoubleClickCommand.CanExecute(obj))
            {
                DoubleClickCommand.Execute(obj);
            }
        }

        #endregion
    }
}
