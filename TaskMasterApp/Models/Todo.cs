namespace TaskMasterApp.Models
{
    /// <summary>
    /// Represents a single todo item with title, status, and optional due date.
    /// </summary>
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }

        public Todo(string title, DateTime? dueDate = null)
        {
            Id = Guid.NewGuid();
            Title = title;
            DueDate = dueDate;
            IsCompleted = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[x]" : "[ ]";
            string due = DueDate.HasValue ? $"(Due: {DueDate:yyyy-MM-dd})" : "";
            return $"{status} {Title} {due}";
        }
    }
}