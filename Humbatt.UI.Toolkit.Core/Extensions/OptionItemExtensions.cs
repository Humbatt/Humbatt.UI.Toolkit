using Humbatt.UI.Toolkit.Core.Models;

namespace System;

public static class OptionItemExtensions
{
    /// <summary>
    /// Converts ienumerable to bindble object item list
    /// </summary>
    /// <typeparam name="T">Item type</typeparam>
    /// <param name="target">Target list</param>
    /// <param name="titleFunction">Function to return the title(Display Text) for eaxh item</param>
    /// <param name="subTitleFunction">Optional function for returning the sub-title</param>
    /// <returns></returns>
    public static List<OptionItem<T>> BuildOptionItems<T>(this IEnumerable<T> target, Func<T, string> titleFunction, Func<T, string> subTitleFunction = null)
    {
        var options = new List<OptionItem<T>>();

        foreach (var item in target)
        {
            var oi = new OptionItem<T>()
            {
                Value = item,
            };

            oi.Title = titleFunction(item);

            if (subTitleFunction != null)
            {
                oi.SubTitle = subTitleFunction(item);
            }

            options.Add(oi);

        }

        return options;
    }
}
