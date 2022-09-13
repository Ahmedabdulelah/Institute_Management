Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Form_of_Search

    Dim con As New SqlConnection("server =;database=; integrated security= true; ")
    Dim ds As New DataSet
    Dim sql As String


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If rdoName.Checked Then
            sql = "select * from Std_Management where Name like '%" & txtSearch.Text & "%'"
        End If
        If rdoNumber.Checked Then
            sql = "select * from Std_Management where Number like '%" & txtSearch.Text & "%'"
        End If
        Dim da As New SqlDataAdapter(sql, con)
        Dim table As New DataTable()
        da.Fill(table)
        DataGridView1.DataSource = table
    End Sub
End Class