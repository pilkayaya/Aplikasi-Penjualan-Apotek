<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanSupplier
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
        Me.TblsupplierBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_supplierTableAdapter = New Design_Aplikasi_Penjualan_Apotik.AplikasiPenjualanDataSetTableAdapters.tbl_supplierTableAdapter()
        CType(Me.AplikasiPenjualanDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblsupplierBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.TblsupplierBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Design_Aplikasi_Penjualan_Apotik.ReportSupplier.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(637, 362)
        Me.ReportViewer1.TabIndex = 0
        '
        'AplikasiPenjualanDataSet
        '
        Me.AplikasiPenjualanDataSet.DataSetName = "AplikasiPenjualanDataSet"
        Me.AplikasiPenjualanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblsupplierBindingSource
        '
        Me.TblsupplierBindingSource.DataMember = "tbl_supplier"
        Me.TblsupplierBindingSource.DataSource = Me.AplikasiPenjualanDataSet
        '
        'Tbl_supplierTableAdapter
        '
        Me.Tbl_supplierTableAdapter.ClearBeforeFill = True
        '
        'LaporanSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 363)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "LaporanSupplier"
        Me.Text = "LaporanSupplier"
        CType(Me.AplikasiPenjualanDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblsupplierBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents AplikasiPenjualanDataSet As AplikasiPenjualanDataSet
    Friend WithEvents TblsupplierBindingSource As BindingSource
    Friend WithEvents Tbl_supplierTableAdapter As AplikasiPenjualanDataSetTableAdapters.tbl_supplierTableAdapter
End Class
