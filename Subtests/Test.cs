using System;
using System.Runtime.InteropServices;
using Tdms.Api;

namespace TdmsExtension.iCommands.Subtests;

[ComVisible(true)]
public class Test
{
    public string? Name { get; set; }
    public string? Age { get; set; }

    public TDMSApplication? TA;
    public Test() { 
    }
    public Test(string name, string age, TDMSApplication application)
    {
        Name = name;
        Age = age;
        TA = application;
    }

    [ComVisible(true)]
    public string GetStr()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Age);
        Console.WriteLine(TA?.DatabaseName);
        return "Ok";
    }
}
