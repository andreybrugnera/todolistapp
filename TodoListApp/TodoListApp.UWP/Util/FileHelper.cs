using System.IO;
using Xamarin.Forms;
using TodoListApp.Util;
using Windows.Storage;

[assembly: Dependency(typeof(TodoListApp.UWP.Util.FileHelper))]
namespace TodoListApp.UWP.Util
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
