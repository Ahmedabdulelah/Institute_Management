Imports System.Data
Imports System.Data.SqlClient
Public Class Form2
    Dim Std_manag As New Student_Management
    Dim cmd As New SqlCommand
    Dim con As New SqlConnection("server = DESKTOP-9JEPVJE;database=Std_Management; integrated security= true; ")

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New SqlCommand("INSERT INTO Student(Name,Number,Level,Section) VALUES (@Name, " & "@Number,@Level,@Section)", con)
        With cmd.Parameters
            .AddWithValue("@Name", TextBox1.Text).DbType = DbType.String
            .AddWithValue("@Number", TextBox2.Text).DbType = DbType.Int32
            .AddWithValue("@Level", TextBox3.Text).DbType = DbType.String
            .AddWithValue("@Section", TextBox4.Text).DbType = DbType.String
        End With
        If con.State = ConnectionState.Open Then
            con.Close()
        End If

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Added successufly", , "The Result of the Addition process")
        Me.Hide()
        Std_manag.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Std_manag.Show()
    End Sub
End Class