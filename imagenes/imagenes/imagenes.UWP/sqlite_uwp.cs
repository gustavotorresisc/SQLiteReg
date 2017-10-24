using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Windows.Storage;
using imagenes.UWP;

[assembly: Dependency(typeof(sqlite_uwp))]
namespace imagenes.UWP
{
    public class sqlite_uwp : isqlite
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
