Public Class Usuarios
    Public rut As String
    Public nombre As String
    Public apellido As String
    Public rol As Integer
    Public pass As String
    Public telefono As String

    Public Sub New(rut As String, nombre As String, apellido As String, rol As Integer, pass As String, telefono As String)
        Me.rut = rut
        Me.nombre = nombre
        Me.apellido = apellido
        Me.rol = rol
        Me.pass = pass
        Me.telefono = telefono
    End Sub

    Public Shared Function obtenerUsuario(id As String) As Usuarios
        Dim tabla = DB.SelectQuery(String.Format("SELECT Rut,Nombre,Apellidos,idRol,pass,telefono FROM Usuario WHERE Rut = '{0}'", id))
        If tabla.Rows.Count > 0 Then
            Dim data = tabla.Rows(0).ItemArray
            Return New Usuarios(data(0), data(1), data(2), data(3), data(4), data(5))
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function getUsuarios() As DataTable
        Return DB.SelectQuery(String.Format("SELECT u.Rut, u.Nombre as Nombres,u.Apellidos,r.NombreRol as Cargo, u.telefono
                                             FROM Usuario u INNER JOIN Rol r ON u.idRol = r.Id"))
    End Function

    Public Shared Function getRoles() As DataTable
        Return DB.SelectQuery(String.Format("SELECT Id, NombreRol FROM Rol"))
    End Function

    Public Function IngresarUsuario() As Integer
        Dim tabla = DB.SelectQuery(String.Format("SELECT count(*)
                                                  FROM usuario
                                                  WHERE Rut LIKE '{0}'", Me.rut))
        If tabla.Rows(0).Item(0) > 0 Then
            Return -1
        Else
            DB.Query(String.Format("INSERT INTO Usuario (Rut,Nombre,Apellidos,idRol,pass,telefono) VALUES ('{0}','{1}','{2}',{3},'{4}','{5}')", Me.rut, Me.nombre, Me.apellido, Me.rol, Me.pass, Me.telefono))
            Return 1
        End If
    End Function

    Public Sub ActualizarUsuario()
        DB.Query(String.Format("UPDATE Usuario SET Nombre ='{1}',Apellidos ='{2}',
                                                   idRol = {3},pass ='{4}',telefono = '{5}' WHERE Rut = '{0}'", Me.rut, Me.nombre, Me.apellido, Me.rol, Me.pass, Me.telefono))
    End Sub

    Public Shared Function getUsersById(id As String) As DataTable
        Return DB.SelectQuery(String.Format("SELECT u.Rut, u.Nombre as Nombres,u.Apellidos,r.NombreRol as Cargo,u.telefono 
                                             FROM Usuario u INNER JOIN Rol r ON u.idRol = r.Id WHERE (((u.Rut) LIKE '%{0}%') OR ((u.Nombre) LIKE '%{0}%') OR
                                                                                                       ((u.Apellidos) LIKE '%{0}%') OR ((r.NombreRol) LIKE '%{0}%')
                                                                                                        OR ((u.telefono) LIKE '%{0}%'))", id))
    End Function

End Class
