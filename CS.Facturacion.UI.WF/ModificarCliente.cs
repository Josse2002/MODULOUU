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
    public partial class ModificarCliente : Form
    {
        public ModificarCliente()
        {
            InitializeComponent();
        }

        public ModificarCliente(Cliente pCliente)
        {
            InitializeComponent();
           
            txtId.Text = pCliente.Id.ToString();
            txtNombre.Text = pCliente.Nombres.ToString();
            txtApellidos.Text = pCliente.Apellidos.ToString();
            dtmCliente.Text = pCliente.FechaNacimiento.ToShortDateString();
            txtDUI.Text = pCliente.DUI.ToString();
            txtMunicipio.Text = pCliente.Municipio.ToString();
            txtDepartamento.Text = pCliente.Departamento.ToString();
            txtTelefono.Text = pCliente.Telefono.ToString();
            txtEmail.Text = pCliente.EMail.ToString();


        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente _cliente = new Cliente();

                _cliente.Id = Convert.ToInt64(txtId.Text);
                _cliente.Nombres = txtNombre.Text;
                _cliente.Apellidos = txtApellidos.Text;
                _cliente.FechaNacimiento = Convert.ToDateTime(dtmCliente.Text);
                _cliente.DUI = txtDUI.Text;
                _cliente.Municipio = txtMunicipio.Text;
                _cliente.Departamento = txtDepartamento.Text;
                _cliente.Telefono = txtTelefono.Text;
                _cliente.EMail = txtEmail.Text;

                ClienteBL _clienteBL = new ClienteBL();
                int _resultado = _clienteBL.EditarCliente(_cliente);

                if (_resultado != 0)
                {
                    MessageBox.Show("El cliente se ha modificado exitosamente ",
                    "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
