Public Class ListaVentas


    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Font = New Font(Label1.Font.Name, 18)
        Label2.Font = New Font(Label2.Font.Name, 12)
        DataGridView1.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        DataGridView1.MultiSelect = False
        refrescarTablaVenta()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ventaForm As New VentaForm(Me)
        ventaForm.Show()
    End Sub

    Public Sub refrescarTablaVenta()
        DataGridView1.DataSource = Ventas.getVentas()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.ClearSelection()
        DataGridView1.AllowUserToAddRows = False
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim text = TextBox2.Text
        If text = "" Then
            refrescarTablaVenta()
        Else
            DataGridView1.DataSource = Ventas.getVentasByFiltro(text)
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.ClearSelection()
            DataGridView1.AllowUserToAddRows = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MsgBox("Seleccione una Venta")
        Else
            Dim cod As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            Dim infoventa As New InfoVenta(cod)
            infoventa.Show()
        End If
    End Sub
End Class