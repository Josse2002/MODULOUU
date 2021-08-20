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
    public partial class EditarProducto : Form
    {
        public EditarProducto()
        {
            InitializeComponent();
        }

        public EditarProducto(Producto _producto)
        {
            //CONSTRUCTOR
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
            txtIdProveedor.Text = _producto.IdProveedor.ToString();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                Producto _producto = new Producto();

                _producto.Id = Convert.ToInt64(txtId.Text);
                _producto.Nombre = txtNombre.Text;
                _producto.Descripcion = txtDescripcion.Text;
                _producto.Marca = txtMarca.Text;
                _producto.Modelo = txtModelo.Text;
                _producto.Largo = Convert.ToDecimal(txtLargo.Text);
                _producto.Ancho = Convert.ToDecimal(txtAncho.Text);
                _producto.Alto = Convert.ToDecimal(txtAlto.Text);
                _producto.Talla = txtTalla.Text;
                _producto.Color = txtColor.Text;
                _producto.IdProveedor = Convert.ToInt64(txtIdProveedor.Text);

                ProductoBL _productoBL = new ProductoBL();

                int resultado = _productoBL.EditarProducto(_producto);

                if (resultado != 0)
                {
                    MessageBox.Show("El producto se ha modificado exitosamente ",
                    "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EditarProducto _form = new EditarProducto();
                    ActiveForm.Close();
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
