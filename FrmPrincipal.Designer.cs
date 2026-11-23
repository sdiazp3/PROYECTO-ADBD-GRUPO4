namespace SistemaAyudantias.Formularios
{
    partial class FrmPrincipal
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
            panelContenido = new Panel();
            panelCabecera = new Panel();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            panelPeriodo = new Panel();
            lblFecha = new Label();
            lblSoloConsulta = new Label();
            panelMenu = new SistemaAyudantias.Diseno.PanelDegradado();
            picLogo = new PictureBox();
            lblSistema = new Label();
            lblSistema2 = new Label();
            lblSeccion = new Label();
            panelOpciones = new FlowLayoutPanel();
            menuInicio = new SistemaAyudantias.Diseno.MenuBoton();
            menuUsuarios = new SistemaAyudantias.Diseno.MenuBoton();
            menuFacultades = new SistemaAyudantias.Diseno.MenuBoton();
            menuCarreras = new SistemaAyudantias.Diseno.MenuBoton();
            menuAsignaturas = new SistemaAyudantias.Diseno.MenuBoton();
            menuPeriodos = new SistemaAyudantias.Diseno.MenuBoton();
            menuConvocatorias = new SistemaAyudantias.Diseno.MenuBoton();
            menuPostulacion = new SistemaAyudantias.Diseno.MenuBoton();
            menuEvaluacion = new SistemaAyudantias.Diseno.MenuBoton();
            menuPredicciones = new SistemaAyudantias.Diseno.MenuBoton();
            menuReportes = new SistemaAyudantias.Diseno.MenuBoton();
            menuClave = new SistemaAyudantias.Diseno.MenuBoton();
            panelUsuario = new Panel();
            lblUsuario = new Label();
            lblRol = new Label();
            menuSalir = new SistemaAyudantias.Diseno.MenuBoton();
            panelCabecera.SuspendLayout();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelOpciones.SuspendLayout();
            panelUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenido
            // 
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(256, 92);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(24, 4, 24, 20);
            panelContenido.Size = new Size(1110, 676);
            panelContenido.TabIndex = 0;
            // 
            // panelCabecera
            // 
            panelCabecera.Controls.Add(lblTitulo);
            panelCabecera.Controls.Add(lblDescripcion);
            panelCabecera.Controls.Add(panelPeriodo);
            panelCabecera.Controls.Add(lblFecha);
            panelCabecera.Controls.Add(lblSoloConsulta);
            panelCabecera.Dock = DockStyle.Top;
            panelCabecera.Location = new Point(256, 0);
            panelCabecera.Name = "panelCabecera";
            panelCabecera.Padding = new Padding(28, 0, 28, 0);
            panelCabecera.Size = new Size(1110, 92);
            panelCabecera.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(26, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(102, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Inicio";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F);
            lblDescripcion.ForeColor = Color.FromArgb(100, 116, 139);
            lblDescripcion.Location = new Point(31, 63);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(174, 21);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Descripción del módulo";
            lblDescripcion.Click += lblDescripcion_Click;
            // 
            // panelPeriodo
            // 
            panelPeriodo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelPeriodo.BackColor = Color.FromArgb(244, 246, 251);
            panelPeriodo.Cursor = Cursors.Hand;
            panelPeriodo.Location = new Point(772, 12);
            panelPeriodo.Name = "panelPeriodo";
            panelPeriodo.Size = new Size(310, 54);
            panelPeriodo.TabIndex = 2;
            panelPeriodo.Click += panelPeriodo_Click;
            panelPeriodo.Paint += panelPeriodo_Paint;
            panelPeriodo.MouseEnter += panelPeriodo_MouseEnter;
            panelPeriodo.MouseLeave += panelPeriodo_MouseLeave;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Font = new Font("Segoe UI", 8.5F);
            lblFecha.ForeColor = Color.FromArgb(100, 116, 139);
            lblFecha.Location = new Point(772, 70);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(310, 18);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha";
            lblFecha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSoloConsulta
            // 
            lblSoloConsulta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSoloConsulta.BackColor = Color.FromArgb(254, 243, 199);
            lblSoloConsulta.Font = new Font("Segoe UI Semibold", 9F);
            lblSoloConsulta.ForeColor = Color.FromArgb(180, 83, 9);
            lblSoloConsulta.Location = new Point(636, 26);
            lblSoloConsulta.Name = "lblSoloConsulta";
            lblSoloConsulta.Size = new Size(120, 28);
            lblSoloConsulta.TabIndex = 4;
            lblSoloConsulta.Text = "Solo consulta";
            lblSoloConsulta.TextAlign = ContentAlignment.MiddleCenter;
            lblSoloConsulta.Visible = false;
            // 
            // panelMenu
            // 
            panelMenu.ColorFin = Color.FromArgb(14, 92, 56);
            panelMenu.ColorInicio = Color.FromArgb(7, 52, 32);
            panelMenu.Controls.Add(picLogo);
            panelMenu.Controls.Add(lblSistema);
            panelMenu.Controls.Add(lblSistema2);
            panelMenu.Controls.Add(lblSeccion);
            panelMenu.Controls.Add(panelOpciones);
            panelMenu.Controls.Add(panelUsuario);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(256, 768);
            panelMenu.TabIndex = 2;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(18, 18);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(52, 54);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblSistema
            // 
            lblSistema.AutoSize = true;
            lblSistema.BackColor = Color.Transparent;
            lblSistema.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSistema.ForeColor = Color.White;
            lblSistema.Location = new Point(74, 24);
            lblSistema.Name = "lblSistema";
            lblSistema.Size = new Size(142, 32);
            lblSistema.TabIndex = 1;
            lblSistema.Text = "Ayudantías";
            // 
            // lblSistema2
            // 
            lblSistema2.AutoSize = true;
            lblSistema2.BackColor = Color.Transparent;
            lblSistema2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSistema2.ForeColor = Color.White;
            lblSistema2.Location = new Point(72, 52);
            lblSistema2.Name = "lblSistema2";
            lblSistema2.Size = new Size(109, 25);
            lblSistema2.TabIndex = 2;
            lblSistema2.Text = "de Cátedra ";
            // 
            // lblSeccion
            // 
            lblSeccion.AutoSize = true;
            lblSeccion.BackColor = Color.Transparent;
            lblSeccion.Font = new Font("Segoe UI Semibold", 8F);
            lblSeccion.ForeColor = Color.FromArgb(134, 197, 160);
            lblSeccion.Location = new Point(26, 100);
            lblSeccion.Name = "lblSeccion";
            lblSeccion.Size = new Size(122, 19);
            lblSeccion.TabIndex = 3;
            lblSeccion.Text = "MENÚ PRINCIPAL";
            // 
            // panelOpciones
            // 
            panelOpciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelOpciones.BackColor = Color.Transparent;
            panelOpciones.Controls.Add(menuInicio);
            panelOpciones.Controls.Add(menuUsuarios);
            panelOpciones.Controls.Add(menuFacultades);
            panelOpciones.Controls.Add(menuCarreras);
            panelOpciones.Controls.Add(menuAsignaturas);
            panelOpciones.Controls.Add(menuPeriodos);
            panelOpciones.Controls.Add(menuConvocatorias);
            panelOpciones.Controls.Add(menuPostulacion);
            panelOpciones.Controls.Add(menuEvaluacion);
            panelOpciones.Controls.Add(menuPredicciones);
            panelOpciones.Controls.Add(menuReportes);
            panelOpciones.Controls.Add(menuClave);
            panelOpciones.FlowDirection = FlowDirection.TopDown;
            panelOpciones.Location = new Point(0, 124);
            panelOpciones.Name = "panelOpciones";
            panelOpciones.Size = new Size(256, 520);
            panelOpciones.TabIndex = 4;
            panelOpciones.WrapContents = false;
            // 
            // menuInicio
            // 
            menuInicio.BackColor = Color.Transparent;
            menuInicio.Font = new Font("Segoe UI", 10F);
            menuInicio.Icono = "";
            menuInicio.Location = new Point(0, 2);
            menuInicio.Margin = new Padding(0, 2, 0, 2);
            menuInicio.Name = "menuInicio";
            menuInicio.Size = new Size(256, 44);
            menuInicio.TabIndex = 0;
            menuInicio.Text = "Inicio";
            menuInicio.Click += menuInicio_Click;
            // 
            // menuUsuarios
            // 
            menuUsuarios.BackColor = Color.Transparent;
            menuUsuarios.Font = new Font("Segoe UI", 10F);
            menuUsuarios.Icono = "";
            menuUsuarios.Location = new Point(0, 50);
            menuUsuarios.Margin = new Padding(0, 2, 0, 2);
            menuUsuarios.Name = "menuUsuarios";
            menuUsuarios.Size = new Size(256, 44);
            menuUsuarios.TabIndex = 1;
            menuUsuarios.Text = "Usuarios";
            menuUsuarios.Click += menuUsuarios_Click;
            // 
            // menuFacultades
            // 
            menuFacultades.BackColor = Color.Transparent;
            menuFacultades.Font = new Font("Segoe UI", 10F);
            menuFacultades.Icono = "";
            menuFacultades.Location = new Point(0, 98);
            menuFacultades.Margin = new Padding(0, 2, 0, 2);
            menuFacultades.Name = "menuFacultades";
            menuFacultades.Size = new Size(256, 44);
            menuFacultades.TabIndex = 2;
            menuFacultades.Text = "Facultades";
            menuFacultades.Click += menuFacultades_Click;
            // 
            // menuCarreras
            // 
            menuCarreras.BackColor = Color.Transparent;
            menuCarreras.Font = new Font("Segoe UI", 10F);
            menuCarreras.Icono = "";
            menuCarreras.Location = new Point(0, 146);
            menuCarreras.Margin = new Padding(0, 2, 0, 2);
            menuCarreras.Name = "menuCarreras";
            menuCarreras.Size = new Size(256, 44);
            menuCarreras.TabIndex = 3;
            menuCarreras.Text = "Carreras";
            menuCarreras.Click += menuCarreras_Click;
            // 
            // menuAsignaturas
            // 
            menuAsignaturas.BackColor = Color.Transparent;
            menuAsignaturas.Font = new Font("Segoe UI", 10F);
            menuAsignaturas.Icono = "";
            menuAsignaturas.Location = new Point(0, 194);
            menuAsignaturas.Margin = new Padding(0, 2, 0, 2);
            menuAsignaturas.Name = "menuAsignaturas";
            menuAsignaturas.Size = new Size(256, 44);
            menuAsignaturas.TabIndex = 4;
            menuAsignaturas.Text = "Asignaturas";
            menuAsignaturas.Click += menuAsignaturas_Click;
            // 
            // menuPeriodos
            // 
            menuPeriodos.BackColor = Color.Transparent;
            menuPeriodos.Font = new Font("Segoe UI", 10F);
            menuPeriodos.Icono = "";
            menuPeriodos.Location = new Point(0, 242);
            menuPeriodos.Margin = new Padding(0, 2, 0, 2);
            menuPeriodos.Name = "menuPeriodos";
            menuPeriodos.Size = new Size(256, 44);
            menuPeriodos.TabIndex = 5;
            menuPeriodos.Text = "Períodos académicos";
            menuPeriodos.Click += menuPeriodos_Click;
            // 
            // menuConvocatorias
            // 
            menuConvocatorias.BackColor = Color.Transparent;
            menuConvocatorias.Font = new Font("Segoe UI", 10F);
            menuConvocatorias.Icono = "";
            menuConvocatorias.Location = new Point(0, 290);
            menuConvocatorias.Margin = new Padding(0, 2, 0, 2);
            menuConvocatorias.Name = "menuConvocatorias";
            menuConvocatorias.Size = new Size(256, 44);
            menuConvocatorias.TabIndex = 6;
            menuConvocatorias.Text = "Convocatorias";
            menuConvocatorias.Click += menuConvocatorias_Click;
            // 
            // menuPostulacion
            // 
            menuPostulacion.BackColor = Color.Transparent;
            menuPostulacion.Font = new Font("Segoe UI", 10F);
            menuPostulacion.Icono = "";
            menuPostulacion.Location = new Point(0, 338);
            menuPostulacion.Margin = new Padding(0, 2, 0, 2);
            menuPostulacion.Name = "menuPostulacion";
            menuPostulacion.Size = new Size(256, 44);
            menuPostulacion.TabIndex = 7;
            menuPostulacion.Text = "Postularme";
            menuPostulacion.Click += menuPostulacion_Click;
            // 
            // menuEvaluacion
            // 
            menuEvaluacion.BackColor = Color.Transparent;
            menuEvaluacion.Font = new Font("Segoe UI", 10F);
            menuEvaluacion.Icono = "";
            menuEvaluacion.Location = new Point(0, 386);
            menuEvaluacion.Margin = new Padding(0, 2, 0, 2);
            menuEvaluacion.Name = "menuEvaluacion";
            menuEvaluacion.Size = new Size(256, 44);
            menuEvaluacion.TabIndex = 8;
            menuEvaluacion.Text = "Evaluar postulantes";
            menuEvaluacion.Click += menuEvaluacion_Click;
            // 
            // menuPredicciones
            // 
            menuPredicciones.BackColor = Color.Transparent;
            menuPredicciones.Font = new Font("Segoe UI", 10F);
            menuPredicciones.Icono = "";
            menuPredicciones.Location = new Point(0, 434);
            menuPredicciones.Margin = new Padding(0, 2, 0, 2);
            menuPredicciones.Name = "menuPredicciones";
            menuPredicciones.Size = new Size(256, 44);
            menuPredicciones.TabIndex = 9;
            menuPredicciones.Text = "Predicciones";
            menuPredicciones.Click += menuPredicciones_Click;
            // 
            // menuReportes
            // 
            menuReportes.BackColor = Color.Transparent;
            menuReportes.Font = new Font("Segoe UI", 10F);
            menuReportes.Icono = "";
            menuReportes.Location = new Point(0, 482);
            menuReportes.Margin = new Padding(0, 2, 0, 2);
            menuReportes.Name = "menuReportes";
            menuReportes.Size = new Size(256, 44);
            menuReportes.TabIndex = 10;
            menuReportes.Text = "Reportes";
            menuReportes.Click += menuReportes_Click;
            // 
            // menuClave
            // 
            menuClave.BackColor = Color.Transparent;
            menuClave.Font = new Font("Segoe UI", 10F);
            menuClave.Icono = "";
            menuClave.Location = new Point(0, 530);
            menuClave.Margin = new Padding(0, 2, 0, 2);
            menuClave.Name = "menuClave";
            menuClave.Size = new Size(256, 44);
            menuClave.TabIndex = 11;
            menuClave.Text = "Mi contraseña";
            menuClave.Click += menuClave_Click;
            // 
            // panelUsuario
            // 
            panelUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelUsuario.BackColor = Color.Transparent;
            panelUsuario.Controls.Add(lblUsuario);
            panelUsuario.Controls.Add(lblRol);
            panelUsuario.Controls.Add(menuSalir);
            panelUsuario.Location = new Point(14, 660);
            panelUsuario.Name = "panelUsuario";
            panelUsuario.Size = new Size(228, 92);
            panelUsuario.TabIndex = 5;
            panelUsuario.Paint += panelUsuario_Paint;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoEllipsis = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Font = new Font("Segoe UI Semibold", 9.5F);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(58, 12);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(164, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Nombre del usuario";
            // 
            // lblRol
            // 
            lblRol.BackColor = Color.Transparent;
            lblRol.Font = new Font("Segoe UI", 8.5F);
            lblRol.ForeColor = Color.FromArgb(190, 230, 205);
            lblRol.Location = new Point(58, 32);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(164, 18);
            lblRol.TabIndex = 1;
            lblRol.Text = "Rol";
            // 
            // menuSalir
            // 
            menuSalir.BackColor = Color.Transparent;
            menuSalir.Font = new Font("Segoe UI", 10F);
            menuSalir.Icono = "";
            menuSalir.Location = new Point(-12, 52);
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(240, 38);
            menuSalir.TabIndex = 2;
            menuSalir.Text = "Cerrar sesión";
            menuSalir.Click += menuSalir_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 246, 251);
            ClientSize = new Size(1366, 768);
            Controls.Add(panelContenido);
            Controls.Add(panelCabecera);
            Controls.Add(panelMenu);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1180, 700);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Ayudantías de Cátedra";
            WindowState = FormWindowState.Maximized;
            Load += FrmPrincipal_Load;
            panelCabecera.ResumeLayout(false);
            panelCabecera.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelOpciones.ResumeLayout(false);
            panelUsuario.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelCabecera;
        private SistemaAyudantias.Diseno.PanelDegradado panelMenu;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblSistema2;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.FlowLayoutPanel panelOpciones;
        private SistemaAyudantias.Diseno.MenuBoton menuInicio;
        private SistemaAyudantias.Diseno.MenuBoton menuUsuarios;
        private SistemaAyudantias.Diseno.MenuBoton menuFacultades;
        private SistemaAyudantias.Diseno.MenuBoton menuCarreras;
        private SistemaAyudantias.Diseno.MenuBoton menuAsignaturas;
        private SistemaAyudantias.Diseno.MenuBoton menuPeriodos;
        private SistemaAyudantias.Diseno.MenuBoton menuConvocatorias;
        private SistemaAyudantias.Diseno.MenuBoton menuPostulacion;
        private SistemaAyudantias.Diseno.MenuBoton menuEvaluacion;
        private SistemaAyudantias.Diseno.MenuBoton menuPredicciones;
        private SistemaAyudantias.Diseno.MenuBoton menuReportes;
        private SistemaAyudantias.Diseno.MenuBoton menuClave;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;
        private SistemaAyudantias.Diseno.MenuBoton menuSalir;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel panelPeriodo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblSoloConsulta;
    }
}
