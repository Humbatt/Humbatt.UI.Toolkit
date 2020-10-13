using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Humbatt.UI.Toolkit.Core.Contracts
{
    /// <summary>
    /// Represents the suggestion provider.
    /// </summary>
    public interface ISuggestionProvider
    {

        #region Public Methods

        /// <summary>
        /// Gets the suggestions.
        /// </summary>
        /// <param name="filter">The filter to apply on the suggestion list.</param>
        /// <returns></returns>
        IEnumerable GetSuggestions(string filter);

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        object GetItem(string filter);

        #endregion Public Methods

    }
}
