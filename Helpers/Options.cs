using System;
using System.Collections.Generic;
using System.Linq;

namespace TdmsExtension.iCommands.Helpers;

[Serializable]
public static partial class Options
{
    #region Operation with type & object

    /// <summary>
    /// Проверка на null
    /// </summary>
    /// <param name="oValue"></param>
    /// <returns></returns>
    public static bool IsNull(this object? oValue) => oValue == null || oValue == DBNull.Value;

    #endregion

    #region Strings & List funcs

    #region Strings

    /// <summary>
    /// Удаление в строке Source начальных, конечных, повторяющихся пробелов, а также символов \r \n при SpcCharSupress = OperationState.SpecialChar.
    /// </summary>   
    public static string TrimAll(this string source, OperationState spcCharSupress)
    {
        string s = string.Empty, t = source.Trim();
        if ((spcCharSupress & OperationState.SpecialChar) > 0)
        {
            t = t.Replace("\r", string.Empty); t = t.Replace("\n", string.Empty);
        }
        string[] ss = t.Split(' ');

        for (int i = 0; i < ss.Length; i++)
        {
            if (ss[i].Length > 0)
            {
                if (s.Length > 0) s += " ";
                s += ss[i];
            }
        }
        return s;
    }

    /// <summary>
    /// Удаление в строке Source начальных, конечных, повторяющихся пробелов, а также символов \r \n при SpcCharSupress = true.
    /// </summary>   
    public static string TrimAll(this string source, bool spcCharSupress = false)
    {
        return TrimAll(source, spcCharSupress == true ? OperationState.SpecialChar : OperationState.Default);
    }

    public static string EnsureLast(this string name, string last = "/", bool shouldBe = true)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(name))
            return name;

        return name.EndsWith(last) == shouldBe ? name :
            (shouldBe ? name + last : name.Substring(0, name.Length - last.Length));
    }

    public static bool IsNullOrEmpty(this string? source) => string.IsNullOrEmpty(source);

    public static bool IsNullOrBlank(this string? value) =>
        value.IsNullOrEmpty() || (!value.IsNullOrEmpty() && value.Trim().IsNullOrEmpty());

    public static List<int>? IndexesOf(this string? text, string? sample, List<int>? indexes = null)
    {
        if (text!.IsNullOrEmpty() || sample!.IsNullOrEmpty())
            return indexes;

        var x = text!.IndexOf(sample!);
        if (x < 0)
            return indexes;

        indexes = indexes ?? new List<int>();
        indexes.Add(x + indexes.Sum());

        return text.Substring(x + sample!.Length).IndexesOf(sample, indexes);
    }
    public static string? NotEmpty(this string? value, string? alter) =>
        string.IsNullOrEmpty(value) ? alter : value;

    #endregion

    #region List funcs

    public static IEnumerable<(T item, int index)>? Indexed<T>(this IEnumerable<T>? self) =>
        self?.Select((item, index) => (item, index));

    #endregion

    #endregion

}
