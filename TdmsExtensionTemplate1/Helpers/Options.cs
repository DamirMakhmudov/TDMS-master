using System;
using System.Collections.Generic;
using System.Linq;

namespace TdmsExtension.TdmsExtensionTemplate1.Helpers;

[Serializable]
public static partial class Options
{
    #region Strings & List funcs

    #region Strings

    /// <summary>
    /// Удаление в строке Source начальных, конечных, повторяющихся пробелов, а также символов \r \n при SpcCharSupress = OperationState.SpecialChar.
    /// </summary>   
    public static string TrimAll(this string source, OperationState spcCharSupress)
    {
        string s = "", t = source.Trim();
        if ((spcCharSupress & OperationState.SpecialChar) > 0)
        {
            t = t.Replace("\r", ""); t = t.Replace("\n", "");
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

    #endregion

    #region List funcs

    /// <summary>
    /// Преобразование строк в соответствии с флагами NoEmpty_Case_Unique_Clone_Trims типа OperationState
    /// <para>Допустимые флаги OperationState:</para>
    /// <para>- Empty - удаление пустых строк</para>
    /// <para>- Trim - подавление начальных и конечных пробелов</para>
    /// <para>- TrimAll - Trim + подавление "двойных" пробелов</para>
    /// <para>- UpperCase или LowerCase - преобразование строк в верхний или нижний регистр</para>
    /// <para>- Unique - удаление повторяющихся строк</para>
    /// <para>- Clone - результат возвращается в виде копии результирующих строк</para>
    /// </summary>   
    public static List<string> ListStringState(List<string> lSource, OperationState NoEmpty_Case_Unique_Clone_Trims = OperationState.Default)
    {
        if (lSource != null && lSource.Count > 0)
        {
            IEnumerable<string> ie = lSource.AsEnumerable();
            if ((NoEmpty_Case_Unique_Clone_Trims & OperationState.Empty) > 0) ie = from s in ie where s.Trim().Length > 0 select s;
            if ((NoEmpty_Case_Unique_Clone_Trims & (OperationState.Trim | OperationState.TrimAll)) > 0)
                ie = from s in ie
                     select (NoEmpty_Case_Unique_Clone_Trims & OperationState.TrimAll) > 0 ? TrimAll(s, (NoEmpty_Case_Unique_Clone_Trims & OperationState.SpecialChar) > 0) : s.Trim();
            if ((NoEmpty_Case_Unique_Clone_Trims & (OperationState.UpperCase | OperationState.LowerCase)) > 0)
                ie = from s in ie select (NoEmpty_Case_Unique_Clone_Trims & OperationState.UpperCase) > 0 ? s.ToUpper() : s.ToLower();
            if ((NoEmpty_Case_Unique_Clone_Trims & OperationState.Unique) > 0) ie = ie.Distinct();
            if (ie != null && ie.Count() > 0)
            {
                if ((NoEmpty_Case_Unique_Clone_Trims & OperationState.Clone) > 0)
                {
                    string[] arr = new string[ie.Count()]; ie.ToList().CopyTo(arr); return arr.ToList();
                }
                return ie.ToList();
            }
        }
        return new List<string>();
    }

    /// <summary>
    /// Удаление повторяющихся строк с удалением пустых строк в соответствии с EmptySupress
    /// </summary>   
    public static List<string> ListStringUnique(List<string> lSource, bool EmptySupress = true)
    {
        return ListStringState(lSource, OperationState.Unique | (EmptySupress == true ? OperationState.Empty : OperationState.Default));
    }

    /// <summary>
    /// Находит вхождение списка Sample в список Source. Outersect содержит список Source за исключением Sample.
    /// </summary>   
    public static List<T> ListInterOutersect<T>(List<T> Source, List<T> Sample, out List<T> Outersect)
    {
        IEnumerable<T> io = Source.Except(Sample); Outersect = io == null ? new List<T>() : io.ToList();
        IEnumerable<T> ii = Source.Intersect(Sample); return ii == null ? new List<T>() : ii.ToList();
    }
    /// <summary>
    /// Находит вхождение строк Sample в строки Source с игнорированием регистра или нет (параметр CaseIgnore). Outersect содержит строки Source за исключением Sample. 
    /// </summary>   
    public static List<string> ListIntersect(List<string> Source, List<string> Sample, out List<string> Outersect, bool CaseIgnore = false)
    {
        if (Sample == null || (Sample != null && Sample.Count == 0)) { Outersect = Source ?? new List<string>(); return new List<string>(); }
        if (Source == null || (Source != null && Source.Count == 0)) { Outersect = Sample ?? new List<string>(); return new List<string>(); }

        if (CaseIgnore == false) return ListInterOutersect<string>(Source, Sample, out Outersect);

        List<string> lvc = ListStringUnique(Source), lvs = ListStringUnique(Sample);

        if (lvc.Count != Source.Count || lvs.Count != Sample.Count) return ListIntersect(lvc, lvs, out Outersect, CaseIgnore);

        List<string> li = new List<string>();
        Outersect = new List<string>();
        for (int i = 0; i < lvs.Count; i++) { if (lvc.Contains(lvs[i], StringComparer.InvariantCultureIgnoreCase) == true) li.Add(lvs[i]); else Outersect.Add(lvs[i]); }
        return li;
    }

    #endregion

    #endregion

}
