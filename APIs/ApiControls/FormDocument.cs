using Autofac;
using System;
using Tdms.Api;
using Tdms.ImportExport.Commands;

namespace TdmsExtension.iCommands;

/// <summary>
/// Инициализация объекта "FORM_DOCUMENT" при создании и обработка событий
/// </summary>
[TdmsApi("FORM_DOCUMENT")]
public class FormDocument: CommandBase
{
    public TDMSInputForm _form;
    public TDMSAttribute Attribute;
    public TDMSAttribute OldAttribute;

    public FormDocument(TDMSApplication application, TDMSObject thisObject, TDMSInputForm form, Tdms.Log.ILogger<ExportClassifiersCommand> logger, 
        TDMSAttribute attribute, BoolRef Cancel, TDMSAttribute oldattribute, ILifetimeScope scope) :
        base(application, thisObject, logger, scope)
    {
        _form = form;
        Attribute = attribute;
        OldAttribute = oldattribute;

    }
    
    public void Form_BeforeShow(TDMSInputForm form)
    {
        Console.WriteLine("FormBeforeShow");
        //_application.MsgBox("yes",,,);
    }
    public void Form_AttributeChange(TDMSInputForm form, TDMSObject thisobject, TDMSAttribute attribute, BoolRef Cancel, TDMSAttribute oldattribute)
    {
        Console.WriteLine($"{attribute.AttributeDefName}");
    }
}

