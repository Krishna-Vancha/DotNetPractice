using System;
using System.IO;

namespace ConsoleApp1.C__Practise.PYnative;

/// <summary>
/// Captures Console.Out for exercises whose expected result is printed output.
/// Shared by all PYnative topics (Generics/OOP keep their own older helpers).
/// </summary>
public static class PynativeConsole
{
    public static string Capture(Action action)
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
        string output = Capture(action);
        if (string.IsNullOrEmpty(output))
            return Array.Empty<string>();

        return output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
    }
}
