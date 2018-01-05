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
    public partial class frmImpuesto : Form
    {
        private bool IsNuevo = false;
        public ListViewItem.ListViewSubItemCollection SubItems;

        public frmImpuesto()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre del impuesto");
            ttMensaje.SetToolTip(txtMonto, "Ingrese el monto en porcentaje del impuesto");
        }
        //Mostrar mensaje de confirmación
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "S&B Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "S&B Control de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // Limpiar formulario
        private void LimpiarFrm()
        {
            txtBuscar.Text = string.Empty;            
            txtNombre.Text = string.Empty;
            txtMonto.Text = string.Empty;
            chkEliminar.Checked = false;
        }
        //Habilitar las cajas de textos
        private void Habilitar(bool Valor)
        {
            txtNombre.ReadOnly = !Valor;
            txtMonto.ReadOnly = !Valor;
        }
        private void Botones()
        {
            if (IsNuevo)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }                        
        }
        // Metodo ocultar columnas
        private void Mostrar()
        {
            LlenarListView(NImpuesto.mostrar());
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwImpuesto.Items.Count);
        }
        //Método para agregar los items al listview
        private void LlenarListView(DataTable dt)
        {
            lvwImpuesto.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow filas = dt.Rows[i];
                ListViewItem elementos = new ListViewItem("", 1);
                elementos.SubItems.Add(filas["IdImpuesto"].ToString());
                elementos.SubItems.Add(filas["Descripcion"].ToString());
                elementos.SubItems.Add(filas["Monto"].ToString());
                lvwImpuesto.Items.Add(elementos);
            }

        }
        private void frmImpuesto_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void CrearColumnas()
        {
            lvwImpuesto.View = View.Details;
            lvwImpuesto.LabelEdit = false;
            lvwImpuesto.AllowColumnReorder = true;
            lvwImpuesto.CheckBoxes = false;
            lvwImpuesto.FullRowSelect = true;
            lvwImpuesto.GridLines = true;
            lvwImpuesto.Sorting = SortOrder.Ascending;

            lvwImpuesto.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwImpuesto.Columns.Add("Código", 0, HorizontalAlignment.Right);
            lvwImpuesto.Columns.Add("Nombre", 200, HorizontalAlignment.Left);
            lvwImpuesto.Columns.Add("Monto", 150, HorizontalAlignment.Left);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            Botones();
            LimpiarFrm();
            Habilitar(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (txtMonto.Text == string.Empty | txtNombre.Text == string.Empty)
                {
                    if (txtMonto.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtMonto, "Ingrese el porcentaje del impuesto");
                    }
                    if (txtNombre.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtNombre, "Ingrese el nombre del impuesto");
                    }
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NImpuesto.Insertar(Convert.ToString(txtNombre.Text),
                            Convert.ToInt32(txtMonto.Text));
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (IsNuevo)
                        {
                            MensajeOk("El registro fue ingresado con exito");
                        }
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                    IsNuevo = false;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            Botones();
            LimpiarFrm();
            Habilitar(false);
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {

        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
