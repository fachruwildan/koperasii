Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Module koneksi
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost;user id=root;password=;database=koperasi")
    'Dim conn As SqlConnection = New SqlConnection("Data Source=desktop-chr9bf5;Initial Catalog=PC_20;Integrated Security=True")
    Dim da As MySqlDataAdapter
    Dim dt As DataTable
    Dim cmd As MySqlCommand
    Function aksi(ByVal query As String) As Boolean
        conn.Open()
        cmd = New MySqlCommand(query, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        Return True
    End Function
    Function read(ByVal query As String) As DataTable
        conn.Open()
        da = New MySqlDataAdapter(query, conn)
        dt = New DataTable
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Function checkemail(ByVal value As String) As Boolean
        ' Menyiapkan pola
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        ' Jika sukses maka akan mengembailkan nilai True, jika tidak maka akan mengembailkan nilai false
        If System.Text.RegularExpressions.Regex.Match(value, pattern).Success Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
