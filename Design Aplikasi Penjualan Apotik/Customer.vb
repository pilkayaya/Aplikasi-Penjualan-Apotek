Imports System.Data
Imports System.Data.SqlClient

Public Class Customer
    Public Shared Points As Integer = 0
    Dim query As String
    Dim conn As New SqlConnection
    Public Sub Connect()
        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub
    Sub Clear()
        txtNama.Text = ""
        txtAlamat.Text = ""
        txtTelp.Text = ""
        txtPoin.Text = ""
        CboStatus.Items.Clear()
        CboStatus.Items.Add("Member")
        CboStatus.Items.Add("Non Member")
    End Sub
    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        txtKode.Text = ""
        Clear()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn
        query = "Select * From tbl_customer Where kode_customer ='" & Trim(txtKode.Text) & "'"
        cmdOpen.CommandText = query

        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        If drOpen.HasRows Then
            query = "update tbl_customer set " &
                    "nama_customer = '" & Trim(txtNama.Text) & "'," &
                    "Status_customer = '" & Trim(CboStatus.Text) & "'," &
                    "alamat = '" & Trim(txtAlamat.Text) & "'," &
                    "no_telp = '" & Trim(txtTelp.Text) & "'," &
                    "poin = '" & Trim(txtPoin.Text) & "'" &
                    "where kode_customer = '" & Trim(txtKode.Text) & "'"
        Else
            query = "Insert into tbl_customer values('" & Trim(txtKode.Text) & "', '" & Trim(txtNama.Text) & "', '" &
                Trim(CboStatus.Text) & "', '" &
                Trim(txtPoin.Text) & "', '" &
                Trim(txtAlamat.Text) & "', '" &
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
            query = "Select * From tbl_customer Where kode_customer ='" & Trim(txtKode.Text) & "'"
            cmdOpen.CommandText = query

            'Buat Data Adapter
            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.HasRows Then
                While drOpen.Read()
                    txtKode.Text = drOpen("kode_customer").ToString
                    txtNama.Text = drOpen("nama_customer").ToString
                    txtAlamat.Text = drOpen("alamat").ToString
                    txtTelp.Text = drOpen("no_telp").ToString
                    txtPoin.Text = drOpen("poin").ToString
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
            query = "Delete From tbl_customer Where kode_customer ='" & Trim(txtKode.Text) & "'"
            cmdOpen.CommandText = query
            cmdOpen.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Data Telah Dihapus")
            Clear()
            txtKode.Select()
        End If
    End Sub

    Private Sub Customer_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        txtNama.Select()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub

    Private Sub Customer_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        txtNama.Select()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        vCustomer = "Customer"
        ListCustomer.Close()
        ListCustomer.MdiParent = mdiMenu
        ListCustomer.Show()
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