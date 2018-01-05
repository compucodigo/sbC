namespace CapaPresentacion
{
    partial class frmCatalogoImpuesto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatalogoImpuesto));
            this.lvwImpuesto = new System.Windows.Forms.ListView();
            this.imlUno = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvwImpuesto
            // 
            this.lvwImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwImpuesto.LargeImageList = this.imlUno;
            this.lvwImpuesto.Location = new System.Drawing.Point(12, 12);
            this.lvwImpuesto.Name = "lvwImpuesto";
            this.lvwImpuesto.Size = new System.Drawing.Size(666, 287);
            this.lvwImpuesto.SmallImageList = this.imlUno;
            this.lvwImpuesto.TabIndex = 0;
            this.lvwImpuesto.UseCompatibleStateImageBehavior = false;
            this.lvwImpuesto.View = System.Windows.Forms.View.Details;
            this.lvwImpuesto.SelectedIndexChanged += new System.EventHandler(this.lvwImpuesto_SelectedIndexChanged);
            this.lvwImpuesto.DoubleClick += new System.EventHandler(this.lvwImpuesto_DoubleClick);
            this.lvwImpuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwImpuesto_KeyPress);
            // 
            // imlUno
            // 
            this.imlUno.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlUno.ImageStream")));
            this.imlUno.TransparentColor = System.Drawing.Color.Transparent;
            this.imlUno.Images.SetKeyName(0, "editar2.png");
            this.imlUno.Images.SetKeyName(1, "documento.png");
            // 
            // frmCatalogoImpuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(690, 311);
            this.Controls.Add(this.lvwImpuesto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCatalogoImpuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione un Impuesto";
            this.Load += new System.EventHandler(this.frmCatalogoImpuesto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwImpuesto;
        private System.Windows.Forms.ImageList imlUno;
    }
}