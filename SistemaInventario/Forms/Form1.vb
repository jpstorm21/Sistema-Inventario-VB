Imports System.Runtime.InteropServices
Public Class Form1
    Public usuario As Usuarios

    Sub New(rut As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        user.Font = New Font(user.Font.Name, 12)
        PictureBox1.Image = My.Resources.icono_inventario
        'PictureBox2.Image = My.Resources.fondo2
        usuario = Usuarios.obtenerUsuario(rut)
        user.Text = usuario.nombre + " " + usuario.apellido
        'Label1.Font = New Font(Label1.Font.Name, 32)
        ' Label2.Font = New Font(Label2.Font.Name, 28)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim rol As String = Auth.getRol(usuario.rut)
        If rol = "Trabajador" Then
            Button1.Visible = False
            Panel4.Visible = False
            Panel5.Visible = False
            btnDashBoard.Visible = False
        End If
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub PanelBarraTitulo_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelBarraTitulo.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub AbrirFormEnPanel(ByVal Formhijo As Object)
        If Me.PanelContenedor.Controls.Count > 0 Then Me.PanelContenedor.Controls.RemoveAt(0)
        Dim fh As Form = TryCast(Formhijo, Form)
        fh.TopLevel = False
        fh.FormBorderStyle = FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.PanelContenedor.Controls.Add(fh)
        Me.PanelContenedor.Tag = fh
        fh.Show()

    End Sub


    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        'AbrirFormEnPanel(New Productos)
        If Me.PanelContenedor.Controls.Count > 0 Then Me.PanelContenedor.Controls.RemoveAt(0)
        Dim fh As New Productos
        fh.TopLevel = False
        fh.FormBorderStyle = FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        fh.Show()
        Me.PanelContenedor.Controls.Add(fh)
        Me.PanelContenedor.Tag = fh

    End Sub

    Private Sub btnDashBoard_Click(sender As Object, e As EventArgs) Handles btnDashBoard.Click
        AbrirFormEnPanel(New Reportes)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Application.Exit()
    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AbrirFormEnPanel(New ListaVentas)
    End Sub

    Private Sub PanelContenedor_Paint(sender As Object, e As PaintEventArgs) Handles PanelContenedor.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim login As New Login
        login.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AbrirFormEnPanel(New ListaUsuarios)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AbrirFormEnPanel(New ListaClientes)
    End Sub
End Class
