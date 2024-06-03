Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader

Public Class ListBeli
    Dim query As String
    Dim conn As New SqlConnection

    Public Sub connect()
        conn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub
    Private Sub ListBeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        cboCari.Items.Clear()
        cboCari.Items.Add("No Beli")
        cboCari.Items.Add("Kode Supplier")
        cboCari.Items.Add("Tanggal")
        cboCari.Items.Add("Total")

        cboCari.SelectedIndex = 1
        connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn

        query = "Select * From beli order by no_beli"
        cmdOpen.CommandText = query


        'Buat Data Adapter
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        i = 1

        'Buat Data Adapter
        If drOpen.HasRows Then
            While drOpen.Read()
                dgv.Rows.Add(i, drOpen("no_beli").ToString, drOpen("kode_supplier"), drOpen("tanggal"), drOpen("total"))
                i = i + 1
            End While
        End If
        drOpen.Close()
        conn.Close()
        dgv.Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
        dgv.Columns(4).DefaultCellStyle.Format = "Rp##,##0.00"
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
                    Case "No Beli" : jenis = "no_beli"
                    Case "Kode Supplier" : jenis = "kode_supplier"
                    Case "Tanggal" : jenis = "tanggal"
                    Case "Total" : jenis = "total"
                End Select

                dgv.Rows.Clear()

                query = "Select * From beli Where " & jenis & " like '%" & Trim(txtCari.Text) & "%'"
                query = query & "Order By no_beli"
                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()

                'Buat Data Adapter
                Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("no_beli").ToString, drOpen("kode_supplier"), drOpen("tanggal"), drOpen("total"))
                        i = i + 1
                    End While
                End If
                drOpen.Close()
                conn.Close()
            Else
                Dim cmdOpen As New SqlCommand
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                cmdOpen.Connection = conn

                dgv.Rows.Clear()

                query = "Select * From beli "
                query = query & " Order By no_beli"
                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()

                'Buat Data Adapter
                Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("no_beli").ToString, drOpen("kode_supplier"), drOpen("tanggal"), drOpen("total"))
                        i = i + 1
                    End While
                End If
                drOpen.Close()
                conn.Close()
            End If
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If dgv.CurrentRow.Cells(2).Value <> "" Then
            Select Case vBeli
                Case "Beli"
                    Pembelian.txtKode_C.Text = dgv.CurrentRow.Cells(2).Value
                    Pembelian.txtKode_C_LostFocus(sender, e)
                    Pembelian.Label14.Text = Decimal.Parse(dgv.CurrentRow.Cells(4).Value).ToString("##,##0.00")
                    Pembelian.dtpTanggal.Text = Date.Parse(dgv.CurrentRow.Cells(3).Value).ToString("dd/MM/yyyy")

            End Select
            Me.Close()
        End If
    End Sub


    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case vBeli
                Case "Beli"
                    Pembelian.txtKode_C.Text = dgv.CurrentRow.Cells(2).Value
                    Pembelian.txtKode_C_LostFocus(sender, e)
                    Pembelian.Label14.Text = Decimal.Parse(dgv.CurrentRow.Cells(4).Value).ToString("##,##0.00")
                    Pembelian.dtpTanggal.Text = Date.Parse(dgv.CurrentRow.Cells(3).Value).ToString("dd/MM/yyyy")

            End Select
            Me.Close()
        End If
    End Sub


    Private Sub JualNonResep_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub
End Class