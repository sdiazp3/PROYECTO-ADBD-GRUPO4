using System.Drawing.Drawing2D;

namespace SistemaAyudantias.Diseno;

/// <summary>
/// Colores, fuentes, íconos y estilo de tablas de toda la aplicación.
/// Cambiando un valor aquí cambia el diseño completo.
/// </summary>
public static class Tema
{
    // ---------------- Colores (verde y dorado institucional) ----------------
    public static readonly Color Fondo = Color.FromArgb(244, 247, 245);
    public static readonly Color Blanco = Color.White;
    public static readonly Color Borde = Color.FromArgb(222, 230, 225);
    public static readonly Color Texto = Color.FromArgb(17, 38, 29);
    public static readonly Color TextoSuave = Color.FromArgb(100, 116, 110);

    public static readonly Color Primario = Color.FromArgb(18, 122, 69);      // verde
    public static readonly Color Secundario = Color.FromArgb(11, 79, 48);     // verde oscuro
    public static readonly Color PrimarioSuave = Color.FromArgb(232, 245, 238);
    public static readonly Color Acento = Color.FromArgb(242, 183, 5);        // dorado
    public static readonly Color Exito = Color.FromArgb(16, 185, 129);
    public static readonly Color Advertencia = Color.FromArgb(245, 158, 11);
    public static readonly Color Peligro = Color.FromArgb(220, 38, 38);

    public static readonly Color MenuArriba = Color.FromArgb(7, 52, 32);      // menú lateral
    public static readonly Color MenuAbajo = Color.FromArgb(14, 92, 56);
    public static readonly Color MenuTexto = Color.FromArgb(205, 230, 215);

    // ---------------- Fuentes ----------------
    public static readonly Font Normal = new Font("Segoe UI", 10F);
    public static readonly Font Negrita = new Font("Segoe UI Semibold", 10F);
    public static readonly Font Pequena = new Font("Segoe UI", 8.5F);
    public static readonly Font Titulo = new Font("Segoe UI Semibold", 15F);
    public static readonly Font Cifra = new Font("Segoe UI", 22F, FontStyle.Bold);

    // ---------------- Íconos (fuente Segoe MDL2 Assets de Windows 10/11) ----------------
    public static readonly Font FuenteIcono = new Font("Segoe MDL2 Assets", 12F);
    public static readonly Font FuenteIconoGrande = new Font("Segoe MDL2 Assets", 18F);

    public const string IconoInicio = "";
    public const string IconoUsuarios = "";
    public const string IconoFacultad = "";
    public const string IconoCarrera = "";
    public const string IconoAsignatura = "";
    public const string IconoPeriodo = "";
    public const string IconoConvocatoria = "";
    public const string IconoPostular = "";
    public const string IconoEvaluar = "";
    public const string IconoReporte = "";
    public const string IconoSalir = "";
    public const string IconoBuscar = "";
    public const string IconoNuevo = "";
    public const string IconoGuardar = "";
    public const string IconoEliminar = "";
    public const string IconoAdjuntar = "";
    public const string IconoCorreo = "";
    public const string IconoClave = "";
    public const string IconoReloj = "";
    public const string IconoEstrella = "";

    // ---------------- Imágenes de la carpeta Recursos ----------------
    private static readonly Dictionary<string, Image?> Imagenes = new Dictionary<string, Image?>();

    public static Image? Imagen(string archivo)
    {
        if (!Imagenes.ContainsKey(archivo))
        {
            var ruta = Path.Combine(AppContext.BaseDirectory, "Recursos", archivo);
            Imagenes[archivo] = File.Exists(ruta) ? Image.FromFile(ruta) : null;
        }

        return Imagenes[archivo];
    }

    // ---------------- Dibujo ----------------
    /// <summary>Rectángulo con esquinas redondeadas.</summary>
    public static GraphicsPath Redondeado(Rectangle area, int radio)
    {
        var ruta = new GraphicsPath();
        var d = Math.Max(1, radio * 2);
        ruta.AddArc(area.X, area.Y, d, d, 180, 90);
        ruta.AddArc(area.Right - d, area.Y, d, d, 270, 90);
        ruta.AddArc(area.Right - d, area.Bottom - d, d, d, 0, 90);
        ruta.AddArc(area.X, area.Bottom - d, d, d, 90, 90);
        ruta.CloseFigure();
        return ruta;
    }

    /// <summary>Colores de fondo y texto para cada estado (chips de colores).</summary>
    public static (Color Fondo, Color Texto) ColorEstado(string estado)
    {
        switch (estado)
        {
            case "Seleccionado":
            case "Abierta":
            case "Activo":
            case "Actual":
            case "Sube":
                return (Color.FromArgb(209, 250, 229), Color.FromArgb(4, 120, 87));
            case "Pendiente":
            case "Próxima":
            case "Próximo":
                return (Color.FromArgb(254, 243, 199), Color.FromArgb(180, 83, 9));
            case "En espera":
            case "Estable":
                return (Color.FromArgb(219, 234, 254), Color.FromArgb(29, 78, 216));
            case "No seleccionado":
            case "Inactivo":
            case "Baja":
                return (Color.FromArgb(254, 226, 226), Color.FromArgb(185, 28, 28));
            default:
                return (Color.FromArgb(241, 245, 249), Color.FromArgb(71, 85, 105));
        }
    }

    // ---------------- Estilo de los controles estándar ----------------
    /// <summary>Aplica el estilo web a las tablas y combos de un formulario (se llama en el constructor).</summary>
    public static void Aplicar(Control raiz)
    {
        foreach (Control control in raiz.Controls)
        {
            if (control is DataGridView tabla)
                EstilizarTabla(tabla);
            else if (control is ComboBox combo)
                EstilizarCombo(combo);

            Aplicar(control);
        }
    }

    /// <summary>Combo más alto y con la opción seleccionada resaltada.</summary>
    public static void EstilizarCombo(ComboBox combo)
    {
        combo.DrawMode = DrawMode.OwnerDrawFixed;
        combo.ItemHeight = 28;
        combo.Font = Normal;
        combo.DrawItem += (s, e) =>
        {
            if (e.Index < 0)
                return;

            var seleccionado = (e.State & DrawItemState.Selected) != 0 && (e.State & DrawItemState.ComboBoxEdit) == 0;
            using (var fondo = new SolidBrush(seleccionado ? PrimarioSuave : Blanco))
                e.Graphics.FillRectangle(fondo, e.Bounds);

            var area = new Rectangle(e.Bounds.X + 8, e.Bounds.Y, e.Bounds.Width - 10, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, combo.GetItemText(combo.Items[e.Index]), Normal, area, Texto,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        };
    }

    // ---------------- Tablas ----------------
    /// <summary>
    /// Da estilo web a una tabla: filas amplias, sin bordes verticales, encabezado claro,
    /// columnas "id_..." ocultas y la columna Estado/Activo como chip de color.
    /// </summary>
    public static void EstilizarTabla(DataGridView tabla)
    {
        tabla.BackgroundColor = Blanco;
        tabla.BorderStyle = BorderStyle.None;
        tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        tabla.GridColor = Color.FromArgb(241, 245, 249);
        tabla.RowHeadersVisible = false;
        tabla.AllowUserToAddRows = false;
        tabla.AllowUserToDeleteRows = false;
        tabla.AllowUserToResizeRows = false;
        tabla.ReadOnly = true;
        tabla.MultiSelect = false;
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        tabla.EnableHeadersVisualStyles = false;
        tabla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        tabla.ColumnHeadersHeight = 42;
        tabla.RowTemplate.Height = 44;

        tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        tabla.ColumnHeadersDefaultCellStyle.ForeColor = TextoSuave;
        tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
        tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
        tabla.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

        tabla.DefaultCellStyle.Font = Normal;
        tabla.DefaultCellStyle.ForeColor = Texto;
        tabla.DefaultCellStyle.SelectionBackColor = PrimarioSuave;
        tabla.DefaultCellStyle.SelectionForeColor = Texto;
        tabla.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
        tabla.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

        tabla.DataBindingComplete += (s, e) => PrepararColumnas(tabla);
        tabla.CellPainting += DibujarChip;
    }

    private static void PrepararColumnas(DataGridView tabla)
    {
        foreach (DataGridViewColumn columna in tabla.Columns)
        {
            columna.Visible = !columna.Name.StartsWith("id_") && columna.Name != "Requisitos";
            columna.SortMode = DataGridViewColumnSortMode.Automatic;

            if (columna.ValueType == typeof(DateTime))
                columna.DefaultCellStyle.Format = "dd/MM/yyyy";
            if (columna.ValueType == typeof(decimal))
                columna.DefaultCellStyle.Format = "0.##";

            // Las columnas con textos largos reciben más espacio
            columna.FillWeight = columna.Name is "Asignatura" or "Estudiante" or "Facultad" or "Carrera" or "Correo"
                or "Observación" or "Período" ? 200 : 100;

            // Espacio suficiente para los chips de estado
            if (columna.Name is "Estado" or "Activo" or "Activa" or "Postulado" or "Tendencia")
                columna.MinimumWidth = 130;
        }
    }

    // Dibuja las columnas de estado como "chips" de color, igual que en una página web.
    private static void DibujarChip(object? sender, DataGridViewCellPaintingEventArgs e)
    {
        if (sender is not DataGridView tabla || e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null)
            return;

        var nombre = tabla.Columns[e.ColumnIndex].Name;
        if (nombre != "Estado" && nombre != "Activo" && nombre != "Activa" && nombre != "Postulado" && nombre != "Tendencia")
            return;

        var texto = e.Value switch
        {
            bool valor => valor ? "Activo" : "Inactivo",
            null => "",
            _ => e.Value.ToString() ?? ""
        };
        if (nombre == "Postulado")
            texto = texto == "Sí" ? "Ya postulado" : "Disponible";

        var (fondo, colorTexto) = ColorEstado(texto == "Ya postulado" ? "En espera" : texto == "Disponible" ? "Abierta" : texto);

        e.PaintBackground(e.CellBounds, true);
        var tamano = TextRenderer.MeasureText(texto, Pequena);
        var chip = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + (e.CellBounds.Height - 24) / 2, tamano.Width + 18, 24);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using (var ruta = Redondeado(chip, 12))
        using (var pincel = new SolidBrush(fondo))
            e.Graphics.FillPath(pincel, ruta);

        TextRenderer.DrawText(e.Graphics, texto, Pequena, chip, colorTexto,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        e.Handled = true;
    }
}
