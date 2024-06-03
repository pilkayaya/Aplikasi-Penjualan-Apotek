Public Class LaporanSupplier
    Private Sub LaporanSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AplikasiPenjualanDataSet.tbl_supplier' table. You can move, or remove it, as needed.
        Me.Tbl_supplierTableAdapter.Fill(Me.AplikasiPenjualanDataSet.tbl_supplier)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class