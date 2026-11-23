using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Registro de asignaturas de cada carrera (RF-03).</summary>
public partial class FrmAsignaturas : Form
{
    private int? _id; // null = registro nuevo

    public FrmAsignaturas()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmAsignaturas_Load(object sender, EventArgs e)
    {
        Ayuda.Intentar(() =>
            Ayuda.LlenarCombo(cboCarrera, CarreraDatos.Listar(), "id_carrera", "Carrera"));
        Cargar();
    }

    private void Cargar()
    {
        Ayuda.Intentar(() => tablaDatos.DataSource = AsignaturaDatos.Listar());
        Limpiar();
    }

    private void Limpiar()
    {
        _id = null;
        campoCodigo.Clear();
        campoNombre.Clear();
        numNivel.Value = 1;
        chkActiva.Checked = true;
        btnEliminar.Enabled = false;
        tarjetaDatos.Subtitulo = "Nuevo registro";
        tablaDatos.ClearSelection();
    }

    private void tablaDatos_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        _id = Convert.ToInt32(Ayuda.Celda(tablaDatos, "id_asignatura"));
        cboCarrera.SelectedValue = Ayuda.Celda(tablaDatos, "id_carrera");
        campoCodigo.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Código"));
        campoNombre.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Asignatura"));
        numNivel.Value = Convert.ToInt32(Ayuda.Celda(tablaDatos, "Nivel"));
        chkActiva.Checked = Convert.ToBoolean(Ayuda.Celda(tablaDatos, "Activa"));
        btnEliminar.Enabled = true;
        tarjetaDatos.Subtitulo = "Editando el registro seleccionado";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        var carrera = Ayuda.ValorCombo(cboCarrera);
        if (carrera == null || campoCodigo.Text.Trim().Length == 0 || campoNombre.Text.Trim().Length == 0)
        {
            Ayuda.Advertir("Complete la carrera, el código y el nombre de la asignatura.");
            return;
        }

        var nivel = Convert.ToInt32(numNivel.Value);
        var guardado = Ayuda.Intentar(() =>
        {
            if (_id == null)
                AsignaturaDatos.Insertar(carrera.Value, campoCodigo.Text.Trim(), campoNombre.Text.Trim(),
                    nivel, chkActiva.Checked);
            else
                AsignaturaDatos.Actualizar(_id.Value, carrera.Value, campoCodigo.Text.Trim(), campoNombre.Text.Trim(),
                    nivel, chkActiva.Checked);
        });

        if (guardado)
        {
            Ayuda.Informar("Asignatura guardada correctamente.");
            Cargar();
        }
    }

    private void btnNuevo_Click(object sender, EventArgs e) => Limpiar();

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (_id == null || !Ayuda.Confirmar("¿Eliminar la asignatura seleccionada?"))
            return;

        if (Ayuda.Intentar(() => AsignaturaDatos.Eliminar(_id.Value)))
            Cargar();
    }

    private void campoBuscar_TextChanged(object sender, EventArgs e) => Ayuda.Filtrar(tablaDatos, campoBuscar.Text);
}
