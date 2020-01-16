Public Class TipoForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tipo = TextBox1.Text
        If tipo = "" Then
            MsgBox("Campo se encuentra vacio!!")
        Else
            Dim tip As New Tipo(tipo)
            tip.insertarTipo()
            MsgBox("Tipo Registrado")
            Me.Close()
        End If
    End Sub

    Sub SoloNumeros(ByRef e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            MsgBox("Solo se puede ingresar Letras", MsgBoxStyle.Exclamation)
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub Number(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        SoloNumeros(e)
    End Sub

End Class