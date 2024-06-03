Imports System.Data.SqlClient

Public Class User
    Dim query As String
    Dim conn As New SqlConnection

    Public Sub Connect()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=AplikasiPenjualan;Integrated Security=True"
    End Sub


    Sub KondisiAwal()
        txtKode.Text = ""
        txtNama.Text = ""
        txtPass.Text = ""
        CboLevel.Items.Clear()
        CboLevel.Text = ""
        txtKode.Enabled = False
        txtNama.Enabled = False
        txtPass.Enabled = False
        CboLevel.Enabled = False

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True

        Button1.Text = "Tambah"
        Button2.Text = "Edit"
        Button3.Text = "Hapus"
        Button4.Text = "Tutup"


        Connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn

        query = "Select * From akun order by kode_user,nama_user,password,level"
        cmdOpen.CommandText = query

        ' Hapus semua baris pada DataGridView sebelum menambahkan data baru
        dgv.Rows.Clear()


        'Buat Data Adapter
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader


        ' Tambahkan data baru ke DataGridView
        If drOpen.HasRows Then
            While drOpen.Read()
                dgv.Rows.Add(drOpen("kode_user").ToString, drOpen("nama_user"), drOpen("password"), drOpen("level"))

            End While
        End If
        drOpen.Close()
        conn.Close()
    End Sub
    Sub SiapIsi()
        txtKode.Enabled = True
        txtNama.Enabled = True
        txtPass.Enabled = True
        CboLevel.Enabled = True
        CboLevel.Items.Add("ADMIN")
        CboLevel.Items.Add("USER")
    End Sub
    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
        Else
            If txtKode.Text = "" Or txtNama.Text = "" Or txtPass.Text = "" Or CboLevel.Text = "" Then
                MsgBox("Silahkan isi semua Field")
            Else
                Connect()
                Dim cmdOpen As New SqlCommand()

                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmdOpen.Connection = conn


                query = "Insert into akun values('" & Trim(txtKode.Text) & "','" & Trim(txtNama.Text) & "','" & Trim(txtPass.Text) & "','" & Trim(CboLevel.Text) & "')"
                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()
                MsgBox("Input Data Berhasil")
                Call KondisiAwal()
            End If

            conn.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Edit" Then
            Button2.Text = "Simpan"
            Button1.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
        Else
            If txtKode.Text = "" Or txtNama.Text = "" Or txtPass.Text = "" Or CboLevel.Text = "" Then
                MsgBox("Silahkan isi semua Field")
            Else
                Connect()
                Dim cmdOpen As New SqlCommand()

                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmdOpen.Connection = conn


                query = "Update akun set nama_user = '" & Trim(txtNama.Text) & "',password = '" & Trim(txtPass.Text) & "',level = '" & Trim(CboLevel.Text) & "' where kode_user = '" & txtKode.Text & "'"
                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()
                MsgBox("Update Data Berhasil")
                Call KondisiAwal()
            End If

            conn.Close()
        End If
    End Sub

    Private Sub txtKode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKode.KeyPress
        If e.KeyChar = Chr(13) Then
            Connect()
            Dim cmdOpen As New SqlCommand()

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            cmdOpen.Connection = conn

            query = "Select * From akun Where kode_user ='" & Trim(txtKode.Text) & "'"
            cmdOpen.CommandText = query

            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.Read() Then ' Periksa apakah ada baris data yang tersedia
                txtKode.Text = drOpen("kode_user").ToString
                txtNama.Text = drOpen("nama_user").ToString
                txtPass.Text = drOpen("password").ToString
                CboLevel.Text = drOpen("level").ToString
            Else
                MsgBox("Kode User Tidak Ada")
            End If
            drOpen.Close()
            conn.Close()

        End If
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Tutup" Then
            Me.Close()
        Else
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "Hapus" Then
            Button3.Text = "Delete"
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Text = "Batal"
            Call SiapIsi()
        Else
            If txtKode.Text = "" Or txtNama.Text = "" Or txtPass.Text = "" Or CboLevel.Text = "" Then
                MsgBox("Silahkan isi semua Field")
            Else
                Connect()
                If MessageBox.Show("Yakin mau dihapus?", "Konfirmasi", MessageBoxButtons.OKCancel) = vbOK Then
                    Dim cmdOpen As New SqlCommand()

                    If conn.State = ConnectionState.Open Then conn.Close()
                    conn.Open()
                    cmdOpen.Connection = conn


                    query = "Delete From akun Where kode_user ='" & Trim(txtKode.Text) & "'"
                    cmdOpen.CommandText = query
                    cmdOpen.ExecuteNonQuery()
                    MessageBox.Show("Hapus Data Berhasil")
                    Call KondisiAwal()
                End If
            End If
            conn.Close()
        End If
    End Sub


    Private Sub dgv_DoubleClick(sender As Object, e As EventArgs) Handles dgv.DoubleClick
        Dim i As Integer
        i = dgv.CurrentRow.Index

        txtKode.Text = dgv.Item(0, i).Value
        txtNama.Text = dgv.Item(1, i).Value
        txtPass.Text = dgv.Item(2, i).Value
        CboLevel.Text = dgv.Item(3, i).Value
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