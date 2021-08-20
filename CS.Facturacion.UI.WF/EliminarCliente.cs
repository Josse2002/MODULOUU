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
    public partial class EliminarCliente : Form
    {
        public EliminarCliente()
        {
            InitializeComponent();
        }

        public EliminarCliente(Cliente pCliente)
        {
            InitializeComponent();
            txtId.Text = pCliente.Id.ToString();
            txtNombre.Text = pCliente.Nombres;
            txtApellidos.Text = pCliente.Apellidos;
            dtmCliente.Text = pCliente.FechaNacimiento.ToString();
            txtDUI.Text = pCliente.DUI.ToString();
            txtMunicipio.Text = pCliente.Municipio;
            txtDepartamento.Text = pCliente.Departamento;
            txtTelefono.Text = pCliente.Telefono;
            txtEmail.Text = pCliente.EMail;

        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult _respuesta = MessageBox.Show("Esta seguro de eliminar el registro?",
                    "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_respuesta == DialogResult.Yes)
                {
                    ClienteBL _clienteBL = new ClienteBL();

                    int _resultado = _clienteBL.EliminarCliente(Convert.ToInt64(txtId.Text));

                    if (_resultado != 0)
                    {
                        MessageBox.Show("El cliente se ha eliminado satisfactoriamente",
                    "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
