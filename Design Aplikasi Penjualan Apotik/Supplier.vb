Imports System.Data
Imports System.Data.SqlClient

Public Class Supplier
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
    Private Sub Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        txtKode.Text = ""
        Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn
        query = "Select * From tbl_supplier Where kode_supplier ='" & Trim(txtKode.Text) & "'"
        cmdOpen.CommandText = query

        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        If drOpen.HasRows Then
            query = "UPDATE tbl_supplier SET " &
                    "nama_supplier = '" & Trim(txtNama.Text) & "'," &
                    "alamat = '" & Trim(txtAlamat.Text) & "'," &
                    "no_telp = '" & Trim(txtTelp.Text) & "' " &
                    "WHERE kode_supplier = '" & Trim(txtKode.Text) & "'"
        Else
            query = "INSERT INTO tbl_supplier VALUES('" & Trim(txtKode.Text) & "','" & Trim(txtNama.Text) & "','" &
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
            query = "Select * From tbl_supplier Where kode_supplier ='" & Trim(txtKode.Text) & "'"
            cmdOpen.CommandText = query

            'Buat Data Adapter
            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.HasRows Then
                While drOpen.Read()
                    txtKode.Text = drOpen("kode_supplier").ToString
                    txtNama.Text = drOpen("nama_supplier").ToString
                    txtAlamat.Text = drOpen("alamat").ToString
                    txtTelp.Text = drOpen("no_telp").ToString
                End While
            Else
                Clear()
                txtNama.Select()
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
            query = "Delete From tbl_supplier Where kode_supplier ='" & Trim(txtKode.Text) & "'"
            cmdOpen.CommandText = query
            cmdOpen.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Data Telah Dihapus")
            Clear()
            txtKode.Select()
        End If
    End Sub

    Private Sub supplier_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        txtNama.Select()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub

    Private Sub supplier_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        txtNama.Select()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        vSupplier = "Supplier"
        ListSupplier.Close()
        ListSupplier.MdiParent = mdiMenu
        ListSupplier.Show()
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