Public Class DB

    Private Shared db As IDB = New DBAccess

    Public Shared Function SelectQuery(consulta As String) As DataTable
        Return db.SelectQuery(consulta)

    End Function

    Public Shared Sub Query(consulta As String)
        db.Query(consulta)
    End Sub

End Class

