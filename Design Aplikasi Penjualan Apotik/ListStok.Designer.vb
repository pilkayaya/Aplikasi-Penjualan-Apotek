<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListStok
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Nomor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.cboCari = New System.Windows.Forms.ComboBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nomor, Me.Kode, Me.Nama, Me.Jenis, Me.Column1, Me.Column2, Me.Column3})
        Me.dgv.Location = New System.Drawing.Point(11, 64)
        Me.dgv.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 62
        Me.dgv.RowTemplate.Height = 28
        Me.dgv.Size = New System.Drawing.Size(774, 288)
        Me.dgv.TabIndex = 5
        '
        'Nomor
        '
        Me.Nomor.HeaderText = "No"
        Me.Nomor.MinimumWidth = 8
        Me.Nomor.Name = "Nomor"
        Me.Nomor.Width = 30
        '
        'Kode
        '
        Me.Kode.HeaderText = "Kode Obat"
        Me.Kode.MinimumWidth = 8
        Me.Kode.Name = "Kode"
        Me.Kode.Width = 130
        '
        'Nama
        '
        Me.Nama.HeaderText = "Nama Obat"
        Me.Nama.MinimumWidth = 8
        Me.Nama.Name = "Nama"
        Me.Nama.Width = 150
        '
        'Jenis
        '
        Me.Jenis.HeaderText = "Jenis Obat"
        Me.Jenis.MinimumWidth = 8
        Me.Jenis.Name = "Jenis"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Harga Beli"
        Me.Column1.MinimumWidth = 8
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Harga Jual"
        Me.Column2.MinimumWidth = 8
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Jumlah Stok"
        Me.Column3.MinimumWidth = 8
        Me.Column3.Name = "Column3"
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(197, 23)
        Me.txtCari.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(133, 20)
        Me.txtCari.TabIndex = 4
        '
        'cboCari
        '
        Me.cboCari.FormattingEnabled = True
        Me.cboCari.Location = New System.Drawing.Point(11, 22)
        Me.cboCari.Margin = New System.Windows.Forms.Padding(2)
        Me.cboCari.Name = "cboCari"
        Me.cboCari.Size = New System.Drawing.Size(171, 21)
        Me.cboCari.TabIndex = 3
        '
        'ListStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.cboCari)
        Me.Name = "ListStok"
        Me.Text = "ListStok"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents txtCari As TextBox
    Friend WithEvents cboCari As ComboBox
    Friend WithEvents Nomor As DataGridViewTextBoxColumn
    Friend WithEvents Kode As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Jenis As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
