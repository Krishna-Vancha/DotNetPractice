using System.Globalization;

namespace ConsoleApp1.CSharpPractise.ValueTypes;

/// <summary>
/// Call ValueTypeIoPractice.Run() from any Main to practise console I/O for value types.
/// </summary>
internal static class ValueTypeIoPractice
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("bool (true/false): ");
        _ = bool.TryParse(Console.ReadLine(), out bool b);
        Console.WriteLine($"bool: {b}");

        Console.Write("char (one character): ");
        string? chLine = Console.ReadLine();
        char c = string.IsNullOrEmpty(chLine) ? default : chLine[0];
        Console.WriteLine($"char: '{c}' (code {(int)c})");

        Console.Write("byte (0-255): ");
        _ = byte.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out byte by);
        Console.WriteLine($"byte: {by}");

        Console.Write("sbyte (-128..127): ");
        _ = sbyte.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out sbyte sb);
        Console.WriteLine($"sbyte: {sb}");

        Console.Write("short: ");
        _ = short.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out short sh);
        Console.WriteLine($"short: {sh}");

        Console.Write("ushort: ");
        _ = ushort.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out ushort ush);
        Console.WriteLine($"ushort: {ush}");

        Console.Write("int: ");
        _ = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int i);
        Console.WriteLine($"int: {i}");

        Console.Write("uint: ");
        _ = uint.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out uint ui);
        Console.WriteLine($"uint: {ui}");

        Console.Write("long: ");
        _ = long.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out long lo);
        Console.WriteLine($"long: {lo}");

        Console.Write("ulong: ");
        _ = ulong.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out ulong ul);
        Console.WriteLine($"ulong: {ul}");

        Console.Write("float (e.g. 3.14): ");
        _ = float.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out float f);
        Console.WriteLine($"float: {f:R}");

        Console.Write("double: ");
        _ = double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double d);
        Console.WriteLine($"double: {d:R}");

        Console.Write("decimal (money, e.g. 19.99): ");
        _ = decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal m);
        Console.WriteLine($"decimal: {m:0.00}");

        Console.Write("nint (platform-sized int): ");
        _ = nint.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out nint ni);
        Console.WriteLine($"nint: {ni}");

        Console.Write("nuint: ");
        _ = nuint.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out nuint nui);
        Console.WriteLine($"nuint: {nui}");

        Console.Write("DayOfWeek name (e.g. Monday): ");
        _ = Enum.TryParse(Console.ReadLine(), ignoreCase: true, out DayOfWeek dow);
        Console.WriteLine($"enum DayOfWeek: {dow} ({(int)dow})");

        Console.Write("nullable int (empty = null): ");
        string? niLine = Console.ReadLine();
        int? nullableInt = string.IsNullOrWhiteSpace(niLine)
            ? null
            : int.TryParse(niLine, NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsed) ? parsed : null;
        Console.WriteLine(nullableInt.HasValue ? $"int?: {nullableInt.Value}" : "int?: null");

        Console.WriteLine();
        Console.WriteLine("--- formats ---");
        Console.WriteLine($"decimal currency: {m:C}");
        Console.WriteLine($"double bits: {BitConverter.DoubleToInt64Bits(d):X16}");
    }
}
