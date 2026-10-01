using System;
using System.IO;

namespace ConsoleApp1.C__Practise.PYnative.Generics;

/// <summary>
/// Captures Console.WriteLine output for Generics exercise tests.
/// </summary>
public static class GenericConsoleHelper
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
