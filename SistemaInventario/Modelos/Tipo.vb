Public Class Tipo
    Public tipo As String

    Public Sub New(tipo As String)
        Me.tipo = tipo
    End Sub

    Public Sub insertarTipo()
        DB.Query(String.Format("INSERT INTO Tipo(Nombre) VALUES('{0}')", Me.tipo))
    End Sub
End Class
