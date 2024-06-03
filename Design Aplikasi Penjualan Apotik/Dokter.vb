Imports System.Data
Imports System.Data.SqlClient

Public Class Dokter
    Dim query As String
    Dim conn As New SqlConnection
    Public Sub Connect()
        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub
    Sub Clear()
        txtNama.Text = ""
        txtAlamat.Text = ""
        txtTelp.Text = ""
    End Sub
    Private Sub Dokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        txtKode.Text = ""
        Clear()
    End Sub

    Private Function IsNumeric(value As String) As Boolean
        Dim result As Decimal
        Return Decimal.TryParse(value, result)
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn
        query = "Select * From tbl_dokter Where kode_dokter ='" & Trim(txtKode.Text) & "'"
        cmdOpen.CommandText = query
        ' Validasi nomor telepon
        If Not IsNumeric(txtTelp.Text) Then
            MessageBox.Show("Nomor telepon harus berupa angka.")
            txtTelp.Select()
            Return
        End If
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        If drOpen.HasRows Then
            query = "UPDATE tbl_dokter SET " &
                    "nama_dokter = '" & Trim(txtNama.Text) & "'," &
                    "alamat = '" & Trim(txtAlamat.Text) & "'," &
                    "no_telp = '" & Trim(txtTelp.Text) & "' " &
                    "WHERE kode_dokter = '" & Trim(txtKode.Text) & "'"
        Else
            query = "Insert into tbl_dokter values('" & Trim(txtKode.Text) & "','" & Trim(txtNama.Text) & "','" &
                 Trim(txtAlamat.Text) & "','" &
                 Trim(txtTelp.Text) & "')"
        End If
        drOpen.Close()
        cmdOpen.CommandText = query
        cmdOpen.ExecuteNonQuery()

        conn.Close()

        MessageBox.Show("Data Telah Disimpan")
        Clear()
        txtKode.Select()
    End Sub

    Public Sub txtKode_LostFocus(sender As Object, e As EventArgs) Handles txtKode.LostFocus
        If Trim(txtKode.Text) <> "" Then
            Dim cmdOpen As New SqlCommand
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdOpen.Connection = conn
            query = "Select * From tbl_dokter Where kode_dokter ='" & Trim(txtKode.Text) & "'"
            cmdOpen.CommandText = query

            'Buat Data Adapter
            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.HasRows Then
                While drOpen.Read()
                    txtKode.Text = drOpen("kode_dokter").ToString
                    txtNama.Text = drOpen("nama_dokter").ToString
                    txtAlamat.Text = drOpen("alamat").ToString
                    txtTelp.Text = drOpen("no_telp").ToString
                End While
            Else
                Clear()
                txtAlamat.Select()
            End If
            drOpen.Close()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Clear()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If MessageBox.Show("Yakin mau dihapus?", "Konfirmasi", MessageBoxButtons.OKCancel) = vbOK Then
            Dim cmdOpen As New SqlCommand
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdOpen.Connection = conn
            query = "Delete From tbl_dokter Where kode_dokter ='" & Trim(txtKode.Text) & "'"
            cmdOpen.CommandText = query
            cmdOpen.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Data Telah Dihapus")
            Clear()
            txtKode.Select()
        End If
    End Sub

    Private Sub Dokter_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        txtAlamat.Select()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub

    Private Sub Dokter_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        txtAlamat.Select()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        vDokter = "Dokter"
        ListDokter.Close()
        ListDokter.Show()

    End Sub

    Private Sub txtTelp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelp.KeyPress
        Dim keyascii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" OrElse keyascii = Keys.Back) Then
            keyascii = 0
        Else
            e.Handled = CBool(keyascii)
        End If
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        Dim keyascii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z,a-z]" OrElse keyascii = Keys.Back) Then
            keyascii = 0
        Else
            e.Handled = CBool(keyascii)
        End If
    End Sub
End Class