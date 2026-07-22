using ConsoleApp1.C__Practise.Entry;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.Linq;
using static ConsoleApp1.C__Practise.OOPs_Concepts.TypeCastingOopTheory;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.CSharpPractise.DataStructures.Collections
{
    internal class Collections
    {

        #region C# COLLECTIONS — COMPLETE OVERVIEW NOTES
        /*
                     C# COLLECTIONS HIERARCHY
                     (Top -> Bottom Interface Flow + Major Families)

        TYPES OF COLLECTIONS IN C#
        ─────────────────────────
        1. Generic collections — List<T>, Dictionary<K,V>, HashSet<T>, Queue<T>, Stack<T>.
        2. Non-generic / legacy collections — ArrayList, Hashtable, Queue, Stack, BitArray.
        3. Thread-safe / concurrent collections — ConcurrentDictionary<K,V>, ConcurrentQueue<T>,
           ConcurrentStack<T>, ConcurrentBag<T>, BlockingCollection<T>.
        4. Immutable collections — ImmutableList<T>, ImmutableDictionary<K,V>,
           ImmutableHashSet<T>, ImmutableQueue<T>, ImmutableStack<T>.
        5. Frozen collections — FrozenDictionary<K,V>, FrozenSet<T> for build-once/read-many lookup.
        6. Read-only wrappers and interfaces — IReadOnlyList<T>, IReadOnlyDictionary<K,V>,
           ReadOnlyCollection<T>, ReadOnlyDictionary<K,V>.
        7. Object model / binding collections — Collection<T>, ObservableCollection<T>,
           KeyedCollection<TKey,TItem>, BindingList<T>.
        8. Specialized collections — StringCollection, StringDictionary, NameValueCollection,
           OrderedDictionary, HybridDictionary, ListDictionary.
        9. Sorted collections — SortedList<K,V>, SortedDictionary<K,V>, SortedSet<T>.
        10. Collection-adjacent sequence/memory types — T[], ArraySegment<T>, Span<T>,
            ReadOnlySpan<T>, Memory<T>, ReadOnlyMemory<T>.

        =============================================================================
        ONE FLOWCHART — ALL COLLECTIONS (TOP → BOTTOM, EVERY NODE CONNECTED)
        =============================================================================
        Core Collection Interfaces:

                             IEnumerable
                                  |
                             IEnumerable<T>
                                  |
            ┌─────────────────────┴─────────────────────┐
            |                                           |
  IReadOnlyCollection<T>                          ICollection<T>
            |                                           |
  ┌─────────┴────────┐                     ┌────────────┴────────────┐
  |                  |                     |                         |
IReadOnlyList<T>  IReadOnlySet<T>       IList<T>                  ISet<T>
  |                  |                     |                         |
List<T>           HashSet<T>            List<T>                   HashSet<T>


Dictionary Interfaces:

                 IEnumerable<KeyValuePair<TKey,TValue>>
                                   |
            ┌──────────────────────┴──────────────────────┐
            |                                             |
ICollection<KeyValuePair<TKey,TValue>>    IReadOnlyCollection<KeyValuePair<TKey,TValue>>
            |                                             |
            |                                             |
IDictionary<TKey,TValue>                  IReadOnlyDictionary<TKey,TValue>
            |
Dictionary<TKey,TValue>


Concurrent Interfaces:

                             IEnumerable<T>
                                  |
                   IProducerConsumerCollection<T>
                                  |
            ┌─────────────────────┼─────────────────────┐
            |                     |                     |
    ConcurrentBag<T>      ConcurrentQueue<T>    ConcurrentStack<T>


Iterator Interfaces (Standalone Hierarchy):

        IEnumerator
             |
        IEnumerator<T> ─── (Inherits from) ─── IDisposable

        │ ▼ = implements / derives from parent above
        Concrete types sit under PRIMARY parent; many also implement read-only twins.

        FOREACH PAIR (parallel roots — collection vs cursor)
        ────────────────────────────────────────────────────
        IEnumerable / IEnumerable<T>  = "can be iterated"  (the collection)
        IEnumerator / IEnumerator<T>  = "the cursor"       (NOT a collection parent)

                    ┌─────────────────┐   GetEnumerator()   ┌─────────────────┐
                    │   IEnumerable   │ ───────────────────►│   IEnumerator   │
                    │  (collection)   │                     │ Current/MoveNext│
                    └────────┬────────┘                     │ /Reset          │
                             │                              └────────┬────────┘
                             │ inherits                              │ inherits
                             ▼                                       ▼
                    ┌─────────────────┐   GetEnumerator()   ┌─────────────────┐
                    │ IEnumerable<T>  │ ───────────────────►│ IEnumerator<T>  │
                    │  + LINQ source  │                     │ T Current       │
                    └────────┬────────┘                     │ + IDisposable   │
                             │                              └─────────────────┘
                             │
        foreach expands to: GetEnumerator() → while (MoveNext()) use Current → Dispose()

                              ┌─────────────────┐
                              │   IEnumerable   │  ROOT of collection tree
                              └────────┬────────┘
                                       │
              ┌────────────────────────┼────────────────────────┐
              ▼                        ▼                        ▼
     ┌────────────────┐       ┌────────────────┐       ┌──────────────────────────────┐
     │ IEnumerable<T> │       │  ICollection   │       │ IProducerConsumerCollection  │
     │ generic + LINQ │       │  (non-generic) │       │ <T>  (also : IEnumerable<T>  │
     └───────┬────────┘       └───────┬────────┘       │  + ICollection non-generic)  │
             │                        │                └──────────────┬───────────────┘
             │                        │                               │
   ┌─────────┴──────────┐             │              ┌────────────────┼────────────────┐
   ▼                    ▼             │              ▼                ▼                ▼
┌──────────────┐ ┌────────────────────┐│    ┌────────────────┐┌────────────────┐┌────────────────┐
│ICollection<T>│ │IReadOnlyCollection ││    │ConcurrentQueue ││ConcurrentStack ││ConcurrentBag  │
│ mutate+Count │ │       <T>          ││    │     <T> FIFO   ││     <T> LIFO   ││ <T> unordered  │
└──────┬───────┘ └─────────┬──────────┘│    └───────┬────────┘└────────────────┘└────────────────┘
       │                   │           │            │ wraps default ConcurrentQueue
       │                   │           │            ▼
       │                   │           │    ┌──────────────────────────┐
       │                   │           │    │ BlockingCollection<T>    │
       │                   │           │    └──────────────────────────┘
       │                   │           │
       │                   │           │   NON-GENERIC ICollection branch
       │                   │           ├───────────────┬────────────────┐
       │                   │           ▼               ▼                ▼
       │                   │    ┌──────────┐   ┌────────────┐   ┌────────────────┐
       │                   │    │  IList   │   │IDictionary │   │ Queue (legacy) │
       │                   │    └────┬─────┘   └─────┬──────┘   │ Stack (legacy) │
       │                   │         │               │          │ BitArray       │
       │                   │         ▼               ▼          │ ReadOnlyColl.  │
       │                   │  ┌────────────┐  ┌──────────────┐  │     Base       │
       │                   │  │ ArrayList  │  │ Hashtable    │  └────────────────┘
       │                   │  │Collection  │  │ SortedList   │
       │                   │  │    Base    │  │DictionaryBase│
       │                   │  │StringColl. │  │OrderedDict.  │
       │                   │  └────────────┘  │ListDictionary│
       │                   │                  │HybridDict.   │
       │                   │                  │StringDict.   │
       │                   │                  │NameObjectColl│──► NameValueCollection
       │                   │                  │    Base      │
       │                   │                  └──────────────┘
       │                   │
       │      ┌────────────┼────────────┬──────────────────┐
       │      ▼            ▼            ▼                  ▼
       │ ┌──────────┐┌──────────┐┌──────────────┐┌─────────────────────────────┐
       │ │IReadOnly ││IReadOnly ││IReadOnlyDict ││ Queue<T>  FIFO              │
       │ │ List<T>  ││ Set<T>   ││   <K,V>      ││ Stack<T>  LIFO              │
       │ └──────────┘└──────────┘└──────────────┘│ PriorityQueue<T,P>  heap    │
       │  (List/T[]/… also) (HashSet/…) (Dict/…) │ ImmutableQueue<T>           │
       │                                         │ ImmutableStack<T>           │
       │                                         └─────────────────────────────┘
       │
 ┌─────┴──────────┬──────────────┬──────────────────┐
 ▼                ▼              ▼                  ▼
┌──────────┐ ┌──────────┐ ┌────────────────┐ ┌────────────────┐
│ IList<T> │ │ ISet<T>  │ │IDictionary<K,V>│ │ LinkedList<T>  │
└────┬─────┘ └────┬─────┘ └───────┬────────┘ │ (+ LinkedList  │
     │            │               │          │   Node<T>)     │
     ▼            ▼               ▼          └────────────────┘

┌─────────────────────────┐ ┌──────────────────┐ ┌────────────────────────────┐
│ List<T>                 │ │ HashSet<T>       │ │ Dictionary<K,V>            │
│ T[]                     │ │ SortedSet<T>     │ │ SortedDictionary<K,V>      │
│ ArraySegment<T>         │ │ ImmutableHashSet │ │ SortedList<K,V>            │
│ Collection<T> ──┐       │ │ ImmutableSorted  │ │ ConcurrentDictionary<K,V>  │
│   ├─ObservableColl<T>   │ │   Set<T>         │ │ ReadOnlyDictionary<K,V>    │
│   └─KeyedCollection<K,T>│ │ FrozenSet<T>     │ │ ImmutableDictionary<K,V>   │
│ BindingList<T>          │ └──────────────────┘ │ ImmutableSortedDictionary  │
│ ReadOnlyCollection<T>   │                      │ FrozenDictionary<K,V>      │
│ ImmutableList<T>        │                      └────────────────────────────┘
│ ImmutableArray<T>       │
└─────────────────────────┘

  PARENT CHEATSHEET (climb arrows to IEnumerable)
  ───────────────────────────────────────────────
  Queue<T>/Stack<T>       → IReadOnlyCollection<T> → IEnumerable<T> → IEnumerable
                            (+ ICollection non-generic; NOT ICollection<T>)
  LinkedList<T>           → ICollection<T> → IEnumerable<T> → IEnumerable
  List<T> / T[]           → IList<T> → ICollection<T> → IEnumerable<T> → IEnumerable
  HashSet<T>              → ISet<T> → ICollection<T> → IEnumerable<T> → IEnumerable
  Dictionary<K,V>         → IDictionary<K,V> → ICollection<KVP> → IEnumerable → …
  ConcurrentQueue<T>      → IProducerConsumerCollection<T> → IEnumerable<T> → IEnumerable
  ConcurrentDictionary    → IDictionary<K,V> → … (same map branch)
  ObservableCollection<T> → Collection<T> → IList<T> → …
  Queue/Stack (legacy)    → ICollection → IEnumerable
  Hashtable               → IDictionary → ICollection → IEnumerable

  Outside tree: Channel<T>, ArrayPool<T>, Span<T>/Memory<T>; prefer Concurrent*
  over ArrayList.Synchronized / Hashtable.Synchronized.

        =============================================================================
        COLLECTION-ADJACENT SEQUENCE TYPES (outside main interface tree)
        =============================================================================

        T[] — in tree above under IList<T> / IReadOnlyList<T>.
        ArraySegment<T> — view over array; list-like in modern .NET.
        Span<T> / ReadOnlySpan<T> — stack-only views; NOT IEnumerable<T>.
        Memory<T> / ReadOnlyMemory<T> — heap-safe views for async/pipelines.
        Enumerable / Lookup / Grouping — LINQ result shapes.

        Sorted     — SortedDictionary, SortedSet, SortedList (+ IComparer<T>).
        Concurrent — ConcurrentDictionary, ConcurrentQueue/Stack/Bag.
        Immutable  — ImmutableList/Dictionary/HashSet/Queue/Stack (+ Builder).
        Frozen     — FrozenDictionary / FrozenSet (.NET 8+, build-once read-many).
        Priority   — PriorityQueue<T,P> (.NET 6+); no Concurrent/Immutable twin in BCL.

        -----------------------------------------------------------------------------
           * 9. CHOOSING A TYPE (DECISION CHEATSHEET)
           * -----------------------------------------------------------------------------
           *
           * Ordered list, index access, unknown final size           → List<T>
           * Many inserts/removes with stable node references         → LinkedList<T>
           * Associative map, fastest key lookup, unsorted OK         → Dictionary<,>
           * Map sorted by key, frequent add/remove, large n          → SortedDictionary<,>
           * Map sorted by key, small n, memory tight, rank index     → SortedList<,>
           * Unique membership, no ordering requirement               → HashSet<T>
           * Unique elements, sorted iteration, min/max/ranges        → SortedSet<T>
           * Fair first-in-first-out processing                       → Queue<T> / ConcurrentQueue<T>
           * Undo / depth-first / nested structure (last wins)        → Stack<T> / ConcurrentStack<T>
           * Schedule by priority (Dijkstra, task queues)             → PriorityQueue<,>
           * Many producers/consumers, shared map                     → ConcurrentDictionary<,>
           * Ordered items + UI must react to changes                 → ObservableCollection<T>
           * Expose sequence without exposing Add                     → ReadOnlyCollection<T> or IReadOnlyList<T>
           * Keys derived from items, list order + key lookup         → KeyedCollection<TKey,TItem>
           * Build once, millions of reads, known key set             → FrozenDictionary / FrozenSet (.NET 8+)
           *
           * -----------------------------------------------------------------------------
           * 10. COMPLEXITY SUMMARY (BIG-O; AVERAGE CASE FOR HASH TYPES)
           * -----------------------------------------------------------------------------
           *
           * Type                    Index   Add/end   Add/mid   Contains   Remove
           * ----------------------  ------  --------  --------  ---------  -------------
           * List<T>                 O(1)    O(1)*     O(n)      O(n)       O(n)
           * LinkedList<T>           —       O(1)      O(1)+     O(n)       O(1)+ / O(n)*
           * Dictionary<,>           —       O(1)~     —         O(1)~ key  O(1)~ key
           * SortedDictionary<,>    —       O(log n)  —         O(log n)   O(log n)
           * SortedList<,>          O(1)    O(n)      O(n)      O(log n)k  O(n)
           * HashSet<T>             —       O(1)~     —         O(1)~      O(1)~
           * SortedSet<T>           —       O(log n)  —         O(log n)   O(log n)
           * Queue<T> / Stack<T>    —       O(1)*     —         O(n)       O(1) at end
           * PriorityQueue<,>      —       O(log n)  —         O(n) scan  O(log n)
           *
           * Legend: * amortized (array resize rare but O(n) when it happens).
           *         k ContainsKey / IndexOfKey on SortedList is O(log n).
           *         + LinkedList: O(1) with known node; find node by value O(n).
           *         ~ hash types: O(n) worst case if all keys collide (bad hash / attack);
           *           good GetHashCode + Equals keeps average O(1).

           * =============================================================================
           * C# / .NET COLLECTIONS — FULL REFERENCE (READ ME FIRST)
           * =============================================================================
           *
           * HOW TO USE THIS REGION
           * -----------------------------------------------------------------------------
           * Skim TAKEAWAY, then SECTIONS INDEX, then NAMESPACES. Use numbered sections as a
           * textbook: interfaces (contracts), then concrete types (behavior + complexity), then
           * threading, LINQ, equality, capacity. Deep per-type demos and interview-style notes live
           * in GenericCollections; thread-safe demos in ConcurrentCollections.
           *
           * TAKEAWAY — QUICK REVISION
           * -----------------------------------------------------------------------------
           * • Prefer System.Collections.Generic concrete types for new code:
           *   List<T>, LinkedList<T>, Dictionary<TKey,TValue>, SortedDictionary<TKey,TValue>,
           *   SortedList<TKey,TValue>, HashSet<T>, SortedSet<T>, Queue<T>, Stack<T>,
           *   PriorityQueue<TElement,TPriority> (.NET 6+).
           * • Avoid non-generic ArrayList, Hashtable, Queue, Stack, SortedList (non-generic):
           *   elements are object (reference types OK; value types box on insert, unbox on
           *   read), no compile-time type checking, easy runtime InvalidCastException.
           * • IEnumerable<T>: foreach + LINQ (extensions on IEnumerable<T>, not on the
           *   interface itself). ICollection<T>: Count + Add, Remove, Clear, Contains, CopyTo.
           *   IList<T>: adds int indexer, Insert, RemoveAt (random access by position).
           * • Dictionary: O(1) average by key; SortedDictionary / SortedList: keys sorted;
           *   HashSet / SortedSet: unique elements only (no separate value per key).
           * • Queue FIFO; Stack LIFO; PriorityQueue: next item by best priority (default
           *   min-heap on TPriority). None of these three expose an int indexer.
           * • Never mutate a collection while enumerating it with foreach on that same
           *   instance (InvalidOperationException: collection was modified).
           * • Multiple threads writing List / Dictionary / HashSet without synchronization:
           *   undefined behavior or corruption. Use Concurrent*, locks, or immutable copies.
           * • IReadOnlyList<T> / IReadOnlyDictionary<,> / IReadOnlyCollection<T>: good API
           *   return types; they do not make the underlying object immutable by magic.
           * • Performance: EnsureCapacity / TrimExcess where available; LINQ often allocates
           *   (ToList, OrderBy, GroupBy materialize new objects).
           * • Hash-based types: IEqualityComparer<T> (Equals + GetHashCode contract).
           *   Sorted types: IComparer<T> (consistent ordering; bad comparer breaks trees).
           *
           * SECTIONS INDEX (topics in this Collections overview)
           * -----------------------------------------------------------------------------
           * • HOW TO USE THIS REGION — reading order; links to GenericCollections /
           *   ConcurrentCollections.
           * • TAKEAWAY — QUICK REVISION — one-screen essentials (above).
           * • NAMESPACES — WHERE THINGS LIVE — Generic, legacy Collections, Concurrent,
           *   ObjectModel, Specialized, Immutable, Frozen, LINQ.
           * • 1. WHY GENERICS — object/boxing vs List<T> / type safety.
           * • 2. CORE INTERFACES — contracts, inheritance model, API design, full member
           *   lists (IEnumerable through IReadOnlySet).
           * • 3. ARRAYS, SPAN, MEMORY — T[], covariance, stackalloc, Span/Memory vs List<T>.
           * • 4. List<T> AND LinkedList<T> — dynamic array vs doubly-linked list.
           * • 5. Queue<T>, Stack<T>, PriorityQueue<TElement,TPriority> — FIFO/LIFO/heap.
           * • 6. MAPS — Dictionary, SortedDictionary, SortedList (key -> value).
           * • 7. SETS — HashSet<T>, SortedSet<T> (unique elements).
           * • 8. OBJECTMODEL, SPECIALIZED, CONCURRENT, IMMUTABLE, FROZEN — Collection<T>,
           *   ObservableCollection<T>, ReadOnlyCollection<T>, KeyedCollection<T>, BitArray,
           *   Concurrent*, BlockingCollection<T>, Immutable*, Frozen*.
           * • 9. CHOOSING A TYPE — decision cheatsheet (when to pick which type).
           * • 10. COMPLEXITY SUMMARY — Big-O table + legend.
           * • 11. ENUMERATION, foreach, AND SAFETY — versioning, Reset, struct enumerator.
           * • 12. LINQ AND IEnumerable<T> — deferred vs immediate; IQueryable note.
           * • 13. EQUALITY, ORDERING, AND KEYS — comparers, mutable-key hazard, records.
           * • 14. CAPACITY, MEMORY, AND GC — EnsureCapacity, TrimExcess, rehash, LOH.
           * • Outside this comment: GenericCollections (per-type demos + deep notes);
           *   ConcurrentCollections (thread-safe demos).
           *
           * NAMESPACES — WHERE THINGS LIVE
           * -----------------------------------------------------------------------------
           * System.Collections.Generic — primary generic collections (List, Dictionary, …).
           * System.Collections — legacy non-generic (IEnumerable, ArrayList, Hashtable, …).
           * System.Collections.Concurrent — thread-safe bags, queues, stacks, dictionary.
           * System.Collections.ObjectModel — Collection<T>, ObservableCollection<T>,
           *   ReadOnlyCollection<T>, KeyedCollection<TKey,TItem> (base / binding / keys).
           * System.Collections.Specialized — niche (StringCollection, ListDictionary, …).
           * System.Collections.Immutable — immutable lists, maps, sets (NuGet / ref pack).
           * System.Collections.Frozen — FrozenDictionary, FrozenSet (.NET 8+), build-once.
           * System.Linq — extension methods over IEnumerable<T> (not part of collections).
           *
           * -----------------------------------------------------------------------------
           * 1. WHY GENERICS (NOT object / NON-GENERIC COLLECTIONS)
           * -----------------------------------------------------------------------------
           *
           * Non-generic collections store reference type object. Inserting int into
           * ArrayList boxes the int (heap allocation). Reading back requires (int) cast or
           * invalid cast at runtime if the wrong type was stored. Generics compile to
           * type-specific code (reified generics in .NET): List<int> stores ints without
           * boxing in the backing array; the compiler rejects list.Add("text").
           *
           * When non-generic is still seen: COM interop, very old libraries, Hashtable in
           * some config-style APIs. For new application code, default to List<T>,
           * Dictionary<TKey,TValue>, HashSet<T>, etc.
           *
           * -----------------------------------------------------------------------------
           * 2. CORE INTERFACES (CONTRACTS YOUR CODE CAN DEPEND ON)
           * -----------------------------------------------------------------------------
           *
           * Interfaces declare members only (no default instance methods until explicit
           * interface patterns). Implementations (List<T>, Dictionary<,>, …) provide the
           * real behavior. Extension methods (LINQ in System.Linq) are static methods whose
           * first parameter is IEnumerable<T>; they are not members of IEnumerable<T>.
           *
           * Inheritance chain (mental model): IEnumerable<T> -> ICollection<T> -> IList<T>
           * or ICollection<T> -> ISet<T>. Maps: IEnumerable<KeyValuePair<,>> and
           * IDictionary<TKey,TValue> extend ICollection<KeyValuePair<TKey,TValue>>. Read-only
           * interfaces sit beside these: IReadOnlyCollection<T>, IReadOnlyList<T>,
           * IReadOnlyDictionary<,>, IReadOnlySet<T> — they do not inherit ICollection<T>.
           *
           * API design: accept IEnumerable<T> when you only need one pass (or streaming).
           * Accept IReadOnlyList<T> when callers must support Count + indexer without
           * mutation. Return IReadOnlyList<T> / IReadOnlyDictionary<,> from public APIs to
           * discourage external mutation; internally you may still hold a List<T> or
           * Dictionary<,> and cast or wrap.
           *
           * Member reference (BCL-declared only):
           *
           * --- IEnumerable (non-generic, System.Collections) ---
           *   IEnumerator GetEnumerator();
           * IEnumerator exposes: object Current { get; }, bool MoveNext(), void Reset()
           *   (Reset is legacy; prefer foreach / new enumerator instances.)
           *
           * --- IEnumerable<T> (extends IEnumerable) ---
           *   IEnumerator<T> GetEnumerator();
           * IEnumerator<T> exposes: T Current { get; } (also IDisposable)
           *
           * --- ICollection (non-generic) ---
           *   int Count { get; }
           *   bool IsSynchronized { get; }   object SyncRoot { get; }
           *   void CopyTo(Array array, int index);
           *
           * --- ICollection<T> (extends IEnumerable<T>) ---
           *   int Count { get; }             bool IsReadOnly { get; }
           *   void Add(T item);               void Clear();
           *   bool Contains(T item);         void CopyTo(T[] array, int arrayIndex);
           *   bool Remove(T item);
           *
           * --- IList (non-generic; extends ICollection, IEnumerable) ---
           *   object this[int index] { get; set; }
           *   bool IsFixedSize { get; }      bool IsReadOnly { get; }
           *   int Add(object value);         void Clear();                 bool Contains(object value);
           *   int IndexOf(object value);     void Insert(int index, object value);
           *   void Remove(object value);     void RemoveAt(int index);
           *
           * --- IList<T> (extends ICollection<T>, IEnumerable<T>) ---
           *   T this[int index] { get; set; }
           *   int IndexOf(T item);           void Insert(int index, T item);
           *   void RemoveAt(int index);
           *   (Also inherits ICollection<T>: Add, Clear, Contains, CopyTo, Remove, Count…)
           *
           * --- ISet<T> (extends ICollection<T>, IEnumerable<T>) ---
           *   bool Add(T item);   (returns false if duplicate — unlike ICollection<T>.Add)
           *   void UnionWith(IEnumerable<T> other);           void IntersectWith(IEnumerable<T> other);
           *   void ExceptWith(IEnumerable<T> other);          void SymmetricExceptWith(IEnumerable<T> other);
           *   bool IsSubsetOf(IEnumerable<T> other);          bool IsSupersetOf(IEnumerable<T> other);
           *   bool IsProperSubsetOf(IEnumerable<T> other);    bool IsProperSupersetOf(IEnumerable<T> other);
           *   bool Overlaps(IEnumerable<T> other);             bool SetEquals(IEnumerable<T> other);
           *
           * --- IDictionary (non-generic; extends ICollection, IEnumerable) ---
           *   object this[object key] { get; set; }     ICollection Keys { get; }   ICollection Values { get; }
           *   bool IsFixedSize { get; }                 bool IsReadOnly { get; }
           *   void Add(object key, object value);      void Clear();                bool Contains(object key);
           *   IDictionaryEnumerator GetEnumerator();   void Remove(object key);
           *
           * --- IDictionary<TKey,TValue> (extends ICollection<KeyValuePair<,>>, IEnumerable<…>) ---
           *   TValue this[TKey key] { get; set; }
           *   ICollection<TKey> Keys { get; }           ICollection<TValue> Values { get; }
           *   void Add(TKey key, TValue value);        bool ContainsKey(TKey key);
           *   bool Remove(TKey key);                   bool TryGetValue(TKey key, out TValue value);
           *   (Also ICollection<KeyValuePair<TKey,TValue>>: Add, Clear, Contains, CopyTo, Remove, Count…)
           *
           * --- IReadOnlyCollection<T> (extends IEnumerable<T>) ---
           *   int Count { get; }
           *
           * --- IReadOnlyList<T> (extends IReadOnlyCollection<T>, IEnumerable<T>) ---
           *   T this[int index] { get; }     (plus Count from IReadOnlyCollection<T>)
           *
           * --- IReadOnlyDictionary<TKey,TValue> (extends IReadOnlyCollection<KeyValuePair<,>>,
           *     IEnumerable<KeyValuePair<TKey,TValue>>) ---
           *   TValue this[TKey key] { get; }
           *   IEnumerable<TKey> Keys { get; }         IEnumerable<TValue> Values { get; }
           *   bool ContainsKey(TKey key);              bool TryGetValue(TKey key, out TValue value);
           *   (int Count from IReadOnlyCollection<KeyValuePair<TKey,TValue>>)
           *
           * --- IReadOnlySet<T> (.NET 5+; extends IReadOnlyCollection<T>, IEnumerable<T>) ---
           *   bool Contains(T item);
           *   bool IsSubsetOf(IEnumerable<T> other);              bool IsSupersetOf(IEnumerable<T> other);
           *   bool IsProperSubsetOf(IEnumerable<T> other);      bool IsProperSupersetOf(IEnumerable<T> other);
           *   bool Overlaps(IEnumerable<T> other);                bool SetEquals(IEnumerable<T> other);
           *   (plus Count from IReadOnlyCollection<T>)
           *
           * -----------------------------------------------------------------------------
           * 3. ARRAYS, SPAN, MEMORY (NOT List<T>, BUT COLLECTION-ADJACENT)
           * -----------------------------------------------------------------------------
           *
           * T[] — fixed size after allocation; contiguous memory; best cache locality;
           *   this[i] in O(1). Implements IList<T> (fixed size; some mutating IList APIs
           *   throw NotSupportedException on arrays — prefer array syntax). Covariant for
           *   reference types only (string[] assignable to object[], unsound if you write
           *   non-string into object[] slot — runtime ArrayTypeMismatchException).
           *
           * Choose array when: length known at creation and rarely changes; interop; stack
           * performance. Choose List<T> when: grow/shrink, AddRange, RemoveAll, Sort, …
           *
           * stackalloc T[n] — allocates on the stack (value types); wrapped as Span<T>;
           *   scoped lifetime (cannot return to heap as Span unless copied).
           *
           * Span<T> / ReadOnlySpan<T> — ref struct over contiguous memory (array slice,
           *   stackalloc, string chars); no heap allocation for the view; cannot be fields
           *   on async/iterator classes without care. Memory<T> / ReadOnlyMemory<T> for
           *   async pipelines and non-contiguous-safe holding (Pinning may be required).
           *
           * -----------------------------------------------------------------------------
           * 4. List<T> AND LinkedList<T>
           * -----------------------------------------------------------------------------
           *
           * List<T> — backing store is T[]; Count vs Capacity; Add at end amortized O(1);
           *   insert/remove at index shifts elements O(n); Sort, BinarySearch, RemoveAll,
           *   Find, FindIndex, TrueForAll, ForEach, ConvertAll, GetRange, InsertRange,
           *   RemoveRange, TrimExcess, EnsureCapacity (modern .NET). Default for ordered
           *   sequences with index access. Not thread-safe.
           *
           * LinkedList<T> — doubly-linked LinkedListNode<T> chain; AddFirst, AddLast,
           *   AddBefore, AddAfter with O(1) when you already have the node; Find / FindLast
           *   by value O(n); no this[int]; no Sort on the type (copy to List if needed).
           *   Good: LRU, frequent insert/remove between known nodes. Bad: cache misses vs
           *   array; arbitrary access by logical index requires walking O(n).
           *
           * -----------------------------------------------------------------------------
           * 5. Queue<T>, Stack<T>, PriorityQueue<TElement,TPriority>
           * -----------------------------------------------------------------------------
           *
           * Queue<T> — FIFO: Enqueue (tail), Dequeue / TryDequeue (head), Peek / TryPeek.
           *   foreach walks head-to-tail without dequeuing. Contains is O(n). Internal
           *   ring buffer; EnsureCapacity / TrimExcess on supported runtimes. Wrong tool if
           *   you need priority: use PriorityQueue. For multi-threaded FIFO use
           *   ConcurrentQueue<T>.
           *
           * Stack<T> — LIFO: Push, Pop / TryPop, Peek / TryPeek. foreach iterates top-down
           *   (newest first). ToArray returns top at index 0. ConcurrentStack<T> for
           *   parallel LIFO. Do not use List.RemoveAt(0) as a queue (O(n) per dequeue).
           *
           * PriorityQueue<TElement,TPriority> (.NET 6+) — binary min-heap by default
           *   (Comparer<TPriority>.Default). Enqueue, Dequeue / TryDequeue, Peek / TryPeek,
           *   EnqueueDequeue (bounded top-K pattern), EnqueueRange, UnorderedItems (heap
           *   layout, not dequeue order). Equal priorities: relative order unspecified;
           *   encode tie-breaker in TPriority (e.g. tuple (priority, sequence)). Max-heap:
           *   pass Comparer<TPriority>.Create((a,b) => b.CompareTo(a)).
           *
           * -----------------------------------------------------------------------------
           * 6. MAPS (KEY -> VALUE)
           * -----------------------------------------------------------------------------
           *
           * Dictionary<TKey,TValue> — hash buckets + entries; unique keys. Add throws if
           *   duplicate key; TryAdd returns false; indexer get throws if missing (prefer
           *   TryGetValue); indexer set adds or overwrites. ContainsKey O(1) average;
           *   ContainsValue scans all values O(n). Remove(key), Remove(key, out value).
           *   Enumeration: insertion order on current .NET for string-like usage — still
           *   treat as unordered for algorithm correctness. Custom IEqualityComparer<TKey>
           *   for case-insensitive string keys, structural equality, etc. Not thread-safe.
           *
           * SortedDictionary<TKey,TValue> — red-black tree sorted by key (IComparer<TKey>).
           *   Add / Remove / ContainsKey O(log n). Keys/Values enumerate in sorted order.
           *   Higher per-entry memory than SortedList; better when n grows and keys are
           *   inserted/deleted in random order. No O(1) index into "k-th smallest key"
           *   without walking (unlike SortedList's Keys[i]).
           *
           * SortedList<TKey,TValue> — two arrays (keys sorted, values aligned). IndexOfKey
           *   binary search O(log n); Add may shift O(n); good compact memory for small or
           *   read-heavy maps; Keys and Values implement IList<T> for rank-based access.
           *
           * -----------------------------------------------------------------------------
           * 7. SETS (UNIQUE ELEMENTS; NO VALUE BESIDE THE ELEMENT)
           * -----------------------------------------------------------------------------
           *
           * HashSet<T> — hash table of unique T; Add returns bool (false if duplicate).
           *   UnionWith / IntersectWith / ExceptWith / SymmetricExceptWith mutate this set.
           *   IsSubsetOf, IsSupersetOf, Overlaps, SetEquals for comparisons. TryGetValue
           *   returns canonical equal instance (useful with custom equality). Enumeration
           *   order unspecified. RemoveWhere(predicate) O(n).
           *
           * SortedSet<T> — red-black tree of unique T sorted by IComparer<T>. Min, Max,
           *   GetViewBetween(lower, upper) live sub-range. Same set algebra as HashSet.
           *   CopyTo writes in sorted order. Prefer HashSet when order irrelevant and you
           *   need raw speed; SortedSet when you need sorted enumeration or range queries.
           *
           * -----------------------------------------------------------------------------
           * 8. OBJECTMODEL, SPECIALIZED, CONCURRENT, IMMUTABLE, FROZEN
           * -----------------------------------------------------------------------------
           *
           * System.Collections.ObjectModel
           *   Collection<T> — base class wrapping IList<T>; override InsertItem, RemoveItem,
           *     ClearItems, SetItem to hook mutations (used for validated collections).
           *   ObservableCollection<T> — Collection<T> + INotifyCollectionChanged /
           *     INotifyPropertyChanged for UI binding (WPF, MAUI, WinUI).
           *   ReadOnlyCollection<T> — read-only wrapper over IList<T>; stops external
           *     writes via wrapper; underlying list can still be mutated if referenced.
           *   KeyedCollection<TKey,TItem> — abstract list-like collection keyed by TKey;
           *     override GetKeyForItem; O(1) key lookup dictionary + list order.
           *
           * BitArray (System.Collections) — dense vector of bool; bitwise And/Or/Xor/Not;
           *   different from bool[] for space and bit-twiddling APIs.
           *
           * System.Collections.Concurrent — lock-free or fine-grained structures:
           *   ConcurrentQueue<T>, ConcurrentStack<T>, ConcurrentBag<T> (unordered take),
           *   ConcurrentDictionary<TKey,TValue> (TryAdd, GetOrAdd, AddOrUpdate, TryUpdate).
           *   Count can be approximate under contention. See ConcurrentCollections demos.
           *
           * BlockingCollection<T> — optional bounded buffer; Add blocks when full, Take
           *   blocks when empty; CompleteAdding signals producers finished; wraps a
           *   concurrent collection (default ConcurrentQueue).
           *
           * System.Collections.Immutable — ImmutableArray<T>, ImmutableList<T>,
           *   ImmutableDictionary<,>, ImmutableHashSet<T>, …; builder pattern or factory
           *   methods; structural sharing for cheap snapshots; safe to share if no
           *   mutable builder escapes.
           *
           * System.Collections.Frozen (.NET 8+) — FrozenDictionary.ToFrozenDictionary,
           *   FrozenSet.ToFrozenSet; optimized read-only lookup after one-time build from
           *   mutable data; best for static configuration keys, not churny maps.
           *
           * 
           *
           * -----------------------------------------------------------------------------
           * 11. ENUMERATION, foreach, AND SAFETY
           * -----------------------------------------------------------------------------
           *
           * foreach compiles to GetEnumerator + MoveNext + Current + Dispose pattern.
           * Most BCL collections track a "version" stamp; structural change during active
           * enumeration throws InvalidOperationException. Safe patterns: snapshot with
           * ToArray / ToList / new List<T>(source), iterate indices on List and only remove
           * from high index to low, or use removal APIs that return next position.
           *
           * IEnumerator.Reset — implemented for completeness; many enumerators throw
           *   NotSupportedException on Reset. Do not depend on Reset; create a new
           *   enumerator or re-enter foreach.
           *
           * List<T>.Enumerator is a struct (value type enumerator) — avoids allocation in
           *   foreach over List<T> in typical cases. IEnumerable<T> as a parameter loses
           *   that optimization (boxing to interface).
           *
           * -----------------------------------------------------------------------------
           * 12. LINQ (System.Linq) AND IEnumerable<T>
           * -----------------------------------------------------------------------------
           *
           * Extension methods: Where, Select, SelectMany, OrderBy, GroupBy, Join, Take,
           *   Skip, Distinct, Any, All, First, Single, … Deferred execution: Where returns
           *   IEnumerable<T> that runs the predicate when the consumer enumerates.
           *   Immediate: ToList, ToArray, ToDictionary, ToHashSet, Count(), Max(), …
           *   allocate or fully consume the sequence.
           *
           * IQueryable<T> (System.Linq) — expression trees for remote providers (EF Core);
           *   not a collection storage type; different execution model from IEnumerable.
           *
           * Hot paths: repeated enumeration of deferred chains re-runs work; materialize
           *   once if you need multiple passes. Prefer for loops on List<T> over LINQ when
           *   profiling shows allocation or delegate overhead.
           *
           * -----------------------------------------------------------------------------
           * 13. EQUALITY, ORDERING, AND KEYS
           * -----------------------------------------------------------------------------
           *
           * IEqualityComparer<T>: bool Equals(T x, T y); int GetHashCode(T obj). Contract:
           *   if Equals(a,b) then GetHashCode(a)==GetHashCode(b); hash should distribute
           *   values across int. Used by Dictionary, HashSet, ConcurrentDictionary.
           *
           * Mutable objects as dictionary keys are dangerous: if a field used in Equals or
           *   GetHashCode changes after Add, lookups fail (entry stays in wrong bucket).
           *   Prefer string, int, Guid, immutable records, or readonly structs as keys.
           *
           * IComparer<T>: int Compare(T x, T y); defines strict weak ordering for SortedSet,
           *   SortedDictionary, SortedList, Array.Sort, OrderBy(comparer). If Compare
           *   inconsistent with Equals, structures and binary search misbehave.
           *
           * Records / value equality: default equality for records uses value semantics;
           *   still ensure stable hash if used as keys in long-lived maps.
           *
           * -----------------------------------------------------------------------------
           * 14. CAPACITY, MEMORY, AND GC
           * -----------------------------------------------------------------------------
           *
           * List<T>, Dictionary<,>, HashSet<T>, Queue<T>, Stack<T>, PriorityQueue<,> expose
           *   EnsureCapacity(int) and TrimExcess() on supported runtimes — grow internal
           *   buffers ahead of a large Add loop; shrink after a temporary spike if you keep
           *   the collection for a long time with few elements.
           *
           * Dictionary / HashSet load factor triggers rehash when growth occurs — pre-
           *   sizing avoids repeated rehashing when you know approximate final Count.
           *
           * Large object heap (LOH): very large arrays/lists may land on LOH; different GC
           *   behavior. For huge sequences consider chunking, streaming, or out-of-core.
           *
           * =============================================================================
           * END OF OVERVIEW — practice: GenericCollections (per-type demos + interview
           * notes); ConcurrentCollections (thread-safe types). Re-read TAKEAWAY before
           * interviews; use sections 9–10 for trade-off questions.
           * =============================================================================
           */

        #endregion

        public static void Main(string[] args)
        {
            var concurrent = new ConcurrentCollections();
            concurrent.RunDemos();

            // GenericCollections runcollections = new GenericCollections();
            // runcollections.ShowSortedSet();
        }

    }

    public class GenericCollections
    {

        #region
        /*
         ### 🧠 C# `List<T>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `List<T>`?
    👉 A **`List<T>`** is a dynamic, generic collection that stores elements of the same type.
    👉 It is essentially a **wrapper around an array** that automatically resizes itself when it runs out of space.
    👉 **Namespace:** `System.Collections.Generic`
    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **Dynamic Size:** Unlike arrays, you don't need to specify the size upfront. It grows as you add items.
    ✔ **Ordered:** It maintains the exact order in which elements are added.
    ✔ **Index-Based:** You can access any element instantly using an index (e.g., `myList[0]`).
    ✔ **Duplicates Allowed:** You can store the same value multiple times.
    ✔ **Type-Safe:** Because it is Generic (`<T>`), it prevents you from adding the wrong data type at compile time.
    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Returns the number of elements actually in the list. | $O(1)$ |
    | **`Capacity`** | The total number of elements the internal array can hold before resizing. | $O(1)$ |
    | **`Add(item)`** | Adds an item to the **end** of the list. | $O(1)$* |
    | **`Insert(index, item)`** | Adds an item at a specific position (shifts others). | $O(n)$ |
    | **`Remove(item)`** | Finds and removes the first occurrence of an item. | $O(n)$ |
    | **`RemoveAt(index)`** | Removes the item at the specified index. | $O(n)$ |
    | **`Contains(item)`** | Checks if an item exists in the list. | $O(n)$ |
    | **`Sort()`** | Reorders the elements in ascending order. | $O(n \log n)$ |

    *\*Note: `Add` is $O(1)$ unless the capacity is full, in which case it becomes $O(n)$ while it copies the old array to a new, larger one.*

    ### 🟢 4. LIST SYNTAX EXAMPLES
    ```csharp
    // 1. Initialization
    List<string> names = new List<string> { "Bunty", "Sunil" };

    // 2. Adding & Inserting
    names.Add("Balaji");            // { "Bunty", "Sunil", "Balaji" }
    names.Insert(0, "FirstUser");   // { "FirstUser", "Bunty", "Sunil", "Balaji" }

    // 3. Accessing
    string user = names[1]; // "Bunty"

    // 4. Searching
    bool exists = names.Contains("Sunil"); // true

    // 5. Converting back to Array
    string[] arrayVersion = names.ToArray();

    ### 🟢 5. `Count` VS. `Capacity` (The "Expert" Knowledge)
    Interviewer: *"How does a List resize itself?"*
    * **Count:** How many items are **inside** right now.
    * **Capacity:** How many items the **container can hold**.
    * **The Process:** When `Count` exceeds `Capacity`, the List creates a **new internal array** (usually double the previous size) and copies all elements over.
    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ **`List<T>`** is the "Go-to" collection for 90% of C# tasks.
    ✔ Use it when you need an **ordered** list and don't know the final size.
    ✔ Fast for adding to the **end** ($O(1)$), slow for inserting in the **middle** ($O(n)$).
    ✔ Implements `IList<T>`, `ICollection<T>`, and `IEnumerable<T>`.

    ### 🎯 FINAL INTERVIEW LINE
    > "A `List<T>` is a dynamic array implementation in C# that provides the convenience of automatic resizing while maintaining the high performance of index-based access. It is type-safe, allows duplicates, and is highly optimized for adding elements to the end of the collection."
         */
        #endregion
        public void ShowList()
        {   //Initialize
            // 1) Initialization
            List<string> names = new List<string>() { "Krishna", "Hari" };


            // 2) Add / Insert
            names.Add("Sri Rama");                    // add single
            names.Insert(0, "FirstUser");             // insert at index

            // 3) AddRange / InsertRange
            var more = new List<string> { "Anu", "Ravi" };
            names.AddRange(more);                       // append collection
            names.InsertRange(2, new[] { "X", "Y" }); // insert collection at index

            // 4) Count / Capacity
            Console.WriteLine($"Count: {names.Count}");
            Console.WriteLine($"Capacity: {names.Capacity}");
            names.EnsureCapacity(50);                    // ensure internal array can hold 50 elements
            Console.WriteLine($"Capacity after EnsureCapacity(50): {names.Capacity}");
            names.TrimExcess();                          // reduce capacity to fit count

            // 5) Accessing elements
            Console.WriteLine($"Element at index 0: {names[0]}");
            for (int i = 0; i < names.Count; i++)
                Console.WriteLine($"[{i}] = {names[i]}");

            // 6) Searching / Finding(Only gives one element)
            Console.WriteLine("Contains Hari? " + names.Contains("Hari"));
            Console.WriteLine("IndexOf Sri Rama: " + names.IndexOf("Sri Rama"));
            Console.WriteLine("LastIndexOf Sri Rama: " + names.LastIndexOf("Sri Rama"));
            Console.WriteLine("Find starts with 'S': " + names.Find(s => s.StartsWith("S")));
            Console.WriteLine("FindLast starts with 'S': " + names.FindLast(s => s.StartsWith("S")));
            Console.WriteLine("FindIndex starts with 'S': " + names.FindIndex(s => s.StartsWith("S")));
            Console.WriteLine("FindLastIndex starts with 'S': " + names.FindLastIndex(s => s.StartsWith("S")));
            Console.WriteLine("Exists starts with 'H': " + names.Exists(s => s.StartsWith("H")));

            // 7) Remove operations
            names.Remove("FirstUser");                 // removes first occurrence
            if (names.Count > 2) names.RemoveAt(2);     // remove by index
            names.Add("Temp"); names.Add("Temp");
            names.RemoveAll(s => s == "Temp");        // remove matching predicate
            // names.RemoveRange(startIndex, count) is also available

            // 8) Sorting / Reversing / BinarySearch
            names.Sort();                                // ascending
            names.Reverse();                             // reverse order
            Console.WriteLine("BinarySearch for 'Hari': " + names.BinarySearch("Hari"));

            // 9) Conversion & Utility
            string[] arrayVersion = names.ToArray();
            names.ForEach(s => Console.WriteLine("ForEach: " + s));
            Console.WriteLine("All non-null? " + names.TrueForAll(s => s != null));

            // 9.a) Do NOT modify a collection while iterating with foreach - causes InvalidOperationException
            try
            {
                foreach (var item in names)
                {
                    // This will throw at runtime: "Collection was modified; enumeration operation may not execute."
                    names.Add("new"); // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Other helpers
            var upper = names.ConvertAll(s => s.ToUpper()); // projection
            var slice = names.GetRange(0, Math.Min(3, names.Count));
            Console.WriteLine("Slice: " + string.Join(", ", slice));
            var copied = new string[names.Count];
            names.CopyTo(copied, 0);
            Console.WriteLine("Copied length: " + copied.Length);




        }

        #region
        /*
         ### 🧠 C# `LinkedList<T>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `LinkedList<T>`?
    👉 A **`LinkedList<T>`** is a generic **doubly-linked list**: each element lives in a **`LinkedListNode<T>`** with **`Next`** and **`Previous`** links.
    👉 There is **no backing array** and **no integer indexer** (`list[0]` does not exist). You navigate via **`First`**, **`Last`**, and node references.
    👉 **Namespace:** `System.Collections.Generic`

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **Dynamic size:** Grows and shrinks as you add or remove nodes.
    ✔ **Ordered:** Preserves insertion order (sequence is defined by links, not indices).
    ✔ **Node-based:** Fast operations when you already hold the `LinkedListNode<T>`; searching for a value still walks the list.
    ✔ **Duplicates allowed:** Same value can appear in multiple nodes.
    ✔ **Type-safe:** Generic `<T>` enforces element type at compile time.
    ✔ **Doubly-linked:** You can traverse **forward** (`foreach` / `Next`) and **backward** (`Previous` from `Last`).

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of nodes in the list. | $O(1)$ |
    | **`First` / `Last`** | First or last node (`LinkedListNode<T>`), or `null` if empty. | $O(1)$ |
    | **`AddFirst(value)` / `AddLast(value)`** | Insert at head or tail. | $O(1)$ |
    | **`AddBefore(node, value)` / `AddAfter(node, value)`** | Insert relative to a **known** node. | $O(1)$ |
    | **`Find(value)` / `FindLast(value)`** | First or last node containing `value`. | $O(n)$ |
    | **`Contains(value)`** | Whether any node has that value. | $O(n)$ |
    | **`Remove(value)`** | Remove **first** node with that value. | $O(n)$* |
    | **`Remove(node)`** | Remove a specific node you already have. | $O(1)$ |
    | **`RemoveFirst()` / `RemoveLast()`** | Remove head or tail. | $O(1)$ |
    | **`Clear()`** | Remove all nodes. | $O(n)$ |
    | **`CopyTo(array, index)`** | Copy values into an array. | $O(n)$ |

    *\*Note: `Remove(value)` is $O(n)$ because the list must **find** the node first; `Remove(node)` is $O(1)$ when the node belongs to this list.*

    ### 🟢 4. LINKEDLIST SYNTAX EXAMPLES
    ```csharp
    // 1. Initialization (empty or from sequence)
    LinkedList<string> items = new LinkedList<string>();
    LinkedList<int> nums = new LinkedList<int>(new[] { 1, 2, 3 });

    // 2. Ends and relative insert
    items.AddLast("B");
    items.AddFirst("A");
    LinkedListNode<string> n = items.Find("B");
    items.AddBefore(n, "B0");
    items.AddAfter(n, "B2");

    // 3. Traverse forward / backward
    foreach (var v in items) { }
    for (var x = items.Last; x != null; x = x.Previous) { }

    // 4. Search
    bool ok = items.Contains("B");
    LinkedListNode<string> first = items.Find("B");
    LinkedListNode<string> last = items.FindLast("B");

    // 5. Remove
    items.Remove("B");           // first match by value
    items.Remove(first);         // O(1) if node is from this list
    items.RemoveFirst();
    items.RemoveLast();
    ```

    ### 🟢 5. `List<T>` VS. `LinkedList<T>` (The "Expert" Knowledge)
    Interviewer: *"When would you pick a linked list over a list?"*
    * **`List<T>`:** Contiguous array-backed storage; **random access** by index in $O(1)$; insert/remove in the **middle** is $O(n)$ due to shifting.
    * **`LinkedList<T>`:** **No index access**; insert/remove **at ends** or **next to a known node** in $O(1)$; **finding** a value or node by value is $O(n)$.
    * **`LinkedList<T>`** does **not** expose **`Capacity`**, **`Sort()`**, **`BinarySearch`**, or **`RemoveAll`** like `List<T>`—typical patterns use **nodes** you keep references to (for example LRU cache, work queues), or convert to another structure when you need sorting.

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ **`LinkedList<T>`** is a **doubly-linked** chain of **`LinkedListNode<T>`** instances.
    ✔ Use it when you need **frequent insert/remove at ends** or **relative to nodes** you already track—not for arbitrary index access.
    ✔ **`Find` / `FindLast` / `Contains` / `Remove(value)`** all scan the list: $O(n)$.
    ✔ Implements **`ICollection<T>`**, **`IEnumerable<T>`**, **`IReadOnlyCollection<T>`**—not **`IList<T>`** (no indexer).

    ### 🎯 FINAL INTERVIEW LINE
    > "`LinkedList<T>` is a doubly-linked list in C#: $O(1)$ insert and remove at the ends or adjacent to a known `LinkedListNode<T>`, but $O(n)$ search by value. It has no indexer or array-style capacity, so it complements `List<T>` when your algorithm is node-driven rather than index-driven."
        */
        #endregion
         /* REMEMBER POINTS(from your mistakes):
             * 1. Use?. (null-conditional) when a node / reference may be null — e.g.names.First?.Value, names.Last?.Value(empty LinkedList → First/Last is null).
             * 2. BinarySearch only works on ascending sorted order — Sort first, search, then Reverse if needed; never search after Reverse().
             * 3. LinkedList has no indexer — use First/Last and walk with.Next(forward) or.Previous(backward); first N nodes = .Next from head
             * 4.Start each node walk fresh from names.First or names.Last; use 0-based index when printing[0], [1], …
             * 5. No bulk append on LinkedList — loop a sequence and AddLast each item.
             * 6. Remove(node) is O(1) when you already hold the node; Remove(value) scans the list O(n).
             * 7. Do not modify during foreach — catch InvalidOperationException outside the loop.  */
        public void ShowLinkedList()
        {
            // 1) Initialization
            var names = new LinkedList<string>(new[] { "Krishna", "Hari" });

            // 2) AddFirst / AddLast (ends of the chain)
            names.AddLast("Sri Rama");
            names.AddFirst("FirstUser");

            // 3) "AddRange" — no AddRange on LinkedList<T>; append another sequence
            var more = new[] { "Anu", "Ravi" };
            foreach (var m in more)
                names.AddLast(m);
            // Insert multiple after a node: walk to position or use AddAfter in a loop
            var afterFirst = names.First;
            if (afterFirst != null)
            {
                names.AddAfter(afterFirst, "X");
                names.AddAfter(afterFirst.Next!, "Y"); // after X, still relative to known nodes
            }

            // 4) Count (no Capacity — not array-backed)
            Console.WriteLine($"Count: {names.Count}");

            // 5) Accessing elements (no list[i]; use First/Last and nodes)
            Console.WriteLine($"First: {names.First?.Value}, Last: {names.Last?.Value}");
            int idx = 0;
            for (var n = names.First; n != null; n = n.Next)
                Console.WriteLine($"[{idx++}] = {n.Value}");

            // 6) Searching (no IndexOf on LinkedList — use Find / FindLast)
            Console.WriteLine("Contains Hari? " + names.Contains("Hari"));
            var nodeSriRama = names.Find("Sri Rama");
            Console.WriteLine("Find Sri Rama: " + (nodeSriRama != null ? nodeSriRama.Value : "<null>"));
            LinkedListNode<string>? lastStartsWithS = null;
            for (var ln = names.Last; ln != null; ln = ln.Previous)
                if (ln.Value.StartsWith("S")) { lastStartsWithS = ln; break; }
            Console.WriteLine("FindLast starts with 'S': " + (lastStartsWithS != null ? lastStartsWithS.Value : "<null>"));

            // 7) Remove operations
            names.Remove("FirstUser"); // first occurrence by value, O(n)
            var nodeToDrop = names.Find("X");
            if (nodeToDrop != null)
                names.Remove(nodeToDrop); // O(1) when node is in this list
            names.AddLast("Temp");
            names.AddLast("Temp");
            while (names.Find("Temp") is { } t)
                names.Remove(t); // pattern similar to RemoveAll for one value
            // names.RemoveFirst(); names.RemoveLast(); — also available

            // 8) Sorting — LinkedList<T> has no Sort(); build a List if you need order
            var forSort = new List<string>(names);
            forSort.Sort();
            forSort.Reverse();
            Console.WriteLine("BinarySearch for 'Hari' (on List copy): " + forSort.BinarySearch("Hari"));

            // 9) Conversion & utility
            names.Clear();
            names.AddLast("Krishna");
            names.AddLast("Hari");
            names.AddLast("Sri Rama");
            var arrayVersion = new string[names.Count];
            names.CopyTo(arrayVersion, 0);
            foreach (var s in names)
                Console.WriteLine("foreach: " + s);
            bool allNonNull = true;
            foreach (var v in names)
                if (v == null) allNonNull = false;
            Console.WriteLine("All non-null? " + allNonNull);

            // 9.a) Do NOT modify the collection while iterating with foreach — InvalidOperationException
            try
            {
                foreach (var item in names)
                {
                    names.AddLast("new"); // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Other helpers — CopyTo already shown; clone to List for List-only APIs
            var upperList = new List<string>();
            foreach (var s in names)
                upperList.Add(s.ToUpper());
            Console.WriteLine("Upper copy: " + string.Join(", ", upperList));
            var slice = new List<string>();
            int si = 0;
            for (var sn = names.First; sn != null && si < Math.Min(3, names.Count); sn = sn.Next, si++)
                slice.Add(sn.Value);
            Console.WriteLine("Slice (first N): " + string.Join(", ", slice));
            var copied = new string[names.Count];
            names.CopyTo(copied, 0);
            Console.WriteLine("Copied length: " + copied.Length);

            var lastHari = names.FindLast("Hari");
            Console.WriteLine("FindLast 'Hari': " + (lastHari != null ? lastHari.Value : "<null>"));

            names.Clear();
            Console.WriteLine("Cleared. Count: " + names.Count);
        }

        #region
        /*
         ### 🧠 C# `SortedList<TKey, TValue>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `SortedList<TKey, TValue>`?
    👉 A **`SortedList<TKey, TValue>`** is a generic **key/value collection** that keeps **keys sorted** (ascending by default, or by a custom **`IComparer<TKey>`**).
    👉 Internally it uses **two parallel arrays** (keys and values): keys stay sorted, and each value lines up with its key at the **same index**.
    👉 **Namespace:** `System.Collections.Generic`
    👉 **Duplicate keys are not allowed:** adding an existing key throws **`ArgumentException`** (use the indexer or **`TryAdd`** to update safely where available).

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **Sorted by key:** Enumeration and **`Keys`** / **`Values`** are always in key order—there is **no separate `Sort()`** on the collection.
    ✔ **Index access:** You can read **`Keys[index]`** and **`Values[index]`** in $O(1)$ (random access by **position** in the sorted order).
    ✔ **Key lookup:** **`this[key]`**, **`ContainsKey`**, **`TryGetValue`**, **`IndexOfKey`** use **binary search**: $O(\log n)$.
    ✔ **Values need not be unique:** Only keys must be unique.
    ✔ **Memory vs. `SortedDictionary`:** Typically **more compact** for small/medium counts; inserts can shift arrays, so large, churny workloads often prefer **`SortedDictionary<TKey, TValue>`** (tree-based $O(\log n)$ inserts).

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of key/value pairs. | $O(1)$ |
    | **`Capacity`** | Size of the internal key/value arrays; can be set (not below `Count`). | $O(1)$ |
    | **`Add(key, value)`** | Inserts a pair; **fails** if key exists. | $O(n)$* |
    | **`this[key]` (setter)** | Adds key or **replaces** value if key exists. | $O(\log n)$ lookup + possible shift $O(n)$ |
    | **`TryAdd(key, value)`** | Adds only if key missing (returns `bool`). | $O(n)$* |
    | **`Remove(key)` / `RemoveAt(index)`** | Remove by key or by sorted index. | $O(n)$ (array compacting) |
    | **`ContainsKey(key)`** | Binary search on keys. | $O(\log n)$ |
    | **`ContainsValue(value)`** | Linear scan of values. | $O(n)$ |
    | **`IndexOfKey` / `IndexOfValue`** | Index in sorted order (value search linear). | $O(\log n)$ / $O(n)$ |
    | **`TryGetValue(key, out value)`** | Safe get by key. | $O(\log n)$ |
    | **`TrimExcess()`** | Shrinks capacity to fit `Count`. | $O(n)$ |
    | **`Keys` / `Values`** | `IList<TKey>` / `IList<TValue>` views (sorted by key). | — |

    *\*Note: Insert may resize arrays and shift elements; treat worst-case add as $O(n)$. For frequent inserts/removes at scale, compare with **`SortedDictionary<TKey, TValue>`**.*

    ### 🟢 4. SORTEDLIST SYNTAX EXAMPLES
    ```csharp
    SortedList<string, int> scores = new SortedList<string, int>
    {
        { "Ann", 90 },
        { "Bob", 85 }
    };
    scores.Add("Cam", 88);
    scores["Ann"] = 95;
    bool ok = scores.TryGetValue("Bob", out int v);
    scores.Remove("Cam");
    foreach (KeyValuePair<string, int> kv in scores) { }
    ```

    ### 🟢 5. `Dictionary` VS. `SortedList` VS. `SortedDictionary` (Expert)
    Interviewer: *"When do you use a sorted key collection?"*
    * **`Dictionary<TKey, TValue>`:** Unordered, $O(1)$ average get/add; **no** sorted iteration.
    * **`SortedList<TKey, TValue>`:** **Sorted keys**, **compact** array storage; good when **count is modest** and you want **index + binary search**; adds/removes can be $O(n)$ due to shifting.
    * **`SortedDictionary<TKey, TValue>`:** **Balanced tree**; $O(\log n)$ add/remove/get; **more overhead per item**, better when the structure changes often and stays large.

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ **Keys unique**, sorted; **values** follow key order at matching indices.
    ✔ **`ContainsKey`** is $O(\log n)$; **`ContainsValue`** is $O(n)$.
    ✔ Implements **`IDictionary<TKey, TValue>`**, **`IReadOnlyDictionary<TKey, TValue>`**, and exposes sorted **`Keys`** / **`Values`** as lists.
    ✔ Do **not** modify while enumerating—same **`InvalidOperationException`** rule as other mutable collections.

    ### 🎯 FINAL INTERVIEW LINE
    > "`SortedList<TKey, TValue>` is a sorted dictionary backed by parallel key and value arrays: fast binary search by key and $O(1)$ access by sorted index, with $O(n)$ cost for inserts and deletes due to keeping keys contiguous and sorted—useful when ordering matters and the collection stays relatively small or mostly read-heavy."
        */
        #endregion
        public void ShowSortedList()
        {
            // 1) Initialization
            var idToName = new SortedList<int, string>
            {
                { 2, "Hari" },
                { 5, "Krishna" }
            };

            // 2) Add / indexer (indexer replaces value if key exists)
            idToName.Add(3, "Sri Rama");
            idToName[1] = "FirstUser";
            try
            {
                idToName.Add(2, "DuplicateKey");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Add duplicate key: " + ex.Message);
            }
            idToName[2] = "HariUpdated";

            // 3) "AddRange" — no AddRange; loop Add or initialize from dictionary
            foreach (var kv in new Dictionary<int, string> { { 4, "Anu" }, { 6, "Ravi" } })
                idToName.TryAdd(kv.Key, kv.Value);

            // 4) Count / Capacity
            Console.WriteLine($"Count: {idToName.Count}");
            Console.WriteLine($"Capacity: {idToName.Capacity}");
            idToName.Capacity = Math.Max(idToName.Capacity, 16);
            Console.WriteLine($"Capacity after bump: {idToName.Capacity}");
            idToName.TrimExcess();

            // 5) Accessing by key and by sorted index
            Console.WriteLine($"By key 3: {idToName[3]}");
            Console.WriteLine($"Keys[0]={idToName.Keys[0]}, Values[0]={idToName.Values[0]}");
            for (int i = 0; i < idToName.Count; i++)
                Console.WriteLine($"[{i}] {idToName.Keys[i]} -> {idToName.Values[i]}");

            // 6) Searching
            Console.WriteLine("ContainsKey 5? " + idToName.ContainsKey(5));
            Console.WriteLine("ContainsValue HariUpdated? " + idToName.ContainsValue("HariUpdated"));
            Console.WriteLine("IndexOfKey 4: " + idToName.IndexOfKey(4));
            Console.WriteLine("IndexOfValue Anu: " + idToName.IndexOfValue("Anu"));
            Console.WriteLine("TryGetValue 6: " + (idToName.TryGetValue(6, out var nm) ? nm : "<missing>"));
            int firstIdx = -1;
            for (int i = 0; i < idToName.Count; i++)
                if (idToName.Values[i].StartsWith("S")) { firstIdx = i; break; }
            Console.WriteLine("First index where value starts with 'S': " + firstIdx);

            // 7) Remove operations
            idToName.Remove(1);
            if (idToName.Count > 2)
                idToName.RemoveAt(2);
            idToName[99] = "Temp";
            idToName[100] = "Temp";
            for (int k = 99; k <= 100; k++)
                idToName.Remove(k);

            // 8) Ordering — keys stay sorted automatically (no Sort API on the collection)
            Console.WriteLine("Keys in order: " + string.Join(", ", idToName.Keys));

            // 9) Conversion and utility
            var keysArray = new int[idToName.Count];
            var valsArray = new string[idToName.Count];
            idToName.Keys.CopyTo(keysArray, 0);
            idToName.Values.CopyTo(valsArray, 0);
            foreach (var kv in idToName)
                Console.WriteLine("foreach: " + kv.Key + " -> " + kv.Value);
            bool allValuesNonNull = true;
            foreach (var v in idToName.Values)
                if (v == null) allValuesNonNull = false;
            Console.WriteLine("All values non-null? " + allValuesNonNull);

            // 9.a) Do NOT modify while iterating — InvalidOperationException
            try
            {
                foreach (var kv in idToName)
                {
                    idToName[200] = "bad"; // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Other helpers
            var upperValues = new List<string>();
            foreach (var v in idToName.Values)
                upperValues.Add(v.ToUpper());
            Console.WriteLine("Upper values: " + string.Join(", ", upperValues));
            var sliceKeys = new List<int>();
            for (int i = 0; i < Math.Min(3, idToName.Count); i++)
                sliceKeys.Add(idToName.Keys[i]);
            Console.WriteLine("Slice (first N keys): " + string.Join(", ", sliceKeys));
            var copiedPairs = new KeyValuePair<int, string>[idToName.Count];
            ((ICollection<KeyValuePair<int, string>>)idToName).CopyTo(copiedPairs, 0);
            Console.WriteLine("CopyTo pairs length: " + copiedPairs.Length);

            if (idToName.Count > 0)
                Console.WriteLine("Last key by sort order: " + idToName.Keys[idToName.Count - 1]);

            idToName.Clear();
            Console.WriteLine("Cleared. Count: " + idToName.Count);
        }

        #region
        /*
         ### 🧠 C# `Queue<T>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `Queue<T>`?
    👉 A **`Queue<T>`** is a generic **FIFO** (first-in, first-out) collection: the **oldest** enqueued item is removed **first**.
    👉 It is typically backed by a **circular buffer** (array) with two indices; **`Enqueue`** adds at the tail and **`Dequeue`** removes from the head.
    👉 **Namespace:** `System.Collections.Generic`
    👉 There is **no indexer** (`queue[0]` does not exist). You inspect the front with **`Peek`** / **`TryPeek`** and drain with **`Dequeue`** / **`TryDequeue`**.

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **FIFO ordering:** Perfect for **breadth-first search**, **work queues**, **task scheduling**, and **level-order** tree walks.
    ✔ **Ends only:** You add at the **back** and remove from the **front**—no insert/remove in the middle without rebuilding.
    ✔ **Duplicates allowed:** Same value may appear multiple times in line.
    ✔ **Type-safe:** Generic `<T>` enforces the element type.
    ✔ **Not thread-safe:** For concurrent producers/consumers, use **`ConcurrentQueue<T>`** (`System.Collections.Concurrent`).

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of elements in the queue. | $O(1)$ |
    | **`Capacity`** | Current size of the internal buffer (may be larger than `Count`). | $O(1)$ |
    | **`Enqueue(item)`** | Adds an item at the **tail**. | $O(1)$ amortized* |
    | **`Dequeue()`** | Removes and returns the **head**; throws if empty. | $O(1)$ |
    | **`TryDequeue(out item)`** | Removes head if present; returns `bool`. | $O(1)$ |
    | **`Peek()`** | Returns head **without** removing; throws if empty. | $O(1)$ |
    | **`TryPeek(out item)`** | Reads head if present; returns `bool`. | $O(1)$ |
    | **`Contains(item)`** | Linear scan for equality. | $O(n)$ |
    | **`Clear()`** | Removes all elements (does not trim capacity). | $O(n)$ |
    | **`TrimExcess()`** | Sets capacity to about `Count`. | $O(n)$ |
    | **`EnsureCapacity(min)`** | Grows buffer so capacity is at least `min` (returns new capacity). | $O(n)$ if resize |
    | **`CopyTo` / `ToArray()`** | Snapshot of contents in **FIFO** order (head first). | $O(n)$ |

    *\*Note: Like `List<T>`, occasional **resizing** makes a single `Enqueue` $O(n)$ in the worst case; **`EnsureCapacity`** reduces reallocations when you know expected volume.*

    ### 🟢 4. QUEUE SYNTAX EXAMPLES
    ```csharp
    Queue<string> line = new Queue<string>(new[] { "A", "B" });
    line.Enqueue("C");
    string next = line.Peek();
    string served = line.Dequeue();
    if (line.TryPeek(out string head)) { }
    if (line.TryDequeue(out string outItem)) { }
    foreach (string s in line) { }
    ```

    ### 🟢 5. `Queue<T>` VS. `Stack<T>` VS. `List<T>` (Expert)
    Interviewer: *"Queue vs stack?"*
    * **`Queue<T>` — FIFO:** fair ordering, BFS, pipelines; **front** exits first.
    * **`Stack<T>` — LIFO:** undo/redo, DFS, syntax parsing; **top** exits first.
    * **`List<T>` — indexed:** random access by index; use as a **queue** only with discipline (`RemoveAt(0)` is $O(n)$—avoid; prefer **`Queue<T>`**).

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ **`Enqueue`** back, **`Dequeue`** front; **`Peek`** looks without removing.
    ✔ **`TryPeek` / `TryDequeue`** avoid exceptions on an empty queue.   if(queue.TryDequeue(out int value)){ print(value)}; // ✅ safe
    ✔ **`Contains`** is $O(n)$; no binary search.
    ✔ Implements **`IEnumerable<T>`**, **`IReadOnlyCollection<T>`**—not a list or dictionary.

    ### 🎯 FINAL INTERVIEW LINE
    > "`Queue<T>` is the standard FIFO collection in C#: constant-time enqueue and dequeue at the ends using an internal ring buffer, with no indexer—use it whenever processing order must match arrival order, and prefer `ConcurrentQueue<T>` when multiple threads enqueue or dequeue together."
        */
        #endregion
        public void ShowQueue()
        {
            // 1) Initialization (FIFO order: first enqueued is first dequeued)
            var names = new Queue<string>(new[] { "Krishna", "Hari" });

            // 2) Enqueue (tail)
            names.Enqueue("Sri Rama");
            names.Enqueue("FirstUser");

            // 3) "AddRange" — enqueue each item from a sequence
            foreach (var m in new[] { "Anu", "Ravi" })
                names.Enqueue(m);
            foreach (var x in new[] { "X", "Y" })
                names.Enqueue(x);

            // 4) Count / Capacity (internal buffer; Count is logical size)
            Console.WriteLine($"Count: {names.Count}");
            Console.WriteLine($"Capacity: {names.Capacity}");
            int ensured = names.EnsureCapacity(64);
            Console.WriteLine($"EnsureCapacity(64) -> capacity: {ensured}");
            names.TrimExcess();
            Console.WriteLine($"Capacity after TrimExcess: {names.Capacity}");

            // 5) Accessing — no indexer; Peek / TryPeek inspect the front only
            Console.WriteLine($"Peek (front): {names.Peek()}");
            Console.WriteLine("TryPeek: " + (names.TryPeek(out var peeked) ? peeked : "<empty>"));

            // Walk contents in dequeue order (foreach is FIFO, does not dequeue)
            int ord = 0;
            foreach (var v in names)
                Console.WriteLine($"[{ord++}] (foreach order) = {v}");

            // 6) Searching
            Console.WriteLine("Contains Hari? " + names.Contains("Hari"));
            string? firstStartsWithS = null;
            foreach (var v in names)
                if (v.StartsWith("S")) { firstStartsWithS = v; break; }
            Console.WriteLine("First (FIFO scan) value starting with 'S': " + (firstStartsWithS ?? "<null>"));

            // 7) Remove operations — only from front (Dequeue); rotate queue to drop arbitrary values (e.g. all "Temp")
            names.Dequeue();
            names.TryDequeue(out _);
            names.Enqueue("Temp");
            names.Enqueue("Temp");
            int sweep = names.Count;
            for (int i = 0; i < sweep; i++)
            {
                var x = names.Dequeue();
                if (x != "Temp")
                    names.Enqueue(x);
            }

            // 8) Ordering — always FIFO by enqueue time (no Sort on Queue<T>)
            Console.WriteLine("FIFO snapshot: " + string.Join(", ", names));

            // 9) Conversion and utility
            var arr = names.ToArray();
            Console.WriteLine("ToArray length: " + arr.Length);
            var buf = new string[names.Count];
            names.CopyTo(buf, 0);
            foreach (var s in names)
                Console.WriteLine("foreach: " + s);
            bool allNonNull = true;
            foreach (var v in names)
                if (v == null) allNonNull = false;
            Console.WriteLine("All non-null? " + allNonNull);

            // 9.a) Do NOT modify while iterating — InvalidOperationException
            try
            {
                foreach (var item in names)
                {
                    names.Enqueue("new"); // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Other helpers — snapshot for slice / projection (queues have no GetRange)
            var snap = names.ToArray();
            var upper = new List<string>();
            foreach (var s in snap)
                upper.Add(s.ToUpper());
            Console.WriteLine("Upper (snapshot): " + string.Join(", ", upper));
            var slice = new List<string>();
            for (int i = 0; i < Math.Min(3, snap.Length); i++)
                slice.Add(snap[i]);
            Console.WriteLine("Slice (first N of snapshot): " + string.Join(", ", slice));
            var copied = new string[names.Count];
            names.CopyTo(copied, 0);
            Console.WriteLine("CopyTo length: " + copied.Length);

            if (names.Count > 0)
                Console.WriteLine("Front after demo: " + names.Peek());

            names.Clear();
            Console.WriteLine("Cleared. Count: " + names.Count);
        }

        #region
        /*
         ### 🧠 C# `Stack<T>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `Stack<T>`?
    👉 A **`Stack<T>`** is a generic **LIFO** (last-in, first-out) collection: the **most recently pushed** item is popped **first**.
    👉 It is backed by an **array** that grows as needed; **`Push`** adds at the **top** and **`Pop`** removes from the **top**.
    👉 **Namespace:** `System.Collections.Generic`
    👉 There is **no indexer** (`stack[0]` does not exist). You read the top with **`Peek`** / **`TryPeek`** and remove it with **`Pop`** / **`TryPop`**.

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **LIFO ordering:** Natural for **undo stacks**, **DFS**, **expression evaluation**, **backtracking**, and **nested structure** parsing.
    ✔ **Top only:** Insert and remove happen at one end; no efficient access to the **bottom** without popping everything above it.
    ✔ **Duplicates allowed:** The same value can appear at multiple depths.
    ✔ **Type-safe:** Generic `<T>` enforces the element type.
    ✔ **Not thread-safe:** For concurrent access, use **`ConcurrentStack<T>`** (`System.Collections.Concurrent`).

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of elements on the stack. | $O(1)$ |
    | **`Capacity`** | Current size of the internal buffer (may exceed `Count`). | $O(1)$ |
    | **`Push(item)`** | Pushes onto the **top**. | $O(1)$ amortized* |
    | **`Pop()`** | Removes and returns the **top**; throws if empty. | $O(1)$ |
    | **`TryPop(out item)`** | Pops top if present; returns `bool`. | $O(1)$ |
    | **`Peek()`** | Returns top **without** removing; throws if empty. | $O(1)$ |
    | **`TryPeek(out item)`** | Reads top if present; returns `bool`. | $O(1)$ |
    | **`Contains(item)`** | Linear scan (unspecified order). | $O(n)$ |
    | **`Clear()`** | Removes all elements (does not trim capacity). | $O(n)$ |
    | **`TrimExcess()`** | Shrinks capacity to about `Count`. | $O(n)$ |
    | **`EnsureCapacity(min)`** | Ensures buffer capacity is at least `min` (returns new capacity). | $O(n)$ if resize |
    | **`ToArray()`** | Copy with **top element at index 0**, bottom at the last index. | $O(n)$ |
    | **`CopyTo(array, index)`** | Same **LIFO** ordering as **`ToArray`** for the span written. | $O(n)$ |

    *\*Note: Occasional **array resize** can make a single `Push` $O(n)$; **`EnsureCapacity`** helps when you know the maximum depth.*

    ### 🟢 4. STACK SYNTAX EXAMPLES
    ```csharp
    Stack<string> s = new Stack<string>(new[] { "A", "B" });
    s.Push("C");
    string top = s.Peek();
    string popped = s.Pop();
    if (s.TryPeek(out string head)) { }
    if (s.TryPop(out string outItem)) { }
    foreach (string x in s) { }
    ```

    ### 🟢 5. `Stack<T>` VS. `Queue<T>` VS. `List<T>` (Expert)
    Interviewer: *"When is a stack the right tool?"*
    * **`Stack<T>` — LIFO:** last action is undone first; **depth-first** walks; **call stacks** are the mental model.
    * **`Queue<T>` — FIFO:** first scheduled task runs first; **breadth-first** and **fair** ordering.
    * **`List<T>` as stack:** **`Add` + `RemoveAt(Count-1)`** can mimic a stack but **`Stack<T>`** states intent and matches **`ConcurrentStack<T>`** for threading.

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ **`Push`** adds on top; **`Pop`** removes from top; **`Peek`** reads top only.
    ✔ **`TryPop` / `TryPeek`** avoid exceptions on an empty stack.
    ✔ **`foreach`** enumerates from **top to bottom** (most recent first).
    ✔ Implements **`IEnumerable<T>`**, **`IReadOnlyCollection<T>`**—not a queue or list with an indexer.

    ### 🎯 FINAL INTERVIEW LINE
    > "`Stack<T>` is the standard LIFO collection in C#: constant-time push and pop at the top over a growable array, with no indexer—use it when the last item added must be handled first, and prefer `ConcurrentStack<T>` for lock-free multi-threaded stacks."
        */
        #endregion
        public void ShowStack()
        {
            // 1) Initialization (IEnumerable ctor: first item is bottom, last is top)
            var names = new Stack<string>(new[] { "Krishna", "Hari" });

            // 2) Push (top)
            names.Push("Sri Rama");
            names.Push("FirstUser");

            // 3) "Push range" — push each from sequences (last pushed ends on top)
            foreach (var m in new[] { "Anu", "Ravi" })
                names.Push(m);
            foreach (var x in new[] { "X", "Y" })
                names.Push(x);

            // 4) Count / Capacity
            Console.WriteLine($"Count: {names.Count}");
            Console.WriteLine($"Capacity: {names.Capacity}");
            int ensured = names.EnsureCapacity(64);
            Console.WriteLine($"EnsureCapacity(64) -> capacity: {ensured}");
            names.TrimExcess();
            Console.WriteLine($"Capacity after TrimExcess: {names.Capacity}");

            // 5) Accessing — no indexer; Peek / TryPeek read the top only
            Console.WriteLine($"Peek (top): {names.Peek()}");
            Console.WriteLine("TryPeek: " + (names.TryPeek(out var peeked) ? peeked : "<empty>"));

            // foreach walks top -> bottom (LIFO / most recent first)
            int ord = 0;
            foreach (var v in names)
                Console.WriteLine($"[{ord++}] (foreach top-down) = {v}");

            // 6) Searching
            Console.WriteLine("Contains Hari? " + names.Contains("Hari"));
            string? firstFromTopStartsWithS = null;
            foreach (var v in names)
                if (v.StartsWith("S")) { firstFromTopStartsWithS = v; break; }
            Console.WriteLine("First (top-down scan) value starting with 'S': " + (firstFromTopStartsWithS ?? "<null>"));

            // 7) Remove — Pop / TryPop from top; filter out "Temp" using a scratch stack (two-pass LIFO)
            names.Pop();
            names.TryPop(out _);
            names.Push("Temp");
            names.Push("Temp");
            var scratch = new Stack<string>();
            while (names.Count > 0)
            {
                var x = names.Pop();
                if (x != "Temp")
                    scratch.Push(x);
            }
            while (scratch.Count > 0)
                names.Push(scratch.Pop());

            // 8) Ordering — always LIFO (no Sort on Stack<T>)
            Console.WriteLine("ToArray (index 0 = top): " + string.Join(", ", names.ToArray()));

            // 9) Conversion and utility
            var arr = names.ToArray();
            Console.WriteLine("ToArray length: " + arr.Length);
            var buf = new string[names.Count];
            names.CopyTo(buf, 0);
            foreach (var s in names)
                Console.WriteLine("foreach: " + s);
            bool allNonNull = true;
            foreach (var v in names)
                if (v == null) allNonNull = false;
            Console.WriteLine("All non-null? " + allNonNull);

            // 9.a) Do NOT modify while iterating — InvalidOperationException
            try
            {
                foreach (var item in names)
                {
                    names.Push("new"); // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Snapshot: ToArray is top-first; slice first N = top N items
            var snap = names.ToArray();
            var upper = new List<string>();
            foreach (var s in snap)
                upper.Add(s.ToUpper());
            Console.WriteLine("Upper (snapshot, top-first): " + string.Join(", ", upper));
            var slice = new List<string>();
            for (int i = 0; i < Math.Min(3, snap.Length); i++)
                slice.Add(snap[i]);
            Console.WriteLine("Slice (top N): " + string.Join(", ", slice));
            var copied = new string[names.Count];
            names.CopyTo(copied, 0);
            Console.WriteLine("CopyTo length: " + copied.Length);

            if (names.Count > 0)
                Console.WriteLine("Top after demo: " + names.Peek());

            names.Clear();
            Console.WriteLine("Cleared. Count: " + names.Count);
        }

        #region
        /*
         ### 🧠 C# `PriorityQueue<TElement, TPriority>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `PriorityQueue<TElement, TPriority>`?
    👉 **`PriorityQueue<TElement, TPriority>`** stores **pairs** of an **element** and a **priority**. It is a **binary min-heap** by default: the item with the **smallest** priority value (per **`Comparer<TPriority>.Default`**) is returned **first** by **`Dequeue`** / **`Peek`**.
    👉 **Namespace:** `System.Collections.Generic` (available from **.NET 6** onward.)
    👉 There is **no indexer**. You take the **best** item from the front of the logical heap, not FIFO or LIFO by insertion time alone.

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **Priority ordering:** Use for **Dijkstra**, **A-star pathfinding**, **scheduling**, **merge streams**, **top-K** patterns, and **event simulation** (time as priority).
    ✔ **Tie-breaking:** When two entries share the same priority, order between them is **not specified**—do not rely on FIFO among ties unless you encode order into the priority (for example a sequence number).
    ✔ **Custom order:** Pass an **`IComparer<TPriority>`** to the constructor to get a **max-heap** (`b.CompareTo(a)`) or domain-specific ordering.
    ✔ **Not thread-safe:** Guard with locks or use single-threaded ownership.
    ✔ **Duplicates:** The same **element** or **priority** value may appear in multiple entries; each **`Enqueue`** is a separate node.

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of entries in the heap. | $O(1)$ |
    | **`Enqueue(element, priority)`** | Inserts an element with its priority. | $O(\log n)$ |
    | **`Dequeue()`** | Removes and returns the **best** element; throws if empty. | $O(\log n)$ |
    | **`TryDequeue(out element, out priority)`** | Like **`Dequeue`** but returns `false` if empty. | $O(\log n)$ |
    | **`Peek()`** | Best element **without** removing; throws if empty. | $O(1)$ |
    | **`TryPeek(out element, out priority)`** | Like **`Peek`** but returns `false` if empty. | $O(1)$ |
    | **`EnqueueDequeue(element, priority)`** | Enqueues then removes and returns the **best** (useful for fixed-size “top K” buffers). | $O(\log n)$ |
    | **`EnqueueRange(...)`** | Bulk add from spans or sequences of **(element, priority)** pairs. | $O(k \log n)$ |
    | **`Clear()`** | Empties the queue. | $O(n)$ |
    | **`EnsureCapacity` / `TrimExcess`** | Resize / shrink backing store like other growable collections. | $O(n)$ when resizing |
    | **`UnorderedItems`** | View of **(Element, Priority)** pairs in **heap layout**—**not** dequeue order. | Enumeration $O(n)$ |
    | **`TryRemove(element, ...)`** | Removes an **equal** element (if present); exact API varies by version. | $O(n)$ |

    ### 🟢 4. PRIORITYQUEUE SYNTAX EXAMPLES
    ```csharp
    PriorityQueue<string, int> pq = new PriorityQueue<string, int>();
    pq.Enqueue("task-a", 3);
    pq.Enqueue("task-b", 1);
    if (pq.TryPeek(out string e, out int p)) { }
    if (pq.TryDequeue(out e, out p)) { }
    PriorityQueue<string, int> maxFirst =
        new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
    ```

    ### 🟢 5. `PriorityQueue` VS. `Queue` VS. `Sorted` structures (Expert)
    Interviewer: *"Why not just sort a list?"*
    * **`Queue<T>` — FIFO:** order is **arrival** time, not priority.
    * **`PriorityQueue<,>` — by priority:** **cheapest** (or custom **best**) item **next**, in **logarithmic** time per insert/remove.
    * **`SortedList` / `SortedDictionary` — keyed:** optimize **lookup by key** and **sorted key iteration**; not the same as “next best task” unless the key **is** the priority and you only need the **one** minimum key pattern.

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ Default = **min-heap** on **`TPriority`** using **`Comparer<TPriority>.Default`**.
    ✔ **`Peek`** is $O(1)$; **`Enqueue`** / **`Dequeue`** are $O(\log n)$.
    ✔ **`UnorderedItems`** is for inspection only—order is **not** dequeue order.
    ✔ For **stable** ordering among equal priorities, include a **counter** or **timestamp** in the priority tuple or use a composite key.

    ### 🎯 FINAL INTERVIEW LINE
    > "`PriorityQueue<TElement, TPriority>` is .NET’s binary heap: it always offers the smallest priority first (unless you swap the comparer), with logarithmic enqueue and dequeue and no indexer—ideal for scheduling and graph algorithms where you repeatedly need the current best item."
        */
        #endregion
        public void ShowPriorityQueue()
        {
            // 1) Initialization — lower int priority = higher precedence (min-heap)
            var tasks = new PriorityQueue<string, int>();
            tasks.Enqueue("Krishna", 2);
            tasks.Enqueue("Hari", 5);

            // 2) Enqueue
            tasks.Enqueue("Sri Rama", 3);
            tasks.Enqueue("FirstUser", 1);

            // 3) EnqueueRange — bulk (element, priority) pairs
            tasks.EnqueueRange(new (string Element, int Priority)[]
            {
                ("Anu", 4),
                ("Ravi", 6)
            });
            foreach (var x in new[] { ("X", 7), ("Y", 8) })
                tasks.Enqueue(x.Item1, x.Item2);

            // 4) Count / capacity helpers
            Console.WriteLine($"Count: {tasks.Count}");
            int ensured = tasks.EnsureCapacity(64);
            Console.WriteLine($"EnsureCapacity(64) -> capacity: {ensured}");
            tasks.TrimExcess();

            // 5) Peek / TryPeek — best = minimum priority (not “oldest” unless priority says so)
            tasks.TryPeek(out var bestEl, out var bestPr);
            Console.WriteLine($"TryPeek: {bestEl} (priority {bestPr})");
            Console.WriteLine($"Peek: {tasks.Peek()}");

            // UnorderedItems: heap order, not dequeue order (for debugging / scan only)
            int ui = 0;
            foreach (var item in tasks.UnorderedItems)
                Console.WriteLine($"[{ui++}] UnorderedItems: {item.Element} prio={item.Priority}");

            // 6) Searching — no Contains; scan UnorderedItems
            bool hasHari = false;
            foreach (var item in tasks.UnorderedItems)
                if (item.Element == "Hari") { hasHari = true; break; }
            Console.WriteLine("Has Hari? " + hasHari);
            string? firstStartsWithS = null;
            foreach (var item in tasks.UnorderedItems)
                if (item.Element.StartsWith("S")) { firstStartsWithS = item.Element; break; }
            Console.WriteLine("First UnorderedItems scan starting with 'S': " + (firstStartsWithS ?? "<null>"));

            // 7) Dequeue / TryDequeue; drop all "Temp" by snapshot + rebuild
            tasks.TryDequeue(out _, out _);
            tasks.Dequeue();
            tasks.Enqueue("Temp", 99);
            tasks.Enqueue("Temp", 99);
            var rebuild = new List<(string el, int pr)>();
            foreach (var item in tasks.UnorderedItems)
                rebuild.Add((item.Element, item.Priority));
            tasks.Clear();
            foreach (var (el, pr) in rebuild)
                if (el != "Temp")
                    tasks.Enqueue(el, pr);

            // EnqueueDequeue — enqueue one item, immediately return (and remove) the best
            string displaced = tasks.EnqueueDequeue("Zeta", 50);
            Console.WriteLine("EnqueueDequeue displaced (best before add): " + displaced);

            // 8) Ordering — by priority, not insertion order; max-heap example
            var maxPq = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            maxPq.Enqueue("low", 1);
            maxPq.Enqueue("high", 100);
            maxPq.TryPeek(out var mx, out var mxP);
            Console.WriteLine($"Max-heap TryPeek (larger priority wins): {mx} ({mxP})");

            // 9) Drain in true dequeue order (sorted by priority for this demo)
            var dequeueOrder = new List<string>();
            while (tasks.TryDequeue(out var el, out _))
                dequeueOrder.Add(el);
            Console.WriteLine("Dequeue order: " + string.Join(" -> ", dequeueOrder));

            // Refill for remaining demos
            tasks.Enqueue("Krishna", 2);
            tasks.Enqueue("Hari", 3);
            tasks.Enqueue("Sri Rama", 4);
            bool allElNonNull = true;
            foreach (var item in tasks.UnorderedItems)
                if (item.Element == null) allElNonNull = false;
            Console.WriteLine("All elements non-null? " + allElNonNull);

            // 9.a) Do NOT modify while iterating UnorderedItems
            try
            {
                foreach (var item in tasks.UnorderedItems)
                {
                    tasks.Enqueue("bad", 0); // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Snapshot without destroying: copy pairs, then optional slice
            var snap = new List<(string el, int pr)>();
            foreach (var item in tasks.UnorderedItems)
                snap.Add((item.Element, item.Priority));
            var upper = new List<string>();
            foreach (var t in snap)
                upper.Add(t.el.ToUpper());
            Console.WriteLine("Upper (snapshot): " + string.Join(", ", upper));
            var slice = new List<(string, int)>();
            for (int i = 0; i < Math.Min(3, snap.Count); i++)
                slice.Add(snap[i]);
            Console.WriteLine("Slice (first N of UnorderedItems snapshot): " + string.Join("; ", slice));

            tasks.Clear();
            Console.WriteLine("Cleared. Count: " + tasks.Count);
        }

        #region
        /*
         ### 🧠 C# `Dictionary<TKey, TValue>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `Dictionary<TKey, TValue>`?
    👉 A **`Dictionary<TKey, TValue>`** maps **unique keys** to **values** using a **hash table** (chaining / open addressing in the runtime implementation). Average-case **lookup, insert, and delete by key** are **constant time** $O(1)$.
    👉 **Namespace:** `System.Collections.Generic`
    👉 **Keys must be unique:** duplicate **`Add`** throws **`ArgumentException`**; the **`this[key]`** setter **replaces** the value if the key already exists.
    👉 **Order:** From **.NET Core 3.0 / .NET Standard 2.1** onward, enumeration follows **insertion order** (for string keys this is practical; do not depend on order across all mutation patterns in exotic scenarios).

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **Fast by key:** Prefer **`TryGetValue`** / **`ContainsKey`** instead of catching exceptions from **`this[key]`** when the key might be missing.
    ✔ **Values can duplicate:** Many keys may map to the same value; only keys are unique.
    ✔ **Custom equality:** Pass **`IEqualityComparer<TKey>`** to the constructor for case-insensitive strings, structural equality for records, etc.
    ✔ **Not thread-safe:** For concurrent maps, use **`ConcurrentDictionary<TKey, TValue>`** or external locking.
    ✔ **No indexer by integer position:** Unlike **`List<T>`**, there is no `dict[0]` for “first pair”—use **`Keys`** / **`Values`** or **`foreach`**.

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of key/value pairs. | $O(1)$ |
    | **`Add(key, value)`** | Adds a pair; **throws** if key exists. | $O(1)$ avg* |
    | **`TryAdd(key, value)`** | Adds only if key missing; returns `bool`. | $O(1)$ avg* |
    | **`this[key]`** | Get (throws if missing) or set (add or replace). | $O(1)$ avg* |
    | **`TryGetValue(key, out value)`** | Gets value if present; preferred over catch. | $O(1)$ avg* |
    | **`Remove(key)`** | Removes by key; returns `bool`. | $O(1)$ avg* |
    | **`Remove(key, out value)`** | Removes and returns value if removed. | $O(1)$ avg* |
    | **`ContainsKey(key)`** | Whether key exists. | $O(1)$ avg* |
    | **`ContainsValue(value)`** | Linear scan of values. | $O(n)$ |
    | **`Clear()`** | Removes all entries. | $O(n)$ |
    | **`EnsureCapacity` / `TrimExcess`** | Resize / shrink buckets (modern .NET). | $O(n)$ when resizing |
    | **`Keys` / `Values`** | Live views of keys or values. | — |
    | **`GetValueOrDefault(key)`** | Returns default if key missing (overload with custom default). | $O(1)$ avg* |

    *\*Average case; worst-case hash collisions can degrade to $O(n)$—rare with a good hash and `Equals`.*

    ### 🟢 4. DICTIONARY SYNTAX EXAMPLES
    ```csharp
    Dictionary<string, int> ages = new Dictionary<string, int>
    {
        ["Ann"] = 30,
        ["Bob"] = 25
    };
    ages.Add("Cam", 28);
    ages["Ann"] = 31;
    if (ages.TryGetValue("Bob", out int x)) { }
    ages.Remove("Cam");
    foreach (KeyValuePair<string, int> kv in ages) { }
    ```

    ### 🟢 5. `Dictionary` VS. `SortedDictionary` VS. `SortedList` (Expert)
    Interviewer: *"When do you need a sorted map?"*
    * **`Dictionary<TKey, TValue>`:** **Fastest** typical lookups; **unordered** (insertion order when enumerated in modern .NET).
    * **`SortedDictionary<TKey, TValue>`:** Keys **sorted**; **`O(log n)`** operations; tree structure.
    * **`SortedList<TKey, TValue>`:** Keys sorted in **parallel arrays**; compact memory; **slower** inserts in the middle at scale.

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ **Unique keys**; **`TryAdd`** and **`TryGetValue`** avoid exceptions.
    ✔ **`ContainsValue`** is $O(n)$—avoid in hot paths.
    ✔ Implements **`IDictionary<TKey, TValue>`**, **`IReadOnlyDictionary<TKey, TValue>`**.
    ✔ Do **not** modify the dictionary while **`foreach`** over it—**`InvalidOperationException`**.

    ### 🎯 FINAL INTERVIEW LINE
    > "`Dictionary<TKey, TValue>` is the standard hash map in C#: amortized constant-time operations by key, unique keys with replaceable values, and optional custom equality for keys—use `ConcurrentDictionary` when multiple threads share the map without external locking."
        */
        #endregion
        public void ShowDictionary()
        {
            // 1) Initialization (collection initializer / indexer syntax)
            var idToName = new Dictionary<int, string>
            {
                [2] = "Hari",
                [5] = "Krishna"
            };

            // 2) Add / indexer (indexer adds or replaces)
            idToName.Add(3, "Sri Rama");
            idToName[1] = "FirstUser";
            try
            {
                idToName.Add(2, "DuplicateKey");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Add duplicate key: " + ex.Message);
            }
            idToName[2] = "HariUpdated";

            // 3) TryAdd / merge another map  
            foreach (var kv in new Dictionary<int, string> { { 4, "Anu" }, { 6, "Ravi" } })
                idToName.TryAdd(kv.Key, kv.Value);
            idToName.TryAdd(4, "ShouldNotReplace");

            // 4) Count / capacity (implementation detail; helps avoid rehash churn)
            Console.WriteLine($"Count: {idToName.Count}");
            idToName.EnsureCapacity(64);
            idToName.TrimExcess();

            // 5) Accessing by key (TryGetValue preferred when key may be absent)
            Console.WriteLine($"this[3]: {idToName[3]}");
            Console.WriteLine("TryGetValue 6: " + (idToName.TryGetValue(6, out var n6) ? n6 : "<missing>"));
            Console.WriteLine("GetValueOrDefault 999: " + idToName.GetValueOrDefault(999, "<none>"));

            foreach (var kv in idToName)
                Console.WriteLine($"foreach: {kv.Key} -> {kv.Value}");

            // 6) Searching
            Console.WriteLine("ContainsKey 5? " + idToName.ContainsKey(5));
            Console.WriteLine("ContainsValue HariUpdated? " + idToName.ContainsValue("HariUpdated"));
            int? firstKeyForS = null;
            foreach (var kv in idToName)
                if (kv.Value.StartsWith("S")) { firstKeyForS = kv.Key; break; }
            Console.WriteLine("First key whose value starts with 'S': " + (firstKeyForS?.ToString() ?? "<null>"));

            // 7) Remove
            idToName.Remove(1);
            if (idToName.Remove(5, out var removedName))
                Console.WriteLine("Remove returned value: " + removedName);
            idToName[99] = "Temp";
            idToName[100] = "Temp";
            idToName.Remove(99);
            idToName.Remove(100);

            // 8) Ordering — logical map is unordered; enumeration is insertion order on modern .NET
            Console.WriteLine("Keys (enumeration order): " + string.Join(", ", idToName.Keys));

            // 9) Conversion and utility
            var keysCopy = new int[idToName.Count];
            idToName.Keys.CopyTo(keysCopy, 0);
            var valsCopy = new string[idToName.Count];
            idToName.Values.CopyTo(valsCopy, 0);
            bool allValuesNonNull = true;
            foreach (var v in idToName.Values)
                if (v == null) allValuesNonNull = false;
            Console.WriteLine("All values non-null? " + allValuesNonNull);

            // 9.a) Do NOT modify while iterating
            try
            {
                foreach (var kv in idToName)
                {
                    idToName[200] = "bad"; // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Other helpers
            var upperVals = new List<string>();
            foreach (var v in idToName.Values)
                upperVals.Add(v.ToUpper());
            Console.WriteLine("Upper values: " + string.Join(", ", upperVals));
            var sliceKeys = new List<int>();
            int take = 0;
            foreach (var k in idToName.Keys)
            {
                if (take++ >= Math.Min(3, idToName.Count)) break;
                sliceKeys.Add(k);
            }
            Console.WriteLine("Slice (first N keys in enumeration order): " + string.Join(", ", sliceKeys));
            var copiedPairs = new KeyValuePair<int, string>[idToName.Count];
            ((ICollection<KeyValuePair<int, string>>)idToName).CopyTo(copiedPairs, 0);
            Console.WriteLine("CopyTo pairs length: " + copiedPairs.Length);

            idToName.Clear();
            Console.WriteLine("Cleared. Count: " + idToName.Count);

        }

        #region
        /*
         ### 🧠 C# `SortedDictionary<TKey, TValue>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `SortedDictionary<TKey, TValue>`?
    👉 A **`SortedDictionary<TKey, TValue>`** maps **unique keys** to **values** and keeps keys in **sorted order** (ascending by default, or according to an **`IComparer<TKey>`** you pass to the constructor).
    👉 It is implemented as a **balanced binary search tree** (red–black tree): **`Add`**, **`Remove`**, and **`ContainsKey`** are **`O(log n)`** in the worst case.
    👉 **Namespace:** `System.Collections.Generic`
    👉 **Keys must be unique** (same rules as **`Dictionary`**): duplicate **`Add`** throws; **`this[key]`** setter **replaces** the value for an existing key.

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **Sorted iteration:** **`foreach`**, **`Keys`**, and **`Values`** expose items in **strictly increasing key order**—unlike **`Dictionary`**, which does not guarantee sort order (only insertion order on modern runtimes).
    ✔ **Logarithmic updates:** Good when you need **in-order walks** or **range-style** logic and still want **dynamic** inserts and deletes.
    ✔ **Memory:** Each entry carries **tree pointers**—typically **more overhead per item** than **`SortedList`** arrays but **faster inserts** for random keys when **`n`** is large.
    ✔ **Comparer:** Use **`Comparer<TKey>.Create(...)`** for descending keys or custom ordering.
    ✔ **Not thread-safe:** Use locks or **`ConcurrentDictionary`** (note: concurrent sorted maps are not in the BCL as a drop-in).

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of pairs. | $O(1)$ |
    | **`Add(key, value)`** | Inserts; **throws** if key exists. | $O(\log n)$ |
    | **`TryAdd(key, value)`** | Adds if missing; returns `bool`. | $O(\log n)$ |
    | **`this[key]`** | Get (throws if missing) or set (add or replace). | $O(\log n)$ |
    | **`TryGetValue(key, out value)`** | Safe get by key. | $O(\log n)$ |
    | **`Remove(key)`** | Removes by key; returns `bool`. | $O(\log n)$ |
    | **`Remove(key, out value)`** | Removes and outputs value if removed (same pattern as **`Dictionary`** when available). | $O(\log n)$ |
    | **`ContainsKey(key)`** | Key present? | $O(\log n)$ |
    | **`ContainsValue(value)`** | Linear scan over values. | $O(n)$ |
    | **`Clear()`** | Empties the tree. | $O(n)$ |
    | **`Keys` / `Values`** | Sorted views (keys sorted; values align with those keys). | — |
    | **`GetValueOrDefault(key)`** | Default if missing. | $O(\log n)$ |

    ### 🟢 4. SORTEDDICTIONARY SYNTAX EXAMPLES
    ```csharp
    SortedDictionary<string, int> scores = new SortedDictionary<string, int>
    {
        ["Bob"] = 20,
        ["Ann"] = 10
    };
    scores.Add("Cam", 15);
    scores["Ann"] = 12;
    if (scores.TryGetValue("Bob", out int x)) { }
    scores.Remove("Cam");
    foreach (KeyValuePair<string, int> kv in scores) { }
    ```

    ### 🟢 5. `SortedDictionary` VS. `SortedList` VS. `Dictionary` (Expert)
    Interviewer: *"SortedDictionary vs SortedList?"*
    * **`Dictionary`:** **$O(1)$** average by key; **not sorted** when enumerated (insertion order on current .NET).
    * **`SortedList<TKey, TValue>`:** **Two arrays** of keys and values; **compact**; **`Add`** is often **$O(n)$** due to shifting; fast **index** by position.
    * **`SortedDictionary<TKey, TValue>`:** **Tree**; **$O(\log n)$** add/remove/lookup; better for **many random inserts** at scale; **no integer indexer** for “k-th key” without walking.

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ **Always sorted by key** on enumeration.
    ✔ All core map operations by key are **logarithmic**, not average **$O(1)$** like **`Dictionary`**.
    ✔ **`ContainsValue`** is still **$O(n)$**.
    ✔ Do **not** modify while **`foreach`**—**`InvalidOperationException`**.

    ### 🎯 FINAL INTERVIEW LINE
    > "`SortedDictionary<TKey, TValue>` is the standard sorted map in .NET: a red–black tree giving logarithmic insert, delete, and lookup by key while enumerating keys in order—choose it over `SortedList` when you have frequent inserts and deletes, and over `Dictionary` when sorted key order is required."
        */
        #endregion
        public void ShowSortedDictionary()
        {
            // 1) Initialization — keys will always be iterated in sorted order
            var idToName = new SortedDictionary<int, string>
            {
                [2] = "Hari",
                [5] = "Krishna"
            };

            // 2) Add / indexer
            idToName.Add(3, "Sri Rama");
            idToName[1] = "FirstUser";
            try
            {
                idToName.Add(2, "DuplicateKey");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Add duplicate key: " + ex.Message);
            }
            idToName[2] = "HariUpdated";

            // 3) TryAdd / merge
            foreach (var kv in new Dictionary<int, string> { { 4, "Anu" }, { 6, "Ravi" } })
                idToName.TryAdd(kv.Key, kv.Value);
            idToName.TryAdd(4, "ShouldNotReplace");

            // 4) Count — no EnsureCapacity/TrimExcess (tree-based, not a single growable array)
            Console.WriteLine($"Count: {idToName.Count}");

            // 5) Accessing by key
            Console.WriteLine($"this[3]: {idToName[3]}");
            Console.WriteLine("TryGetValue 6: " + (idToName.TryGetValue(6, out var n6) ? n6 : "<missing>"));
            Console.WriteLine("GetValueOrDefault 999: " + idToName.GetValueOrDefault(999, "<none>"));

            foreach (var kv in idToName)
                Console.WriteLine($"foreach (sorted by key): {kv.Key} -> {kv.Value}");

            // 6) Searching
            Console.WriteLine("ContainsKey 5? " + idToName.ContainsKey(5));
            Console.WriteLine("ContainsValue HariUpdated? " + idToName.ContainsValue("HariUpdated"));
            int? firstKeySortedWhoseValueStartsWithS = null;
            foreach (var kv in idToName)
                if (kv.Value.StartsWith("S")) { firstKeySortedWhoseValueStartsWithS = kv.Key; break; }
            Console.WriteLine("Smallest key (sorted walk) whose value starts with 'S': " + (firstKeySortedWhoseValueStartsWithS?.ToString() ?? "<null>"));

            // 7) Remove
            idToName.Remove(1);
            if (idToName.Remove(5, out var removedName))
                Console.WriteLine("Remove returned value: " + removedName);
            idToName[99] = "Temp";
            idToName[100] = "Temp";
            idToName.Remove(99);
            idToName.Remove(100);

            // 8) Ordering — enumeration is ascending by key (not insertion order)
            Console.WriteLine("Keys (sorted): " + string.Join(", ", idToName.Keys));

            // 9) Conversion and utility
            var keysCopy = new int[idToName.Count];
            idToName.Keys.CopyTo(keysCopy, 0);
            var valsCopy = new string[idToName.Count];
            idToName.Values.CopyTo(valsCopy, 0);
            bool allValuesNonNull = true;
            foreach (var v in idToName.Values)
                if (v == null) allValuesNonNull = false;
            Console.WriteLine("All values non-null? " + allValuesNonNull);

            // 9.a) Do NOT modify while iterating
            try
            {
                foreach (var kv in idToName)
                {
                    idToName[200] = "bad"; // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Other helpers — first N keys are the N smallest keys
            var upperVals = new List<string>();
            foreach (var v in idToName.Values)
                upperVals.Add(v.ToUpper());
            Console.WriteLine("Upper values (sorted key order): " + string.Join(", ", upperVals));
            var sliceKeys = new List<int>();
            int take = 0;
            foreach (var k in idToName.Keys)
            {
                if (take++ >= Math.Min(3, idToName.Count)) break;
                sliceKeys.Add(k);
            }
            Console.WriteLine("Slice (smallest N keys): " + string.Join(", ", sliceKeys));
            var copiedPairs = new KeyValuePair<int, string>[idToName.Count];
            ((ICollection<KeyValuePair<int, string>>)idToName).CopyTo(copiedPairs, 0);
            Console.WriteLine("CopyTo pairs length: " + copiedPairs.Length);

            // Descending key order example (separate instance)
            var desc = new SortedDictionary<int, string>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            desc[1] = "A";
            desc[3] = "B";
            Console.WriteLine("Descending comparer keys first: " + string.Join(", ", desc.Keys));

            idToName.Clear();
            Console.WriteLine("Cleared. Count: " + idToName.Count);
        }

        #region
        /*
         ### 🧠 C# `HashSet<T>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `HashSet<T>`?
    👉 A **`HashSet<T>`** stores **unique** elements of type **`T`** using a **hash table** (same broad idea as **`Dictionary<TKey, TValue>`** keys). **`Add`**, **`Remove`**, and **`Contains`** are **average $O(1)$**.
    👉 **Namespace:** `System.Collections.Generic`
    👉 **No key/value:** Unlike a map, you only store **values** (often used as “have I seen this id?” or set algebra on domains).
    👉 **Order:** Enumeration order is **undefined**—do not rely on insertion order for logic (unlike **`Dictionary`** on modern .NET, which preserves insertion order for enumeration).

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **Uniqueness:** **`Add`** returns **`false`** if the item is already present (no exception).
    ✔ **Set operations:** **`UnionWith`**, **`IntersectWith`**, **`ExceptWith`**, **`SymmetricExceptWith`** mutate **this** set in place.
    ✔ **Comparisons:** **`IsSubsetOf`**, **`IsProperSubsetOf`**, **`IsSupersetOf`**, **`IsProperSupersetOf`**, **`Overlaps`**, **`SetEquals`** answer relational questions without allocating a new set.
    ✔ **Custom equality:** Constructor accepts **`IEqualityComparer<T>`** (for example case-insensitive strings).
    ✔ **Not thread-safe:** Use **`ConcurrentDictionary`** patterns or locks if shared; **`ConcurrentBag`** / custom sync for general concurrency.

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of distinct elements. | $O(1)$ |
    | **`Add(item)`** | Adds if missing; returns **`bool`** (true if added). | $O(1)$ avg* |
    | **`Remove(item)`** | Removes if present; returns **`bool`**. | $O(1)$ avg* |
    | **`Clear()`** | Removes all elements. | $O(n)$ |
    | **`Contains(item)`** | Membership test. | $O(1)$ avg* |
    | **`TryGetValue(equal, out actual)`** | Finds stored value **equal** per comparer (useful for **canonical** instance). | $O(1)$ avg* |
    | **`RemoveWhere(predicate)`** | Removes all matching items. | $O(n)$ |
    | **`EnsureCapacity` / `TrimExcess`** | Pre-size or shrink backing store (modern .NET). | $O(n)$ when resizing |
    | **`CopyTo` / `ToArray` (via LINQ or manual)** | Snapshot; order unspecified. | $O(n)$ |
    | **`UnionWith` / `IntersectWith` / `ExceptWith` / `SymmetricExceptWith`** | In-place set algebra vs another enumerable. | $O(n + m)$ typical |

    *\*Average case; pathological **`GetHashCode`** / **`Equals`** can degrade performance.*

    ### 🟢 4. HASHSET SYNTAX EXAMPLES
    ```csharp
    HashSet<string> ids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    bool added = ids.Add("abc");
    ids.Add("abc");
    bool has = ids.Contains("ABC");
    ids.Remove("abc");
    ids.RemoveWhere(s => s.Length == 0);
    foreach (string s in ids) { }
    ```

    ### 🟢 5. `HashSet<T>` VS. `Dictionary<TKey, TValue>` VS. `SortedSet<T>` (Expert)
    Interviewer: *"When do you use a HashSet?"*
    * **`HashSet<T>`:** **Membership** and **set ops**; no associated value per item.
    * **`Dictionary<K, V>`:** Map **key → value**; keys unique; same average complexity for key ops.
    * **`SortedSet<T>`:** **Sorted** unique elements; **`O(log n)`** ops; use when you need **in-order** enumeration.

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ **`Add`** does **not** throw on duplicate—it returns **`false`**.
    ✔ **`UnionWith`** etc. modify **this** set; clone first if you need the original.
    ✔ Enumeration order is **not** a stable contract for **`HashSet`**.
    ✔ Do **not** modify while **`foreach`**—**`InvalidOperationException`**.

    ### 🎯 FINAL INTERVIEW LINE
    > "`HashSet<T>` is a hash-based set: average constant-time add, remove, and contains with uniqueness enforced by equality, plus rich in-place set algebra—ideal for deduplication, graph edges, permission sets, and fast overlap checks between collections."
        */
        #endregion
        public void ShowHashSet()
        {
            // 1) Initialization
            var names = new HashSet<string>   
            {
                "Krishna", 
                "Hari"
            };   

            // 2) Add — returns false if duplicate
            Console.WriteLine("Add Sri Rama: " + names.Add("Sri Rama"));
            Console.WriteLine("Add Krishna again: " + names.Add("Krishna"));

            // 3) "AddRange" — UnionWith copies all from another set / sequence
            var more = new HashSet<string> { "Anu", "Ravi" };
            names.UnionWith(more);
            names.UnionWith(new[] { "X", "Y" });   //remember unionwith in hashset

            // 4) Count / capacity
            Console.WriteLine($"Count: {names.Count}");
            names.EnsureCapacity(64);
            names.TrimExcess(); // no effect if Count is close to capacity; otherwise may reduce memory usage

            // 5) Contains — no indexer
            Console.WriteLine("Contains Hari? " + names.Contains("Hari"));
            string? firstStartsWithS = null;
            foreach (var v in names)
                if (v.StartsWith("S")) { firstStartsWithS = v; break; }
            Console.WriteLine("First in enumeration starting with 'S': " + (firstStartsWithS ?? "<null>"));

            // TryGetValue — returns the stored instance equal under the comparer
            if (names.TryGetValue("Hari", out var canonical))
                Console.WriteLine("TryGetValue (ordinal): " + canonical);
            var ci = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Hari", "Krishna" };
            if (ci.TryGetValue("HARI", out var canonCi))
                Console.WriteLine("TryGetValue ignore-case canonical: " + canonCi);

            // 6) Remove / RemoveWhere
            names.Remove("X");
            names.Add("Temp");
            names.Add("Temp2");
            names.RemoveWhere(s => s.StartsWith("Temp"));

            // 7) Set algebra — use copies so each demo is easy to read
            var a = new HashSet<int> { 1, 2, 3, 4, 5 };
            var b = new HashSet<int> { 4, 5, 6, 7, 8 };
            var u = new HashSet<int>(a);
            u.UnionWith(b);
            Console.WriteLine("UnionWith copy: " + string.Join(",", u));
            var i = new HashSet<int>(a);
            i.IntersectWith(b);
            Console.WriteLine("IntersectWith: " + string.Join(",", i));
            var e = new HashSet<int>(a);
            e.ExceptWith(b);
            Console.WriteLine("ExceptWith (A minus B): " + string.Join(",", e));
            var sym = new HashSet<int>(a);
            sym.SymmetricExceptWith(b);
            Console.WriteLine("SymmetricExceptWith: " + string.Join(",", sym));

            // 8) Comparisons
            Console.WriteLine("IsSubsetOf: " + new HashSet<int> { 4, 5 }.IsSubsetOf(b));
            Console.WriteLine("Overlaps: " + a.Overlaps(b));
            Console.WriteLine("SetEquals: " + new HashSet<int> { 1, 2, 3 }.SetEquals(new HashSet<int> { 3, 2, 1 }));

            // 9) Ordering — undefined; CopyTo snapshot (order not specified)
            var buf = new string[names.Count];
            names.CopyTo(buf);
            foreach (var s in names)
                Console.WriteLine("foreach: " + s);
            bool allNonNull = true;
            foreach (var v in names)
                if (v == null) allNonNull = false;
            Console.WriteLine("All non-null? " + allNonNull);

            // 9.a) Do NOT modify while iterating
            try
            {
                foreach (var item in names)
                {
                    names.Add("bad"); // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Snapshot slice (arbitrary order) / projection
            var snap = new List<string>();
            foreach (var s in names)
                snap.Add(s);
            var upper = new List<string>();
            foreach (var s in snap)
                upper.Add(s.ToUpper());
            Console.WriteLine("Upper (snapshot): " + string.Join(", ", upper));
            for (int k = 0; k < Math.Min(3, snap.Count); k++)
                Console.WriteLine("Slice arbitrary index " + k + ": " + snap[k]);

            names.Clear();
            Console.WriteLine("Cleared. Count: " + names.Count);
        }

        #region
        /*
         ### 🧠 C# `SortedSet<T>` – INTERVIEW NOTES

    ### 🟢 1. WHAT IS A `SortedSet<T>`?
    👉 A **`SortedSet<T>`** stores **unique** elements kept in **sorted order** (ascending by default, or by an **`IComparer<T>`** passed to the constructor).
    👉 It is implemented as a **balanced binary search tree** (red–black tree), like the key collection inside **`SortedDictionary<TKey, TValue>`**.
    👉 **Namespace:** `System.Collections.Generic`
    👉 **`Add`**, **`Remove`**, and **`Contains`** are **`O(log n)`** in the worst case—not average **`O(1)`** like **`HashSet<T>`**.

    ### 🟢 2. KEY CHARACTERISTICS
    ✔ **Sorted enumeration:** **`foreach`**, **`Min`**, and **`Max`** reflect the **comparer** order—ideal when you need **next / previous** style logic or **range** views.
    ✔ **Range view:** **`GetViewBetween(lower, upper)`** returns a **live** subset between bounds (still backed by the same tree rules).
    ✔ **Set algebra:** Same **`UnionWith`**, **`IntersectWith`**, **`ExceptWith`**, **`SymmetricExceptWith`**, and subset / superset tests as **`HashSet<T>`** (still mutating **this** set).
    ✔ **No hash comparer:** Uses **`IComparer<T>`** (ordering), not **`IEqualityComparer<T>`** (hash/equality)—default is **`Comparer<T>.Default`**.
    ✔ **Not thread-safe:** Guard externally for concurrent use.

    ### 🟢 3. COMMON PROPERTIES & METHODS
    | Member | Purpose | Performance |
    | :--- | :--- | :--- |
    | **`Count`** | Number of elements. | $O(1)$ |
    | **`Add(item)`** | Inserts if missing; returns **`bool`**. | $O(\log n)$ |
    | **`Remove(item)`** | Removes if present; returns **`bool`**. | $O(\log n)$ |
    | **`Clear()`** | Empties the set. | $O(n)$ |
    | **`Contains(item)`** | Membership. | $O(\log n)$ |
    | **`Min` / `Max`** | Smallest / largest element; invalid if empty. | $O(\log n)$ |
    | **`RemoveWhere(predicate)`** | Removes all matches. | $O(n)$ |
    | **`GetViewBetween(lo, hi)`** | Live sub-range per comparer. | $O(\log n)$ to create view |
    | **`CopyTo`** | Fills array in **sorted** order. | $O(n)$ |
    | **`UnionWith` / `IntersectWith` / …** | In-place set operations vs enumerable. | $O(n \log m)$-style bounds typical |

    ### 🟢 4. SORTEDSET SYNTAX EXAMPLES
    ```csharp
    SortedSet<int> nums = new SortedSet<int> { 9, 1, 5 };
    nums.Add(3);
    int smallest = nums.Min;
    SortedSet<int> window = nums.GetViewBetween(3, 7);
    foreach (int x in nums) { }
    ```

    ### 🟢 5. `SortedSet<T>` VS. `HashSet<T>` VS. `SortedList` (Expert)
    Interviewer: *"When pay for a sorted set?"*
    * **`HashSet<T>`:** **Fastest** typical membership; **unordered** enumeration.
    * **`SortedSet<T>`:** **Ordered** unique items; **logarithmic** ops; **range** and **min/max** in one structure.
    * **`SortedList<TKey, TValue>`:** Key/value **arrays**; need **values** per key or **index** by position—different problem than a pure set.

    ### 🟢 6. QUICK REVISION (1-MINUTE)
    ✔ Uniqueness + **sorted** iteration by **`IComparer<T>`**.
    ✔ **`GetViewBetween`** is a **view**—changes to the parent can affect it and vice versa.
    ✔ Prefer **`HashSet`** for raw speed; **`SortedSet`** when **order** or **ranges** matter.
    ✔ Do **not** modify while **`foreach`**—**`InvalidOperationException`**.

    ### 🎯 FINAL INTERVIEW LINE
    > "`SortedSet<T>` is the ordered cousin of `HashSet<T>`: a red–black tree of unique elements with logarithmic add, remove, and contains, sorted enumeration, and `GetViewBetween` for sub-ranges—use it when you need set semantics plus sorted order or min/max in one place."
        */
        #endregion
        public void ShowSortedSet()
        {
            // 1) Initialization — enumeration is always ascending per comparer
            var names = new SortedSet<string>
            {
                "Krishna",
                "Hari"
            };

            // 2) Add — false if already present
            Console.WriteLine("Add Sri Rama: " + names.Add("Sri Rama"));
            Console.WriteLine("Add Krishna again: " + names.Add("Krishna"));

            // 3) UnionWith — merges sorted union in place
            names.UnionWith(new SortedSet<string> { "Anu", "Ravi" });
            names.UnionWith(new[] { "X", "Y" });

            // 4) Count — no EnsureCapacity (tree-based)
            Console.WriteLine($"Count: {names.Count}");

            // 5) Contains — first match for StartsWith in sorted order = lexicographically first such string
            Console.WriteLine("Contains Hari? " + names.Contains("Hari"));
            string? firstStartsWithS = null;
            foreach (var v in names)
                if (v.StartsWith("S")) { firstStartsWithS = v; break; }
            Console.WriteLine("First in sorted order starting with 'S': " + (firstStartsWithS ?? "<null>"));

            // Min / Max
            if (names.Count > 0)
                Console.WriteLine($"Min: {names.Min}, Max: {names.Max}");

            // 6) Remove / RemoveWhere
            names.Remove("X");
            names.Add("Temp");
            names.Add("TempZ");
            names.RemoveWhere(s => s.StartsWith("Temp"));

            // GetViewBetween — live view on string comparer range
            if (names.Count > 0)
            {
                var window = names.GetViewBetween("Anu", "Sri Rama");
                Console.WriteLine("GetViewBetween [Anu, Sri Rama]: " + string.Join(", ", window));
            }

            // 7) Set algebra (copies, like HashSet demo)
            var a = new SortedSet<int> { 1, 2, 3, 4, 5 };
            var b = new SortedSet<int> { 4, 5, 6, 7, 8 };
            var u = new SortedSet<int>(a);
            u.UnionWith(b);
            Console.WriteLine("UnionWith (sorted): " + string.Join(",", u));
            var i = new SortedSet<int>(a);
            i.IntersectWith(b);
            Console.WriteLine("IntersectWith: " + string.Join(",", i));
            var e = new SortedSet<int>(a);
            e.ExceptWith(b);
            Console.WriteLine("ExceptWith: " + string.Join(",", e));
            var sym = new SortedSet<int>(a);
            sym.SymmetricExceptWith(b);
            Console.WriteLine("SymmetricExceptWith: " + string.Join(",", sym));

            // 8) Comparisons
            Console.WriteLine("IsSubsetOf: " + new SortedSet<int> { 4, 5 }.IsSubsetOf(b));
            Console.WriteLine("Overlaps: " + a.Overlaps(b));
            Console.WriteLine("SetEquals: " + new SortedSet<int> { 1, 2, 3 }.SetEquals(new SortedSet<int> { 3, 2, 1 }));

            // Descending order — reverse comparer
            var desc = new SortedSet<int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            desc.UnionWith(new[] { 1, 3, 5 });
            Console.WriteLine("Descending set foreach: " + string.Join(",", desc));

            // 9) CopyTo — sorted order
            var buf = new string[names.Count];
            names.CopyTo(buf);
            foreach (var s in names)
                Console.WriteLine("foreach (sorted): " + s);
            bool allNonNull = true;
            foreach (var v in names)
                if (v == null) allNonNull = false;
            Console.WriteLine("All non-null? " + allNonNull);

            // 9.a) Do NOT modify while iterating
            try
            {
                foreach (var item in names)
                {
                    names.Add("bad"); // ❌ Runtime exception
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException caught: " + ex.Message);
            }

            // 10) Slice = smallest N strings (enumeration order)
            var slice = new List<string>();
            int take = 0;
            foreach (var s in names)
            {
                if (take++ >= Math.Min(3, names.Count)) break;
                slice.Add(s);
            }
            Console.WriteLine("Slice (smallest N lexicographically): " + string.Join(", ", slice));

            names.Clear();
            Console.WriteLine("Cleared. Count: " + names.Count);
        }

    }
}

