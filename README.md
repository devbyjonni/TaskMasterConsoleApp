## 📘 TaskMasterConsoleApp — Developer Guide & Showcase

This README is part documentation, part presentation. It walks through the structure, features, and technical decisions behind the app — and shows why it’s built to scale and impress.

---

### ✅ Project Structure

```
/TaskMasterConsoleApp
│
├── TaskMasterApp/                # Core logic
│   ├── Models/                   # Domain models (Todo.cs)
│   ├── Services/                 # TodoRepository.cs (business logic)
│   ├── Data/                     # Storage abstraction + JSON persistence
│   ├── UI/                       # Console UI logic, menu flows, I/O wrapper
│   └── Program.cs                # Entry point: sets up and launches app
│
├── TaskMasterApp.Tests/          # xUnit tests for logic and UI
│   ├── TodoRepositoryTests.cs
│   └── MenuTests.cs
│
├── todos.json                    # JSON file for persistent tasks
├── README.md                     # You're reading it!
└── TaskMasterConsoleApp.sln      # .NET solution
```

---

### ✅ Completed Features

- [x] Add, view, update, remove tasks
- [x] Mark tasks as completed ✅
- [x] Optional due dates, with automatic sorting by earliest
- [x] JSON file storage with error handling and path feedback
- [x] xUnit test suite (repository + UI flows)
- [x] Modular and testable architecture
- [x] Console I/O wrapper for clean UX and test injection
- [x] Colored output for success and error feedback
- [x] Task list display enhancements (emoji, formatting)

---

### 🧠 Design Goals

| Goal              | Notes                                                                 |
|-------------------|-----------------------------------------------------------------------|
| **Testability**   | All UI and I/O are injectable, enabling reliable unit tests           |
| **Scalability**   | Abstracted `ITodoStorage` interface supports future DB/CSV storage    |
| **Clean Code**    | Separation of concerns, clear method naming, and SRP compliance       |
| **Feedback**      | UI shows file path, storage messages, color-coded task feedback       |

---

### 🧪 Testing

The project uses **xUnit** for automated tests:

- ✅ `AddTodo` adds to list and persists
- ✅ `MarkTodoAsCompleted` updates status
- ✅ `RemoveTodo` deletes and confirms via message
- ✅ `UpdateTodo` changes title cleanly
- ✅ UI tests inject input/output and assert on formatted output
- ✅ `ViewTasksFlow` test confirms sorting by due date

To run tests:

```bash
dotnet test --logger:"console;verbosity=detailed"
```

---

### 🧑‍💻 Local Dev

```bash
# Clean + build
dotnet clean && dotnet build

# Run app
dotnet run --project TaskMasterApp

# View saved todos
cat todos.json
```

---

### 💬 Developer Notes

This project was developed with care for structure, clarity, and future extensibility.

If you’re reviewing the code:
- All logic is modular and commented
- Console UI is fully decoupled from the core logic
- The storage backend can be replaced with minimal changes
- Tests serve as documentation and regression safety

---