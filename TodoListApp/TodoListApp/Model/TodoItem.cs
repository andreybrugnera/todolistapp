using SQLite;

namespace TodoListApp.Model
{
    class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public string Priority { get; set; }

        public TodoItem() { }

        public TodoItem(int iD, string description, bool done, string priority)
        {
            this.ID = iD;
            this.Description = description;
            this.Done = done;
            this.Priority = priority;
        }
    }
}
