using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace imagenes
{
    [Table("_13090371")]
    public class _13090371
    {
            string id;
            string nombre;
            string apellidos;
            string direccion;
            string telefono;
            string carrera;
            string semestre;
            string matricula;
            string correo;
            string github;
            bool deleted;

            [JsonProperty(PropertyName = "id")]
            public string Id
            {
                get { return id; }
                set { id = value; }
            }

            [JsonProperty(PropertyName = "nombre")]
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            [JsonProperty(PropertyName = "apellidos")]
            public string Apellidos
            {
                get { return apellidos; }
                set { apellidos = value; }
            }

            [JsonProperty(PropertyName = "direccion")]
            public string Direccion
            {
                get { return direccion; }
                set { direccion = value; }
            }

            [JsonProperty(PropertyName = "telefono")]
            public string Telefono
            {
                get { return telefono; }
                set { telefono = value; }
            }

            [JsonProperty(PropertyName = "carrera")]
            public string Carrera
            {
                get { return carrera; }
                set { carrera = value; }
            }

            [JsonProperty(PropertyName = "semestre")]
            public string Semestre
            {
                get { return semestre; }
                set { semestre = value; }
            }

            [JsonProperty(PropertyName = "matricula")]
            public string Matricula
            {
                get { return matricula; }
                set { matricula = value; }
            }

            [JsonProperty(PropertyName = "correo")]
            public string Correo
            {
                get { return correo; }
                set { correo = value; }
            }

            [JsonProperty(PropertyName = "github")]
            public string Github
            {
                get { return github; }
                set { github = value; }
            }

             [JsonProperty(PropertyName = "deleted")]
            public bool Deleted
            {
                get { return deleted; }
                set { deleted = value; }
            }
    }
}
