using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Agenda2;

namespace AccesoDatos.Agenda2
{
    public class UsuariosAccesoDatos
    {
        ConexionAccesoDatos _conexion;
        public UsuariosAccesoDatos()
        {

            try
            {
                _conexion = new ConexionAccesoDatos("localhost", "root", "123456789", "agenda", 3306);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fallo la conexion" + ex.Message);
            }
        }


        public void GuardarContactos(Contactos contacto)
        {
            try
            {
                string consulta = string.Format("insert into contactos values('{0}','{1}','{2}','{3}','{4}','{5}')",
                    contacto.Nombre, contacto.Apellidop, contacto.Apellidom, contacto.Fecha, contacto.Correo, contacto.Telefono);
                _conexion.EjecutarConsulta(consulta);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Fallo el guardado" + ex.Message);
            }
        }

        public void EliminarContacto(string contacto)
        {
            try
            {
                string consulta = string.Format("delete from contactos where Nombre ='{0}'", contacto);
                _conexion.EjecutarConsulta(consulta);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Fallo la eliminacion" + ex.Message);
            }
        }

        public void ActualizarContactos(Contactos contacto)
        {
            try
            {
                string consulta = string.Format("update contactos set Apellidop = '{0}', Apellidom = '{1}', Fechanacimiento = '{2}',Correo = '{3}',Telefono = '{4}' where Nombre = '{5}'", contacto.Apellidop,
                contacto.Apellidom, contacto.Fecha, contacto.Correo, contacto.Telefono, contacto.Nombre);
                _conexion.EjecutarConsulta(consulta);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Fallo la actualizacion" + ex.Message);
            }
        }

        public List<Contactos> ObtenerContactos(string filtro)
        {
            var ListaContactos = new List<Contactos>();
            var ds = new DataSet();
            string consulta = string.Format("select * from contactos where Nombre like '%{0}%'", filtro);
            ds = _conexion.ObtenerDatos(consulta, "contactos");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                //var usuario = new Usuarios();
                //usuario.Usuario = row["usuario"].ToString();
                //usuario.Contrasenia = row["contrasenia"].ToString();

                var contacto = new Contactos
                {
                    Nombre = row["nombre"].ToString(),
                    Apellidop = row["apellidop"].ToString(),
                    Apellidom = row["apellidom"].ToString(),
                    Fecha = row["fechanacimiento"].ToString(),
                    Correo = row["correo"].ToString(),
                    Telefono = row["telefono"].ToString()
                };


                ListaContactos.Add(contacto);

            }

            return ListaContactos;
        }
    }
}
