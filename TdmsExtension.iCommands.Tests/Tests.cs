using System.Runtime.CompilerServices;
using TdmsExtension.iCommands.Models;

namespace TdmsExtension.iCommands.Tests;

[TestClass]
public sealed class TestMasterMethod
{

    [TestMethod]
    public void TestMethod1()
    {
        var dataMasterMethod = new JRequest
        {
            GUID = new Guid().ToString(),
            JName = "Имя J",
            JUser = "Пользователь J",
        };

        Assert.IsTrue(true, $"===============================");
    }

    /// <summary>
    /// Тест IsNullOrEmpty
    /// </summary>
    [TestMethod]
    public void TestIsNullOrEmpty()
    {
        var lib = new CommandLib(null, null, null, null);

        checkIsNullOrEmpty(lib, lib);

        checkIsNullOrEmpty(lib, null);

        checkIsNullOrEmpty(lib, new List<string>().ToArray());

        checkIsNullOrEmpty(lib, new List<string>());

        checkIsNullOrEmpty(lib, new[] { 1, 2 });

        checkIsNullOrEmpty(lib, new[] { 1, 2 }.ToList());

        checkIsNullOrEmpty(lib, string.Empty);

        checkIsNullOrEmpty(lib, "test");

        checkIsNullOrEmpty(lib, new Dictionary<string, string>());

    }


    private void checkIsNullOrEmpty(CommandLib lib, object? arg1, [CallerArgumentExpression("arg1")] string argumentExpression = "")
    {
        var result = lib.IsNullOrEmpty(arg1);
        Console.WriteLine($"{argumentExpression} = {result}");
    }

}
