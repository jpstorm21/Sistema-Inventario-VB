Public Class ProductoForm

    Public ListaProducto As Productos = Nothing
    Public prod As Producto = Nothing
    Public codigo As Integer = 0
    Sub New(ListaProducto As Productos, cod As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Font = New Font(Label1.Font.Name, 18)
        Me.ListaProducto = ListaProducto
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ComboBox1.DataSource = Producto.getTipos()
        ComboBox1.DisplayMember = "Nombre"
        ComboBox1.ValueMember = "IdTipo"
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        codigo = cod
        ComboBox2.Items.Add("Kg")
        ComboBox2.Items.Add("Unidades")
        ComboBox2.Items.Add("Gramos")
        ComboBox2.Items.Add("Paquete")
        ComboBox2.SelectedItem = "Kg"
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        If cod <> "-1" Then
            prod = Producto.getProducto(cod)
            Label1.Text = "Actualizar Producto"
            Button1.Text = "Actualizar"
            ComboBox2.SelectedItem = prod.medicion
            TextBoxNombre.Text = prod.nombre
            TextBoxPrecio.Text = prod.precio
            TextBoxStock.Text = prod.stock
            TextBoxStockMin.Text = prod.stockMin
            ComboBox1.SelectedValue = prod.tipo
            TextBoxStock.Enabled = False
        End If

    End Sub

    Function existeProducto(name As String) As Boolean
        Dim existe As Boolean = Producto.existProductoByName(name)
        Return existe
    End Function

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombre = TextBoxNombre.Text
        Dim precio = TextBoxPrecio.Text
        Dim stock = TextBoxStock.Text
        Dim stockmin = TextBoxStockMin.Text
        Dim tipo = ComboBox1.SelectedValue
        Dim medicion = ComboBox2.SelectedItem
        If nombre = "" Or precio = "" Or stock = "" Or stockmin = "" Or medicion = "" Then
            MsgBox("Algunos Campos Se Encuentran Vacios!!")
        Else
            Dim existe As Boolean = existeProducto(nombre)
            If existe Then
                MsgBox("Ya existe un producto con ese Nombre")
            Else
                Dim valor = Format(Val(CDec(precio)), "##,##0")
                Dim producto As New Producto(nombre, tipo, stock, stockmin, medicion, valor)
                If Button1.Text = "Actualizar" Then
                    producto.ActualizarProducto(Me.codigo)
                    MsgBox("Producto Actualizado Correctamente")
                    ListaProducto.refrescarTabla()
                    Me.Close()
                Else
                    producto.insertarProducto()
                    MsgBox("Producto Ingresado Correctamente")
                    ListaProducto.refrescarTabla()
                    Me.Close()
                End If
            End If

        End If
    End Sub

    Private Sub TextBoxPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxPrecio.KeyPress
        SoloNumeros(e)
    End Sub

End Class