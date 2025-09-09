using Autofac;
using System;
using System.Collections;
using System.Linq;
using Tdms;
using Tdms.Api;
using Tdms.ImportExport.Commands;
using TdmsExtension.iCommands.Helpers;

namespace TdmsExtension.iCommands;

[TdmsApiCommand("LIB_EXTENSIONS_COMMONS", Roles = "all")]
public class CommandLib : CommandBase
{
    public CommandLib(TDMSApplication application, TDMSObject thisObject, Tdms.Log.ILogger<ExportClassifiersCommand> logger, ILifetimeScope scope) : 
        base(application, thisObject, logger, scope)
    {
    }

    #region strings

    /// <summary>
    /// Добавление завершающей подстроки к оригинальной
    /// </summary>
    /// <param name="origin">исходная строка</param>
    /// <param name="last">завершающая строка</param>
    /// <returns></returns>
    public string EnsureLastSlashExist(string origin) =>
        EnsureLast(origin, "/", true);

    /// <summary>
    /// Удаление завершающей подстроки из оригинальной
    /// </summary>
    /// <param name="origin">исходная строка</param>
    /// <param name="last">завершающая строка</param>
    /// <returns></returns>
    public string EnsureLastSlashMiss(string origin) =>
        EnsureLast(origin, "/", false);

    /// <summary>
    /// Добавление/удаление завершающей подстроки к/из оригинальной
    /// </summary>
    /// <param name="origin">исходная строка</param>
    /// <param name="last">завершающая строка</param>
    /// <param name="shouldBe">в строке value last: true - должна присутствовать, false - не должна присутствовать</param>
    /// <returns></returns>
    public string EnsureLast(string origin, string last, bool shouldBe) =>
        Options.IsNullOrEmpty(origin) || last.IsNullOrBlank()
            ? origin
            : Options.EnsureLast(origin, last, shouldBe);

    /// <summary>
    /// Провека строки на null, empty или ведущие пробелы
    /// </summary>
    /// <param name="value">исходная строка</param>
    /// <returns></returns>
    public bool IsNullOrBlank(string value) =>
        value.IsNullOrBlank();

    #endregion

    #region objects

    /// <summary>
    /// Провека объекта на null
    /// </summary>
    /// <param name="value">исходная строка</param>
    /// <returns></returns>
    public bool IsNull(object value) =>
        value.IsNull();

    /// <summary>
    /// Провека объекта на null или empty
    /// </summary>
    /// <param name="value">исходный объект</param>
    /// <returns></returns>
    public bool IsNullOrEmpty(object? value)
    {
        if (value.IsNull())
            return true;

        var type = value!.GetType();

        if (type == typeof(string) || value is String)
            return Options.IsNullOrEmpty((string)value);

        if (type.IsPrimitive)
            return false;

        if (type.IsArray)
            return ((Array)value).Count() == 0;

        if (value is IEnumerable)
            return ((IEnumerable)value).Count() == 0;

        //_application.MsgBox($"EnsureLast [{shouldBe}]: {result}", MessageBoxEnum.vbOkOnly, MessageBoxIcon.vbInformation);

        return false;
    }

    #endregion

}
