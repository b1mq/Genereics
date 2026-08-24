# C# Generic Collections in Action 🧬

This repository contains practical implementations of C# built-in **Generic Collections** (`System.Collections.Generic`). Instead of abstract examples, this project demonstrates how different data structures solve specific real-world business logic problems.

## 🚀 Projects & Data Structures Used

### 1. Cafe Queue & Reservation System ☕
Simulates a restaurant's table management system.
*   **`Queue<string>` (FIFO):** Manages the live waiting list for walk-in visitors.
*   **`Dictionary<string, DateTime>`:** Handles table reservations, linking a visitor's name to their booking time, complete with expiration logic (15-minute tolerance).

### 2. Multi-Value English-French Dictionary 📖
A language dictionary that supports multiple translations for a single word.
*   **`Dictionary<string, List<string>>`:** Maps a single English key to a dynamic list of French translations.
*   **Features:** Add, remove, update, and search for specific translations safely without overwriting existing data.

### 3. Employee Password Manager 🔐
A secure-access simulation for employee credentials.
*   **`Dictionary<string, string>`:** Provides fast $O(1)$ lookups for authentication, linking unique employee logins (keys) to their passwords (values).

### 4. Custom Iterators & Records 🧑‍💼
*   **`IEnumerable<T>` & `yield return`:** The `Cafe` class demonstrates how to create a custom iterator to traverse through a collection of employees lazily.
*   **`record` types:** Uses C# 9+ `sealed record` for immutable `Employee` data models (`Name`, `Age`, `Salary`).

## 🛠️ Tech Stack & Concepts
*   **Language:** C# 10+
*   **Architecture:** Domain Entities (`Gn.Domain.Entities`)
*   **Key Concepts:** Generic Collections, Custom Iterators (`IEnumerator`), Time-based logic (`DateTime.Now`), Data Immutability (`records`).

## 🧠 What I Learned
Through these implementations, I solidified my understanding of:
1.  **Choosing the right collection:** When to use a `Queue` vs. a `List`.
2.  **Dictionary power:** Utilizing `TryGetValue` and combining Collections (e.g., lists inside dictionaries) for complex data mapping.
3.  **Iteration:** How `yield return` builds state machines under the hood for clean `foreach` iteration over custom objects.

## 👨‍💻 Author

**Egor (b1mq)**
*   [GitHub Profile](https://github.com/b1mq)
