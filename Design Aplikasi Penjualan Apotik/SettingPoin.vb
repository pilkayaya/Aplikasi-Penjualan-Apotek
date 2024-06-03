Imports System.Data.SqlClient

Public Class SettingPoin
    ' Variabel global untuk menyimpan nilai minimal transaksi
    Public Shared minTransaksi As Integer = 100

    Private connectionString As String = "Data Source=localhost\SQLEXPRESS;Initial Catalog=AplikasiPenjualan;Integrated Security=True"

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        ' Ketika checkbox 1 (Tidak Memakai Poin) diubah
        If CheckBox1.Checked Then
            CheckBox2.Checked = False ' Matikan checkbox 2 (Point Tukar Hadiah)
            TextBox1.Enabled = False ' Matikan textbox
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        ' Ketika checkbox 2 (Point Tukar Hadiah) diubah
        If CheckBox2.Checked Then
            CheckBox1.Checked = False ' Matikan checkbox 1 (Tidak Memakai Poin)
            TextBox1.Enabled = True ' Hidupkan textbox
        Else
            TextBox1.Enabled = False ' Matikan textbox jika checkbox 2 tidak dicentang
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Mengambil nilai minimal transaksi dari textbox dan menyimpannya ke variabel global
        minTransaksi = Integer.Parse(TextBox1.Text)
        MessageBox.Show("Nilai minimal transaksi telah diatur menjadi " & minTransaksi.ToString())

        ' Mengatur tanggal awal dan tanggal akhir secara dinamis
        Dim tanggalAwal As DateTime = DateTimePicker1.Value
        Dim tanggalAkhir As DateTime = DateTimePicker2.Value

        ' Menyimpan data ke database
        SaveToDatabase(minTransaksi, tanggalAwal, tanggalAkhir)

        MessageBox.Show("Data telah disimpan ke database.")

        ' Reset form
        TextBox1.Text = String.Empty
        DateTimePicker1.Value = DateTime.Today
        DateTimePicker2.Value = DateTime.Today
    End Sub

    Private Sub SettingPoin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur nilai default untuk DateTimePicker
        DateTimePicker1.Value = DateTime.Today
        DateTimePicker2.Value = DateTime.Today
    End Sub

    Private Sub SaveToDatabase(minTransaksi As Integer, tanggalAwal As DateTime, tanggalAkhir As DateTime)
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO setting_poin (minimal_transaksi, tanggal_awal, tanggal_akhir) VALUES (@MinimalTransaksi, @TanggalAwal, @TanggalAkhir)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@MinimalTransaksi", minTransaksi)
                command.Parameters.AddWithValue("@TanggalAwal", tanggalAwal)
                command.Parameters.AddWithValue("@TanggalAkhir", tanggalAkhir)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
