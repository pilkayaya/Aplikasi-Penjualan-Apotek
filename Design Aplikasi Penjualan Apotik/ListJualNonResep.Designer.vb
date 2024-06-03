<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListJualNonResep
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
        Me.Nomor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoJual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nomor, Me.NoJual, Me.Nama, Me.Jenis, Me.Column1})
        Me.dgv.Location = New System.Drawing.Point(11, 62)
        Me.dgv.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 62
        Me.dgv.RowTemplate.Height = 28
        Me.dgv.Size = New System.Drawing.Size(767, 334)
        Me.dgv.TabIndex = 8
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(197, 21)
        Me.txtCari.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(133, 20)
        Me.txtCari.TabIndex = 7
        '
        'cboCari
        '
        Me.cboCari.FormattingEnabled = True
        Me.cboCari.Location = New System.Drawing.Point(11, 20)
        Me.cboCari.Margin = New System.Windows.Forms.Padding(2)
        Me.cboCari.Name = "cboCari"
        Me.cboCari.Size = New System.Drawing.Size(171, 21)
        Me.cboCari.TabIndex = 6
        '
        'Nomor
        '
        Me.Nomor.HeaderText = "No"
        Me.Nomor.MinimumWidth = 8
        Me.Nomor.Name = "Nomor"
        Me.Nomor.Width = 30
        '
        'NoJual
        '
        Me.NoJual.HeaderText = "No Jual"
        Me.NoJual.MinimumWidth = 8
        Me.NoJual.Name = "NoJual"
        Me.NoJual.Width = 130
        '
        'Nama
        '
        Me.Nama.HeaderText = "Kode Cutomer"
        Me.Nama.MinimumWidth = 8
        Me.Nama.Name = "Nama"
        Me.Nama.Width = 150
        '
        'Jenis
        '
        Me.Jenis.HeaderText = "Tanggal"
        Me.Jenis.MinimumWidth = 8
        Me.Jenis.Name = "Jenis"
        Me.Jenis.Width = 150
        '
        'Column1
        '
        Me.Column1.HeaderText = "Total"
        Me.Column1.MinimumWidth = 8
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 150
        '
        'ListJualNonResep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.cboCari)
        Me.Name = "ListJualNonResep"
        Me.Text = "ListJualNonResep"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents txtCari As TextBox
    Friend WithEvents cboCari As ComboBox
    Friend WithEvents Nomor As DataGridViewTextBoxColumn
    Friend WithEvents NoJual As DataGridViewTextBoxColumn
    Friend WithEvents Nama As DataGridViewTextBoxColumn
    Friend WithEvents Jenis As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
