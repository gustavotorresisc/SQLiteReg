using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imagenes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedPage : ContentPage
    {
        SQLiteConnection database;
        string datoPiker;
        string datoPiker_sem;
        public SelectedPage(object selectedItem)
        {//chido
            InitializeComponent();
            var datos = selectedItem as TESHDatos;
            BindingContext = datos;
            InitializeComponent();
            string db;
            db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
            database = new SQLiteConnection(db);
        }

        private void ButtonActualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {
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
            database.Update(datos);
            Navigation.PushModalAsync(new DetailPageBD());
            DisplayAlert("", "Registro actualzado ✔", "Aceptar");

        }
        private void ButtonEliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {
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
            database.Delete(datos);
            Navigation.PushModalAsync(new DetailPageBD());
            DisplayAlert("", "Registro Eliminado ✔", "Aceptar");
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