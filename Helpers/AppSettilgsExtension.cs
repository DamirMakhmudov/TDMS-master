using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tdms.Web.DTO;
using TdmsExtension.iCommands.Models;

namespace TdmsExtension.iCommands.Helpers;

public static class AppSettilgsExtension
{
    /// <summary>
    /// Тип конфигурации
    /// </summary>
    public static string ConfigurationType
    {
        get => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                .NotEmpty(Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT"))?
                .ToUpper()
                switch
                {
                    "PRODUCTION" => "production",
                    "LINUX" => "linux",
                    _ => "loc"
                };
    }



    /// <summary>
    /// Имя файла конфигурации
    /// </summary>
    public static string ConfigurationJsonFilename
    {
        get => $"appsettings.{ConfigurationType}.json";
    }


    /// <summary>
    /// Конвертер UInt32 в 4 байта
    /// </summary>
    /// <param name="Value">Исходное число (UInt32)</param>
    /// <param name="Dest">Результирующий набор байт</param>
    /// <param name="DestStartIndex">Позиция в массиве Dest начиная с которой добавляются сконвертированные байты. После выполнения операции позиция смещается на 4</param>
    /// <returns>true - успешно</returns>
    public static List<WebConfigurationPage> LoadWebConfiguration(this AppSettingsModel appsettings)
    {
        var webPages = new List<WebConfigurationPage>();
        if (!appsettings.Name.IsNullOrBlank() && appsettings.Pages.Any())
        {
            webPages = appsettings.Pages.Select(o => new WebConfigurationPage
            {
                Caption = o.Caption, 
                BadgeText = o.BadgeText, 
                FormSysId = o.FormSysId, 
                Src = o.Source, 
                Root = $"{appsettings.Name}.{o.Name}",
                //Xclass = o.XClass.NotEmpty("tdms.view.panels.IFramePage"), 
                Persistent = o.Persistent == true
            }).ToList();
        }
        return webPages;
    }

    /// <summary>
    /// Загрузка конфигурации из файла
    /// </summary>
    /// <returns></returns>
    public static AppSettingsModel GetConfigurationJson()
    {
        var cfgPath = Path.Combine("Config", ConfigurationJsonFilename);

        var config = new AppSettingsModel();

        try
        {
            var exeAssembly = Assembly.GetExecutingAssembly();
            var module = exeAssembly.Modules.FirstOrDefault()?.Name;
            if (!module.IsNullOrBlank())
            {
                var moduleName = module!.Remove(module.IndexOf("."));

                var modulePath = exeAssembly.Location.Replace(module!, string.Empty);
                var filePath = Path.Combine(modulePath, cfgPath);
                var json = File.ReadAllText(filePath);
                config = JsonConvert.DeserializeObject<AppSettingsModel>(json) ?? new AppSettingsModel();
                
                if (config.Name.IsNullOrBlank())
                    config.Name = moduleName;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка загрузки конфигурации из {cfgPath}: {ex.Message}");
        }

        return config;
    }

}
