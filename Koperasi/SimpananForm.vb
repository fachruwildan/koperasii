Imports MySql.Data.MySqlClient
Public Class SimpananForm
    Dim query, id_anggota, id_simpanan As String
    Dim conn As MySqlConnection
    'Dim conn As SqlConnection = New SqlConnection("Data Source=desktop-chr9bf5;Initial Catalog=PC_20;Integrated Security=True")
    Dim da As MySqlDataAdapter
    Dim dr As MySqlDataReader
    Dim cmd As MySqlCommand
    Sub koneksi()
        conn = New MySqlConnection("Server=localhost;user id=root;password=;database=koperasi")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
    Sub has_simpanan()
        query = "insert into anggota_has_simpanan(anggota_id,simpanan_id,jml_ambil,jml_simpan,created_at,updated_at) values('{0}','{1}','0','{2}','{3}','{4}')"
        query = String.Format(query, id_anggota, id_simpanan, txtuangsimpan.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd"), DateTimePicker1.Value.ToString("yyyy-MM-dd"))
        aksi(query)
    End Sub
    Sub update_simpanan()
        If txtsaldo.Text = "" Or txtuangsimpan.Text = "" Then
            MsgBox("Mohon Isi Uang Anda / saldo tidak diketahui", vbCritical, "Information")
        Else
            Dim bil As Double
            Dim bil1 As Double
            Dim bil2 As Double
            bil = txtsaldo.Text
            bil1 = txtuangsimpan.Text
            bil2 = bil1 + bil
            query = "update simpanan set saldo='" & bil2 & "',updated_at='" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "'where id='" & id_simpanan & "'"
            aksi(query)
        End If

    End Sub
    Sub create()
        query = "insert into simpanan(no_rekening,saldo,created_at,updated_at) values('{0}','0','{1}','{2}')"
        query = String.Format(query, TextBox1.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd"), DateTimePicker1.Value.ToString("yyyy-MM-dd"))
        aksi(query)
        MsgBox("Berhasil Create No rekening")
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub
    Private Sub cmbnama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbnama.SelectedIndexChanged
        Call koneksi()
        query = "select * from Anggota where nama ='" & cmbnama.Text & "'"
        cmd = New MySqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            id_anggota = dr.Item("id")
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtuangsimpan.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub
    Private Sub txtnorek_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnorek.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Mohon Isi data dengan lengkap", vbCritical, "Error")
        Else
            Call koneksi()
            cmd = New MySqlCommand("select * from simpanan where no_rekening='" & TextBox1.Text & "'", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                Call create()
            Else
                MsgBox("No rekening sudah digunakan")
            End If

        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtnorek.Text = "" Then
            MsgBox("Masukkan No rekening", vbInformation, "Information")
        Else
            Call koneksi()
            query = "select * from simpanan where no_rekening='" & txtnorek.Text & "' "
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                id_simpanan = dr.Item("id")
                txtsaldo.Text = dr.Item("saldo")
                MsgBox("Data Ada")
            Else
                MsgBox("Data Tidak tersedia")
                txtsaldo.Text = ""
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cmbnama.Text = "" Or txtnorek.Text = "" Or txtuangsimpan.Text = "" Or id_simpanan = "" Or id_anggota = "" Then
            MsgBox("Mohon Lengkapi Data", vbCritical, "Error")
        Else
            Call has_simpanan()
            Call update_simpanan()
            MsgBox("Berhasil Menyimpan data")
        End If
    End Sub
    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        If txtnamaanggota.Text = "" Then
            MsgBox("Mohon isi Nama Anggota")
            cmbnama.Text = ""
        Else
            Call koneksi()
            query = "select * from Anggota where nama like '%" & txtnamaanggota.Text & "%'"
            cmd = New MySqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                cmbnama.DataSource = read(query)
                cmbnama.ValueMember = "nama"
                cmbnama.DisplayMember = "nama"
                MsgBox("Data Ada")
            Else
                MsgBox("Data Tidak tersedia")
                cmbnama.Text = ""
            End If
        End If
    End Sub
End Class