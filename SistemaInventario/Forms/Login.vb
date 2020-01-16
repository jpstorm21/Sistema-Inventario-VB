Public Class Login
    Private Sub Clickeame_Click(sender As Object, e As EventArgs) Handles Clickeame.Click
        Dim rut As String = TextBoxRut.Text
        Dim pass = TextBoxPass.Text
        If rut = "" Or pass = "" Then
            MsgBox("Campos se encuentran vacios")
        Else
            Dim valido = Auth.VerificaRUT(rut)
            If valido Then
                Dim auth As New Auth(rut, pass)
                If auth.Login() Then
                    Auth.nombreUsuarioLogueado = rut
                    Dim productos As New Form1(rut)
                    productos.Show()
                    Me.Close()
                Else
                    MsgBox("Rut y/o Contraseña Incorrectos")
                End If
            Else
                MsgBox("Rut no valido!!!")
            End If
        End If
    End Sub
End Class
