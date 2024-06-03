Imports System.Data
Imports System.Data.SqlClient

Public Class ListMember
    Dim query As String
    Dim conn As New SqlConnection

    Public Sub Connect()
        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub

    Private Sub Listmember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        cboCari.Items.Clear()
        cboCari.Items.Add("Kode member")
        cboCari.Items.Add("Nama member")
        cboCari.Items.Add("Alamat")
        cboCari.Items.Add("No. Telp")
        cboCari.Items.Add("Poin")

        cboCari.SelectedIndex = 1
        Connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn

        query = "Select * From tbl_member order by kode_member"
        cmdOpen.CommandText = query

        'Buat Data Adapter
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        i = 1

        'Buat Data Adapter
        If drOpen.HasRows Then
            While drOpen.Read()
                dgv.Rows.Add(i, drOpen("kode_member").ToString, drOpen("nama_member"), drOpen("alamat"), drOpen("no_telp"), drOpen("poin"))
                i = i + 1
            End While
        End If
        drOpen.Close()
        conn.Close()
    End Sub

    Private Sub txtCari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cboCari.Text <> "" Then
                Dim cmdOpen As New SqlCommand
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmdOpen.Connection = conn
                Dim jenis As String
                Select Case cboCari.Text
                    Case "Kode member" : jenis = "kode_member"
                    Case "Nama member" : jenis = "nama_member"
                    Case "Alamat" : jenis = "alamat"
                    Case "No. Telp" : jenis = "no_telp"
                    Case "Poin" : jenis = "poin"
                End Select

                dgv.Rows.Clear()

                query = "Select * From tbl_member Where " ' & Jenis & " like  '%" & Trim(txtCari.Text) & "%'"
                query = query & " Order By kode_member"
                cmdOpen.CommandText = query

                'Buat Data Adapter
                Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("kode_member").ToString, drOpen("nama_member"), drOpen("alamat"), drOpen("no_telp"), drOpen("poin"))
                        i = i + 1
                    End While
                End If
                drOpen.Close()
                conn.Close()
            Else
                Dim cmdopen As New SqlCommand
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmdopen.Connection = conn

                dgv.Rows.Clear()

                query = "Select * From tbl_member "
                query = query & "Order By kode_member"
                cmdopen.CommandText = query

                'Buat Data Adapter

                Dim drOpen As SqlDataReader = cmdopen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter If drOpen.HasRows Then
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("kode_member").ToString, drOpen("nama_member"), drOpen("alamat"), drOpen("no_telp"), drOpen("poin"))
                        i = i + 1
                    End While
                End If
                drOpen.Close()
                conn.Close()
            End If
        End If
    End Sub

    Private Sub dgv_DoubleClick(sender As Object, e As EventArgs) Handles dgv.DoubleClick
        If dgv.CurrentRow.Cells(1).Value <> "" Then
            Select Case vMember
                Case "member"
                    Member.txtKode.Text = dgv.CurrentRow.Cells(1).Value
                    Call Member.txtKode_LostFocus(sender, e)
            End Select
            Me.Close()
        End If
    End Sub

    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgv.CurrentRow.Cells(1).Value <> "" Then
                Select Case vMember
                    Case "member"
                        Member.txtKode.Text = dgv.CurrentRow.Cells(1).Value
                        Call Member.txtKode_LostFocus(sender, e)
                End Select
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Listmember_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub

End Class