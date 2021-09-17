using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio.Agenda2;
using Agenda2;

namespace Presentacion.Agenda2
{
    public partial class FrmContactos : Form
    {
        public static ContactosManejador _contactosManejador;
        private Contactos _contacto;
        public FrmContactos()
        {
            InitializeComponent();
            _contactosManejador = new ContactosManejador();
            _contacto = new Contactos();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmModal fm = new FrmModal(this);
            fm.banderaGuardar = "guardar";
            fm.UpdateEventHandler += AgContacto_UpdateEventHandler;
            fm.ShowDialog();

            fm.txtNombre.Focus();
        }

        private void AgContacto_UpdateEventHandler(object sender, FrmModal.UpdateEventArgs args)
        {
            CargarContactos("");
        }
        public void CargarContactos(string filtro)
        {
            dtvDatos.DataSource = _contactosManejador.ObtenerContactos(filtro);
        }

        private void FrmContactos_Load(object sender, EventArgs e)
        {
            CargarContactos("");
        }

        private void btnElminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            CargarContactos("");
        }

        private void Eliminar()
        {
            if (MessageBox.Show("Desea eliminar el usuario seleccionado", "Eliminar contacto", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var contacto = dtvDatos.CurrentRow.Cells["Nombre"].Value.ToString();
                _contactosManejador.EliminarContacto(contacto);
            }



        }

        private void dtvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarContactos("");
        }

        private void dtvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmModal fm = new FrmModal(this);
            fm.txtNombre.Text = dtvDatos.CurrentRow.Cells["nombre"].Value.ToString();
            fm.txtApellidoP.Text = dtvDatos.CurrentRow.Cells["apellidop"].Value.ToString();
            fm.txtApellidoM.Text = dtvDatos.CurrentRow.Cells["apellidom"].Value.ToString();
            fm.txtFecha.Text = dtvDatos.CurrentRow.Cells["fecha"].Value.ToString();
            fm.txtCorreo.Text = dtvDatos.CurrentRow.Cells["correo"].Value.ToString();
            fm.txtTelefono.Text = dtvDatos.CurrentRow.Cells["telefono"].Value.ToString();

            fm.Show();
            fm.banderaGuardar = "actualizar";
            fm.txtNombre.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarContactos(txtBuscar.Text);
        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            CargarContactos("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
