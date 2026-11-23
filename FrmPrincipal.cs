using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;
using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>
/// Ventana principal: menú lateral según el rol, cabecera con el título del módulo
/// y un panel donde se abre cada formulario.
/// </summary>
public partial class FrmPrincipal : Form
{
    /// <summary>True si el usuario pulsó "Cerrar sesión" (vuelve al inicio de sesión).</summary>
    public bool CerrarSesion { get; private set; }

    private MenuBoton _opcionActual = null!; // módulo abierto, para recargarlo al cambiar de período
    private DataTable _periodos = new DataTable();
    private bool _encimaPeriodo;

    public FrmPrincipal()
    {
        InitializeComponent();
    }

    private void FrmPrincipal_Load(object sender, EventArgs e)
    {
        picLogo.Image = Tema.Imagen("escudo.png");
        lblUsuario.Text = Sesion.NombreCompleto;
        lblRol.Text = Sesion.Carrera.Length > 0 ? Sesion.Rol + " · " + Sesion.Carrera : Sesion.Rol;
        lblFecha.Text = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es-EC"));

        // Cada rol ve solo sus opciones
        var rol = Sesion.IdRol;
        menuUsuarios.Visible = menuFacultades.Visible = menuCarreras.Visible =
            menuAsignaturas.Visible = menuPeriodos.Visible = rol == Sesion.Administrador;
        menuConvocatorias.Visible = menuEvaluacion.Visible = rol == Sesion.Coordinador;
        menuPostulacion.Visible = rol == Sesion.Estudiante;
        menuPredicciones.Visible = rol == Sesion.Administrador || rol == Sesion.Coordinador;

        Ayuda.Intentar(CargarPeriodos);
        menuInicio_Click(menuInicio, EventArgs.Empty);
    }

    // ================= Período académico =================

    // Carga todos los períodos y elige el que está en curso
    private void CargarPeriodos()
    {
        _periodos = PeriodoDatos.Listar();

        var actual = _periodos.Select("Estado = 'Actual'");
        ElegirPeriodo(actual.Length > 0 ? actual[0] : _periodos.Rows[0]);
    }

    private void ElegirPeriodo(DataRow periodo)
    {
        var finalizado = Convert.ToString(periodo["Estado"]) == "Finalizado";
        Sesion.ElegirPeriodo(Convert.ToInt32(periodo["id_periodo"]), Convert.ToString(periodo["Período"]) ?? "", finalizado);
        lblSoloConsulta.Visible = finalizado;
        panelPeriodo.Invalidate();
    }

    // Abre la ventana para elegir el período, justo debajo del botón
    private void panelPeriodo_Click(object sender, EventArgs e)
    {
        var selector = new FrmSelectorPeriodo(_periodos, Sesion.IdPeriodo);
        var posicion = panelPeriodo.PointToScreen(new Point(panelPeriodo.Width - selector.Width, panelPeriodo.Height + 6));
        selector.Location = posicion;

        selector.FormClosed += (s, a) =>
        {
            if (selector.IdElegido == null || selector.IdElegido == Sesion.IdPeriodo)
                return;

            ElegirPeriodo(_periodos.Select("id_periodo = " + selector.IdElegido)[0]);
            InvokeOnClick(_opcionActual, EventArgs.Empty); // recarga el módulo con el nuevo período
        };
        selector.Show(this);
    }

    private void panelPeriodo_MouseEnter(object sender, EventArgs e) { _encimaPeriodo = true; panelPeriodo.Invalidate(); }

    private void panelPeriodo_MouseLeave(object sender, EventArgs e) { _encimaPeriodo = false; panelPeriodo.Invalidate(); }

    // Botón tipo píldora: ícono, "Período académico", nombre del período, estado y flecha
    private void panelPeriodo_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        var area = new Rectangle(1, 1, panelPeriodo.Width - 3, panelPeriodo.Height - 3);

        using (var ruta = Tema.Redondeado(area, area.Height / 2))
        using (var fondo = new SolidBrush(_encimaPeriodo ? Tema.PrimarioSuave : Color.White))
        using (var borde = new Pen(_encimaPeriodo ? Tema.Primario : Tema.Borde))
        {
            g.FillPath(fondo, ruta);
            g.DrawPath(borde, ruta);
        }

        var circulo = new Rectangle(8, 7, 38, 38);
        using (var pincel = new LinearGradientBrush(circulo, Tema.Primario, Tema.Secundario, 45F))
            g.FillEllipse(pincel, circulo);
        TextRenderer.DrawText(g, "\uE787", Tema.FuenteIcono, circulo, Tema.Acento,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        TextRenderer.DrawText(g, "PERÍODO ACADÉMICO", new Font("Segoe UI Semibold", 7.5F), new Point(54, 8), Tema.Primario);
        TextRenderer.DrawText(g, Sesion.Periodo, new Font("Segoe UI Semibold", 11F), new Point(53, 23), Tema.Texto);

        // Punto de estado: verde = en curso, gris = finalizado
        var anchoNombre = TextRenderer.MeasureText(Sesion.Periodo, new Font("Segoe UI Semibold", 11F)).Width;
        using (var punto = new SolidBrush(Sesion.PeriodoFinalizado ? Color.FromArgb(148, 163, 184) : Tema.Exito))
            g.FillEllipse(punto, 53 + anchoNombre + 4, 31, 8, 8);

        TextRenderer.DrawText(g, "\uE70D", new Font("Segoe MDL2 Assets", 9F), new Rectangle(panelPeriodo.Width - 36, 0, 24, panelPeriodo.Height),
            Tema.TextoSuave, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    /// <summary>Muestra un formulario dentro del panel de contenido.</summary>
    private void AbrirModulo(MenuBoton opcion, Form modulo, string titulo, string descripcion)
    {
        _opcionActual = opcion;
        foreach (Control control in panelOpciones.Controls)
            if (control is MenuBoton boton)
                boton.Activo = boton == opcion;

        lblTitulo.Text = titulo;
        lblDescripcion.Text = descripcion;

        // Se cierra el módulo anterior para liberar memoria
        while (panelContenido.Controls.Count > 0)
            panelContenido.Controls[0].Dispose();

        modulo.TopLevel = false;
        modulo.FormBorderStyle = FormBorderStyle.None;
        modulo.Dock = DockStyle.Fill;
        panelContenido.Controls.Add(modulo);
        modulo.Show();
    }

    private void menuInicio_Click(object sender, EventArgs e) =>
        AbrirModulo(menuInicio, new FrmInicio(), "Inicio", "Resumen general del proceso de ayudantías");

    private void menuUsuarios_Click(object sender, EventArgs e) =>
        AbrirModulo(menuUsuarios, new FrmUsuarios(), "Usuarios", "Registre usuarios y asígneles un rol (RF-01)");

    private void menuFacultades_Click(object sender, EventArgs e) =>
        AbrirModulo(menuFacultades, new FrmFacultades(), "Facultades", "Facultades de la institución (RF-03)");

    private void menuCarreras_Click(object sender, EventArgs e) =>
        AbrirModulo(menuCarreras, new FrmCarreras(), "Carreras", "Carreras de cada facultad (RF-03)");

    private void menuAsignaturas_Click(object sender, EventArgs e) =>
        AbrirModulo(menuAsignaturas, new FrmAsignaturas(), "Asignaturas", "Asignaturas de cada carrera (RF-03)");

    private void menuPeriodos_Click(object sender, EventArgs e) =>
        AbrirModulo(menuPeriodos, new FrmPeriodos(), "Períodos académicos", "Períodos en los que se abren convocatorias (RF-03)");

    private void menuConvocatorias_Click(object sender, EventArgs e) =>
        AbrirModulo(menuConvocatorias, new FrmConvocatorias(), "Convocatorias", "Publique convocatorias de ayudantía (RF-04)");

    private void menuPostulacion_Click(object sender, EventArgs e) =>
        AbrirModulo(menuPostulacion, new FrmPostulacion(), "Postularme", "Postule a una ayudantía de su carrera (RF-05)");

    private void menuEvaluacion_Click(object sender, EventArgs e) =>
        AbrirModulo(menuEvaluacion, new FrmEvaluacion(), "Evaluar postulantes", "Califique y seleccione a los ayudantes (RF-06)");

    private void menuReportes_Click(object sender, EventArgs e) =>
        AbrirModulo(menuReportes, new FrmReportes(), "Reportes", "Genere reportes en PDF y Word (RF-11)");

    private void menuClave_Click(object sender, EventArgs e) =>
        AbrirModulo(menuClave, new FrmCambiarClave(), "Mi contraseña", "Cambie su contraseña de acceso al sistema");

    private void menuPredicciones_Click(object sender, EventArgs e) =>
        AbrirModulo(menuPredicciones, new FrmPredicciones(), "Predicciones", "Postulantes esperados en el período elegido según los períodos anteriores");

    private void menuSalir_Click(object sender, EventArgs e)
    {
        if (!Ayuda.Confirmar("¿Desea cerrar sesión?"))
            return;

        CerrarSesion = true;
        Close();
    }

    // Círculo con las iniciales del usuario (avatar)
    private void panelUsuario_Paint(object sender, PaintEventArgs e)
    {
        var iniciales = (Sesion.Nombres.Length > 0 ? Sesion.Nombres.Substring(0, 1) : "") +
                        (Sesion.Apellidos.Length > 0 ? Sesion.Apellidos.Substring(0, 1) : "");
        var circulo = new Rectangle(8, 8, 42, 42);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using (var pincel = new LinearGradientBrush(circulo, Tema.Acento, Tema.Secundario, 45F))
            e.Graphics.FillEllipse(pincel, circulo);
        TextRenderer.DrawText(e.Graphics, iniciales.ToUpper(), Tema.Negrita, circulo, Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private void lblDescripcion_Click(object sender, EventArgs e)
    {

    }
}
