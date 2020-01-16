Public Class Auth

    Public Shared nombreUsuarioLogueado As String = ""
    Public Shared rutUsuarioLogueado As String = ""
    Private usuario As String
    Private password As String

    Public Sub New(usuario As String, password As String)
        Me.usuario = usuario
        Me.password = password
    End Sub

    Public Function Login() As Boolean
        Dim tabla = DB.SelectQuery(String.Format("SELECT count(*)
                                                  FROM usuario
                                                  WHERE Rut LIKE '{0}' AND pass LIKE '{1}'", Me.usuario, Me.password))
        Return tabla.Rows(0).Item(0) > 0
    End Function

    Public Shared Function getRol(rut As String) As String
        Dim tabla = DB.SelectQuery(String.Format("SELECT r.NombreRol
                                                  FROM usuario u INNER JOIN Rol r ON u.idRol = r.Id
                                                  WHERE Rut LIKE '{0}'", rut))
        Return tabla.Rows(0).Item(0)
    End Function

    Public Shared Function VerificaRUT(ByVal codigo As String) As Boolean
        Dim rut As Long
        Dim bRet As Boolean
        Dim digitoControl As String

        Try

            bRet = False
            codigo = codigo.Trim.ToUpper

            Dim largo As Integer = codigo.Length
            Dim penultimo As Integer = largo - 2
            Dim ultimo As Integer = largo - 1

            'Si tiene menos de 8 caractéres es incorrecto
            If (largo < 6 Or largo > 12) Then Return False

            For i As Integer = 0 To ultimo
                Dim c As Char = CChar(codigo.Substring(i, 1))

                If i < ultimo Then
                    'Solo admite numeros antes del ultimo caracter
                    If Asc(c) < 48 Or Asc(c) > 57 Then Return False
                Else
                    'Solo admite numeros o K mayúscula en el digito de control.
                    If (Asc(c) < 48 And Asc(c) > 57) And (Asc(c) <> 75) Then Return False 'K
                End If

            Next

            rut = CType(codigo.Substring(0, codigo.Length - 1), Long)
            Dim digitoControlEsperado As String = Right(codigo, 1)

            digitoControl = RutDigito(rut)

            If digitoControl = digitoControlEsperado Then
                bRet = True
            End If

        Catch ex As Exception
            bRet = False


        End Try
        Return bRet

    End Function

    Private Shared Function RutDigito(ByVal Rut As Long) As String
        Dim Digito As Long
        Dim Contador As Long
        Dim Multiplo As Long
        Dim Acumulador As Long

        Contador = 2
        Acumulador = 0
        While Rut <> 0
            Multiplo = (Rut Mod 10) * Contador
            Acumulador = Acumulador + Multiplo
            Rut = Rut \ 10
            Contador = Contador + 1
            If Contador = 8 Then
                Contador = 2
            End If
        End While
        Digito = 11 - (Acumulador Mod 11)
        RutDigito = CStr(Digito)
        If Digito = 10 Then RutDigito = "K"
        If Digito = 11 Then RutDigito = "0"
    End Function


End Class
