using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.OOPs_Concepts
{
    public class OppsTheory
    {
        
        /*
         * =============================================================================
         * Polymorphism — Study Notes (C# Version, Interview-Oriented)
         * =============================================================================
         *
         * Definition: Performing a single action in different ways; "One interface, many forms."
         *
         * 1) Compile-Time / Static Polymorphism (Early Binding)
         * - The compiler determines exactly which method or constructor to execute at compile time.
         * - Resolution is based on the method signature (name, parameter types, count, and order).
         * - Faster execution because no runtime lookup overhead is required.
         * - Examples: Method Overloading, Constructor Overloading.
         * - Implicit Type Conversion during selection: If an exact type match isn't found, 
         *   the C# compiler attempts type promotion (e.g., widening an `int` to a `double`).
         *
         * 2) Runtime / Dynamic Polymorphism (Late Binding)
         * - The method to execute is resolved at runtime based on the actual object instance type on the heap.
         * - Achieved via Dynamic Method Dispatch using a Virtual Method Table (VMT / V-Table).
         * - C# Strict Contract: To override, the base method MUST be marked `virtual`, `abstract`, or `override`.
         * - C# Keywords: 
         *     - `virtual`: Declares in the base class that a method *can* be overridden.
         *     - `override`: Explicitly modifies the inherited method in the child class (Replaces Java's `@Override` annotation).
         *     - `sealed`: Restricts further overriding in subclasses (Replaces Java's `final` keyword for methods).
         *
         * 3) The Reference vs. Object Rule
         * - BaseClass obj = new ChildClass();
         * - Access Control / Member Visibility: Dependent strictly on the **Reference Type** (BaseClass).
         * - Method Execution Target: Dependent strictly on the **Object Creation Type** (ChildClass) at runtime.
         * =============================================================================
         */
        
            public static void RunAllDemos()
            {
                // --- Static Polymorphism Demo ---
                StaticPolymorphismDemo demoObj = new StaticPolymorphismDemo();

                // Calls the int, int overload directly
                Console.WriteLine($"Exact Match: {demoObj.Sum(5, 6)}");

                // Passes (int, int) but since exact match doesn't exist for a 3-param int method, 
                // the compiler promotes the first argument to double to match Sum(double, int, int)
                Console.WriteLine($"Implicit Type Promotion Match: {demoObj.Sum(5, 6, 7)}");

                // --- Dynamic Polymorphism Demo ---
                // Parent reference pointing to a Child object
                ParentClass obj = new ChildClass();

                // 1. Which method to call depends on Object Creation (ChildClass) -> Outputs: "Child Class Method"
                obj.Display();

                // 2. Access control / visibility depends on Reference Type (ParentClass)
                // obj.ChildSpecificMethod(); // COMPILE ERROR: ParentClass does not contain 'ChildSpecificMethod'

                // --- Abstraction Demo ---
                AbstractionTheory.RunDemo();

                // --- Encapsulation Demo ---
                EncapsulationTheory.RunDemo();

                // --- Inheritance types Demo ---
                InheritanceTheory.RunDemo();
            }

        #region Abstraction (Hidden vs. Showcased)

        /*
         * =============================================================================
         * Abstraction — Study Notes (Hidden vs. Showcased Mechanics)
         * =============================================================================
         *
         * Definition: Hiding complex internal implementation details and showcasing
         * only the essential features/capabilities of an object to the user.
         *
         * 1) What is SHOWCASED (The Surface / The "What"):
         * - The Contract: Interface definitions and public method signatures.
         * - Inputs & Outputs: Parameter lists and return types (or promised data structures).
         * - High-Level Capabilities: The simple actions an outside consumer can invoke.
         *
         * 2) What is HIDDEN (The Depth / The "How"):
         * - Execution Logic: The actual algorithms and lines of code inside method blocks.
         * - Internal State: Private fields, variables, backing stores, and buffers.
         * - Technical Nuances: Data transformation, error handling, retries, and network protocols.
         * - Downstream Dependencies: Third-party SDKs, specific endpoints, database drivers.
         *
         * 3) Architectural Benefit: Loose Coupling
         * - Changing the hidden inner logic will NOT break the consuming code as long
         *   as the showcased public contract remains exactly the same.
         * =============================================================================
         */

        public static class AbstractionTheory
        {
            public static void RunDemo()
            {
                // SHOWCASED: The consumer only interacts with the clean, abstract contract
                INotificationService notification = new SmsNotificationService();

                // Showcased: Simple capability execution requiring minimal inputs
                notification.SendNotification("+1234567890", "Your order has shipped!");

                // Note: The consumer has absolutely no visibility into the network protocols,
                // string formatting, or validation happening underneath.
            }
        }

        #region The Showcased Contract

        public interface INotificationService
        {
            // SHOWCASED: Inputs (recipient, text) and expected action. No implementation details.
            void SendNotification(string recipient, string message);
        }

        #endregion

        #region The Hidden Implementations

        public class SmsNotificationService : INotificationService
        {
            public void SendNotification(string recipient, string message)
            {
                // 1. HIDDEN: Data Validation Mechanics
                if (string.IsNullOrWhiteSpace(recipient) || !recipient.StartsWith("+"))
                {
                    throw new ArgumentException("Invalid international phone number format.");
                }

                // 2. HIDDEN: Data Transformation / Internal formatting
                string optimizedMessage = TrimMessageToSmsLimit(message);

                // 3. HIDDEN: Dependency Orchestration & Low-level Execution
                string gatewayPayload = $"{{ \"to\": \"{recipient}\", \"body\": \"{optimizedMessage}\" }}";

                PostToTelecomGateway(gatewayPayload);
            }

            private string TrimMessageToSmsLimit(string text)
            {
                return text.Length > 160 ? text.Substring(0, 157) + "..." : text;
            }

            private void PostToTelecomGateway(string payload)
            {
                Console.WriteLine($"[Network I/O Hidden Logic] Transmitting payload to SMS Gateway... \nPayload: {payload}");
            }
        }

        #endregion

        #endregion

        #region Encapsulation (Data Hiding & State Protection)

        /*
         * =============================================================================
         * Encapsulation — Study Notes (Data Hiding & State Protection)
         * =============================================================================
         *
         * Definition: Wrapping data (fields) and code (methods) together as a single
         * unit, and restricting direct access to the internal state of an object.
         *
         * 1) The Core Mechanics:
         * - Make internal fields PRIVATE to prevent external tampering.
         * - Expose controlled entry points using PUBLIC Properties (get/set/init)
         *   or methods to read and modify the data.
         * - Validation: Ensure that fields can never be assigned invalid data.
         *
         * 2) Abstraction vs. Encapsulation (The Difference):
         * - Abstraction: Focuses on hiding COMPLEXITY (What the object does).
         *   Achieved via Interfaces / Abstract classes.
         * - Encapsulation: Focuses on hiding DATA / STATE (Protecting the object's safety).
         *   Achieved via Access Modifiers (private, protected, internal, public).
         *
         * 3) Architectural Benefit: Maintainability & Invariant Protection
         * - It keeps an object's internal state valid and secure. External classes
         *   cannot bypass business validation rules.
         * =============================================================================
         */

        public static class EncapsulationTheory
        {
            public static void RunDemo()
            {
                BankAccount account = new BankAccount("Bunty Singh", 500.00m);

                // 1. Controlled Reading: We can check the balance through the public property getter.
                Console.WriteLine($"Initial Balance: ${account.Balance}");

                // 2. State Mutation through Controlled Methods:
                account.Deposit(150.00m);

                // 3. Protection Rule in Action:
                // account._balance = -50000; // COMPILE ERROR: '_balance' is inaccessible due to its protection level.

                try
                {
                    account.Withdraw(1000.00m);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Blocked Action: {ex.Message}");
                }
            }
        }

        #region Encapsulated Class

        public class BankAccount
        {
            private string _accountHolder;
            private decimal _balance;

            public decimal Balance
            {
                get { return _balance; }
            }

            public BankAccount(string holder, decimal initialDeposit)
            {
                _accountHolder = holder;
                if (initialDeposit > 0)
                {
                    _balance = initialDeposit;
                }
            }

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be positive.");
                }

                _balance += amount;
            }

            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be positive.");
                }
                if (amount > _balance)
                {
                    throw new ArgumentException("Insufficient funds. Action denied.");
                }

                _balance -= amount;
            }
        }

        #endregion

        #endregion

        #region Static Polymorphism (Overloading)

        public class StaticPolymorphismDemo
        {
            // Constructor Overloading (Multiple Constructors)
            public StaticPolymorphismDemo() { }
            public StaticPolymorphismDemo(int initialValue) { }

            // Method Overloading: Same name, different parameter types
            public int Sum(int i, int j)
            {
                return i + j;
            }

            // Overloading: Same name, different parameter count & types (Implicit casting target)
            public double Sum(double i, int j, int k)
            {
                return i + j + k;
            }
        }

        #endregion

        #region Dynamic Polymorphism (Overriding)

        public class ParentClass
        {
            // 'virtual' keyword explicitly permits overriding
            public virtual void Display()
            {
                Console.WriteLine("Parent Class Method");
            }

            // Restricting access: 'private' methods cannot be seen or overridden by subclasses
            private void PrivateHelper()
            {
                Console.WriteLine("Hidden from everyone outside this class.");
            }
        }

        public class ChildClass : ParentClass
        {
            // 'override' keyword tells the compiler this replaces the parent's behavior
            // This is a mandatory language feature in C#, unlike Java's optional @Override
            public override void Display()
            {
                Console.WriteLine("Child Class Method");
            }

            // 'sealed' prevents further subclasses from overriding this method again (Equivalent to final)
            public sealed override string ToString()
            {
                return "ChildClass Instance";
            }

            public void ChildSpecificMethod()
            {
                Console.WriteLine("Only visible via a ChildClass reference.");
            }
        }

        #endregion
    }

}
