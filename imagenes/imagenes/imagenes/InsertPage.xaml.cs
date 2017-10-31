using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace imagenes
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {
        public ObservableCollection<_13090371> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090371> Tabla;

        /*  Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
          {
                { "Sistemas", Color.Aqua },
              { "Biologia", Color.Black },
          };*/

        //SQLiteConnection database;
        string datoPiker;
        string datoPiker_sem;
        public InsertPage()
        {
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzuteURL);
            Tabla = Cliente.GetTable<_13090371>();
            //string db;
            //db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
            //database = new SQLiteConnection(db);
            //database.CreateTable<_13090371>();


        }

       
        private async void Insertar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090371
            {
                Id= Entry_Id.Text,
                Nombre = Entry_Nom.Text,
                Apellidos = Entry_Ape.Text,
                Direccion = Entry_Dir.Text,
                Telefono = Entry_Tel.Text,
                Carrera = datoPiker,
                Semestre = datoPiker_sem,
                Matricula = Entry_Matric.Text ,
                Correo = Entry_Cor.Text,
                Github = Entry_Git.Text,
            };
            await InsertPage.Tabla.InsertAsync(datos);
            await Navigation.PushModalAsync(new DetailPageBD());
            //database.Insert(datos);
            //Navigation.PushModalAsync(new DetailPageBD());


        }

        private void inicio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }


        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {

            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datoPiker = (string)picker.ItemsSource[selectedIndex];

            }

        }

        private void picker_semestre_SelectedIndexChanged(object sender, EventArgs e)
        {

            var picker_semestre = (Picker)sender;
            int selectedIndex = picker_semestre.SelectedIndex;

            if (selectedIndex != -1)
            {
                datoPiker_sem = (string)picker_semestre.ItemsSource[selectedIndex];

            }

        }
    }
}