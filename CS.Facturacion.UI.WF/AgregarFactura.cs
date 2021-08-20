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

namespace CS.Facturacion.UI.WF
{
    public partial class AgregarFactura : Form
    {
        //PARAMETROS CLIENTE
        public static Int64 IdCliente;
        public static string NombreCliente;
        public static string ApellidoCliente;
        public static string DireccionCliente;

        //PARAMETROS PRODUCTO

        public static Int64 IdProducto;
        public static string NombreProducto;
       


        public AgregarFactura()
        {
            InitializeComponent();
        }

        private void txtCodigo_DoubleClick(object sender, EventArgs e)
        {
            BuscarClientePorNombre _form = new BuscarClientePorNombre();
            _form.Show();
        }

        private void AgregarFactura_Activated(object sender, EventArgs e)
        {
            txtCodigo.Text = IdCliente.ToString();
            txtNombre.Text = NombreCliente + "" + ApellidoCliente;
            txtDireccion.Text = DireccionCliente;

            txtNumeroProducto.Text = IdProducto.ToString();
            txtProducto.Text = NombreProducto;
            
           
           
        }

        private void txtNumeroProducto_DoubleClick(object sender, EventArgs e)
        {
            BuscarProductoPorNombre _form = new BuscarProductoPorNombre();
            _form.Show();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                IdCliente = 0;
                NombreCliente = null;
                ApellidoCliente = null;
                DireccionCliente = null;


            }
        }
    }
}
