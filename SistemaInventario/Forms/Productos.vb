Imports System.ComponentModel

Public Class Productos

    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Font = New Font(Label1.Font.Name, 18)
        Label2.Font = New Font(Label2.Font.Name, 12)
        DataGridView1.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        DataGridView1.MultiSelect = False
        refrescarTabla()
    End Sub

    Public Sub refrescarTabla()
        DataGridView1.DataSource = Producto.getProductos()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.ClearSelection()
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells("Stock").Value <= DataGridView1.Rows(i).Cells("StockMin").Value Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            ElseIf DataGridView1.Rows(i).Cells("Stock").Value - 10 <= DataGridView1.Rows(i).Cells("StockMin").Value Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            ElseIf DataGridView1.Rows(i).Cells("Stock").Value - 10 >= DataGridView1.Rows(i).Cells("StockMin").Value Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Green
            End If
        Next
        DataGridView1.AllowUserToAddRows = False
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim text = TextBox2.Text
        If text = "" Then
            refrescarTabla()
        Else
            DataGridView1.DataSource = Producto.getProductosByFiltro(text)
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.ClearSelection()
            For i = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells("Stock").Value <= DataGridView1.Rows(i).Cells("StockMin").Value Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
                ElseIf DataGridView1.Rows(i).Cells("Stock").Value - 10 <= DataGridView1.Rows(i).Cells("StockMin").Value Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                ElseIf DataGridView1.Rows(i).Cells("Stock").Value - 10 >= DataGridView1.Rows(i).Cells("StockMin").Value Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Green
                End If
            Next
            DataGridView1.AllowUserToAddRows = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim productoForm As New ProductoForm(Me, -1)
        productoForm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MsgBox("Seleccione Un Producto Para Editar")
        Else
            Dim cod As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
            Dim productoForm As New ProductoForm(Me, cod)
            productoForm.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cateForm As New TipoForm()
        cateForm.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim gestion As New GestionStock(Me)
        gestion.Show()
    End Sub
End Class