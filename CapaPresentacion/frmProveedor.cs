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
    public partial class frmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public ListViewItem.ListViewSubItemCollection SubItems;

        public frmProveedor()
        {
            InitializeComponent();            
            ttMensaje.SetToolTip(txtCodigo, "Ingrese un número que identifique el proveedor");
            ttMensaje.SetToolTip(txtRif, "Ingrese el numero de RIF del proveedor");
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre o la razón social del proveedor");

            LlenarBanco();
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
            txtNombre.Text = string.Empty;
            txtContacto.Text = string.Empty;
            txtCuenta.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTOficina.Text = string.Empty;
            txtTFax.Text = string.Empty;
            txtTMovil.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtWeb.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            chkStatus.Checked = false;
        }
        //Habilitar las cajas de textos
        private void Habilitar(bool Valor)
        {
            txtCodigo.ReadOnly = !Valor;
            txtRif.ReadOnly = !Valor;
            txtNombre.ReadOnly = !Valor;
            txtContacto.ReadOnly = !Valor;
            txtCuenta.ReadOnly = !Valor;
            txtDireccion.ReadOnly = !Valor;
            txtTOficina.ReadOnly = !Valor;
            txtTFax.ReadOnly = !Valor;
            txtTMovil.ReadOnly = !Valor;
            txtCorreo.ReadOnly = !Valor;
            txtWeb.ReadOnly = !Valor;
            txtObservacion.ReadOnly = !Valor;
            rbGobierno.Enabled = Valor;
            rbJuridico.Enabled = Valor;
            rbNatural.Enabled = Valor;
            rbNacional.Enabled = Valor;
            rbExtranjero.Enabled = Valor;
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
            LlenarListView(NProveedor.mostrar());
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwProveedor.Items.Count);
        }
        //Método para agregar los items al listview
        private void LlenarListView(DataTable dt)
        {
            //DataTable dtUnidad = new DataTable();
            //dtUnidad = NUnidad.mostrar();

            lvwProveedor.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DataRow filas = dt.Rows[i];
                ListViewItem elementos = new ListViewItem("", 1);
                elementos.SubItems.Add(filas["IdProveedor"].ToString());
                elementos.SubItems.Add(filas["Rif"].ToString());
                elementos.SubItems.Add(filas["Nombre"].ToString());
                elementos.SubItems.Add(filas["Contacto"].ToString());
                elementos.SubItems.Add(filas["TOficina"].ToString());
                elementos.SubItems.Add(filas["TFax"].ToString());
                elementos.SubItems.Add(filas["TMovil"].ToString());
                elementos.SubItems.Add(filas["NroCuenta"].ToString());
                elementos.SubItems.Add(filas["Email"].ToString());
                elementos.SubItems.Add(filas["WebSite"].ToString());
                elementos.SubItems.Add(filas["Direccion"].ToString());
                elementos.SubItems.Add(filas["Tipo"].ToString());                
                elementos.SubItems.Add(filas["Clasificacion"].ToString());
                elementos.SubItems.Add(filas["Observacion"].ToString());
                elementos.SubItems.Add(filas["IdBanco"].ToString());
                elementos.SubItems.Add(filas["Status"].ToString());
                lvwProveedor.Items.Add(elementos);
            }
        }
        //Método buscarnombre
        private void BuscarNombre()
        {
            LlenarListView(NProveedor.BuscarNombre(Convert.ToString(txtBuscar.Text), 0, "", 0));
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwProveedor.Items.Count);
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Mostrar();
            Habilitar(false);
            Botones();            
        }
        private void LlenarBanco()
        {
            cmbBanco.DataSource = NBanco.mostrar();
            cmbBanco.ValueMember = "IdBanco";
            cmbBanco.DisplayMember = "Descripcion";
        }
        private void CrearColumnas()
        {
            lvwProveedor.View = View.Details;
            lvwProveedor.LabelEdit = false;
            lvwProveedor.AllowColumnReorder = true;
            lvwProveedor.CheckBoxes = false;
            lvwProveedor.FullRowSelect = true;
            lvwProveedor.GridLines = true;
            lvwProveedor.Sorting = SortOrder.Ascending;

            lvwProveedor.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwProveedor.Columns.Add("Código", 70, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Rif", 100, HorizontalAlignment.Left);
            lvwProveedor.Columns.Add("Nombre o Razón", 200, HorizontalAlignment.Left);
            lvwProveedor.Columns.Add("Contacto", 100, HorizontalAlignment.Left);
            lvwProveedor.Columns.Add("Tlf. Oficina", 100, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("tlf Fax", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Tlf. Movil", 100, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Nro. Cta. Bancaria", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Correo", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Sitio Web", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Dirección", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Tipo", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Clasificación", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Observación", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("IdBanco", 0, HorizontalAlignment.Right);
            lvwProveedor.Columns.Add("Estatus", 0, HorizontalAlignment.Right);
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
            LimpiarFrm();
            IsNuevo = true;
            IsEditar = false;
            Botones();            
            Habilitar(true);
            txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int valorclasificacion = 0;
            int valortipo = 0;
            //Radiobuton clasificación
            if (rbGobierno.Checked == true)
            {
                valorclasificacion = 2;
            }
            if (rbJuridico.Checked == true)
            {
                valorclasificacion = 1;
            }
            if (rbNatural.Checked == true)
            {
                valorclasificacion = 0;
            }
            //Radiobuton tipo de proveedor
            if (rbNacional.Checked == true)
            {
                valortipo = 1;
            }
            else
            {
                valortipo = 0;
            }

            try
            {
                string rpta = "";
                if (txtCodigo.Text == string.Empty | txtRif.Text == string.Empty | txtNombre.Text == string.Empty)
                {
                    if (txtCodigo.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtCodigo, "Ingrese el código del proveedor");
                    }
                    if (txtRif.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtRif, "Ingrese el RIF del proveedor");
                    }
                    if (txtNombre.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtNombre, "Ingrese el nombre o la razón social del proveedor");
                    }
                }
                else
                {
                    if (IsNuevo)
                    {
                        rpta = NProveedor.Insertar(Convert.ToInt32(txtCodigo.Text), txtRif.Text, txtNombre.Text, txtContacto.Text, txtTOficina.Text,
                            txtTFax.Text, txtTMovil.Text, txtCuenta.Text, txtCorreo.Text, txtWeb.Text, txtDireccion.Text, valortipo, valorclasificacion,
                            txtObservacion.Text, Convert.ToInt32(cmbBanco.SelectedValue), Convert.ToInt16(chkStatus.Checked));
                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(txtCodigo.Text), txtRif.Text, txtNombre.Text, txtContacto.Text, txtTOficina.Text,
                            txtTFax.Text, txtTMovil.Text, txtCuenta.Text, txtCorreo.Text, txtWeb.Text, txtDireccion.Text, valortipo, valorclasificacion,
                            txtObservacion.Text, Convert.ToInt32(cmbBanco.SelectedValue), Convert.ToInt16(chkStatus.Checked));
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
                lvwProveedor.CheckBoxes = true;
            }
            else
            {
                lvwProveedor.CheckBoxes = false;
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
                    for (int i = 0; i < lvwProveedor.Items.Count; i++)
                    {
                        if (lvwProveedor.Items[i].Checked == true)
                        {
                            Codigo = Convert.ToString(lvwProveedor.Items[i].SubItems[1].Text);
                            Rif = Convert.ToString(lvwProveedor.Items[i].SubItems[2].Text);
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo), Rif);
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

        private void lvwProveedor_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = lvwProveedor.SelectedItems[0].SubItems[1].Text;
            txtRif.Text = lvwProveedor.SelectedItems[0].SubItems[2].Text;
            txtNombre.Text = lvwProveedor.SelectedItems[0].SubItems[3].Text;
            txtContacto.Text = lvwProveedor.SelectedItems[0].SubItems[4].Text;
            txtTOficina.Text = lvwProveedor.SelectedItems[0].SubItems[5].Text;
            txtTFax.Text = lvwProveedor.SelectedItems[0].SubItems[6].Text;
            txtTMovil.Text = lvwProveedor.SelectedItems[0].SubItems[7].Text;
            txtCuenta.Text = lvwProveedor.SelectedItems[0].SubItems[8].Text;
            txtCorreo.Text = lvwProveedor.SelectedItems[0].SubItems[9].Text;
            txtWeb.Text = lvwProveedor.SelectedItems[0].SubItems[10].Text;
            txtDireccion.Text = lvwProveedor.SelectedItems[0].SubItems[11].Text;
            //radio buton tipo
            switch (lvwProveedor.SelectedItems[0].SubItems[12].Text)
            {
                case "0":
                    rbExtranjero.Checked = true;
                    break;
                case "1":
                    rbNacional.Checked = true;
                    break;
            }
            //radio buton clasificación
            switch (lvwProveedor.SelectedItems[0].SubItems[13].Text)
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
            txtObservacion.Text = lvwProveedor.SelectedItems[0].SubItems[14].Text;
            cmbBanco.SelectedIndex = Convert.ToInt32(lvwProveedor.SelectedItems[0].SubItems[15].Text)-1;            
            //Chech Status
            if (lvwProveedor.SelectedItems[0].SubItems[16].Text == "1")
            {
                chkStatus.Checked = true;
            }
            else
            {
                chkStatus.Checked = false;
            }
            tbcUno.SelectedIndex = 1;
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtRif.Text))
            {
                DataTable dtProveedor;
                dtProveedor = NProveedor.BuscarCodigo("", Convert.ToInt32(txtCodigo.Text), txtRif.Text, 1);
                if (dtProveedor.Rows.Count > 0)
                {
                    MessageBox.Show("El código y Rif del proveedor ya se encuentra registrado", "Sistema S&B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                dtProveedor.Clear();
            }
        }

        private void txtRif_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtRif.Text))
            {
                DataTable dtProveedor;
                dtProveedor = NProveedor.BuscarCodigo("", Convert.ToInt32(txtCodigo.Text), txtRif.Text, 1);
                if (dtProveedor.Rows.Count > 0)
                {
                    MessageBox.Show("El Código y Rif del proveedor ya se encuentra registrado", "Sistema S&B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                dtProveedor.Clear();
            }
        }
    }
}
