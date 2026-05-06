namespace ConsoleApp1.CSharpPractise.ShortTopics;

/*
 * =============================================================================
 * Null-coalescing operators (`??`, `??=`)
 * =============================================================================
 *
 * Provides a fallback value when the left side is null, or assigns only if the
 * left-hand side is null (for ??=).
 *
 * Examples:
 *
 *   string name = input ?? "Guest";
 *   name ??= "Default";
 *
 * Notes:
 * - ??  — if left operand is non-null, use it; otherwise use the right operand.
 * - ??= — assign the right side only when the left-hand target is null (C# 8+).
 * =============================================================================
 */

/*
 * =============================================================================
 * Difference between nullable (`T?`) and null-conditional operator (`?.`)
 * =============================================================================
 *
 * Nullable (`T?`)
 * - Allows value types to store null (Nullable<T> shorthand).
 * - Used when a value type is optional or missing (int, bool, DateTime, etc.).
 *
 * Example:
 *
 *   int? age = null;
 *
 * Null-conditional (`?.`)
 * - Safely accesses members when the receiver might be null; entire chain short-circuits.
 * - Avoids NullReferenceException when probing members.
 *
 * Example:
 *
 *   string? name = null;
 *   int? length = name?.Length;
 *
 * Key difference (quick intuition)
 * - T?  → makes a value type nullable (or annotated reference can use nullable context).
 * - ?.  → makes member access safe when the instance might be null.
 *
 * Note: With nullable reference types enabled, `string?` means the reference may be null;
 * `?.` is about safe navigation, not about boxing value types into Nullable<>.
 * =============================================================================
 */

public static class ShortTheories
{
}
