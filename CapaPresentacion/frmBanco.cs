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
    public partial class frmBanco : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public ListViewItem.ListViewSubItemCollection SubItems;

        public frmBanco()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCodigo, "Ingrese un número que identifique el banco");
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre o descripción del banco");
            ttMensaje.SetToolTip(txtBuscar, "Debe ingresar el nombre o indicio del banco a buscar");
        }
        //Mostrar mensaje de confirmación
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje,"S&B Control de Inventario",MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            chkEliminar.Checked = false;
        }
        //Habilitar las cajas de textos
        private void Habilitar(bool Valor)
        {
            txtCodigo.ReadOnly = !Valor;
            txtNombre.ReadOnly = !Valor;
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
        private void Mostrar()
        {
            LlenarListView(NBanco.mostrar());
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwBanco.Items.Count);
        }
        //Método para agregar los items al listview
        private void LlenarListView(DataTable dt)
        {

            lvwBanco.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow filas = dt.Rows[i];
                ListViewItem elementos = new ListViewItem("", 1);
                elementos.SubItems.Add(filas["IdBanco"].ToString());
                elementos.SubItems.Add(filas["Descripcion"].ToString());
                lvwBanco.Items.Add(elementos);
            }

        }
        //Método buscarnombre
        private void BuscarNombre()
        {
            LlenarListView(NBanco.BuscarNombre(Convert.ToString(txtBuscar.Text)));
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwBanco.Items.Count);
        }

        private void frmBanco_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void CrearColumnas()
        {
            lvwBanco.View = View.Details;
            lvwBanco.LabelEdit = false;
            lvwBanco.AllowColumnReorder = true;
            lvwBanco.CheckBoxes = false;
            lvwBanco.FullRowSelect = true;
            lvwBanco.GridLines = true;
            lvwBanco.Sorting = SortOrder.Ascending;

            lvwBanco.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwBanco.Columns.Add("Código", 100, HorizontalAlignment.Right);
            lvwBanco.Columns.Add("Nombre", 500, HorizontalAlignment.Left);
            lvwBanco.Columns.Add("Fecha", 0, HorizontalAlignment.Left);
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
            try
            {
                string rpta = "";
                if (txtCodigo.Text == string.Empty | txtNombre.Text == string.Empty)
                {
                    if (txtCodigo.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtCodigo, "Ingrese el código del banco");
                    }
                    if (txtNombre.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtNombre, "Ingrese el nombre del banco");
                    }
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NBanco.Insertar(Convert.ToInt32(txtCodigo.Text),
                            Convert.ToString(txtNombre.Text));
                    }
                    else
                    {
                        rpta = NBanco.Editar(Convert.ToInt32(txtCodigo.Text), 
                            Convert.ToString(txtNombre.Text));
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Text.Equals(""))
            {
                IsEditar = true;
                Botones();
                Habilitar(true);
                txtNombre.Focus();
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
                lvwBanco.CheckBoxes = true;
            }
            else
            {
                lvwBanco.CheckBoxes = false;
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (chkEliminar.Checked == false)
            {
                return;
            }
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea Eliminar estos registros", "Sistema S&B", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Opcion == DialogResult.Yes)
                {
                    string Codigo;
                    string Rpta = "";
                    for (int i = 0; i < lvwBanco.Items.Count; i++)
                    {
                        if (lvwBanco.Items[i].Checked == true)
                        {
                            Codigo = Convert.ToString(lvwBanco.Items[i].SubItems[1].Text);
                            Rpta = NBanco.Eliminar(Convert.ToInt32(Codigo));
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

        private void lvwBanco_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = lvwBanco.SelectedItems[0].SubItems[1].Text;
            txtNombre.Text = lvwBanco.SelectedItems[0].SubItems[2].Text;
            tbcUno.SelectedIndex = 1;
        }
    }
}
