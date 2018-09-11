using System;
using TodoListApp.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoListApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;

            var selectedPriority = picker.Items[picker.SelectedIndex];
            todoItem.Priority = selectedPriority;

            await App.DataBase.SaveOrUpdateTodoItem(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}