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
    public partial class FrmProducto : Form
    {
        private ManejadorTienda _manejador;
        private Productos _producto;
        public FrmProducto()
        {
            InitializeComponent();
            _manejador = new ManejadorTienda();
            _producto = new Productos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCrearProducto fp = new FrmCrearProducto(this);
            fp.banGuardar = "guardar";
            fp.UpdateEventHandler += Fp_UpdateEventHandler;
            fp.ShowDialog();
            fp.txtId.Focus();
        }

        private void Fp_UpdateEventHandler(object sender, FrmCrearProducto.UpdateEventArgs args)
        {
            CargarCategorias("");
        }

        public void CargarCategorias(string filtro)
        {
            dtgProducto.DataSource = _manejador.ObtenerCategorias(filtro);
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias("");
        }

        private void Eliminar()
        {
            {
                var categoria = dtgProducto.CurrentRow.Cells["nombre"].Value.ToString();
                _manejador.EliminarCategorias(categoria);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            CargarCategorias("");
        }

        private void dtgProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmCrearProducto cc = new FrmCrearProducto(this);
            cc.banGuardar = "actualizar";
            cc.txtId.Text = dtgProducto.CurrentRow.Cells["idproducto"].Value.ToString();
            cc.txtNombre.Text = dtgProducto.CurrentRow.Cells["nombre"].Value.ToString();
            cc.txtDescripcion.Text = dtgProducto.CurrentRow.Cells["descripcion"].Value.ToString();
            cc.txtPrecio.Text = dtgProducto.CurrentRow.Cells["precio"].Value.ToString();
            cc.ShowDialog();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarCategorias("");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCategorias(txtBuscar.Text);
        }
    }
}
