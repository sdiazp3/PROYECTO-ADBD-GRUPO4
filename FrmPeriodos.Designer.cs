namespace SistemaAyudantias.Formularios
{
    partial class FrmPeriodos
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
            this.lblCampoNombre = new System.Windows.Forms.Label();
            this.campoNombre = new SistemaAyudantias.Diseno.Campo();
            this.lblDtpInicio = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblDtpFin = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.panelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new SistemaAyudantias.Diseno.Boton();
            this.btnNuevo = new SistemaAyudantias.Diseno.Boton();
            this.btnEliminar = new SistemaAyudantias.Diseno.Boton();
            this.tarjetaLista.SuspendLayout();
            this.tarjetaDatos.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // tarjetaLista
            // 
            this.tarjetaLista.Controls.Add(this.tablaDatos);
            this.tarjetaLista.Controls.Add(this.panelBuscar);
            this.tarjetaLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaLista.Size = new System.Drawing.Size(400, 300);
            this.tarjetaLista.Subtitulo = "Seleccione una fila para editarla";
            this.tarjetaLista.Titulo = "Períodos académicos";
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
            this.tarjetaDatos.Controls.Add(this.lblCampoNombre);
            this.tarjetaDatos.Controls.Add(this.campoNombre);
            this.tarjetaDatos.Controls.Add(this.lblDtpInicio);
            this.tarjetaDatos.Controls.Add(this.dtpInicio);
            this.tarjetaDatos.Controls.Add(this.lblDtpFin);
            this.tarjetaDatos.Controls.Add(this.dtpFin);
            this.tarjetaDatos.Controls.Add(this.chkActivo);
            this.tarjetaDatos.Controls.Add(this.panelBotones);
            this.tarjetaDatos.Dock = System.Windows.Forms.DockStyle.Right;
            this.tarjetaDatos.Size = new System.Drawing.Size(400, 300);
            this.tarjetaDatos.Subtitulo = "Nuevo registro";
            this.tarjetaDatos.Titulo = "Datos del período";
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
            // lblCampoNombre
            // 
            this.lblCampoNombre.AutoSize = true;
            this.lblCampoNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoNombre.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoNombre.Location = new System.Drawing.Point(22, 82);
            this.lblCampoNombre.Text = "Nombre del período";
            this.lblCampoNombre.Name = "lblCampoNombre";
            // 
            // campoNombre
            // 
            this.campoNombre.Location = new System.Drawing.Point(22, 104);
            this.campoNombre.Size = new System.Drawing.Size(356, 40);
            this.campoNombre.MaxLength = 60;
            this.campoNombre.Marcador = "Ej.: 2026 - 2027 PAO 1";
            this.campoNombre.Name = "campoNombre";
            // 
            // lblDtpInicio
            // 
            this.lblDtpInicio.AutoSize = true;
            this.lblDtpInicio.BackColor = System.Drawing.Color.Transparent;
            this.lblDtpInicio.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDtpInicio.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDtpInicio.Location = new System.Drawing.Point(22, 154);
            this.lblDtpInicio.Text = "Fecha de inicio";
            this.lblDtpInicio.Name = "lblDtpInicio";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(22, 176);
            this.dtpInicio.Size = new System.Drawing.Size(356, 25);
            this.dtpInicio.Name = "dtpInicio";
            // 
            // lblDtpFin
            // 
            this.lblDtpFin.AutoSize = true;
            this.lblDtpFin.BackColor = System.Drawing.Color.Transparent;
            this.lblDtpFin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblDtpFin.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDtpFin.Location = new System.Drawing.Point(22, 226);
            this.lblDtpFin.Text = "Fecha de fin";
            this.lblDtpFin.Name = "lblDtpFin";
            // 
            // dtpFin
            // 
            this.dtpFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(22, 248);
            this.dtpFin.Size = new System.Drawing.Size(356, 25);
            this.dtpFin.Name = "dtpFin";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.BackColor = System.Drawing.Color.White;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActivo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.chkActivo.Location = new System.Drawing.Point(22, 302);
            this.chkActivo.Text = "Período activo";
            this.chkActivo.UseVisualStyleBackColor = false;
            this.chkActivo.Name = "chkActivo";
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
            // FrmPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaLista);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.tarjetaDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmPeriodos";
            this.Load += new System.EventHandler(this.FrmPeriodos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).EndInit();
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
        private System.Windows.Forms.Label lblCampoNombre;
        private SistemaAyudantias.Diseno.Campo campoNombre;
        private System.Windows.Forms.Label lblDtpInicio;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblDtpFin;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private SistemaAyudantias.Diseno.Boton btnGuardar;
        private SistemaAyudantias.Diseno.Boton btnNuevo;
        private SistemaAyudantias.Diseno.Boton btnEliminar;
    }
}
