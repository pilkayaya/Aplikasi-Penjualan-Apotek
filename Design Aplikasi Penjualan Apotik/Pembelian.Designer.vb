<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pembelian
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
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCari_C = New System.Windows.Forms.Button()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.txtKode_C = New System.Windows.Forms.TextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnCari_S = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtKode = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LBLHarga = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LBLJenisObat = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LBLNamaObat = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LBLNama = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LBLNoBeli = New System.Windows.Forms.Label()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpTanggal
        '
        Me.dtpTanggal.Location = New System.Drawing.Point(150, 106)
        Me.dtpTanggal.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(193, 20)
        Me.dtpTanggal.TabIndex = 80
        '
        'btnCari
        '
        Me.btnCari.Location = New System.Drawing.Point(502, 499)
        Me.btnCari.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(93, 23)
        Me.btnCari.TabIndex = 78
        Me.btnCari.Text = "Cari"
        Me.btnCari.UseVisualStyleBackColor = True
        '
        'btnBatal
        '
        Me.btnBatal.Location = New System.Drawing.Point(276, 499)
        Me.btnBatal.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(93, 23)
        Me.btnBatal.TabIndex = 77
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(46, 76)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 26)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Nama Supplier"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(46, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 26)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Kode Supplier"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(46, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 26)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "No. Beli"
        '
        'btnCari_C
        '
        Me.btnCari_C.Location = New System.Drawing.Point(291, 51)
        Me.btnCari_C.Name = "btnCari_C"
        Me.btnCari_C.Size = New System.Drawing.Size(75, 23)
        Me.btnCari_C.TabIndex = 89
        Me.btnCari_C.Text = "Cari"
        Me.btnCari_C.UseVisualStyleBackColor = True
        '
        'dgvDetail
        '
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(44, 251)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.Size = New System.Drawing.Size(643, 172)
        Me.dgvDetail.TabIndex = 90
        '
        'txtKode_C
        '
        Me.txtKode_C.Location = New System.Drawing.Point(150, 53)
        Me.txtKode_C.Margin = New System.Windows.Forms.Padding(2)
        Me.txtKode_C.Name = "txtKode_C"
        Me.txtKode_C.Size = New System.Drawing.Size(135, 20)
        Me.txtKode_C.TabIndex = 92
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(44, 499)
        Me.btnSimpan.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(93, 23)
        Me.btnSimpan.TabIndex = 97
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(159, 499)
        Me.btnHapus.Margin = New System.Windows.Forms.Padding(2)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(93, 23)
        Me.btnHapus.TabIndex = 98
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(46, 102)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 26)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "Tanggal"
        '
        'btnCari_S
        '
        Me.btnCari_S.Location = New System.Drawing.Point(283, 155)
        Me.btnCari_S.Name = "btnCari_S"
        Me.btnCari_S.Size = New System.Drawing.Size(79, 23)
        Me.btnCari_S.TabIndex = 110
        Me.btnCari_S.Text = "Cari"
        Me.btnCari_S.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(636, 190)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(79, 23)
        Me.Button5.TabIndex = 111
        Me.Button5.Text = "Tambah"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(466, 190)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(158, 20)
        Me.txtQty.TabIndex = 109
        '
        'txtKode
        '
        Me.txtKode.Location = New System.Drawing.Point(119, 157)
        Me.txtKode.Name = "txtKode"
        Me.txtKode.Size = New System.Drawing.Size(158, 20)
        Me.txtKode.TabIndex = 108
        '
        'Label16
        '
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Location = New System.Drawing.Point(390, 187)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 26)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "Qty"
        '
        'LBLHarga
        '
        Me.LBLHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLHarga.Location = New System.Drawing.Point(466, 157)
        Me.LBLHarga.Name = "LBLHarga"
        Me.LBLHarga.Size = New System.Drawing.Size(158, 26)
        Me.LBLHarga.TabIndex = 101
        Me.LBLHarga.Text = "Harga"
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(390, 157)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 26)
        Me.Label15.TabIndex = 102
        Me.Label15.Text = "Harga"
        '
        'LBLJenisObat
        '
        Me.LBLJenisObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLJenisObat.Location = New System.Drawing.Point(119, 210)
        Me.LBLJenisObat.Name = "LBLJenisObat"
        Me.LBLJenisObat.Size = New System.Drawing.Size(158, 26)
        Me.LBLJenisObat.TabIndex = 103
        Me.LBLJenisObat.Text = "Jenis Obat"
        '
        'Label17
        '
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Location = New System.Drawing.Point(44, 210)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 26)
        Me.Label17.TabIndex = 104
        Me.Label17.Text = "Jenis Obat"
        '
        'LBLNamaObat
        '
        Me.LBLNamaObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLNamaObat.Location = New System.Drawing.Point(119, 184)
        Me.LBLNamaObat.Name = "LBLNamaObat"
        Me.LBLNamaObat.Size = New System.Drawing.Size(158, 26)
        Me.LBLNamaObat.TabIndex = 105
        Me.LBLNamaObat.Text = "Nama Obat"
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Location = New System.Drawing.Point(44, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 26)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Nama Obat"
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Location = New System.Drawing.Point(44, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 26)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Kode"
        '
        'LBLNama
        '
        Me.LBLNama.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBLNama.Location = New System.Drawing.Point(144, 76)
        Me.LBLNama.Name = "LBLNama"
        Me.LBLNama.Size = New System.Drawing.Size(225, 26)
        Me.LBLNama.TabIndex = 112
        Me.LBLNama.Text = "LBLNama"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(44, 436)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 37)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Total : Rp. "
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(228, 436)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(219, 37)
        Me.Label14.TabIndex = 113
        Me.Label14.Text = "Rp. 250.000"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(390, 499)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(93, 23)
        Me.Button3.TabIndex = 115
        Me.Button3.Text = "Tutup"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LBLNoBeli
        '
        Me.LBLNoBeli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBLNoBeli.Location = New System.Drawing.Point(144, 25)
        Me.LBLNoBeli.Name = "LBLNoBeli"
        Me.LBLNoBeli.Size = New System.Drawing.Size(158, 26)
        Me.LBLNoBeli.TabIndex = 105
        Me.LBLNoBeli.Text = "LBLNoBeli"
        '
        'Pembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 564)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LBLNama)
        Me.Controls.Add(Me.btnCari_S)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtKode)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LBLHarga)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.LBLJenisObat)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LBLNoBeli)
        Me.Controls.Add(Me.LBLNamaObat)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.txtKode_C)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.btnCari_C)
        Me.Controls.Add(Me.dtpTanggal)
        Me.Controls.Add(Me.btnCari)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Pembelian"
        Me.Text = "Pembelian"
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents btnCari As Button
    Friend WithEvents btnBatal As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCari_C As Button
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents txtKode_C As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents btnCari_S As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents txtQty As TextBox
    Friend WithEvents txtKode As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents LBLHarga As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LBLJenisObat As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents LBLNamaObat As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LBLNama As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents LBLNoBeli As Label
End Class
