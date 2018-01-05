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
    public partial class frmCatalogoImpuesto : Form
    {
        public ListViewItem.ListViewSubItemCollection SubItems;

        public frmCatalogoImpuesto()
        {
            InitializeComponent();
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void frmCatalogoImpuesto_Load(object sender, EventArgs e)
        {
            CrearColumnas();
            Mostrar();
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
                //elementos.SubItems.Add(filas["Monto"].ToString());
                lvwImpuesto.Items.Add(elementos);
            }

        }
        private void Mostrar()
        {
            LlenarListView(NImpuesto.mostrar());            
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
            lvwImpuesto.Columns.Add("Código", 100, HorizontalAlignment.Right);
            lvwImpuesto.Columns.Add("Nombre", 350, HorizontalAlignment.Left);
            lvwImpuesto.Columns.Add("Monto", 100, HorizontalAlignment.Left);
        }

        private void lvwImpuesto_DoubleClick(object sender, EventArgs e)
        {
            frmExamen form = frmExamen.GetInstancia();
            string par1, par2, par3;
            par1=  Convert.ToString(lvwImpuesto.SelectedItems[0].SubItems[1].Text);
            par2 = lvwImpuesto.SelectedItems[0].SubItems[2].Text;
            par3 = lvwImpuesto.SelectedItems[0].SubItems[3].Text;
            form.SetImpuesto(par1, par2, par3);
            this.Hide();
        }

        private void lvwImpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvwImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmExamen form = frmExamen.GetInstancia();
            string par1, par2, par3;
            par1 = Convert.ToString(lvwImpuesto.SelectedItems[0].SubItems[1].Text);
            par2 = lvwImpuesto.SelectedItems[0].SubItems[2].Text;
            par3 = lvwImpuesto.SelectedItems[0].SubItems[3].Text;
            form.SetImpuesto(par1, par2, par3);
            this.Hide();
        }
    }
}