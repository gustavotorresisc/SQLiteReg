using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imagenes
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {
      /*  Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
              { "Sistemas", Color.Aqua },
            { "Biologia", Color.Black },
        };*/

        SQLiteConnection database;
        string datoPiker;
        string datoPiker_sem;
        public InsertPage()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<isqlite>().GetLocalFilePath("TESHDB0.db");
            database = new SQLiteConnection(db);
            database.CreateTable<TESHDatos>();

            //var monkeyList = new List<string>();
            //monkeyList.Add("Baboon");
            //monkeyList.Add("Capuchin Monkey");
            //monkeyList.Add("Blue Monkey");
            //monkeyList.Add("Squirrel Monkey");
            //monkeyList.Add("Golden Lion Tamarin");
            //monkeyList.Add("Howler Monkey");
            //monkeyList.Add("Japanese Macaque");

            //var picker = new Picker { Title = "Select a monkey" };
            //picker.ItemsSource = monkeyList;
        }

        /* Picker carrera = new Picker
         {
             //Title = "Carrera",

             VerticalOptions = LayoutOptions.CenterAndExpand
         };*/

        /* foreach (string colorName in nameToColor.Keys)
         {
             picker.Items.Add(colorName);
         }

      this.Content = new StackLayout
      {
              Children =
             {
               // header,
                 picker,
                // boxView
             }
      };*/
        private void Insertar_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {
                Nombre = Entry_Nom.Text,
                Apellidos = Entry_Ape.Text,
                Direccion = Entry_Dir.Text,
                Telefono = Entry_Tel.Text,
                Carrera = datoPiker,
               // Carrera = Entry_carr.Text,
                Semestre = datoPiker_sem,
                Matricula = Entry_Matric.Text ,
                Correo = Entry_Cor.Text,
                Github = Entry_Git.Text,
            };
            database.Insert(datos);
            Navigation.PushModalAsync(new DetailPageBD());

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