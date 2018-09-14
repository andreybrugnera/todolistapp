using System;
using System.Collections.ObjectModel;
using TodoListApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoListApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {

        ObservableCollection<TodoItem> Items;

        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            loadTotoItems();
        }

        private async void loadTotoItems()
        {
            Items = new ObservableCollection<TodoItem>(await App.DataBase.GetAll());
            todoListView.ItemsSource = Items;
        }

        async void addNewTodoItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void setItemAsDoneOrUndone(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            TodoItem todoItem = (TodoItem) e.Item;
            todoItem.Done = todoItem.Done ? false : true;
 
            await App.DataBase.SaveOrUpdateTodoItem(todoItem);

            loadTotoItems();
        }
    }
}
