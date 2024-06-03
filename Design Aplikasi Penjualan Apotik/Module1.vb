Imports System.Data
Imports System.Data.SqlClient

Module Module1
    Public conn As New SqlConnection
    Public Da As SqlDataAdapter
    Public drOpen As SqlDataReader
    Public cmdOpen As New SqlCommand
    Public Ds As DataSet
    Public Sub Connect()
        conn.ConnectionString = "Data source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
        If conn.State = ConnectionState.Open Then conn.Close()
    End Sub

    Public vStok As String
    Public vCustomer As String
    Public vMember As String
    Public vSupplier As String
    Public vDokter As String
    Public vBeli As String
    Public vSupplierBeli As String
    Public vJResep As String
    Public vJNonResep As String
    Public vCustomerJualR As String
    Public vCustomerJualN As String
    Public vDokterJualR As String


    Function AutoCodeBeli(X As String, Y As DateTime) As String
        Dim Z As Boolean = True
        Dim Last As Integer

        Using cnn = New SqlConnection
            cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
            Using cmdOpen As New SqlCommand
                cnn.Open()
                cmdOpen.Connection = cnn
                Select Case X
                    Case "Beli"
                        cmdOpen.CommandText = "select TOP 1 no_beli from beli where SUBSTRING(no_beli,3,2)= '" & Format(Y, "yy") &
                                           "' And SUBSTRING(no_beli,5,2) = '" & Format(Y, "MM") & "' order by no_beli DESC"

                End Select

                'Buat Data Adapter
                Using drOpen As SqlDataReader = cmdOpen.ExecuteReader
                    If drOpen.HasRows Then
                        While drOpen.Read()
                            Last = CInt(Mid(drOpen.Item("no_beli"), 7, 4))
                            Z = False
                        End While
                    End If
                    drOpen.Close()
                End Using
            End Using
        End Using
        Select Case X
            Case "Beli"
                If Z Then
                    Return "BL" & Format(Y, "yyMM") & "1001"
                Else
                    Return "BL" & Format(Y, "yyMM") & (Last + 1).ToString
                End If
        End Select
        Return ""
    End Function

    Function AutoCodeJual(K As String, L As DateTime) As String
        Dim M As Boolean = True
        Dim Last As Integer

        Using cnn = New SqlConnection
            cnn.ConnectionString = "Data Source = localhost\SQLEXPRESS; Initial Catalog = AplikasiPenjualan; Integrated Security = True"
            Using cmdOpen As New SqlCommand
                cnn.Open()
                cmdOpen.Connection = cnn
                Select Case K
                    Case "Jual"
                        cmdOpen.CommandText = "select TOP 1 no_jual from jual_nonresep where SUBSTRING(no_jual,3,2)= '" & Format(L, "yy") &
                                           "' And SUBSTRING(no_beli,5,2) = '" & Format(L, "MM") & "' order by no_jual DESC"

                End Select

                'Buat Data Adapter
                Using drOpen As SqlDataReader = cmdOpen.ExecuteReader
                    If drOpen.HasRows Then
                        While drOpen.Read()
                            Last = CInt(Mid(drOpen.Item("no_jual"), 7, 4))
                            M = False
                        End While
                    End If
                    drOpen.Close()
                End Using
            End Using
        End Using
        Select Case K
            Case "Jual"
                If M Then
                    Return "BL" & Format(L, "yyMM") & "1001"
                Else
                    Return "BL" & Format(L, "yyMM") & (Last + 1).ToString
                End If
        End Select
        Return ""
    End Function


End Module
