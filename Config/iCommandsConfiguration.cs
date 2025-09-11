using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tdms;
using TdmsExtension.iCommands.Models;

namespace TdmsExtension.iCommands;

/// <summary>
/// Класс конфигурации для настроек расширения
/// </summary>
[ModuleConfiguration]
public class iCommandsConfiguration
{
    
    [Category("Разработка"), DisplayName("Меню разработчика"), Description("Показывать меню разработчика"), Visible]
    public bool ShowDevMenu { get; set; }

    [Category("Разработка"), DisplayName("Режим отладки"), Description("Режим отладки, фронтенд с внешенего сервера"), Visible]
    public bool DebugMode { get; set; }

    [Category("Параметры"), DisplayName("Запретить загрузку конфигурации"), Description("Запретить загрузку конфигурации из appsettings.json"), Visible]
    public bool DisableAppsettingsConfiguration { get; set; }

    [Category("Папки"), DisplayName("Лимит вложенных подпапок"), Description("Максимально возможное количество вложенных папок на каждом уровне"), Visible]
    [Options("10", "20", "50", "100")]
    public string SubfoldersLevelCount { get; set; }

    [Category("Папки"), DisplayName("Лимит всех вложенных подпапок"), Description("Максимально возможное количество вложенных папок на всех уровнях"), Visible]
    [Options("100", "200", "500", "1000")]
    public string SubfoldersCount { get; set; }

    [Category("Объекты"), DisplayName("Поддерживаемые формы"), Description("Формы в КСП"), Text, Visible]
    public string SupportedForms { get; set; }

    [Category("Объекты"), DisplayName("Поддерживаемые объекты"), Description("Объекты, котрые являются работами в КСП"), Visible]
    public List<string> SupportedObjects { get; set; }

    [Category("Объекты"), DisplayName("Доступные модули"), Description("Модули, доступные для использования"), Visible]
    public List<string> AvailableModules { get; set; }

    [Category("Объекты"), DisplayName("Доступные классы"), Description("Классы доступные для использования"), Visible]
    public List<RqModel> AvailableClasses { get; set; }


    #region Вычисляемые свойства

    public int SubfoldersMax { get => int.TryParse(SubfoldersCount, out var max) ? max : 0; }
    public int SubfoldersLevelMax { get => int.TryParse(SubfoldersLevelCount, out var max) ? max : 0; }

    #endregion


    /// <summary>
    /// Конструктор конфигурации
    /// </summary>
    public iCommandsConfiguration()
    {
        SubfoldersCount = "500";
        SubfoldersLevelCount = "20";
        SupportedForms = "Form1\r\nForm2\r\nForm3";
        SupportedObjects = new() { "O_PLAN_Activity", "O_PLAN_Worker_Task" };
        AvailableModules = new() { "ganttChart", "teamChart" };
        ShowDevMenu = false;
        DebugMode = true;
        DisableAppsettingsConfiguration = true;

        AvailableClasses = new()
        {
            new()
            {
                GUID = Guid.NewGuid().ToString(),
                JName = "JName", 
                JUser = "JUser"
            }
        };
    }

}