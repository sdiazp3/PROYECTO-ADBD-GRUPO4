namespace SistemaAyudantias.Formularios
{
    partial class FrmReportes
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
            this.tarjetaResultados = new SistemaAyudantias.Diseno.Tarjeta();
            this.separador = new System.Windows.Forms.Panel();
            this.tarjetaFiltros = new SistemaAyudantias.Diseno.Tarjeta();
            this.tablaReporte = new System.Windows.Forms.DataGridView();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.cboCarrera = new System.Windows.Forms.ComboBox();
            this.lblAsignatura = new System.Windows.Forms.Label();
            this.cboAsignatura = new System.Windows.Forms.ComboBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.campoCedula = new SistemaAyudantias.Diseno.Campo();
            this.btnConsultar = new SistemaAyudantias.Diseno.Boton();
            this.panelExportar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPdf = new SistemaAyudantias.Diseno.Boton();
            this.btnWord = new SistemaAyudantias.Diseno.Boton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tarjetaResultados.SuspendLayout();
            this.tarjetaFiltros.SuspendLayout();
            this.panelExportar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // tarjetaResultados
            // 
            this.tarjetaResultados.Controls.Add(this.tablaReporte);
            this.tarjetaResultados.Controls.Add(this.panelExportar);
            this.tarjetaResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaResultados.Size = new System.Drawing.Size(400, 300);
            this.tarjetaResultados.Subtitulo = "Vista previa del reporte";
            this.tarjetaResultados.Titulo = "Resultados";
            this.tarjetaResultados.Name = "tarjetaResultados";
            // 
            // separador
            // 
            this.separador.Dock = System.Windows.Forms.DockStyle.Top;
            this.separador.Size = new System.Drawing.Size(18, 18);
            this.separador.Name = "separador";
            // 
            // tarjetaFiltros
            // 
            this.tarjetaFiltros.Controls.Add(this.lblPeriodo);
            this.tarjetaFiltros.Controls.Add(this.cboPeriodo);
            this.tarjetaFiltros.Controls.Add(this.lblCarrera);
            this.tarjetaFiltros.Controls.Add(this.cboCarrera);
            this.tarjetaFiltros.Controls.Add(this.lblAsignatura);
            this.tarjetaFiltros.Controls.Add(this.cboAsignatura);
            this.tarjetaFiltros.Controls.Add(this.lblCedula);
            this.tarjetaFiltros.Controls.Add(this.campoCedula);
            this.tarjetaFiltros.Controls.Add(this.btnConsultar);
            this.tarjetaFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.tarjetaFiltros.Size = new System.Drawing.Size(400, 172);
            this.tarjetaFiltros.Subtitulo = "Filtre por período, carrera, asignatura o estudiante";
            this.tarjetaFiltros.Titulo = "Reporte de postulaciones";
            this.tarjetaFiltros.Name = "tarjetaFiltros";
            // 
            // tablaReporte
            // 
            this.tablaReporte.BackgroundColor = System.Drawing.Color.White;
            this.tablaReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaReporte.ReadOnly = true;
            this.tablaReporte.RowHeadersVisible = false;
            this.tablaReporte.AllowUserToAddRows = false;
            this.tablaReporte.Size = new System.Drawing.Size(400, 300);
            this.tablaReporte.Name = "tablaReporte";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.BackColor = System.Drawing.Color.Transparent;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPeriodo.Location = new System.Drawing.Point(22, 82);
            this.lblPeriodo.Text = "Período";
            this.lblPeriodo.Name = "lblPeriodo";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPeriodo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(22, 104);
            this.cboPeriodo.Size = new System.Drawing.Size(190, 25);
            this.cboPeriodo.Name = "cboPeriodo";
            // 
            // lblCarrera
            // 
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.BackColor = System.Drawing.Color.Transparent;
            this.lblCarrera.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCarrera.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCarrera.Location = new System.Drawing.Point(228, 82);
            this.lblCarrera.Text = "Carrera";
            this.lblCarrera.Name = "lblCarrera";
            // 
            // cboCarrera
            // 
            this.cboCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarrera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCarrera.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCarrera.FormattingEnabled = true;
            this.cboCarrera.Location = new System.Drawing.Point(228, 104);
            this.cboCarrera.Size = new System.Drawing.Size(210, 25);
            this.cboCarrera.Name = "cboCarrera";
            this.cboCarrera.SelectedIndexChanged += new System.EventHandler(this.cboCarrera_SelectedIndexChanged);
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AutoSize = true;
            this.lblAsignatura.BackColor = System.Drawing.Color.Transparent;
            this.lblAsignatura.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblAsignatura.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblAsignatura.Location = new System.Drawing.Point(454, 82);
            this.lblAsignatura.Text = "Asignatura";
            this.lblAsignatura.Name = "lblAsignatura";
            // 
            // cboAsignatura
            // 
            this.cboAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsignatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAsignatura.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboAsignatura.FormattingEnabled = true;
            this.cboAsignatura.Location = new System.Drawing.Point(454, 104);
            this.cboAsignatura.Size = new System.Drawing.Size(240, 25);
            this.cboAsignatura.Name = "cboAsignatura";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.BackColor = System.Drawing.Color.Transparent;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCedula.Location = new System.Drawing.Point(710, 82);
            this.lblCedula.Text = "Cédula del estudiante";
            this.lblCedula.Name = "lblCedula";
            // 
            // campoCedula
            // 
            this.campoCedula.Location = new System.Drawing.Point(710, 100);
            this.campoCedula.Size = new System.Drawing.Size(160, 40);
            this.campoCedula.MaxLength = 10;
            this.campoCedula.Marcador = "Opcional";
            this.campoCedula.Name = "campoCedula";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Primario;
            this.btnConsultar.Icono = "\uE721";
            this.btnConsultar.Location = new System.Drawing.Point(886, 100);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnConsultar.Size = new System.Drawing.Size(124, 40);
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // panelExportar
            // 
            this.panelExportar.Controls.Add(this.btnPdf);
            this.panelExportar.Controls.Add(this.btnWord);
            this.panelExportar.Controls.Add(this.lblTotal);
            this.panelExportar.BackColor = System.Drawing.Color.White;
            this.panelExportar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelExportar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelExportar.Size = new System.Drawing.Size(400, 62);
            this.panelExportar.Name = "panelExportar";
            // 
            // btnPdf
            // 
            this.btnPdf.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Peligro;
            this.btnPdf.Icono = "\uE8A5";
            this.btnPdf.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnPdf.Size = new System.Drawing.Size(150, 40);
            this.btnPdf.Text = "Exportar PDF";
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnWord
            // 
            this.btnWord.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Primario;
            this.btnWord.Icono = "\uE8A5";
            this.btnWord.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnWord.Size = new System.Drawing.Size(160, 40);
            this.btnWord.Text = "Exportar Word";
            this.btnWord.Name = "btnWord";
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTotal.Text = "0 registros";
            this.lblTotal.Margin = new System.Windows.Forms.Padding(10, 12, 0, 0);
            this.lblTotal.Name = "lblTotal";
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaResultados);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.tarjetaFiltros);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaReporte)).EndInit();
            this.tarjetaResultados.ResumeLayout(false);
            this.tarjetaResultados.PerformLayout();
            this.tarjetaFiltros.ResumeLayout(false);
            this.tarjetaFiltros.PerformLayout();
            this.panelExportar.ResumeLayout(false);
            this.panelExportar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaAyudantias.Diseno.Tarjeta tarjetaResultados;
        private System.Windows.Forms.Panel separador;
        private SistemaAyudantias.Diseno.Tarjeta tarjetaFiltros;
        private System.Windows.Forms.DataGridView tablaReporte;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.ComboBox cboCarrera;
        private System.Windows.Forms.Label lblAsignatura;
        private System.Windows.Forms.ComboBox cboAsignatura;
        private System.Windows.Forms.Label lblCedula;
        private SistemaAyudantias.Diseno.Campo campoCedula;
        private SistemaAyudantias.Diseno.Boton btnConsultar;
        private System.Windows.Forms.FlowLayoutPanel panelExportar;
        private SistemaAyudantias.Diseno.Boton btnPdf;
        private SistemaAyudantias.Diseno.Boton btnWord;
        private System.Windows.Forms.Label lblTotal;
    }
}
