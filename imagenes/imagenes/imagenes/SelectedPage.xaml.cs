using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace imagenes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedPage : ContentPage
    {
        public ObservableCollection<_13090371> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090371> Tabla;


        //SQLiteConnection database;
        string datoPiker;
        string datoPiker_sem;
        public SelectedPage(object selectedItem)
        {

            

            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzuteURL);
            Tabla = Cliente.GetTable<_13090371>();
            Tabla.IncludeDeleted();
            //LeerTabla();
            //Tabla.UndeleteAsync(nombre);
            //if (DetailPageBD.usuario.UserId != "Administrador(Id)")
                if (DetailPageBD.usuario == null)
            {
                Entry_Nom.IsEnabled = false;
                Entry_Ape.IsEnabled = false;
                ButtonActualizar.IsVisible = false;
                ButtonEliminar.IsVisible = false;
                ButtonActualizar.IsEnabled = false;
                ButtonEliminar.IsEnabled = false;
            }

            var datos = selectedItem as _13090371;
            BindingContext = datos;
            //InitializeComponent();
            //string db;
            //db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
        }

        private async void ButtonActualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090371
            {
                Id=Entry_Id.Text,
                Nombre = Entry_Nom.Text,
                Apellidos = Entry_Ape.Text,
                Direccion = Entry_Dir.Text,
                Telefono = Entry_Telef.Text,
                Carrera =datoPiker,
                Semestre = datoPiker_sem,
                Matricula =Entry_Matric.Text,
                Correo = Entry_Corre.Text,
                Github = Entry_Git.Text,
            };
            await DetailPageBD.Tabla.UpdateAsync(datos);
            //await Navigation.PushModalAsync(new DetailPageBD());
            await Navigation.PopAsync();
            //database.Update(datos);
            //Navigation.PushModalAsync(new DetailPageBD());
            //DisplayAlert("", "Registro actualzado ✔", "Aceptar");

        }
        private async void ButtonEliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090371
            {
                Id=Entry_Id.Text,
                Nombre = Entry_Nom.Text,
                Apellidos = Entry_Ape.Text,
                Direccion = Entry_Dir.Text,
                Telefono = Entry_Telef.Text,
                Carrera =datoPiker,
                Semestre = datoPiker_sem,
                Matricula =Entry_Matric.Text,
                Correo = Entry_Corre.Text,
                Github = Entry_Git.Text,
            };
            await DetailPageBD.Tabla.DeleteAsync(datos);
            await Navigation.PopAsync();
            //database.Delete(datos);
            //Navigation.PushModalAsync(new DetailPageBD());
            //DisplayAlert("", "Registro Eliminado ✔", "Aceptar");
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

        private void ButtonDeleted_Clicked(object sender, EventArgs e)
        {

        }
    }
}