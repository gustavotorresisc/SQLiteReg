using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Android.Service.Notification;

namespace imagenes.Droid
{
    [Activity(Label = "imagenes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity,ISQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
           
        {
            var message = string.Empty;
            try
            {//tipo de ddato con el que le vamos a dar autenticacion al usuario MobileServiceAuthenticationProvider
                usuario = await imagenes.DetailPageBD.Cliente.LoginAsync(this,MobileServiceAuthenticationProvider.MicrosoftAccount,"https://tesh.azurebsites.net/.auth/login/facebook/callback");
                if (usuario != null)
                {
                    message = string.Format("Usuario Autenticado{0}.", usuario.UserId);
                    //await new (usuario.UserId, "Bienvenido").ShowAsync();
                    //await new MessageDialog(user.MobileServiceAuthenticationToken, "Token").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                //await new MessageDialog(ex.Message, "Error Message").ShowAsync();
            }
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Resultado de autenticacion");
            builder.Create().Show();
            return usuario;
        }


        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            App.Init((ISQLAzure)this);
            LoadApplication(new App());
        }
    }
}
