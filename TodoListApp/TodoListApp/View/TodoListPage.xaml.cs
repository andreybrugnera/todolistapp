using System;
using System.Collections.ObjectModel;
using TodoListApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace TodoListApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage, INotifyPropertyChanged
    {
        ObservableCollection<TodoItem> Items;

        private string _selectedPriorityFilter = "Todas";
        private string _selectedStatusFilter = "Todas";
        private string _DescriptionFilter = "";

        public string SelectedPriorityFilter
        {
            get { return _selectedPriorityFilter; }
            set
            {
                if (_selectedPriorityFilter != value)
                {
                    OnPropertyChanged(nameof(SelectedPriorityFilter));
                    _selectedPriorityFilter = value;
                    loadTotoItems();
                }
            }
        }

        public string SelectedStatusFilter
        {
            get { return _selectedStatusFilter; }
            set
            {
                if (_selectedStatusFilter != value)
                {
                    OnPropertyChanged(nameof(SelectedStatusFilter));
                    _selectedStatusFilter = value;
                    loadTotoItems();
                }
            }
        }

        public TodoListPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            loadTotoItems();
        }

        private async void loadTotoItems()
        {           
            Items = new ObservableCollection<TodoItem>(await App.DataBase.GetAll());

            Items = new ObservableCollection<TodoItem>(Items.Where((item) => {                
                if (_DescriptionFilter != "" && !item.Description.ToLower().Contains(_DescriptionFilter.ToLower()))
                {
                    return false;
                }

                if (SelectedPriorityFilter != "Todas" && !item.Priority.ToLower().Contains(SelectedPriorityFilter.ToLower()))
                {
                    return false;
                }

                if (SelectedStatusFilter == "Resolvidas" && !item.Done || SelectedStatusFilter == "Pendentes" && item.Done)
                {
                    return false;
                }

                return true;
            }));

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

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            BindingContext = this;
            _DescriptionFilter = MainSearchBar.Text;
            OnPropertyChanged(nameof(_DescriptionFilter));
            loadTotoItems();
        }
    }
}
