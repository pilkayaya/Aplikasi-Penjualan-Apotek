<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stok
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtKodeObat = New System.Windows.Forms.TextBox()
        Me.txtJual = New System.Windows.Forms.TextBox()
        Me.txtNamaObat = New System.Windows.Forms.TextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBeli = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStok = New System.Windows.Forms.TextBox()
        Me.CboJenisObat = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(145, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode Obat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 72)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Obat"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(145, 100)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Jenis Obat"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 131)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Harga Beli"
        '
        'txtKodeObat
        '
        Me.txtKodeObat.Location = New System.Drawing.Point(228, 42)
        Me.txtKodeObat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtKodeObat.Name = "txtKodeObat"
        Me.txtKodeObat.Size = New System.Drawing.Size(125, 20)
        Me.txtKodeObat.TabIndex = 5
        '
        'txtJual
        '
        Me.txtJual.Location = New System.Drawing.Point(228, 159)
        Me.txtJual.Margin = New System.Windows.Forms.Padding(2)
        Me.txtJual.Name = "txtJual"
        Me.txtJual.Size = New System.Drawing.Size(125, 20)
        Me.txtJual.TabIndex = 6
        Me.txtJual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNamaObat
        '
        Me.txtNamaObat.Location = New System.Drawing.Point(228, 69)
        Me.txtNamaObat.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNamaObat.Name = "txtNamaObat"
        Me.txtNamaObat.Size = New System.Drawing.Size(229, 20)
        Me.txtNamaObat.TabIndex = 8
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(146, 234)
        Me.btnSimpan.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(67, 22)
        Me.btnSimpan.TabIndex = 11
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnCari
        '
        Me.btnCari.Location = New System.Drawing.Point(391, 234)
        Me.btnCari.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(66, 22)
        Me.btnCari.TabIndex = 12
        Me.btnCari.Text = "Cari"
        Me.btnCari.UseVisualStyleBackColor = True
        '
        'btnBatal
        '
        Me.btnBatal.Location = New System.Drawing.Point(309, 234)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(67, 22)
        Me.btnBatal.TabIndex = 13
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(228, 234)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(2)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(67, 22)
        Me.btnHapus.TabIndex = 14
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(145, 162)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Harga Jual"
        '
        'txtBeli
        '
        Me.txtBeli.Location = New System.Drawing.Point(228, 128)
        Me.txtBeli.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBeli.Name = "txtBeli"
        Me.txtBeli.Size = New System.Drawing.Size(125, 20)
        Me.txtBeli.TabIndex = 16
        Me.txtBeli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(145, 192)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Jumlah Stok"
        '
        'txtStok
        '
        Me.txtStok.Location = New System.Drawing.Point(228, 189)
        Me.txtStok.Margin = New System.Windows.Forms.Padding(2)
        Me.txtStok.Name = "txtStok"
        Me.txtStok.Size = New System.Drawing.Size(125, 20)
        Me.txtStok.TabIndex = 18
        Me.txtStok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CboJenisObat
        '
        Me.CboJenisObat.FormattingEnabled = True
        Me.CboJenisObat.Location = New System.Drawing.Point(228, 97)
        Me.CboJenisObat.Name = "CboJenisObat"
        Me.CboJenisObat.Size = New System.Drawing.Size(121, 21)
        Me.CboJenisObat.TabIndex = 19
        '
        'Stok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 312)
        Me.Controls.Add(Me.CboJenisObat)
        Me.Controls.Add(Me.txtStok)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtBeli)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.btnCari)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.txtNamaObat)
        Me.Controls.Add(Me.txtJual)
        Me.Controls.Add(Me.txtKodeObat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Stok"
        Me.Text = "Stok Obat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtKodeObat As TextBox
    Friend WithEvents txtJual As TextBox
    Friend WithEvents txtNamaObat As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnCari As Button
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBeli As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtStok As TextBox
    Friend WithEvents CboJenisObat As ComboBox
End Class
