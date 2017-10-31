using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace imagenes
{
    public interface ISQLAzure
    {
        Task<MobileServiceUser> Authenticate();

    }
}
