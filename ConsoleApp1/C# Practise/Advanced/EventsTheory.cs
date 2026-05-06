using System;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Events in C# — interview notes (read with the code below)
 * =============================================================================
 * QuickReview/Subtopics: Observer Pattern(Publisher/Subscriber),event keyword, EventHandler<CustomEventArgs>, CustomEventArgs derived class of EventArgs to send data when event triggeredd , 
 * event(delegate) is owned by publisher(triggers event) , subscriber(contains methods of that event).
 *
 * 1) What is an event?
 * - A messaging mechanism built on top of delegates.
 * - Implements the "Observer" pattern (Publisher sends, Subscribers receive).
 * - The 'event' keyword provides a layer of protection over a delegate.
 *
 * 2) Events vs. Delegates (The "Interview Classic")
 * - A public delegate can be cleared (d = null) or invoked (d()) by anyone.
 * - An event only allows external code to use += and -=. 
 * - Only the class that defines the event can "trigger" (invoke) it.
 *
 * 3) Standard .NET Pattern (EventHandler)
 * - Use 'EventHandler' for events without data.
 * - Use 'EventHandler<TEventArgs>' for events with data.
 * - Signature: void (object sender, TEventArgs e).
 *
 * 4) Null-Safety (The ?.Invoke pattern)
 * - If an event has no subscribers, it is null. Calling it crashes the app.
 * - Use the null-conditional operator: MyEvent?.Invoke(this, args);
 *
 * 5) Memory Leaks (The "Lapsed Listener" problem)
 * - If a subscriber is not unsubscribed (-=) when finished, the publisher 
 * keeps a reference to it, preventing Garbage Collection (GC).
 * - Interview: Always mention -= in IDisposable or when closing UI views.
 *
 * 6) Virtual OnXxx Methods
 * - Best practice: Wrap event invocation in a 'protected virtual' method 
 * (e.g., OnClicked). This allows derived classes to override or trigger.
 *
 * 7) Custom Event Accessors (add/remove)
 * - Like properties have get/set, events have add/remove.
 * - Used for thread-safety or custom logic when someone subscribes.
 * =============================================================================
 */

public static class EventsTheory
{
    public static void RunAllDemos()
    {
        StandardEventPattern_Section();
        CustomArgs_Section();
        Unsubscribe_Section();
        CustomAccessors_Section();
    }

    #region Standard Event Pattern

    public class SimpleButton
    {
        // Standard non-generic event
        public event EventHandler? Clicked;

        public void Press()
        {
            // Null-safe invocation
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public static void StandardEventPattern_Section()
    {
        var btn = new SimpleButton();
        // Method group conversion for subscriber
        btn.Clicked += OnButtonClicked;
        btn.Press();
    }

    private static void OnButtonClicked(object? sender, EventArgs e)
        => Console.WriteLine("Button clicked!");

    #endregion

    #region Custom EventArgs

    // Custom data class (must inherit from EventArgs)
    public class HealthChangedEventArgs : EventArgs
    {
        public int NewHealth { get; }
        public HealthChangedEventArgs(int health) => NewHealth = health;
    }

    public class Player
    {
        public event EventHandler<HealthChangedEventArgs>? HealthChanged;

        public void TakeDamage(int amount)
        {
            // Logic...
            HealthChanged?.Invoke(this, new HealthChangedEventArgs(80));
        }
    }

    public static void CustomArgs_Section()
    {
        var player = new Player();
        player.HealthChanged += (s, e) => Console.WriteLine($"Health: {e.NewHealth}");
        player.TakeDamage(20);
    }

    #endregion

    #region Unsubscribing (Memory Management)

    public static void Unsubscribe_Section()
    {
        var btn = new SimpleButton();
        EventHandler handler = (s, e) => { };

        btn.Clicked += handler; // Subscribed
        btn.Clicked -= handler; // Unsubscribed - safe for GC
    }

    #endregion

    #region Custom Accessors (Advanced)

    public class SecureEvent
    {
        private EventHandler? _myEventBackingField;

        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("Someone subscribed!");
                _myEventBackingField += value;
            }
            remove
            {
                Console.WriteLine("Someone unsubscribed!");
                _myEventBackingField -= value;
            }
        }
    }

    public static void CustomAccessors_Section()
    {
        var sec = new SecureEvent();
        sec.MyEvent += (s, e) => { };
    }

    #endregion
}