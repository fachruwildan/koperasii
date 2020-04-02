Public Class AdminForm
    Dim nama As String
    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = False
        Me.WindowState = FormWindowState.Maximized
        Label3.Text = "Selamat Datang " + Form1.nama
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MasterAnggota.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Masteruser.Show()
        Me.Hide()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Form1.Show()
        Me.Hide()
        Form1.txtpassword.Text = ""
        Form1.txtusername.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TransaksiPinjam.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TransaksiAngsurans.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SimpananForm.Show()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MengambilForm.Show()

    End Sub
End Class