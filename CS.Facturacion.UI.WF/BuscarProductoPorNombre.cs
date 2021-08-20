using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS.Facturacion.BL;
using CS.Facturacion.Entities;
using System.Data.SqlClient;

namespace CS.Facturacion.UI.WF
{
    public partial class BuscarProductoPorNombre : Form
    {
        public BuscarProductoPorNombre()
        {
            InitializeComponent();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            ProductoBL _ProductoBL = new ProductoBL();

            if (txtBuscarProducto.Text.Trim() != "")
            {
                dgvBuscarProducto.DataSource = _ProductoBL.BuscarProductoPorNombre(txtBuscarProducto.Text);
            }
            else
            {
                dgvBuscarProducto.DataSource = _ProductoBL.ObtenerProductos();
            }
            
        }

        private void BuscarProductoPorNombre_Load(object sender, EventArgs e)
        {
            ProductoBL _ProductoBL = new ProductoBL();
            dgvBuscarProducto.DataSource = _ProductoBL.ObtenerProductos();
        }

        private void dgvBuscarProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AgregarFactura.IdProducto = Convert.ToInt64(dgvBuscarProducto.CurrentRow.Cells[0].Value);
            AgregarFactura.NombreProducto = dgvBuscarProducto.CurrentRow.Cells[1].Value.ToString();

            this.Hide();
        }
    }
}
