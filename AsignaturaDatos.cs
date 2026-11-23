using System.Data;
using Npgsql;

namespace SistemaAyudantias.Datos;

/// <summary>Asignaturas: llama a las rutinas fn_listar_asignaturas y sp_*_asignatura.</summary>
public static class AsignaturaDatos
{
    /// <summary>Lista las asignaturas de una carrera, o todas si idCarrera es null.</summary>
    public static DataTable Listar(int? idCarrera = null)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_listar_asignaturas(@id_carrera)", conexion);
        comando.Parameters.AddWithValue("id_carrera", Conexion.ValorONulo(idCarrera));
        return Conexion.LlenarTabla(comando);
    }

    public static void Insertar(int idCarrera, string codigo, string nombre, int nivel, bool activa)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "CALL sp_insertar_asignatura(@id_carrera, @codigo, @nombre, @nivel, @activa)", conexion);
        comando.Parameters.AddWithValue("id_carrera", idCarrera);
        comando.Parameters.AddWithValue("codigo", codigo);
        comando.Parameters.AddWithValue("nombre", nombre);
        comando.Parameters.AddWithValue("nivel", nivel);
        comando.Parameters.AddWithValue("activa", activa);
        comando.ExecuteNonQuery();
    }

    public static void Actualizar(int id, int idCarrera, string codigo, string nombre, int nivel, bool activa)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "CALL sp_actualizar_asignatura(@id, @id_carrera, @codigo, @nombre, @nivel, @activa)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.Parameters.AddWithValue("id_carrera", idCarrera);
        comando.Parameters.AddWithValue("codigo", codigo);
        comando.Parameters.AddWithValue("nombre", nombre);
        comando.Parameters.AddWithValue("nivel", nivel);
        comando.Parameters.AddWithValue("activa", activa);
        comando.ExecuteNonQuery();
    }

    public static void Eliminar(int id)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_eliminar_asignatura(@id)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.ExecuteNonQuery();
    }
}
