using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;


namespace CapaPresentacion
{
    public partial class frmVendedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmVendedor()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCodigo, "Ingrese un número que identifique la presentación");
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre o descripción  de la presentación");
            ttMensaje.SetToolTip(txtBuscar, "Debe ingresar el nombre o indicio de la presentación a buscar");
            ttMensaje.SetToolTip(txtPorc, "Debe ingresar el monto de la comición así sea cero 0");

        }
        //Mostrar mensaje de confirmación
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "S&B Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrat mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "S&B Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // Limpiar formulario
        private void LimpiarFrm()
        {
            txtBuscar.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPorc.Text = string.Empty;
        }
        //Habilitar las cajas de textos
        private void Habilitar(bool Valor)
        {
            txtCodigo.ReadOnly = !Valor;
            txtNombre.ReadOnly = !Valor;
            txtPorc.ReadOnly = !Valor;
        }
        private void Botones()
        {
            if (IsNuevo || IsEditar)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
        }
        // Metodo ocultar columnas
        private void OcultarColumnas()
        {
            dgvVendedor.Columns[0].Visible = false;            
        }
        private void Mostrar()
        {
            dgvVendedor.DataSource = NVendedor.mostrar();
            OcultarColumnas();
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(dgvVendedor.Rows.Count);
        }
        //Método buscarnombre
        private void BuscarNombre()
        {
            dgvVendedor.DataSource = NVendedor.BuscarNombre(Convert.ToString(txtBuscar.Text));
            OcultarColumnas();
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(dgvVendedor.Rows.Count);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmVendedor_Load_1(object sender, EventArgs e)
        {
            Mostrar();
            Habilitar(false);
            Botones();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            LimpiarFrm();
            Habilitar(true);
            txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime FechaActual = DateTime.Now;
            try
            {
                string rpta = "";
                if (txtCodigo.Text==string.Empty | txtNombre.Text==string.Empty) 
                {
                    if (txtCodigo.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtCodigo, "Ingrese el código de la presentación");
                    }
                    if (txtNombre.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtNombre, "Ingrese el nombre de la presentación");
                    }
                    if (txtPorc.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtNombre, "Ingrese el porcentaje de comisión del vendedor así sea cero 0");
                    }
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NVendedor.Insertar(Convert.ToInt32(txtCodigo.Text), txtNombre.Text, Convert.ToInt32(txtPorc.Text));
                    }
                    else
                    {
                        rpta = NVendedor.Editar(Convert.ToInt32(txtCodigo.Text),
                            txtNombre.Text, Convert.ToInt32(txtPorc.Text));
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (IsNuevo)
                        {
                            MensajeOk("El registro fue ingresado con exito");
                        }
                        else
                        {
                            MensajeOk("El registro fue modificado con exito");
                        }
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                    IsNuevo = false;
                    IsEditar = false;
                    Botones();
                    LimpiarFrm();
                    Mostrar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvVendedor_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = Convert.ToString(dgvVendedor.CurrentRow.Cells[1].Value);
            txtNombre.Text = Convert.ToString(dgvVendedor.CurrentRow.Cells[2].Value);
            txtPorc.Text = Convert.ToString(dgvVendedor.CurrentRow.Cells[3].Value);
            tbcUno.SelectedIndex = 1;
        }

        private void dgvVendedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvVendedor.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dgvVendedor.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Equals(""))
            {
                IsEditar = true;
                Botones();
                Habilitar(true);
            }
            else
            {
                MensajeError("Debe seleccionar registro a editar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            Botones();
            LimpiarFrm();
            Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                dgvVendedor.Columns[0].Visible = true;
            }
            else
            {
                dgvVendedor.Columns[0].Visible = false;
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea Eliminar estos registros", "Sistema S&B", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dgvVendedor.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVendedor.Eliminar(Convert.ToInt32(Codigo));
                            if (Rpta.Equals("OK"))
                            {
                                MensajeOk("El Registro se Eliminó con Exito");
                            }
                            else
                            {
                                MensajeError(Rpta);
                            }
                        }
                    }
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
