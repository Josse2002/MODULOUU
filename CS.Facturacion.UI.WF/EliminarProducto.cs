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
    public partial class EliminarProducto : Form
    {
        public EliminarProducto()
        {
            InitializeComponent();
        }

        public EliminarProducto(Producto _producto)
        {
            InitializeComponent();
            txtId.Text = _producto.Id.ToString();
            txtNombre.Text = _producto.Nombre.ToString();
            txtDescripcion.Text = _producto.Descripcion.ToString();
            txtMarca.Text = _producto.Marca.ToString();
            txtModelo.Text = _producto.Modelo.ToString();
            txtLargo.Text = _producto.Largo.ToString();
            txtAncho.Text = _producto.Ancho.ToString();
            txtAlto.Text = _producto.Alto.ToString();
            txtTalla.Text = _producto.Talla.ToString();
            txtColor.Text = _producto.Color.ToString();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult _respuesta = MessageBox.Show("Esta seguro de eliminar el registro?",
                   "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_respuesta == DialogResult.Yes)
                {
                   ProductoBL _productoBL = new ProductoBL();

                    int _resultado = _productoBL.EliminarProducto(Convert.ToInt64(txtId.Text));

                    if (_resultado != 0)
                    {
                        MessageBox.Show("El cliente se ha eliminado satisfactoriamente",
                    "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ActiveForm.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error en la aplicacion: " + ex.Message,
                    "Error en la aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("Ha ocurrido un error en los campos: " + ex.Message,
                    "Error en la aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ha ocurrido un error en la aplicacion: " + ex.Message,
                    "Error en la aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en la aplicacion: " + ex.Message,
                    "Error en la aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
