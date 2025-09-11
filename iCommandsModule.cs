using Autofac;
using System.Reflection;
using Tdms;
using Tdms.Api;
using TdmsExtension.iCommands.Models;
using static TdmsExtension.iCommands.Helpers.AppSettilgsExtension;

namespace TdmsExtension.iCommands;

[SwaggerHelp("iCommands", "v1", "Пример модуля расширений", "", "СиСофт Разработка", "support@tdms.ru", "https://tdms.ru/")]
public class iCommandsModule : TDMSExtensionModule
{
    public AppSettingsModel AppSettings { get; set; } = new AppSettingsModel();
    public iCommandsConfiguration AppConfiguration { get; set; } = new iCommandsConfiguration();

    public override void Configure(ContainerBuilder builder)
    {
        AppSettings = GetConfigurationJson();

        var executingAssembly = Assembly.GetExecutingAssembly();

        builder.RegisterHandlers(executingAssembly);

        builder.RegisterConfig<iCommandsConfiguration>();

        builder.RegisterType<iCommandsModule>();
        builder.RegisterInstance<iCommandsModule>(this);
    }

    public override void Start(ILifetimeScope scope)
    {
        AppConfiguration = scope.Resolve<iCommandsConfiguration>();
    }

    public override void Stop()
    {
    }

}

//[SwaggerHelp("planning", "v1", "Gantt Planning Restful API", "", "СиСофт Разработка", "support@tdms.ru", "https://tdms.ru/")]
//public class WebServerModule : IModule
//{
//    public void Configure(ContainerBuilder builder)
//    {
//        var assemblies = new Assembly[] { Assembly.GetExecutingAssembly() };
//        builder.RegisterType<GanttChartMiddlewareBase>().As<IGanttChartMiddleware>();
//        builder.RegisterType<FarvaterGantt>().As<IGanttChartBackend>();
//        builder.RegisterConfig<CalendarPlanningConfiguration>();
//        builder.RegisterHandlers();
//    }
//    public void Start(Autofac.ILifetimeScope scope)
//    {
//        scope.Resolve<CalendarPlanningConfiguration>();
//    }
//}
