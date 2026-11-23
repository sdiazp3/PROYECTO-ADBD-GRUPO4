using System.Data;
using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>El coordinador publica las convocatorias de ayudantía de su carrera (RF-04).</summary>
public partial class FrmConvocatorias : Form
{
    private int? _id; // null = registro nuevo

    public FrmConvocatorias()
    {
        InitializeComponent();
        Tema.Aplicar(this);

        // Todas las convocatorias son de la carrera del coordinador: no hace falta mostrarla
        tablaDatos.DataBindingComplete += (s, e) => tablaDatos.Columns["Carrera"].Visible = false;
    }

    private void FrmConvocatorias_Load(object sender, EventArgs e)
    {
        Ayuda.Intentar(() =>
        {
            // Solo asignaturas activas de la carrera del coordinador y períodos activos
            var asignaturas = AsignaturaDatos.Listar(Sesion.IdCarrera);
            asignaturas.DefaultView.RowFilter = "Activa = true";
            var lista = asignaturas.DefaultView.ToTable();
            lista.Columns.Add("Texto", typeof(string), "[Código] + ' - ' + Asignatura");
            Ayuda.LlenarCombo(cboAsignatura, lista, "id_asignatura", "Texto");

            // El período es el elegido en la parte superior de la ventana
            Ayuda.LlenarCombo(cboPeriodo, PeriodoDatos.Listar(), "id_periodo", "Período");
            cboPeriodo.Enabled = false;
        });

        // Un período finalizado solo se consulta
        btnGuardar.Enabled = btnNuevo.Enabled = !Sesion.PeriodoFinalizado;
        Cargar();
    }

    private void Cargar()
    {
        Ayuda.Intentar(() => tablaDatos.DataSource = ConvocatoriaDatos.Listar(Sesion.IdCarrera, Sesion.IdPeriodo));
        Limpiar();
    }

    private void Limpiar()
    {
        _id = null;
        numCupos.Value = 1;
        numHoras.Value = 64;
        dtpDesde.Value = DateTime.Today;
        dtpHasta.Value = DateTime.Today.AddDays(15);
        campoRequisitos.Clear();
        cboPeriodo.SelectedValue = Sesion.IdPeriodo;
        btnEliminar.Enabled = false;
        tarjetaDatos.Subtitulo = Sesion.PeriodoFinalizado ? "Período finalizado: solo consulta" : "Nuevo registro";
        tablaDatos.ClearSelection();
    }

    private void tablaDatos_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        _id = Convert.ToInt32(Ayuda.Celda(tablaDatos, "id_convocatoria"));
        cboAsignatura.SelectedValue = Ayuda.Celda(tablaDatos, "id_asignatura");
        cboPeriodo.SelectedValue = Ayuda.Celda(tablaDatos, "id_periodo");
        numCupos.Value = Convert.ToInt32(Ayuda.Celda(tablaDatos, "Cupos"));
        numHoras.Value = Convert.ToInt32(Ayuda.Celda(tablaDatos, "Horas"));
        dtpDesde.Value = Convert.ToDateTime(Ayuda.Celda(tablaDatos, "Desde"));
        dtpHasta.Value = Convert.ToDateTime(Ayuda.Celda(tablaDatos, "Hasta"));
        campoRequisitos.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Requisitos"));
        btnEliminar.Enabled = !Sesion.PeriodoFinalizado;
        tarjetaDatos.Subtitulo = Sesion.PeriodoFinalizado ? "Período finalizado: solo consulta" : "Editando el registro seleccionado";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        var asignatura = Ayuda.ValorCombo(cboAsignatura);
        var periodo = Ayuda.ValorCombo(cboPeriodo);

        if (asignatura == null || periodo == null)
        {
            Ayuda.Advertir("Seleccione la asignatura y el período.");
            return;
        }
        if (campoRequisitos.Text.Trim().Length == 0)
        {
            Ayuda.Advertir("Escriba los requisitos de la convocatoria.");
            return;
        }
        if (dtpHasta.Value.Date < dtpDesde.Value.Date)
        {
            Ayuda.Advertir("La fecha \"hasta\" no puede ser anterior a la fecha \"desde\".");
            return;
        }

        var cupos = Convert.ToInt32(numCupos.Value);
        var horas = Convert.ToInt32(numHoras.Value);
        var guardado = Ayuda.Intentar(() =>
        {
            if (_id == null)
                ConvocatoriaDatos.Insertar(asignatura.Value, periodo.Value, Sesion.IdUsuario, cupos, horas,
                    campoRequisitos.Text.Trim(), dtpDesde.Value.Date, dtpHasta.Value.Date);
            else
                ConvocatoriaDatos.Actualizar(_id.Value, asignatura.Value, periodo.Value, Sesion.IdUsuario, cupos, horas,
                    campoRequisitos.Text.Trim(), dtpDesde.Value.Date, dtpHasta.Value.Date);
        });

        if (guardado)
        {
            Ayuda.Informar("Convocatoria guardada correctamente.");
            Cargar();
        }
    }

    private void btnNuevo_Click(object sender, EventArgs e) => Limpiar();

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (_id == null || !Ayuda.Confirmar("¿Eliminar la convocatoria seleccionada?"))
            return;

        if (Ayuda.Intentar(() => ConvocatoriaDatos.Eliminar(_id.Value)))
            Cargar();
    }

    private void campoBuscar_TextChanged(object sender, EventArgs e) => Ayuda.Filtrar(tablaDatos, campoBuscar.Text);
}
