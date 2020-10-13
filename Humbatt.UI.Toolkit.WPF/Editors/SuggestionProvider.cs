using Humbatt.UI.Toolkit.Core.Contracts;
using System;
using System.Collections;

namespace Humbatt.UI.Toolkit.WPF.Editors
{
    /// <summary>
    /// A generic suggestion provider. 
    /// </summary>
    /// <seealso cref="WpfControls.Editors.ISuggestionProvider" />
    public class SuggestionProvider : ISuggestionProvider
    {

        #region Private Fields

        private readonly Func<string, IEnumerable> _method;

        #endregion Private Fields

        #region Public Constructors

        public SuggestionProvider(Func<string, IEnumerable> method)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }
            _method = method;
        }

        public object GetItem(string filter)
        {
            return null;
        }

        #endregion Public Constructors

        #region Public Methods

        public IEnumerable GetSuggestions(string filter)
        {
            return _method(filter);
        }

        #endregion Public Methods

    }
}
