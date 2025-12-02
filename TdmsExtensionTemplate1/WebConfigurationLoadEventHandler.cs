using System;
using System.Threading;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;
using Tdms.Web.DTO;
using Tdms.Web.Events;

namespace TdmsExtension.TdmsExtensionTemplate1;

public class WebConfigurationLoadAfterEventHandler : IEventHandler<WebConfigurationLoadEvent>
{
    private TDMSApplication _application;

    public WebConfigurationLoadAfterEventHandler(TDMSApplication app)
    {
        _application = app;
    }
    public Task Handle(WebConfigurationLoadEvent notification, CancellationToken cancellationToken)
    {
        WebConfiguration config = notification.Configuration;
        Console.WriteLine("module has started");

        var newPage = new WebConfigurationPage()
        {
            Xclass = "tdms.view.panels.IFramePage",
            Caption = "Расширение!",
            Src = "/index.html",
            Root = "TdmsExtensionTemplate1",
            Persistent = false
        };

        config.MainTabs.Add(newPage);

        return Task.CompletedTask;
    }
}