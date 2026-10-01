using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.DelegatesEvents;

public static class DelegateEventExerciseTests
{
    public static void RunAll()
    {
        var results = new List<PynativeExerciseRunner.SuiteResult>();
        for (int i = 1; i <= 21; i++)
            results.Add(RunExercise(i));
        PynativeExerciseRunner.PrintSummary("PYnative - Delegates & Events Exercises (21)", results);
    }

    public static PynativeExerciseRunner.SuiteResult RunExercise(int number) => number switch
    {
        1 => Test01_MathOperator(),
        2 => Test02_StringTransformer(),
        3 => Test03_FilterListOfIntegers(),
        4 => Test04_MulticastLogger(),
        5 => Test05_AnonymousGreeting(),
        6 => Test06_LambdaConversion(),
        7 => Test07_ActionReporter(),
        8 => Test08_FuncCalculator(),
        9 => Test09_PredicateMatcher(),
        10 => Test10_ButtonClick(),
        11 => Test11_StockPriceTracker(),
        12 => Test12_ThermostatAlert(),
        13 => Test13_Unsubscribing(),
        14 => Test14_StandardEventPattern(),
        15 => Test15_SafeEventInvocation(),
        16 => Test16_TextFileDownloader(),
        17 => Test17_GenericDataPipeline(),
        18 => Test18_BankAccountOverdraft(),
        19 => Test19_ChatRoomBroadcast(),
        20 => Test20_TrafficLightSystem(),
        21 => Test21_CustomEventAccessors(),
        _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Delegate/event exercises are numbered 1-21.")
    };

    public static PynativeExerciseRunner.SuiteResult Test01_MathOperator() =>
        PynativeExerciseRunner.Run(1, "The Math Operator",
            "Create a delegate MathOperation that accepts two integers and returns an integer. Assign Add and Multiply and invoke both.",
            t => t.Add(("a = 10, b = 5 -> Add 15, Multiply 50", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Add Result = 15", "Multiply Result = 50" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise01)))));

    public static PynativeExerciseRunner.SuiteResult Test02_StringTransformer() =>
        PynativeExerciseRunner.Run(2, "String Transformer",
            "Write a StringTransformer delegate and pass it to a method that processes a list of names.",
            t => t.Add(("Alice, Bob, Charlie uppercase -> ALICE, BOB, CHARLIE", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "ALICE", "BOB", "CHARLIE" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise02)))));

    public static PynativeExerciseRunner.SuiteResult Test03_FilterListOfIntegers() =>
        PynativeExerciseRunner.Run(3, "Filter List of Integers",
            "Create an IntFilter delegate and FilterList that returns only the elements that satisfy the condition.",
            t => t.Add(("1..10 IsEven -> Filtered = 2, 4, 6, 8, 10", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Filtered = 2, 4, 6, 8, 10" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise03)))));

    public static PynativeExerciseRunner.SuiteResult Test04_MulticastLogger() =>
        PynativeExerciseRunner.Run(4, "Multicast Logger",
            "Create a LogMessage delegate. Combine console, file, and debug loggers into one multicast delegate and invoke it once.",
            t => t.Add(("message = \"System started successfully\"", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Console: System started successfully",
                        "File: System started successfully",
                        "Debug: System started successfully"
                    },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise04)))));

    public static PynativeExerciseRunner.SuiteResult Test05_AnonymousGreeting() =>
        PynativeExerciseRunner.Run(5, "Anonymous Greeting",
            "Rewrite a simple greeting delegate using an anonymous method with the delegate keyword instead of a separate named method.",
            t => t.Add(("name = \"Priya\" -> Hello, Priya! Welcome.", () =>
                PynativeExerciseRunner.AssertEqual("Hello, Priya! Welcome.",
                    () => DelegateEventExercises.CreateAnonymousGreeting()("Priya")))));

    public static PynativeExerciseRunner.SuiteResult Test06_LambdaConversion() =>
        PynativeExerciseRunner.Run(6, "Lambda Conversion",
            "Take the anonymous method from Exercise 5 and rewrite it using a modern lambda expression (=>).",
            t => t.Add(("name = \"Priya\" -> Hello, Priya! Welcome.", () =>
                PynativeExerciseRunner.AssertEqual("Hello, Priya! Welcome.",
                    () => DelegateEventExercises.CreateLambdaGreeting()("Priya")))));

    public static PynativeExerciseRunner.SuiteResult Test07_ActionReporter() =>
        PynativeExerciseRunner.Run(7, "Action Reporter",
            "Use Action<string, ConsoleColor> to print messages in different colors, without a custom delegate type.",
            t => t.Add(("Info Green, Warning Yellow, Error Red", () =>
            {
                Action<string, ConsoleColor> report = DelegateEventExercises.CreateReporter();
                string[] lines = PynativeConsole.CaptureLines(() =>
                {
                    report("Info: Load complete", ConsoleColor.Green);
                    report("Warning: Low disk space", ConsoleColor.Yellow);
                    report("Error: Connection failed", ConsoleColor.Red);
                });
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Info: Load complete",
                        "Warning: Low disk space",
                        "Error: Connection failed"
                    },
                    lines);
            })));

    public static PynativeExerciseRunner.SuiteResult Test08_FuncCalculator() =>
        PynativeExerciseRunner.Run(8, "Func Calculator",
            "Use Func<double, double, double> to divide, checking for division by zero before the calculation runs.",
            t => t.Add(("10 / 2 -> Result = 5; 10 / 0 -> Cannot divide by zero", () =>
            {
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Result = 5", "Cannot divide by zero" },
                    new[]
                    {
                        DelegateEventExercises.DescribeDivision(10, 2),
                        DelegateEventExercises.DescribeDivision(10, 0)
                    });
            })));

    public static PynativeExerciseRunner.SuiteResult Test09_PredicateMatcher() =>
        PynativeExerciseRunner.Run(9, "Predicate Matcher",
            "Use Predicate<T> to find the first book published before a certain year.",
            t => t.Add(("books before 2000 -> The Great Gatsby (1925)", () =>
            {
                DelegateBook? match = DelegateEventExercises.FindFirstPublishedBefore(new[]
                {
                    new DelegateBook { Title = "The Great Gatsby", Year = 1925 },
                    new DelegateBook { Title = "Clean Code", Year = 2008 },
                    new DelegateBook { Title = "1984", Year = 1949 }
                }, 2000);
                PynativeExerciseRunner.PrintOutput(match is null ? "null" : $"Found: {match.Title} ({match.Year})");
                PynativeExerciseRunner.AssertEqualSilent("The Great Gatsby", match!.Title);
                PynativeExerciseRunner.AssertEqualSilent(1925, match.Year);
            })));

    public static PynativeExerciseRunner.SuiteResult Test10_ButtonClick() =>
        PynativeExerciseRunner.Run(10, "The Button Click",
            "Create a Button class with a custom delegate and an OnClick event raised by Click().",
            t => t.Add(("subscribe then Click() -> Button was clicked!", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Button was clicked!" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise10)))));

    public static PynativeExerciseRunner.SuiteResult Test11_StockPriceTracker() =>
        PynativeExerciseRunner.Run(11, "Stock Price Tracker",
            "Create a Stock class that raises PriceChanged whenever Price changes, printing the old and new prices.",
            t => t.Add(("100 -> 150 -> 165", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Price changed from 100 to 150",
                        "Price changed from 150 to 165"
                    },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise11)))));

    public static PynativeExerciseRunner.SuiteResult Test12_ThermostatAlert() =>
        PynativeExerciseRunner.Run(12, "Thermostat Alert",
            "Design a Thermostat class that fires TemperatureCritical if the temperature rises above 100 degrees C.",
            t => t.Add(("85 then 105 -> Critical temperature reached: 105 C", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Critical temperature reached: 105\u00B0C" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise12)))));

    public static PynativeExerciseRunner.SuiteResult Test13_Unsubscribing() =>
        PynativeExerciseRunner.Run(13, "Unsubscribing Memory Leak",
            "Subscribe to an event, fire it, unsubscribe, and fire it again. The handler should run only once.",
            t => t.Add(("subscribe, raise, unsubscribe, raise -> Handler triggered once", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Handler triggered" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise13)))));

    public static PynativeExerciseRunner.SuiteResult Test14_StandardEventPattern() =>
        PynativeExerciseRunner.Run(14, "Standard .NET Event Pattern",
            "Redo the stock tracker with EventHandler<TEventArgs> and a StockChangedEventArgs subclass.",
            t => t.Add(("100 -> 150 -> 165", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Price changed from 100 to 150",
                        "Price changed from 150 to 165"
                    },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise14)))));

    public static PynativeExerciseRunner.SuiteResult Test15_SafeEventInvocation() =>
        PynativeExerciseRunner.Run(15, "Safe Event Invocation",
            "Raise an event with MyEvent?.Invoke so a call with no subscribers does not throw.",
            t => t.Add(("raise, then subscribe, then raise -> Event raised safely once", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Event raised safely" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise15)))));

    public static PynativeExerciseRunner.SuiteResult Test16_TextFileDownloader() =>
        PynativeExerciseRunner.Run(16, "Text File Downloader",
            "Create a FileDownloader with a ProgressChanged event that reports percentage completion.",
            t => t.Add(("progress 25, 50, 75, 100", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Download progress: 25%",
                        "Download progress: 50%",
                        "Download progress: 75%",
                        "Download progress: 100%"
                    },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise16)))));

    public static PynativeExerciseRunner.SuiteResult Test17_GenericDataPipeline() =>
        PynativeExerciseRunner.Run(17, "Generic Data Pipeline",
            "Write Pipeline<T> that passes data through a chain of Func<T, T> transforms.",
            t => t.Add(("3, double, add 5, square -> Result = 121", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Result = 121" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise17)))));

    public static PynativeExerciseRunner.SuiteResult Test18_BankAccountOverdraft() =>
        PynativeExerciseRunner.Run(18, "BankAccount Overdraft Protection",
            "If a withdrawal exceeds the balance, fire OverdraftAttempted and let the subscriber cancel it.",
            t => t.Add(("balance 100, withdraw 150, Cancel = true", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Overdraft attempted for 150",
                        "Transaction cancelled by subscriber",
                        "Balance remains: 100"
                    },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise18)))));

    public static PynativeExerciseRunner.SuiteResult Test19_ChatRoomBroadcast() =>
        PynativeExerciseRunner.Run(19, "The Chat Room Broadcast",
            "When one user sends a message, the ChatRoom broadcasts it to all other connected users.",
            t => t.Add(("Alice sends \"Hello everyone!\" to Bob and Charlie", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Bob received: Hello everyone!",
                        "Charlie received: Hello everyone!"
                    },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise19)))));

    public static PynativeExerciseRunner.SuiteResult Test20_TrafficLightSystem() =>
        PynativeExerciseRunner.Run(20, "Traffic Light System",
            "TrafficLightController notifies Car and Pedestrian objects as it changes to Green, Yellow, then Red.",
            t => t.Add(("Green, Yellow, Red", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[]
                    {
                        "Car: Driving through green light",
                        "Pedestrian: Do not cross",
                        "Car: Slowing down for yellow light",
                        "Pedestrian: Do not cross",
                        "Car: Stopped at red light",
                        "Pedestrian: Waiting to cross"
                    },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise20)))));

    public static PynativeExerciseRunner.SuiteResult Test21_CustomEventAccessors() =>
        PynativeExerciseRunner.Run(21, "Custom Event Accessors (add / remove)",
            "Implement an event with add and remove accessors that log when a subscriber attaches or detaches.",
            t => t.Add(("subscribe then unsubscribe", () =>
                PynativeExerciseRunner.AssertSequenceEqual(
                    new[] { "Subscriber added", "Subscriber removed" },
                    () => PynativeConsole.CaptureLines(DelegateEventExercises.RunExercise21)))));
}
