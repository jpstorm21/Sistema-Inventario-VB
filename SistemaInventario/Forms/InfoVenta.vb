Public Class InfoVenta

    Public venta As Ventas

    Sub New(cod As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Label1.Font = New Font(Label1.Font.Name, 12)
        Label2.Font = New Font(Label2.Font.Name, 12)
        Label3.Font = New Font(Label3.Font.Name, 12)
        Label4.Font = New Font(Label4.Font.Name, 12)
        Label5.Font = New Font(Label5.Font.Name, 12)
        Label6.Font = New Font(Label6.Font.Name, 12)
        Label7.Font = New Font(Label7.Font.Name, 12)
        Label8.Font = New Font(Label8.Font.Name, 12)
        Label9.Font = New Font(Label9.Font.Name, 12)
        Label10.Font = New Font(Label10.Font.Name, 12)
        Label11.Font = New Font(Label11.Font.Name, 12)
        Label12.Font = New Font(Label12.Font.Name, 12)
        Label14.Font = New Font(Label14.Font.Name, 12)
        Label13.Font = New Font(Label13.Font.Name, 12)
        Label15.Font = New Font(Label15.Font.Name, 12)
        Label16.Font = New Font(Label16.Font.Name, 12)
        RichTextBox1.Font = New Font(RichTextBox1.Font.Name, 11)
        DataGridView1.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 11)
        venta = Ventas.getVenta(cod)
        Label10.Text = cod
        Label9.Text = venta.total
        RichTextBox1.Text = venta.descripcion
        Label7.Text = venta.medioPago
        Label8.Text = venta.tipo
        Label12.Text = venta.fecha
        Label15.Text = venta.cliente
        Label13.Text = venta.formaVenta
        Label17.Text = venta.rutCliente
        Label19.Text = venta.telefonoCliente
        Label22.Text = venta.direccionCliente
        DataGridView1.DataSource = Ventas.getProductosByVenta(cod)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.ClearSelection()
        DataGridView1.AllowUserToAddRows = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class