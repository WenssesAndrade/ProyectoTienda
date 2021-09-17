using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agenda2;
using LogicaNegocio.Agenda2;

namespace Presentacion.Agenda2
{
    public partial class FrmCrearProducto : Form
    {
        private ManejadorTienda _manejador;
        private Productos _producto;
        public string banGuardar;
        public FrmCrearProducto(FrmProducto frmProducto)
        {
            InitializeComponent();
            _manejador = new ManejadorTienda();
            _producto = new Productos();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (banGuardar == "guardar")
            {
                GuardarUsuario();
                Agregard();
                Close();
            }    
            else
            {
                ActualizarUsuario();
                Close();
            }
        }

        private void GuardarUsuario()
        {
            _producto.IdProducto = int.Parse(txtId.Text);
            _producto.Nombre = txtNombre.Text;
            _producto.Precio = int.Parse(txtPrecio.Text);

            var valida = _manejador.ValidarCategorias(_producto);

            if(valida.Item1)
            {
                _manejador.GuardarCategorias(_producto);
            }

            else
            {
                MessageBox.Show(valida.Item2, "Ocurrio un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   

        private void ActualizarUsuario()
        {
            _manejador.ActualizarCategorias(new Productos
            {
                IdProducto = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = int.Parse(txtPrecio.Text)
            });
        }
    }
}
