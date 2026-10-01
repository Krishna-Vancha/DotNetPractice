using System;
using System.Collections.Generic;

namespace ConsoleApp1.C__Practise.PYnative.DelegatesEvents;

// Source: https://pynative.com/csharp-delegates-events-exercises/
// The page title says 20 problems; the page lists 21 exercises. These stubs follow the page.
//
// Exercises that ask you to define a delegate, class, or event use RunExerciseNN().
// Exercises 5, 6, 7, 8, and 9 are computation stubs.

public static partial class DelegateEventExercises
{
    // Exercise 1: The Math Operator
    //
    // Practice Problem: Create a delegate called MathOperation that accepts two integers and returns an integer. Implement Add and Multiply methods, then assign them to the delegate to perform calculations.
    //
    // Given Input: a = 10, b = 5, invoked once through Add and once through Multiply.
    //
    // Expected Output:
    // Add Result = 15
    // Multiply Result = 50
    //
    // --- Your solution: MathOperation + RunExercise01() below ---

    public static void RunExercise01() =>
        throw new NotImplementedException();

    // Exercise 2: String Transformer
    //
    // Practice Problem: Write a delegate StringTransformer that takes a string and returns a string. Pass it to a method that processes a list of names, letting the caller choose whether to convert them to uppercase, lowercase, or reverse them.
    //
    // Given Input: names = ["Alice", "Bob", "Charlie"], processed with an uppercase transformer.
    //
    // Expected Output:
    // ALICE
    // BOB
    // CHARLIE
    //
    // --- Your solution: StringTransformer + RunExercise02() below ---

    public static void RunExercise02() =>
        throw new NotImplementedException();

    // Exercise 3: Filter List of Integers
    //
    // Practice Problem: Create a custom delegate IntFilter that takes an integer and returns a boolean. Write a method FilterList(List numbers, IntFilter filter) that returns a new list containing only the elements that satisfy the condition.
    //
    // Given Input: numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], filtered using an IsEven condition.
    //
    // Expected Output:
    // Filtered = 2, 4, 6, 8, 10
    //
    // --- Your solution: IntFilter + RunExercise03() below ---

    public static void RunExercise03() =>
        throw new NotImplementedException();

    // Exercise 4: Multicast Logger
    //
    // Practice Problem: Create a LogMessage delegate. Write three methods that log a message to the console, a mock text file, and a mock debug window. Combine all three into a single multicast delegate and invoke it once.
    //
    // Given Input: message = "System started successfully"
    //
    // Expected Output:
    // Console: System started successfully
    // File: System started successfully
    // Debug: System started successfully
    //
    // --- Your solution: LogMessage + RunExercise04() below ---

    public static void RunExercise04() =>
        throw new NotImplementedException();

    // Question 5: Greeting built with an anonymous method (delegate keyword), not a named method.
    public static Func<string, string> CreateAnonymousGreeting()
        => throw new NotImplementedException();

    // Question 6: Same greeting as exercise 5, written as a lambda expression (=>).
    public static Func<string, string> CreateLambdaGreeting()
        => throw new NotImplementedException();

    // Question 7: Action<string, ConsoleColor> that prints the message (color may be applied around the write).
    public static Action<string, ConsoleColor> CreateReporter()
        => throw new NotImplementedException();

    // Question 8: Divide a by b using Func<double, double, double>. Return "Result = 5" or "Cannot divide by zero".
    public static string DescribeDivision(double a, double b)
        => throw new NotImplementedException();

    // Question 9: Use Predicate<DelegateBook> to find the first book published before the given year.
    public static DelegateBook? FindFirstPublishedBefore(IEnumerable<DelegateBook> books, int year)
        => throw new NotImplementedException();

    // Exercise 10: The Button Click
    //
    // Practice Problem: Create a Button class. Simulate a user clicking the button by defining a custom delegate and an OnClick event, then raise the event when a Click() method is called.
    //
    // Given Input: A handler method is subscribed to OnClick before button.Click() is called.
    //
    // Expected Output:
    // Button was clicked!
    //
    // --- Your solution: Button + RunExercise10() below ---

    public static void RunExercise10() =>
        throw new NotImplementedException();

    // Exercise 11: Stock Price Tracker
    //
    // Practice Problem: Create a Stock class with a Price property. Raise a PriceChanged event whenever the price changes, notifying a StockTrader class that prints the old and new prices.
    //
    // Given Input: Price starts at 100, then changes to 150, then to 165.
    //
    // Expected Output:
    // Price changed from 100 to 150
    // Price changed from 150 to 165
    //
    // --- Your solution: Stock, StockTrader + RunExercise11() below ---

    public static void RunExercise11() =>
        throw new NotImplementedException();

    // Exercise 12: Thermostat Alert
    //
    // Practice Problem: Design a Thermostat class that fires a TemperatureCritical event if the temperature rises above 100 degrees C.
    //
    // Given Input: Temperature is set to 85, then to 105.
    //
    // Expected Output:
    // Critical temperature reached: 105°C
    //
    // --- Your solution: Thermostat + RunExercise12() below ---

    public static void RunExercise12() =>
        throw new NotImplementedException();

    // Exercise 13: Unsubscribing Memory Leak
    //
    // Practice Problem: Write a program where an object subscribes to an event, fires it, unsubscribes, and fires it again. Verify that the second fire does not trigger the unsubscribed object.
    //
    // Given Input: Subscribe Handler to MyEvent, raise the event, unsubscribe Handler, then raise the event again.
    //
    // Expected Output:
    // Handler triggered
    //
    // --- Your solution: publisher with MyEvent + RunExercise13() below ---

    public static void RunExercise13() =>
        throw new NotImplementedException();

    // Exercise 14: Standard .NET Event Pattern
    //
    // Practice Problem: Redo the Stock Price Tracker (Exercise 11) using the standard .NET guidelines: use EventHandler<T> and a custom EventArgs subclass named StockChangedEventArgs.
    //
    // Given Input: Price starts at 100, then changes to 150, then to 165.
    //
    // Expected Output:
    // Price changed from 100 to 150
    // Price changed from 150 to 165
    //
    // --- Your solution: StockChangedEventArgs + RunExercise14() below ---

    public static void RunExercise14() =>
        throw new NotImplementedException();

    // Exercise 15: Safe Event Invocation
    //
    // Practice Problem: Implement a class that raises an event safely using the null-conditional operator (MyEvent?.Invoke(this, EventArgs.Empty)) to avoid a null reference exception when there are no subscribers.
    //
    // Given Input: RaiseEvent() is called once before any subscriber is attached, then a handler subscribes, then RaiseEvent() is called again.
    //
    // Expected Output:
    // Event raised safely
    //
    // --- Your solution: safe publisher + RunExercise15() below ---

    public static void RunExercise15() =>
        throw new NotImplementedException();

    // Exercise 16: Text File Downloader
    //
    // Practice Problem: Create a FileDownloader class. Implement a ProgressChanged event using EventHandler<T> that passes the percentage completion back to the console UI.
    //
    // Given Input: A simulated download that reports progress in steps of 25, up to 100.
    //
    // Expected Output:
    // Download progress: 25%
    // Download progress: 50%
    // Download progress: 75%
    // Download progress: 100%
    //
    // --- Your solution: FileDownloader + RunExercise16() below ---

    public static void RunExercise16() =>
        throw new NotImplementedException();

    // Exercise 17: Generic Data Pipeline
    //
    // Practice Problem: Write a generic class Pipeline<T> that accepts data and passes it through a chain of generic Func<T, T> delegates to transform the data step by step.
    //
    // Given Input: Starting value 3, passed through three steps: double it, add 5, then square it.
    //
    // Expected Output:
    // Result = 121
    //
    // --- Your solution: Pipeline<T> + RunExercise17() below ---

    public static void RunExercise17() =>
        throw new NotImplementedException();

    // Exercise 18: BankAccount Overdraft Protection
    //
    // Practice Problem: Create a BankAccount class with a Withdraw method. If a withdrawal exceeds the balance, fire an OverdraftAttempted event, and allow the subscriber to cancel the transaction using a property inside the event data.
    //
    // Given Input: Balance starts at 100. A withdrawal of 150 is attempted, and the subscriber sets Cancel = true.
    //
    // Expected Output:
    // Overdraft attempted for 150
    // Transaction cancelled by subscriber
    // Balance remains: 100
    //
    // --- Your solution: BankAccount + RunExercise18() below ---

    public static void RunExercise18() =>
        throw new NotImplementedException();

    // Exercise 19: The Chat Room Broadcast
    //
    // Practice Problem: Build a ChatRoom class where multiple User objects can join. When one user sends a message, the ChatRoom broadcasts it to all other connected users through events.
    //
    // Given Input: Three users, Alice, Bob, and Charlie, join the room. Alice sends "Hello everyone!".
    //
    // Expected Output:
    // Bob received: Hello everyone!
    // Charlie received: Hello everyone!
    //
    // --- Your solution: ChatRoom, User + RunExercise19() below ---

    public static void RunExercise19() =>
        throw new NotImplementedException();

    // Exercise 20: Traffic Light System
    //
    // Practice Problem: Create a TrafficLightController that manages Red, Yellow, and Green state transitions. Use events to notify attached Car and Pedestrian objects so each can change its own behavior.
    //
    // Given Input: The controller changes from its starting state to Green, then Yellow, then Red.
    //
    // Expected Output:
    // Car: Driving through green light
    // Pedestrian: Do not cross
    // Car: Slowing down for yellow light
    // Pedestrian: Do not cross
    // Car: Stopped at red light
    // Pedestrian: Waiting to cross
    //
    // --- Your solution: TrafficLightController, Car, Pedestrian + RunExercise20() below ---

    public static void RunExercise20() =>
        throw new NotImplementedException();

    // Exercise 21: Custom Event Accessors (add / remove)
    //
    // Practice Problem: Implement an event explicitly using add and remove accessors to log to the console every time a subscriber attaches or detaches from the event.
    //
    // Given Input: A handler subscribes to MyEvent, then unsubscribes from it.
    //
    // Expected Output:
    // Subscriber added
    // Subscriber removed
    //
    // --- Your solution: event with add/remove + RunExercise21() below ---

    public static void RunExercise21() =>
        throw new NotImplementedException();
}
