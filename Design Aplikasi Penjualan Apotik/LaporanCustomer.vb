Public Class LaporanCustomer
    Private Sub LaporanCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AplikasiPenjualanDataSet.tbl_customer' table. You can move, or remove it, as needed.
        Me.Tbl_customerTableAdapter.Fill(Me.AplikasiPenjualanDataSet.tbl_customer)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class