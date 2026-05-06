using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.CSharpPractise.Advanced;

/*
 * =============================================================================
 * Multithreading in C# / .NET — interview notes (read with the code below)
 * =============================================================================
 * QuickReview/Subtopics: Process, Thread, Asynchronus vs Multithreading, ThreadPool, Task, async/await, locks, race condition, deadlock 
 * Monitor, Mutex, SemaphoreSlim, Interlocked, volatile, cancellation, exception
 * handling, concurrent collections, Parallel APIs, thread-local state, deadlocks.

 Worker thread → doing its job
Main thread → stuck at Join()
Once worker finishes → main thread resumes
 *
 * 1) Processes and threads
 *    - A process is an isolated running program with its own virtual memory.
 *    - A thread is a unit of execution inside a process. Threads in the same process
 *      share heap/static data, but each thread has its own stack.
 *    - Interview line: sharing memory makes communication easy but creates race conditions.
 *
 * 2) Concurrency vs parallelism vs asynchronous programming
 *    - Concurrency: multiple tasks are in progress during the same time period.
 *    - Parallelism: multiple tasks literally execute at the same time on different cores.
 *    - Async: non-blocking style, usually for I/O. It may use zero extra threads while waiting.
 *    - Multithreading: using multiple threads. Can be used for parallel CPU work or background work.
 *
 * 3) System.Threading.Thread
 *    - new Thread(...).Start() creates a dedicated OS thread.
 *    - Join() blocks the caller until the thread finishes.
 *    - Sleep() blocks the current thread; it does not "await".
 *    - Foreground threads keep the process alive; background threads do not.
 *    - Use Thread rarely: long-lived dedicated workers, special priority/apartment cases.
 *
 * 4) ThreadPool
 *    - .NET keeps a pool of reusable worker threads to avoid constantly creating threads.
 *    - ThreadPool.QueueUserWorkItem and Task.Run schedule work on the pool.
 *    - Avoid long blocking work on pool threads; starvation can happen when all pool threads block.
 *
 * 5) Task and Task<TResult>
 *    - Task represents work that may complete in the future. Task<TResult> returns a result.
 *    - Task.Run is useful for CPU-bound work that should run on the ThreadPool.
 *    - Task.WhenAll waits for all tasks; Task.WhenAny waits for the first completed task.
 *    - Task.Wait / .Result block and wrap exceptions in AggregateException.
 *    - await unwraps exceptions naturally and keeps the code non-blocking.
 *
 * 6) async / await
 *    - async methods compile to state machines.
 *    - await yields control until the awaited operation completes; the waiting thread is not blocked.
 *    - Best for I/O-bound work: HTTP calls, database calls, file/network operations.
 *    - "Async all the way": avoid mixing async code with .Result or .Wait().
 *    - ConfigureAwait(false) is common in library code to avoid resuming on a captured context.
 *
 * 7) Race condition and critical section
 *    - Race condition: result depends on unpredictable timing between threads.
 *    - Critical section: code that accesses shared mutable state and must be protected.
 *    - i++ is not atomic; it is read + add + write.
 *
 * 8) lock and Monitor
 *    - lock(obj) is syntax sugar over Monitor.Enter/Exit in a try/finally.
 *    - Lock on a private readonly object, not this, typeof(T), or string literals.
 *    - Keep lock sections small; do not do slow I/O or await inside lock.
 *    - Monitor.TryEnter can use a timeout instead of waiting forever.
 *
 * 9) Mutex, Semaphore, SemaphoreSlim
 *    - Mutex: cross-process or same-process mutual exclusion, heavier than lock.
 *    - Semaphore/SemaphoreSlim: allow N concurrent callers, not just one.
 *    - SemaphoreSlim is common for async-friendly throttling with WaitAsync.
 *
 * 10) Interlocked
 *     - Atomic operations such as Increment, Add, Exchange, CompareExchange.
 *     - Great for simple counters/flags without lock overhead.
 *     - CompareExchange is a building block for lock-free algorithms.
 *
 * 11) volatile and memory visibility
 *     - volatile prevents certain compiler/CPU reorderings and forces direct field reads/writes.
 *     - It does not make compound operations atomic. volatile int x; x++ is still not safe.
 *     - Prefer lock, Interlocked, CancellationToken, or higher-level primitives when possible.
 *
 * 12) CancellationToken
 *     - Cancellation is cooperative: one side requests, the worker observes and stops cleanly.
 *     - Pass tokens to APIs that accept them; call ThrowIfCancellationRequested in loops.
 *     - OperationCanceledException is normal for canceled work.
 *
 * 13) Exceptions in threads/tasks
 *     - Exceptions on raw Thread do not flow back to the creator automatically.
 *     - Exceptions in Task are stored in the task; await rethrows the original exception.
 *     - Task.Wait / Result throws AggregateException.
 *     - Task.WhenAll with await throws; inspect individual tasks to see all failures.
 *
 * 14) Concurrent collections
 *     - System.Collections.Concurrent gives thread-safe collections:
 *       ConcurrentDictionary, ConcurrentQueue, ConcurrentStack, ConcurrentBag,
 *       BlockingCollection.
 *     - Use these instead of locking List<T>/Dictionary<TKey,TValue> manually when they fit.
 *
 * 15) Parallel APIs and PLINQ
 *     - Parallel.For / Parallel.ForEach split CPU-bound work across cores.
 *     - PLINQ: source.AsParallel() for parallel LINQ queries.
 *     - Not always faster: overhead, ordering, shared state, and small data sets can hurt.
 *
 * 16) Thread-local and async-local state
 *     - ThreadLocal<T>: separate value per physical thread.
 *     - AsyncLocal<T>: value flows through async calls, useful for correlation IDs/request context.
 *
 * 17) Deadlocks and common pitfalls
 *     - Deadlock: two or more operations wait forever for each other.
 *     - Classic cause: inconsistent lock ordering.
 *     - Async deadlock: blocking on .Result/.Wait() while a captured context is needed to resume.
 *     - ThreadPool starvation: blocking many pool threads while queued work needs pool threads.
 *
 * 18) Choosing the right tool
 *     - CPU-bound background work: Task.Run / Parallel APIs.
 *     - I/O-bound work: async/await without Task.Run.
 *     - Shared state: lock or concurrent collections.
 *     - Simple numeric state: Interlocked.
 *     - Throttling: SemaphoreSlim.
 *     - Cancellation: CancellationToken.
 *
 * =============================================================================
 */

//Interview Quick revision Notes for Multithreading

/// <summary>Runnable samples + notes in the file header for multithreading interviews.</summary>
public static class MultithreadingTheory
{
    public static void RunAllDemos()
    {
        ThreadBasics_Section();
        ThreadPool_Section();
        TaskBasics_Section();
        AsyncAwait_Section().GetAwaiter().GetResult();
        RaceConditionAndLock_Section();
        MonitorTryEnter_Section();
        Interlocked_Section();
        SemaphoreSlim_Section().GetAwaiter().GetResult();
        CancellationToken_Section().GetAwaiter().GetResult();
        TaskException_Section().GetAwaiter().GetResult();
        ConcurrentCollections_Section();
        ParallelApis_Section();
        ThreadLocalAndAsyncLocal_Section().GetAwaiter().GetResult();
        VolatileConcept_Section();
    }

    // Keeps compatibility with older notes or entry points that may call RunAll().
    public static void RunAll() => RunAllDemos();

    #region Thread basics

    /*
     * Section: raw Thread — dedicated OS thread, Start, Join, foreground/background.
     */
    public static void ThreadBasics_Section()
    {
        var worker = new Thread(static () =>
        {
            Thread.Sleep(10); // blocks only this worker thread
        })
        {
            Name = "InterviewDemoWorker",
            IsBackground = true
        };

        worker.Start();
        worker.Join(); // caller waits until worker is done
    }

    #endregion

    #region ThreadPool

    /*
     * Section: ThreadPool — reusable worker threads; Task.Run uses it underneath.
     */
    public static void ThreadPool_Section()
    {
        using var completed = new ManualResetEventSlim();

        ThreadPool.QueueUserWorkItem(static state =>
        {
            var signal = (ManualResetEventSlim)state!;
            signal.Set();
        }, completed);

        completed.Wait();
    }

    #endregion

    #region Task basics

    /*
     * Section: Task — represents future work; await is preferred over blocking Result/Wait.
     */
    public static void TaskBasics_Section()
    {
        Task<int> cpuTask = Task.Run(static () =>
        {
            var sum = 0;
            for (var i = 1; i <= 100; i++)
            {
                sum += i;
            }

            return sum;
        });

        int result = cpuTask.GetAwaiter().GetResult(); // demo-only sync bridge
        _ = result; // 5050
    }

    public static async Task TaskCombinators_Section()
    {
        Task<int> one = Task.FromResult(1);
        Task<int> two = Task.FromResult(2);

        int[] results = await Task.WhenAll(one, two);
        Task<int> firstFinished = await Task.WhenAny(one, two);

        _ = results.Sum(); // 3
        _ = await firstFinished;
    }

    #endregion

    #region async and await

    /*
     * Section: async/await — non-blocking wait; ideal for I/O-bound operations.
     */
    public static async Task AsyncAwait_Section()
    {
        string data = await FakeIoCallAsync().ConfigureAwait(false);
        _ = data.Length;
    }

    private static async Task<string> FakeIoCallAsync()
    {
        await Task.Delay(10).ConfigureAwait(false);
        return "data from async operation";
    }

    #endregion

    #region Race condition and lock

    private static readonly object s_counterLock = new();
    private static int s_counter;

    /*
     * Section: race condition — protect shared mutable state with lock.
     */
    public static void RaceConditionAndLock_Section()
    {
        s_counter = 0;

        Task[] workers = Enumerable.Range(0, 4)
            .Select(_ => Task.Run(static () =>
            {
                for (var i = 0; i < 1_000; i++)
                {
                    lock (s_counterLock)
                    {
                        s_counter++;
                    }
                }
            }))
            .ToArray();

        Task.WaitAll(workers);
        _ = s_counter; // expected 4000
    }

    #endregion

    #region Monitor.TryEnter

    /*
     * Section: Monitor.TryEnter — lock attempt with timeout; always Exit in finally if taken.
     */
    public static void MonitorTryEnter_Section()
    {
        object gate = new();
        var lockTaken = false;

        try
        {
            Monitor.TryEnter(gate, TimeSpan.FromMilliseconds(10), ref lockTaken);
            if (lockTaken)
            {
                _ = "critical section";
            }
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(gate);
            }
        }
    }

    #endregion

    #region Interlocked

    /*
     * Section: Interlocked — atomic operations for simple shared values.
     */
    public static void Interlocked_Section()
    {
        var total = 0;

        Parallel.For(0, 1_000, _ =>
        {
            Interlocked.Increment(ref total);
        });

        int original = 0;
        int previous = Interlocked.CompareExchange(ref original, value: 10, comparand: 0);

        _ = total; // 1000
        _ = previous; // 0 means exchange succeeded
        _ = original; // 10
    }

    #endregion

    #region SemaphoreSlim

    private static readonly SemaphoreSlim s_twoAtATime = new(initialCount: 2, maxCount: 2);

    /*
     * Section: SemaphoreSlim — async-friendly throttling; permits limited concurrency.
     */
    public static async Task SemaphoreSlim_Section()
    {
        Task[] calls = Enumerable.Range(1, 5)
            .Select(CallLimitedResourceAsync)
            .ToArray();

        await Task.WhenAll(calls).ConfigureAwait(false);
    }

    private static async Task CallLimitedResourceAsync(int id)
    {
        await s_twoAtATime.WaitAsync().ConfigureAwait(false);
        try
        {
            await Task.Delay(5).ConfigureAwait(false);
            _ = id;
        }
        finally
        {
            s_twoAtATime.Release();
        }
    }

    #endregion

    #region CancellationToken

    /*
     * Section: CancellationToken — cooperative cancellation, not Thread.Abort.
     */
    public static async Task CancellationToken_Section()
    {
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromMilliseconds(10));

        try
        {
            await CountUntilCanceledAsync(cts.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            // expected in demo
        }
    }

    private static async Task CountUntilCanceledAsync(CancellationToken cancellationToken)
    {
        var count = 0;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            count++;
            await Task.Delay(5, cancellationToken).ConfigureAwait(false);
        }
    }

    #endregion

    #region Task exceptions

    /*
     * Section: await unwraps task exceptions; Wait/Result wrap them in AggregateException.
     */
    public static async Task TaskException_Section()
    {
        try
        {
            await Task.Run(static () => throw new InvalidOperationException("demo"))
                .ConfigureAwait(false);
        }
        catch (InvalidOperationException)
        {
            // await rethrows the original exception type
        }

        Task faulted = Task.Run(static () => throw new InvalidOperationException("demo"));
        try
        {
            faulted.Wait();
        }
        catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
        {
            // Wait/Result wrap task failures
        }
    }

    #endregion

    #region Concurrent collections

    /*
     * Section: concurrent collections — thread-safe containers for common producer/consumer cases.
     */
    public static void ConcurrentCollections_Section()
    {
        var counts = new ConcurrentDictionary<string, int>();

        Parallel.ForEach(new[] { "C#", "SQL", "C#", "Azure" }, topic =>
        {
            counts.AddOrUpdate(topic, addValue: 1, updateValueFactory: (_, old) => old + 1);
        });

        var queue = new ConcurrentQueue<int>();
        queue.Enqueue(10);
        bool removed = queue.TryDequeue(out int item);

        _ = counts["C#"]; // 2
        _ = removed;
        _ = item;
    }

    #endregion

    #region Parallel APIs

    /*
     * Section: Parallel.For / PLINQ — CPU-bound parallelism; avoid shared mutable state.
     */
    public static void ParallelApis_Section()
    {
        int[] numbers = Enumerable.Range(1, 100).ToArray();
        var squares = new int[numbers.Length];

        Parallel.For(0, numbers.Length, i =>
        {
            squares[i] = numbers[i] * numbers[i];
        });

        int evenSquareSum = numbers
            .AsParallel()
            .Where(n => n % 2 == 0)
            .Select(n => n * n)
            .Sum();

        _ = squares[0];
        _ = evenSquareSum;
    }

    #endregion

    #region ThreadLocal and AsyncLocal

    private static readonly AsyncLocal<string?> s_correlationId = new();

    /*
     * Section: ThreadLocal is per physical thread; AsyncLocal flows through async calls.
     */
    public static async Task ThreadLocalAndAsyncLocal_Section()
    {
        using var perThreadCounter = new ThreadLocal<int>(() => 0);

        Parallel.For(0, 10, _ =>
        {
            perThreadCounter.Value++;
        });

        s_correlationId.Value = "request-123";
        await Task.Delay(1).ConfigureAwait(false);
        _ = s_correlationId.Value; // still request-123 in this async flow
    }

    #endregion

    #region volatile concept

    private static volatile bool s_stopRequested;

    /*
     * Section: volatile — visibility for simple flags; not a replacement for atomicity.
     */
    public static void VolatileConcept_Section()
    {
        s_stopRequested = false;

        var worker = new Thread(static () =>
        {
            while (!s_stopRequested)
            {
                Thread.Sleep(1);
            }
        });

        worker.Start();
        s_stopRequested = true;
        worker.Join();

        // Interview trap: volatile makes this flag visible, but it would not make counter++ atomic.
    }

    #endregion
}
