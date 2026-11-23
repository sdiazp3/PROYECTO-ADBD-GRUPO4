using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace SistemaAyudantias.Datos;

/// <summary>Períodos académicos: llama a las rutinas fn_listar_periodos y sp_*_periodo.</summary>
public static class PeriodoDatos
{
    public static DataTable Listar()
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_listar_periodos()", conexion);
        return Conexion.LlenarTabla(comando);
    }

    public static void Insertar(string nombre, DateTime inicio, DateTime fin, bool activo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_insertar_periodo(@nombre, @inicio, @fin, @activo)", conexion);
        comando.Parameters.AddWithValue("nombre", nombre);
        // Las fechas se envían como DATE (solo día, sin hora)
        comando.Parameters.AddWithValue("inicio", NpgsqlDbType.Date, inicio.Date);
        comando.Parameters.AddWithValue("fin", NpgsqlDbType.Date, fin.Date);
        comando.Parameters.AddWithValue("activo", activo);
        comando.ExecuteNonQuery();
    }

    public static void Actualizar(int id, string nombre, DateTime inicio, DateTime fin, bool activo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_actualizar_periodo(@id, @nombre, @inicio, @fin, @activo)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.Parameters.AddWithValue("nombre", nombre);
        comando.Parameters.AddWithValue("inicio", NpgsqlDbType.Date, inicio.Date);
        comando.Parameters.AddWithValue("fin", NpgsqlDbType.Date, fin.Date);
        comando.Parameters.AddWithValue("activo", activo);
        comando.ExecuteNonQuery();
    }

    public static void Eliminar(int id)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_eliminar_periodo(@id)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.ExecuteNonQuery();
    }
}
