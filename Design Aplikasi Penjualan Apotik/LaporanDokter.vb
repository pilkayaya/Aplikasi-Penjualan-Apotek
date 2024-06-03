Public Class LaporanDokter
    Private Sub LaporanDokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AplikasiPenjualanDataSet.tbl_dokter' table. You can move, or remove it, as needed.
        Me.Tbl_dokterTableAdapter.Fill(Me.AplikasiPenjualanDataSet.tbl_dokter)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class