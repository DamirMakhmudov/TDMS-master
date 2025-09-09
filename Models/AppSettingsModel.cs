using System.Collections.Generic;

namespace TdmsExtension.iCommands.Models;

public class AppSettingsModel
{
    public string? Name { set; get; }
    public List<AppSettingPages>? Pages { set; get; }
}

public class AppSettingPages
{
    public string? Name { set; get; }
    public string? Caption { set; get; }
    public string? Tooltip { set; get; }
    public string? BadgeText { set; get; }
    public string? XClass { set; get; }
    public string? Source { set; get; }
    public string? FormSysId { set; get; }
    public bool? Persistent { set; get; }
}
