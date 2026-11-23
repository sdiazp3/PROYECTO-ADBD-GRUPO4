using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Inicio de sesión por rol (RF-02).</summary>
public partial class FrmLogin : Form
{
    private Point _inicioArrastre;

    public FrmLogin()
    {
        InitializeComponent();
    }

    private void FrmLogin_Load(object sender, EventArgs e)
    {
        picPortada.Image = Tema.Imagen("portada_login.png");
        picIcono.Image = Tema.Imagen("icono_login.png");
        lblInstitucion.Text = Conexion.Institucion;
    }

    private void btnIngresar_Click(object sender, EventArgs e)
    {
        if (campoCorreo.Text.Trim().Length == 0 || campoClave.Text.Length == 0)
        {
            Ayuda.Advertir("Escriba su correo y su contraseña.");
            return;
        }

        Ayuda.Intentar(() =>
        {
            var usuario = UsuarioDatos.IniciarSesion(campoCorreo.Text.Trim(), campoClave.Text);
            Sesion.Iniciar(usuario);
            DialogResult = DialogResult.OK;
        });
    }

    // Muestra u oculta la contraseña
    private void lblVerClave_Click(object sender, EventArgs e)
    {
        campoClave.Contrasena = !campoClave.Contrasena;
        lblVerClave.ForeColor = campoClave.Contrasena ? Tema.TextoSuave : Tema.Primario;
    }

    private void lblCerrar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    // Puntos decorativos arriba a la derecha y escudo de fondo muy suave
    private void panelFormulario_Paint(object sender, PaintEventArgs e)
    {
        using (var punto = new SolidBrush(Tema.Primario))
            for (var fila = 0; fila < 3; fila++)
                for (var columna = 0; columna < 4; columna++)
                    e.Graphics.FillEllipse(punto, panelFormulario.Width - 120 + columna * 18, 46 + fila * 18, 6, 6);

        var marca = Tema.Imagen("marca_agua.png");
        if (marca != null)
            e.Graphics.DrawImage(marca, panelFormulario.Width - 150, 130);
    }

    // La ventana no tiene barra de título: se mueve arrastrando la imagen o el fondo
    private void Arrastrar_MouseDown(object sender, MouseEventArgs e)
    {
        _inicioArrastre = e.Location;
        ((Control)sender).MouseMove -= Arrastrar_MouseMove;
        ((Control)sender).MouseMove += Arrastrar_MouseMove;
    }

    private void Arrastrar_MouseMove(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            Location = new Point(Left + e.X - _inicioArrastre.X, Top + e.Y - _inicioArrastre.Y);
    }
}
