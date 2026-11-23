using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>Gestión de usuarios y roles (RF-01).</summary>
public partial class FrmUsuarios : Form
{
    private int? _id; // null = registro nuevo

    public FrmUsuarios()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmUsuarios_Load(object sender, EventArgs e)
    {
        Ayuda.Intentar(() =>
        {
            Ayuda.LlenarCombo(cboRol, UsuarioDatos.ListarRoles(), "id_rol", "nombre");
            Ayuda.LlenarCombo(cboCarrera, CarreraDatos.Listar(), "id_carrera", "Carrera",
                "(Sin carrera)");
        });
        Cargar();
    }

    private void Cargar()
    {
        Ayuda.Intentar(() => tablaDatos.DataSource = UsuarioDatos.Listar());
        Limpiar();
    }

    private void Limpiar()
    {
        _id = null;
        campoCedula.Clear();
        campoNombres.Clear();
        campoApellidos.Clear();
        campoCorreo.Clear();
        campoClave.Clear();
        cboRol.SelectedValue = Sesion.Estudiante;
        btnEliminar.Enabled = btnEstado.Enabled = false;
        campoClave.Enabled = true;
        tarjetaDatos.Subtitulo = "Nuevo registro";
        tablaDatos.ClearSelection();
    }

    private void tablaDatos_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        _id = Convert.ToInt32(Ayuda.Celda(tablaDatos, "id_usuario"));
        campoCedula.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Cédula"));
        campoNombres.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Nombres"));
        campoApellidos.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Apellidos"));
        campoCorreo.Text = Convert.ToString(Ayuda.Celda(tablaDatos, "Correo"));
        cboRol.SelectedValue = Ayuda.Celda(tablaDatos, "id_rol");
        cboCarrera.SelectedValue = Ayuda.Celda(tablaDatos, "id_carrera") ?? DBNull.Value;
        // La contraseña solo se escribe al crear el usuario; después cada usuario la cambia desde "Mi contraseña"
        campoClave.Clear();
        campoClave.Enabled = false;
        btnEliminar.Enabled = btnEstado.Enabled = true;
        tarjetaDatos.Subtitulo = "Editando el registro seleccionado";
    }

    // El administrador no pertenece a ninguna carrera
    private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
    {
        var esAdministrador = Ayuda.ValorCombo(cboRol) == Sesion.Administrador;
        cboCarrera.Enabled = !esAdministrador;
        if (esAdministrador && cboCarrera.Items.Count > 0)
            cboCarrera.SelectedIndex = 0;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        var rol = Ayuda.ValorCombo(cboRol);
        var carrera = Ayuda.ValorCombo(cboCarrera);

        // Validación de formato en pantalla; las reglas completas las aplica la base de datos
        if (campoCedula.Text.Length != 10 || !campoCedula.Text.All(char.IsDigit))
        {
            Ayuda.Advertir("La cédula debe tener 10 dígitos.");
            return;
        }
        if (campoNombres.Text.Trim().Length == 0 || campoApellidos.Text.Trim().Length == 0 || campoCorreo.Text.Trim().Length == 0)
        {
            Ayuda.Advertir("Complete nombres, apellidos y correo.");
            return;
        }
        if (rol == null)
        {
            Ayuda.Advertir("Seleccione el rol.");
            return;
        }
        if (_id == null && campoClave.Text.Length < 8)
        {
            Ayuda.Advertir("Escriba una contraseña de al menos 8 caracteres para el nuevo usuario.");
            return;
        }

        var guardado = Ayuda.Intentar(() =>
        {
            if (_id == null)
                UsuarioDatos.Insertar(campoCedula.Text, campoNombres.Text.Trim(), campoApellidos.Text.Trim(),
                    campoCorreo.Text.Trim(), campoClave.Text, rol.Value, carrera);
            else
                UsuarioDatos.Actualizar(_id.Value, campoCedula.Text, campoNombres.Text.Trim(),
                    campoApellidos.Text.Trim(), campoCorreo.Text.Trim(), rol.Value, carrera);
        });

        if (guardado)
        {
            Ayuda.Informar("Usuario guardado correctamente.");
            Cargar();
        }
    }

    private void btnNuevo_Click(object sender, EventArgs e) => Limpiar();

    private void btnEstado_Click(object sender, EventArgs e)
    {
        if (_id == null)
            return;

        var activo = Convert.ToBoolean(Ayuda.Celda(tablaDatos, "Activo"));
        if (_id == Sesion.IdUsuario && activo)
        {
            Ayuda.Advertir("No puede desactivar su propia cuenta.");
            return;
        }

        if (Ayuda.Intentar(() => UsuarioDatos.CambiarEstado(_id.Value, !activo)))
        {
            Ayuda.Informar(activo ? "Usuario desactivado." : "Usuario activado.");
            Cargar();
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (_id == null || !Ayuda.Confirmar("¿Eliminar el usuario seleccionado?"))
            return;

        if (_id == Sesion.IdUsuario)
        {
            Ayuda.Advertir("No puede eliminar su propia cuenta.");
            return;
        }

        if (Ayuda.Intentar(() => UsuarioDatos.Eliminar(_id.Value)))
            Cargar();
    }

    private void campoBuscar_TextChanged(object sender, EventArgs e) => Ayuda.Filtrar(tablaDatos, campoBuscar.Text);
}
