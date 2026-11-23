using System.Data;
using Npgsql;

namespace SistemaAyudantias.Datos;

/// <summary>Consultas del tablero de inicio y del reporte. Cada rol ve solo lo que le corresponde.</summary>
public static class ReporteDatos
{
    /// <summary>Totales del inicio en un período: convocatorias, postulaciones, por_evaluar, seleccionados.</summary>
    public static DataRow ResumenInicio(int idUsuario, int idPeriodo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_resumen_inicio(@id_usuario, @id_periodo)", conexion);
        comando.Parameters.AddWithValue("id_usuario", idUsuario);
        comando.Parameters.AddWithValue("id_periodo", idPeriodo);
        return Conexion.LlenarTabla(comando).Rows[0];
    }

    /// <summary>Número de postulaciones por estado en un período (para el gráfico del inicio).</summary>
    public static DataTable PostulacionesPorEstado(int idUsuario, int idPeriodo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_postulaciones_por_estado(@id_usuario, @id_periodo)", conexion);
        comando.Parameters.AddWithValue("id_usuario", idUsuario);
        comando.Parameters.AddWithValue("id_periodo", idPeriodo);
        return Conexion.LlenarTabla(comando);
    }

    /// <summary>Reporte de postulaciones. Los filtros en null significan "todos".</summary>
    public static DataTable Postulaciones(int idUsuario, int? idPeriodo, int? idCarrera, int? idAsignatura, string cedula)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "SELECT * FROM fn_reporte_postulaciones(@id_usuario, @id_periodo, @id_carrera, @id_asignatura, @cedula)", conexion);
        comando.Parameters.AddWithValue("id_usuario", idUsuario);
        comando.Parameters.AddWithValue("id_periodo", Conexion.ValorONulo(idPeriodo));
        comando.Parameters.AddWithValue("id_carrera", Conexion.ValorONulo(idCarrera));
        comando.Parameters.AddWithValue("id_asignatura", Conexion.ValorONulo(idAsignatura));
        comando.Parameters.AddWithValue("cedula", cedula);
        return Conexion.LlenarTabla(comando);
    }
}
