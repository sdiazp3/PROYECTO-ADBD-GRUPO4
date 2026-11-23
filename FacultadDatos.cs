using System.Data;
using Npgsql;

namespace SistemaAyudantias.Datos;

/// <summary>Facultades: llama a las rutinas fn_listar_facultades y sp_*_facultad.</summary>
public static class FacultadDatos
{
    public static DataTable Listar()
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_listar_facultades()", conexion);
        return Conexion.LlenarTabla(comando);
    }

    public static void Insertar(string nombre, bool activa)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_insertar_facultad(@nombre, @activa)", conexion);
        comando.Parameters.AddWithValue("nombre", nombre);
        comando.Parameters.AddWithValue("activa", activa);
        comando.ExecuteNonQuery();
    }

    public static void Actualizar(int id, string nombre, bool activa)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_actualizar_facultad(@id, @nombre, @activa)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.Parameters.AddWithValue("nombre", nombre);
        comando.Parameters.AddWithValue("activa", activa);
        comando.ExecuteNonQuery();
    }

    public static void Eliminar(int id)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_eliminar_facultad(@id)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.ExecuteNonQuery();
    }
}
