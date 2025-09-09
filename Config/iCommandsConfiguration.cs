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
        rootObjects = "";
        supportedObjects = "O_PLAN_KSG, O_PLAN_WBS, O_PLAN_Activity, O_PLAN_Worker_Task";
        availableModules = "ganttChart, loadChart, teamChart";
        ShowDevMenu = false;
        DebugMode = true;
    }

    #region Runtime properties

    public List<string> RootObjects => StringToArray(rootObjects);
    public List<string> SupportedObjects => StringToArray(supportedObjects);
    public List<string> AvailableModules => StringToArray(availableModules);

    #endregion Runtime properties

    [Visible, Description("Объекты с котрых может открываться КСП"), DisplayName("Корневые объекты")]
    public string rootObjects { get; set; }

    [Visible, Description("Объекты котрые являются работами в КСП"), DisplayName("Поддерживаемые объекты")]
    public string supportedObjects { get; set; }

    [Visible, Description("Модули КСП, доступные для использования"), DisplayName("Доступные модули")]
    public string availableModules { get; set; }

    [Visible, Description("Показывать меню разработчика"), DisplayName("Меню разработчика")]
    public bool ShowDevMenu { get; set; }

    [Visible, Description("Режим отладки, фронтенд с внешенего сервера"), DisplayName("Режим отладки")]
    public bool DebugMode { get; set; }

    private static List<string> StringToArray(string str, string delimiter = ",")
    {
        List<string> arr = new(str.Split(delimiter));
        for (int index = 0; index < arr.Count; index++)
        {
            arr[index] = arr[index].Trim();
        }
        return arr;
    }
}