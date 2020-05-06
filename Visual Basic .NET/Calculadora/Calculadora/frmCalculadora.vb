Public Class frmCalculadora
    Dim obj_Operaciones As New cls_Operaciones
    Dim bln_Hizoperacion As Boolean
    Dim str_Operador_1 As String = vbNullString
    Dim str_Operador_2 As String = vbNullString

    Private Sub btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Limpiar.Click
        rt_Limpiar()
    End Sub

    Private Sub btn_Siete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Siete.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Siete.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Siete.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Siete.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Siete.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub rt_Limpiar()
        obj_Operaciones.Operador_1 = 0
        obj_Operaciones.Operador_2 = 0
        obj_Operaciones.Operacion = vbNullString
        Me.lbl_Display.Text = vbNullString
        bln_Hizoperacion = False
        str_Operador_1 = vbNullString
        str_Operador_2 = vbNullString
    End Sub

    Private Sub rt_Mostrar(ByVal Texto As String)
        Dim int_Posicion As Integer = 0

        If bln_Hizoperacion = False Then
            Me.lbl_Display.Text = vbNullString
            Me.lbl_Display.Text = Texto.Trim()
        Else
            int_Posicion = InStr(Me.lbl_Display.Text, "/")
            If int_Posicion = 0 Then
                int_Posicion = InStr(Me.lbl_Display.Text, "*")
                If int_Posicion = 0 Then
                    int_Posicion = InStr(Me.lbl_Display.Text, "-")
                    If int_Posicion = 0 Then
                        int_Posicion = InStr(Me.lbl_Display.Text, "+")
                        If int_Posicion = 0 Then
                            int_Posicion = InStr(Me.lbl_Display.Text, "=")
                            If int_Posicion = 0 Then
                                int_Posicion = InStr(Me.lbl_Display.Text, ".")
                                If int_Posicion = 0 Then
                                    Me.lbl_Display.Text = Me.lbl_Display.Text.Trim() + Texto.Trim()
                                Else
                                    Me.lbl_Display.Text = Me.lbl_Display.Text.Substring(0, Len(Me.lbl_Display.Text)) + Texto.Trim()
                                End If
                            Else
                                Me.lbl_Display.Text = Me.lbl_Display.Text.Substring(0, int_Posicion) + Texto.Trim()
                            End If
                        Else
                            Me.lbl_Display.Text = Me.lbl_Display.Text.Substring(0, int_Posicion) + Texto.Trim()
                        End If
                    Else
                        Me.lbl_Display.Text = Me.lbl_Display.Text.Substring(0, int_Posicion) + Texto.Trim()
                    End If
                Else
                    Me.lbl_Display.Text = Me.lbl_Display.Text.Substring(0, int_Posicion) + Texto.Trim()
                End If
            Else
                Me.lbl_Display.Text = Me.lbl_Display.Text.Substring(0, int_Posicion) + Texto.Trim()
            End If
        End If
    End Sub

    Private Sub frmCalculadora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rt_Limpiar()
    End Sub

    Private Sub btn_Dividir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Dividir.Click
        bln_Hizoperacion = True
        obj_Operaciones.Operacion = "/"
        rt_Mostrar(obj_Operaciones.Operacion)
    End Sub

    Private Sub btn_Multiplar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Multiplar.Click
        bln_Hizoperacion = True
        obj_Operaciones.Operacion = "*"
        rt_Mostrar(obj_Operaciones.Operacion)
    End Sub

    Private Sub btn_Restar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Restar.Click
        bln_Hizoperacion = True
        obj_Operaciones.Operacion = "-"
        rt_Mostrar(obj_Operaciones.Operacion)
    End Sub

    Private Sub btn_Sumar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Sumar.Click
        bln_Hizoperacion = True
        obj_Operaciones.Operacion = "+"
        Me.Tag = obj_Operaciones.Operacion
        rt_Mostrar(Me.Tag)
    End Sub

    Private Sub btn_Igual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Igual.Click
        If obj_Operaciones.Operador_1 > 0 And obj_Operaciones.Operador_2 > 0 And _
           obj_Operaciones.Operacion <> vbNullString Then
            Me.lbl_Display.Text = Me.lbl_Display.Text.Trim() + Me.btn_Igual.Text.Trim() + CStr(obj_Operaciones.Calcula_Operacion)
        Else
            MessageBox.Show("Seleccione 2 números y la operación a realizar", "Calculadora", MessageBoxButtons.OK)
            Me.btn_Uno.Focus()
        End If
        bln_Hizoperacion = False
    End Sub

    Private Sub btn_Ocho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ocho.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Ocho.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Ocho.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Ocho.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Ocho.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Nueve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Nueve.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Nueve.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Nueve.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Nueve.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Nueve.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Cuatro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cuatro.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Cuatro.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Cuatro.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Cuatro.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Cuatro.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Cinco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cinco.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Cinco.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Cinco.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Cinco.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Cinco.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Seis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Seis.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Seis.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Seis.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Seis.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Seis.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Uno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Uno.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Uno.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Uno.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Uno.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Uno.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Dos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Dos.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Dos.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Dos.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Dos.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Dos.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Tres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Tres.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Tres.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Tres.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Tres.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Tres.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Cero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cero.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Cero.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Cero.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(CStr(obj_Operaciones.Operador_1))
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Cero.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Cero.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(CStr(obj_Operaciones.Operador_2))
            End If
        End If
    End Sub

    Private Sub btn_Punto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Punto.Click
        If obj_Operaciones.Operador_1 = 0 Then
            obj_Operaciones.Operador_1 = CSng(Me.btn_Punto.Text)
            str_Operador_1 = obj_Operaciones.Operador_1
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = False Then
            str_Operador_1 = str_Operador_1.Trim() + Me.btn_Punto.Text.Trim()
            obj_Operaciones.Operador_1 = CSng(str_Operador_1)
            rt_Mostrar(str_Operador_1)
        ElseIf bln_Hizoperacion = True Then
            If obj_Operaciones.Operador_2 = 0 Then
                obj_Operaciones.Operador_2 = CSng(Me.btn_Punto.Text)
                str_Operador_2 = obj_Operaciones.Operador_2
                rt_Mostrar(str_Operador_2)
            Else
                str_Operador_2 = str_Operador_2.Trim() + Me.btn_Punto.Text.Trim()
                obj_Operaciones.Operador_2 = CSng(str_Operador_2)
                rt_Mostrar(str_Operador_2)
            End If
        End If
    End Sub
End Class
