Public Class Form7
    Public dinv As Integer
    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn1()
        rs.Open("select * from invoice ", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                ComboBox1.Items.Add(rs.Fields("invno").Value)
                rs.MoveNext()
            Loop
        End If
        rs.Close()





    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        On Error Resume Next
        rs.Open("select * from invoice where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            TextBox1.Text = rs.Fields("cust_name").Value
        End If
        rs.Close()

        DG1.Refresh()
        DG1.Rows.Clear()
        rs.Open("select *from invoice  where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim i As Integer
        Do While Not rs.EOF
            DG1.Rows.Add()
            DG1.Item(0, i).Value = rs.Fields("dt").Value
            DG1.Item(1, i).Value = rs.Fields("cust_code").Value
            DG1.Item(2, i).Value = rs.Fields("invno").Value
            DG1.Item(3, i).Value = rs.Fields("cust_name").Value
            DG1.Item(4, i).Value = rs.Fields("address").Value
            DG1.Item(5, i).Value = rs.Fields("phno").Value
            DG1.Item(6, i).Value = rs.Fields("model").Value
            rs.MoveNext()
            i = i + 1
        Loop
        rs.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        rs.Open("select *from invoice where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.Update("cust_name", DG1.Item(3, 0).Value)
            rs.Update("address", DG1.Item(4, 0).Value)
            rs.Update("phno", DG1.Item(5, 0).Value)
            rs.Update("model", DG1.Item(6, 0).Value)
        End If
        rs.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub DG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.Click

    End Sub
End Class