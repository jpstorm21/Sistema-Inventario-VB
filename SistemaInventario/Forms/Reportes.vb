Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class Reportes
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        'Label1.Font = New Font(Label1.Font.Name, 28)

        'Label2.Font = New Font(Label2.Font.Name, 12)
        'Button1.Font = New Font(Button1.Font.Name, 14)
        'Button2.Font = New Font(Button2.Font.Name, 14)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim fecha1 = DateTimePicker1.Value.AddDays(-1)
            Dim fecha2 = DateTimePicker2.Value
            Dim pdfDoc As New Document()
            Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream("Reporte-Ventas.pdf", FileMode.Create))
            pdfDoc.Open()
            Dim titulo = (New Paragraph("REPORTE DE VENTAS",
                                     FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18,
                                         iTextSharp.text.Font.NORMAL)))
            titulo.Alignment = Element.ALIGN_CENTER
            pdfDoc.Add(titulo)
            pdfDoc.Add(New Paragraph(Chunk.NEWLINE))
            Dim fechaem = (New Paragraph("                                                               Fecha de Emisión: " + DateTime.Now.ToString("dd/MM/yyyy"),
                                      FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10,
                                          iTextSharp.text.Font.NORMAL)))
            fechaem.Alignment = Element.ALIGN_CENTER
            pdfDoc.Add(fechaem)

            pdfDoc.Add(New Paragraph(Chunk.NEWLINE))
            pdfDoc.Add(New Paragraph(Chunk.NEWLINE))

            Dim tabla

            Dim celda0
            Dim celda1
            Dim celda2
            Dim celda3
            Dim celda4
            Dim celda5
            Dim celda6

            tabla = New pdf.PdfPTable(7) 'EL 5 ES EL NUMERO DE COLUMNAS

            celda0 = New pdf.PdfPCell(New Phrase("Codigo"))
            celda1 = New pdf.PdfPCell(New Phrase("Fecha"))
            celda2 = New pdf.PdfPCell(New Phrase("Tipo"))
            celda3 = New pdf.PdfPCell(New Phrase("Medio Pago"))
            celda4 = New pdf.PdfPCell(New Phrase("Vendedor"))
            celda5 = New pdf.PdfPCell(New Phrase("Cliente"))
            celda6 = New pdf.PdfPCell(New Phrase("Total"))


            celda0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda0.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda1.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda1.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda2.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda3.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda4.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda4.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda5.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda6.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda6.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP


            celda0.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY ' COLOR DE RELLENO DE LA CELDA DE TITULO
            celda1.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda2.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda3.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda4.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda5.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda6.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY

            tabla.addcell(celda0)
            tabla.addcell(celda1)
            tabla.addcell(celda2)
            tabla.addcell(celda3)
            tabla.addcell(celda4)
            tabla.addcell(celda5)
            tabla.addcell(celda6)

            pdfDoc.Add(tabla)

            Dim datos = Ventas.getVentasByReporte(fecha1, fecha2)

            For Each row As DataRow In datos.Rows
                Dim tablaAux As New PdfPTable(7)
                Dim valor As String = CStr(row("Codigo"))
                tablaAux.AddCell(valor)
                Dim valor2 As String = CStr(row("Fecha"))
                tablaAux.AddCell(valor2)
                Dim valor3 As String = CStr(row("Tipo"))
                tablaAux.AddCell(valor3)
                Dim valor4 As String = CStr(row("MedioPago"))
                tablaAux.AddCell(valor4)
                Dim valor5 As String = CStr(row("Vendedor"))
                tablaAux.AddCell(valor5)
                Dim valor6 As String = CStr(row("Cliente"))
                tablaAux.AddCell(valor6)
                Dim valor7 As String = CStr(row("Total"))
                tablaAux.AddCell(valor7)
                pdfDoc.Add(tablaAux)
            Next

            pdfDoc.Close()
            'Process.Start("MiPDF.pdf") 'abre el documento generado
            If System.IO.File.Exists("Reporte-Ventas.pdf") Then
                If MsgBox("Documento PDF generado correctamente " +
                   "¿desea abrir el fichero PDF resultante?",
                   MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Abrimos el fichero PDF con la aplicación asociada
                    System.Diagnostics.Process.Start("Reporte-Ventas.pdf")
                End If
            Else
                MsgBox("El fichero PDF no se ha generado, " +
                   "compruebe que tiene permisos en la carpeta de destino.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox("Se ha producido un error al intentar generar el documento PDF: puede que ya haya un archivo abierto",
                MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim pdfDoc As New Document()
            Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream("Reporte-Inventario.pdf", FileMode.Create))
            pdfDoc.Open()
            Dim titulo = (New Paragraph("REPORTE DE INVENTARIO",
                                     FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18,
                                         iTextSharp.text.Font.NORMAL)))
            titulo.Alignment = Element.ALIGN_CENTER
            pdfDoc.Add(titulo)
            pdfDoc.Add(New Paragraph(Chunk.NEWLINE))
            Dim fechaem = (New Paragraph("                                                               Fecha de Emisión: " + DateTime.Now.ToString("dd/MM/yyyy"),
                                      FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10,
                                          iTextSharp.text.Font.NORMAL)))
            fechaem.Alignment = Element.ALIGN_CENTER
            pdfDoc.Add(fechaem)

            pdfDoc.Add(New Paragraph(Chunk.NEWLINE))
            pdfDoc.Add(New Paragraph(Chunk.NEWLINE))

            Dim tabla

            Dim celda0
            Dim celda1
            Dim celda2
            Dim celda3
            Dim celda4
            Dim celda5
            Dim celda6

            tabla = New pdf.PdfPTable(7) 'EL 5 ES EL NUMERO DE COLUMNAS

            celda0 = New pdf.PdfPCell(New Phrase("Codigo"))
            celda1 = New pdf.PdfPCell(New Phrase("Nombre"))
            celda2 = New pdf.PdfPCell(New Phrase("Tipo"))
            celda3 = New pdf.PdfPCell(New Phrase("Stock Actual"))
            celda4 = New pdf.PdfPCell(New Phrase("Stock Minimo"))
            celda5 = New pdf.PdfPCell(New Phrase("Medición"))
            celda6 = New pdf.PdfPCell(New Phrase("Precio"))


            celda0.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda0.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda1.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda1.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda2.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda3.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda3.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda4.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda4.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda5.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda5.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP
            celda6.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            celda6.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP


            celda0.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY ' COLOR DE RELLENO DE LA CELDA DE TITULO
            celda1.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda2.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda3.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda4.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda5.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY
            celda6.backgroundcolor = pdf.ExtendedColor.LIGHT_GRAY

            tabla.addcell(celda0)
            tabla.addcell(celda1)
            tabla.addcell(celda2)
            tabla.addcell(celda3)
            tabla.addcell(celda4)
            tabla.addcell(celda5)
            tabla.addcell(celda6)

            pdfDoc.Add(tabla)

            Dim datos = Producto.getProductos()

            For Each row As DataRow In datos.Rows
                Dim tablaAux As New PdfPTable(7)
                Dim valor As String = CStr(row("codigo"))
                tablaAux.AddCell(valor)
                Dim valor2 As String = CStr(row("Nombre"))
                tablaAux.AddCell(valor2)
                Dim valor3 As String = CStr(row("Tipo"))
                tablaAux.AddCell(valor3)
                Dim valor4 As String = CStr(row("Stock"))
                tablaAux.AddCell(valor4)
                Dim valor5 As String = CStr(row("StockMin"))
                tablaAux.AddCell(valor5)
                Dim valor6 As String = CStr(row("Medicion"))
                tablaAux.AddCell(valor6)
                Dim valor7 As String = CStr(row("Precio"))
                tablaAux.AddCell(valor7)
                pdfDoc.Add(tablaAux)
            Next

            pdfDoc.Close()
            'Process.Start("MiPDF.pdf") 'abre el documento generado
            If System.IO.File.Exists("Reporte-Inventario.pdf") Then
                If MsgBox("Documento PDF generado correctamente " +
                   "¿desea abrir el fichero PDF resultante?",
                   MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Abrimos el fichero PDF con la aplicación asociada
                    System.Diagnostics.Process.Start("Reporte-Inventario.pdf")
                End If
            Else
                MsgBox("El fichero PDF no se ha generado, " +
                   "compruebe que tiene permisos en la carpeta de destino.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox("Se ha producido un error al intentar generar el documento PDF: puede que ya haya un archivo abierto",
                MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)

        End Try
    End Sub

End Class