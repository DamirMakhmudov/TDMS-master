using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tdms.Api;

namespace TdmsExtension.iCommands;

internal class ImportService
{
    TDMSApplication _application;
    public ImportService(TDMSApplication app)
    {
        _application = app;
    }
    public async Task Import(string url = "", CancellationToken cancellationToken = default(CancellationToken))
    {

    }
}
