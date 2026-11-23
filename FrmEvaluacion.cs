using System.Data;
using System.Diagnostics;
using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>El coordinador califica a los postulantes y elige a los ayudantes (RF-06).</summary>
public partial class FrmEvaluacion : Form
{
    private int? _idPostulacion;
    private DataTable _convocatorias = new DataTable();

    public FrmEvaluacion()
    {
        InitializeComponent();
        Tema.Aplicar(this);

        // El nombre del documento se muestra en el panel derecho
        tablaPostulantes.DataBindingComplete += (s, e) => tablaPostulantes.Columns["Documento"].Visible = false;
    }

    private void FrmEvaluacion_Load(object sender, EventArgs e)
    {
        cboResultado.Items.AddRange(new object[] { "Seleccionado", "En espera", "No seleccionado" });

        Ayuda.Intentar(() =>
        {
            _convocatorias = ConvocatoriaDatos.Listar(Sesion.IdCarrera, Sesion.IdPeriodo);
            _convocatorias.Columns.Add("Texto", typeof(string), "Asignatura + '  (' + [Período] + ')'");
            Ayuda.LlenarCombo(cboConvocatoria, _convocatorias, "id_convocatoria", "Texto");

            // Se muestra primero una convocatoria que ya tenga postulantes
            var conPostulantes = _convocatorias.Select("Postulantes > 0");
            if (conPostulantes.Length > 0)
                cboConvocatoria.SelectedValue = conPostulantes[0]["id_convocatoria"];
        });
    }

    private void cboConvocatoria_SelectedIndexChanged(object sender, EventArgs e) => CargarPostulantes();

    private void CargarPostulantes()
    {
        var convocatoria = Ayuda.ValorCombo(cboConvocatoria);
        if (convocatoria == null)
            return;

        Ayuda.Intentar(() =>
        {
            var postulantes = PostulacionDatos.Postulantes(convocatoria.Value);
            tablaPostulantes.DataSource = postulantes;

            var cupos = _convocatorias.Select("id_convocatoria = " + convocatoria)[0]["Cupos"];
            var seleccionados = postulantes.Select("Estado = 'Seleccionado'").Length;
            lblCupos.Text = "Cupos: " + cupos + "    ·    Seleccionados: " + seleccionados + "    ·    Postulantes: " + postulantes.Rows.Count;
        });

        Limpiar();
    }

    private void Limpiar()
    {
        _idPostulacion = null;
        lblEstudiante.Text = "—";
        lblDocumento.Text = "";
        numPuntaje.Value = 0;
        cboResultado.SelectedIndex = -1;
        campoObservacion.Clear();
        btnGuardar.Enabled = btnDocumento.Enabled = false;
        tablaPostulantes.ClearSelection();
        tarjetaEvaluar.Subtitulo = Sesion.PeriodoFinalizado
            ? "Período finalizado: solo consulta"
            : "Seleccione un postulante de la lista";
    }

    private void tablaPostulantes_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        _idPostulacion = Convert.ToInt32(Ayuda.Celda(tablaPostulantes, "id_postulacion"));
        lblEstudiante.Text = Convert.ToString(Ayuda.Celda(tablaPostulantes, "Estudiante"));
        lblDocumento.Text = "Documento: " + Ayuda.Celda(tablaPostulantes, "Documento");
        numPuntaje.Value = Convert.ToDecimal(Ayuda.Celda(tablaPostulantes, "Puntaje") ?? 0m);
        var estado = Convert.ToString(Ayuda.Celda(tablaPostulantes, "Estado"));
        cboResultado.SelectedItem = estado == "Pendiente" ? null : estado;
        campoObservacion.Text = Convert.ToString(Ayuda.Celda(tablaPostulantes, "Observación"));
        btnDocumento.Enabled = true;
        btnGuardar.Enabled = !Sesion.PeriodoFinalizado; // un período finalizado solo se consulta
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (_idPostulacion == null)
            return;

        if (cboResultado.SelectedItem == null)
        {
            Ayuda.Advertir("Seleccione el resultado de la evaluación.");
            return;
        }

        var guardado = Ayuda.Intentar(() => PostulacionDatos.Evaluar(_idPostulacion.Value,
            numPuntaje.Value, cboResultado.SelectedItem.ToString(), campoObservacion.Text.Trim()));

        if (guardado)
        {
            Ayuda.Informar("Evaluación guardada.");
            CargarPostulantes();
        }
    }

    // Guarda el PDF en la carpeta temporal y lo abre con el visor predeterminado
    private void btnDocumento_Click(object sender, EventArgs e)
    {
        if (_idPostulacion == null)
            return;

        Ayuda.Intentar(() =>
        {
            var documento = PostulacionDatos.Documento(_idPostulacion.Value);
            var ruta = Path.Combine(Path.GetTempPath(), "postulacion_" + _idPostulacion + ".pdf");
            File.WriteAllBytes(ruta, documento);
            Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
        });
    }
}
