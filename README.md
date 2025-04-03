# 📝 TaskMasterConsoleApp

A simple, testable console app for managing todos — built as part of my .NET education.

---

## 👋 About Me

Hi, I’m **Jonni Åkesson**. I come from an iOS background, and this is one of my first real .NET projects. I wanted to focus on structure, clean code, and testing — and this app was a great way to explore that.

---

## 🧠 Planning First

Before writing any code, I focused on structure and flow.  
I used ChatGPT to help me:

- Break down the user story
- Plan out folders, classes, and naming
- Stay focused on testability and separation of concerns

This early planning helped the code stay maintainable and clear as the app grew.

---

## 🧩 Project Overview

### ✅ Features
- Add, view, update, complete, and remove tasks
- Optional due dates, sorted automatically
- Color-coded feedback in the console (✅ green, ❌ red, 🗑️ trash)
- Unit-tested with xUnit and fake in-memory storage

### 📂 Structure

```
/TaskMasterConsoleApp
├── Models/          // The Todo domain model
├── Services/        // Business logic (TodoRepository)
├── Data/            // Storage interface + JSON file storage
├── UI/              // Console interaction (Menu + UserInterface)
├── Tests/           // xUnit test project
├── todos.json       // Default local storage
└── Program.cs       // App entry point
```

---

## 🧪 Technologies & Concepts

- C# with .NET 8
- LINQ
- System.Text.Json for file storage
- Interfaces & abstraction
- Console UI with injected I/O
- Unit testing with xUnit
- Git, GitHub, and pull request workflow

---

## 🔍 UML Diagram

This diagram shows the architecture and how classes interact:

📎 `docs/uml-taskmaster.png` (embed or link to your UML image here)

- `Menu` handles UI logic and user flows
- `TodoRepository` coordinates data operations
- `ITodoStorage` abstracts saving/loading
- `JsonTodoStorage` is one implementation (can be swapped)
- `UserInterface` encapsulates all console I/O for better testability

---

## 🧠 Reflections

### What I learned:
- Real-world structure matters as much as getting it to work.
- Abstractions, interfaces, and loose coupling really pay off later.
- Writing tests early helps guide clean code.

### What I’d improve next:
- Add a database option like SQLite via another `ITodoStorage` implementation
- Add filtering or searching
- Maybe build a minimal UI or web front-end

---

## 🙋 Presentation Notes

I’ll cover:
- My planning process using ChatGPT
- Key design decisions (repo pattern, I/O abstraction, test setup)
- A demo of the core features
- What I’ve learned from this project and the course

---

## ✅ Run Locally

```bash
# Build & run the app
dotnet run --project TaskMasterApp

# Run tests
dotnet test --logger:"console;verbosity=detailed"
```

---

## 🤝 Thanks for reviewing

This was more than a coding exercise — it was a learning experience.  
Built with care, tested with purpose, and always ready to grow. 🙌
```

---