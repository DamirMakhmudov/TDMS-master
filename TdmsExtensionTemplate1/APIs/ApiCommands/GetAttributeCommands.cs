using System.Threading;
using Tdms.Api;
using Tdms.ImportExport.Commands;

namespace TdmsExtension.TdmsExtensionTemplate1;

[TdmsApiCommand("C_GET_ATTR_O_1", Roles = "all")]
public class iCommand : ACommands
{
    public iCommand(TDMSApplication application, TDMSObject thisObject, Tdms.Log.ILogger<ExportClassifiersCommand> logger) : base(application, thisObject, logger) { }
    public void Execute(string handle)
    {
        //_application.GetObjectByHandle(handle);
        Thread.Sleep(5000);
        _logger.Info(handle);
        //_logger.Info(thisobject.Description);
    }
}

[TdmsApiCommand("C_GET_ATTR_O_3", Roles = "all")]
public class iCommandw : ACommands
{
    public iCommandw(TDMSApplication application, TDMSObject thisObject, Tdms.Log.ILogger<ExportClassifiersCommand> logger) : base(application, thisObject, logger) { }
    public void Execute(string handle)
    {
        //_application.GetObjectByHandle(handle);
        _logger.Info(handle);
        //_application.Context.CommandManager.
        //_logger.Info(thisobject.Description);
    }
}


//public async Task<object> ExecuteAsync(string taskID = "", CancellationToken ct = default)
//{
//    var dlg = Application.Dialogs.SelectUserDlg;
//    bool ret = await dlg.ShowAsync();
//    var users = dlg.Users.GetItems();
//    return new
//    {
//        buttonId = (string)(ret ? "ok" : "cancel"),
//        success = true,
//        selectedUsers = users,
//        taskID = taskID,
//    };
//}

//public async Task<bool> Execute(TDMSObject obj)
//{
//    string redirectURL = string.Format("#planning/?page=ganttChartProject&jobhandle={0}", obj.Handle.ToString());
//    System.Console.WriteLine("Open gantchart with url " + redirectURL);
//    await Application.RedirectAsync(redirectURL, false);
//    return true;
//}