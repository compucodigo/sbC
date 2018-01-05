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
    public partial class frmUnidad : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public ListViewItem.ListViewSubItemCollection SubItems;

        public frmUnidad()
        {
            InitializeComponent();            
            ttMensaje.SetToolTip(txtCodigo, "Ingrese un número que identifique la presentación");
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre o descripción  de la presentación");
            ttMensaje.SetToolTip(txtBuscar, "Debe ingresar el nombre o indicio de la presentación a buscar");
            ttMensaje.SetToolTip(chkSerial, "Indica si el producto tiene un serial o código para su venta");
            ttMensaje.SetToolTip(chkI, "Indica si el producto maneja inventario o existencia para su venta");
            ttMensaje.SetToolTip(chkFecha, "Indica si el producto se vende por un rango de días para su venta, es decir si es un servicio por días o horas etc.");
            ttMensaje.SetToolTip(chkDime, "Indica si el producto tiene unas dimensiones para su venta");

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
            chkDime.Checked = false;
            chkEliminar.Checked = false;
            chkFecha.Checked = false;
            chkI.Checked = false;
            chkSerial.Checked = false;
            //btnGuardar.Enabled = false;
            //cmdEliminar.Enabled = false;
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
            LlenarListView(NUnidad.mostrar(1));
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwUnidad.Items.Count);
        }
        //Método para agregar los items al listview
        private void LlenarListView(DataTable dt)
        {
            //DataTable dtUnidad = new DataTable();
            //dtUnidad = NUnidad.mostrar();

            lvwUnidad.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow filas = dt.Rows[i];
                ListViewItem elementos = new ListViewItem("", 1);
                elementos.SubItems.Add(filas["Código"].ToString());
                elementos.SubItems.Add(filas["Descripcion"].ToString());
                elementos.SubItems.Add(filas["Dime"].ToString());
                elementos.SubItems.Add(filas["Fec"].ToString());
                elementos.SubItems.Add(filas["Inve"].ToString());
                elementos.SubItems.Add(filas["Seri"].ToString());
                lvwUnidad.Items.Add(elementos);
            }

        }
        //Método buscarnombre
        private void BuscarNombre()
        {
            LlenarListView(NUnidad.BuscarNombre(Convert.ToString(txtBuscar.Text)));
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwUnidad.Items.Count);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frmUnidad_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void CrearColumnas()
        {
            lvwUnidad.View = View.Details;
            lvwUnidad.LabelEdit = false;
            lvwUnidad.AllowColumnReorder = true;
            lvwUnidad.CheckBoxes = false;
            lvwUnidad.FullRowSelect = true;
            lvwUnidad.GridLines = true;
            lvwUnidad.Sorting = SortOrder.Ascending;

            lvwUnidad.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwUnidad.Columns.Add("Código", 70, HorizontalAlignment.Right);
            lvwUnidad.Columns.Add("Nombre", 200, HorizontalAlignment.Left);
            lvwUnidad.Columns.Add("Dimensión", 70, HorizontalAlignment.Center);
            lvwUnidad.Columns.Add("Fecha", 70, HorizontalAlignment.Center);
            lvwUnidad.Columns.Add("Inventario", 70, HorizontalAlignment.Center);
            lvwUnidad.Columns.Add("Serial", 70, HorizontalAlignment.Center);
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
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NUnidad.Insertar(Convert.ToInt32(txtCodigo.Text), 
                            txtNombre.Text, FechaActual, 
                            Convert.ToInt16(chkDime.Checked), 
                            Convert.ToInt16(chkFecha.Checked), 
                            Convert.ToInt16(chkI.Checked), 
                            Convert.ToInt16(chkSerial.Checked));
                    }
                    else
                    {
                        rpta = NUnidad.Editar(Convert.ToInt32(txtCodigo.Text),
                            txtNombre.Text, FechaActual,
                            Convert.ToInt16(chkDime.Checked),
                            Convert.ToInt16(chkFecha.Checked),
                            Convert.ToInt16(chkI.Checked),
                            Convert.ToInt16(chkSerial.Checked));
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
                lvwUnidad.CheckBoxes = true;
            }
            else
            {
                lvwUnidad.CheckBoxes = false;
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
                    for (int i = 0; i < lvwUnidad.Items.Count; i++)
                    {
                        if(lvwUnidad.Items[i].Checked==true)
                        {
                            Codigo = Convert.ToString(lvwUnidad.Items[i].SubItems[1].Text );
                            Rpta = NUnidad.Eliminar(Convert.ToInt32(Codigo));
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lvwUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwUnidad_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = lvwUnidad.SelectedItems[0].SubItems[1].Text;
            txtNombre.Text = lvwUnidad.SelectedItems[0].SubItems[2].Text;
            //Chech Dimención
            if (lvwUnidad.SelectedItems[0].SubItems[3].Text == "SI")
            {
                chkDime.Checked = true;
            }
            else
            {
                chkDime.Checked = false;
            }
            //Chech Fecha
            if (lvwUnidad.SelectedItems[0].SubItems[4].Text == "SI")
            {
                chkFecha.Checked = true;
            }
            else
            {
                chkFecha.Checked = false;
            }
            //Chech Inventario
            if (lvwUnidad.SelectedItems[0].SubItems[5].Text == "SI")
            {
                chkI.Checked = true;
            }
            else
            {
                chkI.Checked = false;
            }
            //Chech Serial
            if (lvwUnidad.SelectedItems[0].SubItems[6].Text == "SI")
            {
                chkSerial.Checked = true;
            }
            else
            {
                chkSerial.Checked = false;
            }
            tbcUno.SelectedIndex = 1;
        }
    }
}
