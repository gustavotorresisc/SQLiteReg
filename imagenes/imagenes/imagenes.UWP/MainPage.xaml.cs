using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;//ventanas emergentes

namespace imagenes.UWP
{
    public sealed partial class MainPage: ISQLAzure
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            try
            {//tipo de ddato con el que le vamos a dar autenticacion al usuario MobileServiceAuthenticationProvider
                usuario = await imagenes.DetailPageBD.Cliente.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount, true);
                if (usuario != null)
                {
                    await new MessageDialog(usuario.UserId, "Bienvenido").ShowAsync();
                    //await new MessageDialog(user.MobileServiceAuthenticationToken, "Token").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message, "Error Message").ShowAsync();
            }
            return usuario;
        }
    

    
        public MainPage()
        {
            this.InitializeComponent();
            imagenes.App.Init((ISQLAzure)this);
            LoadApplication(new imagenes.App());
        }
    }
}
