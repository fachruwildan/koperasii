Imports MySql.Data.MySqlClient
Public Class TransaksiPinjam
    Dim query, id_anggota As String
    Dim conn As MySqlConnection
    'Dim conn As SqlConnection = New SqlConnection("Data Source=desktop-chr9bf5;Initial Catalog=PC_20;Integrated Security=True")
    Dim da As MySqlDataAdapter
    Dim dr As MySqlDataReader
    Dim cmd As MySqlCommand
    Sub koneksi()
        conn = New MySqlConnection("Server=localhost;user id=root;password=;database=koperasi")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
    Sub total()
        Dim saldo As Double
        Dim total As Double
        saldo = Val(txtsaldo.Text)
        total = (saldo * 5 / 100) + saldo
        txttotal.Text = "Rp." + Str(total)
    End Sub
    Private Sub gen_Click(sender As Object, e As EventArgs) Handles gen.Click
        If txtangsur.Text = "" Or txtsaldo.Text = "" Then
            MsgBox("Masukkan Saldo dan Angsuran", vbInformation, "Infromation")

        Else

            Dim bil1 As Double
            Dim bil2 As Double
            Dim bln As Integer
            Dim check As Integer

            bil1 = txtsaldo.Text
            bil2 = txtangsur.Text

            check = bil1 Mod bil2

            bln = bil1 / bil2


            If check > 0 Then
                bln += 1
            End If
            hasil.Text = Str(bln)


            Math.Ceiling(bil1)
            Call total()
        End If
    End Sub

    Private Sub cmbnama_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbnama.SelectedIndexChanged

        Call koneksi()
        query = "select * from Anggota where nama ='" & cmbnama.Text & "'"
        cmd = New MySqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            id_anggota = dr.Item("id")
            txtalamatangt.Text = dr.Item("alamat")
            txtemailagt.Text = dr.Item("email")
            txtnohpagt.Text = dr.Item("no_hp")
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
                txtalamatangt.Text = ""
                txtemailagt.Text = ""
                txtnohpagt.Text = ""
                cmbnama.Text = ""
            End If
        End If
    End Sub
    Private Sub txtsaldo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtsaldo.KeyPress, txttotal.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub

    Private Sub TransaksiPinjam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub goback_Click(sender As Object, e As EventArgs) Handles goback.Click
        Me.Hide()
        AdminForm.Show()

    End Sub
    Sub kosongkandata()
        txttotal.Text = ""
        txtangsur.Text = ""
        txtsaldo.Text = ""
        hasil.Text = ""
        txtnamaanggota.Text = ""
        cmbnama.Text = ""
        txtalamatangt.Text = ""
        txtemailagt.Text = ""
        txtnohpagt.Text = ""
    End Sub
    Sub peminjaman()
        query = "insert into peminjaman(jumlah_pinjaman,anggota_id,ansur_perbulan,jumlah_bulan,bunga,status,tanggal_pinjam) values('{0}','{1}','{2}','{3}','5%','belum_lunas','{4}')"
        query = String.Format(query, txttotal.Text, id_anggota, txtangsur.Text, hasil.Text, dtppinjam.Value.ToString("yyyy-MM-dd"))
        aksi(query)
        MsgBox("Berhasil Buat Peminjaman")
        Call kosongkandata()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim status As Integer
        status = 0

        ' ketika status == 1 maka menampilkan pesan error , jika status == 0 maka create data

        If txtsaldo.Text = "" Or txtalamatangt.Text = "" Or txttotal.Text = "" Then
            status = 1
            MsgBox("Mohon isi data dengan lengkap", vbCritical, "Error")
        Else
            query = "select * from peminjaman a,anggota b where b.nama='" & cmbnama.Text & "' and b.id=a.anggota_id"
            If read(query).Rows().Count > 0 Then

                If read(query).Rows(0)("status") = "belum_lunas" Then
                    status = 1
                    MsgBox("Pinjaman Kemarin Belum Lunas Harap Lunasi Dulu")
                End If
            End If
        End If

        If status = 0 Then
            Call peminjaman()
        End If

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