<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanDokter
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.AplikasiPenjualanDataSet = New Design_Aplikasi_Penjualan_Apotik.AplikasiPenjualanDataSet()
        Me.TbldokterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_dokterTableAdapter = New Design_Aplikasi_Penjualan_Apotik.AplikasiPenjualanDataSetTableAdapters.tbl_dokterTableAdapter()
        CType(Me.AplikasiPenjualanDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbldokterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.TbldokterBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Design_Aplikasi_Penjualan_Apotik.ReportDokter.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(1, -3)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(635, 393)
        Me.ReportViewer1.TabIndex = 0
        '
        'AplikasiPenjualanDataSet
        '
        Me.AplikasiPenjualanDataSet.DataSetName = "AplikasiPenjualanDataSet"
        Me.AplikasiPenjualanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TbldokterBindingSource
        '
        Me.TbldokterBindingSource.DataMember = "tbl_dokter"
        Me.TbldokterBindingSource.DataSource = Me.AplikasiPenjualanDataSet
        '
        'Tbl_dokterTableAdapter
        '
        Me.Tbl_dokterTableAdapter.ClearBeforeFill = True
        '
        'LaporanDokter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 387)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "LaporanDokter"
        Me.Text = "LaporanDokter"
        CType(Me.AplikasiPenjualanDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbldokterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents AplikasiPenjualanDataSet As AplikasiPenjualanDataSet
    Friend WithEvents TbldokterBindingSource As BindingSource
    Friend WithEvents Tbl_dokterTableAdapter As AplikasiPenjualanDataSetTableAdapters.tbl_dokterTableAdapter
End Class
