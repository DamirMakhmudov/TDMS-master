using Autofac;
using System;
using Tdms.Api;
using Tdms.ImportExport.Commands;

namespace TdmsExtension.iCommands;

/// <summary>
/// Актуализация документа - установка иконки, атрибутов ATTR_CREATEDб ATTR_AUTHOR
/// </summary>
[TdmsApiCommand("C_SET_DOC", Roles = "all", ObjectDefs = "OBJECT_DOCUMENT", Description = "Актуализировать документ (C#)") ]
public class CommandActualizeDocument: CommandBase
{
    public CommandActualizeDocument(TDMSApplication application, TDMSObject thisObject, Tdms.Log.ILogger<ExportClassifiersCommand> logger, ILifetimeScope scope) : 
        base(application, thisObject, logger, scope)
    {
    }

    public override void Execute()
    {
        _object.Icon = _object.Files.Count > 0 ? _application.Icons["IMG_DOCUMENT_FILE"] : _application.Icons["IMG_DOCUMENT"];

        _object.Attributes["ATTR_CREATED"].Value = DateTime.Today;
        _object.Attributes["ATTR_AUTHOR"].Value = _application.CurrentUser;

        _application.MsgBox("Актуализация завершена", MessageBoxEnum.vbOkOnly, MessageBoxIcon.vbInformation);
    }
}


/// <summary>
/// Очиститка аттрибутов документа: NAME, Description
/// </summary>
[TdmsApiCommand("C_DOC_ATR_CLEAR", Roles = "all", ObjectDefs = "OBJECT_DOCUMENT", Description = "Очистить аттрибуты документа (C#)")]
public class CommandObjectDocumentClear : CommandBase
{
    public CommandObjectDocumentClear(TDMSApplication application, TDMSObject Thisobject, Tdms.Log.ILogger<ExportClassifiersCommand> logger, ILifetimeScope scope) : 
        base(application, Thisobject, logger, scope) 
    {
    }

    public override void Execute()
    {
        _object.Attributes["ATTR_NAME"].Value = string.Empty;
        _object.Attributes["ATTR_Description"].Value = string.Empty;

        _logger.Info("Очистка аттрибутов документа завершена");

        _application.MsgBox("Очистка завершена", MessageBoxEnum.vbOkOnly, MessageBoxIcon.vbInformation);
    }
}
