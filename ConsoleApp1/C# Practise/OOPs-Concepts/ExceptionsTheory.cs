using System;
using System.Runtime.ExceptionServices;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Exception Handling in C# — study notes (interview-oriented)
 * =============================================================================
 *QuickReview/Subtopics: try, catch, finally, throw (throw; throw new Exception difference), Use TryParse or null-checks to avoid the high performance cost of throwing.
 *finally{}//has no method param, exception filter for catch block , use when (condition) 
 *ex.Message, ex.StackTrace,ex.Source  CustomException: Exception
 *  In C#, exceptions are handled using try-catch-finally. try contains risky code, catch handles errors, and finally is always executed for cleanup. throw; preserves the original stack trace, while throw new Exception creates a new one. For performance, TryParse is preferred over exceptions for validation. We can also use exception filters using ‘when’ for conditional catching. Custom exceptions help define domain-specific errors.
 * StackOverflowException--infinite loop, NullReferenceException-Happens when try to access the data/method/property of Object 
 *
 * 1) Core Keywords: try, catch, finally, throw
 * - try: Marks a code block for error monitoring.
 * - catch: Handles specific exception types. Multiple blocks allowed; order matters.
 * - finally: Executes regardless of success/failure (cleanup logic). //guaranteed to execute even if there is a return, break, or continue statement inside the try or catch blocks.
 * - throw: **Explicitly** triggers an exception instance.
 *
 * 2) Exception Propagation: throw vs. throw ex
 * - throw;: Re-throws the original exception. **Preserves the Stack Trace**.  //in the stacktrace it shows the line number where exception happened 
 * - throw ex;: Re-throws as if originated from this line. **Wipes the original Stack Trace**.  //it shows current line
 * - ExceptionDispatchInfo.Capture(ex).Throw(): Advanced re-throw that preserves stack across threads.
 *
 * 3) Catch Filters and Ordering
 * - Specificity: Always catch derived exceptions (e.g., FileNotFound) before base (e.g., Exception).
 * - when (filter): Syntax: catch (Exception ex) when (condition). Executes before the stack unwinds,
 * allowing state inspection without side effects.
 *
 * 4) CLR Mechanics: The Two-Pass Model
 * - Pass 1: Searches for a matching handler (executes 'when' filters).
 * - Pass 2: Unwinds the stack and executes 'finally' blocks up to the handler.
 *
 * 5) Common System Exceptions
 * - NullReferenceException: Accessing members of a null object.
 * - IndexOutOfRangeException: (Not ArrayOutOfBounds!) Array index is invalid.
 * - ArgumentNullException / ArgumentOutOfRangeException: Guard clause failures.
 * - InvalidOperationException: Object state is incompatible with the method call.
 * - StackOverflowException / OutOfMemoryException: Generally unrecoverable; process terminates.
 *
 * 6) Best Practices
 * - Tester-Doer Pattern: Use TryParse or null-checks to avoid the high performance cost of throwing.  
 * - Inner Exceptions: When wrapping, pass the original exception to the constructor: new MyEx("msg", ex).
 * - Fail-Fast: Do not catch exceptions you cannot meaningfully recover from.
 * =============================================================================
 */

public static class ExceptionHandlingTheory
{
    public static void RunAllDemos()
    {
        BasicTryCatch_Section();
        RethrowPatterns_Section();
        ExceptionFilters_Section();
        CustomException_Section();
    }

    #region Basic Try-Catch-Finally

    public static void BasicTryCatch_Section()
    {
        try
        {
            int divisor = 0;
            int result = 10 / divisor;
        }
        catch (DivideByZeroException ex)
        {
            // Catching specific exception
            Console.WriteLine($"Specific Catch: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Catching general base exception (Always put last)
            Console.WriteLine($"General Catch: {ex.Message}");
        }
        finally
        {
            // Ideal for IDisposable or closing resources
            Console.WriteLine("Finally block: Cleanup executed.");
        }
    }

    #endregion

    #region Throw vs Rethrow

    public static void RethrowPatterns_Section()
    {
        try
        {
            MethodThatFails();
        }
        catch (Exception ex)
        {
            // Print stack trace to see preservation
            Console.WriteLine($"Captured Stack Trace:\n{ex.StackTrace}");   //It does not rethrow, Shows The exact line where MethodThatFails() threw the error 
        }
    }

    private static void MethodThatFails()
    {
        try
        {
            throw new InvalidOperationException("Initial Error");  
        }
        catch (Exception)
        {
            // throw;      // CORRECT: Preserves "Initial Error" source line
            // throw ex;   // INCORRECT: Resets source line to here
            throw;  //passes the error in try , does nothing
        }
    }

    #endregion

    #region Exception Filters (when)

    public static void ExceptionFilters_Section()
    {
        int statusCode = 500;

        try
        {
            throw new Exception("Server Error");
        }
        catch (Exception ex) when (statusCode == 500)
        {
            // This catch only runs if the 'when' condition is true
            Console.WriteLine($"Filtered Catch: {ex.Message} with code 500");
        }
    }

    #endregion

    #region Custom Exceptions

    /*
     * Custom exceptions should inherit from System.Exception.
     * Convention: Always end class name with "Exception".
     */
    public class DomainServiceException : Exception
    {
        public int ErrorCode { get; }

        public DomainServiceException(string message, int code) : base(message)
        {
            ErrorCode = code;
        }

        public DomainServiceException(string message, Exception inner, int code)
            : base(message, inner)
        {
            ErrorCode = code;
        }
    }

    public static void CustomException_Section()
    {
        try
        {
            throw new DomainServiceException("Custom Error", 404);
        }
        catch (DomainServiceException ex)
        {
            Console.WriteLine($"Handled {ex.GetType().Name}. Code: {ex.ErrorCode}");
        }
    }

    #endregion
}