namespace SistemaAyudantias.Formularios
{
    partial class FrmLogin
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
            panelFormulario = new Panel();
            lblCerrar = new Label();
            picIcono = new PictureBox();
            lblBienvenida = new Label();
            lineaVerde = new Panel();
            lineaDorada = new Panel();
            lblIndicacion = new Label();
            lblIconoCorreo = new Label();
            lblCorreo = new Label();
            lblIconoClave = new Label();
            lblClave = new Label();
            campoCorreo = new SistemaAyudantias.Diseno.Campo();
            lblVerClave = new Label();
            campoClave = new SistemaAyudantias.Diseno.Campo();
            btnIngresar = new SistemaAyudantias.Diseno.Boton();
            lblInstitucion = new Label();
            picPortada = new PictureBox();
            panelFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcono).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPortada).BeginInit();
            SuspendLayout();
            // 
            // panelFormulario
            // 
            panelFormulario.BackColor = Color.White;
            panelFormulario.Controls.Add(lblCerrar);
            panelFormulario.Controls.Add(picIcono);
            panelFormulario.Controls.Add(lblBienvenida);
            panelFormulario.Controls.Add(lineaVerde);
            panelFormulario.Controls.Add(lineaDorada);
            panelFormulario.Controls.Add(lblIndicacion);
            panelFormulario.Controls.Add(lblIconoCorreo);
            panelFormulario.Controls.Add(lblCorreo);
            panelFormulario.Controls.Add(lblIconoClave);
            panelFormulario.Controls.Add(lblClave);
            panelFormulario.Controls.Add(campoCorreo);
            panelFormulario.Controls.Add(lblVerClave);
            panelFormulario.Controls.Add(campoClave);
            panelFormulario.Controls.Add(btnIngresar);
            panelFormulario.Controls.Add(lblInstitucion);
            panelFormulario.Dock = DockStyle.Fill;
            panelFormulario.Location = new Point(520, 0);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(540, 620);
            panelFormulario.TabIndex = 0;
            panelFormulario.Paint += panelFormulario_Paint;
            panelFormulario.MouseDown += Arrastrar_MouseDown;
            // 
            // lblCerrar
            // 
            lblCerrar.AutoSize = true;
            lblCerrar.BackColor = Color.Transparent;
            lblCerrar.Cursor = Cursors.Hand;
            lblCerrar.Font = new Font("Segoe UI", 13F);
            lblCerrar.ForeColor = Color.FromArgb(100, 116, 139);
            lblCerrar.Location = new Point(500, 10);
            lblCerrar.Name = "lblCerrar";
            lblCerrar.Size = new Size(31, 30);
            lblCerrar.TabIndex = 0;
            lblCerrar.Text = "✕";
            lblCerrar.Click += lblCerrar_Click;
            // 
            // picIcono
            // 
            picIcono.BackColor = Color.Transparent;
            picIcono.Location = new Point(70, 46);
            picIcono.Name = "picIcono";
            picIcono.Size = new Size(84, 84);
            picIcono.SizeMode = PictureBoxSizeMode.Zoom;
            picIcono.TabIndex = 1;
            picIcono.TabStop = false;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.BackColor = Color.Transparent;
            lblBienvenida.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(12, 52, 35);
            lblBienvenida.Location = new Point(62, 136);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(292, 67);
            lblBienvenida.TabIndex = 2;
            lblBienvenida.Text = "Bienvenido";
            // 
            // lineaVerde
            // 
            lineaVerde.BackColor = Color.FromArgb(18, 122, 69);
            lineaVerde.Location = new Point(70, 200);
            lineaVerde.Name = "lineaVerde";
            lineaVerde.Size = new Size(62, 6);
            lineaVerde.TabIndex = 3;
            // 
            // lineaDorada
            // 
            lineaDorada.BackColor = Color.FromArgb(242, 183, 5);
            lineaDorada.Location = new Point(132, 200);
            lineaDorada.Name = "lineaDorada";
            lineaDorada.Size = new Size(36, 6);
            lineaDorada.TabIndex = 4;
            // 
            // lblIndicacion
            // 
            lblIndicacion.AutoSize = true;
            lblIndicacion.BackColor = Color.Transparent;
            lblIndicacion.Font = new Font("Segoe UI", 11F);
            lblIndicacion.ForeColor = Color.FromArgb(100, 116, 139);
            lblIndicacion.Location = new Point(68, 222);
            lblIndicacion.Name = "lblIndicacion";
            lblIndicacion.Size = new Size(435, 25);
            lblIndicacion.TabIndex = 5;
            lblIndicacion.Text = "Ingrese con su correo institucional para continuar.";
            // 
            // lblIconoCorreo
            // 
            lblIconoCorreo.AutoSize = true;
            lblIconoCorreo.BackColor = Color.Transparent;
            lblIconoCorreo.Font = new Font("Segoe MDL2 Assets", 13F);
            lblIconoCorreo.ForeColor = Color.FromArgb(18, 122, 69);
            lblIconoCorreo.Location = new Point(68, 272);
            lblIconoCorreo.Name = "lblIconoCorreo";
            lblIconoCorreo.Size = new Size(32, 22);
            lblIconoCorreo.TabIndex = 6;
            lblIconoCorreo.Text = "";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.BackColor = Color.Transparent;
            lblCorreo.Font = new Font("Segoe UI Semibold", 10.5F);
            lblCorreo.ForeColor = Color.FromArgb(12, 52, 35);
            lblCorreo.Location = new Point(96, 272);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(177, 25);
            lblCorreo.TabIndex = 7;
            lblCorreo.Text = "Correo institucional";
            // 
            // lblIconoClave
            // 
            lblIconoClave.AutoSize = true;
            lblIconoClave.BackColor = Color.Transparent;
            lblIconoClave.Font = new Font("Segoe MDL2 Assets", 13F);
            lblIconoClave.ForeColor = Color.FromArgb(18, 122, 69);
            lblIconoClave.Location = new Point(68, 364);
            lblIconoClave.Name = "lblIconoClave";
            lblIconoClave.Size = new Size(32, 22);
            lblIconoClave.TabIndex = 8;
            lblIconoClave.Text = "";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.BackColor = Color.Transparent;
            lblClave.Font = new Font("Segoe UI Semibold", 10.5F);
            lblClave.ForeColor = Color.FromArgb(12, 52, 35);
            lblClave.Location = new Point(96, 364);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(106, 25);
            lblClave.TabIndex = 9;
            lblClave.Text = "Contraseña";
            // 
            // campoCorreo
            // 
            campoCorreo.BackColor = Color.White;
            campoCorreo.Location = new Point(70, 298);
            campoCorreo.Marcador = "usuario@uteq.edu.ec";
            campoCorreo.MaxLength = 120;
            campoCorreo.Name = "campoCorreo";
            campoCorreo.Padding = new Padding(12, 10, 10, 6);
            campoCorreo.Size = new Size(400, 46);
            campoCorreo.TabIndex = 10;
            // 
            // lblVerClave
            // 
            lblVerClave.AutoSize = true;
            lblVerClave.BackColor = Color.FromArgb(248, 250, 252);
            lblVerClave.Cursor = Cursors.Hand;
            lblVerClave.Font = new Font("Segoe MDL2 Assets", 13F);
            lblVerClave.ForeColor = Color.FromArgb(100, 116, 139);
            lblVerClave.Location = new Point(434, 402);
            lblVerClave.Name = "lblVerClave";
            lblVerClave.Size = new Size(32, 22);
            lblVerClave.TabIndex = 11;
            lblVerClave.Text = "";
            lblVerClave.Click += lblVerClave_Click;
            // 
            // campoClave
            // 
            campoClave.BackColor = Color.White;
            campoClave.Contrasena = true;
            campoClave.Location = new Point(70, 390);
            campoClave.Marcador = "Su contraseña";
            campoClave.MaxLength = 60;
            campoClave.Name = "campoClave";
            campoClave.Padding = new Padding(12, 10, 10, 6);
            campoClave.Size = new Size(400, 46);
            campoClave.TabIndex = 12;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.Transparent;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI Semibold", 12F);
            btnIngresar.Icono = "";
            btnIngresar.IconoDerecha = true;
            btnIngresar.Location = new Point(70, 470);
            btnIngresar.Margin = new Padding(0, 0, 8, 8);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(400, 52);
            btnIngresar.TabIndex = 13;
            btnIngresar.Text = "Ingresar al sistema";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblInstitucion
            // 
            lblInstitucion.AutoSize = true;
            lblInstitucion.BackColor = Color.Transparent;
            lblInstitucion.Font = new Font("Segoe UI", 9F);
            lblInstitucion.ForeColor = Color.FromArgb(100, 116, 139);
            lblInstitucion.Location = new Point(70, 576);
            lblInstitucion.Name = "lblInstitucion";
            lblInstitucion.Size = new Size(0, 20);
            lblInstitucion.TabIndex = 15;
            // 
            // picPortada
            // 
            picPortada.BackColor = Color.White;
            picPortada.Dock = DockStyle.Left;
            picPortada.Location = new Point(0, 0);
            picPortada.Name = "picPortada";
            picPortada.Padding = new Padding(10, 10, 0, 10);
            picPortada.Size = new Size(520, 620);
            picPortada.SizeMode = PictureBoxSizeMode.Zoom;
            picPortada.TabIndex = 1;
            picPortada.TabStop = false;
            picPortada.MouseDown += Arrastrar_MouseDown;
            // 
            // FrmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(1060, 620);
            Controls.Add(panelFormulario);
            Controls.Add(picPortada);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar sesión - Ayudantías de Cátedra";
            Load += FrmLogin_Load;
            panelFormulario.ResumeLayout(false);
            panelFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIcono).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPortada).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.PictureBox picPortada;
        private System.Windows.Forms.Label lblCerrar;
        private System.Windows.Forms.PictureBox picIcono;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel lineaVerde;
        private System.Windows.Forms.Panel lineaDorada;
        private System.Windows.Forms.Label lblIndicacion;
        private System.Windows.Forms.Label lblIconoCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblIconoClave;
        private System.Windows.Forms.Label lblClave;
        private SistemaAyudantias.Diseno.Campo campoCorreo;
        private System.Windows.Forms.Label lblVerClave;
        private SistemaAyudantias.Diseno.Campo campoClave;
        private SistemaAyudantias.Diseno.Boton btnIngresar;
        private System.Windows.Forms.Label lblInstitucion;
    }
}
