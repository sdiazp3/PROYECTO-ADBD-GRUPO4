using System.Data;
using Npgsql;

namespace SistemaAyudantias.Datos;

/// <summary>Usuarios, roles, inicio de sesión y contraseñas.</summary>
public static class UsuarioDatos
{
    /// <summary>
    /// Verifica correo y contraseña en la base (la contraseña se compara cifrada en PostgreSQL).
    /// Devuelve una fila con id_usuario, nombres, apellidos, id_rol, rol, id_carrera y carrera.
    /// </summary>
    public static DataRow IniciarSesion(string correo, string contrasena)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_iniciar_sesion(@correo, @contrasena)", conexion);
        comando.Parameters.AddWithValue("correo", correo);
        comando.Parameters.AddWithValue("contrasena", contrasena);
        return Conexion.LlenarTabla(comando).Rows[0];
    }

    public static DataTable ListarRoles()
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_listar_roles()", conexion);
        return Conexion.LlenarTabla(comando);
    }

    public static DataTable Listar()
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("SELECT * FROM fn_listar_usuarios()", conexion);
        return Conexion.LlenarTabla(comando);
    }

    /// <summary>Registra un usuario con su contraseña inicial (el administrador no tiene carrera).</summary>
    public static void Insertar(string cedula, string nombres, string apellidos, string correo, string contrasena,
        int idRol, int? idCarrera)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "CALL sp_insertar_usuario(@cedula, @nombres, @apellidos, @correo, @contrasena, @id_rol, @id_carrera)", conexion);
        comando.Parameters.AddWithValue("cedula", cedula);
        comando.Parameters.AddWithValue("nombres", nombres);
        comando.Parameters.AddWithValue("apellidos", apellidos);
        comando.Parameters.AddWithValue("correo", correo);
        comando.Parameters.AddWithValue("contrasena", contrasena);
        comando.Parameters.AddWithValue("id_rol", idRol);
        comando.Parameters.AddWithValue("id_carrera", Conexion.ValorONulo(idCarrera));
        comando.ExecuteNonQuery();
    }

    public static void Actualizar(int id, string cedula, string nombres, string apellidos, string correo,
        int idRol, int? idCarrera)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand(
            "CALL sp_actualizar_usuario(@id, @cedula, @nombres, @apellidos, @correo, @id_rol, @id_carrera)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.Parameters.AddWithValue("cedula", cedula);
        comando.Parameters.AddWithValue("nombres", nombres);
        comando.Parameters.AddWithValue("apellidos", apellidos);
        comando.Parameters.AddWithValue("correo", correo);
        comando.Parameters.AddWithValue("id_rol", idRol);
        comando.Parameters.AddWithValue("id_carrera", Conexion.ValorONulo(idCarrera));
        comando.ExecuteNonQuery();
    }

    /// <summary>Activa o desactiva la cuenta. Un usuario desactivado no puede iniciar sesión.</summary>
    public static void CambiarEstado(int id, bool activo)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_cambiar_estado_usuario(@id, @activo)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.Parameters.AddWithValue("activo", activo);
        comando.ExecuteNonQuery();
    }

    /// <summary>Cada usuario cambia su propia contraseña escribiendo la actual.</summary>
    public static void CambiarContrasena(int id, string actual, string nueva)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_cambiar_contrasena(@id, @actual, @nueva)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.Parameters.AddWithValue("actual", actual);
        comando.Parameters.AddWithValue("nueva", nueva);
        comando.ExecuteNonQuery();
    }

    public static void Eliminar(int id)
    {
        using var conexion = Conexion.Abrir();
        using var comando = new NpgsqlCommand("CALL sp_eliminar_usuario(@id)", conexion);
        comando.Parameters.AddWithValue("id", id);
        comando.ExecuteNonQuery();
    }
}
