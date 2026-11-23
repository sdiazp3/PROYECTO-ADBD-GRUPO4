using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Registro de facultades (RF-03).</summary>
public partial class FrmFacultades : Form
{
    private int? _id; // null = registro nuevo

    public FrmFacultades()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmFacultades_Load(object sender, EventArgs e) => Cargar();

    private void Cargar()
    {
        Ayuda.Intentar(() => tablaDatos.DataSource = FacultadDatos.Listar());
        Limpiar();
    }

    private void Limpiar()
    {
        _id = null;
        campoNombre.Clear();
        chkActiva.Checked = true;
        btnEliminar.Enabled = false;
        tarjetaDatos.Subtitulo = "Nuevo registro";
        tablaDatos.ClearSelection();
    }

    private void tablaDatos_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        _id = Convert.ToInt32(Ayuda.Celda(tablaDatos, "id_facultad"));
        campoNombre.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Facultad"));
        chkActiva.Checked = Convert.ToBoolean(Ayuda.Celda(tablaDatos, "Activa"));
        btnEliminar.Enabled = true;
        tarjetaDatos.Subtitulo = "Editando el registro seleccionado";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (campoNombre.Text.Trim().Length == 0)
        {
            Ayuda.Advertir("Escriba el nombre de la facultad.");
            campoNombre.Focus();
            return;
        }

        var guardado = Ayuda.Intentar(() =>
        {
            if (_id == null)
                FacultadDatos.Insertar(campoNombre.Text.Trim(), chkActiva.Checked);
            else
                FacultadDatos.Actualizar(_id.Value, campoNombre.Text.Trim(), chkActiva.Checked);
        });

        if (guardado)
        {
            Ayuda.Informar("Facultad guardada correctamente.");
            Cargar();
        }
    }

    private void btnNuevo_Click(object sender, EventArgs e) => Limpiar();

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (_id == null || !Ayuda.Confirmar("¿Eliminar la facultad seleccionada?"))
            return;

        if (Ayuda.Intentar(() => FacultadDatos.Eliminar(_id.Value)))
            Cargar();
    }

    private void campoBuscar_TextChanged(object sender, EventArgs e) => Ayuda.Filtrar(tablaDatos, campoBuscar.Text);
}
