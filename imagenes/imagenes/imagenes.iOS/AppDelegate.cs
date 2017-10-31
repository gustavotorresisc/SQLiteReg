using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace imagenes.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate,ISQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            {//tipo de ddato con el que le vamos a dar autenticacion al usuario MobileServiceAuthenticationProvider
                usuario = await imagenes.DetailPageBD.Cliente.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController,MobileServiceAuthenticationProvider.Facebook, "https://tesh.azurebsites.net/.auth/login/facebook/callback");
                if (usuario != null)
                {
                    message = string.Format("usuario autenticado {0}.", usuario.UserId);
                    //await new MessageDialog(usuario.UserId, "Bienvenido").ShowAsync();
                    //await new MessageDialog(user.MobileServiceAuthenticationToken, "Token").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                //await new MessageDialog(ex.Message, "Error Message").ShowAsync();
            }
            UIAlertView avAlert = new UIAlertView("resultado de autenticacion", message, null, "ok", null);
            avAlert.Show();
            return usuario;
        }
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            App.Init(this);//inicializar la app
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
