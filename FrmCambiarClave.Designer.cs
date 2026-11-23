namespace SistemaAyudantias.Formularios
{
    partial class FrmCambiarClave
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
            this.tarjetaClave = new SistemaAyudantias.Diseno.Tarjeta();
            this.lblActual = new System.Windows.Forms.Label();
            this.campoActual = new SistemaAyudantias.Diseno.Campo();
            this.lblNueva = new System.Windows.Forms.Label();
            this.campoNueva = new SistemaAyudantias.Diseno.Campo();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.campoConfirmar = new SistemaAyudantias.Diseno.Campo();
            this.lblConsejo = new System.Windows.Forms.Label();
            this.btnGuardar = new SistemaAyudantias.Diseno.Boton();
            this.tarjetaClave.SuspendLayout();
            this.SuspendLayout();
            // 
            // tarjetaClave
            // 
            this.tarjetaClave.Controls.Add(this.lblActual);
            this.tarjetaClave.Controls.Add(this.campoActual);
            this.tarjetaClave.Controls.Add(this.lblNueva);
            this.tarjetaClave.Controls.Add(this.campoNueva);
            this.tarjetaClave.Controls.Add(this.lblConfirmar);
            this.tarjetaClave.Controls.Add(this.campoConfirmar);
            this.tarjetaClave.Controls.Add(this.lblConsejo);
            this.tarjetaClave.Controls.Add(this.btnGuardar);
            this.tarjetaClave.Location = new System.Drawing.Point(0, 0);
            this.tarjetaClave.Size = new System.Drawing.Size(520, 470);
            this.tarjetaClave.Subtitulo = "Por seguridad, escriba primero su contraseña actual";
            this.tarjetaClave.Titulo = "Cambiar mi contraseña";
            this.tarjetaClave.Name = "tarjetaClave";
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.BackColor = System.Drawing.Color.Transparent;
            this.lblActual.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblActual.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblActual.Location = new System.Drawing.Point(26, 86);
            this.lblActual.Text = "Contraseña actual";
            this.lblActual.Name = "lblActual";
            // 
            // campoActual
            // 
            this.campoActual.Location = new System.Drawing.Point(26, 108);
            this.campoActual.Size = new System.Drawing.Size(464, 44);
            this.campoActual.MaxLength = 60;
            this.campoActual.Icono = "\uE72E";
            this.campoActual.Contrasena = true;
            this.campoActual.Name = "campoActual";
            // 
            // lblNueva
            // 
            this.lblNueva.AutoSize = true;
            this.lblNueva.BackColor = System.Drawing.Color.Transparent;
            this.lblNueva.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblNueva.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNueva.Location = new System.Drawing.Point(26, 172);
            this.lblNueva.Text = "Nueva contraseña (mínimo 8 caracteres)";
            this.lblNueva.Name = "lblNueva";
            // 
            // campoNueva
            // 
            this.campoNueva.Location = new System.Drawing.Point(26, 194);
            this.campoNueva.Size = new System.Drawing.Size(464, 44);
            this.campoNueva.MaxLength = 60;
            this.campoNueva.Icono = "\uE72E";
            this.campoNueva.Contrasena = true;
            this.campoNueva.Name = "campoNueva";
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.AutoSize = true;
            this.lblConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblConfirmar.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblConfirmar.Location = new System.Drawing.Point(26, 258);
            this.lblConfirmar.Text = "Confirme la nueva contraseña";
            this.lblConfirmar.Name = "lblConfirmar";
            // 
            // campoConfirmar
            // 
            this.campoConfirmar.Location = new System.Drawing.Point(26, 280);
            this.campoConfirmar.Size = new System.Drawing.Size(464, 44);
            this.campoConfirmar.MaxLength = 60;
            this.campoConfirmar.Icono = "\uE72E";
            this.campoConfirmar.Contrasena = true;
            this.campoConfirmar.Name = "campoConfirmar";
            // 
            // lblConsejo
            // 
            this.lblConsejo.AutoSize = false;
            this.lblConsejo.BackColor = System.Drawing.Color.Transparent;
            this.lblConsejo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConsejo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblConsejo.Location = new System.Drawing.Point(26, 346);
            this.lblConsejo.Size = new System.Drawing.Size(464, 40);
            this.lblConsejo.Text = "Consejo: combine letras mayúsculas, minúsculas y números. No comparta su contraseña con nadie.";
            this.lblConsejo.Name = "lblConsejo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Primario;
            this.btnGuardar.Icono = "\uE74E";
            this.btnGuardar.Location = new System.Drawing.Point(26, 398);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnGuardar.Size = new System.Drawing.Size(200, 44);
            this.btnGuardar.Text = "Guardar contraseña";
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmCambiarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaClave);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmCambiarClave";
            this.Load += new System.EventHandler(this.FrmCambiarClave_Load);
            this.tarjetaClave.ResumeLayout(false);
            this.tarjetaClave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaAyudantias.Diseno.Tarjeta tarjetaClave;
        private System.Windows.Forms.Label lblActual;
        private SistemaAyudantias.Diseno.Campo campoActual;
        private System.Windows.Forms.Label lblNueva;
        private SistemaAyudantias.Diseno.Campo campoNueva;
        private System.Windows.Forms.Label lblConfirmar;
        private SistemaAyudantias.Diseno.Campo campoConfirmar;
        private System.Windows.Forms.Label lblConsejo;
        private SistemaAyudantias.Diseno.Boton btnGuardar;
    }
}
