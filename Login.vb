Imports System.Data
Imports System.Data.SqlClient

Public Class Login

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblLogin.Click

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs)
   
    End Sub

    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=DESKTOP-5K8H7SF;Initial Catalog=statfes;Integrated Security=True")
        Dim dataTable As New DataTable()
        Dim command As New SqlCommand("select * from Login where UserName='" & txtUserName.Text & "' and Passwerd='" & txtPass.Text & "'", con)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable
        adapter.Fill(table)
        'The table contain the values that return from the query statmetn so if the table is empty that means the user name and the passwerd are in correct
        If (table.Rows.Count > 0) Then
            MessageBox.Show("Login Success", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        txtUserName.Text = ""
        txtPass.Text = ""
    End Sub
End Class