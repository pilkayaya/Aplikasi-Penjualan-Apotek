Public Class LaporanStok
    Private Sub LaporanStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AplikasiPenjualanDataSet.tbl_stok' table. You can move, or remove it, as needed.
        Me.Tbl_stokTableAdapter.Fill(Me.AplikasiPenjualanDataSet.tbl_stok)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class