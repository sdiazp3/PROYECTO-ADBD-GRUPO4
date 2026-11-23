namespace SistemaAyudantias.Formularios
{
    partial class FrmConvocatorias
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
            this.tarjetaDatos = new SistemaAyudantias.Diseno.Tarjeta();
            this.tablaDatos = new System.Windows.Forms.DataGridView();
            this.panelBuscar = new System.Windows.Forms.Panel();
            this.campoBuscar = new SistemaAyudantias.Diseno.Campo();
            this.lblCboAsignatura = new System.Windows.Forms.Label();
            this.cboAsignatura = new System.Windows.Forms.ComboBox();
            this.lblCboPeriodo = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.lblNumCupos = new System.Windows.Forms.Label();
            this.numCupos = new System.Windows.Forms.NumericUpDown();
            this.lblNumHoras = new System.Windows.Forms.Label();
            this.numHoras = new System.Windows.Forms.NumericUpDown();
            this.lblDtpDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDtpHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblCampoRequisitos = new System.Windows.Forms.Label();
            this.campoRequisitos = new SistemaAyudantias.Diseno.Campo();
            this.panelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new SistemaAyudantias.Diseno.Boton();
            this.btnNuevo = new SistemaAyudantias.Diseno.Boton();
            this.btnEliminar = new SistemaAyudantias.Diseno.Boton();
            this.tarjetaLista.SuspendLayout();
            this.tarjetaDatos.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).BeginInit();
            this.SuspendLayout();
            // 
            // tarjetaLista
            // 
            this.tarjetaLista.Controls.Add(this.tablaDatos);
            this.tarjetaLista.Controls.Add(this.panelBuscar);
            this.tarjetaLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaLista.Size = new System.Drawing.Size(400, 300);
            this.tarjetaLista.Subtitulo = "Seleccione una fila para editarla";
            this.tarjetaLista.Titulo = "Convocatorias de mi carrera";
            this.tarjetaLista.Name = "tarjetaLista";
            // 
            // separador
            // 
            this.separador.Dock = System.Windows.Forms.DockStyle.Right;
            this.separador.Size = new System.Drawing.Size(18, 18);
            this.separador.Name = "separador";
            // 
            // tarjetaDatos
            // 
            this.tarjetaDatos.Controls.Add(this.lblCboAsignatura);
            this.tarjetaDatos.Controls.Add(this.cboAsignatura);
            this.tarjetaDatos.Controls.Add(this.lblCboPeriodo);
            this.tarjetaDatos.Controls.Add(this.cboPeriodo);
            this.tarjetaDatos.Controls.Add(this.lblNumCupos);
            this.tarjetaDatos.Controls.Add(this.numCupos);
            this.tarjetaDatos.Controls.Add(this.lblNumHoras);
            this.tarjetaDatos.Controls.Add(this.numHoras);
            this.tarjetaDatos.Controls.Add(this.lblDtpDesde);
            this.tarjetaDatos.Controls.Add(this.dtpDesde);
            this.tarjetaDatos.Controls.Add(this.lblDtpHasta);
            this.tarjetaDatos.Controls.Add(this.dtpHasta);
            this.tarjetaDatos.Controls.Add(this.lblCampoRequisitos);
            this.tarjetaDatos.Controls.Add(this.campoRequisitos);
            this.tarjetaDatos.Controls.Add(this.panelBotones);
            this.tarjetaDatos.Dock = System.Windows.Forms.DockStyle.Right;
            this.tarjetaDatos.Size = new System.Drawing.Size(470, 300);
            this.tarjetaDatos.Subtitulo = "Nuevo registro";
            this.tarjetaDatos.Titulo = "Datos de la convocatoria";
            this.tarjetaDatos.Name = "tarjetaDatos";
            // 
            // tablaDatos
            // 
            this.tablaDatos.BackgroundColor = System.Drawing.Color.White;
            this.tablaDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaDatos.ReadOnly = true;
            this.tablaDatos.RowHeadersVisible = false;
            this.tablaDatos.AllowUserToAddRows = false;
            this.tablaDatos.Size = new System.Drawing.Size(400, 300);
            this.tablaDatos.Name = "tablaDatos";
            this.tablaDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDatos_CellClick);
            // 
            // panelBuscar
            // 
            this.panelBuscar.Controls.Add(this.campoBuscar);
            this.panelBuscar.BackColor = System.Drawing.Color.White;
            this.panelBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBuscar.Size = new System.Drawing.Size(400, 54);
            this.panelBuscar.Name = "panelBuscar";
            // 
            // campoBuscar
            // 
            this.campoBuscar.Location = new System.Drawing.Point(0, 0);
            this.campoBuscar.Size = new System.Drawing.Size(300, 40);
            this.campoBuscar.Marcador = "Buscar...";
            this.campoBuscar.Icono = "\uE721";
            this.campoBuscar.Name = "campoBuscar";
            this.campoBuscar.TextChanged += new System.EventHandler(this.campoBuscar_TextChanged);
            // 
            // lblCboAsignatura
            // 
            this.lblCboAsignatura.AutoSize = true;
            this.lblCboAsignatura.BackColor = System.Drawing.Color.Transparent;
            this.lblCboAsignatura.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCboAsignatura.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCboAsignatura.Location = new System.Drawing.Point(22, 82);
            this.lblCboAsignatura.Text = "Asignatura";
            this.lblCboAsignatura.Name = "lblCboAsignatura";
            // 
            // cboAsignatura
            // 
            this.cboAsignatura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAsignatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAsignatura.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboAsignatura.FormattingEnabled = true;
            this.cboAsignatura.Location = new System.Drawing.Point(22, 104);
            this.cboAsignatura.Size = new System.Drawing.Size(426, 25);
            this.cboAsignatura.Name = "cboAsignatura";
            // 
            // lblCboPeriodo
            // 
            this.lblCboPeriodo.AutoSize = true;
            this.lblCboPeriodo.BackColor = System.Drawing.Color.Transparent;
            this.lblCboPeriodo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCboPeriodo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCboPeriodo.Location = new System.Drawing.Point(22, 154);
            this.lblCboPeriodo.Text = "Período académico";
            this.lblCboPeriodo.Name = "lblCboPeriodo";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPeriodo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(22, 176);
            this.cboPeriodo.Size = new System.Drawing.Size(426, 25);
            this.cboPeriodo.Name = "cboPeriodo";
            // 
            // lblNumCupos
            // 
            this.lblNumCupos.AutoSize = true;
            this.lblNumCupos.BackColor = System.Drawing.Color.Transparent;
            this.lblNumCupos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblNumCupos.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNumCupos.Location = new System.Drawing.Point(22, 226);
            this.lblNumCupos.Text = "Cupos";
            this.lblNumCupos.Name = "lblNumCupos";
            // 
            // numCupos
            // 
            this.numCupos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCupos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numCupos.Location = new System.Drawing.Point(22, 248);
            this.numCupos.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numCupos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCupos.Size = new System.Drawing.Size(205, 25);
            this.numCupos.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCupos.Name = "numCupos";
            // 
            // lblNumHoras
            // 
            this.lblNumHoras.AutoSize = true;
            this.lblNumHoras.BackColor = System.Drawing.Color.Transparent;
            this.lblNumHoras.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblNumHoras.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNumHoras.Location = new System.Drawing.Point(243, 226);
            this.lblNumHoras.Text = "Horas requeridas";
            this.lblNumHoras.Name = "lblNumHoras";
            // 
            // numHoras
            // 
            this.numHoras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numHoras.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numHoras.Location = new System.Drawing.Point(243, 248);
            this.numHoras.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            this.numHoras.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numHoras.Size = new System.Drawing.Size(205, 25);
            this.numHoras.Value = new decimal(new int[] { 64, 0, 0, 0 });
            this.numHoras.Name = "numHoras";
            // 
            // lblDtpDesde
            // 
            this.lblDtpDesde.AutoSize = true;
            this.lblDtpDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDtpDesde.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDtpDesde.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDtpDesde.Location = new System.Drawing.Point(22, 298);
            this.lblDtpDesde.Text = "Postulación desde";
            this.lblDtpDesde.Name = "lblDtpDesde";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(22, 320);
            this.dtpDesde.Size = new System.Drawing.Size(205, 25);
            this.dtpDesde.Name = "dtpDesde";
            // 
            // lblDtpHasta
            // 
            this.lblDtpHasta.AutoSize = true;
            this.lblDtpHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblDtpHasta.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDtpHasta.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDtpHasta.Location = new System.Drawing.Point(243, 298);
            this.lblDtpHasta.Text = "Postulación hasta";
            this.lblDtpHasta.Name = "lblDtpHasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(243, 320);
            this.dtpHasta.Size = new System.Drawing.Size(205, 25);
            this.dtpHasta.Name = "dtpHasta";
            // 
            // lblCampoRequisitos
            // 
            this.lblCampoRequisitos.AutoSize = true;
            this.lblCampoRequisitos.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoRequisitos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoRequisitos.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoRequisitos.Location = new System.Drawing.Point(22, 370);
            this.lblCampoRequisitos.Text = "Requisitos";
            this.lblCampoRequisitos.Name = "lblCampoRequisitos";
            // 
            // campoRequisitos
            // 
            this.campoRequisitos.Location = new System.Drawing.Point(22, 392);
            this.campoRequisitos.Size = new System.Drawing.Size(426, 96);
            this.campoRequisitos.MaxLength = 1000;
            this.campoRequisitos.Multilinea = true;
            this.campoRequisitos.Name = "campoRequisitos";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnNuevo);
            this.panelBotones.Controls.Add(this.btnEliminar);
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
            this.btnGuardar.Size = new System.Drawing.Size(112, 40);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Secundario;
            this.btnNuevo.Icono = "\uE710";
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnNuevo.Size = new System.Drawing.Size(100, 40);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Peligro;
            this.btnEliminar.Icono = "\uE74D";
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnEliminar.Size = new System.Drawing.Size(110, 40);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmConvocatorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaLista);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.tarjetaDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmConvocatorias";
            this.Load += new System.EventHandler(this.FrmConvocatorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).EndInit();
            this.tarjetaLista.ResumeLayout(false);
            this.tarjetaLista.PerformLayout();
            this.tarjetaDatos.ResumeLayout(false);
            this.tarjetaDatos.PerformLayout();
            this.panelBuscar.ResumeLayout(false);
            this.panelBuscar.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelBotones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaAyudantias.Diseno.Tarjeta tarjetaLista;
        private System.Windows.Forms.Panel separador;
        private SistemaAyudantias.Diseno.Tarjeta tarjetaDatos;
        private System.Windows.Forms.DataGridView tablaDatos;
        private System.Windows.Forms.Panel panelBuscar;
        private SistemaAyudantias.Diseno.Campo campoBuscar;
        private System.Windows.Forms.Label lblCboAsignatura;
        private System.Windows.Forms.ComboBox cboAsignatura;
        private System.Windows.Forms.Label lblCboPeriodo;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label lblNumCupos;
        private System.Windows.Forms.NumericUpDown numCupos;
        private System.Windows.Forms.Label lblNumHoras;
        private System.Windows.Forms.NumericUpDown numHoras;
        private System.Windows.Forms.Label lblDtpDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDtpHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblCampoRequisitos;
        private SistemaAyudantias.Diseno.Campo campoRequisitos;
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private SistemaAyudantias.Diseno.Boton btnGuardar;
        private SistemaAyudantias.Diseno.Boton btnNuevo;
        private SistemaAyudantias.Diseno.Boton btnEliminar;
    }
}
