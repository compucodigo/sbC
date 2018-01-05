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
    public partial class frmUbicacion : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public frmUbicacion()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCodigo, "Ingrese un número que identifique la ubicación");
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre o descripción  de la ubicación");
            ttMensaje.SetToolTip(chkStatus, "Indica si la ubicación esta activa para manejar inventario");
            ttMensaje.SetToolTip(chkMovimiento, "Indica si la ubicación maneja inventario o sirve como almacen de destrucción");
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
            chkMovimiento.Checked = false;
        }
        //Habilitar las cajas de textos
        private void Habilitar(bool Valor)
        {
            txtCodigo.ReadOnly = !Valor;
            txtNombre.ReadOnly = !Valor;
            chkMovimiento.Enabled = Valor;
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
            LlenarListView(NUbicacion.mostrar());
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwUbicacion.Items.Count);
        }
        //Método para agregar los items al listview
        private void LlenarListView(DataTable dt)
        {

            lvwUbicacion.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow filas = dt.Rows[i];
                ListViewItem elementos = new ListViewItem("", 1);
                elementos.SubItems.Add(filas["IdUbicacion"].ToString());
                elementos.SubItems.Add(filas["Descripcion"].ToString());
                elementos.SubItems.Add(filas["Movimiento"].ToString());
                elementos.SubItems.Add(filas["Status"].ToString());
                lvwUbicacion.Items.Add(elementos);
            }

        }
        //Método buscarnombre
        private void BuscarNombre()
        {
            LlenarListView(NUbicacion.BuscarNombre(Convert.ToString(txtBuscar.Text)));
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwUbicacion.Items.Count);
        }

        private void frmUbicacion_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void CrearColumnas()
        {
            lvwUbicacion.View = View.Details;
            lvwUbicacion.LabelEdit = false;
            lvwUbicacion.AllowColumnReorder = true;
            lvwUbicacion.CheckBoxes = false;
            lvwUbicacion.FullRowSelect = true;
            lvwUbicacion.GridLines = true;
            lvwUbicacion.Sorting = SortOrder.Ascending;

            lvwUbicacion.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwUbicacion.Columns.Add("Código", 80, HorizontalAlignment.Right);
            lvwUbicacion.Columns.Add("Nombre", 200, HorizontalAlignment.Left);
            lvwUbicacion.Columns.Add("Movimiento", 90, HorizontalAlignment.Left);
            lvwUbicacion.Columns.Add("Activo", 90, HorizontalAlignment.Left);
            lvwUbicacion.Columns.Add("Fecha", 0, HorizontalAlignment.Left);
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
                        errorIcono.SetError(txtCodigo, "Ingrese el código del almacen");
                    }
                    if (txtNombre.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtNombre, "Ingrese el nombre del almacen");
                    }
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NUbicacion.Insertar(Convert.ToInt32(txtCodigo.Text),
                            Convert.ToString(txtNombre.Text), 
                            Convert.ToInt16(chkMovimiento.Checked), 
                            Convert.ToInt16(chkStatus.Checked));
                    }
                    else
                    {
                        rpta = NUbicacion.Editar(Convert.ToInt32(txtCodigo.Text),
                            Convert.ToString(txtNombre.Text),
                            Convert.ToInt16(chkMovimiento.Checked),
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                lvwUbicacion.CheckBoxes = true;
            }
            else
            {
                lvwUbicacion.CheckBoxes = false;
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
                    for (int i = 0; i < lvwUbicacion.Items.Count; i++)
                    {
                        if (lvwUbicacion.Items[i].Checked == true)
                        {
                            Codigo = Convert.ToString(lvwUbicacion.Items[i].SubItems[1].Text);
                            Rpta = NUbicacion.Eliminar(Convert.ToInt32(Codigo));
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

        private void lvwUbicacion_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = lvwUbicacion.SelectedItems[0].SubItems[1].Text;
            txtNombre.Text = lvwUbicacion.SelectedItems[0].SubItems[2].Text;
            //Chech Movimiento
            if (lvwUbicacion.SelectedItems[0].SubItems[3].Text == "SI")
            {
                chkMovimiento.Checked = true;
            }
            else
            {
                chkMovimiento.Checked = false;
            }
            //Chech Status
            if (lvwUbicacion.SelectedItems[0].SubItems[4].Text == "SI")
            {
                chkStatus.Checked = true;
            }
            else
            {
                chkStatus.Checked = false;
            }
            tbcUno.SelectedIndex = 1;
        }

        private void lvwUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
