Public Class TransaksiAngsurans
    Dim query, idpinjam As String

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
    Private Sub TransaksiAngsurans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Call tahun()
        Call bulan()
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        If txtnamaanggota.Text = "" Then
            MsgBox("Masukkan Nama terlebih dahulu")
        Else
            query = "select b.id 'No',a.nama,b.jumlah_pinjaman,b.ansur_perbulan,b.jumlah_bulan,b.status from anggota a,peminjaman b where a.nama='" & txtnamaanggota.Text & "' and b.anggota_id=a.id and b.status='belum_lunas'"
            dgv.DataSource = read(query)
        End If
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        idpinjam = dgv.CurrentRow.Cells(0).Value
        txtjumlahpinjam.Text = dgv.CurrentRow.Cells(2).Value
        txtansurperbulan.Text = dgv.CurrentRow.Cells(3).Value
        txtjmlbulan.Text = dgv.CurrentRow.Cells(4).Value
    End Sub
    Sub penguranganuang()
        Dim bil1 As Double
        Dim bil2 As Double
        Dim bil3 As Double
        bil1 = txtangsur.Text
        bil2 = txtansurperbulan.Text
        If bil2 > bil1 Then
            MsgBox("uang kurang")
        Else
            bil3 = bil1 - bil2
            txtkembali.Text = bil3
        End If
    End Sub
    Sub angsuran()
        query = "insert into angsuran(bulan,tahun,jml_angsur,peminjaman_id) values('{0}','{1}','{2}','{3}')"
        query = String.Format(query, DateTimePicker2.Value.ToString("MMMM"), DateTimePicker3.Value.ToString("yyyy"), txtansurperbulan.Text, idpinjam)
        aksi(query)
    End Sub
    Sub updatestatus()
        query = "update peminjaman set status='lunas' where id='" & dgv.CurrentRow.Cells(0).Value & "'"
        aksi(query)
    End Sub
    Sub updatebulan()
        query = "update peminjaman set jumlah_bulan='" & txtjmlbulan.Text - 1 & "' where id='" & dgv.CurrentRow.Cells(0).Value & "'"
        aksi(query)
    End Sub
    Sub updatepinjam()
        'Dim bil As Double
        'Dim hasil As Integer
        'bil = txtansurperbulan.Text
        'hasil = bil - 1
        If txtjmlbulan.Text - 1 = 0 Then
            Call updatestatus()
        Else
            Call updatebulan()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtnamaanggota.Text = "" Or txtangsur.Text = "" Or txtansurperbulan.Text = "" Then
            MsgBox("Mohon Lengkapi Data", vbInformation, "Information")
        Else
            Call penguranganuang()
            Call angsuran()
            Call updatepinjam()
            MsgBox("Sukses")
        End If
    End Sub

    Private Sub goback_Click(sender As Object, e As EventArgs) Handles goback.Click
        AdminForm.Show()
        Me.Hide()
    End Sub

    Private Sub txtangsur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtangsur.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub
End Class