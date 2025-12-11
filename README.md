# Advanced OOP Principles in C#

This project demonstrates advanced C# capabilities and design patterns implemented within a device management system context.

## 🛠 Features Implemented
* **Interfaces & Polymorphism:** - Multiple interface implementation (`IChargeable`, `IDiagnostic`).
  - **Explicit interface implementation** to resolve naming conflicts (`ISelfRepair`).
* **Events & Delegates:**
  - Custom event handling using `Action<T>` delegates.
  - Anonymous methods and Lambda expressions for event subscription.
* **Functional Programming:**
  - Usage of `Func<T, TResult>` for logic encapsulation.
* **Collections & LINQ:**
  - Custom collection (`DeviceGarage`) implementing `IEnumerable` for iteration.
  - `IComparable` implementation for object sorting.
  - Custom Indexers (String-based indexing).
* **Extensions:**
  - Extension methods implementation (`IsPortable` for `ComputingDevice`).

## 💻 Tech Stack
* C# / .NET
* Object-Oriented Programming (OOP)
