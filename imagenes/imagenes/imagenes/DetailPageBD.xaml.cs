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

namespace imagenes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPageBD : ContentPage
    {
        public ObservableCollection<_13090371> Items { get; set; }
        //SQLiteConnection database;
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090371>Tabla;
        public static MobileServiceUser usuario;

        public DetailPageBD()
        {
            InitializeComponent();

            Cliente = new MobileServiceClient(AzureConnection.AzuteURL);
            Tabla = Cliente.GetTable<_13090371>();
            //Tabla.IncludeDeleted();
            //LeerTabla();
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
            /*
            if (App.Authenticator != null)
            {
                usuario = await App.Authenticator.Authenticate();
                if (usuario != null)
                {
                    await DisplayAlert("Usuario Autenticado", usuario.UserId, "Okey");
                    await Navigation.PushModalAsync(new InsertPage());
                    //LeerTabla();
                    //if (usuario.UserId != "Administrador(Id)")
                }
                if (usuario == null)
                {
                    Boton_Insertar.IsVisible = false;
                    Boton_Insertar.IsEnabled = false;

                }
                
            }*/
            try
            {
                if (App.Authenticator != null)
                {
                    usuario = await App.Authenticator.Authenticate();

                    if (usuario != null)
                    {
                        await DisplayAlert("Usuario Autenticado", usuario.UserId, "ok");
                        await Navigation.PushModalAsync(new InsertPage());
                    }
                    if (usuario == null)
                    {
                        await DisplayAlert("", "Usuario No Autenticado", "ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new SelectedPage(e.SelectedItem as _13090371));
        }
        private void Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertPage());
        }
        private void inicio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
        private void MostrarElominados_Clicked(object sender, EventArgs e)
        {

        }
    }
}