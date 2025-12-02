using System;
using Tdms.Api;
using Tdms.ImportExport.Commands;

namespace TdmsExtension.TdmsExtensionTemplate1;

[TdmsApi("SCRIPT_GLOBAL")]
public class ScriptGlobal : ACommands
{
    public TDMSInputForm _form { get; set; }

    public ScriptGlobal(TDMSApplication application, TDMSObject thisObject, TDMSInputForm form, Tdms.Log.ILogger<ExportClassifiersCommand> logger) :
        base(application, thisObject, logger)
    {
        _form = form;
    }

    public void Object_Created(TDMSObject thisobject, TDMSObject parent)
    {
        Console.WriteLine("Object_Created GLOBAL");
        //TA.MsgBox("Создание Документа");
        //thisobject.Attributes["ATTR_AUTHOR"].User = TA.CurrentUser;
    }
}
