namespace ConsoleApp1.C__Practise.PYnative.PatternMatching;

public sealed class PatternCircle
{
    public double Radius { get; set; }

    public PatternCircle(double radius) => Radius = radius;
}

public sealed class PatternRectangle
{
    public double Width { get; set; }
    public double Height { get; set; }

    public PatternRectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
}

public sealed class PatternOrder
{
    public decimal TotalPrice { get; set; }
    public bool IsPremiumCustomer { get; set; }
}

public sealed class PatternAddress
{
    public string Country { get; set; } = "";
}

public sealed class PatternProfile
{
    public PatternAddress? Address { get; set; }
}

public sealed class PatternUser
{
    public PatternProfile? Profile { get; set; }
}

public sealed class PatternButton
{
    public bool IsEnabled { get; set; }
    public bool IsHovered { get; set; }
    public bool IsPressed { get; set; }
}

public sealed record PatternPoint(int X, int Y);

public enum PatternLightState
{
    Red,
    Yellow,
    Green
}
