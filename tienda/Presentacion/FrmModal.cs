using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio.Agenda2;
using Agenda2;

namespace Presentacion.Agenda2
{
    public partial class FrmModal : Form
    {
        private ContactosManejador _contactosManejador;
        private Contactos _contactos;
        public string banderaGuardar;


        // private string banderaGuardar;
        public static FrmContactos fs = new FrmContactos();
        public FrmModal(FrmContactos registro)
        {
            InitializeComponent();
            _contactosManejador = new ContactosManejador();
            _contactos = new Contactos();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void Agregard()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Botonera(Boolean guardar, Boolean cancelar)
        {

            btnGuardar.Enabled = guardar;
            btnCancelar.Enabled = cancelar;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (banderaGuardar == "guardar")
            {
                GuardarContacto();
                Agregard();
                Close();
            }

            else
            {
                ActualizarContactos();

                Close();
            }

            Botonera(true, true);
            LimpiarCuadros();
            Cuadros(false, false, false, false, false, false);
        }

        private void Cuadros(Boolean nombre, Boolean apellidop, Boolean apellidom, Boolean fecha, Boolean correo, Boolean telefono)
        {
            txtNombre.Enabled = nombre;
            txtApellidoP.Enabled = apellidop;
            txtApellidoM.Enabled = apellidom;
            txtFecha.Enabled = fecha;
            txtCorreo.Enabled = correo;
            txtTelefono.Enabled = telefono;

        }

        private void GuardarContacto()
        {
            _contactos.Nombre = txtNombre.Text;
            _contactos.Apellidop = txtApellidoP.Text;
            _contactos.Apellidom = txtApellidoM.Text;
            _contactos.Fecha = txtFecha.Text;
            _contactos.Correo = txtCorreo.Text;
            _contactos.Telefono = txtTelefono.Text;

            var valida = _contactosManejador.ValidarContacto(_contactos);

            if (valida.Item1)
            {
                _contactosManejador.GuardarContacto(_contactos);
            }

            else
            {
                MessageBox.Show(valida.Item2, "Ocurrio un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LimpiarCuadros()
        {
            txtNombre.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtFecha.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }

        private void ActualizarContactos()
        {
            _contactosManejador.ActualizarContactos(new Contactos
            {
                Nombre = txtNombre.Text,
                Apellidop = txtApellidoP.Text,
                Apellidom = txtApellidoM.Text,
                Fecha = txtFecha.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text
            });
        }
    }
}
