Public Class GestionStock

    Public listProductos As Productos = Nothing
    Sub New(listProductos As Productos)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ComboBox1.Items.Add("Ingresar")
        ComboBox1.Items.Add("Descontar")
        ComboBox1.SelectedItem = "Ingresar"
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cagarProductos()
        Me.listProductos = listProductos
    End Sub

    Public Sub cagarProductos()
        DataGridView1.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        DataGridView1.MultiSelect = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.DataSource = Producto.getProductosByGestion
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.ClearSelection()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MsgBox("Seleccione un producto")
        Else
            Dim cod As Integer = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            Dim stock As Integer = DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value
            Dim cant = TextBox1.Text
            Dim movimiento = ComboBox1.SelectedItem
            Dim comentario = RichTextBox1.Text
            If cant = "" Then
                MsgBox("Ingrese una cantidad")
            Else
                If cant > stock And movimiento = "Descontar" Then
                    MsgBox("Ingrese una cantidad que no exceda el stock actual")
                Else
                    Producto.gestionInventario(cod, comentario, cant, stock, movimiento)
                    Me.listProductos.refrescarTabla()
                    MsgBox("Operación Realizada Exitosamente!!!")
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Sub SoloNumeros(ByRef e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Solo se puede ingresar valores de tipo número", MsgBoxStyle.Exclamation, "Ingreso de Número")
        End If
    End Sub

    Private Sub xd(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        SoloNumeros(e)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim text = TextBox2.Text
        If text = "" Then
            cagarProductos()
        Else
            DataGridView1.DataSource = Producto.getProductosByFiltro2(text)
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.ClearSelection()
            DataGridView1.AllowUserToAddRows = False
        End If
    End Sub
End Class