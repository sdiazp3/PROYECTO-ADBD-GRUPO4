using System.Data;

namespace SistemaAyudantias.Utilidades;

/// <summary>Datos del usuario que inició sesión. Se comparten entre todos los formularios.</summary>
public static class Sesion
{
    public const int Administrador = 1;
    public const int Coordinador = 2;
    public const int Docente = 3;
    public const int Estudiante = 4;

    public static int IdUsuario { get; private set; }
    public static string Nombres { get; private set; } = string.Empty;
    public static string Apellidos { get; private set; } = string.Empty;
    public static int IdRol { get; private set; }
    public static string Rol { get; private set; } = string.Empty;
    public static int? IdCarrera { get; private set; }
    public static string Carrera { get; private set; } = string.Empty;

    public static string NombreCompleto => Nombres + " " + Apellidos;

    // Período académico elegido en la parte superior (como en el SGA).
    // Un período finalizado solo se puede consultar.
    public static int IdPeriodo { get; private set; }
    public static string Periodo { get; private set; } = string.Empty;
    public static bool PeriodoFinalizado { get; private set; }

    public static void ElegirPeriodo(int idPeriodo, string nombre, bool finalizado)
    {
        IdPeriodo = idPeriodo;
        Periodo = nombre;
        PeriodoFinalizado = finalizado;
    }

    /// <summary>Guarda la fila que devuelve fn_iniciar_sesion.</summary>
    public static void Iniciar(DataRow usuario)
    {
        IdUsuario = Convert.ToInt32(usuario["id_usuario"]);
        Nombres = Convert.ToString(usuario["nombres"]) ?? string.Empty;
        Apellidos = Convert.ToString(usuario["apellidos"]) ?? string.Empty;
        IdRol = Convert.ToInt32(usuario["id_rol"]);
        Rol = Convert.ToString(usuario["rol"]) ?? string.Empty;
        IdCarrera = usuario["id_carrera"] == DBNull.Value ? null : Convert.ToInt32(usuario["id_carrera"]);
        Carrera = Convert.ToString(usuario["carrera"]) ?? string.Empty;
    }

    public static void Cerrar()
    {
        IdUsuario = 0;
        IdRol = 0;
        IdCarrera = null;
        IdPeriodo = 0;
        PeriodoFinalizado = false;
        Periodo = string.Empty;
        Nombres = Apellidos = Rol = Carrera = string.Empty;
    }
}
