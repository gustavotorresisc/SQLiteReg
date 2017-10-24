using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//using sqlite.Droid;
using Xamarin.Forms;
using SQLite;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using imagenes.Droid;



[assembly: Dependency(typeof(SQLite_droid))]
namespace imagenes.Droid
{
    public class SQLite_droid: isqlite
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

    }
}