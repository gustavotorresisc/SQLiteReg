using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using imagenes.iOS;
using Xamarin.Forms;
using SQLite;
using Foundation;
using UIKit;
using System.ComponentModel;
using SQLitePCL;


[assembly: Dependency(typeof(SQLite_IOS))]
namespace imagenes.iOS
{
    //public class SQLite_IOS
    public class SQLite_IOS : isqlite

    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library","Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);

            }
            return Path.Combine(libFolder, filename);
        }
    }
}