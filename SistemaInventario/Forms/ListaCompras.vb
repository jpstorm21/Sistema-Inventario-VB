Public Class ListaCompras

    Public rut As String

    Sub New(rut As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.rut = rut
        DataGridView1.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        DataGridView1.MultiSelect = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarCompras(rut)
    End Sub

    Public Sub cargarCompras(rut As String)
        DataGridView1.DataSource = Cliente.getComprasByCliente(rut)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.ClearSelection()
        DataGridView1.AllowUserToAddRows = False
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim text = TextBox2.Text
        If text = "" Then
            cargarCompras(Me.rut)
        Else
            DataGridView1.DataSource = Cliente.getComprasByClienteFiltro(Me.rut, text)
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.ClearSelection()
            DataGridView1.AllowUserToAddRows = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MsgBox("Seleccione una Compra")
        Else
            Dim cod As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            Dim infoventa As New InfoVenta(cod)
            infoventa.Show()
        End If
    End Sub
End Class