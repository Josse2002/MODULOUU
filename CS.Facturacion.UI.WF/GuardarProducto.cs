using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CS.Facturacion.BL;
using CS.Facturacion.Entities;

namespace CS.Facturacion.UI.WF
{
    public partial class GuardarProducto : Form
    {
        public GuardarProducto()
        {
            InitializeComponent();
        }

        private void GuardarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                ProveedorBL _proveedorBL = new ProveedorBL();
                txtNombre.Focus();

                cmbProveedor.DataSource = _proveedorBL.ObtenerProveedor();
                //MOSTRAR LOS CAMPOS DE RAZON SOCIAL EN EL FORMULARIO
                cmbProveedor.DisplayMember = "RazonSocial";
                //EL VALOR QUE SE VA A SELECCIONAR POR ENCIMA DE RAZON SOCIAL, EL ID QUE SE VA A MANDAR
                cmbProveedor.ValueMember = "Id";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtAlto.Clear();
            txtAncho.Clear();
            txtLargo.Clear();
            txtTalla.Clear();
            txtColor.Clear();

            GuardarProducto_Load(sender, e);
            txtNombre.Focus();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
               
                Producto _Producto = new Producto();
                ProductoBL _ProductoBL = new ProductoBL();

                if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtMarca.Text == "" ||
                    txtModelo.Text == "" || txtLargo.Text == "" || txtAncho.Text == "" || txtAlto.Text == "" ||
                    txtColor.Text == "")
                {
                     MessageBox.Show("Verifique los campos, no pueden quedar vacios",
                        "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    _Producto.Nombre = txtNombre.Text;
                    _Producto.Descripcion = txtDescripcion.Text;
                    _Producto.Marca = txtMarca.Text;
                    _Producto.Modelo = txtModelo.Text;
                    _Producto.Largo = Convert.ToDecimal(txtLargo.Text.Trim());
                    _Producto.Ancho = Convert.ToDecimal(txtAncho.Text.Trim());
                    _Producto.Alto = Convert.ToDecimal(txtAlto.Text.Trim());
                    _Producto.Talla = txtTalla.Text;
                    _Producto.Color = txtColor.Text;
                    _Producto.IdProveedor = Convert.ToInt64(cmbProveedor.SelectedValue);



                    int _resultado = _ProductoBL.AgregarProducto(_Producto);

                    if (_resultado != 0)
                    {
                        MessageBox.Show("El cliente se ha guardado exitosamente ",
                        "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnLimpiar_Click(sender, e);
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
