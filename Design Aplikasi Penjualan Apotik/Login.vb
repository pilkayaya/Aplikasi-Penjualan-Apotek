Imports System.Data.SqlClient
Imports System.Reflection.Emit

Public Class Login
    Dim query As String
    Dim conn As New SqlConnection

    Public Sub Connect()
        conn.ConnectionString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=AplikasiPenjualan;Integrated Security=True"
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Sub Terbuka()
        mdiMenu.LogoutToolStripMenuItem.Enabled = True
        mdiMenu.LoginToolStripMenuItem.Enabled = False
        mdiMenu.MasterToolStripMenuItem.Enabled = True
        mdiMenu.TransaksiToolStripMenuItem.Enabled = True
        mdiMenu.LaporanToolStripMenuItem.Enabled = True
        mdiMenu.UtilityToolStripMenuItem.Enabled = True
    End Sub
    Sub KondisiAwal()
        txtKode.Text = ""
        txtPass.Text = ""
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtKode.Text = "" Or txtPass.Text = "" Then
            MsgBox("Silahkan isi Kode User dan Password !")
        Else
            Connect() ' Panggil metode Connect untuk menginisialisasi koneksi
            Dim cmdOpen As New SqlCommand()
            cmdOpen.Connection = conn

            query = "Select * From akun where kode_user = '" & txtKode.Text & "' and password='" & txtPass.Text & "'"
            cmdOpen.CommandText = query

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
            If drOpen.Read() Then
                Me.Close()
                Call Terbuka()
                MsgBox("Login sukses")

                mdiMenu.Slabel2.Text = "" & drOpen("kode_user").ToString()
                mdiMenu.Slabel4.Text = "" & drOpen("nama_user").ToString()
                mdiMenu.Slabel6.Text = "" & drOpen("level").ToString()


                mdiMenu.LoginToolStripMenuItem.Enabled = False
                mdiMenu.LoginToolStripMenuItem.Enabled = True
                mdiMenu.StokToolStripMenuItem.Enabled = True
                mdiMenu.DokterToolStripMenuItem.Enabled = True
                mdiMenu.CustomerToolStripMenuItem.Enabled = True
                mdiMenu.SupplierToolStripMenuItem.Enabled = True
                mdiMenu.MemberToolStripMenuItem.Enabled = True
                mdiMenu.TransaksiToolStripMenuItem.Enabled = True
                mdiMenu.LaporanToolStripMenuItem.Enabled = True
                mdiMenu.UtilityToolStripMenuItem.Enabled = True
                If mdiMenu.Slabel6.Text = "USER" Then
                    mdiMenu.UserToolStripMenuItem.Enabled = False
                    mdiMenu.StokToolStripMenuItem.Enabled = False
                Else
                    mdiMenu.UserToolStripMenuItem.Enabled = True
                End If
            Else
                MsgBox("Kode User atau Password salah!")
            End If
            drOpen.Close()
            conn.Close()
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        txtPass.PasswordChar = "X"
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtPass.PasswordChar = ""
        Else
            txtPass.PasswordChar = "X"
        End If
    End Sub
End Class

