using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace imagenes
{
    [Table("MisDatos")]
    public class TESHDatos
    {   

        string nombre;
        string apellidos;
        string direccion;
        string telefono;
        string carrera;
        string semestre;
        string matricula;
        string correo;
        string github;

        [PrimaryKey,MaxLength(50)]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [Column("Nombres"),MaxLength(30)]
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        
        [Column("Apellido"), MaxLength(30)]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        [Column("Telefono"), MaxLength(30)]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        [Column("Carrera"), MaxLength(30)]
        public string Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }

        [Column("Semestre"), MaxLength(30)]
        public string Semestre
        {
            get { return semestre; }
            set { semestre = value; }
        }

        [Column("Matricula"), MaxLength(30)]
        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        [Column("Correo"), MaxLength(30)]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        [Column("Git Hub"), MaxLength(30)]
        public string Github
        {
            get { return github; }
            set { github = value; }
        }
    }
}
