Public Class ClienteForm

    Public venta As VentaForm = Nothing
    Public listCliente As ListaClientes = Nothing
    Public client As Cliente = Nothing
    Sub New(venta As VentaForm)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.venta = venta
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Sub New(listCliente As ListaClientes, rut As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.listCliente = listCliente
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If rut <> "-1" Then
            client = Cliente.getClienteByRut(rut)
            TextBoxTelefono.Text = client.telefono
            TextBoxDireccion.Text = client.direccion
            TextBoxNombre.Text = client.nombre
            TextBoxRut.Text = client.rut
            TextBoxRut.Enabled = False
            Label1.Text = "Editar Cliente"
            Button1.Text = "Editar Cliente"
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rut = TextBoxRut.Text
        Dim nombre = TextBoxNombre.Text
        Dim direccion = TextBoxDireccion.Text
        Dim telefono = TextBoxTelefono.Text
        If rut = "" Or nombre = "" Or direccion = "" Or telefono = "" Then
            MsgBox("Algunos campos se encuentran vacios!!")
        Else
            Dim valido = Auth.VerificaRUT(rut)
            If valido Then
                Dim cliente As New Cliente(rut, nombre, direccion, telefono)
                If Button1.Text = "Editar Cliente" Then
                    cliente.ActualizarCliente()
                    MsgBox("Cliente Actualizado Exitosamente!!")
                Else
                    Dim resultado = cliente.ingresarCliente()
                    If resultado = -1 Then
                        MsgBox("Ya se encuentra un cliente con el rut ingresado!!!")
                    Else
                        MsgBox("Cliente Registrado Exitosamente!!")
                    End If
                End If
                If Me.venta Is Nothing Then
                    listCliente.cargarClientes()
                Else
                    venta.cargarClientes()
                End If
                Me.Close()
            Else
                MsgBox("Rut no valido!!!")
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

    Private Sub xd(sender As Object, e As KeyPressEventArgs) Handles TextBoxTelefono.KeyPress
        SoloNumeros(e)
    End Sub

End Class