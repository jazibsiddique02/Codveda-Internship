#  Zoo Management System – C# OOP Concepts Demo

##  Overview

This is a simple C# console application that demonstrates **Object-Oriented Programming (OOP)** principles such as:

- Encapsulation
- Inheritance
- Polymorphism
- Constructors
- Use of Access Modifiers (private, public)

The application simulates a Zoo Management System that handles different types of animals using a class hierarchy and polymorphic behavior.

---

##  Assigned Task

> Implement OOP concepts such as:
>
> - Encapsulation
> - Inheritance
> - Polymorphism  
>
> Understand Access Modifiers and their use cases.  
>
> Write and execute methods, properties, and constructors.

---

##  Technologies Used

- **Language:** C#
- **Framework:** .NET Core / .NET 6+
- **Type:** Console Application

---

##  Class Structure

###  `Animal` (Base Class)
- Encapsulates common properties:
  - `Name`, `Age`, `Habitat`
- Provides a virtual method: `MakeSound()`

###  `Lion`, `Parrot`, `Elephant` (Derived Classes)
- Each inherits from `Animal` and:
  - Adds unique attributes:
    - `Lion`: `IsAlphaMale`
    - `Parrot`: `Color`
    - `Elephant`: `TrunkLength`
  - Overrides the `MakeSound()` method to provide species-specific behavior

---

##  Features Demonstrated

###  **Encapsulation**
- Private fields and public properties ensure controlled access.

###  **Inheritance**
- `Lion`, `Parrot`, and `Elephant` inherit from the `Animal` class.

###  **Polymorphism**
- Overridden `MakeSound()` method behaves differently based on the object type, even when accessed via the base class reference.

###  **Constructors**
- All classes have parameterized constructors for proper initialization.

###  **Access Modifiers**
- Demonstrated use of `private` and `public` for restricting access.

---

##  How It Works

1. Creates instances of animals: a generic `Animal`, a `Lion`, a `Parrot`, and an `Elephant`.
2. Stores all instances in a `List<Animal>`.
3. Iterates through the list and calls the `MakeSound()` method polymorphically.
4. Also demonstrates how the `Name` property of `Lion` can be changed using its public setter.

---

##  Sample Output

Mufasa
Animal makes a sound
Roar! I am a Lion.
Squawk! I can talk.
Trumpet! I am an elephant.

##  Folder Structure
├── Animal.cs
├── Lion.cs
├── Parrot.cs
├── Elephant.cs
└── MainClass.cs

##  Author

**Jazib Siddique**  


