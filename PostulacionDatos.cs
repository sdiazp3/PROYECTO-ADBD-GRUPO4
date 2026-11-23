using System.Data;
using Npgsql;

namespace SistemaAyudantias.Datos;

/// <summary>Postulaciones de los estudiantes y su evaluación por el coordinador.</summary>
public static class PostulacionDatos
{
    /// <summary>Guarda la postulación con el documento PDF (en bytes).</summary>
    public static void Postular(int idConvocatoria, int idEstudiante, string nombreDocumento, byte[] documento)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "CALL sp_postular(@id_convocatoria, @id_estudiante, @documento_nombre, @documento)", conexion);
        comando.Parameters.AddWithValue("id_convocatoria", idConvocatoria);
        comando.Parameters.AddWithValue("id_estudiante", idEstudiante);
        comando.Parameters.AddWithValue("documento_nombre", nombreDocumento);
        comando.Parameters.AddWithValue("documento", documento);
        comando.ExecuteNonQuery();
    }

    /// <summary>El estudiante retira una postulación que aún no ha sido evaluada.</summary>
    public static void Retirar(int idPostulacion, int idEstudiante)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_retirar_postulacion(@id_postulacion, @id_estudiante)", conexion);
        comando.Parameters.AddWithValue("id_postulacion", idPostulacion);
        comando.Parameters.AddWithValue("id_estudiante", idEstudiante);
        comando.ExecuteNonQuery();
    }

    /// <summary>Postulaciones del estudiante en un período.</summary>
    public static DataTable MisPostulaciones(int idEstudiante, int idPeriodo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_mis_postulaciones(@id_estudiante, @id_periodo)", conexion);
        comando.Parameters.AddWithValue("id_estudiante", idEstudiante);
        comando.Parameters.AddWithValue("id_periodo", idPeriodo);
        return Conexion.LlenarTabla(comando);
    }

    /// <summary>Postulantes de una convocatoria, ordenados por puntaje.</summary>
    public static DataTable Postulantes(int idConvocatoria)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_postulantes(@id_convocatoria)", conexion);
        comando.Parameters.AddWithValue("id_convocatoria", idConvocatoria);
        return Conexion.LlenarTabla(comando);
    }

    /// <summary>Guarda el puntaje y el resultado: Seleccionado, En espera o No seleccionado.</summary>
    public static void Evaluar(int idPostulacion, decimal puntaje, string estado, string observacion)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "CALL sp_evaluar_postulacion(@id_postulacion, @puntaje, @estado, @observacion)", conexion);
        comando.Parameters.AddWithValue("id_postulacion", idPostulacion);
        comando.Parameters.AddWithValue("puntaje", puntaje);
        comando.Parameters.AddWithValue("estado", estado);
        comando.Parameters.AddWithValue("observacion", observacion);
        comando.ExecuteNonQuery();
    }

    /// <summary>Devuelve el PDF que adjuntó el estudiante (columna "contenido").</summary>
    public static byte[] Documento(int idPostulacion)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_documento_postulacion(@id_postulacion)", conexion);
        comando.Parameters.AddWithValue("id_postulacion", idPostulacion);
        return (byte[])Conexion.LlenarTabla(comando).Rows[0]["contenido"];
    }
}
