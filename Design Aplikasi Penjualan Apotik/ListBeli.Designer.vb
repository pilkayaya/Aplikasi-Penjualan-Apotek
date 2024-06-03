<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListBeli
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
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.cboCari = New System.Windows.Forms.ComboBox()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nomor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Nomor, Me.Kode, Me.Column2, Me.Jenis})
        Me.dgv.Location = New System.Drawing.Point(11, 56)
        Me.dgv.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 62
        Me.dgv.RowTemplate.Height = 28
        Me.dgv.Size = New System.Drawing.Size(748, 297)
        Me.dgv.TabIndex = 14
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(197, 21)
        Me.txtCari.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(163, 20)
        Me.txtCari.TabIndex = 13
        '
        'cboCari
        '
        Me.cboCari.FormattingEnabled = True
        Me.cboCari.Location = New System.Drawing.Point(11, 20)
        Me.cboCari.Margin = New System.Windows.Forms.Padding(2)
        Me.cboCari.Name = "cboCari"
        Me.cboCari.Size = New System.Drawing.Size(182, 21)
        Me.cboCari.TabIndex = 12
        '
        'Column1
        '
        Me.Column1.HeaderText = "No"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 30
        '
        'Nomor
        '
        Me.Nomor.HeaderText = "No. Beli"
        Me.Nomor.MinimumWidth = 8
        Me.Nomor.Name = "Nomor"
        '
        'Kode
        '
        Me.Kode.HeaderText = "Kode Supplier"
        Me.Kode.MinimumWidth = 8
        Me.Kode.Name = "Kode"
        Me.Kode.Width = 130
        '
        'Column2
        '
        Me.Column2.HeaderText = "Tanggal"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 130
        '
        'Jenis
        '
        Me.Jenis.HeaderText = "Total"
        Me.Jenis.MinimumWidth = 8
        Me.Jenis.Name = "Jenis"
        Me.Jenis.Width = 150
        '
        'ListBeli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 450)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.cboCari)
        Me.Name = "ListBeli"
        Me.Text = "ListBeli"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents txtCari As TextBox
    Friend WithEvents cboCari As ComboBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Nomor As DataGridViewTextBoxColumn
    Friend WithEvents Kode As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Jenis As DataGridViewTextBoxColumn
End Class
