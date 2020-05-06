<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalculadora
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl_Display = New System.Windows.Forms.Label
        Me.btn_Siete = New System.Windows.Forms.Button
        Me.btn_Ocho = New System.Windows.Forms.Button
        Me.btn_Nueve = New System.Windows.Forms.Button
        Me.btn_Cuatro = New System.Windows.Forms.Button
        Me.btn_Cinco = New System.Windows.Forms.Button
        Me.btn_Seis = New System.Windows.Forms.Button
        Me.btn_Uno = New System.Windows.Forms.Button
        Me.btn_Dos = New System.Windows.Forms.Button
        Me.btn_Tres = New System.Windows.Forms.Button
        Me.btn_Cero = New System.Windows.Forms.Button
        Me.btn_Punto = New System.Windows.Forms.Button
        Me.btn_Limpiar = New System.Windows.Forms.Button
        Me.btn_Dividir = New System.Windows.Forms.Button
        Me.btn_Multiplar = New System.Windows.Forms.Button
        Me.btn_Restar = New System.Windows.Forms.Button
        Me.btn_Sumar = New System.Windows.Forms.Button
        Me.btn_Igual = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lbl_Display
        '
        Me.lbl_Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_Display.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Display.Location = New System.Drawing.Point(12, 9)
        Me.lbl_Display.Name = "lbl_Display"
        Me.lbl_Display.Size = New System.Drawing.Size(178, 53)
        Me.lbl_Display.TabIndex = 0
        '
        'btn_Siete
        '
        Me.btn_Siete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Siete.Location = New System.Drawing.Point(12, 77)
        Me.btn_Siete.Name = "btn_Siete"
        Me.btn_Siete.Size = New System.Drawing.Size(32, 28)
        Me.btn_Siete.TabIndex = 2
        Me.btn_Siete.Text = "7"
        Me.btn_Siete.UseVisualStyleBackColor = True
        '
        'btn_Ocho
        '
        Me.btn_Ocho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Ocho.Location = New System.Drawing.Point(47, 77)
        Me.btn_Ocho.Name = "btn_Ocho"
        Me.btn_Ocho.Size = New System.Drawing.Size(32, 28)
        Me.btn_Ocho.TabIndex = 3
        Me.btn_Ocho.Text = "8"
        Me.btn_Ocho.UseVisualStyleBackColor = True
        '
        'btn_Nueve
        '
        Me.btn_Nueve.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Nueve.Location = New System.Drawing.Point(82, 77)
        Me.btn_Nueve.Name = "btn_Nueve"
        Me.btn_Nueve.Size = New System.Drawing.Size(32, 28)
        Me.btn_Nueve.TabIndex = 4
        Me.btn_Nueve.Text = "9"
        Me.btn_Nueve.UseVisualStyleBackColor = True
        '
        'btn_Cuatro
        '
        Me.btn_Cuatro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cuatro.Location = New System.Drawing.Point(12, 111)
        Me.btn_Cuatro.Name = "btn_Cuatro"
        Me.btn_Cuatro.Size = New System.Drawing.Size(32, 28)
        Me.btn_Cuatro.TabIndex = 5
        Me.btn_Cuatro.Text = "4"
        Me.btn_Cuatro.UseVisualStyleBackColor = True
        '
        'btn_Cinco
        '
        Me.btn_Cinco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cinco.Location = New System.Drawing.Point(44, 111)
        Me.btn_Cinco.Name = "btn_Cinco"
        Me.btn_Cinco.Size = New System.Drawing.Size(32, 28)
        Me.btn_Cinco.TabIndex = 6
        Me.btn_Cinco.Text = "5"
        Me.btn_Cinco.UseVisualStyleBackColor = True
        '
        'btn_Seis
        '
        Me.btn_Seis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Seis.Location = New System.Drawing.Point(82, 111)
        Me.btn_Seis.Name = "btn_Seis"
        Me.btn_Seis.Size = New System.Drawing.Size(32, 28)
        Me.btn_Seis.TabIndex = 7
        Me.btn_Seis.Text = "6"
        Me.btn_Seis.UseVisualStyleBackColor = True
        '
        'btn_Uno
        '
        Me.btn_Uno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Uno.Location = New System.Drawing.Point(12, 145)
        Me.btn_Uno.Name = "btn_Uno"
        Me.btn_Uno.Size = New System.Drawing.Size(32, 28)
        Me.btn_Uno.TabIndex = 8
        Me.btn_Uno.Text = "1"
        Me.btn_Uno.UseVisualStyleBackColor = True
        '
        'btn_Dos
        '
        Me.btn_Dos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Dos.Location = New System.Drawing.Point(47, 145)
        Me.btn_Dos.Name = "btn_Dos"
        Me.btn_Dos.Size = New System.Drawing.Size(32, 28)
        Me.btn_Dos.TabIndex = 9
        Me.btn_Dos.Text = "2"
        Me.btn_Dos.UseVisualStyleBackColor = True
        '
        'btn_Tres
        '
        Me.btn_Tres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Tres.Location = New System.Drawing.Point(82, 145)
        Me.btn_Tres.Name = "btn_Tres"
        Me.btn_Tres.Size = New System.Drawing.Size(32, 28)
        Me.btn_Tres.TabIndex = 10
        Me.btn_Tres.Text = "3"
        Me.btn_Tres.UseVisualStyleBackColor = True
        '
        'btn_Cero
        '
        Me.btn_Cero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cero.Location = New System.Drawing.Point(12, 179)
        Me.btn_Cero.Name = "btn_Cero"
        Me.btn_Cero.Size = New System.Drawing.Size(67, 28)
        Me.btn_Cero.TabIndex = 11
        Me.btn_Cero.Text = "0"
        Me.btn_Cero.UseVisualStyleBackColor = True
        '
        'btn_Punto
        '
        Me.btn_Punto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Punto.Location = New System.Drawing.Point(82, 179)
        Me.btn_Punto.Name = "btn_Punto"
        Me.btn_Punto.Size = New System.Drawing.Size(32, 28)
        Me.btn_Punto.TabIndex = 12
        Me.btn_Punto.Text = "."
        Me.btn_Punto.UseVisualStyleBackColor = True
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Limpiar.Location = New System.Drawing.Point(158, 77)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(32, 28)
        Me.btn_Limpiar.TabIndex = 13
        Me.btn_Limpiar.Text = "CE"
        Me.btn_Limpiar.UseVisualStyleBackColor = True
        '
        'btn_Dividir
        '
        Me.btn_Dividir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Dividir.Location = New System.Drawing.Point(120, 77)
        Me.btn_Dividir.Name = "btn_Dividir"
        Me.btn_Dividir.Size = New System.Drawing.Size(32, 28)
        Me.btn_Dividir.TabIndex = 14
        Me.btn_Dividir.Text = "/"
        Me.btn_Dividir.UseVisualStyleBackColor = True
        '
        'btn_Multiplar
        '
        Me.btn_Multiplar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Multiplar.Location = New System.Drawing.Point(120, 111)
        Me.btn_Multiplar.Name = "btn_Multiplar"
        Me.btn_Multiplar.Size = New System.Drawing.Size(32, 28)
        Me.btn_Multiplar.TabIndex = 15
        Me.btn_Multiplar.Text = "*"
        Me.btn_Multiplar.UseVisualStyleBackColor = True
        '
        'btn_Restar
        '
        Me.btn_Restar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Restar.Location = New System.Drawing.Point(120, 145)
        Me.btn_Restar.Name = "btn_Restar"
        Me.btn_Restar.Size = New System.Drawing.Size(32, 28)
        Me.btn_Restar.TabIndex = 16
        Me.btn_Restar.Text = "-"
        Me.btn_Restar.UseVisualStyleBackColor = True
        '
        'btn_Sumar
        '
        Me.btn_Sumar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Sumar.Location = New System.Drawing.Point(120, 179)
        Me.btn_Sumar.Name = "btn_Sumar"
        Me.btn_Sumar.Size = New System.Drawing.Size(32, 28)
        Me.btn_Sumar.TabIndex = 17
        Me.btn_Sumar.Text = "+"
        Me.btn_Sumar.UseVisualStyleBackColor = True
        '
        'btn_Igual
        '
        Me.btn_Igual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Igual.Location = New System.Drawing.Point(158, 111)
        Me.btn_Igual.Name = "btn_Igual"
        Me.btn_Igual.Size = New System.Drawing.Size(32, 96)
        Me.btn_Igual.TabIndex = 18
        Me.btn_Igual.Text = "="
        Me.btn_Igual.UseVisualStyleBackColor = True
        '
        'frmCalculadora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(205, 220)
        Me.Controls.Add(Me.btn_Igual)
        Me.Controls.Add(Me.btn_Sumar)
        Me.Controls.Add(Me.btn_Restar)
        Me.Controls.Add(Me.btn_Multiplar)
        Me.Controls.Add(Me.btn_Dividir)
        Me.Controls.Add(Me.btn_Limpiar)
        Me.Controls.Add(Me.btn_Punto)
        Me.Controls.Add(Me.btn_Cero)
        Me.Controls.Add(Me.btn_Tres)
        Me.Controls.Add(Me.btn_Dos)
        Me.Controls.Add(Me.btn_Uno)
        Me.Controls.Add(Me.btn_Seis)
        Me.Controls.Add(Me.btn_Cinco)
        Me.Controls.Add(Me.btn_Cuatro)
        Me.Controls.Add(Me.btn_Nueve)
        Me.Controls.Add(Me.btn_Ocho)
        Me.Controls.Add(Me.btn_Siete)
        Me.Controls.Add(Me.lbl_Display)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCalculadora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculadora"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Display As System.Windows.Forms.Label
    Friend WithEvents btn_Siete As System.Windows.Forms.Button
    Friend WithEvents btn_Ocho As System.Windows.Forms.Button
    Friend WithEvents btn_Nueve As System.Windows.Forms.Button
    Friend WithEvents btn_Cuatro As System.Windows.Forms.Button
    Friend WithEvents btn_Cinco As System.Windows.Forms.Button
    Friend WithEvents btn_Seis As System.Windows.Forms.Button
    Friend WithEvents btn_Uno As System.Windows.Forms.Button
    Friend WithEvents btn_Dos As System.Windows.Forms.Button
    Friend WithEvents btn_Tres As System.Windows.Forms.Button
    Friend WithEvents btn_Cero As System.Windows.Forms.Button
    Friend WithEvents btn_Punto As System.Windows.Forms.Button
    Friend WithEvents btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents btn_Dividir As System.Windows.Forms.Button
    Friend WithEvents btn_Multiplar As System.Windows.Forms.Button
    Friend WithEvents btn_Restar As System.Windows.Forms.Button
    Friend WithEvents btn_Sumar As System.Windows.Forms.Button
    Friend WithEvents btn_Igual As System.Windows.Forms.Button

End Class
