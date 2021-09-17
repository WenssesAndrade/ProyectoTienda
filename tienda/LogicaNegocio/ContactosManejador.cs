using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Agenda2;
using Agenda2;

namespace LogicaNegocio.Agenda2
{
    public class ContactosManejador
    {
        UsuariosAccesoDatos _usuariosAccesoDatos = new UsuariosAccesoDatos();

        public Tuple<bool, string> ValidarContacto(Contactos contacto)
        {
            bool error = true;
            string cadenaErrores = "";

            if (contacto.Nombre.Length == 0 || contacto.Nombre == null)
            {
                cadenaErrores = cadenaErrores + "El campo Nombre no puede ser vacio \n";
                error = false;
            }

            if (contacto.Apellidop.Length == 0 || contacto.Apellidop == null)
            {
                cadenaErrores = cadenaErrores + "El campo del Apellido paterno no puede ser vacio \n";
                error = false;
            }

            if (contacto.Apellidom.Length == 0 || contacto.Apellidom == null)
            {
                cadenaErrores = cadenaErrores + "El campo del Apellido materno no puede ser vacio \n";
                error = false;
            }

            if (contacto.Fecha.Length == 0 || contacto.Fecha == null)
            {
                cadenaErrores = cadenaErrores + "El campo de la fecha de nacimiento no puede ser vacio \n";
                error = false;
            }

            if (contacto.Correo.Length == 0 || contacto.Correo == null)
            {
                cadenaErrores = cadenaErrores + "El campo del correo no puede ser vacio \n";
                error = false;
            }

            if (contacto.Telefono.Length == 0 || contacto.Telefono == null)
            {
                cadenaErrores = cadenaErrores + "El campo del telefono no puede ser vacio \n";
                error = false;
            }

            /*   if (usuario.Usuario.Length > 10)
               {
                   cadenaErrores = cadenaErrores + "Solo se permiten 10 caracteres para el usuario \n";
                   error = false;
               }*/


            var valida = new Tuple<bool, string>(error, cadenaErrores);
            return valida;
        }

        public void GuardarContacto(Contactos contacto)
        {
            try
            {
                _usuariosAccesoDatos.GuardarContactos(contacto);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Fallo el guardado" + ex.Message);
            }
        }

        public List<Contactos> ObtenerContactos(string filtro)
        {
            var listaContactos = _usuariosAccesoDatos.ObtenerContactos(filtro);
            return listaContactos;
        }

        public void ActualizarContactos(Contactos contacto)
        {
            try
            {
                _usuariosAccesoDatos.ActualizarContactos(contacto);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Fallo la actualizacion" + ex.Message);
            }
        }

        public void EliminarContacto(string contacto)
        {
            try
            {
                _usuariosAccesoDatos.EliminarContacto(contacto);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Fallo la eliminacion" + ex.Message);
            }
        }
    }
}
