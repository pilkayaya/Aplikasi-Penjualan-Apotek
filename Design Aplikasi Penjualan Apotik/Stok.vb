Imports System.Data
Imports System.Data.SqlClient

Public Class Stok
    Dim query As String
    Dim conn As New SqlConnection


    Public Sub Connect()
        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub

    Sub Clear()
        txtNamaObat.Text = ""
        CboJenisObat.Text = ""
        CboJenisObat.Items.Clear()
        CboJenisObat.Items.Add("Strip")
        CboJenisObat.Items.Add("Pcs")
        CboJenisObat.Items.Add("Botol")
        CboJenisObat.Items.Add("Sachet")
        CboJenisObat.Items.Add("Tube")
        CboJenisObat.Items.Add("Kotak")
        txtBeli.Text = 0
        txtJual.Text = 0
        txtStok.Text = 0

    End Sub

    Private Sub Stok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        Call NomorOtomatis()
        Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn

        query = "SELECT * FROM tbl_stok WHERE kode_obat ='" & Trim(txtKodeObat.Text) & "'"
        cmdOpen.CommandText = query

        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        If drOpen.HasRows Then
            query = "UPDATE tbl_stok SET " &
                "nama_obat = '" & Trim(txtNamaObat.Text) & "', " &
                "jenis_obat = '" & Trim(CboJenisObat.Text) & "', " &
                "harga_beli = " & CDec(Trim(txtBeli.Text)) & ", " &
                "harga_jual = " & CDec(Trim(txtJual.Text)) & ", " &
                "jumlah_stok = " & CInt(Trim(txtStok.Text)) &
                " WHERE kode_obat = '" & Trim(txtKodeObat.Text) & "'"
        Else
            query = "INSERT INTO tbl_stok Values ('" & Trim(txtKodeObat.Text) & "', '" & Trim(txtNamaObat.Text) & "', '" &
                Trim(CboJenisObat.Text) & "', " &
                CDec(Trim(txtBeli.Text)) & ", " &
                CDec(Trim(txtJual.Text)) & ", " &
                CInt(Trim(txtStok.Text)) & ")"
        End If

        drOpen.Close()
        cmdOpen.CommandText = query
        cmdOpen.ExecuteNonQuery()

        conn.Close()

        MessageBox.Show("Data Telah Disimpan")
        Clear()
        txtKodeObat.Select()

    End Sub


    Public Sub txtKode_LostFocus(sender As Object, e As EventArgs) Handles txtKodeObat.LostFocus
        If Trim(txtKodeObat.Text) <> "" Then
            Dim cmdOpen As New SqlCommand
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdOpen.Connection = conn
            query = "Select * From tbl_stok Where kode_obat ='" & Trim(txtKodeObat.Text) & "'"
            cmdOpen.CommandText = query

            'Buat Data Adapter
            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.HasRows Then
                While drOpen.Read()
                    txtKodeObat.Text = drOpen("kode_obat").ToString
                    txtNamaObat.Text = drOpen("nama_obat").ToString
                    CboJenisObat.Text = drOpen("jenis_obat").ToString
                    txtBeli.Text = Format(drOpen("harga_beli"), "##,##0.00")
                    txtJual.Text = Format(drOpen("harga_jual"), "##,##0.00")
                    txtStok.Text = Format(drOpen("jumlah_stok"), "##,##0")
                End While
            Else
                Clear()
                txtNamaObat.Select()
            End If
            drOpen.Close()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Clear()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If MessageBox.Show("Yakin mau dihapus?", "Konfirmasi", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            Dim cmdOpen As New SqlCommand
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdOpen.Connection = conn
            query = "Delete From tbl_stok Where kode_obat ='" & Trim(txtKodeObat.Text) & "'"
            cmdOpen.CommandText = query
            cmdOpen.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Data Telah Dihapus")
            Clear()
            txtKodeObat.Select()
        End If
    End Sub

    Private Sub txtBeli_LostFocus(sender As Object, e As EventArgs) Handles txtBeli.LostFocus
        If Not IsNumeric(Trim(txtBeli.Text)) Then txtBeli.Text = 0
        txtBeli.Text = Format(CDec(txtBeli.Text), "##,##0.00")
    End Sub

    Private Sub txtJual_LostFocus(sender As Object, e As EventArgs) Handles txtJual.LostFocus
        If Not IsNumeric(Trim(txtJual.Text)) Then txtJual.Text = 0
        txtJual.Text = Format(CDec(txtJual.Text), "##,##0.00")
    End Sub

    Private Sub txtStok_LostFocus(sender As Object, e As EventArgs) Handles txtStok.LostFocus
        If Not IsNumeric(Trim(txtStok.Text)) Then txtStok.Text = 0
        txtStok.Text = Format(CDec(txtStok.Text), "##,##0")
    End Sub

    Private Sub Stok_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        txtNamaObat.Select()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub

    Private Sub txtBeli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBeli.KeyPress
        If Asc(e.KeyChar) <> Asc(vbBack) Then
            If Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtJual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJual.KeyPress
        If Asc(e.KeyChar) <> Asc(vbBack) Then
            If Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtStok_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStok.KeyPress
        If Asc(e.KeyChar) <> Asc(vbBack) Then
            If Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Stok_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        txtNamaObat.Select()
    End Sub


    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        vStok = "Stok"
        listStok.Close()
        listStok.MdiParent = mdiMenu
        listStok.Show()
    End Sub

    Sub NomorOtomatis()
        Connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn
        query = "Select * From tbl_stok where kode_obat in(select max(kode_obat) from tbl_stok)"
        cmdOpen.CommandText = query

        Dim UrutanKode As String
        Dim Hitung As Long
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        If drOpen.HasRows Then
            drOpen.Read()
            If Not drOpen.IsDBNull(0) Then
                Hitung = Microsoft.VisualBasic.Right(drOpen.GetString(0), 3) + 1
            Else
                Hitung = 1
            End If
            UrutanKode = "D" + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        Else
            UrutanKode = "D" + "001"
        End If
        txtKodeObat.Text = UrutanKode
    End Sub

End Class
