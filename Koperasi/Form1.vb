Public Class Form1
    Dim query As String
    Public nama As String
    Private Sub bntlogin_Click(sender As Object, e As EventArgs) Handles bntlogin.Click
        query = "select * from tbuser where username='" & txtusername.Text & "' and password='" & txtpassword.Text & "'"
        If read(query).Rows().Count > 0 Then
            nama = read(query).Rows(0)("nama")
            If read(query).Rows(0)("role") = "admin" Then
                MsgBox("Login Berhasil sebagai Admin")
                AdminForm.Show()
                Me.Hide()
                nama = read(query).Rows(0)("nama")
            ElseIf read(query).Rows(0)("role") = "operator" Then
                MsgBox("Login Berhasil sebagai operator")
            Else
                MsgBox("Login Gagal,Cek Username Dan Password", vbCritical, "Error")
            End If
        Else
            MsgBox("Login GagalTidak Ada USername dan password", vbCritical, "Error")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        MaximizeBox = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub
End Class
