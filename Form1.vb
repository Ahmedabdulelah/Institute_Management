Imports نظام_إدارة_معاهد.Class1
Imports System.Data.SqlClient

Public Class frmWorkers
    Dim sql = ""
    Dim con As SqlConnection = New SqlConnection("Data Source=DESKTOP-5K8H7SF;Initial Catalog=statfes;Integrated Security=True")
    Dim dataSet As New DataSet()
    Dim command As New SqlCommand()
    Dim adapter As New SqlDataAdapter

    Public Sub clear()
        txtName.Text = ""
        txtID.Text = ""
        txtAddress.Text = ""
        txtJopTitle.Text = ""
        txtPhone.Text = ""
        txtSearch.Text = ""
        txtShowRec.Text = ""
        txtName.Focus()
    End Sub


    Public Sub changePosition()
        txtShowRec.Text = "Record " & Me.BindingContext(dataSet, "myDb1").Position & " From " & Me.BindingContext(dataSet, "myDb1").Count - 1
    End Sub

    Public Sub getAll()
        sql = "select * from myDb1 "
        adapter = New SqlDataAdapter(sql, con)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView2.DataSource = table
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub


    Private Sub frmWorkers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StatfesDataSet4.myDb1' table. You can move, or remove it, as needed.
        Me.MyDb1TableAdapter1.Fill(Me.StatfesDataSet4.myDb1)
        'TODO: This line of code loads data into the 'StatfesDataSet3.myDb1' table. You can move, or remove it, as needed.
        Me.MyDb1TableAdapter.Fill(Me.StatfesDataSet3.myDb1)

        dataSet.Reset()
        sql = "select * from myDb1 "
        con.Open()
        Dim adapter = New SqlDataAdapter(sql, con)
        adapter.Fill(dataSet, "myDb1")
        con.Close()
    End Sub

    
   

    

   

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)


    End Sub

    Private Sub RoundCornerButton4_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtID.Text = "" Then
            MsgBox("Please enter the id ", MsgBoxStyle.Information)

        Else
            sql = "Delete from mydb1 where ID=" & txtID.Text
            Dim command = New SqlCommand(sql, con)
            command.Connection.Open()
            command.ExecuteNonQuery()
            MsgBox("Delete  Complet succesfuly")
            clear()
            getAll()

        End If


    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        sql = "insert into myDb1 values('" & txtName.Text & "'," & Val(txtID.Text) & ",'" & txtAddress.Text & "','" & txtJopTitle.Text & "'," & Val(txtPhone.Text) & ")"
        command = New SqlCommand(sql, con)
        command.Connection.Open()
        command.ExecuteNonQuery()
        command.Connection.Close()
        MsgBox("Insert Complet")
        clear()
        getAll()
    End Sub

    Private Sub btnUpdate_Click_1(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If (txtID.Text = "") Then
            MsgBox("Plase enter the ID", MsgBoxStyle.Critical)
        Else
            sql = "update  myDb1 set name='" & txtName.Text & "',Address='" & txtAddress.Text & "',jopTitle='" & txtJopTitle.Text & "',phone=" & txtPhone.Text & "where ID=" & txtID.Text
            Dim command = New SqlCommand(sql, con)
            command.Connection.Open()
            command.ExecuteNonQuery()
            command.Connection.Close()
            MsgBox("Update Complet")
            clear()
            getAll()
        End If
     
    End Sub

    Private Sub btnFind_Click_1(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim id = Val(InputBox("Enter the id:"))
        sql = "select * from myDb1 where ID=" & id
        adapter = New SqlDataAdapter(sql, con)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView2.DataSource = table
    End Sub

    Private Sub btnClear_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub btnAll_Click_1(sender As Object, e As EventArgs) Handles btnAll.Click
        getAll()
    End Sub

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim strSearch = ""
        If rdoName.Checked Then
            strSearch = "select * from myDb1 where name like'%" & txtSearch.Text & "%'"

        ElseIf rdoID.Checked Then
            strSearch = "select * from myDb1 where ID=" & txtSearch.Text

        ElseIf rdoAddress.Checked Then
            strSearch = "select * from myDb1 where Address like'%" & txtSearch.Text & "%'"

        ElseIf rdoJopTile.Checked Then
            strSearch = "select * from myDb1 where jopTitle like'%" & txtSearch.Text & "%'"

        Else
            strSearch = "select * from myDb1 where phone=" & txtSearch.Text & "'"
        End If
        adapter = New SqlDataAdapter(strSearch, con)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView2.DataSource = table
    End Sub

    Private Sub btnFirstRec_Click(sender As Object, e As EventArgs) Handles btnFirstRec.Click
        Me.BindingContext(dataSet, "myDb1").Position = 0
        changePosition()

    End Sub

    Private Sub btnNextRec_Click(sender As Object, e As EventArgs) Handles btnNextRec.Click
        Me.BindingContext(dataSet, "myDb1").Position += 1
        changePosition()
    End Sub

    Private Sub btnPreviousRec_Click(sender As Object, e As EventArgs) Handles btnPreviousRec.Click
        Me.BindingContext(dataSet, "myDb1").Position -= 1
        changePosition()
    End Sub

    Private Sub btnLastRec_Click(sender As Object, e As EventArgs) Handles btnLastRec.Click
        Me.BindingContext(dataSet, "myDb1").Position = Me.BindingContext(dataSet, "myDb1").Count - 1
        changePosition()
    End Sub
End Class
