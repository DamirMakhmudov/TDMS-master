using Autofac;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;
using Tdms.Web.DTO;
using Tdms.Web.Events;
using TdmsExtension.iCommands.Models;
using static TdmsExtension.iCommands.Helpers.AppSettilgsExtension;

namespace TdmsExtension.iCommands;

public class WebConfigurationLoadAfterEventHandler : IEventHandler<WebConfigurationLoadEvent>
{
    private TDMSApplication _application;
    protected AppSettingsModel _appsettings { get; set; }

    public WebConfigurationLoadAfterEventHandler(TDMSApplication app, iCommandsConfiguration planningConfig, ILifetimeScope scope)
    {
        _application = app;
        _appsettings = scope.Resolve<iCommandsModule>()?.AppSettings ?? new AppSettingsModel();
    }

    /// <summary>
    /// Конфигурация модуля расширений
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task Handle(WebConfigurationLoadEvent notification, CancellationToken cancellationToken)
    {
        Version? serverVersion = System.Reflection.Assembly.GetEntryAssembly()?
            .GetName().Version;

        Console.WriteLine($"Сервер {serverVersion}. Модуль расширений '{_appsettings.Name}'");

        notification.Configuration.MainTabs.AddRange(_appsettings.LoadWebConfiguration());

        return Task.CompletedTask;
    }
}


//namespace CalendarPlanning
//{
//    public class WebConfigurationLoadAfterEventHandler : IEventHandler<WebConfigurationLoadEvent>
//    {
//        CalendarPlanningConfiguration PlanningConfig;
//        private TDMSApplication Application;

//        public WebConfigurationLoadAfterEventHandler(TDMSApplication app, CalendarPlanningConfiguration planningConfig)
//        {
//            Application = app;
//            PlanningConfig = planningConfig;
//        }

//        public Task Handle(WebConfigurationLoadEvent notification, CancellationToken cancellationToken)
//        {
//            WebConfiguration config = notification.Configuration;

//#if TdmsGantt

//            TDMSGroup planning = Application.Groups["public_PlanningDepatrament"];
//            if (planning == null || !Application.CurrentUser.Groups.Has(planning)) return Task.CompletedTask;
//#endif
//            var newPage = new WebConfigurationPage()
//            {
//                Xclass = "tdms.view.panels.IFramePage",
//                Caption = "Календарное планирование",
//                Root = "planning",
//                Persistent = false
//            };

//            newPage.Src = PlanningConfig.DebugMode ? "http://localhost:3000" : "/Planning/index.html";

//            config.MainTabs.Add(newPage);
//            // Для "прогрессивных" тем
//            JArray treeTabs = config.TreeTabs;
//            bool doAdd = treeTabs == null;
//            if (doAdd) treeTabs = new JArray();
//            if (treeTabs.Count > 0)
//            {
//                treeTabs.Add(JObject.FromObject(new
//                {
//                    xclass = "tdms.view.panels.IFramePage",
//                    caption = "Календарное планирование",
//                    root = "planning",
//                    src = "/Planning/index.html",
//                    iconCls = "x-fa fa-align-left"
//                }));
//            }
//            if (doAdd) config.TreeTabs = treeTabs;

//            return Task.CompletedTask;
//        }
//    }
//}