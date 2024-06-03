Imports System.Data
Imports System.Data.SqlClient

Public Class ListDokter
    Dim query As String
    Dim conn As New SqlConnection

    Public Sub Connect()
        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub

    Private Sub Listdokter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        cboCari.Items.Clear()
        cboCari.Items.Add("Kode dokter")
        cboCari.Items.Add("Nama Dokter")
        cboCari.Items.Add("Alamat")
        cboCari.Items.Add("No Telepon")

        cboCari.SelectedIndex = 1
        Connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn

        query = "Select * From tbl_dokter order by kode_dokter"
        cmdOpen.CommandText = query

        'Buat Data Adapter
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        i = 1

        'Buat Data Adapter
        If drOpen.HasRows Then
            While drOpen.Read()
                dgv.Rows.Add(i, drOpen("kode_dokter").ToString, drOpen("nama_dokter"), drOpen("alamat"), drOpen("no_telp"))
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
                Dim jenis As String = ""
                Select Case cboCari.Text
                    Case "Kode dokter" : jenis = "kode_dokter"
                    Case "Nama Dokter" : jenis = "nama_dokter"
                    Case "Alamat" : jenis = "alamat"
                    Case "No Telepon" : jenis = "no_telp"
                End Select

                dgv.Rows.Clear()

                query = "Select * From tbl_dokter Where " & jenis & " like '%" & Trim(txtCari.Text) & "%'"
                query = query & " Order By kode_dokter"
                cmdOpen.CommandText = query

                'Buat Data Adapter
                Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("kode_dokter").ToString, drOpen("nama_dokter"), drOpen("alamat"), drOpen("no_telp"))
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

                query = "Select * From tbl_dokter "
                query = query & "Order By kode_dokter"
                cmdopen.CommandText = query

                'Buat Data Adapter

                Dim drOpen As SqlDataReader = cmdopen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter If drOpen.HasRows Then
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("kode_dokter").ToString, drOpen("nama_dokter"), drOpen("Alamat"), drOpen("no_telp"))
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
            Select Case vDokter
                Case "Dokter"
                    Dokter.txtKode.Text = dgv.CurrentRow.Cells(1).Value
                    Call Dokter.txtKode_LostFocus(sender, e)
            End Select
            Select Case vDokterJualR
                Case "DokterJualR"
                    PenjualanResep.txtKodeD.Text = dgv.CurrentRow.Cells(1).Value
                    Call PenjualanResep.txtKodeD_LostFocus(sender, e)
            End Select
            Me.Close()
        End If
    End Sub

    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgv.CurrentRow.Cells(1).Value <> "" Then
                Select Case vDokter
                    Case "dokter"
                        Dokter.txtKode.Text = dgv.CurrentRow.Cells(1).Value
                        Call Dokter.txtKode_LostFocus(sender, e)
                End Select
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Listdokter_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub
End Class