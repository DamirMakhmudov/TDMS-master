using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TdmsExtension.TdmsExtensionTemplate1.Helpers;
using TdmsExtension.TdmsExtensionTemplate1.Models;

namespace TdmsExtension.TdmsExtensionTemplate1;

public partial class TDMSAPIController : ControllerBase
{
    /// <summary>
    /// Тест MasterMethod
    /// </summary>
    /// <param name="request">Входные данные</param>
    /// <returns>200 - ok, 400 -ошибка</returns>
    [AllowAnonymous]
    [EnableCors("AllowAllOrigins")]
    [Route("mastermethod"), HttpPost]
    //[Produces("application/json")]
    //[SwaggerOperation(Summary = "MasterMethod тест", Description = "Тестируем MasterMethod", Tags = new[] { "MasterMethod тег" })]
    //[SwaggerResponse(200, "MasterMethod выполнен успешно")]
    //[SwaggerResponse(400, "Ошибка выполнения MasterMethod")]
    //[Route("commands/api"), HttpPost]
    public ActionResult MasterMethod([FromBody] JRequest request)
    {
        if (request == null)
        {
            return BadRequest("Пустой вызов");
        }
        else if (request.GUID.IsNullOrBlank() || request.JName.IsNullOrBlank() || request.JUser.IsNullOrBlank())
        {
            return BadRequest("Все параметры из списка должны быть заполнены");
        }

        try
        {
            _logger.Info("API controller was triggered");

            var obj = _application.GetObjectByGUID(request.GUID);
            if (obj == null)
            {
                return BadRequest($"Объект {request.GUID} не найден");
            }

            obj.Attributes["ATTR_CODE"].Value = request.JName;
            obj.Attributes["ATTR_AUTHOR"].User = _application.Users[request.JUser];
            _application.SaveChanges();

            object resp = new { status = "ok" };
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(resp, options);
            return Ok(json);
        }
        catch (Exception ex)
        {
            var response = ex.Message + "\n" + ex.StackTrace;
            _logger.Info($"Error: {response}");
            return BadRequest(response);
        }
    }
}
