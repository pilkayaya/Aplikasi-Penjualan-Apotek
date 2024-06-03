Imports System.Data
Imports System.Data.SqlClient

Public Class ListSupplier
    Dim query As String
    Dim conn As New SqlConnection

    Public Sub Connect()
        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub

    Private Sub ListSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        cboCari.Items.Clear()
        cboCari.Items.Add("Kode Supplier")
        cboCari.Items.Add("Nama Supplier")
        cboCari.Items.Add("Alamat")
        cboCari.Items.Add("No. Telp")

        cboCari.SelectedIndex = 1
        Connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn

        query = "Select * From tbl_supplier order by kode_supplier"
        cmdOpen.CommandText = query

        'Buat Data Adapter
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        i = 1

        'Buat Data Adapter
        If drOpen.HasRows Then
            While drOpen.Read()
                dgv.Rows.Add(i, drOpen("kode_supplier").ToString, drOpen("nama_supplier"), drOpen("alamat"), drOpen("no_telp"))
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
                    Case "Kode supplier" : Jenis = "kode_supplier"
                    Case "Nama supplier" : Jenis = "nama_supplier"
                    Case "Alamat" : Jenis = "alamat"
                    Case "No. Telp" : Jenis = "no_telp"
                End Select

                dgv.Rows.Clear()

                query = "Select * From tbl_supplier Where " ' & Jenis & " like  '%" & Trim(txtCari.Text) & "%'"
                query = query & " Order By kode_supplier"
                cmdOpen.CommandText = query

                'Buat Data Adapter
                Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("kode_supplier").ToString, drOpen("nama_supplier"), drOpen("alamat"), drOpen("no_telp"))
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

                query = "Select * From tbl_supplier "
                query = query & "Order By kode_supplier"
                cmdopen.CommandText = query

                'Buat Data Adapter

                Dim drOpen As SqlDataReader = cmdopen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter If drOpen.HasRows Then
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("kode_supplier").ToString, drOpen("nama_supplier"), drOpen("alamat"), drOpen("no_telp"))
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
            Select Case vSupplier
                Case "Supplier"
                    Supplier.txtKode.Text = dgv.CurrentRow.Cells(1).Value
                    Call Supplier.txtKode_LostFocus(sender, e)
            End Select
            Select Case vSupplierBeli
                Case "SupplierBeli"
                    Pembelian.txtKode_C.Text = dgv.CurrentRow.Cells(1).Value
                    Call Pembelian.txtKode_C_LostFocus(sender, e)
            End Select
            Me.Close()
        End If
    End Sub

    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgv.CurrentRow.Cells(1).Value <> "" Then
                Select Case vSupplier
                    Case "Supplier"
                        Supplier.txtKode.Text = dgv.CurrentRow.Cells(1).Value
                        Call Supplier.txtKode_LostFocus(sender, e)

                End Select
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ListSupplier_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub
End Class