//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SQLite;
//using Microsoft.WindowsAzure.MobileServices;
//using Newtonsoft.Json;

//namespace imagenes
//{
//    [Table("MisDatos")]
//    public class TESHDatos
//    {
//        string id;
//        string nombre;
//        string apellidos;
//        string direccion;
//        string telefono;
//        string carrera;
//        string semestre;
//        string matricula;
//        string correo;
//        string github;
//        bool deleted;

//        [Column("Id"), MaxLength(30)]
//        public string Id
//        {
//            get { return id; }
//            set { id = value; }
//        }

//        [PrimaryKey,MaxLength(50)]
//        public string Nombre
//        {
//            get { return nombre; }
//            set { nombre = value; }
//        }

//        [Column("Nombres"),MaxLength(30)]
//        public string Apellidos
//        {
//            get { return apellidos; }
//            set { apellidos = value; }
//        }
        
//        [Column("Apellido"), MaxLength(30)]
//        public string Direccion
//        {
//            get { return direccion; }
//            set { direccion = value; }
//        }

//        [Column("Telefono"), MaxLength(30)]
//        public string Telefono
//        {
//            get { return telefono; }
//            set { telefono = value; }
//        }

//        [Column("Carrera"), MaxLength(30)]
//        public string Carrera
//        {
//            get { return carrera; }
//            set { carrera = value; }
//        }

//        [Column("Semestre"), MaxLength(30)]
//        public string Semestre
//        {
//            get { return semestre; }
//            set { semestre = value; }
//        }

//        [Column("Matricula"), MaxLength(30)]
//        public string Matricula
//        {
//            get { return matricula; }
//            set { matricula = value; }
//        }

//        [Column("Correo"), MaxLength(30)]
//        public string Correo
//        {
//            get { return correo; }
//            set { correo = value; }
//        }

//        [Column("Git Hub"), MaxLength(30)]
//        public string Github
//        {
//            get { return github; }
//            set { github = value; }
//        }

//        [JsonProperty(PropertyName ="deleted")]
//        public bool Deleted
//        {
//            get { return deleted; }
//            set { deleted = value; }
//        }
//        //convertir la misma app ahora que guarde en sqlazure
//    }
//}
