namespace SistemaAyudantias.Formularios
{
    partial class FrmSelectorPeriodo
    {
        /// <summary>Variable del diseñador necesaria.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Limpiar los recursos que se estén usando.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLista = new System.Windows.Forms.FlowLayoutPanel();
            this.panelPie = new System.Windows.Forms.Panel();
            this.panelEncabezado = new SistemaAyudantias.Diseno.PanelDegradado();
            this.lblIconoCalendario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblCerrar = new System.Windows.Forms.Label();
            this.lblPie = new System.Windows.Forms.Label();
            this.panelPie.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLista
            // 
            this.panelLista.AutoScroll = true;
            this.panelLista.BackColor = System.Drawing.Color.White;
            this.panelLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLista.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelLista.Padding = new System.Windows.Forms.Padding(14, 10, 0, 8);
            this.panelLista.WrapContents = false;
            this.panelLista.Size = new System.Drawing.Size(420, 380);
            this.panelLista.Name = "panelLista";
            // 
            // panelPie
            // 
            this.panelPie.Controls.Add(this.lblPie);
            this.panelPie.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.panelPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPie.Size = new System.Drawing.Size(420, 44);
            this.panelPie.Name = "panelPie";
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.lblIconoCalendario);
            this.panelEncabezado.Controls.Add(this.lblTitulo);
            this.panelEncabezado.Controls.Add(this.lblSubtitulo);
            this.panelEncabezado.Controls.Add(this.lblCerrar);
            this.panelEncabezado.Angulo = 0F;
            this.panelEncabezado.ColorFin = System.Drawing.Color.FromArgb(11, 79, 48);
            this.panelEncabezado.ColorInicio = System.Drawing.Color.FromArgb(18, 122, 69);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Size = new System.Drawing.Size(420, 86);
            this.panelEncabezado.Name = "panelEncabezado";
            // 
            // lblIconoCalendario
            // 
            this.lblIconoCalendario.AutoSize = true;
            this.lblIconoCalendario.BackColor = System.Drawing.Color.Transparent;
            this.lblIconoCalendario.Font = new System.Drawing.Font("Segoe MDL2 Assets", 20F);
            this.lblIconoCalendario.ForeColor = System.Drawing.Color.FromArgb(250, 214, 107);
            this.lblIconoCalendario.Location = new System.Drawing.Point(20, 24);
            this.lblIconoCalendario.Text = "\uE787";
            this.lblIconoCalendario.Name = "lblIconoCalendario";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(62, 18);
            this.lblTitulo.Text = "Período académico";
            this.lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(209, 236, 220);
            this.lblSubtitulo.Location = new System.Drawing.Point(64, 48);
            this.lblSubtitulo.Text = "Elija el semestre que quiere consultar";
            this.lblSubtitulo.Name = "lblSubtitulo";
            // 
            // lblCerrar
            // 
            this.lblCerrar.AutoSize = true;
            this.lblCerrar.BackColor = System.Drawing.Color.Transparent;
            this.lblCerrar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCerrar.ForeColor = System.Drawing.Color.FromArgb(209, 236, 220);
            this.lblCerrar.Location = new System.Drawing.Point(384, 12);
            this.lblCerrar.Text = "\u2715";
            this.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrar.Name = "lblCerrar";
            this.lblCerrar.Click += new System.EventHandler(this.lblCerrar_Click);
            // 
            // lblPie
            // 
            this.lblPie.AutoSize = false;
            this.lblPie.BackColor = System.Drawing.Color.Transparent;
            this.lblPie.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPie.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPie.Location = new System.Drawing.Point(0, 0);
            this.lblPie.Size = new System.Drawing.Size(420, 44);
            this.lblPie.Text = "Los períodos finalizados se abren en modo solo consulta.";
            this.lblPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPie.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblPie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPie.Name = "lblPie";
            // 
            // FrmSelectorPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 520);
            this.Controls.Add(this.panelLista);
            this.Controls.Add(this.panelPie);
            this.Controls.Add(this.panelEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Período académico";
            this.Name = "FrmSelectorPeriodo";
            this.Load += new System.EventHandler(this.FrmSelectorPeriodo_Load);
            this.Deactivate += new System.EventHandler(this.FrmSelectorPeriodo_Deactivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSelectorPeriodo_KeyDown);
            this.panelPie.ResumeLayout(false);
            this.panelPie.PerformLayout();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelLista;
        private System.Windows.Forms.Panel panelPie;
        private SistemaAyudantias.Diseno.PanelDegradado panelEncabezado;
        private System.Windows.Forms.Label lblIconoCalendario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblCerrar;
        private System.Windows.Forms.Label lblPie;
    }
}
