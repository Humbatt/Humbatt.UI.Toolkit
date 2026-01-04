using System;
using System.Collections.Generic;
using System.Text;
using Humbatt.UI.Toolkit.Core.Models;

namespace Humbatt.UI.Toolkit.Core;

public static class EnumHelper
{
    /// <summary>
    /// Builds the options.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>List&lt;OptionItem&gt;.</returns>
    public static List<OptionItem<T>> BuildOptions<T>() where T : Enum
    {
        var results = new List<OptionItem<T>>();

        var values = Enum.GetValues(typeof(T));

        foreach (var anEnum in values)
        {
            var name = Enum.GetName(typeof(T), anEnum);

            var cleanName = name.Replace("_", " ");

            results.Add(new OptionItem<T>()
            {
                Title = cleanName,
                Value = (T)anEnum
            });
        }

        return results;
    }

    /// <summary>
    /// Builds the options.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ignoreList">The ignore list.</param>
    /// <returns>List&lt;OptionItem&gt;.</returns>
    public static List<OptionItem<T>> BuildOptions<T>(params T[] ignoreList) where T : Enum
    {
        var results = new List<OptionItem<T>>();

        var values = Enum.GetValues(typeof(T));

        foreach (T anEnum in values)
        {
            if (ignoreList != null || ignoreList.Length != 0)
            {
                if (ignoreList.ToList().Contains(anEnum))
                    continue;
            }

            var name = Enum.GetName(typeof(T), anEnum);

            var cleanName = name.Replace("_", " ");

            results.Add(new OptionItem<T>()
            {
                Title = cleanName,
                Value = (T)anEnum
            });
        }

        return results;
    }

    /// <summary>
    /// Builds the options.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="wordList">The word list.</param>
    /// <param name="ignoreList">The ignore list.</param>
    /// <returns>
    /// List&lt;OptionItem&gt;.
    /// </returns>
    public static List<OptionItem<T>> BuildOptions<T>(Dictionary<T, string> wordList, params T[] ignoreList) where T : Enum
    {
        var results = new List<OptionItem<T>>();

        var values = Enum.GetValues(typeof(T));

        foreach (T anEnum in values)
        {
            if (ignoreList != null || ignoreList.Length != 0)
            {
                if (ignoreList.ToList().Contains(anEnum))
                    continue;
            }

            if (wordList.ContainsKey(anEnum))
            {
                var name = wordList[anEnum];

                var cleanName = name.Replace("_", " ");

                results.Add(new OptionItem<T>()
                {
                    Title = cleanName,
                    Value = anEnum
                });
            }
            else
            {
                var name = Enum.GetName(typeof(T), anEnum);

                var cleanName = name.Replace("_", " ");

                results.Add(new OptionItem<T>()
                {
                    Title = cleanName,
                    Value = anEnum
                });
            }

        }

        if (results.Any())
        {
            results.Sort((x, y) => x.Title.CompareTo(y.Title));
        }

        return results;
    }
}
