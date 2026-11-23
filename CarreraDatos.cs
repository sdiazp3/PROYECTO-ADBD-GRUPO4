using System.Data;
using Npgsql;

namespace SistemaAyudantias.Datos;

/// <summary>Carreras: llama a las rutinas fn_listar_carreras y sp_*_carrera.</summary>
public static class CarreraDatos
{
    /// <summary>Lista las carreras de una facultad, o todas si idFacultad es null.</summary>
    public static DataTable Listar(int? idFacultad = null)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_listar_carreras(@id_facultad)", conexion);
        comando.Parameters.AddWithValue("id_facultad", Conexion.ValorONulo(idFacultad));
        return Conexion.LlenarTabla(comando);
    }

    public static void Insertar(int idFacultad, string nombre, bool activa)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_insertar_carrera(@id_facultad, @nombre, @activa)", conexion);
        comando.Parameters.AddWithValue("id_facultad", idFacultad);
        comando.Parameters.AddWithValue("nombre", nombre);
        comando.Parameters.AddWithValue("activa", activa);
        comando.ExecuteNonQuery();
    }

    public static void Actualizar(int id, int idFacultad, string nombre, bool activa)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_actualizar_carrera(@id, @id_facultad, @nombre, @activa)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.Parameters.AddWithValue("id_facultad", idFacultad);
        comando.Parameters.AddWithValue("nombre", nombre);
        comando.Parameters.AddWithValue("activa", activa);
        comando.ExecuteNonQuery();
    }

    public static void Eliminar(int id)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_eliminar_carrera(@id)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.ExecuteNonQuery();
    }
}
