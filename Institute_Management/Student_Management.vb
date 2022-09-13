Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Student_Management

    Dim con As New SqlConnection("server = ;database=; integrated security= true; ")
    Dim ds As New DataSet
    Dim sql As String
    Dim da As New SqlDataAdapter("select * from Student ", con)
    Dim cmd As New SqlCommand
    Private Sub Student_Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds.Reset()
        con.Open()
        da.Fill(ds, "Student")
        TextBox1.DataBindings.Add("Text", ds, "Student.Name")
        TextBox2.DataBindings.Add("Text", ds, "Student.Number")
        TextBox3.DataBindings.Add("Text", ds, "Student.Level")
        TextBox4.DataBindings.Add("Text", ds, "Student.Section")
    End Sub
    Public Sub changeposition()
        Label5.Text = "Record" & Me.BindingContext(ds, "Student").Position & "From" & Me.BindingContext(ds, "Student").Count - 1
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.BindingContext(ds, "Student").Position = 0
        changeposition()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.BindingContext(ds, "Student").Position += 1
        changeposition()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.BindingContext(ds, "Student").Position -= 1
        changeposition()
    End Sub

    Private Sub Button8_Click(sendter As Object, e As EventArgs) Handles Button8.Click
        Me.BindingContext(ds, "Student").Position = Me.BindingContext(ds, "Student").Count - 1
        changeposition()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cmd = New SqlCommand("UPDATE Student SET Name = @Name,Number = @Number,Level =@Level ,Section =@Section WHERE Number=@Number ", con)

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
        MsgBox("Update successufly", , "The Result of the Update process")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MsgBox("Do you want to delete", MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes Then
            cmd = New SqlCommand("DELETE FROM Student WHERE Number = " & CInt(TextBox2.Text), con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form_of_Search.Show()
    End Sub
End Class