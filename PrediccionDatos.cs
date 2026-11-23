using System.Data;
using Npgsql;

namespace SistemaAyudantias.Datos;

/// <summary>
/// Predicción de postulantes para la próxima convocatoria de cada asignatura.
/// El cálculo (regresión lineal con los períodos anteriores) se hace en PostgreSQL.
/// </summary>
public static class PrediccionDatos
{
    /// <summary>
    /// Predicción por asignatura para el período elegido, calculada con los períodos anteriores a él.
    /// Si el período ya terminó, la columna "Real" trae lo que de verdad ocurrió.
    /// </summary>
    public static DataTable Listar(int idUsuario, int idPeriodo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_prediccion_postulantes(@id_usuario, @id_periodo)", conexion);
        comando.Parameters.AddWithValue("id_usuario", idUsuario);
        comando.Parameters.AddWithValue("id_periodo", idPeriodo);
        return Conexion.LlenarTabla(comando);
    }

    /// <summary>Postulantes y seleccionados de una asignatura en los períodos anteriores al elegido.</summary>
    public static DataTable Historial(int idAsignatura, int idPeriodo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_historial_asignatura(@id_asignatura, @id_periodo)", conexion);
        comando.Parameters.AddWithValue("id_asignatura", idAsignatura);
        comando.Parameters.AddWithValue("id_periodo", idPeriodo);
        return Conexion.LlenarTabla(comando);
    }
}
