using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace SistemaAyudantias.Datos;

/// <summary>Convocatorias de ayudantía que publica el coordinador.</summary>
public static class ConvocatoriaDatos
{
    /// <summary>Convocatorias de una carrera y un período (null = todas las carreras / todos los períodos).</summary>
    public static DataTable Listar(int? idCarrera, int? idPeriodo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_listar_convocatorias(@id_carrera, @id_periodo)", conexion);
        comando.Parameters.AddWithValue("id_carrera", Conexion.ValorONulo(idCarrera));
        comando.Parameters.AddWithValue("id_periodo", Conexion.ValorONulo(idPeriodo));
        return Conexion.LlenarTabla(comando);
    }

    /// <summary>Convocatorias en plazo de la carrera del estudiante (indica si ya se postuló).</summary>
    public static DataTable ListarAbiertas(int idEstudiante)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_convocatorias_abiertas(@id_estudiante)", conexion);
        comando.Parameters.AddWithValue("id_estudiante", idEstudiante);
        return Conexion.LlenarTabla(comando);
    }

    public static void Insertar(int idAsignatura, int idPeriodo, int idCoordinador, int cupos, int horas,
        string requisitos, DateTime desde, DateTime hasta)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "CALL sp_insertar_convocatoria(@id_asignatura, @id_periodo, @id_coordinador, @cupos, @horas, @requisitos, @desde, @hasta)",
            conexion);
        comando.Parameters.AddWithValue("id_asignatura", idAsignatura);
        comando.Parameters.AddWithValue("id_periodo", idPeriodo);
        comando.Parameters.AddWithValue("id_coordinador", idCoordinador);
        comando.Parameters.AddWithValue("cupos", cupos);
        comando.Parameters.AddWithValue("horas", horas);
        comando.Parameters.AddWithValue("requisitos", requisitos);
        comando.Parameters.AddWithValue("desde", NpgsqlDbType.Date, desde.Date);
        comando.Parameters.AddWithValue("hasta", NpgsqlDbType.Date, hasta.Date);
        comando.ExecuteNonQuery();
    }

    public static void Actualizar(int id, int idAsignatura, int idPeriodo, int idCoordinador, int cupos, int horas,
        string requisitos, DateTime desde, DateTime hasta)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "CALL sp_actualizar_convocatoria(@id, @id_asignatura, @id_periodo, @id_coordinador, @cupos, @horas, @requisitos, @desde, @hasta)",
            conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.Parameters.AddWithValue("id_asignatura", idAsignatura);
        comando.Parameters.AddWithValue("id_periodo", idPeriodo);
        comando.Parameters.AddWithValue("id_coordinador", idCoordinador);
        comando.Parameters.AddWithValue("cupos", cupos);
        comando.Parameters.AddWithValue("horas", horas);
        comando.Parameters.AddWithValue("requisitos", requisitos);
        comando.Parameters.AddWithValue("desde", NpgsqlDbType.Date, desde.Date);
        comando.Parameters.AddWithValue("hasta", NpgsqlDbType.Date, hasta.Date);
        comando.ExecuteNonQuery();
    }

    public static void Eliminar(int id)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_eliminar_convocatoria(@id)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.ExecuteNonQuery();
    }
}
