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
│   ├── Data/                      # JSON file storage (JsonTodoStorage.cs)
│   └── UI/                        # Console UI logic (Menu.cs, UserInterface.cs)
│   └── Program.cs                 # Entry point
│
├── TaskMasterApp.Tests           # xUnit test project
│   ├── TodoRepositoryTests.cs    # Tests for repo logic
│   ├── MenuTests.cs              # Tests for menu flow with input/output injection
│   └── FakeInMemoryStorage.cs    # Mocked test storage
│
├── todos.json                    # Local data store (excluded from git)
├── .gitignore                    # Standard .NET
├── README.md                     # You're reading it!
└── TaskMasterConsoleApp.sln      # Solution file
```

---

## ✅ Completed Features
- [x] Base structure with clean folder layout and single responsibility
- [x] `Todo` model with basic properties and `ToString()` override
- [x] `TodoRepository` with methods: Add, GetAll, MarkCompleted, Remove
- [x] `ITodoStorage` interface to abstract storage
- [x] `JsonTodoStorage` implementation using System.Text.Json
- [x] UI Menu with injected input/output
- [x] Add + View Todos
- [x] Mark task as completed ✅
- [x] Remove task 🗑️
- [x] Color-coded UI via `UserInterface` (green/red)
- [x] Emojis for user feedback (🆕 ✅ 🗑️)
- [x] All success/error messages bubble through the architecture
- [x] Tests for add, complete, remove flows
- [x] In-memory mock storage for isolated tests
- [x] Clean PRs and commits with good messages 🧼

---

## 🧠 Design Goals
- **Testable**: All input/output injectable
- **Scalable**: Easy to replace JSON with DB later
- **Separation of concerns**: Models, services, UI are cleanly separated
- **Readable**: Clear naming, small functions, clean formatting

---

## 🔜 Next Steps (Roadmap)

### 🔧 Code Improvements
- [ ] Add `UpdateTodo(Guid id)`
- [ ] Sort tasks by due date (optional)
- [ ] Highlight overdue tasks (color or emoji)
- [ ] Allow due date entry on task creation

### 📂 Storage Enhancements
- [ ] Add CSV or SQLiteStorage alternative (based on `ITodoStorage`)
- [ ] Abstract file path to be configurable

### 📈 Testing
- [ ] Add test for `MarkTodoAsCompleted()` with invalid GUID
- [ ] Add test for viewing todos with mocked input/output
- [ ] Test persistence via JSON read/write

### 🧑‍💻 UI Polish
- [ ] Group tasks by status (incomplete/complete)
- [ ] Display total task count
- [ ] Validate and re-prompt on invalid inputs

### 📦 Release Prep
- [ ] Tag next release (v1.2.0)
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