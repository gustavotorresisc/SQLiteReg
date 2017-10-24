using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//chido
namespace imagenes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPageBD : ContentPage
    {
        public ObservableCollection<TESHDatos> Items { get; set; }
        SQLiteConnection database;
        

        public DetailPageBD()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
            database = new SQLiteConnection(db);
            database.CreateTable<TESHDatos>();

            Items = new ObservableCollection<TESHDatos>(database.Table<TESHDatos>());
            BindingContext = this;
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new SelectedPage(e.SelectedItem as TESHDatos));
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