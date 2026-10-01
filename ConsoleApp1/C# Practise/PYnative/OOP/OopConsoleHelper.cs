using System;
using System.IO;

namespace ConsoleApp1.C__Practise.PYnative.OOP;

/// <summary>
/// Captures Console.WriteLine output for OOP exercise tests.
/// </summary>
public static class OopConsoleHelper
{
    public static string CaptureConsole(Action action)
    {
        var writer = new StringWriter();
        TextWriter original = Console.Out;
        try
        {
            Console.SetOut(writer);
            action();
            return writer.ToString().TrimEnd('\r', '\n');
        }
        finally
        {
            Console.SetOut(original);
        }
    }

    public static string[] CaptureLines(Action action)
    {
        string output = CaptureConsole(action);
        if (string.IsNullOrEmpty(output))
            return Array.Empty<string>();

        return output.Split(Environment.NewLine, StringSplitOptions.None);
    }
}
