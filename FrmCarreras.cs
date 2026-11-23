using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Registro de carreras de cada facultad (RF-03).</summary>
public partial class FrmCarreras : Form
{
    private int? _id; // null = registro nuevo

    public FrmCarreras()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmCarreras_Load(object sender, EventArgs e)
    {
        Ayuda.Intentar(() =>
            Ayuda.LlenarCombo(cboFacultad, FacultadDatos.Listar(), "id_facultad", "Facultad"));
        Cargar();
    }

    private void Cargar()
    {
        Ayuda.Intentar(() => tablaDatos.DataSource = CarreraDatos.Listar());
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

        _id = Convert.ToInt32(Ayuda.Celda(tablaDatos, "id_carrera"));
        cboFacultad.SelectedValue = Ayuda.Celda(tablaDatos, "id_facultad");
        campoNombre.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Carrera"));
        chkActiva.Checked = Convert.ToBoolean(Ayuda.Celda(tablaDatos, "Activa"));
        btnEliminar.Enabled = true;
        tarjetaDatos.Subtitulo = "Editando el registro seleccionado";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        var facultad = Ayuda.ValorCombo(cboFacultad);
        if (facultad == null || campoNombre.Text.Trim().Length == 0)
        {
            Ayuda.Advertir("Seleccione la facultad y escriba el nombre de la carrera.");
            return;
        }

        var guardado = Ayuda.Intentar(() =>
        {
            if (_id == null)
                CarreraDatos.Insertar(facultad.Value, campoNombre.Text.Trim(), chkActiva.Checked);
            else
                CarreraDatos.Actualizar(_id.Value, facultad.Value, campoNombre.Text.Trim(), chkActiva.Checked);
        });

        if (guardado)
        {
            Ayuda.Informar("Carrera guardada correctamente.");
            Cargar();
        }
    }

    private void btnNuevo_Click(object sender, EventArgs e) => Limpiar();

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (_id == null || !Ayuda.Confirmar("¿Eliminar la carrera seleccionada?"))
            return;

        if (Ayuda.Intentar(() => CarreraDatos.Eliminar(_id.Value)))
            Cargar();
    }

    private void campoBuscar_TextChanged(object sender, EventArgs e) => Ayuda.Filtrar(tablaDatos, campoBuscar.Text);
}
