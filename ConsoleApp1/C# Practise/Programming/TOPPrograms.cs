using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.C__Practise.Programming
{
    internal class TOPPrograms
    {
        // 1. Numbers, Parsing & Overflow
        public static void ConvertVeryLargeNumericString() { }
        public static void AddTwoLargeNumberStrings() { }
        public static void ParseIntSafely() {
        

            string number=Console.ReadLine();
            int num;


            if (int.TryParse(number, out num))
            {
                Console.WriteLine(num);
            }

            else {
                Console.WriteLine("Please enter proper number string"+ number);
            }
        
        }
        public static void ReverseInteger() {
            int number;
            int.TryParse(Console.ReadLine(), out number);
            int rem, rev, final=0;
            if (number > 0)
            {
                while (number > 0)
                {
                    rem = number % 10;


                    final = final * 10 + rem;


                    number /= 10;

                }
                Console.WriteLine(final);
            }
            else
            {
                number *= -1;
                while (number > 0)
                {
                    rem = number % 10;


                    final = final * 10 + rem;


                    number /= 10;

                }
                Console.WriteLine(-final);
            }
            
           

        }
        public static void IsIntegerPalindrome() { }
        public static void DivideWithoutMultiplyOrDivide() { }
        public static void IntegerPow() { }
        public static void DetectIntegerOverflowOnAdd() { }
        public static void DecimalToDoublePrecisionLoss() { }
        public static void CurrencyRounding() { }

        // 2. Strings
        public static void ReverseStringManually() { }
        public static void IsStringPalindrome() { }
        public static void CountCharacterOccurrences() { }
        public static void FirstNonRepeatingCharacter() { }
        public static void AreAnagrams() { }
        public static void CustomStringTrim() { }
        public static void HasBalancedParentheses() { }
        public static void CompressString() { }
        public static void LongestCommonSubstringOrPrefix() { }
        public static void SplitOnMultipleDelimiters() { }

        // 3. Arrays & Collections
        public static void FindDuplicatesInArray() { }
        public static void FindMissingNumber() { }
        public static void RotateArray() { }
        public static void SecondLargestWithoutSorting() { }
        public static void MergeSortedArrays() { }
        public static void ArrayIntersection() { }
        public static void FlattenJaggedArray() { }
        public static void FindPairsThatSumToTarget() { }
        public static void ImplementStackAndQueue() { }
        public static void MaxSubarraySumKadane() { }

        // 4. LINQ
        public static void GroupEmployeesByDepartmentAverageSalary() { }
        public static void AggregateRunningTotalAndReverseString() { }
        public static void FindDuplicateObjectsWithComparer() { }
        public static void GroupByToDictionary() { }
        public static void FirstVsSingleDemo() { }
        public static void SelectManyFlatten() { }
        public static void DeferredExecutionDemo() { }
        public static void PaginateEnumerable() { }
        public static void JoinAndGroupJoinDemo() { }
        public static void IEnumerableVsIQueryableDemo() { }

        // 5. OOP & C# Language Fundamentals
        public static void OverrideVsNew() { }
        public static void AbstractClassVsInterface() { }
        public static void BoxingUnboxing() { }
        public static void StructVsClass() { }
        public static void IComparableAndIEquatable() { }
        public static void ConstVsReadonly() { }
        public static void ExtensionMethodDemo() { }
        public static void DeepCopyVsShallowCopy() { }
        public static void SealedClassesAndMethods() { }
        public static void OperatorOverloading() { }

        // 6. Exception Handling
        public static void NestedTryCatchFinally() { }
        public static void CustomExceptionClass() { }
        public static void ThrowVsThrowEx() { }
        public static void ExceptionInUsingBlock() { }
        public static void ExceptionFilters() { }
        public static void MultipleExceptionCatchOrdering() { }
        public static void AsyncVoidVsAsyncTaskException() { }
        public static void RetryWithExponentialBackoff() { }

        // 7. Delegates, Events & Functional C#
        public static void CustomDelegateVsFuncAction() { }
        public static void EventPublisherSubscriber() { }
        public static void MulticastDelegates() { }
        public static void ClosuresLoopCapture() { }
        public static void ObservableObserver() { }
        public static void LambdaCapturingDisposable() { }
        public static void Memoization() { }

        // 8. Async / Await & Threading
        public static void TaskRunVsAsyncMethod() { }
        public static void DeadlockWithResultAndConfigureAwait() { }
        public static void ParallelWhenAllAggregateException() { }
        public static void RaceConditionAndFix() { }
        public static void TaskVsThread() { }
        public static void ProducerConsumer() { }
        public static void AwaitInLoopVsWhenAll() { }
        public static void AsyncTimeoutWithCancellation() { }
        public static void AsyncVoidVsTask() { }
        public static void ExceptionWrappingAsync() { }

        // 9. Memory, GC & Performance
        public static void IDisposablePattern() { }
        public static void StaticEventMemoryLeak() { }
        public static void StringBuilderVsConcatenation() { }
        public static void ValueTypeVsReferenceTypeAllocation() { }
        public static void SpanOrMemoryUsage() { }
        public static void GenerationalGcDemo() { }

        // 10. Design Patterns & Architecture
        public static void ThreadSafeSingleton() { }
        public static void RepositoryPattern() { }
        public static void FactoryPattern() { }
        public static void StrategyPattern() { }
        public static void ManualDependencyInjection() { }
        public static void SolidPrinciples() { }

        // 11. Entity Framework Core & SQL
        public static void EfNPlusOneAndInclude() { }
        public static void EagerLazyExplicitLoading() { }
        public static void OptimisticConcurrency() { }
        public static void AsNoTrackingDemo() { }
        public static void RawSqlWithEfCore() { }
        public static void MigrationNonNullableColumn() { }
        public static void InVsExistsJoin() { }
        public static void NullHandlingCSharpAndSql() { }

        // 12. Reflection, Attributes & Misc
        public static void ReflectionListProperties() { }
        public static void CustomAttributeReflection() { }
        public static void GenericMethodWithConstraints() { }
        public static void IsAsPatternMatchingVsCast() { }
        public static void DeepEqualityAndDictionaryKey() { }

        // 13. Collections Deep Dive — Dictionary, HashSet & More
        public static void DictionaryLookupMissingKey() { }
        public static void ModifyDictionaryDuringIteration() { }
        public static void HashSetRemoveDuplicates() { }
        public static void CustomEqualityComparer() { }
        public static void DictionaryEnumerationOrder() { }
        public static void SortedDictionaryVsSortedList() { }
        public static void LruCache() { }
        public static void ConcurrentDictionaryThreadSafety() { }
        public static void BinarySearchRequiresSorted() { }
        public static void ListContainsVsHashSetContains() { }
        public static void MutableDictionaryKey() { }
        public static void CustomEnumerableWithYield() { }
        public static void ListVsIListVsICollectionVsIEnumerable() { }
        public static void ListCapacityVsCount() { }
        public static void ReadOnlyCollectionMutation() { }
        public static void ImmutableCollections() { }
        public static void PriorityQueue() { }
        public static void QueueStackPeekOnEmpty() { }
        public static void ArraySortMultiField() { }
        public static void ValueTupleVsKeyValuePairVsClass() { }
    }
}
