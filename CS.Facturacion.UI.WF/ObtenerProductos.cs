using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS.Facturacion.Entities;
using CS.Facturacion.BL;
using System.Data.SqlClient;


namespace CS.Facturacion.UI.WF
{
    public partial class ObtenerProductos : Form
    {
        public ObtenerProductos()
        {
            InitializeComponent();
        }

        #region Obtener Productos de la base de datos con boton y al cargar la app 

        private void btnObtenerProductos_Click(object sender, EventArgs e)
        {
            try
            {
                //INVOCANDO A LOS DATOS DE BL
                ProductoBL _productoBL = new ProductoBL();
                //PASANDOLE LOS DATOS (CONEXION, PRODUCTOS A EL DGV
                dgvObtenerProductos.DataSource = _productoBL.ObtenerProductos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error en la app. "
                    + ex.Message,
                    "Error en la ejecucion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("No se pudo establecer la conexion con el servidor. "
                    + ex.Message,
                    "Error en la ejecucion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Hay un error en el formato de texto ingresado. ",
                     "Error en la ejecucion",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error durante la ejecucion de la consulta. "
                    + ex.Message,
                     "Error en la ejecucion",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerProductos_Load(object sender, EventArgs e)
        {
            try
            {
                //INVOCANDO A LOS DATOS DE BL
                ProductoBL _productoBL = new ProductoBL();
                //PASANDOLE LOS DATOS (CONEXION, PRODUCTOS A EL DGV
                dgvObtenerProductos.DataSource = _productoBL.ObtenerProductos();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error en la app. "
                    + ex.Message,
                    "Error en la ejecucion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("No se pudo establecer la conexion con el servidor. "
                    + ex.Message,
                    "Error en la ejecucion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Hay un error en el formato de texto ingresado. ",
                     "Error en la ejecucion",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error durante la ejecucion de la consulta. "
                    + ex.Message,
                     "Error en la ejecucion",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        #endregion

        #region Editar Productos Click y doble click


        private void btnEditarProductos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvObtenerProductos.CurrentRow != null)
                {
                    Producto _Product = new Producto();

                    _Product.Id = Convert.ToInt64(dgvObtenerProductos.CurrentRow.Cells[0].Value);
                    _Product.Nombre = dgvObtenerProductos.CurrentRow.Cells[1].Value.ToString();
                    _Product.Descripcion = dgvObtenerProductos.CurrentRow.Cells[2].Value.ToString();
                    _Product.Marca = dgvObtenerProductos.CurrentRow.Cells[3].Value.ToString();
                    _Product.Modelo = dgvObtenerProductos.CurrentRow.Cells[4].Value.ToString();
                    _Product.Largo = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[5].Value);
                    _Product.Ancho = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[6].Value);
                    _Product.Alto = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[7].Value);
                    _Product.Talla = dgvObtenerProductos.CurrentRow.Cells[8].Value.ToString();
                    _Product.Color = dgvObtenerProductos.CurrentRow.Cells[9].Value.ToString();
                    _Product.IdProveedor = Convert.ToInt64(dgvObtenerProductos.CurrentRow.Cells[10].Value);

                    EditarProducto _form = new EditarProducto(_Product);

                    _form.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        private void dgvObtenerProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvObtenerProductos.CurrentRow != null)
                {
                    Producto _Product = new Producto();

                    _Product.Id = Convert.ToInt64(dgvObtenerProductos.CurrentRow.Cells[0].Value);
                    _Product.Nombre = dgvObtenerProductos.CurrentRow.Cells[1].Value.ToString();
                    _Product.Descripcion = dgvObtenerProductos.CurrentRow.Cells[2].Value.ToString();
                    _Product.Marca = dgvObtenerProductos.CurrentRow.Cells[3].Value.ToString();
                    _Product.Modelo = dgvObtenerProductos.CurrentRow.Cells[4].Value.ToString();
                    _Product.Largo = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[5].Value);
                    _Product.Ancho = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[6].Value);
                    _Product.Alto = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[7].Value);
                    _Product.Talla = dgvObtenerProductos.CurrentRow.Cells[8].Value.ToString();
                    _Product.Color = dgvObtenerProductos.CurrentRow.Cells[9].Value.ToString();

                    EditarProducto _form = new EditarProducto(_Product);

                    _form.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        private void btnEliminarProductos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvObtenerProductos.CurrentRow != null)
                {
                    Producto _Product = new Producto();

                    _Product.Id = Convert.ToInt64(dgvObtenerProductos.CurrentRow.Cells[0].Value);
                    _Product.Nombre = dgvObtenerProductos.CurrentRow.Cells[1].Value.ToString();
                    _Product.Descripcion = dgvObtenerProductos.CurrentRow.Cells[2].Value.ToString();
                    _Product.Marca = dgvObtenerProductos.CurrentRow.Cells[3].Value.ToString();
                    _Product.Modelo = dgvObtenerProductos.CurrentRow.Cells[4].Value.ToString();
                    _Product.Largo = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[5].Value);
                    _Product.Ancho = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[6].Value);
                    _Product.Alto = Convert.ToDecimal(dgvObtenerProductos.CurrentRow.Cells[7].Value);
                    _Product.Talla = dgvObtenerProductos.CurrentRow.Cells[8].Value.ToString();
                    _Product.Color = dgvObtenerProductos.CurrentRow.Cells[9].Value.ToString();

                    EliminarProducto _form = new EliminarProducto(_Product);

                    _form.Show();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            GuardarProducto _form = new GuardarProducto();
            _form.Show();
        }

       
    }
}
