Public Class ListaUsuarios

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Font = New Font(Label1.Font.Name, 18)
        Label2.Font = New Font(Label2.Font.Name, 12)
        DataGridView1.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        DataGridView1.MultiSelect = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        refrescarTabla()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userform As New UserForm(Me, -1)
        userform.Show()
    End Sub

    Public Sub refrescarTabla()
        DataGridView1.DataSource = Usuarios.getUsuarios()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.ClearSelection()
        DataGridView1.AllowUserToAddRows = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MsgBox("Seleccione Un Usuario Para Editar")
        Else
            Dim rut As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            Dim formuser As New UserForm(Me, rut)
            formuser.Show()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim text = TextBox1.Text
        If text = "" Then
            refrescarTabla()
        Else
            DataGridView1.DataSource = Usuarios.getUsersById(text)
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.ClearSelection()
            DataGridView1.AllowUserToAddRows = False
        End If

    End Sub
End Class