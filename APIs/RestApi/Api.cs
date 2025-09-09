using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tdms.Api;
using Tdms.ImportExport.Commands;

namespace TdmsExtension.iCommands;


[AllowAnonymous]
[Route("commands")]
public partial class TDMSAPIController : ControllerBase
{
    protected TDMSApplication _application { get; set; }
    protected Tdms.Log.ILogger<ExportClassifiersCommand> _logger { get; set; }

    public TDMSAPIController(TDMSApplication application, Tdms.Log.ILogger<ExportClassifiersCommand> logger)
    {
        _application = application;
        _logger = logger;
    }
}
