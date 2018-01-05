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
    public partial class frmClasificacion : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmClasificacion()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCodigo, "Ingrese un número que identifique la clasificación");
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre o descripción  de la clasificación");
            ttMensaje.SetToolTip(chkStatus, "Indica si la Clasificación esta activa");            
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
            chkStatus.Checked = false;
        }
        //Habilitar las cajas de textos
        private void Habilitar(bool Valor)
        {
            txtCodigo.ReadOnly = !Valor;
            txtNombre.ReadOnly = !Valor;
            chkStatus.Enabled = Valor;
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
            LlenarListView(NClasificacion.mostrar());
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwClasificacion.Items.Count);
        }
        //Método para agregar los items al listview
        private void LlenarListView(DataTable dt)
        {

            lvwClasificacion.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow filas = dt.Rows[i];
                ListViewItem elementos = new ListViewItem("", 1);
                elementos.SubItems.Add(filas["IdClasificacion"].ToString());
                elementos.SubItems.Add(filas["Descripcion"].ToString());
                elementos.SubItems.Add(filas["Fecha"].ToString());
                elementos.SubItems.Add(filas["Status"].ToString());
                lvwClasificacion.Items.Add(elementos);
            }
        }
        //Método buscarnombre
        private void BuscarNombre()
        {
            LlenarListView(NClasificacion.BuscarNombre(Convert.ToString(txtBuscar.Text)));
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwClasificacion.Items.Count);
        }
        private void frmClasificacion_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void CrearColumnas()
        {
            lvwClasificacion.View = View.Details;
            lvwClasificacion.LabelEdit = false;
            lvwClasificacion.AllowColumnReorder = true;
            lvwClasificacion.CheckBoxes = false;
            lvwClasificacion.FullRowSelect = true;
            lvwClasificacion.GridLines = true;
            lvwClasificacion.Sorting = SortOrder.Ascending;

            lvwClasificacion.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwClasificacion.Columns.Add("Código", 90, HorizontalAlignment.Right);
            lvwClasificacion.Columns.Add("Nombre", 250, HorizontalAlignment.Left);
            lvwClasificacion.Columns.Add("Fecha", 0, HorizontalAlignment.Left);
            lvwClasificacion.Columns.Add("Activo", 90, HorizontalAlignment.Center);            
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
                        errorIcono.SetError(txtCodigo, "Ingrese el código de la clasificación");
                    }
                    if (txtNombre.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtNombre, "Ingrese el nombre de la clasificación");
                    }
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NClasificacion.Insertar(Convert.ToInt32(txtCodigo.Text),
                            Convert.ToString(txtNombre.Text),
                            Convert.ToInt16(chkStatus.Checked));
                    }
                    else
                    {
                        rpta = NClasificacion.Editar(Convert.ToInt32(txtCodigo.Text),
                            Convert.ToString(txtNombre.Text),
                            Convert.ToInt16(chkStatus.Checked));
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
                    for (int i = 0; i < lvwClasificacion.Items.Count; i++)
                    {
                        if (lvwClasificacion.Items[i].Checked == true)
                        {
                            Codigo = Convert.ToString(lvwClasificacion.Items[i].SubItems[1].Text);
                            Rpta = NClasificacion.Eliminar(Convert.ToInt32(Codigo));
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                lvwClasificacion.CheckBoxes = true;
            }
            else
            {
                lvwClasificacion.CheckBoxes = false;
            }
        }

        private void lvwClasificacion_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = lvwClasificacion.SelectedItems[0].SubItems[1].Text;
            txtNombre.Text = lvwClasificacion.SelectedItems[0].SubItems[2].Text;
            //Chech Status
            if (lvwClasificacion.SelectedItems[0].SubItems[4].Text == "SI")
            {
                chkStatus.Checked = true;
            }
            else
            {
                chkStatus.Checked = false;
            }
            tbcUno.SelectedIndex = 1;
        }
    }
}
