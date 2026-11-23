using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SistemaAyudantias.Diseno;

// Controles visuales propios, dibujados con GDI+ (livianos, sin librerías externas).
// Después de compilar aparecen en el Cuadro de herramientas de Visual Studio
// y se pueden arrastrar a los formularios como cualquier control.

public enum EstiloBoton { Primario, Secundario, Peligro, Exito }

/// <summary>Botón redondeado con ícono. El color indica la acción (guardar, eliminar...).</summary>
public class Boton : Button
{
    private bool _encima;

    public Boton()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.SupportsTransparentBackColor, true);
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        BackColor = Color.Transparent;
        Cursor = Cursors.Hand;
        Font = Tema.Negrita;
        Size = new Size(120, 40);
    }

    [DefaultValue(EstiloBoton.Primario)]
    public EstiloBoton Estilo { get; set; } = EstiloBoton.Primario;

    [DefaultValue("")]
    public string Icono { get; set; } = "";

    /// <summary>Muestra el ícono en un círculo a la derecha (por ejemplo, una flecha).</summary>
    [DefaultValue(false)]
    public bool IconoDerecha { get; set; }

    protected override void OnMouseEnter(EventArgs e) { _encima = true; Invalidate(); base.OnMouseEnter(e); }
    protected override void OnMouseLeave(EventArgs e) { _encima = false; Invalidate(); base.OnMouseLeave(e); }
    protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Parent?.BackColor ?? Tema.Blanco);

        Color inicio, fin, texto = Color.White;
        switch (Estilo)
        {
            case EstiloBoton.Peligro: inicio = Tema.Peligro; fin = Color.FromArgb(220, 38, 38); break;
            case EstiloBoton.Exito: inicio = Tema.Exito; fin = Color.FromArgb(5, 150, 105); break;
            case EstiloBoton.Secundario: inicio = fin = _encima ? Tema.PrimarioSuave : Tema.Blanco; texto = Tema.Texto; break;
            default: inicio = Tema.Primario; fin = Tema.Secundario; break;
        }

        if (!Enabled)
        {
            inicio = fin = Tema.Borde;
            texto = Tema.TextoSuave;
        }

        var area = new Rectangle(0, 0, Width - 1, Height - 1);
        using (var ruta = Tema.Redondeado(area, 10))
        {
            using (var pincel = new LinearGradientBrush(area, inicio, fin, 0F))
                g.FillPath(pincel, ruta);

            if (Estilo == EstiloBoton.Secundario)
                using (var borde = new Pen(Tema.Borde))
                    g.DrawPath(borde, ruta);
            else if (_encima && Enabled)
                using (var brillo = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
                    g.FillPath(brillo, ruta);
        }

        // Ícono en un círculo blanco a la derecha y texto centrado
        if (IconoDerecha)
        {
            var circulo = new Rectangle(Width - Height + 8, 8, Height - 16, Height - 16);
            using (var blanco = new SolidBrush(Color.White))
                g.FillEllipse(blanco, circulo);
            TextRenderer.DrawText(g, Icono, Tema.FuenteIcono, circulo, inicio,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            TextRenderer.DrawText(g, Text, Font, new Rectangle(0, 0, Width, Height), texto,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            return;
        }

        // Ícono y texto centrados
        var anchoTexto = TextRenderer.MeasureText(Text, Font).Width;
        var anchoIcono = Icono.Length > 0 ? 24 : 0;
        var x = (Width - anchoTexto - anchoIcono) / 2;
        var flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding;

        if (anchoIcono > 0)
            TextRenderer.DrawText(g, Icono, Tema.FuenteIcono, new Rectangle(x, 0, 22, Height), texto, flags);
        TextRenderer.DrawText(g, Text, Font, new Rectangle(x + anchoIcono, 0, anchoTexto + 4, Height), texto, flags);
    }
}

/// <summary>Tarjeta blanca con esquinas redondeadas, sombra suave y título opcional.</summary>
public class Tarjeta : Panel
{
    private string _titulo = "";
    private string _subtitulo = "";

    public Tarjeta()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw, true);
        BackColor = Tema.Fondo;
        Padding = new Padding(22, 18, 22, 18);
    }

    [DefaultValue("")]
    public string Titulo { get => _titulo; set { _titulo = value; Invalidate(); PerformLayout(); } }

    [DefaultValue("")]
    public string Subtitulo { get => _subtitulo; set { _subtitulo = value; Invalidate(); } }

    /// <summary>Color de la franja superior (opcional). Transparent = sin franja.</summary>
    public Color Acento { get; set; } = Color.Transparent;

    // El contenido acoplado (Dock) empieza debajo del título
    public override Rectangle DisplayRectangle
    {
        get
        {
            var area = base.DisplayRectangle;
            var alto = _titulo.Length == 0 ? 0 : _subtitulo.Length == 0 ? 36 : 54;
            return new Rectangle(area.X, area.Y + alto, area.Width, Math.Max(0, area.Height - alto));
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(BackColor);
        var area = new Rectangle(4, 2, Width - 9, Height - 8);

        // Sombra difusa en capas
        for (var i = 1; i <= 4; i++)
            using (var sombra = Tema.Redondeado(new Rectangle(area.X, area.Y + i, area.Width, area.Height), 14))
            using (var pincel = new SolidBrush(Color.FromArgb(12 - i * 2, 15, 23, 42)))
                g.FillPath(pincel, sombra);

        using (var ruta = Tema.Redondeado(area, 14))
        using (var fondo = new SolidBrush(Tema.Blanco))
        using (var borde = new Pen(Color.FromArgb(234, 238, 245)))
        {
            g.FillPath(fondo, ruta);
            g.DrawPath(borde, ruta);

            if (Acento != Color.Transparent)
            {
                g.SetClip(ruta);
                using (var franja = new SolidBrush(Acento))
                    g.FillRectangle(franja, area.X, area.Y, area.Width, 4);
                g.ResetClip();
            }
        }

        if (_titulo.Length > 0)
        {
            TextRenderer.DrawText(g, _titulo, new Font("Segoe UI Semibold", 12F), new Point(Padding.Left - 2, Padding.Top - 4), Tema.Texto);
            if (_subtitulo.Length > 0)
                TextRenderer.DrawText(g, _subtitulo, Tema.Pequena, new Point(Padding.Left, Padding.Top + 20), Tema.TextoSuave);
        }
    }
}

/// <summary>Panel con degradado de color y círculos decorativos (menú lateral, portadas).</summary>
public class PanelDegradado : Panel
{
    public PanelDegradado()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw, true);
    }

    public Color ColorInicio { get; set; } = Tema.MenuArriba;
    public Color ColorFin { get; set; } = Tema.MenuAbajo;

    [DefaultValue(90F)]
    public float Angulo { get; set; } = 90F;

    [DefaultValue(0)]
    public int Radio { get; set; }

    [DefaultValue(true)]
    public bool Decorado { get; set; } = true;

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Width <= 0 || Height <= 0)
            return;

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Parent?.BackColor ?? Tema.Fondo);
        var area = new Rectangle(0, 0, Width - 1, Height - 1);

        using (var ruta = Radio > 0 ? Tema.Redondeado(area, Radio) : new GraphicsPath())
        {
            if (Radio == 0)
                ruta.AddRectangle(area);

            using (var pincel = new LinearGradientBrush(area, ColorInicio, ColorFin, Angulo))
                g.FillPath(pincel, ruta);

            if (Decorado)
            {
                g.SetClip(ruta);
                using (var circulo = new SolidBrush(Color.FromArgb(18, 255, 255, 255)))
                {
                    g.FillEllipse(circulo, Width - 160, -70, 230, 230);
                    g.FillEllipse(circulo, -60, Height - 140, 180, 180);
                    g.FillEllipse(circulo, Width - 90, Height - 90, 70, 70);
                }
                g.ResetClip();
            }
        }
    }
}

/// <summary>Opción del menú lateral con ícono; la opción activa se resalta.</summary>
public class MenuBoton : Control
{
    private bool _activo;
    private bool _encima;

    public MenuBoton()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        Cursor = Cursors.Hand;
        Size = new Size(230, 44);
        Font = Tema.Normal;
    }

    [DefaultValue("")]
    public string Icono { get; set; } = "";

    [DefaultValue(false)]
    public bool Activo { get => _activo; set { _activo = value; Invalidate(); } }

    protected override void OnMouseEnter(EventArgs e) { _encima = true; Invalidate(); base.OnMouseEnter(e); }
    protected override void OnMouseLeave(EventArgs e) { _encima = false; Invalidate(); base.OnMouseLeave(e); }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        var pastilla = new Rectangle(12, 2, Width - 24, Height - 4);

        if (_activo || _encima)
            using (var ruta = Tema.Redondeado(pastilla, 10))
            using (var pincel = _activo
                       ? (Brush)new LinearGradientBrush(pastilla, Color.FromArgb(70, 255, 255, 255), Color.FromArgb(18, 255, 255, 255), 0F)
                       : new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
                g.FillPath(pincel, ruta);

        if (_activo)
            using (var barra = new SolidBrush(Tema.Acento))
                g.FillRectangle(barra, 0, pastilla.Y + 10, 4, pastilla.Height - 20);

        var color = _activo ? Color.White : Tema.MenuTexto;
        TextRenderer.DrawText(g, Icono, Tema.FuenteIcono, new Rectangle(pastilla.X + 12, 0, 24, Height), color,
            TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        TextRenderer.DrawText(g, Text, _activo ? Tema.Negrita : Font, new Rectangle(pastilla.X + 48, 0, pastilla.Width - 52, Height),
            color, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
    }
}

/// <summary>
/// Caja de texto con bordes redondeados, ícono opcional y texto de ayuda (marcador).
/// El borde se pinta de color cuando el campo tiene el foco.
/// </summary>
public class Campo : Panel
{
    private readonly TextBox _caja = new TextBox();
    private readonly Label _marcador = new Label();
    private string _icono = "";

    public Campo()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw, true);
        BackColor = Tema.Blanco;
        Size = new Size(260, 40);
        Padding = new Padding(12, 10, 10, 6);

        _caja.BorderStyle = BorderStyle.None;
        _caja.Font = Tema.Normal;
        _caja.ForeColor = Tema.Texto;
        _caja.BackColor = Color.FromArgb(248, 250, 252);
        _caja.Dock = DockStyle.Fill;
        _caja.TextChanged += (s, e) => { _marcador.Visible = _caja.Text.Length == 0; OnTextChanged(e); };
        _caja.Enter += (s, e) => Invalidate();
        _caja.Leave += (s, e) => Invalidate();

        _marcador.AutoSize = false;
        _marcador.Dock = DockStyle.Fill;
        _marcador.Font = Tema.Normal;
        _marcador.ForeColor = Color.FromArgb(148, 163, 184);
        _marcador.BackColor = Color.FromArgb(248, 250, 252);
        _marcador.Click += (s, e) => _caja.Focus();

        Controls.Add(_marcador);
        Controls.Add(_caja);
    }

    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text { get => _caja.Text; set => _caja.Text = value ?? ""; }

    /// <summary>Texto gris que se muestra cuando el campo está vacío.</summary>
    [DefaultValue("")]
    public string Marcador { get => _marcador.Text; set => _marcador.Text = value; }

    [DefaultValue(32767)]
    public int MaxLength { get => _caja.MaxLength; set => _caja.MaxLength = value; }

    [DefaultValue(false)]
    public bool Contrasena { get => _caja.UseSystemPasswordChar; set => _caja.UseSystemPasswordChar = value; }

    [DefaultValue(false)]
    public bool Multilinea
    {
        get => _caja.Multiline;
        set { _caja.Multiline = value; _caja.ScrollBars = value ? ScrollBars.Vertical : ScrollBars.None; }
    }

    [DefaultValue(false)]
    public bool SoloLectura { get => _caja.ReadOnly; set => _caja.ReadOnly = value; }

    /// <summary>Ícono de Segoe MDL2 Assets a la izquierda (opcional).</summary>
    [DefaultValue("")]
    public string Icono
    {
        get => _icono;
        set { _icono = value; Padding = new Padding(value.Length > 0 ? 38 : 12, 10, 10, 6); Invalidate(); }
    }

    public new void Focus() => _caja.Focus();

    public void Clear() => _caja.Clear();

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Parent?.BackColor ?? Tema.Blanco);

        var enfocado = _caja.Focused;
        using (var ruta = Tema.Redondeado(new Rectangle(0, 0, Width - 1, Height - 1), 9))
        using (var fondo = new SolidBrush(Color.FromArgb(248, 250, 252)))
        using (var borde = new Pen(enfocado ? Tema.Primario : Tema.Borde, enfocado ? 1.6F : 1F))
        {
            g.FillPath(fondo, ruta);
            g.DrawPath(borde, ruta);
        }

        if (_icono.Length > 0)
            TextRenderer.DrawText(g, _icono, Tema.FuenteIcono, new Rectangle(8, 0, 26, Math.Min(Height, 40)),
                enfocado ? Tema.Primario : Tema.TextoSuave, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
    }
}
