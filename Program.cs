using SistemaAyudantias.Datos;
using SistemaAyudantias.Formularios;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias;

internal static class Program
{
    /// <summary>Punto de entrada: verifica la conexión con PostgreSQL y abre el inicio de sesión.</summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 1. Leer appsettings.json y probar la conexión
        try
        {
            Conexion.LeerConfiguracion();
            using var prueba = Conexion.Abrir();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "No se pudo conectar con la base de datos PostgreSQL.\n\n" +
                "Revise que:\n" +
                "  1. PostgreSQL esté encendido.\n" +
                "  2. Se haya ejecutado el script BaseDeDatos/ayudantias_catedra.sql.\n" +
                "  3. Los datos de appsettings.json (servidor, base, usuario y contraseña) sean correctos.\n\n" +
                "Detalle: " + ex.Message,
                "Ayudantías de Cátedra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // 2. Inicio de sesión. Al cerrar sesión se vuelve a esta ventana.
        while (true)
        {
            using (var login = new FrmLogin())
            {
                if (login.ShowDialog() != DialogResult.OK)
                    return;
            }

            using (var principal = new FrmPrincipal())
            {
                principal.ShowDialog();
                if (!principal.CerrarSesion)
                    return;
            }

            Sesion.Cerrar();
        }
    }
}
