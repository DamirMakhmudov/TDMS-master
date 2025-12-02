using Tdms.Api;
using Tdms.ImportExport.Commands;
using TdmsExtension.TdmsExtensionTemplate1.Helpers;

namespace TdmsExtension.TdmsExtensionTemplate1;

[TdmsApiCommand("LIB_EXTENSIONS_COMMONS", Roles = "all")]
public class CommandLib : ACommands
{
    public CommandLib(TDMSApplication application, TDMSObject thisObject, Tdms.Log.ILogger<ExportClassifiersCommand> logger) :
        base(application, thisObject, logger)
    {
    }

    //public void Execute(string handle)
    //{
    //    _application.MsgBox("Актуализация завершена", MessageBoxEnum.vbOkOnly, MessageBoxIcon.vbInformation);
    //}

    /// <summary>
    /// Добавление/удаление завершающей подстроки к оригинальной
    /// </summary>
    /// <param name="origin">исходная строка</param>
    /// <param name="last">завершающая строка</param>
    /// <param name="shouldBe">в строке value last: true - должна присутствовать, false - не должна присутствовать</param>
    /// <returns></returns>
    public string EnsureLast(string origin, string last, bool shouldBe)
    {
        var result = origin.IsNullOrEmpty() || last.IsNullOrBlank()
            ? origin
            : Options.EnsureLast(origin, last, shouldBe);


        _application.MsgBox($"EnsureLast: {result}", MessageBoxEnum.vbOkOnly, MessageBoxIcon.vbInformation);

        return result;
    }
}
