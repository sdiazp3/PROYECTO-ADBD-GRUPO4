using System.Data;
using System.Drawing.Drawing2D;
using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>
/// Predicción de postulantes del período elegido arriba, usando solo los períodos anteriores a él.
/// En un período que ya terminó se compara la predicción con lo que realmente pasó.
/// El cálculo se hace en PostgreSQL (fn_prediccion_postulantes); aquí solo se muestra.
/// </summary>
public partial class FrmPredicciones : Form
{
    private DataTable _historial = new DataTable();
    private int _prediccion;
    private int? _real;

    public FrmPredicciones()
    {
        InitializeComponent();
        Tema.Aplicar(this);

        // El coordinador solo ve su carrera: no hace falta mostrarla
        if (Sesion.IdRol != Sesion.Administrador)
            tablaPredicciones.DataBindingComplete += (s, e) => tablaPredicciones.Columns["Carrera"].Visible = false;
    }

    private void FrmPredicciones_Load(object sender, EventArgs e)
    {
        tarjetaLista.Titulo = "Predicción de postulantes · " + Sesion.Periodo;
        tarjetaLista.Subtitulo = Sesion.PeriodoFinalizado
            ? "Calculada con los períodos anteriores y comparada con lo que realmente ocurrió (columna Real)"
            : "Calculada con los períodos anteriores a " + Sesion.Periodo;

        Ayuda.Intentar(() => tablaPredicciones.DataSource = PrediccionDatos.Listar(Sesion.IdUsuario, Sesion.IdPeriodo));

        if (tablaPredicciones.Rows.Count > 0)
        {
            MostrarAsignatura(tablaPredicciones.Rows[0]);
        }
        else
        {
            tarjetaGrafico.Titulo = "Sin datos para predecir";
            tarjetaGrafico.Subtitulo = "No hay períodos anteriores a " + Sesion.Periodo + " con convocatorias cerradas";
            lblResumen.Text = "Elija un período más reciente en la parte superior.";
        }
    }

    private void tablaPredicciones_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            MostrarAsignatura(tablaPredicciones.Rows[e.RowIndex]);
    }

    private void MostrarAsignatura(DataGridViewRow fila)
    {
        var idAsignatura = Convert.ToInt32(fila.Cells["id_asignatura"].Value);
        _prediccion = Convert.ToInt32(fila.Cells["Predicción"].Value);
        _real = fila.Cells["Real"].Value is DBNull or null ? null : Convert.ToInt32(fila.Cells["Real"].Value);

        tarjetaGrafico.Titulo = Convert.ToString(fila.Cells["Asignatura"].Value) ?? "";
        tarjetaGrafico.Subtitulo = "Verde: períodos anteriores · Dorado: predicción · Gris: resultado real";
        lblResumen.Text = "Promedio: " + fila.Cells["Promedio"].Value + " postulantes   ·   Tendencia: " +
                          fila.Cells["Tendencia"].Value + "   ·   Cupos sugeridos: " + fila.Cells["Cupos sugeridos"].Value +
                          "\n" + (_real == null
                              ? "Resultado real: aún no disponible (convocatoria en curso o sin convocatoria)."
                              : "Resultado real: " + _real + " postulantes (diferencia de " + Math.Abs(_real.Value - _prediccion) + ").");

        Ayuda.Intentar(() => _historial = PrediccionDatos.Historial(idAsignatura, Sesion.IdPeriodo));
        panelGrafico.Invalidate();
    }

    // Gráfico de barras: verde = períodos anteriores, dorado = predicción, gris = resultado real
    private void panelGrafico_Paint(object sender, PaintEventArgs e)
    {
        if (_historial.Rows.Count == 0)
            return;

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // Valores y nombres de las barras
        var valores = new List<int>();
        var nombres = new List<string>();
        foreach (DataRow fila in _historial.Rows)
        {
            valores.Add(Convert.ToInt32(fila["Postulantes"]));
            nombres.Add(Convert.ToString(fila["Período"]) ?? "");
        }
        valores.Add(_prediccion);
        nombres.Add("Predicción");
        if (_real != null)
        {
            valores.Add(_real.Value);
            nombres.Add("Real");
        }

        var maximo = Math.Max(1, valores.Max());
        var altoUtil = panelGrafico.Height - 70;   // espacio para números arriba y nombres abajo
        var ancho = panelGrafico.Width / valores.Count;
        var anchoBarra = Math.Min(56, ancho - 24);
        var base_ = panelGrafico.Height - 44;

        using (var linea = new Pen(Tema.Borde))
            g.DrawLine(linea, 0, base_, panelGrafico.Width, base_);

        for (var i = 0; i < valores.Count; i++)
        {
            Color arriba = Tema.Primario, abajo = Tema.Secundario;
            if (nombres[i] == "Predicción") { arriba = Tema.Acento; abajo = Color.FromArgb(202, 138, 4); }
            if (nombres[i] == "Real") { arriba = Color.FromArgb(148, 163, 184); abajo = Color.FromArgb(100, 116, 139); }

            var alto = Math.Max(4, altoUtil * valores[i] / maximo);
            var x = i * ancho + (ancho - anchoBarra) / 2;
            var barra = new Rectangle(x, base_ - alto, anchoBarra, alto);

            using (var ruta = Tema.Redondeado(barra, 8))
            using (var pincel = new LinearGradientBrush(barra, arriba, abajo, 90F))
                g.FillPath(pincel, ruta);

            TextRenderer.DrawText(g, valores[i].ToString(), Tema.Negrita, new Rectangle(x - 10, barra.Y - 24, anchoBarra + 20, 20),
                Tema.Texto, TextFormatFlags.HorizontalCenter);
            TextRenderer.DrawText(g, nombres[i], Tema.Pequena, new Rectangle(i * ancho, base_ + 6, ancho, 34),
                nombres[i] == "Predicción" ? Color.FromArgb(161, 98, 7) : Tema.TextoSuave,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak);
        }
    }

    private void panelGrafico_Resize(object sender, EventArgs e) => panelGrafico.Invalidate();
}
