using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda2
{
    public class Contactos
    {
        private string _nombre;
        private string _apellidop;
        private string _apellidom;
        private string _fecha;
        private string _correo;
        private string _telefono;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellidop { get => _apellidop; set => _apellidop = value; }
        public string Apellidom { get => _apellidom; set => _apellidom = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
    }
}
