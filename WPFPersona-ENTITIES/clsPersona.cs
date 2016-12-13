using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPersona_ENTITIES
{
    public class clsPersona
    {
        //Atributos
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }

        //Constructores
        public clsPersona()
        {
            Id = 0;
            Nombre = "";
            Apellidos = "";
            FechaNac = DateTime.Now;
            Direccion = "";
            Telefono = "";
        }

        public clsPersona(int id, String nombre, String apellidos, DateTime fechaNac, String direccion, String telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            FechaNac = fechaNac;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
