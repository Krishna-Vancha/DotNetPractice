using System;

namespace ConsoleApp1.C__Practise.OOPs_Concepts;

/*
 * =============================================================================
 * Types of Inheritance in C# — Study Notes
 * =============================================================================
 *
 * 1) Single Inheritance (Supported):
 *    - A derived class inherits from exactly ONE base class.
 *    - C# is a single-inheritance language for classes to avoid the "Diamond Problem"
 *      (ambiguity caused when two base classes have methods with the same name).
 *
 * 2) Multilevel Inheritance (Supported):
 *    - A class inherits from a derived class, creating a linear chain of inheritance.
 *    - Example: Class C inherits from Class B, which inherits from Class A.
 *
 * 3) Hierarchical Inheritance (Supported):
 *    - Multiple derived classes inherit from a single, shared base class.
 *    - Example: Both 'Car' and 'Truck' inherit from 'Vehicle'.
 *
 * 4) Multiple Inheritance (NOT Supported via Classes; Supported via Interfaces):
 *    - A class CANNOT inherit from more than one class.
 *    - To achieve the design pattern of multiple inheritance, C# allows a class to
 *      implement multiple **Interfaces**.
 * =============================================================================
 */

public static class InheritanceTheory
{
    public static void RunDemo()
    {
        Console.WriteLine("=== 1. Single & Multilevel Inheritance ===");
        SmartPhone myPhone = new SmartPhone();
        myPhone.TurnOn();
        myPhone.MakeCall();
        myPhone.Browse();

        Console.WriteLine("\n=== 2. Hierarchical Inheritance ===");
        Laptop laptop = new Laptop();
        laptop.TurnOn();
        laptop.CompileCode();

        Console.WriteLine("\n=== 3. Multiple Inheritance via Interfaces ===");
        TechGadget gadget = new TechGadget();
        gadget.Boot();
        gadget.ConnectToWifi();
        gadget.CapturePhoto();
    }
}

#region 1. Single & Multilevel Inheritance Layout

public class Device
{
    public void TurnOn() => Console.WriteLine("Device powered up.");
}

public class Phone : Device
{
    public void MakeCall() => Console.WriteLine("Placing an audio call...");
}

public class SmartPhone : Phone
{
    public void Browse() => Console.WriteLine("Browsing the web via mobile data.");
}

#endregion

#region 2. Hierarchical Inheritance Layout

public class Laptop : Device
{
    public void CompileCode() => Console.WriteLine("Compiling .NET C# source code.");
}

#endregion

#region 3. Simulating Multiple Inheritance via Interfaces

public interface IWifiConnectable
{
    void ConnectToWifi();
}

public interface ICamera
{
    void CapturePhoto();
}

// public class TechGadget : Device, Phone // COMPILE ERROR — only one base class
public class TechGadget : Device, IWifiConnectable, ICamera
{
    public void Boot() => TurnOn();

    public void ConnectToWifi() => Console.WriteLine("Connected to local network SSID.");
    public void CapturePhoto() => Console.WriteLine("Image saved to local storage.");
}

#endregion
