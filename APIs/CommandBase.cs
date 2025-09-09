using Autofac;
using Tdms.Api;
using Tdms.ImportExport.Commands;
using TdmsExtension.iCommands.Models;

namespace TdmsExtension.iCommands;

public class CommandBase
{
    protected TDMSApplication _application { get; set; }
    protected Tdms.Log.ILogger<ExportClassifiersCommand> _logger { get; set; }
    protected TDMSObject _object { get; set; }
    protected AppSettingsModel _appsettings { get; set; }

    public CommandBase(TDMSApplication application, TDMSObject thisObject, Tdms.Log.ILogger<ExportClassifiersCommand> logger, ILifetimeScope scope)
    {
        _application = application;
        _logger = logger;
        _object = thisObject;
        _appsettings = scope.Resolve<iCommandsModule>()?.AppSettings ?? new AppSettingsModel();
    }

    public virtual void Execute()
    {
    }

}
