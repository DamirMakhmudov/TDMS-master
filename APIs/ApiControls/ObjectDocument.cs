using Autofac;
using System;
using Tdms.Api;
using Tdms.ImportExport.Commands;

namespace TdmsExtension.iCommands;

/// <summary>
/// Инициализация объекта "OBJECT_DOCUMENT" при создании
/// </summary>
[TdmsApi("OBJECT_DOCUMENT")]
public class ObjectDocument: CommandBase
{
    private TDMSInputForm _form;

    public ObjectDocument(TDMSApplication application, TDMSObject Thisobject, TDMSInputForm form, Tdms.Log.ILogger<ExportClassifiersCommand> logger, ILifetimeScope scope) : 
        base(application, Thisobject, logger, scope)
    {
        _form = form;
    }

    public void Object_BeforeCreate(TDMSObject Obj, TDMSObject parent, BoolRef Cancel)
    {
        Console.WriteLine("SERVER Object_BeforeCreate OBJECT_DOC");
        Obj.Attributes["ATTR_CREATED"].Value = DateTime.Today;
        Obj.Attributes["ATTR_DOC_ACTUAL"].Value = true;
        Obj.Attributes["ATTR_AUTHOR"].Value = _application.CurrentUser;
        Obj.Attributes["ATTR_DOC_TYPE"].Value = _application.Classifiers["NODE_DOC_TYPE_CONTRACT"];
    }
    public void Object_Created(TDMSObject thisobject, TDMSObject parent)
    {
        Console.WriteLine("SERVER Object_Created SERVER OBJECT_DOC");
        //_application.MsgBox("Создание Документа");
        //thisobject.Attributes["ATTR_AUTHOR"].User = TA.CurrentUser;
    }
}
