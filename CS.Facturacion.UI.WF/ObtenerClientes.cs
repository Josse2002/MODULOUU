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
    public partial class ObtenerClientes : Form
    {
        public ObtenerClientes()
        {
            InitializeComponent(); //NO BORRAR ESTO DIBUJA LO QUE HAY EN PANTALLA
        }

       

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvObtenerClientes.CurrentRow != null)
                {
                    Cliente _cliente = new Cliente();

                    _cliente.Id = Convert.ToInt64(dgvObtenerClientes.CurrentRow.Cells[0].Value);
                    _cliente.Nombres = dgvObtenerClientes.CurrentRow.Cells[1].Value.ToString();
                    _cliente.Apellidos = dgvObtenerClientes.CurrentRow.Cells[2].Value.ToString();
                    _cliente.FechaNacimiento = Convert.ToDateTime(dgvObtenerClientes.CurrentRow.Cells[3].Value);
                    _cliente.DUI = dgvObtenerClientes.CurrentRow.Cells[4].Value.ToString();
                    _cliente.Municipio = dgvObtenerClientes.CurrentRow.Cells[5].Value.ToString();
                    _cliente.Departamento = dgvObtenerClientes.CurrentRow.Cells[6].Value.ToString();
                    _cliente.Telefono = dgvObtenerClientes.CurrentRow.Cells[7].Value.ToString();
                    _cliente.EMail = dgvObtenerClientes.CurrentRow.Cells[8].Value.ToString();

                    ModificarCliente _form = new ModificarCliente(_cliente);
                    _form.Show();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un registro para modificar.",
                        "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        private void btnObtenerClientes_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBL _clienteBL = new ClienteBL();
                dgvObtenerClientes.DataSource = _clienteBL.ObtenerClientes();
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
        private void dgvObtenerClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvObtenerClientes.CurrentRow != null)
                {
                    Cliente _cliente = new Cliente();

                    _cliente.Id = Convert.ToInt64(dgvObtenerClientes.CurrentRow.Cells[0].Value);
                    _cliente.Nombres = dgvObtenerClientes.CurrentRow.Cells[1].Value.ToString();
                    _cliente.Apellidos = dgvObtenerClientes.CurrentRow.Cells[2].Value.ToString();
                    _cliente.FechaNacimiento = Convert.ToDateTime(dgvObtenerClientes.CurrentRow.Cells[3].Value);
                    _cliente.DUI = dgvObtenerClientes.CurrentRow.Cells[4].Value.ToString();
                    _cliente.Municipio = dgvObtenerClientes.CurrentRow.Cells[5].Value.ToString();
                    _cliente.Departamento = dgvObtenerClientes.CurrentRow.Cells[6].Value.ToString();
                    _cliente.Telefono = dgvObtenerClientes.CurrentRow.Cells[7].Value.ToString();
                    _cliente.EMail = dgvObtenerClientes.CurrentRow.Cells[8].Value.ToString();

                    ModificarCliente _form = new ModificarCliente(_cliente);
                    _form.Show();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un registro para modificar.",
                        "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvObtenerClientes.CurrentRow != null)
                {
                    Cliente _cliente = new Cliente();

                    _cliente.Id = Convert.ToInt64(dgvObtenerClientes.CurrentRow.Cells[0].Value);
                    _cliente.Nombres = dgvObtenerClientes.CurrentRow.Cells[1].Value.ToString();
                    _cliente.Apellidos = dgvObtenerClientes.CurrentRow.Cells[2].Value.ToString();
                    _cliente.FechaNacimiento = Convert.ToDateTime(dgvObtenerClientes.CurrentRow.Cells[3].Value);
                    _cliente.DUI = dgvObtenerClientes.CurrentRow.Cells[4].Value.ToString();
                    _cliente.Municipio = dgvObtenerClientes.CurrentRow.Cells[5].Value.ToString();
                    _cliente.Departamento = dgvObtenerClientes.CurrentRow.Cells[6].Value.ToString();
                    _cliente.Telefono = dgvObtenerClientes.CurrentRow.Cells[7].Value.ToString();
                    _cliente.EMail = dgvObtenerClientes.CurrentRow.Cells[8].Value.ToString();

                    EliminarCliente _form = new EliminarCliente(_cliente);
                    _form.Show();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un registro para eliminar.",
                        "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarCliente _form = new GuardarCliente();
            _form.Show();
        }
    }
}
