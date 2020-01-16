Public Class VentaForm

    Public listVentas As ListaVentas = Nothing
    Public table As New DataTable
    Public total As Integer

    Sub New(listVentas As ListaVentas)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Font = New Font(Label1.Font.Name, 14)
        Label2.Font = New Font(Label2.Font.Name, 14)
        DataGridView1.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        DataGridView2.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        DataGridView2.MultiSelect = False
        DataGridView1.MultiSelect = False
        Me.listVentas = listVentas
        cargarProductos()
        table.Columns.Add("Codigo")
        table.Columns.Add("Nombre")
        table.Columns.Add("Cantidad")
        table.Columns.Add("Precio Unitario")
        table.Columns.Add("Precio por Cantidad")
        ComboBox1.Items.Add("Efectivo")
        ComboBox1.Items.Add("Debito")
        ComboBox1.Items.Add("Credito")
        ComboBox1.SelectedItem = "Efectivo"
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.Items.Add("Presencial")
        ComboBox2.Items.Add("Telefonica")
        ComboBox2.Items.Add("Otro")
        ComboBox2.SelectedItem = "Presencial"
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        cargarClientes()
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Public Sub cargarProductos()
        DataGridView1.DataSource = Producto.getProductos()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.ClearSelection()
        DataGridView1.AllowUserToAddRows = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MsgBox("Seleccione Algun Producto")
        Else
            Dim cantidadTotal As Integer = 0
            Dim arrayProductos(100) As Producto
            Dim cant = InputBox("Ingrese Cantidad del Producto Seleccionado", "Cantidad")
            If IsNumeric(cant) Then
                Dim stock As Integer = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value
                If cant > stock Then
                    MsgBox("La cantidad Seleccionada Supera el Stock Actual!!")
                Else
                    If cant <> 0 Then
                        Dim cod As Integer = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
                        Dim nombre As String = DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value
                        Dim precio As Decimal = DataGridView1.Item(6, DataGridView1.CurrentRow.Index).Value
                        Me.total = Me.total + precio * cant
                        Label6.Text = Format(Val(CDec(Me.total)), "##,##0")

                        Dim esta As Boolean = False
                        For Each row As DataRow In table.Rows
                            Dim valor As Integer = row("Codigo")
                            If valor = cod Then
                                esta = True
                            End If
                        Next

                        If esta = False Then
                            table.Rows.Add(cod, nombre, cant, Format(Val(CDec(precio)), "##,##0"), Format(Val(CDec(precio * cant)), "##,##0"))
                            DataGridView2.DataSource = Nothing
                            DataGridView2.DataSource = table
                            DataGridView2.AllowUserToAddRows = False
                            DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value - cant
                        Else
                            For i = 0 To DataGridView2.Rows.Count - 1
                                If DataGridView2.Rows(i).Cells("Codigo").Value = cod Then
                                    Dim cantAux As String = DataGridView2.Rows(i).Cells("Cantidad").Value
                                    Dim cant2 As Integer = Convert.ToInt32(cantAux)
                                    Dim precioAux As Decimal = DataGridView2.Rows(i).Cells("Precio Unitario").Value
                                    DataGridView2.Rows(i).Cells("Cantidad").Value = cant2 + cant
                                    DataGridView2.Rows(i).Cells("Precio por Cantidad").Value = Format(Val(CDec(precioAux * (cant + cant2))), "##,##0")
                                    DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value - cant
                                End If
                            Next
                        End If

                    Else
                        MsgBox("Ingrese una cantidad valida")
                    End If
                End If
            Else
                MsgBox("Ingrese un Valor Numerico")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView2.CurrentRow Is Nothing Then
            MsgBox("Seleccione Algun Producto")
        Else
            Dim stock As Integer = DataGridView2.Item(2, DataGridView2.CurrentRow.Index).Value
            Dim valor As Decimal = DataGridView2.Item(4, DataGridView2.CurrentRow.Index).Value
            Dim cod As String = DataGridView2.Item(0, DataGridView2.CurrentRow.Index).Value
            Me.total = Me.total - valor
            Label6.Text = Format(Val(CDec(Me.total)), "##,##0")
            DataGridView2.Rows.Remove(DataGridView2.CurrentRow)
            'DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value + stock
            For i = 0 To DataGridView1.Rows.Count - 1
                If cod = DataGridView1.Rows(i).Cells("codigo").Value Then
                    DataGridView1.Rows(i).Cells("Stock").Value = DataGridView1.Rows(i).Cells("Stock").Value + stock
                End If
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView2.CurrentRow Is Nothing Then
            MsgBox("Carrito de compra se encuenta vacio")
        Else
            Dim descripcion = RichTextBox1.Text
            Dim boleta = RadioButton1.Checked
            Dim factura = RadioButton2.Checked
            Dim pago = ComboBox1.SelectedItem
            Dim cliente = ComboBox3.SelectedValue
            Dim formaVenta = ComboBox2.SelectedItem
            Dim tipo As String = ""
            If boleta Or factura Or cliente = "" Then
                If boleta Then
                    tipo = "Boleta"
                Else
                    tipo = "Factura"
                End If
                Dim venta As New Ventas(tipo, pago, Auth.nombreUsuarioLogueado, descripcion, Format(Val(CDec(Me.total)), "##,##0"), cliente, formaVenta)
                Dim cod = venta.registrarVenta()
                For Each Fila As DataGridViewRow In DataGridView2.Rows
                    Dim codProd = Fila.Cells("Codigo").Value
                    Dim cantidad = Fila.Cells("Cantidad").Value
                    Ventas.registrarProductosVentas(cod, cantidad, codProd)
                Next
                MsgBox("Venta Registrada Exitosamente")
                listVentas.refrescarTablaVenta()
                Me.Close()
            Else
                MsgBox("Algunos Campos se encuentran vacias!!")
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim clienteForm As New ClienteForm(Me)
        clienteForm.show()
    End Sub

    Public Sub cargarClientes()
        ComboBox3.DataSource = Cliente.getClientes()
        ComboBox3.DisplayMember = "Nombre"
        ComboBox3.ValueMember = "Rut"
    End Sub
End Class