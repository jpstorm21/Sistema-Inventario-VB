Public Class Producto
    Public nombre As String
    Public tipo As String
    Public stock As Integer
    Public stockMin As Integer
    Public medicion As String
    Public precio As String
    Public codigo As Integer

    Public Sub New(nombre As String, tipo As String, stock As Integer, stockMin As Integer, medicion As String, precio As String)
        Me.nombre = nombre
        Me.tipo = tipo
        Me.stock = stock
        Me.stockMin = stockMin
        Me.medicion = medicion
        Me.precio = precio
    End Sub

    Public Sub New(codigo As Integer, nombre As String, tipo As String, stock As Integer, stockMin As Integer, medicion As String, precio As String)
        Me.codigo = codigo
        Me.nombre = nombre
        Me.tipo = tipo
        Me.stock = stock
        Me.stockMin = stockMin
        Me.medicion = medicion
        Me.precio = precio
    End Sub

    Public Shared Function getProductos() As DataTable
        Return DB.SelectQuery(String.Format("SELECT p.codProducto as codigo ,p.Nombre as Nombre ,t.Nombre as Tipo,p.Stock,p.StockMin,p.Medicion, ph.Precio
                                             FROM Producto p, PrecioHistorico ph,Tipo t
                                             WHERE p.codProducto = ph.codProducto AND p.Tipo = t.IdTipo AND
                                                   ph.Fecha = (SELECT MAX(ph2.Fecha)
                                                               FROM   PrecioHistorico ph2
                                                               WHERE  ph2.codProducto = p.codProducto)"))
    End Function

    Public Shared Function getProductosByFiltro(id As String) As DataTable
        Return DB.SelectQuery(String.Format("SELECT p.codProducto as codigo ,p.Nombre as Nombre,t.Nombre as Tipo,p.Stock,p.StockMin,p.Medicion, ph.Precio
                                             FROM Producto p, PrecioHistorico ph,Tipo T
                                             WHERE p.codProducto = ph.codProducto AND p.Tipo = t.IdTipo AND
                                                   ph.Fecha = (SELECT MAX(ph2.Fecha)
                                                               FROM   PrecioHistorico ph2
                                                               WHERE  ph2.codProducto = p.codProducto) AND
                                                   (((p.codProducto) LIKE '%{0}%') OR ((p.Nombre) LIKE '%{0}%') OR
                                                                                                       ((t.Nombre) LIKE '%{0}%') OR ((p.Stock) LIKE '%{0}%')
                                                                                                        OR ((p.StockMin) LIKE '%{0}%') OR ((p.Medicion) LIKE '%{0}%')
                                                                                                        OR ((ph.Precio) LIKE '%{0}%'))", id))
    End Function

    Public Shared Function getTipos() As DataTable
        Return DB.SelectQuery(String.Format("SELECT IdTipo,Nombre FROM Tipo"))
    End Function

    Public Sub insertarProducto()
        DB.Query(String.Format("INSERT INTO Producto (Nombre,Tipo,Stock,StockMin,Medicion) VALUES ('{0}',{1},{2},{3},'{4}')", Me.nombre, Me.tipo, Me.stock, Me.stockMin, Me.medicion))
        Dim tabla = DB.SelectQuery(String.Format("SELECT MAX(codProducto)
                                                  FROM Producto"))
        Dim cod = tabla.Rows(0).Item(0)
        DB.Query(String.Format("INSERT INTO PrecioHistorico (codProducto,Fecha,Precio) VALUES ({0},'{1}','{2}')", cod, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Me.precio))
        DB.Query(String.Format("INSERT INTO ProductoIngreso (codProducto,fecha,cantidad,comentario,movimiento) VALUES ({0},'{1}',{2},'{3}','{4}')", cod, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Me.stock, "", "Ingresar"))
    End Sub

    Public Shared Function getProducto(cod As Integer) As Producto
        Dim tabla = DB.SelectQuery(String.Format("SELECT p.Nombre,p.Tipo,p.Stock,p.StockMin,p.Medicion, ph.Precio
                                                  FROM Producto p INNER JOIN PrecioHistorico ph ON p.codProducto = ph.codProducto
                                                  WHERE ph.Fecha = (SELECT MAX(ph2.Fecha)
                                                                    FROM   PrecioHistorico ph2
                                                                    WHERE  ph2.codProducto = p.codProducto)
                                                        AND p.codProducto = {0}", cod))
        If tabla.Rows.Count > 0 Then
            Dim data = tabla.Rows(0).ItemArray
            Return New Producto(data(0), data(1), data(2), data(3), data(4), data(5))
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function existProductoByName(nombre As String) As Boolean
        Dim tabla = DB.SelectQuery(String.Format("SELECT COUNT(*)
                                                  FROM Producto p
                                                  WHERE p.Nombre = '{0}'", nombre))
        If tabla.Rows(0).Item(0) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ActualizarProducto(cod As Integer)
        Dim tabla = DB.SelectQuery(String.Format("SELECT p.Stock, ph.Precio
                                                  From Producto p INNER Join PrecioHistorico ph ON p.codProducto = ph.codProducto
                                                  Where ph.Fecha = (SELECT MAX(ph2.Fecha)
                                                                    FROM  PrecioHistorico ph2
                                                                    WHERE ph2.codProducto = p.codProducto)
                                                        And p.codProducto = {0}", cod))
        Dim data = tabla.Rows(0).ItemArray
        DB.Query(String.Format("UPDATE Producto SET Nombre = '{1}', Tipo = {2},StockMin = {3},Medicion='{4}',Stock={5} WHERE codProducto = {0}", cod, Me.nombre, Me.tipo, Me.stockMin, Me.medicion, Me.stock))

        If data(1) <> Me.precio Then
            'agregar preciohistorico'
            DB.Query(String.Format("INSERT INTO PrecioHistorico (codProducto,Fecha,Precio) VALUES ({0},'{1}','{2}')", cod, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Me.precio))
        End If
    End Sub

    Public Shared Function getProductosByGestion()
        Return DB.SelectQuery(String.Format("SELECT p.codProducto as Codigo ,p.Nombre as Nombre,p.Stock
                                             FROM Producto p, PrecioHistorico ph
                                             WHERE p.codProducto = ph.codProducto AND
                                                   ph.Fecha = (SELECT MAX(ph2.Fecha)
                                                               FROM   PrecioHistorico ph2
                                                               WHERE  ph2.codProducto = p.codProducto)"))
    End Function

    Public Shared Sub gestionInventario(cod As Integer, comentario As String, cantidad As Integer, stock As Integer, movimiento As String)
        DB.Query(String.Format("INSERT INTO ProductoIngreso (codProducto,fecha,cantidad,comentario,movimiento) VALUES ({0},'{1}',{2},'{3}','{4}')", cod, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), cantidad, comentario, movimiento))
        Dim stockActual = 0
        If movimiento = "Ingresar" Then
            stockActual = stock + cantidad
        Else
            stockActual = stock - cantidad
        End If
        DB.Query(String.Format("UPDATE Producto SET Stock={1} WHERE codProducto = {0}", cod, stockActual))
    End Sub

    Public Shared Function getProductosByFiltro2(id As String) As DataTable
        Return DB.SelectQuery(String.Format("SELECT p.codProducto as Codigo,p.Nombre,p.Stock
                                             FROM Producto p, PrecioHistorico ph
                                             WHERE p.codProducto = ph.codProducto AND
                                                   ph.Fecha = (SELECT MAX(ph2.Fecha)
                                                               FROM   PrecioHistorico ph2
                                                               WHERE  ph2.codProducto = p.codProducto) AND 
                                                   (((p.codProducto) LIKE '%{0}%') OR ((p.Nombre) LIKE '%{0}%') OR
                                                   ((p.Stock) LIKE '%{0}%'))", id))
    End Function
End Class
