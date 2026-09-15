# Memory Allocation Analysis: Stack vs. Heap

---

## Diagram 1: After Line 1

```csharp
Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };
```

```
       STACK                                     HEAP
+------------------+                    +-----------------------+
|   Variable /     |                    |   Object Metadata     |
|   Address Value  |                    |   & Fields            |
+------------------+                    +-----------------------+
| o1 : 0x00A14B80  | -----------------> | Address: 0x00A14B80   |
+------------------+                    | Type:    Order        |
                                        | --------------------- |
                                        | OrderId:      1       |
                                        | CustomerName: "Ali"   |
                                        | IsPaid:       false   |
                                        +-----------------------+
```

**Explanation:** A new `Order` object is instantiated on the Heap at memory address `0x00A14B80` with default/assigned field values, while a reference variable `o1` is allocated on the Stack holding that memory address.

---

## Diagram 2: After Line 2

```csharp
Order o2 = o1;
```

```
       STACK                                     HEAP
+------------------+                    +-----------------------+
|   Variable /     |                    |   Object Metadata     |
|   Address Value  |                    |   & Fields            |
+------------------+                    +-----------------------+
| o1 : 0x00A14B80  | -----------------> | Address: 0x00A14B80   |
| o2 : 0x00A14B80  | -----------------> | Type:    Order        |
+------------------+                    | --------------------- |
                                        | OrderId:      1       |
                                        | CustomerName: "Ali"   |
                                        | IsPaid:       false   |
                                        +-----------------------+
```

**Explanation:** A second reference variable `o2` is pushed onto the Stack containing a copy of the memory address `0x00A14B80`, so both `o1` and `o2` now point to the exact same object instance on the Heap.

---

## Diagram 3: After Line 3

```csharp
o2.IsPaid = true;
```

```
       STACK                                     HEAP
+------------------+                    +-----------------------+
|   Variable /     |                    |   Object Metadata     |
|   Address Value  |                    |   & Fields            |
+------------------+                    +-----------------------+
| o1 : 0x00A14B80  | -----------------> | Address: 0x00A14B80   |
| o2 : 0x00A14B80  | -----------------> | Type:    Order        |
+------------------+                    | --------------------- |
                                        | OrderId:      1       |
                                        | CustomerName: "Ali"   |
                                        | IsPaid:       true    |  <-- Updated
                                        +-----------------------+
```

**Explanation:** Accessing `o2.IsPaid` dereferences address `0x00A14B80` and updates the `IsPaid` field to `true` directly on the shared Heap object, meaning accessing `o1.IsPaid` will also evaluate to `true`.

---

## What would be different with structs?

If `Order` were defined as a `struct` (a value type, such as `Point`) rather than a `class`:

1. **No Heap Allocation:** The entire instance and all its fields (`OrderId`, `CustomerName`, `IsPaid`) would reside directly on the Stack inside `o1`'s frame space (assuming local scope), with zero allocations on the Heap.
2. **Copy-by-Value Behavior:** Executing `Order o2 = o1;` would create a complete, independent bitwise copy of `o1` on the Stack allocated for `o2`.
3. **Independent Mutation:** Executing `o2.IsPaid = true;` would only modify the `IsPaid` field inside `o2` on the Stack; `o1.IsPaid` would remain `false` because they occupy distinct, isolated memory locations.
