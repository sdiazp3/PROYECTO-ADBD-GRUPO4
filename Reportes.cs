using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SistemaAyudantias.Datos;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using W = DocumentFormat.OpenXml.Wordprocessing; // "W" evita confundir las clases de Word con las de QuestPDF

namespace SistemaAyudantias.Utilidades;

/// <summary>
/// Reporte de postulaciones (RF-11) en PDF (QuestPDF) y Word (Open XML SDK), con formato institucional:
/// encabezado con escudo, datos del reporte, resumen por estado, tabla, firmas y número de página.
/// </summary>
public static class Reportes
{
    public const string Titulo = "REPORTE DE POSTULACIONES A AYUDANTÍAS DE CÁTEDRA";
    private const string Sistema = "Sistema de Gestión de Ayudantías de Cátedra";

    // Colores institucionales (hexadecimal)
    private const string Verde = "127A45";
    private const string VerdeOscuro = "0B4F30";
    private const string VerdeClaro = "EEF7F1";
    private const string Dorado = "F2B705";
    private const string Gris = "64748B";
    private const string GrisBorde = "D6E0DA";

    private static readonly string[] Estados = { "Seleccionado", "En espera", "Pendiente", "No seleccionado" };

    // =================================================================
    //  PDF
    // =================================================================
    public static void GenerarPdf(DataTable datos, string filtros, string ruta)
    {
        QuestPDF.Settings.License = LicenseType.Community; // gratuita para uso académico
        var escudo = RutaEscudo();

        Document.Create(documento =>
        {
            documento.Page(pagina =>
            {
                pagina.Size(PageSizes.A4.Landscape());
                pagina.Margin(1.4f, Unit.Centimetre);
                pagina.DefaultTextStyle(estilo => estilo.FontSize(9).FontColor("#1F2937"));

                // ---------- Encabezado ----------
                pagina.Header().Column(encabezado =>
                {
                    encabezado.Item().Row(fila =>
                    {
                        if (escudo != null)
                            fila.ConstantItem(62).Height(62).AlignCenter().AlignMiddle().Image(escudo).FitArea();

                        fila.RelativeItem().PaddingLeft(12).Column(texto =>
                        {
                            texto.Item().Text(Conexion.Institucion.ToUpper()).Bold().FontSize(14).FontColor("#" + VerdeOscuro);
                            texto.Item().Text(Sistema).FontSize(10).FontColor("#" + Gris);
                            texto.Item().PaddingTop(6).Text(Titulo).Bold().FontSize(12.5f);
                        });

                        fila.ConstantItem(140).AlignRight().AlignMiddle().Column(fecha =>
                        {
                            fecha.Item().AlignRight().Text("Fecha de emisión").FontSize(8).FontColor("#" + Gris);
                            fecha.Item().AlignRight().Text(DateTime.Now.ToString("dd/MM/yyyy  HH:mm")).SemiBold();
                        });
                    });

                    // Franja verde y dorada
                    encabezado.Item().PaddingTop(8).Row(franja =>
                    {
                        franja.RelativeItem(4).LineHorizontal(3).LineColor("#" + Verde);
                        franja.RelativeItem(1).LineHorizontal(3).LineColor("#" + Dorado);
                    });
                });

                // ---------- Contenido ----------
                pagina.Content().PaddingTop(12).Column(contenido =>
                {
                    // Datos del reporte
                    contenido.Item().Background("#" + VerdeClaro).Border(1).BorderColor("#" + GrisBorde).Padding(10).Row(fila =>
                    {
                        DatoPdf(fila.RelativeItem(2), "Generado por", Sesion.NombreCompleto + " (" + Sesion.Rol + ")");
                        DatoPdf(fila.RelativeItem(4), "Filtros aplicados", filtros);
                        DatoPdf(fila.RelativeItem(1), "Total de registros", datos.Rows.Count.ToString());
                    });

                    // Resumen por estado
                    contenido.Item().PaddingTop(10).Row(fila =>
                    {
                        foreach (var estado in Estados)
                        {
                            var (fondo, texto) = ColoresEstado(estado);
                            fila.RelativeItem().PaddingRight(estado == "No seleccionado" ? 0 : 8)
                                .Background("#" + fondo).Padding(8).Column(caja =>
                                {
                                    caja.Item().Text(Contar(datos, estado).ToString()).Bold().FontSize(16).FontColor("#" + texto);
                                    caja.Item().Text(estado).FontSize(8.5f).FontColor("#" + texto);
                                });
                        }
                    });

                    // Tabla de postulaciones
                    contenido.Item().PaddingTop(12).Table(tabla =>
                    {
                        tabla.ColumnsDefinition(columnas =>
                        {
                            columnas.ConstantColumn(28); // N.º
                            foreach (DataColumn columna in datos.Columns)
                                columnas.RelativeColumn(AnchoColumna(columna.ColumnName));
                        });

                        tabla.Header(cabecera =>
                        {
                            cabecera.Cell().Background("#" + VerdeOscuro).Padding(5).Text("N.º").Bold().FontColor(Colors.White);
                            foreach (DataColumn columna in datos.Columns)
                                cabecera.Cell().Background("#" + VerdeOscuro).Padding(5).Text(columna.ColumnName).Bold().FontColor(Colors.White);
                        });

                        for (var i = 0; i < datos.Rows.Count; i++)
                        {
                            var fondo = i % 2 == 0 ? "#FFFFFF" : "#F5FAF7"; // filas intercaladas
                            tabla.Cell().Background(fondo).BorderBottom(0.5f).BorderColor("#" + GrisBorde).Padding(5)
                                .Text((i + 1).ToString()).FontColor("#" + Gris);

                            foreach (DataColumn columna in datos.Columns)
                            {
                                var valor = TextoCelda(datos.Rows[i][columna]);
                                var celda = tabla.Cell().Background(fondo).BorderBottom(0.5f).BorderColor("#" + GrisBorde).Padding(5);

                                if (columna.ColumnName == "Estado")
                                    celda.Text(valor).SemiBold().FontColor("#" + ColoresEstado(valor).Texto);
                                else if (columna.ColumnName == "Puntaje")
                                    celda.AlignRight().Text(valor);
                                else
                                    celda.Text(valor);
                            }
                        }
                    });

                    // Firmas
                    contenido.Item().PaddingTop(45).Row(firmas =>
                    {
                        FirmaPdf(firmas.RelativeItem(), "Elaborado por", Sesion.NombreCompleto, Sesion.Rol);
                        firmas.ConstantItem(80);
                        FirmaPdf(firmas.RelativeItem(), "Revisado por", "Coordinación de Carrera", "Firma y sello");
                    });
                });

                // ---------- Pie de página ----------
                pagina.Footer().BorderTop(0.75f).BorderColor("#" + GrisBorde).PaddingTop(5).Row(pie =>
                {
                    pie.RelativeItem().Text(Sistema + " · " + Conexion.Institucion).FontSize(8).FontColor("#" + Gris);
                    pie.ConstantItem(100).AlignRight().Text(texto =>
                    {
                        texto.DefaultTextStyle(estilo => estilo.FontSize(8).FontColor("#" + Gris));
                        texto.Span("Página ");
                        texto.CurrentPageNumber();
                        texto.Span(" de ");
                        texto.TotalPages();
                    });
                });
            });
        }).GeneratePdf(ruta);
    }

    private static void DatoPdf(IContainer contenedor, string titulo, string valor)
    {
        contenedor.PaddingRight(10).Column(dato =>
        {
            dato.Item().Text(titulo.ToUpper()).FontSize(7.5f).SemiBold().FontColor("#" + Verde);
            dato.Item().Text(valor).FontSize(9);
        });
    }

    private static void FirmaPdf(IContainer contenedor, string titulo, string nombre, string cargo)
    {
        contenedor.Column(firma =>
        {
            firma.Item().PaddingHorizontal(30).LineHorizontal(0.75f).LineColor("#1F2937");
            firma.Item().PaddingTop(4).AlignCenter().Text(nombre).SemiBold();
            firma.Item().AlignCenter().Text(cargo).FontSize(8).FontColor("#" + Gris);
            firma.Item().AlignCenter().Text(titulo).FontSize(8).FontColor("#" + Verde);
        });
    }

    // =================================================================
    //  WORD (.docx)
    // =================================================================
    public static void GenerarWord(DataTable datos, string filtros, string ruta)
    {
        using var documento = WordprocessingDocument.Create(ruta, WordprocessingDocumentType.Document);
        var principal = documento.AddMainDocumentPart();
        var cuerpo = new W.Body();
        principal.Document = new W.Document(cuerpo);

        // ---------- Encabezado: escudo | institución y título | fecha ----------
        var celdaEscudo = Celda("", 1300);
        var escudo = RutaEscudo();
        if (escudo != null)
            celdaEscudo = new W.TableCell(Ancho(1300), new W.Paragraph(new W.Run(ImagenWord(principal, escudo, 1.6, 1.7))));

        var encabezado = TablaSinBordes(
            new W.TableRow(
                celdaEscudo,
                new W.TableCell(Ancho(10500),
                    Parrafo(Conexion.Institucion.ToUpper(), 28, true, VerdeOscuro),
                    Parrafo(Sistema, 20, false, Gris),
                    Parrafo(Titulo, 24, true, "1F2937", espacioAntes: 80)),
                new W.TableCell(Ancho(2600),
                    Parrafo("Fecha de emisión", 16, false, Gris, alineacion: W.JustificationValues.Right),
                    Parrafo(DateTime.Now.ToString("dd/MM/yyyy  HH:mm"), 18, true, "1F2937", alineacion: W.JustificationValues.Right))));

        // Línea verde gruesa bajo el encabezado
        var linea = new W.Paragraph(new W.ParagraphProperties(
            new W.ParagraphBorders(new W.BottomBorder { Val = W.BorderValues.Single, Size = 18, Color = Verde, Space = 1 }),
            new W.SpacingBetweenLines { After = "160" }));

        // ---------- Datos del reporte ----------
        var datosReporte = TablaSinBordes(new W.TableRow(
            CeldaDato("GENERADO POR", Sesion.NombreCompleto + " (" + Sesion.Rol + ")", 4200),
            CeldaDato("FILTROS APLICADOS", filtros, 7800),
            CeldaDato("TOTAL DE REGISTROS", datos.Rows.Count.ToString(), 2400)));

        // ---------- Resumen por estado ----------
        var filaResumen = new W.TableRow();
        foreach (var estado in Estados)
        {
            var (fondo, texto) = ColoresEstado(estado);
            filaResumen.Append(new W.TableCell(
                new W.TableCellProperties(new W.TableCellWidth { Width = "3600", Type = W.TableWidthUnitValues.Dxa },
                    new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = fondo }),
                Parrafo(Contar(datos, estado).ToString(), 28, true, texto),
                Parrafo(estado, 17, false, texto)));
        }
        var resumen = TablaSinBordes(filaResumen);

        // ---------- Tabla de postulaciones ----------
        var tabla = new W.Table(new W.TableProperties(
            new W.TableWidth { Width = "5000", Type = W.TableWidthUnitValues.Pct },
            new W.TableBorders(
                new W.TopBorder { Val = W.BorderValues.Single, Size = 4, Color = GrisBorde },
                new W.BottomBorder { Val = W.BorderValues.Single, Size = 4, Color = GrisBorde },
                new W.LeftBorder { Val = W.BorderValues.Nil },
                new W.RightBorder { Val = W.BorderValues.Nil },
                new W.InsideHorizontalBorder { Val = W.BorderValues.Single, Size = 4, Color = GrisBorde },
                new W.InsideVerticalBorder { Val = W.BorderValues.Nil }),
            new W.TableCellMarginDefault(
                new W.TopMargin { Width = "60", Type = W.TableWidthUnitValues.Dxa },
                new W.BottomMargin { Width = "60", Type = W.TableWidthUnitValues.Dxa })));

        // Encabezado verde que se repite en cada página
        var cabecera = new W.TableRow(new W.TableRowProperties(new W.TableHeader()));
        cabecera.Append(CeldaColor("N.º", VerdeOscuro, "FFFFFF", true));
        foreach (DataColumn columna in datos.Columns)
            cabecera.Append(CeldaColor(columna.ColumnName, VerdeOscuro, "FFFFFF", true));
        tabla.Append(cabecera);

        for (var i = 0; i < datos.Rows.Count; i++)
        {
            var fondo = i % 2 == 0 ? "FFFFFF" : "F5FAF7";
            var fila = new W.TableRow(new W.TableRowProperties(new W.CantSplit()));
            fila.Append(CeldaColor((i + 1).ToString(), fondo, Gris, false));

            foreach (DataColumn columna in datos.Columns)
            {
                var valor = TextoCelda(datos.Rows[i][columna]);
                var colorTexto = columna.ColumnName == "Estado" ? ColoresEstado(valor).Texto : "1F2937";
                fila.Append(CeldaColor(valor, fondo, colorTexto, columna.ColumnName == "Estado"));
            }
            tabla.Append(fila);
        }

        // ---------- Firmas ----------
        var firmas = TablaSinBordes(new W.TableRow(
            CeldaFirma("Elaborado por", Sesion.NombreCompleto, Sesion.Rol),
            Celda("", 2400),
            CeldaFirma("Revisado por", "Coordinación de Carrera", "Firma y sello")));

        // ---------- Pie de página con "Página X de Y" ----------
        var pie = principal.AddNewPart<FooterPart>();
        pie.Footer = new W.Footer(new W.Paragraph(
            new W.ParagraphProperties(
                new W.ParagraphBorders(new W.TopBorder { Val = W.BorderValues.Single, Size = 4, Color = GrisBorde, Space = 4 }),
                new W.Tabs(new W.TabStop { Val = W.TabStopValues.Right, Position = 14900 })),
            Texto(Sistema + " · " + Conexion.Institucion, 16, false, Gris),
            new W.Run(new W.TabChar()),
            Texto("Página ", 16, false, Gris),
            new W.SimpleField(Texto("1", 16, false, Gris)) { Instruction = " PAGE " },
            Texto(" de ", 16, false, Gris),
            new W.SimpleField(Texto("1", 16, false, Gris)) { Instruction = " NUMPAGES " }));

        cuerpo.Append(
            encabezado,
            linea,
            datosReporte,
            Parrafo("", 10),
            resumen,
            Parrafo("", 10),
            tabla,
            Parrafo("", 18, espacioAntes: 900),
            firmas,
            Parrafo("", 4),
            // Hoja A4 horizontal con márgenes de 1.4 cm (medidas en twips: 1 cm = 567)
            new W.SectionProperties(
                new W.FooterReference { Type = W.HeaderFooterValues.Default, Id = principal.GetIdOfPart(pie) },
                new W.PageSize { Width = 16838, Height = 11906, Orient = W.PageOrientationValues.Landscape },
                new W.PageMargin { Top = 794, Bottom = 794, Left = 794, Right = 794, Header = 400, Footer = 400, Gutter = 0 }));

        principal.Document.Save();
    }

    // ---------- Piezas pequeñas de Word ----------

    // Texto con formato. El tamaño va en medios puntos: 18 = 9 pt
    private static W.Run Texto(string texto, int tamano, bool negrita, string color)
    {
        var formato = new W.RunProperties(
            new W.RunFonts { Ascii = "Calibri", HighAnsi = "Calibri" },
            new W.Color { Val = color },
            new W.FontSize { Val = tamano.ToString() });
        if (negrita)
            formato.PrependChild(new W.Bold());

        return new W.Run(formato, new W.Text(texto) { Space = SpaceProcessingModeValues.Preserve });
    }

    private static W.Paragraph Parrafo(string texto, int tamano, bool negrita = false, string color = "1F2937",
        W.JustificationValues? alineacion = null, int espacioAntes = 0)
    {
        var propiedades = new W.ParagraphProperties(
            new W.SpacingBetweenLines { Before = espacioAntes.ToString(), After = "20" });
        if (alineacion != null)
            propiedades.Append(new W.Justification { Val = alineacion.Value });

        return new W.Paragraph(propiedades, Texto(texto, tamano, negrita, color));
    }

    private static W.TableCellProperties Ancho(int twips) =>
        new W.TableCellProperties(new W.TableCellWidth { Width = twips.ToString(), Type = W.TableWidthUnitValues.Dxa },
            new W.TableCellVerticalAlignment { Val = W.TableVerticalAlignmentValues.Center });

    private static W.TableCell Celda(string texto, int twips) =>
        new W.TableCell(Ancho(twips), Parrafo(texto, 18));

    private static W.TableCell CeldaColor(string texto, string fondo, string colorTexto, bool negrita) =>
        new W.TableCell(
            new W.TableCellProperties(new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = fondo }),
            Parrafo(texto, 17, negrita, colorTexto));

    private static W.TableCell CeldaDato(string titulo, string valor, int twips) =>
        new W.TableCell(
            new W.TableCellProperties(
                new W.TableCellWidth { Width = twips.ToString(), Type = W.TableWidthUnitValues.Dxa },
                new W.Shading { Val = W.ShadingPatternValues.Clear, Fill = VerdeClaro }),
            Parrafo(titulo, 14, true, Verde, espacioAntes: 60),
            Parrafo(valor, 18));

    private static W.TableCell CeldaFirma(string titulo, string nombre, string cargo) =>
        new W.TableCell(Ancho(6000),
            Parrafo("______________________________________", 18, false, "1F2937", W.JustificationValues.Center),
            Parrafo(nombre, 18, true, "1F2937", W.JustificationValues.Center),
            Parrafo(cargo, 16, false, Gris, W.JustificationValues.Center),
            Parrafo(titulo, 16, false, Verde, W.JustificationValues.Center));

    private static W.Table TablaSinBordes(W.TableRow fila) =>
        new W.Table(new W.TableProperties(
                new W.TableWidth { Width = "5000", Type = W.TableWidthUnitValues.Pct },
                new W.TableBorders(
                    new W.TopBorder { Val = W.BorderValues.Nil }, new W.BottomBorder { Val = W.BorderValues.Nil },
                    new W.LeftBorder { Val = W.BorderValues.Nil }, new W.RightBorder { Val = W.BorderValues.Nil },
                    new W.InsideHorizontalBorder { Val = W.BorderValues.Nil },
                    new W.InsideVerticalBorder { Val = W.BorderValues.Nil })),
            fila);

    /// <summary>Inserta una imagen PNG en Word (código estándar del Open XML SDK). Medidas en centímetros.</summary>
    private static W.Drawing ImagenWord(MainDocumentPart principal, string rutaImagen, double anchoCm, double altoCm)
    {
        var parteImagen = principal.AddImagePart(ImagePartType.Png);
        using (var archivo = File.OpenRead(rutaImagen))
            parteImagen.FeedData(archivo);

        var idImagen = principal.GetIdOfPart(parteImagen);
        long ancho = (long)(anchoCm * 360000); // 1 cm = 360000 EMU
        long alto = (long)(altoCm * 360000);

        return new W.Drawing(
            new DW.Inline(
                new DW.Extent { Cx = ancho, Cy = alto },
                new DW.EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                new DW.DocProperties { Id = 1U, Name = "Escudo" },
                new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks { NoChangeAspect = true }),
                new A.Graphic(
                    new A.GraphicData(
                        new PIC.Picture(
                            new PIC.NonVisualPictureProperties(
                                new PIC.NonVisualDrawingProperties { Id = 0U, Name = "escudo.png" },
                                new PIC.NonVisualPictureDrawingProperties()),
                            new PIC.BlipFill(
                                new A.Blip { Embed = idImagen },
                                new A.Stretch(new A.FillRectangle())),
                            new PIC.ShapeProperties(
                                new A.Transform2D(new A.Offset { X = 0L, Y = 0L }, new A.Extents { Cx = ancho, Cy = alto }),
                                new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle })))
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }))
            { DistanceFromTop = 0U, DistanceFromBottom = 0U, DistanceFromLeft = 0U, DistanceFromRight = 0U });
    }

    // =================================================================
    //  Comunes
    // =================================================================
    private static int Contar(DataTable datos, string estado) =>
        datos.Rows.Cast<DataRow>().Count(fila => Convert.ToString(fila["Estado"]) == estado);

    // Colores de fondo y texto de cada estado (igual que los chips de la pantalla)
    private static (string Fondo, string Texto) ColoresEstado(string estado) => estado switch
    {
        "Seleccionado" => ("D1FAE5", "047857"),
        "En espera" => ("DBEAFE", "1D4ED8"),
        "Pendiente" => ("FEF3C7", "B45309"),
        "No seleccionado" => ("FEE2E2", "B91C1C"),
        _ => ("F1F5F9", "475569")
    };

    // Ancho relativo de cada columna de la tabla del PDF
    private static float AnchoColumna(string columna) => columna switch
    {
        "Estudiante" or "Asignatura" => 3f,
        "Carrera" => 2.2f,
        "Período" => 2f,
        "Estado" => 1.7f,
        "Cédula" => 1.6f,
        _ => 1.3f
    };

    private static string? RutaEscudo()
    {
        var ruta = Path.Combine(AppContext.BaseDirectory, "Recursos", "escudo.png");
        return File.Exists(ruta) ? ruta : null;
    }

    private static string TextoCelda(object valor) => valor switch
    {
        DateTime fecha => fecha.ToString("dd/MM/yyyy"),
        decimal numero => numero.ToString("0.##"),
        DBNull => "",
        _ => Convert.ToString(valor) ?? ""
    };
}
