namespace SistemaAyudantias.Formularios
{
    partial class FrmUsuarios
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
            this.lblCampoCedula = new System.Windows.Forms.Label();
            this.campoCedula = new SistemaAyudantias.Diseno.Campo();
            this.lblCboRol = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblCampoNombres = new System.Windows.Forms.Label();
            this.campoNombres = new SistemaAyudantias.Diseno.Campo();
            this.lblCampoApellidos = new System.Windows.Forms.Label();
            this.campoApellidos = new SistemaAyudantias.Diseno.Campo();
            this.lblCampoCorreo = new System.Windows.Forms.Label();
            this.campoCorreo = new SistemaAyudantias.Diseno.Campo();
            this.lblCboCarrera = new System.Windows.Forms.Label();
            this.cboCarrera = new System.Windows.Forms.ComboBox();
            this.lblCampoClave = new System.Windows.Forms.Label();
            this.campoClave = new SistemaAyudantias.Diseno.Campo();
            this.panelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new SistemaAyudantias.Diseno.Boton();
            this.btnNuevo = new SistemaAyudantias.Diseno.Boton();
            this.btnEliminar = new SistemaAyudantias.Diseno.Boton();
            this.btnEstado = new SistemaAyudantias.Diseno.Boton();
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
            this.tarjetaLista.Titulo = "Usuarios del sistema";
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
            this.tarjetaDatos.Controls.Add(this.lblCampoCedula);
            this.tarjetaDatos.Controls.Add(this.campoCedula);
            this.tarjetaDatos.Controls.Add(this.lblCboRol);
            this.tarjetaDatos.Controls.Add(this.cboRol);
            this.tarjetaDatos.Controls.Add(this.lblCampoNombres);
            this.tarjetaDatos.Controls.Add(this.campoNombres);
            this.tarjetaDatos.Controls.Add(this.lblCampoApellidos);
            this.tarjetaDatos.Controls.Add(this.campoApellidos);
            this.tarjetaDatos.Controls.Add(this.lblCampoCorreo);
            this.tarjetaDatos.Controls.Add(this.campoCorreo);
            this.tarjetaDatos.Controls.Add(this.lblCboCarrera);
            this.tarjetaDatos.Controls.Add(this.cboCarrera);
            this.tarjetaDatos.Controls.Add(this.lblCampoClave);
            this.tarjetaDatos.Controls.Add(this.campoClave);
            this.tarjetaDatos.Controls.Add(this.panelBotones);
            this.tarjetaDatos.Dock = System.Windows.Forms.DockStyle.Right;
            this.tarjetaDatos.Size = new System.Drawing.Size(480, 300);
            this.tarjetaDatos.Subtitulo = "Nuevo registro";
            this.tarjetaDatos.Titulo = "Datos del usuario";
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
            // lblCampoCedula
            // 
            this.lblCampoCedula.AutoSize = true;
            this.lblCampoCedula.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoCedula.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoCedula.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoCedula.Location = new System.Drawing.Point(22, 82);
            this.lblCampoCedula.Text = "Cédula";
            this.lblCampoCedula.Name = "lblCampoCedula";
            // 
            // campoCedula
            // 
            this.campoCedula.Location = new System.Drawing.Point(22, 104);
            this.campoCedula.Size = new System.Drawing.Size(210, 40);
            this.campoCedula.MaxLength = 10;
            this.campoCedula.Marcador = "10 dígitos";
            this.campoCedula.Name = "campoCedula";
            // 
            // lblCboRol
            // 
            this.lblCboRol.AutoSize = true;
            this.lblCboRol.BackColor = System.Drawing.Color.Transparent;
            this.lblCboRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCboRol.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCboRol.Location = new System.Drawing.Point(248, 82);
            this.lblCboRol.Text = "Rol";
            this.lblCboRol.Name = "lblCboRol";
            // 
            // cboRol
            // 
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(248, 104);
            this.cboRol.Size = new System.Drawing.Size(210, 25);
            this.cboRol.Name = "cboRol";
            this.cboRol.SelectedIndexChanged += new System.EventHandler(this.cboRol_SelectedIndexChanged);
            // 
            // lblCampoNombres
            // 
            this.lblCampoNombres.AutoSize = true;
            this.lblCampoNombres.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoNombres.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoNombres.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoNombres.Location = new System.Drawing.Point(22, 154);
            this.lblCampoNombres.Text = "Nombres";
            this.lblCampoNombres.Name = "lblCampoNombres";
            // 
            // campoNombres
            // 
            this.campoNombres.Location = new System.Drawing.Point(22, 176);
            this.campoNombres.Size = new System.Drawing.Size(210, 40);
            this.campoNombres.MaxLength = 80;
            this.campoNombres.Name = "campoNombres";
            // 
            // lblCampoApellidos
            // 
            this.lblCampoApellidos.AutoSize = true;
            this.lblCampoApellidos.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoApellidos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoApellidos.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoApellidos.Location = new System.Drawing.Point(248, 154);
            this.lblCampoApellidos.Text = "Apellidos";
            this.lblCampoApellidos.Name = "lblCampoApellidos";
            // 
            // campoApellidos
            // 
            this.campoApellidos.Location = new System.Drawing.Point(248, 176);
            this.campoApellidos.Size = new System.Drawing.Size(210, 40);
            this.campoApellidos.MaxLength = 80;
            this.campoApellidos.Name = "campoApellidos";
            // 
            // lblCampoCorreo
            // 
            this.lblCampoCorreo.AutoSize = true;
            this.lblCampoCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoCorreo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoCorreo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoCorreo.Location = new System.Drawing.Point(22, 226);
            this.lblCampoCorreo.Text = "Correo institucional";
            this.lblCampoCorreo.Name = "lblCampoCorreo";
            // 
            // campoCorreo
            // 
            this.campoCorreo.Location = new System.Drawing.Point(22, 248);
            this.campoCorreo.Size = new System.Drawing.Size(436, 40);
            this.campoCorreo.MaxLength = 120;
            this.campoCorreo.Marcador = "usuario@uteq.edu.ec";
            this.campoCorreo.Name = "campoCorreo";
            // 
            // lblCboCarrera
            // 
            this.lblCboCarrera.AutoSize = true;
            this.lblCboCarrera.BackColor = System.Drawing.Color.Transparent;
            this.lblCboCarrera.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCboCarrera.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCboCarrera.Location = new System.Drawing.Point(22, 298);
            this.lblCboCarrera.Text = "Carrera (coordinadores, docentes y estudiantes)";
            this.lblCboCarrera.Name = "lblCboCarrera";
            // 
            // cboCarrera
            // 
            this.cboCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarrera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCarrera.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCarrera.FormattingEnabled = true;
            this.cboCarrera.Location = new System.Drawing.Point(22, 320);
            this.cboCarrera.Size = new System.Drawing.Size(436, 25);
            this.cboCarrera.Name = "cboCarrera";
            // 
            // lblCampoClave
            // 
            this.lblCampoClave.AutoSize = true;
            this.lblCampoClave.BackColor = System.Drawing.Color.Transparent;
            this.lblCampoClave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblCampoClave.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCampoClave.Location = new System.Drawing.Point(22, 370);
            this.lblCampoClave.Text = "Contraseña inicial (solo al crear el usuario)";
            this.lblCampoClave.Name = "lblCampoClave";
            // 
            // campoClave
            // 
            this.campoClave.Location = new System.Drawing.Point(22, 392);
            this.campoClave.Size = new System.Drawing.Size(436, 40);
            this.campoClave.MaxLength = 60;
            this.campoClave.Marcador = "Mínimo 8 caracteres";
            this.campoClave.Contrasena = true;
            this.campoClave.Name = "campoClave";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnNuevo);
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Controls.Add(this.btnEstado);
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Size = new System.Drawing.Size(300, 110);
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
            // btnEstado
            // 
            this.btnEstado.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Secundario;
            this.btnEstado.Icono = "\uE72E";
            this.btnEstado.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnEstado.Size = new System.Drawing.Size(190, 40);
            this.btnEstado.Text = "Activar / Desactivar";
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaLista);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.tarjetaDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmUsuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
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
        private System.Windows.Forms.Label lblCampoCedula;
        private SistemaAyudantias.Diseno.Campo campoCedula;
        private System.Windows.Forms.Label lblCboRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblCampoNombres;
        private SistemaAyudantias.Diseno.Campo campoNombres;
        private System.Windows.Forms.Label lblCampoApellidos;
        private SistemaAyudantias.Diseno.Campo campoApellidos;
        private System.Windows.Forms.Label lblCampoCorreo;
        private SistemaAyudantias.Diseno.Campo campoCorreo;
        private System.Windows.Forms.Label lblCboCarrera;
        private System.Windows.Forms.ComboBox cboCarrera;
        private System.Windows.Forms.Label lblCampoClave;
        private SistemaAyudantias.Diseno.Campo campoClave;
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private SistemaAyudantias.Diseno.Boton btnGuardar;
        private SistemaAyudantias.Diseno.Boton btnNuevo;
        private SistemaAyudantias.Diseno.Boton btnEliminar;
        private SistemaAyudantias.Diseno.Boton btnEstado;
    }
}
