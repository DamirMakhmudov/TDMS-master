using Autofac;
using System.Reflection;
using Tdms;
//using Tdms.Api;
using TdmsExtension.iCommands.Models;
using static TdmsExtension.iCommands.Helpers.AppSettilgsExtension;

namespace TdmsExtension.iCommands;

//public class iCommandsModule : TDMSExtensionModule
public class iCommandsModule : IModule
{
    public AppSettingsModel AppSettings { get; set; } = new AppSettingsModel();

    //public override void Configure(ContainerBuilder builder)
    public void Configure(ContainerBuilder builder)
    {
        AppSettings = GetConfigurationJson();

        var executingAssembly = Assembly.GetExecutingAssembly();

        builder.RegisterHandlers(executingAssembly);

        builder.RegisterType<iCommandsModule>();
        builder.RegisterInstance<iCommandsModule>(this);

        builder.RegisterConfig<iCommandsConfiguration>();
    }

    //public override void Start(ILifetimeScope scope)
    public void Start(ILifetimeScope scope)
    {
        scope.Resolve<iCommandsConfiguration>();
    }

    //public override void Stop()
    //{
    //}

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
