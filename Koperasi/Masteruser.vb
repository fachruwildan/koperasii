Public Class Masteruser
    Dim query As String
    Sub kosongkandata()
        txtusername.Text = ""
        txtpassword.Text = ""
        txtconfrimpassword.Text = ""
        txtnama.Text = ""
        cmbrole.Text = ""
    End Sub
    Sub kondisiawal()
        Call kosongkandata()
        Call awal_button()
        query = "select id 'No',username 'Username',nama,role from tbuser"
        dgv.DataSource = read(query)
        cmbrole.Items.Clear()
        cmbrole.Items.Add("admin")
        cmbrole.Items.Add("operator")
    End Sub
    Sub button()

        btncancel.Enabled = True
        txtnama.Enabled = True
        txtusername.Enabled = True
        txtpassword.Enabled = True
        txtconfrimpassword.Enabled = True
        cmbrole.Enabled = True

    End Sub
    Sub awal_button()

        btncancel.Enabled = False
        btnupdate.Enabled = True
        btndelete.Enabled = True
        btncreate.Enabled = True
        btncreate.Text = "Create"
        btnupdate.Text = "Update"
        btndelete.Text = "Delete"

        txtnama.Enabled = False
        txtusername.Enabled = False
        txtpassword.Enabled = False
        txtconfrimpassword.Enabled = False
        cmbrole.Enabled = False
    End Sub
    Private Sub Masteruser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
        Me.WindowState = FormWindowState.Maximized
        'MaximizeBox = False
    End Sub

    Private Sub btncreate_Click(sender As Object, e As EventArgs) Handles btncreate.Click
        If btncreate.Text = "Create" Then
            Call button()

            btndelete.Enabled = False
            btnupdate.Enabled = False
            btncreate.Text = "Save"
        ElseIf btncreate.Text = "Save" Then
            If txtnama.Text = "" Or txtpassword.Text = "" Or txtusername.Text = "" Or cmbrole.Text = "" Then
                MsgBox("Mohon Isi Data Dengan Lengkap", vbCritical, "Error")
            Else
                If txtpassword.Text <> txtconfrimpassword.Text Then
                    MsgBox("Password Beda harus Sama", vbInformation, "Infromation")
                Else
                    query = "insert into tbuser(username,password,nama,role) values('{0}','{1}','{2}','{3}')"
                    query = String.Format(query, txtusername.Text, txtconfrimpassword.Text, txtnama.Text, cmbrole.Text)
                    MsgBox("Berhasil Create")
                    aksi(query)
                    Call kondisiawal()
                    btncreate.Text = "Create"
                End If
            End If
        End If
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If btnupdate.Text = "Update" Then
            Call button()
            btndelete.Enabled = False
            btncreate.Enabled = False
            btnupdate.Text = "Save"
        ElseIf btnupdate.Text = "Save" Then
            If txtnama.Text = "" Or txtpassword.Text = "" Or txtusername.Text = "" Or cmbrole.Text = "" Then
                MsgBox("Mohon Isi Data Dengan Lengkap", vbCritical, "Error")
            Else
                If txtpassword.Text <> txtconfrimpassword.Text Then
                    MsgBox("Password Beda harus Sama", vbInformation, "Infromation")
                Else
                    query = "update tbuser set username='" & txtusername.Text & "',password='" & txtconfrimpassword.Text & "',nama='" & txtnama.Text & "',role='" & cmbrole.Text & "' where Id='" & dgv.CurrentRow.Cells(0).Value & "'"
                    'query = "insert into Employee(Username,Password,Name,Email,Address,DateOfBirth,JobId,Photo) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                    'query = String.Format(query, txtusername.Text, txtconfirmpassword.Text, txtname.Text, txtemail.Text, txtalamat.Text, dtpdate.Value.ToString("yyyy-MM-dd"), idjob, txtnamephoto.Text)
                    MsgBox("Berhasil Update")
                    aksi(query)
                    Call kondisiawal()
                    btnupdate.Text = "Update"
                End If
            End If
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If btndelete.Text = "Delete" Then
            Call button()
            btncreate.Enabled = False
            btnupdate.Enabled = False
            btndelete.Text = "Save"
        ElseIf btndelete.Text = "Save" Then
            If txtnama.Text = "" Or txtusername.Text = "" Or cmbrole.Text = "" Then
                MsgBox("Mohon Isi Data Dengan Lengkap", vbCritical, "Error")
            Else
                query = "delete from tbuser where id='" & dgv.CurrentRow.Cells(0).Value & "'"
                'txtusername.Text = query
                'query = "insert into Employee(Username,Password,Name,Email,Address,DateOfBirth,JobId,Photo) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                'query = String.Format(query, txtusername.Text, txtconfirmpassword.Text, txtname.Text, txtemail.Text, txtalamat.Text, dtpdate.Value.ToString("yyyy-MM-dd"), idjob, txtnamephoto.Text)
                MsgBox("Berhasil Delete")
                aksi(query)
                Call kondisiawal()
                btndelete.Text = "Delete"
            End If
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call awal_button()
        Call kondisiawal()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        txtusername.Text = dgv.CurrentRow.Cells(1).Value
        txtnama.Text = dgv.CurrentRow.Cells(2).Value
        cmbrole.Text = dgv.CurrentRow.Cells(3).Value
        'txtemail.Text = dgv.CurrentRow.Cells(4).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles goback.Click
        AdminForm.Show()
        Me.Hide()
    End Sub

End Class