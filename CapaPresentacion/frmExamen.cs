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
    public partial class frmExamen : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public ListViewItem.ListViewSubItemCollection SubItems;

        private static frmExamen _Instancia;
        public static frmExamen GetInstancia()
        {
            if (_Instancia==null)
            {
                _Instancia=new frmExamen();
            }
            return _Instancia;
        }
        private void CalculoPrecio()
        {
            double dblPCompra, dblPCompraImp, dblGanancia, dblMonto, dblPVenta;
            //verificar precio de compra y asignar a variable
            if (string.IsNullOrEmpty(txtPCompra.Text))
            {
                MessageBox.Show("Falta el precio de compra para calcular la ganancía",Funciones.GLB_APLICACION,MessageBoxButtons.OK,MessageBoxIcon.Information);

                return;
            }
            else
            {
                dblPCompra = Convert.ToDouble(txtPCompra.Text);
            }
            //verificar precio de compra + impuesto y asignar a variable
            if (string.IsNullOrEmpty(txtPCompraImpuesto.Text))
            {
                MessageBox.Show( "Falta el precio de compra con impuesto para calcular la ganancía");
                return;
            }
            else
            {
                dblPCompraImp = Convert.ToDouble(txtPCompraImpuesto.Text);
            }
            if (string.IsNullOrEmpty(txtGanancia.Text))
            {
                MessageBox.Show("Falta un monto para determinar la ganancia");
                return;
            }
            else
            {
                dblGanancia = Convert.ToDouble(txtGanancia.Text);
                dblMonto = Convert.ToDouble(txtMontoImpuesto.Text);                
                if (rbtPorcentaje.Checked){                    
                    txtPVenta.Text = Convert.ToString(string.Format("{0:N}", dblPCompra + (dblPCompra * dblGanancia / 100)));
                    dblPVenta = Convert.ToDouble(txtPVenta.Text);
                    txtPVentaImpuesto.Text = Convert.ToString(string.Format("{0:N}", dblPVenta + (dblPVenta * dblMonto / 100)));
                }
                else
                {
                    txtPVenta.Text = Convert.ToString(dblPCompra + dblGanancia);
                    dblPVenta = Convert.ToDouble(txtPVenta.Text);
                    txtPVentaImpuesto.Text = Convert.ToString(string.Format("{0:N}", dblPVenta + (dblPVenta * dblMonto / 100)));
                }
            }
        }
        private void LlenarUbicacion()
        {
            cmbAlmacen.DataSource = NUbicacion.mostrar();
            cmbAlmacen.ValueMember = "IdUbicacion";
            cmbAlmacen.DisplayMember = "Descripcion";
        }
        private void LlenarUnidad()
        {
            cmbPresentacion.DataSource = NUnidad.mostrar(0);
            cmbPresentacion.ValueMember = "IdUnidad";
            cmbPresentacion.DisplayMember = "Descripcion";
        }
        private void LlenarClasificacion()
        {
            cmbClasificacion.DataSource = NClasificacion.mostrar();
            cmbClasificacion.ValueMember = "IdClasificacion";
            cmbClasificacion.DisplayMember = "Descripcion";
        }

        public void SetImpuesto(string idimpuesto, string descripcion, string monto)
        {
            txtImpuesto.Text = idimpuesto;
            txtNombreImpuesto.Text = descripcion;
            txtMontoImpuesto.Text = monto;
        }
        public frmExamen()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtCodigo, "Ingrese un Código que identifique el producto");
            ttMensaje.SetToolTip(txtNombre, "Ingrese un nombre que identifique el producto");
            ttMensaje.SetToolTip(cmbPresentacion, "Debe seleccionar una presentación del producto");
            ttMensaje.SetToolTip(cmbClasificacion, "Debe seleccionar una clasificación del producto");
            ttMensaje.SetToolTip(txtPCompra, "Ingrese un monto para el precio de compra");
            ttMensaje.SetToolTip(txtPCompraImpuesto, "Ingrese un monto para el precio de compra para calcular el impuesto");
            ttMensaje.SetToolTip(txtGanancia, "Ingrese un monto en porcentaje o lineal para la ganancía");
            ttMensaje.SetToolTip(txtPVenta, "Ingrese un monto para el precio de venta");
            ttMensaje.SetToolTip(txtPVentaImpuesto, "Ingrese un monto para el precio de venta para calcular el precio de venta con impuesto");
            ttMensaje.SetToolTip(cmbAlmacen, "Debe seleccionar una ubicación del producto");
            LlenarUbicacion();
            LlenarClasificacion();
            LlenarUnidad();
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
            txtBarra.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtImpuesto.Text = string.Empty;
            txtNombreImpuesto.Text = string.Empty;
            txtMontoImpuesto.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtDias.Text = string.Empty;
            txtExistencia.Text = string.Empty;
            txtMaximo.Text = string.Empty;
            txtMinimo.Text = string.Empty;
            txtGarantia.Text = string.Empty;
            txtPedido.Text = string.Empty;
            txtPCompra.Text = string.Empty;
            txtPCompraImpuesto.Text = string.Empty;
            txtGanancia.Text = string.Empty;
            txtPVenta.Text = string.Empty;
            txtPVentaImpuesto.Text = string.Empty;
            lvwPrecio.Items.Clear();
            lvwAlmacen.Items.Clear();
            chkExento.Checked = false;
            chkEliminar.Checked = false;
        }
        //Habilitar las cajas de textos
        private void Habilitar(bool Valor)
        {
            txtCodigo.ReadOnly = !Valor;
            txtBarra.ReadOnly = !Valor;
            txtNombre.ReadOnly = !Valor;
            txtImpuesto.ReadOnly = !Valor;            
            cmbPresentacion.Enabled = Valor;
            cmbClasificacion.Enabled = Valor;
            txtObservacion.ReadOnly = !Valor;
            txtDias.ReadOnly = !Valor;
            txtExistencia.ReadOnly = !Valor;
            txtMaximo.ReadOnly = !Valor;
            txtMinimo.ReadOnly = !Valor;
            txtGarantia.ReadOnly = !Valor;
            txtPedido.ReadOnly = !Valor;
            chkExento.Enabled = Valor;
            txtPCompra.ReadOnly = !Valor;
            txtPCompraImpuesto.ReadOnly = !Valor;
            txtGanancia.ReadOnly = !Valor;
            txtPVenta.ReadOnly = !Valor;
            txtPVentaImpuesto.ReadOnly = !Valor;
            cmbAlmacen.Enabled = Valor;
            pctBuscar.Enabled = Valor;
            btnAgregarUbicacion.Enabled = Valor;
            btnAgregarPrecio.Enabled = Valor;
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
            LlenarListView(NExamen.mostrar());
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwExamen.Items.Count);
        }
        //Método para agregar los items al listview
        private void LlenarListView(DataTable dt)
        {
            lvwExamen.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow filas = dt.Rows[i];
                ListViewItem elementos = new ListViewItem("", 1);
                elementos.SubItems.Add(filas["IdExamen"].ToString());
                elementos.SubItems.Add(filas["CodigoBarra"].ToString());
                elementos.SubItems.Add(filas["Nombre"].ToString());
                elementos.SubItems.Add(filas["IdImpuesto"].ToString());
                elementos.SubItems.Add(filas["Exis"].ToString());
                elementos.SubItems.Add(filas["Clasificacion"].ToString());
                elementos.SubItems.Add(filas["Unidad"].ToString());
                lvwExamen.Items.Add(elementos);
            }
        }
        //Método buscarnombre
        private void BuscarNombre()
        {
            LlenarListView(NExamen.BuscarNombre("0",Convert.ToString(txtBuscar.Text)));
            lblTotal.Text = "Cantidad de Registros: " + Convert.ToString(lvwExamen.Items.Count);
        }
        private void frmExamen_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            CrearColumnasPrecio();
            CrearColumnasUbicacion();
            Mostrar();
            //Habilitar(false);
            Botones();            
        }
        private void CrearColumnas()
        {
            lvwExamen.View = View.Details;
            lvwExamen.LabelEdit = false;
            lvwExamen.AllowColumnReorder = true;
            lvwExamen.CheckBoxes = false;
            lvwExamen.FullRowSelect = true;
            lvwExamen.GridLines = true;
            lvwExamen.Sorting = SortOrder.Ascending;

            lvwExamen.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwExamen.Columns.Add("Código", 100, HorizontalAlignment.Right);
            lvwExamen.Columns.Add("Nombre", 220, HorizontalAlignment.Left);
            lvwExamen.Columns.Add("Existencia", 100, HorizontalAlignment.Right);
            lvwExamen.Columns.Add("Clasificación", 120, HorizontalAlignment.Left);
            lvwExamen.Columns.Add("Presentación", 100, HorizontalAlignment.Left);
        }
        private void CrearColumnasPrecio()
        {
            lvwPrecio.View = View.Details;
            lvwPrecio.LabelEdit = false;
            lvwPrecio.AllowColumnReorder = true;
            lvwPrecio.CheckBoxes = false;
            lvwPrecio.FullRowSelect = true;
            lvwPrecio.GridLines = true;
            lvwPrecio.Sorting = SortOrder.Ascending;

            lvwPrecio.Columns.Add("", 20, HorizontalAlignment.Left);
            lvwPrecio.Columns.Add("Código", 0, HorizontalAlignment.Right);
            lvwPrecio.Columns.Add("Precio Compra", 95, HorizontalAlignment.Right);
            lvwPrecio.Columns.Add("P. Compra + Imp.", 95, HorizontalAlignment.Right);
            lvwPrecio.Columns.Add("Precio Venta", 95, HorizontalAlignment.Right);
            lvwPrecio.Columns.Add("P. Venta + Imp.", 95, HorizontalAlignment.Right);
            lvwPrecio.Columns.Add("Ganancia", 95, HorizontalAlignment.Right);
        }
        private void CrearColumnasUbicacion()
        {
            lvwAlmacen.View = View.Details;
            lvwAlmacen.LabelEdit = false;
            lvwAlmacen.AllowColumnReorder = true;
            lvwAlmacen.CheckBoxes = false;
            lvwAlmacen.FullRowSelect = true;
            lvwAlmacen.GridLines = true;
            lvwAlmacen.Sorting = SortOrder.Ascending;

            lvwAlmacen.Columns.Add("", 40, HorizontalAlignment.Left);
            lvwAlmacen.Columns.Add("Código", 100, HorizontalAlignment.Right);
            lvwAlmacen.Columns.Add("Ubicación", 450, HorizontalAlignment.Left);
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
                if (txtCodigo.Text == string.Empty | txtNombre.Text == string.Empty | lvwPrecio.Items.Count==0 | lvwAlmacen.Items.Count ==0)
                {
                    if (txtCodigo.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtCodigo, "Ingrese el código del producto");
                    }
                    if (txtNombre.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtNombre, "Ingrese el nombre del banco");
                    }
                    if (lvwPrecio.Items.Count==0)
                    {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(txtPCompra, "Ingrese el precio de compra");
                        errorIcono.SetError(txtPCompraImpuesto, "Ingrese el precio de compra con impuesto");
                        errorIcono.SetError(txtGanancia, "Ingrese la ganancia");
                        errorIcono.SetError(txtPVenta, "Ingrese el precio de venta");
                        errorIcono.SetError(txtPVentaImpuesto, "Ingrese el precio de venta con impuesto");
                    }
                    if (lvwAlmacen.Items.Count==0)
	                {
                        MensajeError("Falta ingresar algunos datos, serán remarcados");
                        errorIcono.SetError(cmbAlmacen, "Seleccione un almacen para el inventario");
                    }
                }
                else
                {
                    if (IsNuevo)
                    {
                        //rpta = NExamen.Insertar(Convert.ToInt32(txtCodigo.Text),
                        //txtBarra.Text, txtNombre.Text, Convert.ToInt32(txtImpuesto.Text), txtObservacion.Text,
                        //"0", cmbPresentacion.SelectedValue.ToString(), cmbClasificacion.SelectedValue.ToString(), txtDias.Text,
                        //Convert.ToInt32(txtMaximo.Text), Convert.ToInt32(txtMinimo.Text), Convert.ToInt32(chkExento.Checked),
                        //txtGarantia,);
                    }
                    else
                    {
                        //rpta = NBanco.Editar(Convert.ToInt32(txtCodigo.Text),
                        //    Convert.ToString(txtNombre.Text));
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

        private void frmExamen_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void pctBuscar_Click(object sender, EventArgs e)
        {
            frmCatalogoImpuesto vista = new frmCatalogoImpuesto();
            vista.ShowDialog();
        }

        private void frmExamen_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instancia = null;
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

        private void lvwExamen_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = lvwExamen.SelectedItems[0].SubItems[1].Text;

            
            //Chech Status
            if (lvwExamen.SelectedItems[0].SubItems[6].Text == "1")
            {
                chkStatus.Checked = true;
            }
            else
            {
                chkStatus.Checked = false;
            }
            tbcUno.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                lvwExamen.CheckBoxes = true;
            }
            else
            {
                lvwExamen.CheckBoxes = false;
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
                    for (int i = 0; i < lvwExamen.Items.Count; i++)
                    {
                        if (lvwExamen.Items[i].Checked == true)
                        {
                            Codigo = Convert.ToString(lvwExamen.Items[i].SubItems[1].Text);
                            Rif = Convert.ToString(lvwExamen.Items[i].SubItems[2].Text);
                            //Rpta = NExamen.Eliminar(Convert.ToInt32(Codigo), Rif);
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

        private void txtImpuesto_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtImpuesto.Text))
            {
                DataTable dtImpuesto;
                dtImpuesto=NImpuesto.Buscar(1, Convert.ToInt32(txtImpuesto.Text));
                if (dtImpuesto.Rows.Count>0)
                {
                    txtNombreImpuesto.Text = dtImpuesto.Rows[0][1].ToString();
                    txtMontoImpuesto.Text = dtImpuesto.Rows[0][2].ToString();
                }
                else
                {
                    MessageBox.Show("El código de impuesto no se encuentra registrado","Sistema S&B",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtImpuesto.Clear();
                    txtNombreImpuesto.Clear();
                    txtMontoImpuesto.Clear();
                    e.Cancel = true;
                }
                dtImpuesto.Clear();
            }
        }

        private void txtCodigo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                DataTable dtExamen;
                dtExamen = NExamen.BuscarNombre("1", txtCodigo.Text);
                if (dtExamen.Rows.Count>0)
                {
                    MessageBox.Show("El código del producto ya se encuentra registrado", "Sistema S&B", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarFrm();
                    txtCodigo.Focus();                    
                }
            }
        }

        private void txtPCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "D", (TextBox)sender);
        }

        private void txtPCompra_Enter(object sender, EventArgs e)
        {
            Funciones.SelTexto((TextBox)sender);
        }

        private void txtImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "N", (TextBox)sender);
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "N", (TextBox)sender);
        }

        private void txtMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "N", (TextBox)sender);
        }

        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "N", (TextBox)sender);
        }

        private void txtPCompraImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "D", (TextBox)sender);
        }

        private void txtGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "D", (TextBox)sender);
        }

        private void txtPVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "D", (TextBox)sender);
        }

        private void txtPVentaImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.ValidarCampo(e, "D", (TextBox)sender);
        }

        private void txtPCompraImpuesto_Enter(object sender, EventArgs e)
        {
            Funciones.SelTexto((TextBox)sender);
        }
        private void txtGanancia_Enter(object sender, EventArgs e)
        {
            Funciones.SelTexto((TextBox)sender);
        }
        private void txtPVenta_Enter(object sender, EventArgs e)
        {
            Funciones.SelTexto((TextBox)sender);
        }
        private void txtPVentaImpuesto_Enter(object sender, EventArgs e)
        {
            Funciones.SelTexto((TextBox)sender);
        }

        private void txtImpuesto_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                frmCatalogoImpuesto vista = new frmCatalogoImpuesto();
                vista.ShowDialog();
            }
        }

        private void txtGanancia_Validating(object sender, CancelEventArgs e)
        {
            double dblPrecioVenta, dblMonto;
            if (!string.IsNullOrEmpty(txtGanancia.Text))
            {
                if(rbtPorcentaje.Checked.Equals(true))
                {
                    dblPrecioVenta = Convert.ToDouble(txtPCompraImpuesto.Text) + (Convert.ToDouble(txtPCompraImpuesto.Text) * Convert.ToDouble(txtGanancia.Text) / 100);
                }
                else
                {
                    dblPrecioVenta = Convert.ToDouble(txtPCompraImpuesto.Text) + Convert.ToDouble(txtGanancia.Text);
                }
                dblMonto = Convert.ToDouble(txtMontoImpuesto.Text);
                txtPVenta.Text = Convert.ToString(string.Format("{0:N}", dblPrecioVenta));
                txtPVentaImpuesto.Text = Convert.ToString(string.Format("{0:N}",dblPrecioVenta + (dblPrecioVenta * dblMonto / 100)));
            }
        }

        private void txtPCompraImpuesto_Validating(object sender, CancelEventArgs e)
        {
            double dblPCompraI, dblMonto;
            if (!string.IsNullOrEmpty(txtPCompraImpuesto.Text))
            {
                dblPCompraI = Convert.ToDouble(txtPCompraImpuesto.Text);
                if (string.IsNullOrEmpty(txtMontoImpuesto.Text))
                {
                    txtPCompra.Text = Convert.ToString(string.Format("{0:N}", txtPCompraImpuesto.Text));
                }
                else
                {
                    dblMonto = Convert.ToDouble(txtMontoImpuesto.Text);
                    txtPCompra.Text = Convert.ToString(string.Format("{0:N}", dblPCompraI-(dblPCompraI *(dblMonto / 100))));                    
                }                
                txtPCompraImpuesto.Text = Convert.ToString(string.Format("{0:N}", txtPCompraImpuesto.Text));
                rbtPorcentaje.Focus();
            }
        }

        private void txtPCompra_Validating(object sender, CancelEventArgs e)
        {
            double dblPCompra, dblMonto;
            if (!string.IsNullOrEmpty(txtPCompra.Text))
            {
                dblPCompra = Convert.ToDouble(txtPCompra.Text);
                if (string.IsNullOrEmpty(txtMontoImpuesto.Text) || chkExento.Checked.Equals(true))
                {
                    txtPCompraImpuesto.Text = Convert.ToString(string.Format("{0:N}", dblPCompra));
                }
                else
                {
                    dblMonto = Convert.ToDouble(txtMontoImpuesto.Text);
                    txtPCompraImpuesto.Text = Convert.ToString(string.Format("{0:N}", dblPCompra + (dblPCompra * dblMonto / 100)));
                }
                txtPCompra.Text = Convert.ToString(string.Format("{0:N}", dblPCompra));                
                rbtPorcentaje.Focus();
            }
        }

        private void btnAgregarPrecio_Click(object sender, EventArgs e)
        {
            string strGanancia;
            if (!string.IsNullOrEmpty(txtPCompra.Text) && !string.IsNullOrEmpty(txtPCompraImpuesto.Text) && !string.IsNullOrEmpty(txtGanancia.Text) && !string.IsNullOrEmpty(txtPVenta.Text) && !string.IsNullOrEmpty(txtPVentaImpuesto.Text))
            {
                ListViewItem itemAgregar = new ListViewItem(" ",1);
                itemAgregar.SubItems.Add(txtCodigo.Text);
                itemAgregar.SubItems.Add(txtPCompra.Text);
                itemAgregar.SubItems.Add(txtPCompraImpuesto.Text);
                itemAgregar.SubItems.Add(txtPVenta.Text);
                itemAgregar.SubItems.Add(txtPVentaImpuesto.Text);
                strGanancia = Convert.ToString(string.Format("{0:N}",Convert.ToDouble(txtPVentaImpuesto.Text) - Convert.ToDouble(txtPCompraImpuesto.Text)));
                itemAgregar.SubItems.Add(strGanancia);
                lvwPrecio.Items.Add(itemAgregar);
                txtPCompra.Clear();
                txtPCompraImpuesto.Clear();
                txtGanancia.Clear();
                txtPVenta.Clear();
                txtPVentaImpuesto.Clear();
                txtPCompra.Focus();
            }
        }

        private void btnAgregarUbicacion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbAlmacen.Text))
            {
                for(int i = lvwAlmacen.Items.Count - 1; i >= 0; i--)
                {
                    var ltwBuscar = lvwAlmacen.Items[i];
                    if (ltwBuscar.SubItems[1].Text == Convert.ToString(cmbAlmacen.SelectedValue))
                    {
                        MessageBox.Show("El almacen ya existe la lista", "Sistema S&B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                ListViewItem itemAgregar = new ListViewItem(" ", 1);
                itemAgregar.SubItems.Add(Convert.ToString(cmbAlmacen.SelectedValue));
                itemAgregar.SubItems.Add(cmbAlmacen.Text);
                lvwAlmacen.Items.Add(itemAgregar);
                cmbAlmacen.Focus();
            }
            else
            {
                MessageBox.Show("Debe de crear un almacen para agregar los productos", "Sistema S&B", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAlmacen.Focus();
            }
        }
    }
}