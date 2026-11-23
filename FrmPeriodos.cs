using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Registro de períodos académicos (RF-03).</summary>
public partial class FrmPeriodos : Form
{
    private int? _id; // null = registro nuevo

    public FrmPeriodos()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmPeriodos_Load(object sender, EventArgs e) => Cargar();

    private void Cargar()
    {
        Ayuda.Intentar(() => tablaDatos.DataSource = PeriodoDatos.Listar());
        Limpiar();
    }

    private void Limpiar()
    {
        _id = null;
        campoNombre.Clear();
        dtpInicio.Value = DateTime.Today;
        dtpFin.Value = DateTime.Today.AddMonths(5);
        chkActivo.Checked = true;
        btnEliminar.Enabled = false;
        tarjetaDatos.Subtitulo = "Nuevo registro";
        tablaDatos.ClearSelection();
    }

    private void tablaDatos_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        _id = Convert.ToInt32(Ayuda.Celda(tablaDatos, "id_periodo"));
        campoNombre.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Período"));
        dtpInicio.Value = Convert.ToDateTime(Ayuda.Celda(tablaDatos, "Inicio"));
        dtpFin.Value = Convert.ToDateTime(Ayuda.Celda(tablaDatos, "Fin"));
        chkActivo.Checked = Convert.ToBoolean(Ayuda.Celda(tablaDatos, "Activo"));
        btnEliminar.Enabled = true;
        tarjetaDatos.Subtitulo = "Editando el registro seleccionado";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (campoNombre.Text.Trim().Length == 0)
        {
            Ayuda.Advertir("Escriba el nombre del período.");
            campoNombre.Focus();
            return;
        }

        if (dtpFin.Value.Date <= dtpInicio.Value.Date)
        {
            Ayuda.Advertir("La fecha de fin debe ser posterior a la fecha de inicio.");
            return;
        }

        var guardado = Ayuda.Intentar(() =>
        {
            if (_id == null)
                PeriodoDatos.Insertar(campoNombre.Text.Trim(), dtpInicio.Value.Date, dtpFin.Value.Date,
                    chkActivo.Checked);
            else
                PeriodoDatos.Actualizar(_id.Value, campoNombre.Text.Trim(), dtpInicio.Value.Date,
                    dtpFin.Value.Date, chkActivo.Checked);
        });

        if (guardado)
        {
            Ayuda.Informar("Período guardado correctamente.");
            Cargar();
        }
    }

    private void btnNuevo_Click(object sender, EventArgs e) => Limpiar();

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (_id == null || !Ayuda.Confirmar("¿Eliminar el período seleccionado?"))
            return;

        if (Ayuda.Intentar(() => PeriodoDatos.Eliminar(_id.Value)))
            Cargar();
    }

    private void campoBuscar_TextChanged(object sender, EventArgs e) => Ayuda.Filtrar(tablaDatos, campoBuscar.Text);
}
