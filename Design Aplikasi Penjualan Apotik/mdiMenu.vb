Imports System.Text.RegularExpressions

Public Class mdiMenu
    Sub Terkunci()
        LoginToolStripMenuItem.Enabled = True
        LogoutToolStripMenuItem.Enabled = False
        MasterToolStripMenuItem.Enabled = False
        TransaksiToolStripMenuItem.Enabled = False
        LaporanToolStripMenuItem.Enabled = False
        UtilityToolStripMenuItem.Enabled = False
        Me.Slabel2.Text = ""
        Me.Slabel4.Text = ""
        Me.Slabel6.Text = ""

    End Sub

    Private Sub mdiMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Slabel8.Text = Today
        Call Terkunci()

    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        Login.ShowDialog()
    End Sub

    Private Sub KeluarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Call Terkunci()
        MsgBox("Logout sukses")

    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        User.ShowDialog()
    End Sub

    Private Sub StokToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StokToolStripMenuItem.Click
        Stok.MdiParent = Me
        Stok.Show()
    End Sub

    Private Sub DokterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DokterToolStripMenuItem.Click
        Dokter.MdiParent = Me
        Dokter.Show()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        Customer.MdiParent = Me
        Customer.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        Supplier.MdiParent = Me
        Supplier.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Slabel10.Text = TimeOfDay
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        Pembelian.MdiParent = Me
        Pembelian.Show()
    End Sub

    Private Sub NonResepToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NonResepToolStripMenuItem.Click
        JualNonResep.MdiParent = Me
        JualNonResep.Show()
    End Sub

    Private Sub SettingPoinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingPoinToolStripMenuItem.Click
        SettingPoin.MdiParent = Me
        SettingPoin.Show()
    End Sub

    Private Sub ResepToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ResepToolStripMenuItem1.Click
        PenjualanResep.MdiParent = Me
        PenjualanResep.Show()
    End Sub

    Private Sub StokToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StokToolStripMenuItem1.Click
        LaporanStok.MdiParent = Me
        LaporanStok.Show()
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem1.Click
        LaporanCustomer.MdiParent = Me
        LaporanCustomer.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem1.Click
        LaporanSupplier.MdiParent = Me
        LaporanSupplier.Show()
    End Sub

    Private Sub DokterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DokterToolStripMenuItem1.Click
        LaporanDokter.MdiParent = Me
        LaporanDokter.Show()
    End Sub
End Class
