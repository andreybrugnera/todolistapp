using System;
using System.IO;
using Xamarin.Forms;
using TodoListApp.Util;

[assembly: Dependency(typeof(TodoListApp.Droid.Util.FileHelper))]
namespace TodoListApp.Droid.Util
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}