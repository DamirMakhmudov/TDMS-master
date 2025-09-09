using System;

namespace TdmsExtension.iCommands.Helpers;

/// <summary>
/// Флаги операций
/// </summary>
[Flags]
public enum OperationState : uint
{
    Default = 0, 
    Empty = 0x01, 
    Null = 0x02, 
    UpperCase = 0x04,
    LowerCase = 0x08, 
    Unique = 0x10, 
    SpecialChar = 0x20, 
    Clone = 0x40,
    TrimStart = 0x80,
    TrimEnd = 0x100,
    Trim = TrimStart | TrimEnd,
    TrimAll = 0x200, 
}
