namespace SistemaAyudantias.Formularios
{
    partial class FrmEvaluacion
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
            this.tarjetaEvaluar = new SistemaAyudantias.Diseno.Tarjeta();
            this.tablaPostulantes = new System.Windows.Forms.DataGridView();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.lblConvocatoria = new System.Windows.Forms.Label();
            this.cboConvocatoria = new System.Windows.Forms.ComboBox();
            this.lblCupos = new System.Windows.Forms.Label();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblPuntaje = new System.Windows.Forms.Label();
            this.numPuntaje = new System.Windows.Forms.NumericUpDown();
            this.lblResultado = new System.Windows.Forms.Label();
            this.cboResultado = new System.Windows.Forms.ComboBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.campoObservacion = new SistemaAyudantias.Diseno.Campo();
            this.panelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new SistemaAyudantias.Diseno.Boton();
            this.btnDocumento = new SistemaAyudantias.Diseno.Boton();
            this.tarjetaLista.SuspendLayout();
            this.tarjetaEvaluar.SuspendLayout();
            this.panelFiltro.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPostulantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntaje)).BeginInit();
            this.SuspendLayout();
            // 
            // tarjetaLista
            // 
            this.tarjetaLista.Controls.Add(this.tablaPostulantes);
            this.tarjetaLista.Controls.Add(this.panelFiltro);
            this.tarjetaLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaLista.Size = new System.Drawing.Size(400, 300);
            this.tarjetaLista.Subtitulo = "Ordenados por puntaje";
            this.tarjetaLista.Titulo = "Postulantes";
            this.tarjetaLista.Name = "tarjetaLista";
            // 
            // separador
            // 
            this.separador.Dock = System.Windows.Forms.DockStyle.Right;
            this.separador.Size = new System.Drawing.Size(18, 18);
            this.separador.Name = "separador";
            // 
            // tarjetaEvaluar
            // 
            this.tarjetaEvaluar.Controls.Add(this.lblEstudiante);
            this.tarjetaEvaluar.Controls.Add(this.lblDocumento);
            this.tarjetaEvaluar.Controls.Add(this.lblPuntaje);
            this.tarjetaEvaluar.Controls.Add(this.numPuntaje);
            this.tarjetaEvaluar.Controls.Add(this.lblResultado);
            this.tarjetaEvaluar.Controls.Add(this.cboResultado);
            this.tarjetaEvaluar.Controls.Add(this.lblObservacion);
            this.tarjetaEvaluar.Controls.Add(this.campoObservacion);
            this.tarjetaEvaluar.Controls.Add(this.panelBotones);
            this.tarjetaEvaluar.Dock = System.Windows.Forms.DockStyle.Right;
            this.tarjetaEvaluar.Size = new System.Drawing.Size(380, 300);
            this.tarjetaEvaluar.Subtitulo = "Seleccione un postulante de la lista";
            this.tarjetaEvaluar.Titulo = "Evaluar postulante";
            this.tarjetaEvaluar.Name = "tarjetaEvaluar";
            // 
            // tablaPostulantes
            // 
            this.tablaPostulantes.BackgroundColor = System.Drawing.Color.White;
            this.tablaPostulantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaPostulantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaPostulantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaPostulantes.ReadOnly = true;
            this.tablaPostulantes.RowHeadersVisible = false;
            this.tablaPostulantes.AllowUserToAddRows = false;
            this.tablaPostulantes.Size = new System.Drawing.Size(400, 300);
            this.tablaPostulantes.Name = "tablaPostulantes";
            this.tablaPostulantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaPostulantes_CellClick);
            // 
            // panelFiltro
            // 
            this.panelFiltro.Controls.Add(this.lblConvocatoria);
            this.panelFiltro.Controls.Add(this.cboConvocatoria);
            this.panelFiltro.Controls.Add(this.lblCupos);
            this.panelFiltro.BackColor = System.Drawing.Color.White;
            this.panelFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltro.Size = new System.Drawing.Size(400, 92);
            this.panelFiltro.Name = "panelFiltro";
            // 
            // lblConvocatoria
            // 
            this.lblConvocatoria.AutoSize = true;
            this.lblConvocatoria.BackColor = System.Drawing.Color.Transparent;
            this.lblConvocatoria.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblConvocatoria.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblConvocatoria.Location = new System.Drawing.Point(0, 0);
            this.lblConvocatoria.Text = "Convocatoria";
            this.lblConvocatoria.Name = "lblConvocatoria";
            // 
            // cboConvocatoria
            // 
            this.cboConvocatoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConvocatoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboConvocatoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboConvocatoria.FormattingEnabled = true;
            this.cboConvocatoria.Location = new System.Drawing.Point(0, 22);
            this.cboConvocatoria.Size = new System.Drawing.Size(460, 25);
            this.cboConvocatoria.Name = "cboConvocatoria";
            this.cboConvocatoria.SelectedIndexChanged += new System.EventHandler(this.cboConvocatoria_SelectedIndexChanged);
            // 
            // lblCupos
            // 
            this.lblCupos.AutoSize = true;
            this.lblCupos.BackColor = System.Drawing.Color.Transparent;
            this.lblCupos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblCupos.ForeColor = System.Drawing.Color.FromArgb(18, 122, 69);
            this.lblCupos.Location = new System.Drawing.Point(0, 62);
            this.lblCupos.Text = "";
            this.lblCupos.Name = "lblCupos";
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = false;
            this.lblEstudiante.BackColor = System.Drawing.Color.Transparent;
            this.lblEstudiante.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblEstudiante.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblEstudiante.Location = new System.Drawing.Point(22, 82);
            this.lblEstudiante.Size = new System.Drawing.Size(330, 26);
            this.lblEstudiante.Text = "—";
            this.lblEstudiante.Name = "lblEstudiante";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = false;
            this.lblDocumento.BackColor = System.Drawing.Color.Transparent;
            this.lblDocumento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDocumento.Location = new System.Drawing.Point(22, 108);
            this.lblDocumento.Size = new System.Drawing.Size(330, 20);
            this.lblDocumento.Text = "";
            this.lblDocumento.Name = "lblDocumento";
            // 
            // lblPuntaje
            // 
            this.lblPuntaje.AutoSize = true;
            this.lblPuntaje.BackColor = System.Drawing.Color.Transparent;
            this.lblPuntaje.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblPuntaje.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPuntaje.Location = new System.Drawing.Point(22, 140);
            this.lblPuntaje.Text = "Puntaje (0 a 100)";
            this.lblPuntaje.Name = "lblPuntaje";
            // 
            // numPuntaje
            // 
            this.numPuntaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPuntaje.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numPuntaje.Location = new System.Drawing.Point(22, 162);
            this.numPuntaje.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numPuntaje.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numPuntaje.Size = new System.Drawing.Size(150, 25);
            this.numPuntaje.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.numPuntaje.Name = "numPuntaje";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.BackColor = System.Drawing.Color.Transparent;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblResultado.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblResultado.Location = new System.Drawing.Point(188, 140);
            this.lblResultado.Text = "Resultado";
            this.lblResultado.Name = "lblResultado";
            // 
            // cboResultado
            // 
            this.cboResultado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResultado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboResultado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboResultado.FormattingEnabled = true;
            this.cboResultado.Location = new System.Drawing.Point(188, 162);
            this.cboResultado.Size = new System.Drawing.Size(170, 25);
            this.cboResultado.Name = "cboResultado";
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.BackColor = System.Drawing.Color.Transparent;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblObservacion.Location = new System.Drawing.Point(22, 210);
            this.lblObservacion.Text = "Observación";
            this.lblObservacion.Name = "lblObservacion";
            // 
            // campoObservacion
            // 
            this.campoObservacion.Location = new System.Drawing.Point(22, 232);
            this.campoObservacion.Size = new System.Drawing.Size(336, 96);
            this.campoObservacion.MaxLength = 300;
            this.campoObservacion.Multilinea = true;
            this.campoObservacion.Name = "campoObservacion";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnDocumento);
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Size = new System.Drawing.Size(300, 60);
            this.panelBotones.Name = "panelBotones";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Primario;
            this.btnGuardar.Icono = "\uE74E";
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnGuardar.Size = new System.Drawing.Size(180, 40);
            this.btnGuardar.Text = "Guardar evaluación";
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnDocumento
            // 
            this.btnDocumento.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Secundario;
            this.btnDocumento.Icono = "\uE8A5";
            this.btnDocumento.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnDocumento.Size = new System.Drawing.Size(118, 40);
            this.btnDocumento.Text = "Ver PDF";
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // FrmEvaluacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaLista);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.tarjetaEvaluar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmEvaluacion";
            this.Load += new System.EventHandler(this.FrmEvaluacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaPostulantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntaje)).EndInit();
            this.tarjetaLista.ResumeLayout(false);
            this.tarjetaLista.PerformLayout();
            this.tarjetaEvaluar.ResumeLayout(false);
            this.tarjetaEvaluar.PerformLayout();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelBotones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaAyudantias.Diseno.Tarjeta tarjetaLista;
        private System.Windows.Forms.Panel separador;
        private SistemaAyudantias.Diseno.Tarjeta tarjetaEvaluar;
        private System.Windows.Forms.DataGridView tablaPostulantes;
        private System.Windows.Forms.Panel panelFiltro;
        private System.Windows.Forms.Label lblConvocatoria;
        private System.Windows.Forms.ComboBox cboConvocatoria;
        private System.Windows.Forms.Label lblCupos;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblPuntaje;
        private System.Windows.Forms.NumericUpDown numPuntaje;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.ComboBox cboResultado;
        private System.Windows.Forms.Label lblObservacion;
        private SistemaAyudantias.Diseno.Campo campoObservacion;
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private SistemaAyudantias.Diseno.Boton btnGuardar;
        private SistemaAyudantias.Diseno.Boton btnDocumento;
    }
}
