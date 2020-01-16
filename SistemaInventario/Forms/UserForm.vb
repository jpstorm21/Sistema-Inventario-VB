Public Class UserForm
    Public ListaUser As ListaUsuarios = Nothing
    Public user As Usuarios = Nothing
    Sub New(ListaUser As ListaUsuarios, rut As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Font = New Font(Label1.Font.Name, 18)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ComboBoxCargo.DataSource = Usuarios.getRoles()
        ComboBoxCargo.DisplayMember = "NombreRol"
        ComboBoxCargo.ValueMember = "Id"
        ComboBoxCargo.DropDownStyle = ComboBoxStyle.DropDownList
        Me.ListaUser = ListaUser
        If rut <> "-1" Then
            user = Usuarios.obtenerUsuario(rut)
            Label1.Text = "Editar Usuario"
            Button1.Text = "Actualizar"
            TextBoxRut.Text = user.rut
            TextBoxApellidos.Text = user.apellido
            TextBoxNames.Text = user.nombre
            TextBoxPass.Text = user.pass
            TextBoxPass2.Text = user.pass
            TextBoxPhone.Text = user.telefono
            ComboBoxCargo.SelectedValue = user.rol
            TextBoxRut.Enabled = False
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rut = TextBoxRut.Text
        Dim nombre = TextBoxNames.Text
        Dim apellidos = TextBoxApellidos.Text
        Dim telefono = TextBoxPhone.Text
        Dim rol = ComboBoxCargo.SelectedValue
        Dim pass = TextBoxPass.Text
        Dim pass2 = TextBoxPass2.Text
        If rut = "" Or nombre = "" Or apellidos = "" Or telefono = "" Or pass = "" Or pass2 = "" Then
            MsgBox("Algunos Campos Se Encuentras Vacios")
        Else
            Dim valido = Auth.VerificaRUT(rut)
            If valido Then
                If pass <> pass2 Then
                    MsgBox("Las Contraseñas No Coinciden")
                Else
                    Dim user As New Usuarios(rut, nombre, apellidos, rol, pass, telefono)
                    If Button1.Text = "Registrar" Then
                        Dim resul = user.IngresarUsuario()
                        If resul = -1 Then
                            MsgBox("Ya Existe Un Usuario Con Este Rut")
                        Else
                            MsgBox("Usuario Registrado Con Exito!!")
                            ListaUser.refrescarTabla()
                            Me.Close()
                        End If
                    Else
                        user.ActualizarUsuario()
                        MsgBox("Usuario Actualizado Con Exito!!")
                        ListaUser.refrescarTabla()
                        Me.Close()
                    End If
                End If
            Else
                MsgBox("Rut no valido!!!")
            End If
        End If
    End Sub

    Private Sub xd(sender As Object, e As KeyPressEventArgs) Handles TextBoxPhone.KeyPress
        SoloNumeros(e)
    End Sub
End Class