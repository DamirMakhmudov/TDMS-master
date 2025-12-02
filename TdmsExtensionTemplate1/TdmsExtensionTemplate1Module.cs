using System.Reflection;
using Autofac;
using Tdms.Api;

namespace TdmsExtension.TdmsExtensionTemplate1;

public class TdmsExtensionTemplate1Module : TDMSExtensionModule
{
    public override void Configure(ContainerBuilder builder)
    {
        builder.RegisterHandlers(Assembly.GetExecutingAssembly());

    }
    public override void Start(ILifetimeScope scope)
    {
    }
    public override void Stop()
    {
    }
}