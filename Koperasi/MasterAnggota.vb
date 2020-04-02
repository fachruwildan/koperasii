Public Class MasterAnggota
    Dim query As String
    Sub kondisiawal()
        query = "select * from Anggota"
        dgv.DataSource = read(query)
        Call awal_button()
        Call kosongkandata()
    End Sub
    Sub kosongkandata()
        txttelp.Text = ""
        txtnama.Text = ""
        txtemail.Text = ""
        txtalamat.Text = ""
    End Sub
    Sub button()

        btncancel.Enabled = True
        txtnama.Enabled = True
        txttelp.Enabled = True
        txtemail.Enabled = True
        txtalamat.Enabled = True

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
        txttelp.Enabled = False
        txtemail.Enabled = False
        txtalamat.Enabled = False
    End Sub
    Private Sub MasterAnggota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub txttelp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttelp.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub

    Private Sub btncreate_Click(sender As Object, e As EventArgs) Handles btncreate.Click
        If btncreate.Text = "Create" Then
            Call button()

            btndelete.Enabled = False
            btnupdate.Enabled = False
            btncreate.Text = "Save"
        ElseIf btncreate.Text = "Save" Then
            If txtnama.Text = "" Or txtalamat.Text = "" Or txtemail.Text = "" Or txttelp.Text = "" Then
                MsgBox("Mohon Isi Data Dengan Lengkap", vbCritical, "Error")
            Else
                If txttelp.TextLength > 14 Or txttelp.TextLength <= 11 Then
                    MsgBox("Nomor Telepon harus 14 digit", vbInformation, "Infromation")
                Else
                    query = "insert into Anggota(nama,alamat,no_hp,email) values('{0}','{1}','{2}','{3}')"
                    query = String.Format(query, txtnama.Text, txtalamat.Text, txttelp.Text, txtemail.Text)
                    MsgBox("Berhasil Create")
                    aksi(query)
                    Call kondisiawal()
                    btncreate.Text = "Create"
                End If
            End If
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call awal_button()
        Call kondisiawal()
    End Sub
    Private Sub txtemail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtemail.KeyPress
        ' Jika tombol enter ditekan

        If e.KeyChar = Chr(13) Then

            'jika fungsi checkemail bernilai true

            If checkemail(txtemail.Text) = True Then

                ' memunculkan pesan email valid

                MsgBox("Email Valid", MsgBoxStyle.Information, "Informasi")

            Else

                ' memunculkan pesan email tidak valid

                MsgBox("Email tidak valid", MsgBoxStyle.Exclamation, "Peringatan")

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
            If txtnama.Text = "" Or txtalamat.Text = "" Or txtemail.Text = "" Or txttelp.Text = "" Then
                MsgBox("Mohon Isi Data Dengan Lengkap", vbCritical, "Error")
            Else
                If txttelp.TextLength > 14 Or txttelp.TextLength <= 11 Then
                    MsgBox("Nomor Telepon harus 14 digit", vbInformation, "Infromation")
                Else
                    query = "update Anggota set nama='" & txtnama.Text & "',alamat='" & txtalamat.Text & "',no_hp='" & txttelp.Text & "',email='" & txtemail.Text & "' where Id='" & dgv.CurrentRow.Cells(0).Value & "'"
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
            If txtnama.Text = "" Or txtalamat.Text = "" Or txtemail.Text = "" Or txttelp.Text = "" Then
                MsgBox("Mohon Isi Data Dengan Lengkap", vbCritical, "Error")
            Else
                query = "delete from Anggota where Id='" & dgv.CurrentRow.Cells(0).Value & "'"
                'query = "insert into Employee(Username,Password,Name,Email,Address,DateOfBirth,JobId,Photo) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                'query = String.Format(query, txtusername.Text, txtconfirmpassword.Text, txtname.Text, txtemail.Text, txtalamat.Text, dtpdate.Value.ToString("yyyy-MM-dd"), idjob, txtnamephoto.Text)
                MsgBox("Berhasil Delete")
                aksi(query)
                Call kondisiawal()
                btndelete.Text = "Delete"
            End If
        End If
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        txtnama.Text = dgv.CurrentRow.Cells(1).Value
        txtalamat.Text = dgv.CurrentRow.Cells(2).Value
        txttelp.Text = dgv.CurrentRow.Cells(3).Value
        txtemail.Text = dgv.CurrentRow.Cells(4).Value
    End Sub

    Private Sub goback_Click(sender As Object, e As EventArgs) Handles goback.Click
        AdminForm.Show()
        Me.Hide()
    End Sub

End Class