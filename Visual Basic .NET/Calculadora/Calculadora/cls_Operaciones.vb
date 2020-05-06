Public Class cls_Operaciones
    Private pOperador_1 As Single
    Private pOperador_2 As Single
    Private pOperacion As String

    Public Property Operador_1() As Single
        Get
            Return pOperador_1
        End Get
        Set(ByVal value As Single)
            pOperador_1 = value
        End Set
    End Property

    Public Property Operador_2() As Single
        Get
            Return pOperador_2
        End Get
        Set(ByVal value As Single)
            pOperador_2 = value
        End Set
    End Property

    Public Property Operacion() As String
        Get
            Return pOperacion
        End Get
        Set(ByVal value As String)
            pOperacion = value
        End Set
    End Property

    Public Function Calcula_Operacion() As Single
        Dim sng_Resultado As Single

        Select Case Operacion
            Case "/"
                '   División
                sng_Resultado = Operador_1 / Operador_2
            Case "*"
                '   Multiplicación
                sng_Resultado = Operador_1 * Operador_2
            Case "-"
                '   Resta
                sng_Resultado = Operador_1 - Operador_2
            Case Else
                '   Suma
                sng_Resultado = Operador_1 + Operador_2
        End Select

        Return sng_Resultado
    End Function
End Class
