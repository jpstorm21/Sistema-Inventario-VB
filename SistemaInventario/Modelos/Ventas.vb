Public Class Ventas
    Public tipo As String
    Public medioPago As String
    Public vendedor As String
    Public descripcion As String
    Public total As String
    Public fecha As String
    Public cliente As String
    Public formaVenta As String
    Public rutCliente As String
    Public direccionCliente As String
    Public telefonoCliente As String
    Public Sub New(tipo As String, medioPago As String, vendedor As String, descripcion As String, total As String, cliente As String, formaVenta As String)
        Me.tipo = tipo
        Me.medioPago = medioPago
        Me.vendedor = vendedor
        Me.descripcion = descripcion
        Me.total = total
        Me.cliente = cliente
        Me.formaVenta = formaVenta
    End Sub

    Public Sub New(tipo As String, medioPago As String, vendedor As String, descripcion As String, total As String, fecha As String, cliente As String, formaVenta As String, rutCliente As String, direccionCliente As String, telefonoCliente As String)
        Me.tipo = tipo
        Me.medioPago = medioPago
        Me.vendedor = vendedor
        Me.descripcion = descripcion
        Me.total = total
        Me.fecha = fecha
        Me.cliente = cliente
        Me.formaVenta = formaVenta
        Me.rutCliente = rutCliente
        Me.direccionCliente = direccionCliente
        Me.telefonoCliente = telefonoCliente
    End Sub

    Public Function registrarVenta() As Integer
        DB.Query(String.Format("INSERT INTO Venta (fechaVenta,Tipo,MedioPago,Descripcion,Vendedor,total,Comprador,formaVenta) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Me.tipo, Me.medioPago, Me.descripcion, Me.vendedor, Me.total, Me.cliente, Me.formaVenta))
        Dim tabla = DB.SelectQuery(String.Format("SELECT MAX(codVenta) FROM Venta"))
        Dim cod = tabla.Rows(0).Item(0)
        Return cod
    End Function

    Public Shared Sub registrarProductosVentas(codventa As Integer, cantidad As Integer, codproducto As Integer)
        DB.Query(String.Format("INSERT INTO ProductoVenta (codVenta,cantidad,codProducto) VALUES ({0},{1},{2})", codventa, cantidad, codproducto))
        Dim tabla = DB.SelectQuery(String.Format("SELECT Stock FROM Producto WHERE codProducto = {0}", codproducto))
        Dim stock = tabla.Rows(0).Item(0)
        DB.Query(String.Format("UPDATE Producto SET Stock = {1} WHERE codProducto = {0}", codproducto, stock - cantidad))
    End Sub

    Public Shared Function getVentas() As DataTable
        Return DB.SelectQuery(String.Format("SELECT v.codVenta as Codigo,v.fechaVenta as Fecha,v.Tipo,v.MedioPago,(u.Nombre & ' '& u.Apellidos) as Vendedor,v.total as Total,c.Nombre as Cliente 
                                             FROM Venta v, Usuario u,Cliente c 
                                             WHERE  v.Comprador = c.Rut AND v.Vendedor = u.Rut"))
    End Function

    Public Shared Function getVentasByReporte(fecha1 As Date, fecha2 As Date) As DataTable
        Dim ventas = getVentas()
        Dim table As New DataTable
        table.Columns.Add("Codigo")
        table.Columns.Add("Fecha")
        table.Columns.Add("Tipo")
        table.Columns.Add("MedioPago")
        table.Columns.Add("Vendedor")
        table.Columns.Add("Cliente")
        table.Columns.Add("Total")
        For Each row As DataRow In ventas.Rows
            Dim fecha = row("Fecha")
            If (fecha >= fecha1 And fecha <= fecha2) Then
                table.Rows.Add(row("Codigo"), row("Fecha"), row("Tipo"), row("MedioPago"), row("Vendedor"), row("Cliente"), row("Total"))
            End If
        Next
        Return table
    End Function

    Public Shared Function getVentasByFiltro(cod As String) As DataTable
        Return DB.SelectQuery(String.Format("SELECT v.codVenta as Codigo,v.fechaVenta as Fecha,v.Tipo,v.MedioPago,(u.Nombre & ' '& u.Apellidos) as Vendedor,v.total,c.Nombre as Cliente 
                                             FROM Venta v, Usuario u,Cliente c 
                                             WHERE v.Comprador = c.Rut AND v.Vendedor = u.Rut AND 
                                                    (((v.codVenta) LIKE '%{0}%') OR ((v.fechaVenta) LIKE '%{0}%') OR
                                                    ((v.Tipo) LIKE '%{0}%') OR ((v.MedioPago) LIKE '%{0}%')
                                                    OR (((u.Nombre & ' '& u.Apellidos)) LIKE '%{0}%') OR ((v.total) LIKE '%{0}%') OR ((c.Nombre) LIKE '%{0}%'))", cod))
    End Function

    Public Shared Function getVenta(cod As String) As Ventas
        Dim tabla = DB.SelectQuery(String.Format("SELECT Tipo,MedioPago,Vendedor,Descripcion,total,fechaVenta,Nombre,formaVenta,Rut,Direccion,Telefono 
                                                  FROM Venta INNER JOIN Cliente ON Venta.Comprador = Cliente.Rut WHERE codVenta = {0}", cod))
        If tabla.Rows.Count > 0 Then
            Dim data = tabla.Rows(0).ItemArray
            Return New Ventas(data(0), data(1), data(2), data(3), data(4), data(5), data(6), data(7), data(8), data(9), data(10))
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function getProductosByVenta(cod As String) As DataTable
        Return DB.SelectQuery(String.Format("SELECT p.Nombre, pv.cantidad,ph.Precio
                                             FROM ProductoVenta pv, Producto p,PrecioHistorico ph
                                             WHERE ph.codProducto = p.codProducto AND pv.codProducto = p.codProducto AND 
                                                   ph.Fecha = (SELECT MAX(ph2.Fecha)
                                                               FROM   PrecioHistorico ph2
                                                               WHERE  ph2.codProducto = p.codProducto) AND pv.codVenta = {0}", cod))
    End Function

End Class
