using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1.CSharpPractise.DataStructures.Collections
{
    public class ConcurrentCollections
    {
        public void RunDemos()
        {
            Console.WriteLine("========== CONCURRENT COLLECTIONS DEMOS ==========\n");
            ShowConcurrentQueue();
            Console.WriteLine();
            ShowConcurrentStack();
            Console.WriteLine();
            ShowConcurrentBag();
            Console.WriteLine();
            ShowConcurrentDictionary();
            Console.WriteLine();
            ShowBlockingCollection();
            Console.WriteLine();
            ShowParallelProducerConsumer();
            Console.WriteLine("========== END ==========");
        }

        #region
        /*
         ### 🧠 C# CONCURRENT COLLECTIONS – INTERVIEW NOTES

    ### 🟢 1. WHAT ARE THEY?
    👉 Types in **`System.Collections.Concurrent`** are **thread-safe** collections meant for **high concurrency**: multiple threads can **add and remove** without external locks in typical patterns.
    👉 They use **fine-grained locking**, **lock-free** techniques, or **per-partition** structures internally—**not** simply wrapping **`lock`** around **`List<T>`**.
    👉 **Semantics differ** from non-concurrent types: for example **`ConcurrentDictionary`** indexer **get** can throw if the key is absent (like **`Dictionary`**) but **set** is atomic; prefer **`TryGetValue`**, **`GetOrAdd`**, **`AddOrUpdate`**.

    ### 🟢 2. `ConcurrentQueue<T>` — FIFO
    | Member | Purpose |
    | :--- | :--- |
    | **`Enqueue`** | Add to tail (thread-safe). |
    | **`TryDequeue`** | Remove from head; returns **`false`** if empty. |
    | **`TryPeek`** | Read head without removing. |
    | **`Count`** | Approximate during contention; treat as **hint** for hot loops. |
    | **`IsEmpty`** | Often useful for spin-wait patterns (still coordinate with **`TryDequeue`**). |

    **Complexity:** **`Enqueue`** / **`TryDequeue`** are **amortized** $O(1)$ under typical load.

    ### 🟢 3. `ConcurrentStack<T>` — LIFO
    | Member | Purpose |
    | :--- | :--- |
    | **`Push`** | Add on top. |
    | **`TryPop`** / **`TryPeek`** | Pop or peek; **`false`** if empty. |

    Same idea as **`Stack<T>`**, but safe for concurrent **push/pop** without a global lock on every operation.

    ### 🟢 4. `ConcurrentBag<T>` — unordered bag
    | Member | Purpose |
    | :--- | :--- |
    | **`Add`** | Insert (thread-affine staging; **no global order**). |
    | **`TryTake`** | Removes **some** element; **which** one is **undefined** (not FIFO/LIFO globally). |

    **Use when:** work-stealing style pools, **any** item is fine, order does not matter. **Avoid** when you need **fair** or **predictable** ordering—use **`ConcurrentQueue`**.

    ### 🟢 5. `ConcurrentDictionary<TKey, TValue>` — concurrent map
    | Member | Purpose |
    | :--- | :--- |
    | **`TryAdd` / `TryRemove` / `TryGetValue`** | Non-throwing, atomic where documented. |
    | **`GetOrAdd`** | Adds factory value if key missing (factory may run **more than once** under races). |
    | **`AddOrUpdate`** | Add or update with delegates (subtle race semantics—read docs for your overload). |
    | **`TryUpdate`** | CAS-style update if current value matches expected. |

    **Indexer:** get throws if missing; set adds or overwrites—still prefer **`Try*`** in hot paths.

    ### 🟢 6. `BlockingCollection<T>` — producer / consumer
    👉 **Buffer** with optional **bounded** capacity; **`Add`** can **block** when full, **`Take`** blocks when empty.
    👉 **`CompleteAdding()`** signals **no more items**; **`Take`** / enumeration can end gracefully.
    👉 Backing store is often **`ConcurrentQueue`** or **`ConcurrentStack`** via constructor.

    ### 🟢 7. QUICK CHOICE GUIDE (1-MINUTE)
    ✔ **FIFO + many producers/consumers →** **`ConcurrentQueue<T>`**  
    ✔ **LIFO →** **`ConcurrentStack<T>`**  
    ✔ **Order irrelevant, local work stealing →** **`ConcurrentBag<T>`**  
    ✔ **Shared key/value cache, counters →** **`ConcurrentDictionary<TKey, TValue>`**  
    ✔ **Back-pressure, blocking wait →** **`BlockingCollection<T>`** or **`Channels`** (modern alternative)

    ### 🎯 FINAL INTERVIEW LINE
    > ".NET concurrent collections are lock-scalable structures for multi-threaded add/remove: queues and stacks for ordered handoffs, bags for unordered work, concurrent dictionaries for atomic map updates, and BlockingCollection for blocking producer-consumer pipelines—always read API docs for races on factories in GetOrAdd/AddOrUpdate."

        */
        #endregion

        public void ShowConcurrentQueue()
        {
            Console.WriteLine("--- ConcurrentQueue<T> ---");
            var q = new ConcurrentQueue<string>();
            q.Enqueue("Krishna");
            q.Enqueue("Hari");
            q.Enqueue("Sri Rama");
            Console.WriteLine("TryPeek: " + (q.TryPeek(out var head) ? head : "<empty>"));
            while (q.TryDequeue(out var item))
                Console.WriteLine("  Dequeue: " + item);
            Console.WriteLine("After drain, TryDequeue: " + q.TryDequeue(out _));
        }

        public void ShowConcurrentStack()
        {
            Console.WriteLine("--- ConcurrentStack<T> ---");
            var s = new ConcurrentStack<string>();
            s.Push("A");
            s.Push("B");
            s.Push("C");
            Console.WriteLine("TryPeek: " + (s.TryPeek(out var top) ? top : "<empty>"));
            while (s.TryPop(out var item))
                Console.WriteLine("  Pop: " + item);
        }

        public void ShowConcurrentBag()
        {
            Console.WriteLine("--- ConcurrentBag<T> ---");
            var bag = new ConcurrentBag<string>();
            bag.Add("Anu");
            bag.Add("Ravi");
            bag.Add("X");
            Console.WriteLine("Count (hint): " + bag.Count);
            var taken = new List<string>();
            while (bag.TryTake(out var x))
                taken.Add(x);
            Console.WriteLine("TryTake order (undefined): " + string.Join(", ", taken));
        }

        public void ShowConcurrentDictionary()
        {
            Console.WriteLine("--- ConcurrentDictionary<TKey, TValue> ---");
            var map = new ConcurrentDictionary<int, string>();

            Console.WriteLine("TryAdd 1: " + map.TryAdd(1, "FirstUser"));
            Console.WriteLine("TryAdd 1 again: " + map.TryAdd(1, "Duplicate"));

            map[2] = "Hari";
            map[3] = "Krishna";

            string fromGetOrAdd = map.GetOrAdd(4, k => "Generated-" + k);
            Console.WriteLine("GetOrAdd 4: " + fromGetOrAdd);

            string updated = map.AddOrUpdate(2, "NewHari", (k, old) => old + "+");
            Console.WriteLine("AddOrUpdate 2: " + updated);

            if (map.TryGetValue(3, out var v))
                Console.WriteLine("TryGetValue 3: " + v);

            if (map.TryRemove(1, out var removed))
                Console.WriteLine("TryRemove 1: " + removed);

            Console.WriteLine("TryUpdate 3 (expect Krishna): " +
                map.TryUpdate(3, "KrishnaUpdated", "Krishna"));

            foreach (var kv in map)
                Console.WriteLine($"  {kv.Key} -> {kv.Value}");
        }

        public void ShowBlockingCollection()
        {
            Console.WriteLine("--- BlockingCollection<T> (bounded 2) ---");
            var bc = new BlockingCollection<int>(boundedCapacity: 2);
            bc.Add(10);
            bc.Add(20);
            Console.WriteLine("Take: " + bc.Take());
            bc.Add(30);
            Console.WriteLine("Take: " + bc.Take());
            bc.CompleteAdding();
            while (bc.TryTake(out var x, millisecondsTimeout: 0))
                Console.WriteLine("TryTake remainder: " + x);
        }

        public void ShowParallelProducerConsumer()
        {
            Console.WriteLine("--- Parallel producers -> ConcurrentQueue -> drain ---");
            var q = new ConcurrentQueue<int>();
            Parallel.For(0, 50, i => q.Enqueue(i));
            var list = new List<int>();
            while (q.TryDequeue(out var n))
                list.Add(n);
            list.Sort();
            long sum = 0;
            foreach (var x in list)
                sum += x;
            Console.WriteLine("Dequeued count: " + list.Count + " (expect 50), sum: " + sum);
        }
    }
}
