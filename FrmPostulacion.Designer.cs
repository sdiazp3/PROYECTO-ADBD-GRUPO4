namespace SistemaAyudantias.Formularios
{
    partial class FrmPostulacion
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
            this.tarjetaAbiertas = new SistemaAyudantias.Diseno.Tarjeta();
            this.separador = new System.Windows.Forms.Panel();
            this.tarjetaPostular = new SistemaAyudantias.Diseno.Tarjeta();
            this.separador2 = new System.Windows.Forms.Panel();
            this.tarjetaMias = new SistemaAyudantias.Diseno.Tarjeta();
            this.tablaAbiertas = new System.Windows.Forms.DataGridView();
            this.lblAsignatura = new System.Windows.Forms.Label();
            this.lblTituloRequisitos = new System.Windows.Forms.Label();
            this.campoRequisitos = new SistemaAyudantias.Diseno.Campo();
            this.lblTituloArchivo = new System.Windows.Forms.Label();
            this.campoArchivo = new SistemaAyudantias.Diseno.Campo();
            this.panelBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPostular = new SistemaAyudantias.Diseno.Boton();
            this.btnAdjuntar = new SistemaAyudantias.Diseno.Boton();
            this.tablaMias = new System.Windows.Forms.DataGridView();
            this.panelBotonesMias = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRetirar = new SistemaAyudantias.Diseno.Boton();
            this.tarjetaAbiertas.SuspendLayout();
            this.tarjetaPostular.SuspendLayout();
            this.tarjetaMias.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelBotonesMias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAbiertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaMias)).BeginInit();
            this.SuspendLayout();
            // 
            // tarjetaAbiertas
            // 
            this.tarjetaAbiertas.Controls.Add(this.tablaAbiertas);
            this.tarjetaAbiertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tarjetaAbiertas.Size = new System.Drawing.Size(400, 300);
            this.tarjetaAbiertas.Subtitulo = "Seleccione una para ver sus requisitos";
            this.tarjetaAbiertas.Titulo = "Convocatorias abiertas de mi carrera";
            this.tarjetaAbiertas.Name = "tarjetaAbiertas";
            // 
            // separador
            // 
            this.separador.Dock = System.Windows.Forms.DockStyle.Right;
            this.separador.Size = new System.Drawing.Size(18, 18);
            this.separador.Name = "separador";
            // 
            // tarjetaPostular
            // 
            this.tarjetaPostular.Controls.Add(this.lblAsignatura);
            this.tarjetaPostular.Controls.Add(this.lblTituloRequisitos);
            this.tarjetaPostular.Controls.Add(this.campoRequisitos);
            this.tarjetaPostular.Controls.Add(this.lblTituloArchivo);
            this.tarjetaPostular.Controls.Add(this.campoArchivo);
            this.tarjetaPostular.Controls.Add(this.panelBotones);
            this.tarjetaPostular.Dock = System.Windows.Forms.DockStyle.Right;
            this.tarjetaPostular.Size = new System.Drawing.Size(370, 300);
            this.tarjetaPostular.Subtitulo = "Adjunte su hoja de vida en PDF (máx. 5 MB)";
            this.tarjetaPostular.Titulo = "Postularme";
            this.tarjetaPostular.Name = "tarjetaPostular";
            // 
            // separador2
            // 
            this.separador2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separador2.Size = new System.Drawing.Size(18, 18);
            this.separador2.Name = "separador2";
            // 
            // tarjetaMias
            // 
            this.tarjetaMias.Controls.Add(this.tablaMias);
            this.tarjetaMias.Controls.Add(this.panelBotonesMias);
            this.tarjetaMias.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tarjetaMias.Size = new System.Drawing.Size(400, 214);
            this.tarjetaMias.Subtitulo = "Estado de cada postulación enviada";
            this.tarjetaMias.Titulo = "Mis postulaciones";
            this.tarjetaMias.Name = "tarjetaMias";
            // 
            // tablaAbiertas
            // 
            this.tablaAbiertas.BackgroundColor = System.Drawing.Color.White;
            this.tablaAbiertas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaAbiertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAbiertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaAbiertas.ReadOnly = true;
            this.tablaAbiertas.RowHeadersVisible = false;
            this.tablaAbiertas.AllowUserToAddRows = false;
            this.tablaAbiertas.Size = new System.Drawing.Size(400, 300);
            this.tablaAbiertas.Name = "tablaAbiertas";
            this.tablaAbiertas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaAbiertas_CellClick);
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AutoSize = false;
            this.lblAsignatura.BackColor = System.Drawing.Color.Transparent;
            this.lblAsignatura.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.lblAsignatura.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblAsignatura.Location = new System.Drawing.Point(22, 76);
            this.lblAsignatura.Size = new System.Drawing.Size(320, 44);
            this.lblAsignatura.Text = "Seleccione una convocatoria";
            this.lblAsignatura.Name = "lblAsignatura";
            // 
            // lblTituloRequisitos
            // 
            this.lblTituloRequisitos.AutoSize = true;
            this.lblTituloRequisitos.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloRequisitos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblTituloRequisitos.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTituloRequisitos.Location = new System.Drawing.Point(22, 122);
            this.lblTituloRequisitos.Text = "Requisitos";
            this.lblTituloRequisitos.Name = "lblTituloRequisitos";
            // 
            // campoRequisitos
            // 
            this.campoRequisitos.Location = new System.Drawing.Point(22, 144);
            this.campoRequisitos.Size = new System.Drawing.Size(326, 70);
            this.campoRequisitos.Multilinea = true;
            this.campoRequisitos.SoloLectura = true;
            this.campoRequisitos.Name = "campoRequisitos";
            // 
            // lblTituloArchivo
            // 
            this.lblTituloArchivo.AutoSize = true;
            this.lblTituloArchivo.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloArchivo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblTituloArchivo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTituloArchivo.Location = new System.Drawing.Point(22, 222);
            this.lblTituloArchivo.Text = "Documento PDF";
            this.lblTituloArchivo.Name = "lblTituloArchivo";
            // 
            // campoArchivo
            // 
            this.campoArchivo.Location = new System.Drawing.Point(22, 244);
            this.campoArchivo.Size = new System.Drawing.Size(326, 40);
            this.campoArchivo.Marcador = "Ningún archivo seleccionado";
            this.campoArchivo.Icono = "\uE723";
            this.campoArchivo.SoloLectura = true;
            this.campoArchivo.Name = "campoArchivo";
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnPostular);
            this.panelBotones.Controls.Add(this.btnAdjuntar);
            this.panelBotones.BackColor = System.Drawing.Color.White;
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Size = new System.Drawing.Size(300, 60);
            this.panelBotones.Name = "panelBotones";
            // 
            // btnPostular
            // 
            this.btnPostular.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Primario;
            this.btnPostular.Icono = "\uE73E";
            this.btnPostular.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnPostular.Size = new System.Drawing.Size(176, 40);
            this.btnPostular.Text = "Enviar postulación";
            this.btnPostular.Name = "btnPostular";
            this.btnPostular.Click += new System.EventHandler(this.btnPostular_Click);
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Secundario;
            this.btnAdjuntar.Icono = "\uE723";
            this.btnAdjuntar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnAdjuntar.Size = new System.Drawing.Size(120, 40);
            this.btnAdjuntar.Text = "Adjuntar";
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // tablaMias
            // 
            this.tablaMias.BackgroundColor = System.Drawing.Color.White;
            this.tablaMias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaMias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaMias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablaMias.ReadOnly = true;
            this.tablaMias.RowHeadersVisible = false;
            this.tablaMias.AllowUserToAddRows = false;
            this.tablaMias.Size = new System.Drawing.Size(400, 300);
            this.tablaMias.Name = "tablaMias";
            // 
            // panelBotonesMias
            // 
            this.panelBotonesMias.Controls.Add(this.btnRetirar);
            this.panelBotonesMias.BackColor = System.Drawing.Color.White;
            this.panelBotonesMias.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBotonesMias.Size = new System.Drawing.Size(300, 60);
            this.panelBotonesMias.Size = new System.Drawing.Size(170, 60);
            this.panelBotonesMias.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.panelBotonesMias.Name = "panelBotonesMias";
            // 
            // btnRetirar
            // 
            this.btnRetirar.Estilo = SistemaAyudantias.Diseno.EstiloBoton.Peligro;
            this.btnRetirar.Icono = "\uE74D";
            this.btnRetirar.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.btnRetirar.Size = new System.Drawing.Size(140, 40);
            this.btnRetirar.Text = "Retirar";
            this.btnRetirar.Name = "btnRetirar";
            this.btnRetirar.Click += new System.EventHandler(this.btnRetirar_Click);
            // 
            // FrmPostulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 251);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tarjetaAbiertas);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.tarjetaPostular);
            this.Controls.Add(this.separador2);
            this.Controls.Add(this.tarjetaMias);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmPostulacion";
            this.Load += new System.EventHandler(this.FrmPostulacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaAbiertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaMias)).EndInit();
            this.tarjetaAbiertas.ResumeLayout(false);
            this.tarjetaAbiertas.PerformLayout();
            this.tarjetaPostular.ResumeLayout(false);
            this.tarjetaPostular.PerformLayout();
            this.tarjetaMias.ResumeLayout(false);
            this.tarjetaMias.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelBotones.PerformLayout();
            this.panelBotonesMias.ResumeLayout(false);
            this.panelBotonesMias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaAyudantias.Diseno.Tarjeta tarjetaAbiertas;
        private System.Windows.Forms.Panel separador;
        private SistemaAyudantias.Diseno.Tarjeta tarjetaPostular;
        private System.Windows.Forms.Panel separador2;
        private SistemaAyudantias.Diseno.Tarjeta tarjetaMias;
        private System.Windows.Forms.DataGridView tablaAbiertas;
        private System.Windows.Forms.Label lblAsignatura;
        private System.Windows.Forms.Label lblTituloRequisitos;
        private SistemaAyudantias.Diseno.Campo campoRequisitos;
        private System.Windows.Forms.Label lblTituloArchivo;
        private SistemaAyudantias.Diseno.Campo campoArchivo;
        private System.Windows.Forms.FlowLayoutPanel panelBotones;
        private SistemaAyudantias.Diseno.Boton btnPostular;
        private SistemaAyudantias.Diseno.Boton btnAdjuntar;
        private System.Windows.Forms.DataGridView tablaMias;
        private System.Windows.Forms.FlowLayoutPanel panelBotonesMias;
        private SistemaAyudantias.Diseno.Boton btnRetirar;
    }
}
