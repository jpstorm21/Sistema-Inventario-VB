﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PanelBarraTitulo = New System.Windows.Forms.Panel()
        Me.btnMinimizar = New System.Windows.Forms.Button()
        Me.btnMaximizar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.user = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnDashBoard = New System.Windows.Forms.Button()
        Me.PanelContenedor = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PanelBarraTitulo.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBarraTitulo
        '
        Me.PanelBarraTitulo.BackColor = System.Drawing.Color.DarkSlateGray
        Me.PanelBarraTitulo.Controls.Add(Me.btnMinimizar)
        Me.PanelBarraTitulo.Controls.Add(Me.btnMaximizar)
        Me.PanelBarraTitulo.Controls.Add(Me.btnCerrar)
        Me.PanelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBarraTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PanelBarraTitulo.Name = "PanelBarraTitulo"
        Me.PanelBarraTitulo.Size = New System.Drawing.Size(1280, 40)
        Me.PanelBarraTitulo.TabIndex = 0
        '
        'btnMinimizar
        '
        Me.btnMinimizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimizar.FlatAppearance.BorderSize = 0
        Me.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod
        Me.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimizar.ForeColor = System.Drawing.Color.White
        Me.btnMinimizar.Image = Global.SistemaInventario.My.Resources.Resources.Icono_Minimizar
        Me.btnMinimizar.Location = New System.Drawing.Point(1194, 3)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(40, 40)
        Me.btnMinimizar.TabIndex = 6
        Me.btnMinimizar.Text = ""
        Me.btnMinimizar.UseVisualStyleBackColor = True
        '
        'btnMaximizar
        '
        Me.btnMaximizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximizar.FlatAppearance.BorderSize = 0
        Me.btnMaximizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod
        Me.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaximizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaximizar.ForeColor = System.Drawing.Color.White
        Me.btnMaximizar.Location = New System.Drawing.Point(1197, 0)
        Me.btnMaximizar.Name = "btnMaximizar"
        Me.btnMaximizar.Size = New System.Drawing.Size(40, 40)
        Me.btnMaximizar.TabIndex = 5
        Me.btnMaximizar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(1240, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(40, 40)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.PanelMenu.Controls.Add(Me.Panel3)
        Me.PanelMenu.Controls.Add(Me.Button4)
        Me.PanelMenu.Controls.Add(Me.user)
        Me.PanelMenu.Controls.Add(Me.PictureBox1)
        Me.PanelMenu.Controls.Add(Me.Panel5)
        Me.PanelMenu.Controls.Add(Me.Button3)
        Me.PanelMenu.Controls.Add(Me.Panel4)
        Me.PanelMenu.Controls.Add(Me.Button1)
        Me.PanelMenu.Controls.Add(Me.Button2)
        Me.PanelMenu.Controls.Add(Me.Panel2)
        Me.PanelMenu.Controls.Add(Me.btnProductos)
        Me.PanelMenu.Controls.Add(Me.Panel10)
        Me.PanelMenu.Controls.Add(Me.btnDashBoard)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 40)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(220, 680)
        Me.PanelMenu.TabIndex = 1
        '
        'user
        '
        Me.user.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.user.Location = New System.Drawing.Point(24, 19)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(190, 39)
        Me.user.TabIndex = 17
        Me.user.Text = "Label2"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(54, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 81)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(3, 275)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(5, 50)
        Me.Panel5.TabIndex = 6
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImageKey = "(ninguno)"
        Me.Button3.Location = New System.Drawing.Point(5, 443)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(209, 50)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Cerrar Sesión"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Location = New System.Drawing.Point(3, 331)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(5, 50)
        Me.Panel4.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(5, 50)
        Me.Panel1.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(7, 331)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(209, 50)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Usuarios"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(8, 219)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(209, 50)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "  Ventas"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(3, 219)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(5, 50)
        Me.Panel2.TabIndex = 3
        '
        'btnProductos
        '
        Me.btnProductos.FlatAppearance.BorderSize = 0
        Me.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductos.ForeColor = System.Drawing.Color.White
        Me.btnProductos.Image = CType(resources.GetObject("btnProductos.Image"), System.Drawing.Image)
        Me.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProductos.Location = New System.Drawing.Point(8, 163)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(209, 50)
        Me.btnProductos.TabIndex = 2
        Me.btnProductos.Text = "  Productos"
        Me.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Panel10.Location = New System.Drawing.Point(3, 163)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(5, 50)
        Me.Panel10.TabIndex = 1
        '
        'btnDashBoard
        '
        Me.btnDashBoard.FlatAppearance.BorderSize = 0
        Me.btnDashBoard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.btnDashBoard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashBoard.ForeColor = System.Drawing.Color.White
        Me.btnDashBoard.Image = CType(resources.GetObject("btnDashBoard.Image"), System.Drawing.Image)
        Me.btnDashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashBoard.Location = New System.Drawing.Point(8, 275)
        Me.btnDashBoard.Name = "btnDashBoard"
        Me.btnDashBoard.Size = New System.Drawing.Size(208, 50)
        Me.btnDashBoard.TabIndex = 0
        Me.btnDashBoard.Text = "Reportes"
        Me.btnDashBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashBoard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDashBoard.UseVisualStyleBackColor = True
        '
        'PanelContenedor
        '
        Me.PanelContenedor.BackColor = System.Drawing.SystemColors.Control
        Me.PanelContenedor.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContenedor.Location = New System.Drawing.Point(220, 40)
        Me.PanelContenedor.Name = "PanelContenedor"
        Me.PanelContenedor.Size = New System.Drawing.Size(1060, 680)
        Me.PanelContenedor.TabIndex = 2
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(5, 387)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(209, 50)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Clientes"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Location = New System.Drawing.Point(3, 387)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(5, 50)
        Me.Panel3.TabIndex = 9
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(0, 45)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(5, 50)
        Me.Panel6.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.PanelContenedor)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.PanelBarraTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.PanelBarraTitulo.ResumeLayout(False)
        Me.PanelMenu.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBarraTitulo As System.Windows.Forms.Panel
    Friend WithEvents PanelMenu As System.Windows.Forms.Panel
    Friend WithEvents PanelContenedor As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnProductos As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnMaximizar As System.Windows.Forms.Button
    Friend WithEvents btnMinimizar As System.Windows.Forms.Button
    Friend WithEvents btnDashBoard As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents user As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Button4 As Button
End Class
