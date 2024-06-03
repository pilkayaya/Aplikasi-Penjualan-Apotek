Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class PenjualanResep

    Dim query As String
    Dim conn As New SqlConnection
    Public Sub Connect()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub
    Sub KondisiAwal()
        txtKodeR.Text = ""
        txtKodeD.Text = ""
        txtNamaD.Text = ""
        txtKodeC.Text = ""
        txtNamaC.Text = ""
        txtStatus.Text = ""
        txtPoin.Text = ""
        txtKodeS.Text = ""
        txtNamaObat.Text = ""
        txtJenis.Text = ""
        txtHarga.Text = ""
        txtQty.Text = ""
        txtQty.Enabled = False
        dtpTanggal.Text = Today
        txtTotal.Text = "0"
        txtBayar.Text = ""
        txtKembali.Text = ""
        Call NomorOtomatis()
        Call BuatKolom()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtJam.Text = TimeOfDay
    End Sub

    Private Sub JualNonResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Public Sub txtKodeD_LostFocus(sender As Object, e As EventArgs) Handles txtKodeD.LostFocus
        If Trim(txtKodeD.Text) <> "" Then
            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_dokter Where kode_dokter = '" & Trim(txtKodeD.Text) & "'"
                    cmdX.CommandText = query

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                txtNamaD.Text = drX("nama_dokter")
                            End While
                        End If
                        drX.Close()
                    End Using
                End Using
            End Using
        End If
    End Sub
    Public Sub txtKodeC_LostFocus(sender As Object, e As EventArgs) Handles txtKodeC.LostFocus
        If Trim(txtKodeC.Text) <> "" Then
            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_customer Where kode_customer = '" & Trim(txtKodeC.Text) & "'"
                    cmdX.CommandText = query

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                txtNamaC.Text = drX("nama_customer")
                                txtStatus.Text = drX("status_customer")
                                txtPoin.Text = drX("poin")
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
        query = "Select * From tbl_jualresep where NoJual in(select max(NoJual) from tbl_jualresep)"
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
        txtKode.Text = UrutanKode

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

    Public Sub txtKodeS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
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
                txtKodeS.Text = drOpen("kode_obat").ToString
                txtNamaObat.Text = drOpen("nama_obat").ToString
                txtJenis.Text = drOpen("jenis_obat").ToString
                txtHarga.Text = drOpen("harga_jual").ToString

                Dim harga As Decimal = Convert.ToDecimal(drOpen("harga_jual"))
                txtHarga.Text = harga.ToString("##,###.00")

                txtQty.Enabled = True
            Else
                MsgBox("Kode Obat Tidak Ada")

            End If
            drOpen.Close()
            conn.Close()

        End If
    End Sub

    Public Sub txtKodeS_LostFocus(sender As Object, e As EventArgs) Handles txtKode.LostFocus
        If Trim(txtKodeS.Text) <> "" Then
            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_stok Where kode_obat = '" & Trim(txtKodeS.Text) & "'"
                    cmdX.CommandText = query

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                txtNamaObat.Text = drX("nama_obat")
                                txtHarga.Text = Format(drX("harga_jual"), "##,##0.00")
                                txtJenis.Text = drX("jenis_obat")

                            End While
                            txtQty.Enabled = True
                        End If
                        drX.Close()
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub BtnTam_Click(sender As Object, e As EventArgs) Handles BtnTam.Click
        If txtNamaObat.Text = "" Or txtQty.Text = "" Then
            MsgBox("Silahkan Masukan Kode Obat dan Tekan ENTER!")
        Else
            Dim KodeObat As String = txtKodeS.Text
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
                DataGridView1.Rows.Add(New String() {KodeObat, txtNamaObat.Text, txtJenis.Text, txtHarga.Text, txtQty.Text, Val(txtHarga.Text) * Val(txtQty.Text)})
            End If

            Call RumusSubTotal()
            txtKodeS.Text = ""
            txtNamaObat.Text = ""
            txtHarga.Text = ""
            txtJenis.Text = ""
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
        txtTotal.Text = Format(hitung, "##,##0.00")

    End Sub

    Private Sub txtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBayar.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim totalHarga As Decimal
            Dim bayar As Decimal

            If Decimal.TryParse(txtTotal.Text, totalHarga) AndAlso Decimal.TryParse(txtBayar.Text, bayar) Then
                If bayar < totalHarga Then
                    MsgBox("Pembayaran Kurang!")
                ElseIf bayar = totalHarga Then
                    txtKembali.Text = "0.00"
                Else
                    Dim kembali As Decimal = bayar - totalHarga
                    txtKembali.Text = kembali.ToString("##,##0.00")
                    btnSimpan.Focus()

                End If

                ' Mengatur format teks pada txtBayar.Text
                txtBayar.Text = bayar.ToString("##,##0.00")
            Else
                MsgBox("Format input tidak valid!")
            End If

        End If
    End Sub


    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKembali.Text = "" Or txtNamaD.Text = "" Or txtNamaC.Text = "" Or txtTotal.Text = "" Then
            MsgBox("Transaksi Tidak Ada, Silahkan Lakukan Transaksi Terlebih Dahulu")
        Else
            Dim cmdCheck As New SqlCommand
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmdCheck.Connection = conn
            cmdCheck.CommandText = "SELECT COUNT(*) FROM tbl_jualresep WHERE NoJual = '" & Trim(txtKode.Text) & "'"
            Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            conn.Close()

            If count > 0 Then
                MsgBox("NoJual sudah ada dalam database. Mohon periksa kembali nomor transaksi.")
            Else
                conn.Open()
                Dim cmdOpen As New SqlCommand
                cmdOpen.Connection = conn
                Dim query As String = "INSERT INTO tbl_jualresep VALUES ('" & Trim(txtKode.Text) & "', '" & Trim(txtKodeR.Text) & "', '" & CDate(Trim(dtpTanggal.Text)) & "', '" &
                                       Trim(txtJam.Text) & "', " &
                                       CDec(Trim(txtTotal.Text)) & ", " &
                                       CDec(Trim(txtBayar.Text)) & ", " &
                                       CDec(Trim(txtKembali.Text)) & ", '" &
                                       Trim(txtKodeC.Text) & "', '" &
                                       Trim(txtKodeD.Text) & "')"

                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()

                For baris As Integer = 0 To DataGridView1.Rows.Count - 1
                    query = "insert into tbl_detailjualresep(NoJual,KodeObat,NamaObat,JenisObat,HargaJual,JumlahJual,SubTotal)values('" & txtKode.Text &
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

            Dim totalTransaksi As Integer = Integer.Parse(txtTotal.Text)

            If SettingPoin.CheckBox2.Checked AndAlso CekPoin(totalTransaksi) Then
                MessageBox.Show("Anda mendapatkan 1 poin!")

                ' Update tabel tbl_customer dengan menambahkan 1 poin
                Dim cmdUpdate As New SqlCommand
                cmdUpdate.Connection = conn
                query = "UPDATE tbl_customer SET poin = poin + 1 WHERE kode_customer = '" & Trim(txtKodeC.Text) & "'"
                cmdUpdate.CommandText = query
                cmdUpdate.ExecuteNonQuery()
            Else
                MessageBox.Show("Anda tidak mendapatkan poin.")
            End If


            conn.Close()
        End If
        'drOpen.Close()
        '            query = "INSERT INTO Costumer VALUES ('" & Trim(txtKode_C.Text) & "', " & CInt(txtPoin.Text) & ")"
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
        '    Clear()
        'conn.Close()
        'End If
    End Sub

    Private Function CekPoin(totalTransaksi As Integer) As Boolean
        ' Mengambil nilai minimal transaksi dari setting poin
        Dim minTransaksi As Integer = SettingPoin.minTransaksi

        Return totalTransaksi >= minTransaksi
    End Function

    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Close()
    End Sub


    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Call KondisiAwal()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        vJResep = "JualResep"
        ListPenjualanResep.Close()
        ListPenjualanResep.MdiParent = mdiMenu
        ListPenjualanResep.Show()
    End Sub
    Private Sub btnCariD_Click(sender As Object, e As EventArgs) Handles btnCariD.Click
        vDokterJualR = "DokterJualR"
        ListDokter.Close()
        ListDokter.MdiParent = mdiMenu
        ListDokter.Show()
    End Sub
    Private Sub btnCariC_Click(sender As Object, e As EventArgs) Handles btnCariC.Click
        vCustomerJualR = "CustomerJualR"
        ListCustomer.Close()
        ListCustomer.MdiParent = mdiMenu
        ListCustomer.Show()
    End Sub

    Private Sub btnCariS_Click(sender As Object, e As EventArgs) Handles btnCariS.Click
        vStok = "JualRStok"
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
            query = "Delete from tbl_jualresep Where NoJual = '" & Trim(txtKode.Text) & "'"
            cmdopen.CommandText = query
            cmdopen.ExecuteNonQuery()

            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog= AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_jualresep Where NoJual = '" & Trim(txtKode.Text) & "'"
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

            query = "Delete from tbl_jualresep Where NoJual ='" & Trim(txtKode.Text) & "'"
            cmdopen.CommandText = query
            cmdopen.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Data Telah Dihapus")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub dgvDetail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.CurrentRow.Cells(0).Value <> "" Then

            txtKodeS.Text = DataGridView1.CurrentRow.Cells(0).Value
            txtNamaObat.Text = DataGridView1.CurrentRow.Cells(1).Value
            txtJenis.Text = DataGridView1.CurrentRow.Cells(2).Value
            txtQty.Text = Format(CDec(DataGridView1.CurrentRow.Cells(4).Value), "##,##0")
            txtHarga.Text = Format(CDec(DataGridView1.CurrentRow.Cells(3).Value), "##,##0.00")
            txtQty.Enabled = True
        End If
    End Sub
End Class