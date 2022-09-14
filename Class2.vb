Imports System.Data.SqlClient


Public Class Class2

    Dim con As SqlConnection = New SqlConnection("Data Source=DESKTOP-5K8H7SF;Initial Catalog=statfes;Integrated Security=True")
    Dim sqlString = ""
    Dim cmd As SqlCommand = New SqlCommand(sqlString, con)
End Class
