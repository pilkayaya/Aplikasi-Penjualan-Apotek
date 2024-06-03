Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Public Class ListPenjualanResep
    Dim query As String
    Dim conn As New SqlConnection
    Public Sub connect()
        conn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
    End Sub
    Private Sub ListPenjualanResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        cboCari.Items.Clear()
        cboCari.Items.Add("No Jual")
        cboCari.Items.Add("No Resep")
        cboCari.Items.Add("Kode Dokter")
        cboCari.Items.Add("Kode Customer")
        cboCari.Items.Add("Tanggal")
        cboCari.Items.Add("Total")

        cboCari.SelectedIndex = 1
        connect()
        Dim cmdOpen As New SqlCommand
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        cmdOpen.Connection = conn

        query = "Select * From tbl_jualresep order by NoJual"
        cmdOpen.CommandText = query


        'Buat Data Adapter
        Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
        i = 1

        'Buat Data Adapter
        If drOpen.HasRows Then
            While drOpen.Read()
                dgv.Rows.Add(i, drOpen("NoJual").ToString, drOpen("NoResep").ToString, drOpen("KodeDokter"), drOpen("KodeCustomer"), drOpen("TglJual"), drOpen("TotalJual"))
                i = i + 1
            End While
        End If
        drOpen.Close()
        conn.Close()
        dgv.Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"
        dgv.Columns(6).DefaultCellStyle.Format = "Rp##,##0.00"
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
                    Case "No Jual" : jenis = "NoJual"
                    Case "No Resep" : jenis = "NoResep"
                    Case "Kode Dokter" : jenis = "KodeDokter"
                    Case "Kode Customer" : jenis = "KodeCustomer"
                    Case "Tanggal" : jenis = "TglJual"
                    Case "Total" : jenis = "TotalJual"
                End Select

                dgv.Rows.Clear()

                query = "Select * From tbl_jualresep Where " & jenis & " like '%" & Trim(txtCari.Text) & "%'"
                query = query & "Order By NoJual"
                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()

                'Buat Data Adapter
                Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("NoJual").ToString, drOpen("NoResep").ToString, drOpen("KodeDokter"), drOpen("KodeCustomer"), drOpen("TglJual"), drOpen("TotalJual"))
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

                query = "Select * From tbl_jualresep "
                query = query & " Order By NoJual"
                cmdOpen.CommandText = query
                cmdOpen.ExecuteNonQuery()

                'Buat Data Adapter
                Dim drOpen As SqlDataReader = cmdOpen.ExecuteReader
                Dim i As Integer
                i = 1

                'Buat Data Adapter
                If drOpen.HasRows Then
                    While drOpen.Read()
                        dgv.Rows.Add(i, drOpen("NoJual").ToString, drOpen("NoResep").ToString, drOpen("KodeDokter"), drOpen("KodeCustomer"), drOpen("TglJual"), drOpen("TotalJual"))
                        i = i + 1
                    End While
                End If
                drOpen.Close()
                conn.Close()
            End If
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If dgv.CurrentRow.Cells(1).Value <> "" Then
            Select Case vJResep
                Case "JualResep"
                    PenjualanResep.txtKodeD.Text = dgv.CurrentRow.Cells(3).Value
                    PenjualanResep.txtKodeD_LostFocus(sender, e)
                    PenjualanResep.txtKodeC.Text = dgv.CurrentRow.Cells(4).Value
                    PenjualanResep.txtKodeC_LostFocus(sender, e)
                    PenjualanResep.txtTotal.Text = Decimal.Parse(dgv.CurrentRow.Cells(6).Value).ToString("##,##0.00")


            End Select
            Me.Close()
        End If
    End Sub


    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv.KeyDown
        If dgv.CurrentRow.Cells(3).Value <> "" Then
            Select Case vJResep
                Case "JualResep"
                    PenjualanResep.txtKodeD.Text = dgv.CurrentRow.Cells(3).Value
                    PenjualanResep.txtKodeD_LostFocus(sender, e)
                    PenjualanResep.txtTotal.Text = Decimal.Parse(dgv.CurrentRow.Cells(6).Value).ToString("##,##0.00")
                    PenjualanResep.dtpTanggal.Text = Date.Parse(dgv.CurrentRow.Cells(5).Value).ToString("dd/MM/yyyy")

            End Select
            Me.Close()
        End If

    End Sub


    Private Sub JualResep_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If conn.State = ConnectionState.Open Then conn.Close()
        conn = Nothing
    End Sub
End Class
