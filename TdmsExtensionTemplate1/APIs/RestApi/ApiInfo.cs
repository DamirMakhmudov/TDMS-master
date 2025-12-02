using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TdmsExtension.TdmsExtensionTemplate1;

public partial class TDMSAPIController
{
    /// <summary>
    /// Тест Info
    /// </summary>
    /// <returns>200 - ok, 421 - ошибка "Объект ThisApplication недоступен"</returns>

    [AllowAnonymous]
    [EnableCors("AllowAllOrigins")]
    [Route("info"), HttpGet]
    public ActionResult Info()
    {
        if (_application == null)
        {
            return UnprocessableEntity("Объект ThisApplication недоступен");
        }

        var applicationName = _application.ApplicationName;
        var applicationFolder = _application.ApplicationFolder;
        var currentUser = _application.CurrentUser.SysName;
        var currentComputer = _application.CurrentComputer;
        var serverName = _application.ServerName;
        var version = _application.Version();

        return Ok(
            $"applicationName .... {applicationName}\r\n" +
            $"applicationFolder .. {applicationFolder}\r\n" +
            $"currentUser ........ {currentUser}\r\n" +
            $"currentComputer .... {currentComputer}\r\n" +
            $"serverName ......... {serverName}\r\n" +
            $"version ............ {version}"
            );
    }
}
