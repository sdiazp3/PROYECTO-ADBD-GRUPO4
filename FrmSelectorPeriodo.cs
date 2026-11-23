using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;
using SistemaAyudantias.Diseno;

namespace SistemaAyudantias.Formularios;

/// <summary>
/// Ventana emergente para elegir el período académico.
/// Agrupa los períodos en "En curso", "Próximos" y "Anteriores"; el período en curso
/// muestra cuánto avanza el semestre. Se cierra al elegir, al pulsar Esc o al hacer clic fuera.
/// </summary>
public partial class FrmSelectorPeriodo : Form
{
    private static readonly CultureInfo Espanol = new CultureInfo("es-EC");

    private readonly DataTable _periodos;
    private readonly int _idActual;
    private Panel? _filaEncima;

    /// <summary>Período que eligió el usuario (null si cerró sin elegir).</summary>
    public int? IdElegido { get; private set; }

    public FrmSelectorPeriodo(DataTable periodos, int idActual)
    {
        InitializeComponent();
        _periodos = periodos;
        _idActual = idActual;
    }

    // Sombra de ventana emergente (Windows)
    protected override CreateParams CreateParams
    {
        get
        {
            var parametros = base.CreateParams;
            parametros.ClassStyle |= 0x00020000; // CS_DROPSHADOW
            return parametros;
        }
    }

    private void FrmSelectorPeriodo_Load(object sender, EventArgs e)
    {
        AgregarSeccion("EN CURSO", "Actual");
        AgregarSeccion("PRÓXIMOS", "Próximo");
        AgregarSeccion("ANTERIORES", "Finalizado");

        // El alto se ajusta a la cantidad de períodos (máximo 560 px, luego aparece la barra)
        var alto = panelEncabezado.Height + panelPie.Height + panelLista.Padding.Vertical;
        foreach (Control control in panelLista.Controls)
            alto += control.Height + control.Margin.Vertical;
        Height = Math.Min(560, alto + 16);
    }

    private void AgregarSeccion(string titulo, string estado)
    {
        var filas = _periodos.Select("Estado = '" + estado + "'", "Inicio DESC");
        if (filas.Length == 0)
            return;

        panelLista.Controls.Add(new Label
        {
            Text = titulo + "  ·  " + filas.Length,
            Font = new Font("Segoe UI Semibold", 8F),
            ForeColor = Tema.TextoSuave,
            AutoSize = true,
            Margin = new Padding(4, 8, 0, 6)
        });

        foreach (var periodo in filas)
            panelLista.Controls.Add(CrearFila(periodo));
    }

    // Cada período es un panel que se dibuja a sí mismo (DibujarFila)
    private Panel CrearFila(DataRow periodo)
    {
        var fila = new Panel
        {
            Width = 384,
            Height = Convert.ToString(periodo["Estado"]) == "Actual" ? 112 : 64,
            Margin = new Padding(0, 0, 0, 8),
            Cursor = Cursors.Hand,
            Tag = periodo
        };

        fila.Paint += DibujarFila;
        fila.Click += (s, e) => { IdElegido = Convert.ToInt32(periodo["id_periodo"]); Close(); };
        fila.MouseEnter += (s, e) => { _filaEncima = fila; fila.Invalidate(); };
        fila.MouseLeave += (s, e) => { _filaEncima = null; fila.Invalidate(); };
        return fila;
    }

    private void DibujarFila(object? sender, PaintEventArgs e)
    {
        var fila = (Panel)sender!;
        var periodo = (DataRow)fila.Tag!;
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        var estado = Convert.ToString(periodo["Estado"]) ?? "";
        var enCurso = estado == "Actual";
        var elegido = Convert.ToInt32(periodo["id_periodo"]) == _idActual;
        var encima = fila == _filaEncima;
        var inicio = Convert.ToDateTime(periodo["Inicio"]);
        var fin = Convert.ToDateTime(periodo["Fin"]);
        var area = new Rectangle(1, 1, fila.Width - 3, fila.Height - 3);

        // ---- Fondo de la tarjeta ----
        using (var ruta = Tema.Redondeado(area, 12))
        {
            if (enCurso)
            {
                using var degradado = new LinearGradientBrush(area, Tema.Primario, Tema.Secundario, 0F);
                g.FillPath(degradado, ruta);
            }
            else
            {
                var fondo = elegido ? Tema.PrimarioSuave : encima ? Color.FromArgb(247, 250, 248) : Color.White;
                using var pincel = new SolidBrush(fondo);
                g.FillPath(pincel, ruta);
            }

            var colorBorde = elegido ? (enCurso ? Tema.Acento : Tema.Primario) : enCurso ? Tema.Secundario : Tema.Borde;
            using var borde = new Pen(colorBorde, elegido ? 2F : 1F);
            g.DrawPath(borde, ruta);
        }

        // Franja izquierda del período elegido
        if (elegido && !enCurso)
            using (var franja = new SolidBrush(Tema.Primario))
                g.FillRectangle(franja, 1, 14, 4, 36);

        var texto = enCurso ? Color.White : Tema.Texto;
        var textoSuave = enCurso ? Color.FromArgb(209, 236, 220) : Tema.TextoSuave;

        // ---- Ícono en círculo ----
        var circulo = new Rectangle(14, 14, 36, 36);
        var colorCirculo = enCurso ? Color.FromArgb(40, 255, 255, 255)
            : estado == "Próximo" ? Color.FromArgb(254, 243, 199) : Color.FromArgb(241, 245, 243);
        using (var pincel = new SolidBrush(colorCirculo))
            g.FillEllipse(pincel, circulo);
        var icono = enCurso ? "" : estado == "Próximo" ? "" : ""; // calendario, reloj, historial
        var colorIcono = enCurso ? Tema.Acento : estado == "Próximo" ? Color.FromArgb(180, 83, 9) : Tema.TextoSuave;
        TextRenderer.DrawText(g, icono, Tema.FuenteIcono, circulo, colorIcono,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        // ---- Nombre y fechas ----
        TextRenderer.DrawText(g, Convert.ToString(periodo["Período"]), new Font("Segoe UI Semibold", 10.5F),
            new Point(62, 12), texto);
        TextRenderer.DrawText(g, inicio.ToString("d MMM yyyy", Espanol) + "  —  " + fin.ToString("d MMM yyyy", Espanol),
            Tema.Pequena, new Point(63, 34), textoSuave);

        // ---- Distintivo de estado y marca de elegido ----
        var distintivo = enCurso ? "En curso" : estado == "Próximo" ? "Próximo" : "Finalizado";
        var (fondoChip, textoChip) = enCurso
            ? (Tema.Acento, Tema.Secundario)
            : Tema.ColorEstado(estado == "Próximo" ? "Próxima" : "");
        var anchoChip = TextRenderer.MeasureText(distintivo, Tema.Pequena).Width + 16;
        var derecha = elegido ? fila.Width - 44 : fila.Width - 14;
        var chip = new Rectangle(derecha - anchoChip, 18, anchoChip, 22);
        using (var ruta = Tema.Redondeado(chip, 11))
        using (var pincel = new SolidBrush(fondoChip))
            g.FillPath(pincel, ruta);
        TextRenderer.DrawText(g, distintivo, Tema.Pequena, chip, textoChip,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        if (elegido)
        {
            var marca = new Rectangle(fila.Width - 36, 17, 24, 24);
            using (var pincel = new SolidBrush(enCurso ? Color.White : Tema.Primario))
                g.FillEllipse(pincel, marca);
            TextRenderer.DrawText(g, "", new Font("Segoe MDL2 Assets", 9F), marca, enCurso ? Tema.Primario : Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // ---- Avance del semestre (solo el período en curso) ----
        if (enCurso)
        {
            var totalDias = Math.Max(1, (fin - inicio).Days);
            var dias = Math.Max(0, Math.Min(totalDias, (DateTime.Today - inicio).Days));
            var semana = dias / 7 + 1;
            var semanas = totalDias / 7 + 1;
            var porcentaje = dias * 100 / totalDias;

            TextRenderer.DrawText(g, "Semana " + semana + " de " + semanas, Tema.Pequena, new Point(16, 66), textoSuave);
            TextRenderer.DrawText(g, porcentaje + " % del semestre", Tema.Pequena,
                new Rectangle(0, 66, fila.Width - 16, 18), textoSuave, TextFormatFlags.Right);

            var barra = new Rectangle(16, 88, fila.Width - 34, 8);
            using (var ruta = Tema.Redondeado(barra, 4))
            using (var pincel = new SolidBrush(Color.FromArgb(50, 255, 255, 255)))
                g.FillPath(pincel, ruta);
            var avance = new Rectangle(barra.X, barra.Y, Math.Max(8, barra.Width * porcentaje / 100), barra.Height);
            using (var ruta = Tema.Redondeado(avance, 4))
            using (var pincel = new SolidBrush(Tema.Acento))
                g.FillPath(pincel, ruta);
        }
    }

    // Borde fino alrededor de la ventana
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using var borde = new Pen(Tema.Borde);
        e.Graphics.DrawRectangle(borde, 0, 0, Width - 1, Height - 1);
    }

    // Se cierra al hacer clic fuera de la ventana o al pulsar Esc
    private void FrmSelectorPeriodo_Deactivate(object sender, EventArgs e) => Close();

    private void FrmSelectorPeriodo_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
            Close();
    }

    private void lblCerrar_Click(object sender, EventArgs e) => Close();
}
