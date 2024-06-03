Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class JualNonResep
    Public Shared TotalTransaksi As Integer = 0
    Dim query As String
    Dim conn As New SqlConnection
    Public Sub Connect()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub
    Sub KondisiAwal()
        txtKode_C.Text = ""
        LBLNama.Text = ""
        LBLStatus.Text = ""
        LBLAlamat.Text = ""
        LBLTelp.Text = ""
        LBLPoin.Text = ""
        LBLTanggal.Text = Today
        txtKode.Text = ""
        LBLNamaObat.Text = ""
        LBLHarga.Text = ""
        LBLJenisObat.Text = ""
        txtQty.Text = ""
        txtQty.Enabled = False
        LBLKembali.Text = ""
        Call NomorOtomatis()
        Call BuatKolom()
        Label14.Text = "0"
        txtBayar.Text = ""
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LBLJam.Text = TimeOfDay
    End Sub

    Private Sub JualNonResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Public Sub txtKode_C_LostFocus(sender As Object, e As EventArgs) Handles txtKode_C.LostFocus
        If Trim(txtKode_C.Text) <> "" Then
            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_customer Where kode_customer = '" & Trim(txtKode_C.Text) & "'"
                    cmdX.CommandText = query

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                LBLNama.Text = drX("nama_customer")
                                LBLStatus.Text = drX("status_customer")
                                LBLAlamat.Text = drX("alamat")
                                LBLTelp.Text = drX("no_telp")
                                LBLPoin.Text = drX("poin")
                            End While
                        End If
                        drX.Close()
                    End Using
                End Using
            End Using
        End If
    End Sub

    Sub NomorOtomatis()
        Connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn
        query = "Select * From tbl_jualnonresep where NoJual in(select max(NoJual) from tbl_jualnonresep)"
        cmdOpen.CommandText = query

        Dim UrutanKode As String
        Dim Hitung As Long
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        If drOpen.Read() Then
            If Not drOpen.IsDBNull(0) Then
                Hitung = Microsoft.VisualBasic.Right(drOpen.GetString(0), 9) + 1
            Else
                Hitung = 1
            End If
        Else
            Hitung = 1
        End If

        UrutanKode = "JN" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        txtNoJual.Text = UrutanKode

        drOpen.Close()
        conn.Close()
    End Sub

    Sub BuatKolom()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("Kode", "Kode Obat")
        DataGridView1.Columns.Add("Nama", "Nama Obat")
        DataGridView1.Columns.Add("Jenis", "Jenis Obat")
        DataGridView1.Columns.Add("Harga", "Harga Satuan")
        DataGridView1.Columns.Add("Jumlah", "Qty")
        DataGridView1.Columns.Add("SubTotal", "Subtotal")

        DataGridView1.Columns(3).DefaultCellStyle.Format = "##,##0.00"
        DataGridView1.Columns(5).DefaultCellStyle.Format = "##,##0.00"
    End Sub

    Public Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
        If e.KeyChar = Chr(13) Then
            Connect()
            Dim cmdOpen As New SqlCommand()

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdOpen.Connection = conn

            query = "Select * From tbl_stok Where kode_obat ='" & Trim(txtKode.Text) & "'"
            cmdOpen.CommandText = query

            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.Read() Then ' Periksa apakah ada baris data yang tersedia
                txtKode.Text = drOpen("kode_obat").ToString
                LBLNamaObat.Text = drOpen("nama_obat").ToString
                LBLJenisObat.Text = drOpen("jenis_obat").ToString
                LBLHarga.Text = drOpen("harga_jual").ToString

                Dim harga As Decimal = Convert.ToDecimal(drOpen("harga_jual"))
                LBLHarga.Text = harga.ToString("##,###.00")

                txtQty.Enabled = True
            Else
                MsgBox("Kode Obat Tidak Ada")

            End If
            drOpen.Close()
            conn.Close()

        End If
    End Sub

    Public Sub txtKode_LostFocus(sender As Object, e As EventArgs) Handles txtKode.LostFocus
        If Trim(txtKode.Text) <> "" Then
            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_stok Where kode_obat = '" & Trim(txtKode.Text) & "'"
                    cmdX.CommandText = query

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                LBLNamaObat.Text = drX("nama_obat")
                                LBLHarga.Text = Format(drX("harga_jual"), "##,##0.00")
                                LBLJenisObat.Text = drX("jenis_obat")

                            End While
                            txtQty.Enabled = True
                        End If
                        drX.Close()
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If LBLNamaObat.Text = "" Or txtQty.Text = "" Then
            MsgBox("Silahkan Masukan Kode Obat dan Tekan ENTER!")
        Else
            Dim KodeObat As String = txtKode.Text
            Dim qty As Integer = CInt(txtQty.Text)
            Dim obatTerdaftar As Boolean = False

            ' Periksa apakah kode obat sudah ada dalam DataGridView
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("Kode").Value IsNot Nothing AndAlso row.Cells("Kode").Value.ToString() = KodeObat Then

                    ' Kode obat sudah ada, tambahkan qty ke row yang sudah ada
                    Dim existingQty As Integer = CInt(row.Cells("Jumlah").Value)
                    row.Cells("Jumlah").Value = existingQty + qty
                    obatTerdaftar = True
                    Exit For
                End If
            Next

            ' Jika kode obat belum terdaftar, tambahkan sebagai baris baru
            If Not obatTerdaftar Then
                DataGridView1.Rows.Add(New String() {KodeObat, LBLNamaObat.Text, LBLJenisObat.Text, LBLHarga.Text, txtQty.Text, Val(LBLHarga.Text) * Val(txtQty.Text)})
            End If

            Call RumusSubTotal()
            txtKode.Text = ""
            LBLNamaObat.Text = ""
            LBLHarga.Text = ""
            LBLJenisObat.Text = ""
            txtQty.Text = ""
            txtQty.Enabled = False
        End If
    End Sub

    Sub RumusSubTotal()
        Dim hitung As Decimal = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Dim qty As Decimal = DataGridView1.Rows(i).Cells(4).Value
            Dim harga As Decimal = DataGridView1.Rows(i).Cells(3).Value
            Dim subTotal As Decimal = qty * harga
            If subTotal > 0 Then
                DataGridView1.Rows(i).Cells(5).Value = Format(subTotal, "##,##0.00")
            Else
                DataGridView1.Rows(i).Cells(5).Value = ""
            End If
            hitung += subTotal
        Next
        Label14.Text = Format(hitung, "##,##0.00")

    End Sub

    Private Sub txtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBayar.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim totalHarga As Decimal
            Dim bayar As Decimal

            If Decimal.TryParse(Label14.Text, totalHarga) AndAlso Decimal.TryParse(txtBayar.Text, bayar) Then
                If bayar < totalHarga Then
                    MsgBox("Pembayaran Kurang!")
                ElseIf bayar = totalHarga Then
                    LBLKembali.Text = "0.00"
                Else
                    Dim kembali As Decimal = bayar - totalHarga
                    LBLKembali.Text = kembali.ToString("##,##0.00")
                    Button1.Focus()

                End If

                ' Mengatur format teks pada txtBayar.Text
                txtBayar.Text = bayar.ToString("##,##0.00")
            Else
                MsgBox("Format input tidak valid!")
            End If

        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If LBLKembali.Text = "" Or LBLNama.Text = "" Or Label14.Text = "" Then
            MsgBox("Transaksi Tidak Ada, Silahkan Lakukan Transaksi Terlebih Dahulu")
        Else
            Dim cmdCheck As New SqlCommand
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmdCheck.Connection = conn
            cmdCheck.CommandText = "SELECT COUNT(*) FROM tbl_jualnonresep WHERE NoJual = '" & Trim(txtNoJual.Text) & "'"
            Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            conn.Close()

            If count > 0 Then
                MsgBox("NoJual sudah ada dalam database. Mohon periksa kembali nomor transaksi.")
            Else
                conn.Open()
                Dim cmdOpen As New SqlCommand
                cmdOpen.Connection = conn
                Dim query As String = "INSERT INTO tbl_jualnonresep VALUES ('" & Trim(txtNoJual.Text) & "', '" & CDate(Trim(LBLTanggal.Text)) & "', '" &
                                   Trim(LBLJam.Text) & "', " &
                                   CDec(Trim(Label14.Text)) & ", " &
                                   CDec(Trim(txtBayar.Text)) & ", " &
                                   CDec(Trim(LBLKembali.Text)) & ", '" &
                                   Trim(txtKode_C.Text) & "')"
                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()

                For baris As Integer = 0 To DataGridView1.Rows.Count - 1
                    query = "insert into tbl_detailjualnonresep(NoJual,KodeObat,NamaObat,JenisObat,HargaJual,JumlahJual,SubTotal)values('" & txtNoJual.Text &
                                       "','" & DataGridView1.Rows(baris).Cells(0).Value &
                                       "','" & DataGridView1.Rows(baris).Cells(1).Value &
                                       "','" & DataGridView1.Rows(baris).Cells(2).Value &
                                       "','" & DataGridView1.Rows(baris).Cells(3).Value &
                                       "','" & DataGridView1.Rows(baris).Cells(4).Value &
                                       "','" & DataGridView1.Rows(baris).Cells(5).Value &
                                       "')"
                    cmdOpen.CommandText = query
                    cmdOpen.ExecuteNonQuery()

                    query = "select * from tbl_stok where kode_obat ='" & DataGridView1.Rows(baris).Cells(0).Value & "'"
                    cmdOpen.CommandText = query
                    Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader()
                    If drOpen.Read() Then
                        drOpen.Close() ' Menutup SqlDataReader sebelum menjalankan perintah update

                        query = "update tbl_stok set jumlah_stok = jumlah_stok - " & Val(DataGridView1.Rows(baris).Cells(4).Value) &
                      " where kode_obat='" & DataGridView1.Rows(baris).Cells(0).Value & "'"
                        cmdOpen.CommandText = query
                        cmdOpen.ExecuteNonQuery()
                    End If
                    drOpen.Close()
                Next

                Call KondisiAwal()
                MsgBox("Transaksi Telah Berhasil Disimpan")
            End If

            'Dim totalTransaksi As Integer = Integer.Parse(Label14.Text)

            'If SettingPoin.CheckBox2.Checked AndAlso CekPoin(totalTransaksi) Then
            '    MessageBox.Show("Anda mendapatkan 1 poin!")

            '    ' Update tabel tbl_customer dengan menambahkan 1 poin
            '    Dim cmdUpdate As New SqlCommand
            '    cmdUpdate.Connection = conn
            '    query = "UPDATE tbl_customer SET poin = poin + 1 WHERE kode_customer = '" & Trim(txtKode_C.Text) & "'"
            '    cmdUpdate.CommandText = query
            '    cmdUpdate.ExecuteNonQuery()
            'Else
            '    MessageBox.Show("Anda tidak mendapatkan poin.")
            'End If


            '    conn.Close()
            'End If
            'drOpen.Close()
            '            query = "INSERT INTO Costumer VALUES ('" & Trim(txtKode_C.Text) & "', " & CInt(LBLPoin.Text) & ")"
            '            cmdOpen.CommandText = query
            '            cmdOpen.ExecuteNonQuery()
            '            conn.Close()
            '        End If
            '    Else
            '        MessageBox.Show("Anda tidak mendapatkan poin.")
            '    End If
            '    Dim cmdOpen As New SqlCommand
            '    If conn.State = ConnectionState.Open Then conn.Close()
            '    conn.Open()
            '    cmdOpen.Connection = conn
            '    query = "SELECT * FROM Costumer WHERE kode_costumer = '" & Trim(txtKode.Text) & "'"
            '        cmdOpen.CommandText = query

            '        MessageBox.Show("Data has been saved")

            conn.Close()
    End If
    End Sub

    Private Function CekPoin(totalTransaksi As Integer) As Boolean
        ' Mengambil nilai minimal transaksi dari setting poin
        Dim minTransaksi As Integer = SettingPoin.minTransaksi

        Return totalTransaksi >= minTransaksi
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call KondisiAwal()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        vJNonResep = "JualNonResep"
        ListJualNonResep.Close()
        ListJualNonResep.MdiParent = mdiMenu
        ListJualNonResep.Show()
    End Sub

    Private Sub btnCari_C_Click(sender As Object, e As EventArgs) Handles btnCari_C.Click
        vCustomerJualN = "CustomerJualN"
        ListCustomer.Close()
        ListCustomer.MdiParent = mdiMenu
        ListCustomer.Show()
    End Sub

    Private Sub btnCari_S_Click(sender As Object, e As EventArgs) Handles btnCari_S.Click
        vStok = "JualStok"
        ListStok.Close()
        ListStok.MdiParent = mdiMenu
        ListStok.Show()

    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If MessageBox.Show("Yakin mau dihapus?", "Konfirmasi", MessageBoxButtons.OKCancel) = vbOK Then
            Dim cmdopen As New SqlCommand
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdopen.Connection = conn
            query = "Delete from tbl_jualnonresep Where NoJual = '" & Trim(txtNoJual.Text) & "'"
            cmdopen.CommandText = query
            cmdopen.ExecuteNonQuery()

            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog= AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_detailjualnonresep Where NoJual = '" & Trim(txtNoJual.Text) & "'"
                    cmdX.CommandText = query
                    cmdX.ExecuteNonQuery()

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                cmdopen.CommandText = "update tbl_stok set jumlah_stok = jumlah_stok - " & drX("JumlahJual") &
                                                              "where kode_obat = '" & drX("kode_obat") & "'"
                                cmdopen.ExecuteNonQuery()
                            End While
                        End If
                        drX.Close()
                    End Using
                End Using
            End Using

            query = "Delete from tbl_detailjualnonresep Where NoJual ='" & Trim(txtNoJual.Text) & "'"
            cmdopen.CommandText = query
            cmdopen.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Data Telah Dihapus")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.CurrentRow.Cells(0).Value <> "" Then

            txtKode.Text = DataGridView1.CurrentRow.Cells(0).Value
            LBLNamaObat.Text = DataGridView1.CurrentRow.Cells(1).Value
            LBLJenisObat.Text = DataGridView1.CurrentRow.Cells(2).Value
            txtQty.Text = Format(CDec(DataGridView1.CurrentRow.Cells(4).Value), "##,##0")
            LBLHarga.Text = Format(CDec(DataGridView1.CurrentRow.Cells(3).Value), "##,##0.00")
            txtQty.Enabled = True
        End If
    End Sub

    Private Sub txtNoJual_LostFocus(sender As Object, e As EventArgs) Handles txtNoJual.LostFocus
        If Trim(txtNoJual.Text) <> "" Then
            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_jualnonresep Where NoJual = '" & Trim(txtNoJual.Text) & "'"
                    cmdX.CommandText = query

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                LBLTanggal.Text = drX("TglJual")
                                LBLJam.Text = drX("JamJual")
                                LBLAlamat.Text = drX("TotalJual")
                                LBLTelp.Text = drX("Dibayar")
                                LBLPoin.Text = drX("Kembali")
                                LBLPoin.Text = drX("KodeCustomer")
                            End While
                        End If
                        drX.Close()
                    End Using
                End Using
            End Using
        End If
    End Sub
End Class