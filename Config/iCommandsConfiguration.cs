using System.Collections.Generic;
using System.ComponentModel;
using Tdms;

namespace TdmsExtension.iCommands;

/// <summary>
/// Класс конфигурации, имеет имя такое же как имя dll с добавлением .config
/// Куда можно помещать настройки для текущего расширения.
/// </summary>
[ModuleConfiguration]
public class iCommandsConfiguration
{
    public iCommandsConfiguration()
    {
        CountSubfolders = "500";
        CountLevelSubfolders = 20;
        SupportedForms = "Form1\r\nForm2\r\nForm3";
        SupportedObjects = new() { "O_PLAN_Activity", "O_PLAN_Worker_Task" };
        AvailableModules = new() { "ganttChart", "teamChart" };
        ShowDevMenu = false;
        DebugMode = true;
        DisableAppsettingsConfiguration = true;
    }

    [Category("Разработка"), DisplayName("Меню разработчика"), Description("Показывать меню разработчика"), Visible]
    public bool ShowDevMenu { get; set; }

    [Category("Разработка"), DisplayName("Режим отладки"), Description("Режим отладки, фронтенд с внешенего сервера"), Visible]
    public bool DebugMode { get; set; }


    [Category("Параметры"), DisplayName("Запретить загрузку конфигурации"), Description("Запретить загрузку конфигурации из appsettings.json"), Visible]
    public bool DisableAppsettingsConfiguration { get; set; }

    [Category("Папки"), DisplayName("Лимит всех вложенных подпапок"), Description("Максимально возможное количество вложенных папок на всех уровнях"), Visible]
    [Options("100", "200", "500", "1000")]
    public string CountSubfolders { get; set; }

    [Category("Папки"), DisplayName("Лимит вложенных подпапок"), Description("Максимально возможное количество вложенных папок на каждом уровне"), Visible]
    public int CountLevelSubfolders { get; set; }

    [Category("Объекты"), DisplayName("Поддерживаемые формы"), Description("Формы в КСП"), Text, Visible]
    public string SupportedForms { get; set; }

    [Category("Объекты"), DisplayName("Поддерживаемые объекты"), Description("Объекты, котрые являются работами в КСП"), Visible]
    public List<string> SupportedObjects { get; set; }

    [Category("Объекты"), DisplayName("Доступные модули"), Description("Модули, доступные для использования"), Visible]
    public List<string> AvailableModules { get; set; }

}