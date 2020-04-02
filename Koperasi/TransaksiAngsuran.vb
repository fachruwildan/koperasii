Public Class TransaksiAngsuran
    Dim cLeft As Integer = 1
    Dim boxes As New List(Of TextBox)


    Dim query As String
    Sub Main()
        Dim arr As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
        For Each i As Integer In arr
            lshasil.Items.Add("Nomor ke " & i)
            ' MsgBox("Nomor ke " & i)
        Next
        'MsgBox("For Each Telah Selesai")

    End Sub
    Private Sub btnsearchdata_Click(sender As Object, e As EventArgs) Handles btnsearchdata.Click
        query = "SELECT a.id from peminjaman a,anggota b where b.nama= '" & txtcari.Text & "'and a.status='belum_lunas' and a.tanggal_pinjam='" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and b.id=a.anggota_id"
        DataGridView1.DataSource = read(query)

    End Sub
    Sub tahun()
        DateTimePicker3.ShowUpDown = True
        DateTimePicker3.CustomFormat = "yyyy"
        DateTimePicker3.Format = DateTimePickerFormat.Custom
    End Sub
    Sub bulan()
        DateTimePicker2.ShowUpDown = True
        DateTimePicker2.CustomFormat = "MMMM"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
    End Sub
    Private Sub TransaksiAngsuran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tahun()
        Call bulan()
        'Me.txtcari.HintText = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Main()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim i As Integer
        lshasil.Items.Clear()
        For i = 1 To Val(txtjumlah.Text)
            lshasil.Items.Add("Perulangan Ke - " & i)
        Next

    End Sub
    Sub Add()
        Dim txt As New TextBox
        txt.Name = "txtid"
        txt.Size = New Size(40, 138)
        txt.Location = New Point(50, 50)
        GroupBox1.Controls.Add(txt)
    End Sub
    Private Sub Addbuttons(buttonCount As Integer)
        Dim newbox As TextBox
        For i As Integer = 1 To buttonCount
            newbox = New TextBox
            newbox.Size = New Drawing.Size(575, 35)
            newbox.Location = New Drawing.Point(10, 10 + 35 * (i - 1))
            newbox.Name = "TextBox" & i
            newbox.Text = newbox.Name
            'connect it to a handler, save a reference to the array and add it to the form controls
            boxes.Add(newbox)
            Me.Controls.Add(newbox)
        Next
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Addbuttons(Val(txtjumlah.Text))
    End Sub
End Class