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
    public partial class frmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public ListViewItem.ListViewSubItemCollection SubItems;

        public frmCliente()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCodigo, "Ingrese un número que identifique el cliente");
            ttMensaje.SetToolTip(txtRif, "Ingrese el numero de RIF del cliente");
            ttMensaje.SetToolTip(txtRazon, "Ingrese el nombre o la razón social del cliente");
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
            txtRif.Text = string.Empty;
            txtRazon.Text = string.Empty;
            txtContacto.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtWeb.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            chkActivo.Checked = false;
        }
        //Habilitar las cajas de textos
        private void Habilitar(bool Valor)
        {
            txtCodigo.ReadOnly = !Valor;
            txtRif.ReadOnly = !Valor;
            txtRazon.ReadOnly = !Valor;
            txtContacto.ReadOnly = !Valor;
            txtTelefono.ReadOnly = !Valor;
            txtDireccion.ReadOnly = !Valor;
            txtCorreo.ReadOnly = !Valor;
            txtFax.ReadOnly = !Valor;
            txtWeb.ReadOnly = !Valor;
            txtObservacion.ReadOnly = !Valor;
            rbGobierno.Enabled = Valor;
            rbJuridico.Enabled = Valor;
            rbNatural.Enabled = Valor;
            chkActivo.Enabled = Valor;
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
            LlenarListView(NCliente.mostrar());
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwCliente.Items.Count);
        }
        //Método para agregar los items al listview
        private void LlenarListView(DataTable dt)
        {
            //DataTable dtUnidad = new DataTable();
            //dtUnidad = NUnidad.mostrar();

            lvwCliente.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow filas = dt.Rows[i];
                ListViewItem elementos = new ListViewItem("", 1);
                elementos.SubItems.Add(filas["Idcliente"].ToString());
                elementos.SubItems.Add(filas["Rif"].ToString());
                elementos.SubItems.Add(filas["Razon"].ToString());
                elementos.SubItems.Add(filas["Contacto"].ToString());
                elementos.SubItems.Add(filas["Telefono"].ToString());
                elementos.SubItems.Add(filas["Direccion"].ToString());
                elementos.SubItems.Add(filas["Email"].ToString());
                elementos.SubItems.Add(filas["Fax"].ToString());
                elementos.SubItems.Add(filas["Web"].ToString());
                elementos.SubItems.Add(filas["Observacion"].ToString());
                elementos.SubItems.Add(filas["Clasificacion"].ToString());
                elementos.SubItems.Add(filas["Status"].ToString());
                lvwCliente.Items.Add(elementos);
            }

        }
        //Método buscarnombre
        private void BuscarNombre()
        {
            LlenarListView(NCliente.BuscarNombre(Convert.ToString(txtBuscar.Text)));
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwCliente.Items.Count);
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void CrearColumnas()
        {
            lvwCliente.View = View.Details;
            lvwCliente.LabelEdit = false;
            lvwCliente.AllowColumnReorder = true;
            lvwCliente.CheckBoxes = false;
            lvwCliente.FullRowSelect = true;
            lvwCliente.GridLines = true;
            lvwCliente.Sorting = SortOrder.Ascending;

            lvwCliente.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwCliente.Columns.Add("Código", 70, HorizontalAlignment.Right);
            lvwCliente.Columns.Add("Rif", 100, HorizontalAlignment.Left);
            lvwCliente.Columns.Add("Nombre o Razón", 200, HorizontalAlignment.Left);
            lvwCliente.Columns.Add("Contacto", 100, HorizontalAlignment.Left);
            lvwCliente.Columns.Add("Teléfono", 100, HorizontalAlignment.Right);
            lvwCliente.Columns.Add("Dirección", 0, HorizontalAlignment.Right);
            lvwCliente.Columns.Add("Correo", 100, HorizontalAlignment.Right);
            lvwCliente.Columns.Add("Fax", 0, HorizontalAlignment.Right);
            lvwCliente.Columns.Add("Web Site", 0, HorizontalAlignment.Right);
            lvwCliente.Columns.Add("Observación", 0, HorizontalAlignment.Right);
            lvwCliente.Columns.Add("Clasificación", 0, HorizontalAlignment.Right);
            lvwCliente.Columns.Add("Estatus", 70, HorizontalAlignment.Right);
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
            int valorclasificacion=0;
            
            if (rbGobierno.Checked == true)
            {
                valorclasificacion = 2;
            }
            if (rbJuridico.Checked==true)
            {
                valorclasificacion = 1;
            }
            if (rbNatural.Checked==true)
            {
                valorclasificacion = 0;
            }

            try
            {
                string rpta = "";
                if (txtCodigo.Text == string.Empty | txtRif.Text == string.Empty | txtRazon.Text==string.Empty)
                {
                    if (txtCodigo.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtCodigo, "Ingrese el código del cliente");
                    }
                    if (txtRif.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtRif, "Ingrese el RIF del cliente");
                    }
                    if (txtRazon.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtRazon, "Ingrese el nombre o la razón social del cliente");
                    }
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NCliente.Insertar(Convert.ToInt32(txtCodigo.Text),
                            txtRif.Text, txtRazon.Text, txtContacto.Text, txtTelefono.Text, txtDireccion.Text,
                            txtCorreo.Text, txtFax.Text, Convert.ToInt16(valorclasificacion), txtWeb.Text, txtObservacion.Text, Convert.ToInt16(chkActivo.Checked));
                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(txtCodigo.Text),
                            txtRif.Text, txtRazon.Text, txtContacto.Text, txtTelefono.Text, txtDireccion.Text,
                            txtCorreo.Text, txtFax.Text, Convert.ToInt16(valorclasificacion), txtWeb.Text, txtObservacion.Text, Convert.ToInt16(chkActivo.Checked));
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
                lvwCliente.CheckBoxes = true;
            }
            else
            {
                lvwCliente.CheckBoxes = false;
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
                    string Rif;
                    string Rpta = "";
                    for (int i = 0; i < lvwCliente.Items.Count; i++)
                    {
                        if (lvwCliente.Items[i].Checked == true)
                        {
                            Codigo = Convert.ToString(lvwCliente.Items[i].SubItems[1].Text);
                            Rif = Convert.ToString(lvwCliente.Items[i].SubItems[2].Text);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo), Rif);
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

        private void lvwCliente_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = lvwCliente.SelectedItems[0].SubItems[1].Text;
            txtRif.Text = lvwCliente.SelectedItems[0].SubItems[2].Text;
            txtRazon.Text = lvwCliente.SelectedItems[0].SubItems[3].Text;
            txtContacto.Text = lvwCliente.SelectedItems[0].SubItems[4].Text;
            txtTelefono.Text = lvwCliente.SelectedItems[0].SubItems[5].Text;
            txtDireccion.Text = lvwCliente.SelectedItems[0].SubItems[6].Text;
            txtCorreo.Text = lvwCliente.SelectedItems[0].SubItems[7].Text;
            txtFax.Text = lvwCliente.SelectedItems[0].SubItems[8].Text;
            txtWeb.Text = lvwCliente.SelectedItems[0].SubItems[9].Text;
            txtObservacion.Text = lvwCliente.SelectedItems[0].SubItems[10].Text;
            //radio buton clasificación
            switch (lvwCliente.SelectedItems[0].SubItems[11].Text)
            {
                case "0":
                    rbNatural.Checked = true;
                    break;
                case "1":
                    rbJuridico.Checked = true;
                    break;
                case "2":
                    rbGobierno.Checked = true;
                    break;
            }
            //Chech Status
            if (lvwCliente.SelectedItems[0].SubItems[12].Text == "SI")
            {
                chkActivo.Checked = true;
            }
            else
            {
                chkActivo.Checked = false;
            }
            tbcUno.SelectedIndex = 1;
        }

    }
}
