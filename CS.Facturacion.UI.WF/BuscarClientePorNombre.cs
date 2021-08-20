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
    public partial class BuscarClientePorNombre : Form
    {
        public BuscarClientePorNombre()
        {
            InitializeComponent();
        }

        

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (chkbBuscarNombre.Checked)
                {
                    ClienteBL _clienteBL = new ClienteBL();
                    if (txtBuscarCliente.Text.Trim() != "")
                    {
                        dgvBuscarCliente.DataSource = _clienteBL.BuscarClientePorNombres(txtBuscarCliente.Text);
                        
                        
                    }
                    else
                    {
                        dgvBuscarCliente.DataSource = null;
                    }

                }
                else if (chkbBuscarDUI.Checked)
                {
                    //CODIGO DUI
                    
                }
                else
                {
                    MessageBox.Show("Debe Ingresar valores para realizar la busqueda ",
                                        "Error en la aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void chkbBuscarNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbBuscarNombre.Checked)
            {
                chkbBuscarDUI.Enabled = false;

                if (txtBuscarCliente.Enabled == false)
                {
                    txtBuscarCliente.Enabled = true;
                }
            }
            else
            {
                chkbBuscarDUI.Enabled = true;
                if (txtBuscarCliente.Enabled == true)
                {
                    txtBuscarCliente.Enabled = false;
                }
            }
        }

        private void chkbBuscarDUI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbBuscarDUI.Checked)
            {
                chkbBuscarNombre.Enabled = false;

                if (txtBuscarCliente.Enabled == false)
                {
                    txtBuscarCliente.Enabled = true;
                }
            }
            else
            {
                chkbBuscarNombre.Enabled = true;
                if (txtBuscarCliente.Enabled == true)
                {
                    txtBuscarCliente.Enabled = false;
                }
            }
        }

        private void dgvBuscarCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            AgregarFactura.IdCliente = Convert.ToInt64(dgvBuscarCliente.CurrentRow.Cells[0].Value);
            AgregarFactura.NombreCliente = dgvBuscarCliente.CurrentRow.Cells[1].Value.ToString();
            AgregarFactura.ApellidoCliente = dgvBuscarCliente.CurrentRow.Cells[2].Value.ToString();
            AgregarFactura.DireccionCliente = dgvBuscarCliente.CurrentRow.Cells[5].Value.ToString();

            this.Hide();
        }
    }
    }

