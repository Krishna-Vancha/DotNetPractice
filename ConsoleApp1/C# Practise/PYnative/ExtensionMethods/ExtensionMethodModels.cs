using System.ComponentModel;

namespace ConsoleApp1.C__Practise.PYnative.ExtensionMethods;

public sealed class ExtensionPerson
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}

public enum ExtensionStatus
{
    Active,
    Pending,
    Closed
}

public enum ExtensionOrderStatus
{
    [Description("Order Placed")]
    Placed,

    [Description("Order Shipped")]
    Shipped,

    [Description("Order Delivered")]
    Delivered
}
