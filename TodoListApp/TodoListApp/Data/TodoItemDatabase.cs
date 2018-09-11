using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TodoListApp.Model;

namespace TodoListApp.Data
{
    class TodoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GetAll()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<List<TodoItem>> GetTodoItemsOrderedByPriority()
        {
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] ORDER BY [Priority] DESC");
        }

        public Task<List<TodoItem>> GetTodoItems(bool done)
        {
            if (done)
                return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 1");
            else
                return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<TodoItem> GetTodoItemById(int id)
        {
            return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveOrUpdateTodoItem(TodoItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
    }
}
