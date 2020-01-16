Public Class Cliente
    Public rut As String
    Public nombre As String
    Public direccion As String
    Public telefono As String

    Public Sub New(rut As String, nombre As String, direccion As String, telefono As String)
        Me.rut = rut
        Me.nombre = nombre
        Me.direccion = direccion
        Me.telefono = telefono
    End Sub

    Public Function ingresarCliente() As Integer
        Dim tabla = DB.SelectQuery(String.Format("SELECT count(*)
                                                  FROM Cliente
                                                  WHERE Rut LIKE '{0}'", Me.rut))
        If tabla.Rows(0).Item(0) > 0 Then
            Return -1
        Else
            DB.Query(String.Format("INSERT INTO Cliente (Rut,Nombre,Direccion,Telefono) VALUES ('{0}','{1}','{2}','{3}')", Me.rut, Me.nombre, Me.direccion, Me.telefono))
            Return 1
        End If
    End Function

    Public Shared Function getClientes() As DataTable
        Return DB.SelectQuery(String.Format("SELECT Rut, Nombre FROM Cliente"))
    End Function

    Public Shared Function getClientesByData() As DataTable
        Return DB.SelectQuery(String.Format("SELECT Rut,Nombre,Direccion as Dirección, Telefono FROM Cliente"))
    End Function

    Public Shared Function getClienteByRut(rut As String) As Cliente
        Dim tabla = DB.SelectQuery(String.Format("SELECT Rut,Nombre,Direccion as Dirección, Telefono FROM Cliente WHERE Rut = '{0}'", rut))
        If tabla.Rows.Count > 0 Then
            Dim data = tabla.Rows(0).ItemArray
            Return New Cliente(data(0), data(1), data(2), data(3))
        Else
            Return Nothing
        End If
    End Function
    Public Sub ActualizarCliente()
        DB.Query(String.Format("UPDATE Cliente SET Nombre = '{1}', Direccion = '{2}', Telefono = '{3}' WHERE Rut = '{0}'", Me.rut, Me.nombre, Me.direccion, Me.telefono))
    End Sub

    Public Shared Function getClientesById(id As String) As DataTable
        Return DB.SelectQuery(String.Format("SELECT Rut,Nombre,Direccion as Dirección, Telefono 
                                             FROM Cliente
                                             WHERE (((Rut) LIKE '%{0}%') OR ((Nombre) LIKE '%{0}%') OR
                                                    ((Direccion) LIKE '%{0}%') OR ((Telefono) LIKE '%{0}%'))", id))
    End Function

    Public Shared Function getComprasByCliente(rut As String) As DataTable
        Return DB.SelectQuery(String.Format("SELECT v.codVenta as Codigo,v.fechaVenta as Fecha,v.Tipo,v.MedioPago,(u.Nombre & ' '& u.Apellidos) as Vendedor,v.total as Total  
                                             FROM Venta v, Usuario u
                                             WHERE v.Vendedor = u.Rut AND v.Comprador = '{0}'", rut))
    End Function

    Public Shared Function getComprasByClienteFiltro(rut As String, cod As String) As DataTable
        Return DB.SelectQuery(String.Format("SELECT v.codVenta as Codigo,v.fechaVenta as Fecha,v.Tipo,v.MedioPago,(u.Nombre & ' '& u.Apellidos) as Vendedor,v.total as Total  
                                             FROM Venta v, Usuario u
                                             WHERE v.Vendedor = u.Rut AND v.Comprador = '{1}' AND 
                                                    (((v.codVenta) LIKE '%{0}%') OR ((v.fechaVenta) LIKE '%{0}%') OR
                                                    ((v.Tipo) LIKE '%{0}%') OR ((v.MedioPago) LIKE '%{0}%')
                                                    OR (((u.Nombre & ' '& u.Apellidos)) LIKE '%{0}%') OR ((v.total) LIKE '%{0}%'))", cod, rut))
    End Function

End Class
