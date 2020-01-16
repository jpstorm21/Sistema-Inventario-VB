Public Class ListaClientes
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label2.Font = New Font(Label2.Font.Name, 12)
        DataGridView1.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        DataGridView1.MultiSelect = False
        cargarClientes()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub cargarClientes()
        DataGridView1.DataSource = Cliente.getClientesByData()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.ClearSelection()
        DataGridView1.AllowUserToAddRows = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formCliente As New ClienteForm(Me, "-1")
        formCliente.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MsgBox("Seleccione Un Cliente Para Editar")
        Else
            Dim rut As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            Dim formCliente As New ClienteForm(Me, rut)
            formCliente.Show()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim text = TextBox1.Text
        If text = "" Then
            cargarClientes()
        Else
            DataGridView1.DataSource = Cliente.getClientesById(text)
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.ClearSelection()
            DataGridView1.AllowUserToAddRows = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MsgBox("Seleccione Un Cliente Para ver sus comprar")
        Else
            Dim rut As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            Dim compras As New ListaCompras(rut)
            compras.Show()
        End If
    End Sub
End Class