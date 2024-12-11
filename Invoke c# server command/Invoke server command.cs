using Tdms.Api;
using Tdms.Log;

namespace ICommands
{
    [TdmsApiCommand("c_server", Roles = "all", ObjectDefs ="all")]
    public class ICommands
    {
        public TDMSApplication ThisApplication;
        public ILogger Logger { get; set; }
        public TDMSObject thisobject;

        public ICommands(TDMSApplication application, TDMSObject Thisobject)
        {
            ThisApplication = application;
            Logger = Tdms.Log.LogManager.GetLogger("ICommands");
            thisobject = Thisobject;
        }

        public void Execute(string guid)
        {
            Logger.Info(guid);
        }
    }
}
