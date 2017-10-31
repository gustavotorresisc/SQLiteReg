using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
//chido
namespace imagenes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPageBD : ContentPage
    {
        public ObservableCollection<_13090371> Items { get; set; }
        //SQLiteConnection database;


        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090371>Tabla;
        MobileServiceUser usuario;

        public DetailPageBD()
        {
            InitializeComponent();

            Cliente = new MobileServiceClient(AzureConnection.AzuteURL);
            Tabla = Cliente.GetTable<_13090371>();
            Tabla.IncludeDeleted();
            LeerTabla();
           // Tabla.UndeleteAsync(nombre);

            //string db;
            //db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
            //database = new SQLiteConnection(db);
            //database.CreateTable<TESHDatos>();

            //Items = new ObservableCollection<TESHDatos>(database.Table<TESHDatos>());
            //BindingContext = this;
        }

        private async void LeerTabla()
        {
            IEnumerable<_13090371> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_13090371>(elementos);
            BindingContext = this;
        }

        private async void login_Clicked(object sender, EventArgs e)
        {
            usuario = await App.Authenticator.Authenticate();
            if (App.Authenticator != null)
            {
                if (usuario != null)
                {
                    await DisplayAlert("Usuario Autenticado", usuario.UserId, "Okey");
                }
            }
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new SelectedPage(e.SelectedItem as _13090371));
        }

        private void Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new InsertPage());
        }

        private void inicio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }



        //private void Carrera_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var carrera = (Picker)sender;
        //    int selectedIndex = carrera.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        carrera_piker = (string)carrera.ItemsSource[selectedIndex];

        //    }
        //}
    }
}