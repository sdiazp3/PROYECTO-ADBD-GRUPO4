using System.Data;
using Npgsql;

namespace SistemaAyudantias.Utilidades;

/// <summary>Funciones pequeñas que usan todos los formularios: mensajes, combos y manejo de errores.</summary>
public static class Ayuda
{
    private const string Titulo = "Ayudantías de Cátedra";

    public static void Informar(string mensaje) =>
        MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

    public static void Advertir(string mensaje) =>
        MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public static bool Confirmar(string pregunta) =>
        MessageBox.Show(pregunta, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    /// <summary>
    /// Ejecuta una acción mostrando un mensaje claro si algo falla. Devuelve true si terminó bien.
    /// · Mensajes de los procedimientos (RAISE EXCEPTION): se muestran tal cual al usuario.
    /// · Sin conexión con PostgreSQL: se avisa que revise el servidor.
    /// · Otro error: mensaje general y detalle guardado en Logs/errores.log.
    /// </summary>
    public static bool Intentar(Action accion)
    {
        try
        {
            Cursor.Current = Cursors.WaitCursor;
            accion();
            return true;
        }
        catch (PostgresException ex)
        {
            Advertir(MensajeBaseDatos(ex));
        }
        catch (NpgsqlException ex)
        {
            RegistrarError(ex);
            Advertir("No se pudo comunicar con la base de datos. Verifique que PostgreSQL esté encendido.\n\n" + ex.Message);
        }
        catch (Exception ex)
        {
            RegistrarError(ex);
            MessageBox.Show("Ocurrió un error inesperado. El detalle se guardó en la carpeta Logs.\n\n" + ex.Message,
                Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor.Current = Cursors.Default;
        }

        return false;
    }

    // Los RAISE EXCEPTION de los procedimientos tienen el código P0001 y un mensaje ya pensado para el usuario
    private static string MensajeBaseDatos(PostgresException ex)
    {
        switch (ex.SqlState)
        {
            case "P0001": return ex.MessageText;
            case PostgresErrorCodes.UniqueViolation: return "El registro ya existe.";
            case PostgresErrorCodes.ForeignKeyViolation: return "El registro está relacionado con otros datos.";
            case PostgresErrorCodes.CheckViolation: return "Uno de los datos no cumple las reglas del sistema.";
            case PostgresErrorCodes.InsufficientPrivilege: return "El usuario de la base de datos no tiene permiso para esta acción.";
            default: return "Error de la base de datos: " + ex.MessageText;
        }
    }

    public static void RegistrarError(Exception ex)
    {
        try
        {
            var carpeta = Path.Combine(AppContext.BaseDirectory, "Logs");
            Directory.CreateDirectory(carpeta);
            File.AppendAllText(Path.Combine(carpeta, "errores.log"), $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex}\n\n");
        }
        catch (IOException)
        {
            // Si no se puede escribir el registro, el mensaje ya se mostró al usuario.
        }
    }

    /// <summary>Llena un combo con una tabla. Si textoTodos no es null, agrega esa opción al inicio (valor nulo).</summary>
    public static void LlenarCombo(ComboBox combo, DataTable datos, string columnaValor, string columnaTexto,
        string? textoTodos = null)
    {
        var opciones = new DataTable();
        opciones.Columns.Add("valor", typeof(object));
        opciones.Columns.Add("texto", typeof(string));

        if (textoTodos != null)
            opciones.Rows.Add(DBNull.Value, textoTodos);

        foreach (DataRow fila in datos.Rows)
            opciones.Rows.Add(fila[columnaValor], fila[columnaTexto]);

        combo.DataSource = null;
        combo.DisplayMember = "texto";
        combo.ValueMember = "valor";
        combo.DataSource = opciones;
    }

    /// <summary>Valor seleccionado del combo, o null si no hay selección o es "Todos".</summary>
    public static int? ValorCombo(ComboBox combo) =>
        combo.SelectedValue is null or DBNull ? null : Convert.ToInt32(combo.SelectedValue);

    /// <summary>Filtra las filas de la tabla que contienen el texto en cualquier columna de texto.</summary>
    public static void Filtrar(DataGridView grid, string texto)
    {
        if (grid.DataSource is not DataTable tabla)
            return;

        // Se quitan los caracteres especiales del filtro de DataView
        var limpio = new string(texto.Trim().Where(c => "'[]%*".IndexOf(c) < 0).ToArray());
        var condiciones = tabla.Columns.Cast<DataColumn>()
            .Where(c => c.DataType == typeof(string))
            .Select(c => "[" + c.ColumnName + "] LIKE '%" + limpio + "%'");

        tabla.DefaultView.RowFilter = limpio.Length == 0 ? "" : string.Join(" OR ", condiciones);
    }

    /// <summary>Valor de una celda de la fila seleccionada del grid.</summary>
    public static object? Celda(DataGridView grid, string columna) =>
        grid.CurrentRow?.Cells[columna].Value is { } valor and not DBNull ? valor : null;
}
