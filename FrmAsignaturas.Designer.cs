namespace SistemaAyudantias.Formularios
{
    partial class FrmAsignaturas
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
            this.lblCboCarrera = new System.Windows.Forms.Label();
            this.cboCarrera = new System.Windows.Forms.ComboBox();
            this.lblCampoCodigo = new System.Windows.Forms.Label();
            this.campoCodigo = new SistemaAyudantias.Diseno.Campo();
            this.lblCampoNombre = new System.Windows.Forms.Label();
            this.campoNombre = new SistemaAyudantias.Diseno.Campo();
            this.lblNumNivel = new System.Windows.Forms.Label();
            this.numNivel = new System.Windows.Forms.NumericUpDown();
            this.chkActiva = new System.Windows.Forms.CheckBox();
            this.panelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new SistemaAyudantias.Diseno.Boton();
            this.btnNuevo = new SistemaAyudantias.Diseno.Boton();
            this.btnEliminar = new SistemaAyudantias.Diseno.Boton();
            this.tarjetaLista.SuspendLayout();
            this.tarjetaDatos.SuspendLayout();
            this.panelBuscar.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // tarjetaLista
            // 
            this.tarjetaLista.Controls.Add(this.tablaDatos);
            this.tarjetaLista.Controls.Add(this.panelBuscar);
            this.tarjetaLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaLista.Size = new System.Drawing.Size(400, 300);
            this.tarjetaLista.Subtitulo = "Seleccione una fila para editarla";
            this.tarjetaLista.Titulo = "Asignaturas registradas";
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
            this.tarjetaDatos.Controls.Add(this.lblCboCarrera);
            this.tarjetaDatos.Controls.Add(this.cboCarrera);
            this.tarjetaDatos.Controls.Add(this.lblCampoCodigo);
            this.tarjetaDatos.Controls.Add(this.campoCodigo);
            this.tarjetaDatos.Controls.Add(this.lblCampoNombre);
            this.tarjetaDatos.Controls.Add(this.campoNombre);
            this.tarjetaDatos.Controls.Add(this.lblNumNivel);
            this.tarjetaDatos.Controls.Add(this.numNivel);
            this.tarjetaDatos.Controls.Add(this.chkActiva);
            this.tarjetaDatos.Controls.Add(this.panelBotones);
            this.tarjetaDatos.Dock = System.Windows.Forms.DockStyle.Right;
            this.tarjetaDatos.Size = new System.Drawing.Size(400, 300);
            this.tarjetaDatos.Subtitulo = "Nuevo registro";
            this.tarjetaDatos.Titulo = "Datos de la asignatura";
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
            // lblCboCarrera
            // 
            this.lblCboCarrera.AutoSize = true;
            this.lblCboCarrera.BackColor = System.Drawing.Color.Transparent;
            this.lblCboCarrera.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCboCarrera.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCboCarrera.Location = new System.Drawing.Point(22, 82);
            this.lblCboCarrera.Text = "Carrera";
            this.lblCboCarrera.Name = "lblCboCarrera";
            // 
            // cboCarrera
            // 
            this.cboCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarrera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCarrera.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCarrera.FormattingEnabled = true;
            this.cboCarrera.Location = new System.Drawing.Point(22, 104);
            this.cboCarrera.Size = new System.Drawing.Size(356, 25);
            this.cboCarrera.Name = "cboCarrera";
            // 
            // lblCampoCodigo
            // 
            this.lblCampoCodigo.AutoSize = true;
            this.lblCampoCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoCodigo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoCodigo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoCodigo.Location = new System.Drawing.Point(22, 154);
            this.lblCampoCodigo.Text = "Código";
            this.lblCampoCodigo.Name = "lblCampoCodigo";
            // 
            // campoCodigo
            // 
            this.campoCodigo.Location = new System.Drawing.Point(22, 176);
            this.campoCodigo.Size = new System.Drawing.Size(356, 40);
            this.campoCodigo.MaxLength = 20;
            this.campoCodigo.Marcador = "Ej.: ISW-501";
            this.campoCodigo.Name = "campoCodigo";
            // 
            // lblCampoNombre
            // 
            this.lblCampoNombre.AutoSize = true;
            this.lblCampoNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoNombre.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoNombre.Location = new System.Drawing.Point(22, 226);
            this.lblCampoNombre.Text = "Nombre de la asignatura";
            this.lblCampoNombre.Name = "lblCampoNombre";
            // 
            // campoNombre
            // 
            this.campoNombre.Location = new System.Drawing.Point(22, 248);
            this.campoNombre.Size = new System.Drawing.Size(356, 40);
            this.campoNombre.MaxLength = 150;
            this.campoNombre.Name = "campoNombre";
            // 
            // lblNumNivel
            // 
            this.lblNumNivel.AutoSize = true;
            this.lblNumNivel.BackColor = System.Drawing.Color.Transparent;
            this.lblNumNivel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblNumNivel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNumNivel.Location = new System.Drawing.Point(22, 298);
            this.lblNumNivel.Text = "Nivel (semestre)";
            this.lblNumNivel.Name = "lblNumNivel";
            // 
            // numNivel
            // 
            this.numNivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numNivel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numNivel.Location = new System.Drawing.Point(22, 320);
            this.numNivel.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numNivel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNivel.Size = new System.Drawing.Size(356, 25);
            this.numNivel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNivel.Name = "numNivel";
            // 
            // chkActiva
            // 
            this.chkActiva.AutoSize = true;
            this.chkActiva.BackColor = System.Drawing.Color.White;
            this.chkActiva.Checked = true;
            this.chkActiva.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActiva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkActiva.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActiva.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.chkActiva.Location = new System.Drawing.Point(22, 374);
            this.chkActiva.Text = "Asignatura activa";
            this.chkActiva.UseVisualStyleBackColor = false;
            this.chkActiva.Name = "chkActiva";
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
            // FrmAsignaturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaLista);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.tarjetaDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmAsignaturas";
            this.Load += new System.EventHandler(this.FrmAsignaturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNivel)).EndInit();
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
        private System.Windows.Forms.Label lblCboCarrera;
        private System.Windows.Forms.ComboBox cboCarrera;
        private System.Windows.Forms.Label lblCampoCodigo;
        private SistemaAyudantias.Diseno.Campo campoCodigo;
        private System.Windows.Forms.Label lblCampoNombre;
        private SistemaAyudantias.Diseno.Campo campoNombre;
        private System.Windows.Forms.Label lblNumNivel;
        private System.Windows.Forms.NumericUpDown numNivel;
        private System.Windows.Forms.CheckBox chkActiva;
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private SistemaAyudantias.Diseno.Boton btnGuardar;
        private SistemaAyudantias.Diseno.Boton btnNuevo;
        private SistemaAyudantias.Diseno.Boton btnEliminar;
    }
}
