# 📘 TaskMasterConsoleApp — Dev Progress & Roadmap

This README is just for us (Jonni + ChatGPT) to track structure, progress, and plan what comes next.

---

## ✅ Project Structure
```
/TaskMasterConsoleApp
|
├── TaskMasterApp                  # Core logic
│   ├── Models/                    # Domain models (e.g., Todo.cs)
│   ├── Services/                  # Logic layer (TodoRepository, ITodoStorage)
│   ├── Storage/                   # JSON file storage (JsonTodoStorage.cs)
│   └── UI/                        # Console UI logic (Menu.cs)
│   └── Program.cs                # Entry point
│
├── TaskMasterApp.Tests           # xUnit test project
│   └── TodoRepositoryTests.cs    # Tests for repo logic
│   └── MenuTests.cs              # Tests for menu flow with input/output injection
│
├── .gitignore                    # Standard .NET
├── README.md                     # You're reading it!
└── TaskMasterConsoleApp.sln      # Solution file
```

---

## ✅ Completed Features
- [x] Base structure with clean folder layout and single responsibility
- [x] `Todo` model with basic properties and `ToString()` override
- [x] `TodoRepository` with methods: Add, GetAll, MarkCompleted
- [x] `ITodoStorage` interface to abstract storage
- [x] `JsonTodoStorage` implementation using System.Text.Json
- [x] UI Menu with injected input/output
- [x] Add + View Todos (with completion)
- [x] Mark task as completed
- [x] xUnit tests for repository and menu logic
- [x] In-memory mock storage for isolated tests
- [x] Clean PRs and commits with good messages 🧼

---

## 🧠 Design Goals
- **Testable**: All input/output injectable
- **Scalable**: Easy to replace JSON with DB later
- **Separation of concerns**: Models, services, UI are cleanly separated
- **Readable**: Clear naming, XML docs, good structure

---

## 🔜 Next Steps (Roadmap)

### 🔧 Code Improvements
- [ ] Add `RemoveTodo(Guid id)` in repository and UI
- [ ] Add `UpdateTodo(Guid id)`
- [ ] Sort tasks by due date (optional)
- [ ] Error handling for invalid inputs (gracefully)

### 📂 Storage Enhancements
- [ ] Add CSV or SQLiteStorage alternative (based on `ITodoStorage`)
- [ ] Abstract file path to be configurable

### 📈 Testing
- [ ] Add test for `MarkTodoAsCompleted()` with invalid GUID
- [ ] Add test for viewing todos with mocked input/output
- [ ] Test persistence via JSON read/write

### 🧑‍💻 UI Polish
- [ ] Validate and re-prompt on invalid inputs
- [ ] Display status more clearly in UI ([x]/[ ])
- [ ] Highlight overdue tasks (color or text)

### 📦 Release Prep
- [ ] Add versioning (e.g., v1.1.0)
- [ ] Add user-facing README with usage
- [ ] Add license and contribution guide (MIT?)

---

## 🧪 Local Dev Commands
```bash
# Clean + build
$ dotnet clean && dotnet build

# Run the app
$ dotnet run --project TaskMasterApp

# Run tests
$ dotnet test --logger:"console;verbosity=detailed"
```

---

## 💬 Final Thoughts
You’ve built a strong foundation for a real-world console app. The architecture is flexible, testable, and clean — perfect for growth. The next features will only build on this quality.

Let’s keep shipping like pros 🚀

