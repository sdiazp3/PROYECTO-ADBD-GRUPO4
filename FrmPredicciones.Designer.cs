namespace SistemaAyudantias.Formularios
{
    partial class FrmPredicciones
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
            this.tarjetaLista = new SistemaAyudantias.Diseno.Tarjeta();
            this.separador = new System.Windows.Forms.Panel();
            this.tarjetaGrafico = new SistemaAyudantias.Diseno.Tarjeta();
            this.tablaPredicciones = new System.Windows.Forms.DataGridView();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.panelGrafico = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.tarjetaLista.SuspendLayout();
            this.tarjetaGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPredicciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tarjetaLista
            // 
            this.tarjetaLista.Controls.Add(this.tablaPredicciones);
            this.tarjetaLista.Controls.Add(this.lblMetodo);
            this.tarjetaLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaLista.Size = new System.Drawing.Size(400, 300);
            this.tarjetaLista.Subtitulo = "Estimación para la próxima convocatoria según los períodos anteriores";
            this.tarjetaLista.Titulo = "Predicción de postulantes por asignatura";
            this.tarjetaLista.Name = "tarjetaLista";
            // 
            // separador
            // 
            this.separador.Dock = System.Windows.Forms.DockStyle.Right;
            this.separador.Size = new System.Drawing.Size(18, 18);
            this.separador.Name = "separador";
            // 
            // tarjetaGrafico
            // 
            this.tarjetaGrafico.Controls.Add(this.panelGrafico);
            this.tarjetaGrafico.Controls.Add(this.lblResumen);
            this.tarjetaGrafico.Dock = System.Windows.Forms.DockStyle.Right;
            this.tarjetaGrafico.Size = new System.Drawing.Size(450, 300);
            this.tarjetaGrafico.Subtitulo = "Seleccione una asignatura de la lista";
            this.tarjetaGrafico.Titulo = "Historial y predicción";
            this.tarjetaGrafico.Name = "tarjetaGrafico";
            // 
            // tablaPredicciones
            // 
            this.tablaPredicciones.BackgroundColor = System.Drawing.Color.White;
            this.tablaPredicciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaPredicciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPredicciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaPredicciones.ReadOnly = true;
            this.tablaPredicciones.RowHeadersVisible = false;
            this.tablaPredicciones.AllowUserToAddRows = false;
            this.tablaPredicciones.Size = new System.Drawing.Size(400, 300);
            this.tablaPredicciones.Name = "tablaPredicciones";
            this.tablaPredicciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaPredicciones_CellClick);
            // 
            // lblMetodo
            // 
            this.lblMetodo.AutoSize = false;
            this.lblMetodo.BackColor = System.Drawing.Color.Transparent;
            this.lblMetodo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMetodo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMetodo.Location = new System.Drawing.Point(0, 0);
            this.lblMetodo.Size = new System.Drawing.Size(400, 44);
            this.lblMetodo.Text = "Método: regresión lineal simple (mínimos cuadrados) calculada en PostgreSQL con regr_slope y regr_intercept. Solo se usan convocatorias cerradas. Cupos sugeridos = predicción × porcentaje histórico de seleccionados.";
            this.lblMetodo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMetodo.Name = "lblMetodo";
            // 
            // panelGrafico
            // 
            this.panelGrafico.BackColor = System.Drawing.Color.White;
            this.panelGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrafico.Name = "panelGrafico";
            this.panelGrafico.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGrafico_Paint);
            this.panelGrafico.Resize += new System.EventHandler(this.panelGrafico_Resize);
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = false;
            this.lblResumen.BackColor = System.Drawing.Color.Transparent;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(18, 122, 69);
            this.lblResumen.Location = new System.Drawing.Point(0, 0);
            this.lblResumen.Size = new System.Drawing.Size(400, 66);
            this.lblResumen.Text = "";
            this.lblResumen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblResumen.Name = "lblResumen";
            // 
            // FrmPredicciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaLista);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.tarjetaGrafico);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmPredicciones";
            this.Load += new System.EventHandler(this.FrmPredicciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaPredicciones)).EndInit();
            this.tarjetaLista.ResumeLayout(false);
            this.tarjetaLista.PerformLayout();
            this.tarjetaGrafico.ResumeLayout(false);
            this.tarjetaGrafico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaAyudantias.Diseno.Tarjeta tarjetaLista;
        private System.Windows.Forms.Panel separador;
        private SistemaAyudantias.Diseno.Tarjeta tarjetaGrafico;
        private System.Windows.Forms.DataGridView tablaPredicciones;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.Panel panelGrafico;
        private System.Windows.Forms.Label lblResumen;
    }
}
