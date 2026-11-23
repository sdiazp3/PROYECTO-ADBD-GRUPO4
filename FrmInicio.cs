using System.Data;
using System.Drawing.Drawing2D;
using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Tablero de inicio: saludo, indicadores, gráfico por estado y convocatorias abiertas.</summary>
public partial class FrmInicio : Form
{
    private DataTable _porEstado = new DataTable();

    public FrmInicio()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmInicio_Load(object sender, EventArgs e)
    {
        picBanner.Image = Tema.Imagen("banner.png");
        lblSaludo.Text = "¡Hola, " + Sesion.Nombres + "!";
        lblMensaje.Text = Sesion.IdRol switch
        {
            Sesion.Administrador => "Administre usuarios, facultades, carreras, asignaturas y períodos para que cada carrera pueda abrir sus convocatorias.",
            Sesion.Coordinador => "Publique convocatorias de " + Sesion.Carrera + " y evalúe a los estudiantes que se postulan.",
            Sesion.Docente => "Consulte las postulaciones y los ayudantes seleccionados de " + Sesion.Carrera + ".",
            _ => "Revise las convocatorias abiertas de su carrera y el estado de sus postulaciones."
        };

        Ayuda.Intentar(() =>
        {
            var resumen = ReporteDatos.ResumenInicio(Sesion.IdUsuario, Sesion.IdPeriodo);
            lblValor1.Text = resumen["convocatorias"].ToString();
            lblValor2.Text = resumen["postulaciones"].ToString();
            lblValor3.Text = resumen["por_evaluar"].ToString();
            lblValor4.Text = resumen["seleccionados"].ToString();

            _porEstado = ReporteDatos.PostulacionesPorEstado(Sesion.IdUsuario, Sesion.IdPeriodo);

            // El estudiante ve sus postulaciones del período; los demás, las convocatorias del período
            if (Sesion.IdRol == Sesion.Estudiante)
            {
                tarjetaConvocatorias.Titulo = "Mis postulaciones del período";
                var mias = PostulacionDatos.MisPostulaciones(Sesion.IdUsuario, Sesion.IdPeriodo);
                tablaConvocatorias.DataSource = mias.DefaultView.ToTable(false, "Asignatura", "Estado");
            }
            else
            {
                var carrera = Sesion.IdRol == Sesion.Administrador ? null : Sesion.IdCarrera;
                var convocatorias = ConvocatoriaDatos.Listar(carrera, Sesion.IdPeriodo);
                tablaConvocatorias.DataSource = convocatorias.DefaultView.ToTable(false, "Asignatura", "Postulantes", "Estado");
            }

            tarjetaGrafico.Subtitulo = "Período " + Sesion.Periodo;
        });

        if (Sesion.IdRol == Sesion.Estudiante)
            lblIndicador2.Text = "Mis postulaciones";

        panelGrafico.Invalidate();
    }

    // Gráfico de barras horizontales dibujado con GDI+ (sin librerías de gráficos)
    private void panelGrafico_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        if (_porEstado.Rows.Count == 0)
            return;

        var maximo = Math.Max(1, _porEstado.Rows.Cast<DataRow>().Max(f => Convert.ToInt32(f["total"])));
        var anchoEtiqueta = 140;
        var anchoBarras = panelGrafico.Width - anchoEtiqueta - 60;
        var altoFila = Math.Min(48, (panelGrafico.Height - 10) / _porEstado.Rows.Count);
        var y = 6;

        foreach (DataRow fila in _porEstado.Rows)
        {
            var estado = Convert.ToString(fila["estado"]) ?? "";
            var total = Convert.ToInt32(fila["total"]);
            var color = Tema.ColorEstado(estado).Texto;

            TextRenderer.DrawText(g, estado, Tema.Normal, new Rectangle(0, y, anchoEtiqueta, altoFila - 12), Tema.Texto,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            var fondo = new Rectangle(anchoEtiqueta, y + 6, Math.Max(20, anchoBarras), altoFila - 24);
            using (var ruta = Tema.Redondeado(fondo, fondo.Height / 2))
            using (var pincel = new SolidBrush(Color.FromArgb(241, 245, 249)))
                g.FillPath(pincel, ruta);

            if (total > 0)
            {
                var barra = new Rectangle(fondo.X, fondo.Y, Math.Max(fondo.Height, fondo.Width * total / maximo), fondo.Height);
                using (var ruta = Tema.Redondeado(barra, barra.Height / 2))
                using (var pincel = new LinearGradientBrush(barra, Color.FromArgb(170, color), color, 0F))
                    g.FillPath(pincel, ruta);
            }

            TextRenderer.DrawText(g, total.ToString(), Tema.Negrita, new Rectangle(fondo.Right + 8, y, 50, altoFila - 12),
                Tema.Texto, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            y += altoFila;
        }
    }

    private void panelGrafico_Resize(object sender, EventArgs e) => panelGrafico.Invalidate();
}
