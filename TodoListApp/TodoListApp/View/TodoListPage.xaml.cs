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
        public ObservableCollection<string> Items { get; set; }

        public TodoListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            todoListView.ItemsSource = await App.DataBase.GetAll();
        }

        async void addNewTodoItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()
            });
        }

        async void setItemAsDone(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "Setting item as done.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
