using System.Data;
using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Reporte de postulaciones con filtros, exportable a PDF y Word (RF-11).</summary>
public partial class FrmReportes : Form
{
    private DataTable _datos = new DataTable();

    public FrmReportes()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmReportes_Load(object sender, EventArgs e)
    {
        // Coordinadores, docentes y estudiantes solo ven su carrera; el administrador ve todas
        var carreraFija = Sesion.IdRol == Sesion.Administrador ? null : Sesion.IdCarrera;

        Ayuda.Intentar(() =>
        {
            Ayuda.LlenarCombo(cboPeriodo, PeriodoDatos.Listar(), "id_periodo", "Período", "Todos");
            cboPeriodo.SelectedValue = Sesion.IdPeriodo; // por defecto, el período elegido arriba

            var carreras = CarreraDatos.Listar();
            if (carreraFija != null)
                carreras.DefaultView.RowFilter = "id_carrera = " + carreraFija;
            Ayuda.LlenarCombo(cboCarrera, carreras.DefaultView.ToTable(), "id_carrera", "Carrera",
                carreraFija == null ? "Todas" : null);
        });

        // El estudiante solo consulta sus propias postulaciones
        if (Sesion.IdRol == Sesion.Estudiante)
            lblCedula.Visible = campoCedula.Visible = false;

        btnConsultar_Click(btnConsultar, EventArgs.Empty);
    }

    // Al cambiar la carrera se cargan solo sus asignaturas
    private void cboCarrera_SelectedIndexChanged(object sender, EventArgs e)
    {
        var carrera = Ayuda.ValorCombo(cboCarrera);
        Ayuda.Intentar(() => Ayuda.LlenarCombo(cboAsignatura,
            AsignaturaDatos.Listar(carrera), "id_asignatura", "Asignatura", "Todas"));
    }

    private void btnConsultar_Click(object sender, EventArgs e)
    {
        Ayuda.Intentar(() =>
        {
            _datos = ReporteDatos.Postulaciones(Sesion.IdUsuario, Ayuda.ValorCombo(cboPeriodo),
                Ayuda.ValorCombo(cboCarrera), Ayuda.ValorCombo(cboAsignatura), campoCedula.Text.Trim());
            tablaReporte.DataSource = _datos;
            lblTotal.Text = _datos.Rows.Count + " registros";
        });
    }

    private void btnPdf_Click(object sender, EventArgs e) => Exportar("pdf");

    private void btnWord_Click(object sender, EventArgs e) => Exportar("docx");

    private void Exportar(string extension)
    {
        if (_datos.Rows.Count == 0)
        {
            Ayuda.Advertir("No hay datos para exportar. Pulse \"Consultar\" primero.");
            return;
        }

        using var dialogo = new SaveFileDialog
        {
            Title = "Guardar reporte",
            FileName = "reporte_postulaciones_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + "." + extension,
            Filter = extension == "pdf" ? "Documento PDF (*.pdf)|*.pdf" : "Documento de Word (*.docx)|*.docx"
        };

        if (dialogo.ShowDialog() != DialogResult.OK)
            return;

        var filtros = "Período: " + cboPeriodo.Text + " | Carrera: " + cboCarrera.Text + " | Asignatura: " + cboAsignatura.Text +
                      (campoCedula.Text.Trim().Length > 0 ? " | Cédula: " + campoCedula.Text.Trim() : "");

        var generado = Ayuda.Intentar(() =>
        {
            if (extension == "pdf")
                Reportes.GenerarPdf(_datos, filtros, dialogo.FileName);
            else
                Reportes.GenerarWord(_datos, filtros, dialogo.FileName);
        });

        if (generado)
            Ayuda.Informar("Reporte guardado en:\n" + dialogo.FileName);
    }
}
