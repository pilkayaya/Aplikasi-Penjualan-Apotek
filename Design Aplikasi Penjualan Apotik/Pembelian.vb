Imports System.Data
Imports System.Data.SqlClient

Public Class Pembelian

    Dim query As String
    Private conn As New SqlConnection

    Public Sub connect()
        conn.ConnectionString = "Data Source=localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub

    Sub Clear()
        txtKode_C.Text = ""
        dtpTanggal.Value = Now.Date
        LBLNama.Text = ""
        txtKode.Text = ""
        LBLNamaObat.Text = ""
        LBLHarga.Text = ""
        LBLJenisObat.Text = ""
        txtQty.Text = ""
        txtQty.Enabled = False
        Label14.Text = "0"
        Call BuatKolom()
        Call NomorOtomatis()
        txtKode_C.Select()
    End Sub

    Private Sub Pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        Clear()
    End Sub
    Sub BuatKolom()
        dgvDetail.Columns.Clear()
        dgvDetail.Columns.Add("Kode", "Kode Obat")
        dgvDetail.Columns.Add("Nama", "Nama Obat")
        dgvDetail.Columns.Add("Jenis", "Jenis Obat")
        dgvDetail.Columns.Add("Harga", "Harga Satuan")
        dgvDetail.Columns.Add("Jumlah", "Qty")
        dgvDetail.Columns.Add("SubTotal", "Subtotal")

        dgvDetail.Columns(3).DefaultCellStyle.Format = "##,##0.00"
        dgvDetail.Columns(4).DefaultCellStyle.Format = "##,##0"
        dgvDetail.Columns(5).DefaultCellStyle.Format = "##,##0.00"
    End Sub

    Public Sub txtKode_C_LostFocus(sender As Object, e As EventArgs) Handles txtKode_C.LostFocus
        If Trim(txtKode_C.Text) <> "" Then
            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from tbl_supplier Where kode_supplier = '" & Trim(txtKode_C.Text) & "'"
                    cmdX.CommandText = query

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                LBLNama.Text = drX("nama_supplier")
                            End While
                        End If
                        drX.Close()
                    End Using
                End Using
            End Using
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
                                LBLHarga.Text = Format(drX("harga_beli"), "##,##0.00")
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
    Sub NomorOtomatis()
        connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn
        query = "Select * From beli where no_beli in(select max(no_beli) from beli)"
        cmdOpen.CommandText = query

        Dim UrutanKode As String
        Dim Hitung As Long
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader

        If drOpen.Read() Then
            Dim strKode As String = drOpen.GetString(0)
            If strKode.Length > 1 Then
                Dim strAngka As String = strKode.Substring(1) ' Menghapus karakter "L" di awal
                If Long.TryParse(strAngka, Hitung) Then
                    Hitung += 1
                Else
                    ' Penanganan jika konversi gagal, misalnya memberikan nilai default
                    Hitung = 1
                End If
            Else
                Hitung = 1
            End If
        Else
            Hitung = 1
        End If

        UrutanKode = "B" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        LBLNoBeli.Text = UrutanKode

        drOpen.Close()
        conn.Close()

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If LBLNamaObat.Text = "" Or txtQty.Text = "" Then
            MsgBox("Silahkan Masukan Kode Obat dan Tekan ENTER!")
        Else
            Dim KodeObat As String = txtKode.Text
            Dim qty As Integer = CInt(txtQty.Text)
            Dim obatTerdaftar As Boolean = False

            ' Periksa apakah kode obat sudah ada dalam DataGridView
            For Each row As DataGridViewRow In dgvDetail.Rows
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
                dgvDetail.Rows.Add(New String() {KodeObat, LBLNamaObat.Text, LBLJenisObat.Text, LBLHarga.Text, txtQty.Text, Val(LBLHarga.Text) * Val(txtQty.Text)})
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
        For i As Integer = 0 To dgvDetail.Rows.Count - 1
            Dim qty As Decimal = dgvDetail.Rows(i).Cells(4).Value
            Dim harga As Decimal = dgvDetail.Rows(i).Cells(3).Value
            Dim subTotal As Decimal = qty * harga
            If subTotal > 0 Then
                dgvDetail.Rows(i).Cells(5).Value = Format(subTotal, "##,##0.00")
            Else
                dgvDetail.Rows(i).Cells(5).Value = ""
            End If
            hitung += subTotal
        Next
        Label14.Text = Format(hitung, "##,##0.00")

    End Sub
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If LBLNama.Text = "" Or Label14.Text = "" Then
            MsgBox("Transaksi Tidak Ada, Silahkan Lakukan Transaksi Terlebih Dahulu")
        Else
            Dim cmdCheck As New SqlCommand

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmdCheck.Connection = conn
            cmdCheck.CommandText = "SELECT COUNT(*) FROM beli WHERE no_beli = '" & Trim(LBLNoBeli.Text) & "'"
            Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
            conn.Close()

            If count > 0 Then
                MsgBox("NoJual sudah ada dalam database. Mohon periksa kembali nomor transaksi.")
            Else
                conn.Open()
                Dim cmdOpen As New SqlCommand
                cmdOpen.Connection = conn
                Dim query As String = "INSERT INTO beli VALUES ('" & Trim(LBLNoBeli.Text) & "', '" & CDate(Trim(dtpTanggal.Text)) & "', '" &
                               CDec(Trim(Label14.Text)) & "', '" &
                               Trim(txtKode_C.Text) & "')"
                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()

                For baris As Integer = 0 To dgvDetail.Rows.Count - 1
                    query = "INSERT INTO beli_detail(no_beli, kode_obat, nama_obat, jenis_obat, harga_beli, jumlah_beli, sub_total)VALUES('" & LBLNoBeli.Text &
                            "','" & dgvDetail.Rows(baris).Cells(0).Value &
                            "','" & dgvDetail.Rows(baris).Cells(1).Value &
                            "','" & dgvDetail.Rows(baris).Cells(2).Value &
                            "','" & dgvDetail.Rows(baris).Cells(3).Value &
                            "','" & dgvDetail.Rows(baris).Cells(4).Value &
                            "','" & dgvDetail.Rows(baris).Cells(5).Value &
                            "')"
                    cmdOpen.CommandText = query
                    cmdOpen.ExecuteNonQuery()

                    query = "SELECT * FROM tbl_stok WHERE kode_obat ='" & dgvDetail.Rows(baris).Cells(0).Value & "'"
                    cmdOpen.CommandText = query
                    Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader()

                    If drOpen.Read() Then
                        drOpen.Close() ' Menutup SqlDataReader sebelum menjalankan perintah update

                        query = "UPDATE tbl_stok SET jumlah_stok = jumlah_stok + " & Val(dgvDetail.Rows(baris).Cells(4).Value) &
                      " WHERE kode_obat='" & dgvDetail.Rows(baris).Cells(0).Value & "'"
                        cmdOpen.CommandText = query
                        cmdOpen.ExecuteNonQuery()
                    End If

                    drOpen.Close()
                Next

                conn.Close()
                Clear()
                MsgBox("Transaksi Telah Berhasil Disimpan")
            End If
        End If
    End Sub



    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Clear()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If MessageBox.Show("Yakin mau dihapus?", "Konfirmasi", MessageBoxButtons.OKCancel) = vbOK Then
            Dim cmdopen As New SqlCommand
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdopen.Connection = conn
            query = "Delete from beli Where no_beli = '" & Trim(LBLNoBeli.Text) & "'"
            cmdopen.CommandText = query
            cmdopen.ExecuteNonQuery()

            Using cnn = New SqlConnection
                cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog= AplikasiPenjualan; Integrated Security = True"
                Using cmdX As New SqlCommand
                    cnn.Open()
                    cmdX.Connection = cnn
                    query = "Select * from beli_detail Where no_beli = '" & Trim(LBLNoBeli.Text) & "'"
                    cmdX.CommandText = query
                    cmdX.ExecuteNonQuery()

                    'Buat Data Adapter
                    Using drX As SqlDataReader = cmdX.ExecuteReader
                        If drX.HasRows Then
                            While drX.Read()
                                cmdopen.CommandText = "update tbl_stok set jumlah_stok = jumlah_stok - " & drX("jumlah_beli") &
                                                              "where kode_obat = '" & drX("kode_obat") & "'"
                                cmdopen.ExecuteNonQuery()
                            End While
                        End If
                        drX.Close()
                    End Using
                End Using
            End Using

            query = "Delete from beli_detail Where no_beli ='" & Trim(LBLNoBeli.Text) & "'"
            cmdopen.CommandText = query
            cmdopen.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Data Telah Dihapus")
            Clear()
        End If
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> Asc(vbBack) Then
            If Asc(e.KeyChar) < Asc(0) Or Asc(e.KeyChar) > Asc(9) Then
                e.Handled = True
            End If
        End If
    End Sub

    Function GetNameStok(X As String) As String
        Dim Y As String = ""
        If Trim(X) <> "" Then
            Dim cmdOpen As New SqlCommand
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdOpen.Connection = conn
            query = "Select * from tbl_stok Where kode_obat ='" & Trim(X) & "'"
            cmdOpen.CommandText = query

            'Buat Data Adapter
            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.HasRows Then
                While drOpen.Read()
                    Y = drOpen("nama_obat").ToString
                End While
            End If
            drOpen.Close()
        End If
        Return Y
    End Function

    Function GetPriceStok(X As String) As Decimal
        Dim Y As Decimal = 0
        If Trim(X) <> "" Then
            Dim cmdOpen As New SqlCommand
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdOpen.Connection = conn
            query = "Select * from tbl_stok Where kode_obat ='" & Trim(X) & "'"
            cmdOpen.CommandText = query

            'Buat Data Adapter
            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.HasRows Then
                While drOpen.Read()
                    Y = drOpen("harga_beli")
                End While
            End If
            drOpen.Close()
        End If
        Return Y
    End Function


    Private Sub txtQty_GotFocus(sender As Object, e As EventArgs)
        txtQty.SelectAll()
    End Sub


    Private Sub dgvDetail_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetail.CellDoubleClick
        If dgvDetail.CurrentRow.Cells(0).Value <> "" Then

            txtKode.Text = dgvDetail.CurrentRow.Cells(0).Value
            LBLNamaObat.Text = dgvDetail.CurrentRow.Cells(1).Value
            LBLJenisObat.Text = dgvDetail.CurrentRow.Cells(2).Value
            txtQty.Text = Format(CDec(dgvDetail.CurrentRow.Cells(4).Value), "##,##0")
            LBLHarga.Text = Format(CDec(dgvDetail.CurrentRow.Cells(3).Value), "##,##0.00")
            txtQty.Enabled = True
        End If
    End Sub

    Private Sub btnCari_C_Click(sender As Object, e As EventArgs) Handles btnCari_C.Click
        vSupplierBeli = "SupplierBeli"
        ListSupplier.Close()
        ListSupplier.MdiParent = mdiMenu
        ListSupplier.Show()
    End Sub
    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        vBeli = "Beli"
        ListBeli.Close()
        ListBeli.MdiParent = mdiMenu
        ListBeli.Show()
    End Sub
    Private Sub btnCari_S_Click_1(sender As Object, e As EventArgs) Handles btnCari_S.Click
        vStok = "BeliStok"
        ListStok.Close()
        ListStok.MdiParent = mdiMenu
        ListStok.Show()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

End Class
