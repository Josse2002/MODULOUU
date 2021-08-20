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
    public partial class GuardarCliente : Form
    {
        public GuardarCliente()
        {
            InitializeComponent();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente _cliente = new Cliente();
                _cliente.Nombres = txtNombre.Text;
                _cliente.Apellidos = txtApellidos.Text;
                _cliente.FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Text);
                _cliente.DUI = txtDUI.Text;
                _cliente.Municipio = txtMunicipio.Text;
                _cliente.Departamento = cmbDepartamento.SelectedItem.ToString();
                _cliente.Telefono = txtTelefono.Text;
                _cliente.EMail = txtEmail.Text;

                ClienteBL _clienteBL = new ClienteBL();
                int _resultado = _clienteBL.AgregarCliente(_cliente);

                if (_resultado != 0)
                {
                    MessageBox.Show("El cliente se ha guardado exitosamente ",
                    "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    txtDUI.Text = "";
                    txtMunicipio.Text = "";
                    cmbDepartamento.Text = "";
                    txtMunicipio.Text = "";
                    txtTelefono.Text = "";
                    txtEmail.Text = "";

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
