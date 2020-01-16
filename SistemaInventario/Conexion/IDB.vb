Public Interface IDB
    Function SelectQuery(consulta As String) As DataTable
    Sub Query(consulta As String)
End Interface
