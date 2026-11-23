using System.Data;
using System.Text.Json;
using Npgsql;

namespace SistemaAyudantias.Datos;

/// <summary>
/// Conexión con PostgreSQL.
///
/// QUÉ DEBE CAMBIAR PARA CONECTARSE A SU BASE DE DATOS:
///   Nada en el código. Solo edite el archivo appsettings.json (junto al programa):
///     "ConexionPostgreSQL": "Host=localhost;Port=5432;Database=ayudantias_catedra;Username=app_ayudantias;Password=SU_CLAVE"
///   · Host / Port : dónde está PostgreSQL (normalmente localhost y 5432)
///   · Database    : nombre de la base creada con el script ayudantias_catedra.sql
///   · Username    : app_ayudantias (usuario creado al final del script)
///   · Password    : la contraseña que puso en la PARTE 4 del script
///
/// Cada clase de esta carpeta (FacultadDatos, UsuarioDatos, ...) abre la conexión
/// con Conexion.Abrir() y llama a un procedimiento almacenado o función de la base.
/// </summary>
public static class Conexion
{
    private static string _cadena = "";

    /// <summary>Nombre de la institución que se muestra en pantallas y reportes.</summary>
    public static string Institucion { get; private set; } = "Universidad Técnica Estatal de Quevedo";

    /// <summary>Lee los datos de conexión del archivo appsettings.json.</summary>
    public static void LeerConfiguracion()
    {
        var ruta = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        if (!File.Exists(ruta))
            throw new FileNotFoundException("No se encontró el archivo appsettings.json junto al programa.");

        using var json = JsonDocument.Parse(File.ReadAllText(ruta));
        _cadena = json.RootElement.GetProperty("ConexionPostgreSQL").GetString() ?? "";

        if (json.RootElement.TryGetProperty("Institucion", out var institucion))
            Institucion = institucion.GetString() ?? Institucion;
    }

    /// <summary>Devuelve una conexión abierta. Úsela siempre con "using" para que se cierre sola.</summary>
    public static NpgsqlConnection Abrir()
    {
        var conexion = new NpgsqlConnection(_cadena);
        conexion.Open();
        return conexion;
    }

    /// <summary>Ejecuta una consulta (SELECT) y devuelve sus filas en una tabla.</summary>
    public static DataTable LlenarTabla(NpgsqlCommand comando)
    {
        var tabla = new DataTable();
        using var adaptador = new NpgsqlDataAdapter(comando);
        adaptador.Fill(tabla);
        return ConvertirFechas(tabla);
    }

    /// <summary>
    /// Npgsql entrega las columnas DATE como DateOnly, pero los controles de Windows Forms
    /// (DateTimePicker, Convert.ToDateTime, formatos de la tabla) trabajan con DateTime.
    /// Aquí se cambian esas columnas a DateTime una sola vez para todo el programa.
    /// </summary>
    private static DataTable ConvertirFechas(DataTable original)
    {
        var hayFechas = original.Columns.Cast<DataColumn>().Any(c => c.DataType == typeof(DateOnly));
        if (!hayFechas)
            return original;

        var tabla = original.Clone();
        foreach (DataColumn columna in tabla.Columns)
            if (columna.DataType == typeof(DateOnly))
                columna.DataType = typeof(DateTime);

        foreach (DataRow fila in original.Rows)
        {
            var nueva = tabla.NewRow();
            foreach (DataColumn columna in original.Columns)
            {
                var valor = fila[columna];
                if (valor is DateOnly fecha)
                    nueva[columna.ColumnName] = fecha.ToDateTime(TimeOnly.MinValue);
                else
                    nueva[columna.ColumnName] = valor;
            }
            tabla.Rows.Add(nueva);
        }

        return tabla;
    }

    /// <summary>Convierte un número vacío (null) en el NULL de la base de datos.</summary>
    public static object ValorONulo(int? valor)
    {
        if (valor == null)
            return DBNull.Value;

        return valor.Value;
    }
}
