using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Cada usuario (administrador, coordinador, docente o estudiante) cambia su propia contraseña.</summary>
public partial class FrmCambiarClave : Form
{
    public FrmCambiarClave()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmCambiarClave_Load(object sender, EventArgs e)
    {
        tarjetaClave.Subtitulo = Sesion.NombreCompleto + " · escriba primero su contraseña actual";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (campoActual.Text.Length == 0)
        {
            Ayuda.Advertir("Escriba su contraseña actual.");
            campoActual.Focus();
            return;
        }
        if (campoNueva.Text.Length < 8)
        {
            Ayuda.Advertir("La nueva contraseña debe tener al menos 8 caracteres.");
            campoNueva.Focus();
            return;
        }
        if (campoNueva.Text != campoConfirmar.Text)
        {
            Ayuda.Advertir("La confirmación no coincide con la nueva contraseña.");
            campoConfirmar.Focus();
            return;
        }

        var cambiada = Ayuda.Intentar(() =>
            UsuarioDatos.CambiarContrasena(Sesion.IdUsuario, campoActual.Text, campoNueva.Text));

        if (cambiada)
        {
            Ayuda.Informar("Su contraseña se cambió correctamente. Úsela la próxima vez que inicie sesión.");
            campoActual.Clear();
            campoNueva.Clear();
            campoConfirmar.Clear();
        }
    }
}
