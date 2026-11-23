using SistemaAyudantias.Datos;
using SistemaAyudantias.Diseno;
using SistemaAyudantias.Utilidades;

namespace SistemaAyudantias.Formularios;

/// <summary>El estudiante se postula a una convocatoria abierta de su carrera (RF-05).</summary>
public partial class FrmPostulacion : Form
{
    private const int TamanoMaximo = 5 * 1024 * 1024; // 5 MB

    private int? _idConvocatoria;
    private string _rutaDocumento = "";

    public FrmPostulacion()
    {
        InitializeComponent();
        Tema.Aplicar(this);
    }

    private void FrmPostulacion_Load(object sender, EventArgs e) => Cargar();

    private void Cargar()
    {
        Ayuda.Intentar(() =>
        {
            // En un período finalizado ya no hay convocatorias abiertas: solo se consultan las postulaciones
            if (Sesion.PeriodoFinalizado)
            {
                tablaAbiertas.DataSource = null;
                tarjetaAbiertas.Subtitulo = "Período " + Sesion.Periodo + " finalizado: no hay convocatorias abiertas";
                btnAdjuntar.Enabled = btnRetirar.Enabled = false;
            }
            else
            {
                tablaAbiertas.DataSource = ConvocatoriaDatos.ListarAbiertas(Sesion.IdUsuario);
            }

            tablaMias.DataSource = PostulacionDatos.MisPostulaciones(Sesion.IdUsuario, Sesion.IdPeriodo);
            tarjetaMias.Subtitulo = "Período " + Sesion.Periodo;
        });

        _idConvocatoria = null;
        _rutaDocumento = "";
        lblAsignatura.Text = "Seleccione una convocatoria";
        campoRequisitos.Clear();
        campoArchivo.Clear();
        btnPostular.Enabled = false;
        tablaAbiertas.ClearSelection();
        tablaMias.ClearSelection();
    }

    private void tablaAbiertas_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        _idConvocatoria = Convert.ToInt32(Ayuda.Celda(tablaAbiertas, "id_convocatoria"));
        lblAsignatura.Text = Convert.ToString(Ayuda.Celda(tablaAbiertas, "Asignatura"));
        campoRequisitos.Text = Convert.ToString(Ayuda.Celda(tablaAbiertas, "Requisitos"));

        var yaPostulado = Convert.ToString(Ayuda.Celda(tablaAbiertas, "Postulado")) == "Sí";
        btnPostular.Enabled = !yaPostulado;
        tarjetaPostular.Subtitulo = yaPostulado
            ? "Ya se postuló a esta convocatoria"
            : "Adjunte su hoja de vida en PDF (máx. 5 MB)";
    }

    private void btnAdjuntar_Click(object sender, EventArgs e)
    {
        using var dialogo = new OpenFileDialog
        {
            Title = "Seleccione su documento",
            Filter = "Documentos PDF (*.pdf)|*.pdf"
        };

        if (dialogo.ShowDialog() != DialogResult.OK)
            return;

        if (new FileInfo(dialogo.FileName).Length > TamanoMaximo)
        {
            Ayuda.Advertir("El documento no puede superar 5 MB.");
            return;
        }

        _rutaDocumento = dialogo.FileName;
        campoArchivo.Text = Path.GetFileName(_rutaDocumento);
    }

    private void btnPostular_Click(object sender, EventArgs e)
    {
        if (_idConvocatoria == null)
        {
            Ayuda.Advertir("Seleccione una convocatoria.");
            return;
        }
        if (_rutaDocumento.Length == 0)
        {
            Ayuda.Advertir("Adjunte su documento en formato PDF.");
            return;
        }

        var enviado = Ayuda.Intentar(() =>
        {
            var documento = File.ReadAllBytes(_rutaDocumento);
            PostulacionDatos.Postular(_idConvocatoria.Value, Sesion.IdUsuario, Path.GetFileName(_rutaDocumento), documento);
        });

        if (enviado)
        {
            Ayuda.Informar("Su postulación fue enviada. Puede ver su estado en \"Mis postulaciones\".");
            Cargar();
        }
    }

    private void btnRetirar_Click(object sender, EventArgs e)
    {
        var id = Ayuda.Celda(tablaMias, "id_postulacion");
        if (id == null)
        {
            Ayuda.Advertir("Seleccione una de sus postulaciones.");
            return;
        }
        if (Convert.ToString(Ayuda.Celda(tablaMias, "Estado")) != "Pendiente")
        {
            Ayuda.Advertir("Solo puede retirar postulaciones que aún no han sido evaluadas.");
            return;
        }
        if (!Ayuda.Confirmar("¿Retirar la postulación seleccionada?"))
            return;

        if (Ayuda.Intentar(() => PostulacionDatos.Retirar(Convert.ToInt32(id), Sesion.IdUsuario)))
            Cargar();
    }
}
