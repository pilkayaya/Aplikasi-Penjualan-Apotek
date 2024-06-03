Imports System.Data
Imports System.Data.SqlClient

Public Class ListStok
    Dim query As String
    Dim conn As New SqlConnection

    Public Sub Connect()
        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub

    Private Sub ListStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        cboCari.Items.Clear()
        cboCari.Items.Add("Kode Obat")
        cboCari.Items.Add("Nama Obat")
        cboCari.Items.Add("Jenis Obat")
        cboCari.Items.Add("Harga Beli")
        cboCari.Items.Add("Harga Jual")
        cboCari.Items.Add("Jumlah Stok")

        cboCari.SelectedIndex = 1
        Connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn

        query = "Select * From tbl_stok order by kode_obat"
        cmdOpen.CommandText = query

        'Buat Data Adapter
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        i = 1

        'Buat Data Adapter
        If drOpen.HasRows Then
            While drOpen.Read()
                dgv.Rows.Add(i, drOpen("kode_obat").ToString, drOpen("nama_obat"), drOpen("jenis_obat"), drOpen("harga_beli"), drOpen("harga_jual"), drOpen("jumlah_stok"))
                i = i + 1
            End While
        End If
        drOpen.Close()
        conn.Close()

        dgv.Columns(4).DefaultCellStyle.Format = "Rp##,##0.00"
        dgv.Columns(5).DefaultCellStyle.Format = "Rp##,##0.00"
        dgv.Columns(6).DefaultCellStyle.Format = "##,##0"
    End Sub

    Private Sub cboCari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cboCari.Text <> "" Then
                Dim cmdOpen As New SqlCommand
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmdOpen.Connection = conn
                Dim jenis As String = ""
                Select Case cboCari.Text
                    Case "Kode Obat" : jenis = "kode_obat"
                    Case "Nama Obat" : jenis = "nama_obat"
                    Case "Jenis Obat" : jenis = "jenis_obat"
                    Case "Harga Beli" : jenis = "harga_beli"
                    Case "Harga Jual" : jenis = "harga_jual"
                    Case "Jumlah Stok" : jenis = "jumlah_stok"
                End Select

                dgv.Rows.Clear()

                query = "Select * From tbl_stok Where " & jenis & " like '%" & Trim(txtCari.Text) & "%'"
                query = query & " Order By kode_obat"
                cmdOpen.CommandText = query

                'Buat Data Adapter
                Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("kode_obat").ToString, drOpen("nama_obat"), drOpen("jenis_obat"), drOpen("harga_beli"), drOpen("harga_jual"), drOpen("jumlah_stok"))
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

                query = "Select * From tbl_stok "
                query = query & "Order By kode_obat"
                cmdopen.CommandText = query

                'Buat Data Adapter

                Dim drOpen As SqlDataReader = cmdopen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter If drOpen.HasRows Then
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("kode_obat").ToString, drOpen("nama_obat"), drOpen("jenis_obat"), drOpen("harga_beli"), drOpen("harga_jual"), drOpen("jumlah_stok"))
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
            Select Case vStok
                Case "Stok"
                    Stok.txtKodeObat.Text = dgv.CurrentRow.Cells(1).Value
                    Call Stok.txtKode_LostFocus(sender, e)
                Case "BeliStok"
                    Pembelian.txtKode.Text = dgv.CurrentRow.Cells(1).Value
                    Call Pembelian.txtKode_LostFocus(sender, e)
                Case "JualStok"
                    JualNonResep.txtKode.Text = dgv.CurrentRow.Cells(1).Value
                    Call JualNonResep.txtKode_LostFocus(sender, e)
                Case "JualRStok"
                    PenjualanResep.txtKodeS.Text = dgv.CurrentRow.Cells(1).Value
                    Call PenjualanResep.txtKodeS_LostFocus(sender, e)
            End Select

            Me.Close()
        End If
    End Sub

    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgv.CurrentRow.Cells(1).Value <> "" Then
                Select Case vStok
                    Case "Stok"
                        Stok.txtKodeObat.Text = dgv.CurrentRow.Cells(1).Value
                        Call Stok.txtKode_LostFocus(sender, e)
                End Select
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ListStok_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class