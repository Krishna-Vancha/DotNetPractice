using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.FileHandling;

public sealed class FileEmployee
{
    public string Name { get; set; } = "";
}

public sealed class FileCompany
{
    public string Name { get; set; } = "";
    public List<FileEmployee> Employees { get; set; } = new();
}
