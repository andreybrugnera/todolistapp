using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TodoListApp.Data;
using TodoListApp.Util;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoListApp
{
    public partial class App : Application
    {
        private static TodoItemDatabase dataBase;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoListApp.View.TodoListPage());
        }

        internal static TodoItemDatabase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoListSQLite.db3"));
                }
                return dataBase;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
