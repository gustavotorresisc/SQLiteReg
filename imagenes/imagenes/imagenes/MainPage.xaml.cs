using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace imagenes
{

    public partial class MainPage : ContentPage
    {
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090371> Tabla;
        public static MobileServiceUser usuario;

        public MainPage()
        {
            InitializeComponent();

            
           //SQLiteAsyncConnection database;
           // string db;
           // db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
           // database = new SQLiteAsyncConnection(db);
           // database.CreateTableAsync<_13090371>().Wait();
            
            /* var elemento = new TESHDatos
             {
                 Nombre = 3,
                 Apellidos = "Gustavo1",
                 Direccion = "Torres1",
                 Telefono = "55761496031",
                 Carrera = "Ing. Sistemas1",
                 Semestre = "91°",
                 Matricula = "113090371",
                 Correo = "tocg199303011",
                 Github = "gustavotorresisc1",


             }; 
             database.InsertAsync(elemento);

             Label label = new Label();*/
            //    database.Table<TESHDatos>().ToListAsync().ContinueWith(t => { foreach (var item in t.Result) label.Text = item.Nombre; });

        }

        

        private void Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertPage());
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailPageBD());
        }
    }
}
