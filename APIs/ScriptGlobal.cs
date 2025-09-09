using Autofac;
using System;
using Tdms.Api;
using Tdms.ImportExport.Commands;

namespace TdmsExtension.iCommands;

[TdmsApi("SCRIPT_GLOBAL")]
public class ScriptGlobal: CommandBase
{
    public TDMSInputForm _form { get; set; }

    public ScriptGlobal(TDMSApplication application, TDMSObject thisObject, TDMSInputForm form, Tdms.Log.ILogger<ExportClassifiersCommand> logger, ILifetimeScope scope) : 
        base(application, thisObject, logger, scope)
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
