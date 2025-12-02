using Tdms.Api;
using Tdms.ImportExport.Commands;

namespace TdmsExtension.TdmsExtensionTemplate1;

public abstract class ACommands
{
    protected TDMSApplication _application { get; set; }
    protected Tdms.Log.ILogger<ExportClassifiersCommand> _logger { get; set; }
    protected TDMSObject _object { get; set; }

    public ACommands(TDMSApplication application, TDMSObject thisObject, Tdms.Log.ILogger<ExportClassifiersCommand> logger)
    {
        _application = application;
        _logger = logger;
        _object = thisObject;
    }
}
