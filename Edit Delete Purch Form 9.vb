Public Class Form9
    Public inv_no As Integer
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        On Error Resume Next
        rs.Open("select * from stock where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        'If Not rs.EOF Then
        'rs.MoveFirst()
        'TextBox1.Text = rs.Fields("cust_name").Value
        'End If
        'rs.Close()

        DG1.Refresh()
        DG1.Rows.Clear()
        rs.Open("select *from stock  where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim i As Integer
        Do While Not rs.EOF
            DG1.Rows.Add()
            DG1.Item(0, i).Value = rs.Fields("dt").Value
            DG1.Item(1, i).Value = rs.Fields("invno").Value
            DG1.Item(2, i).Value = rs.Fields("frame1").Value
            DG1.Item(3, i).Value = rs.Fields("frame2").Value
            DG1.Item(4, i).Value = rs.Fields("engine1").Value
            DG1.Item(5, i).Value = rs.Fields("engine2").Value
            DG1.Item(6, i).Value = rs.Fields("disdt").Value
            DG1.Item(7, i).Value = rs.Fields("recdt").Value
            DG1.Item(8, i).Value = rs.Fields("status").Value
            DG1.Item(9, i).Value = rs.Fields("model").Value
            DG1.Item(10, i).Value = rs.Fields("plant").Value
            DG1.Item(11, i).Value = rs.Fields("mcolor").Value
            rs.MoveNext()
            i = i + 1
        Loop
        rs.Close()
    End Sub

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn1()

        rs.Open("select distinct invno from stock", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                ComboBox1.Items.Add(rs.Fields("invno").Value)
                rs.MoveNext()
            Loop
            rs.Close()
        End If
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ans As Integer
        ans = MsgBox("Do Want to Delete Selected Item ?", MsgBoxStyle.YesNo)
        If ans = 6 Then

            rs.Open("delete from stock where frame2=" & inv_no, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        End If
        DG1.Refresh()
        DG1.Rows.Clear()
        rs.Open("select *from stock  where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim i As Integer
        Do While Not rs.EOF
            DG1.Rows.Add()
            DG1.Item(0, i).Value = rs.Fields("dt").Value
            DG1.Item(1, i).Value = rs.Fields("invno").Value
            DG1.Item(2, i).Value = rs.Fields("frame1").Value
            DG1.Item(3, i).Value = rs.Fields("frame2").Value
            DG1.Item(4, i).Value = rs.Fields("engine1").Value
            DG1.Item(5, i).Value = rs.Fields("engine2").Value
            DG1.Item(6, i).Value = rs.Fields("disdt").Value
            DG1.Item(7, i).Value = rs.Fields("recdt").Value
            DG1.Item(8, i).Value = rs.Fields("status").Value
            DG1.Item(9, i).Value = rs.Fields("model").Value
            DG1.Item(10, i).Value = rs.Fields("plant").Value
            'DG1.Item(11, i).Value = rs.Fields("mcolor").Value
            rs.MoveNext()
            i = i + 1
        Loop
        rs.Close()
    End Sub

    Private Sub DG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.Click
        inv_no = DG1.Item(3, DG1.CurrentRow.Index).Value
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        rs.Open("select *from stock where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.Update("frame1", DG1.Item(3, 0).Value)
            rs.Update("frame2", DG1.Item(4, 0).Value)
            rs.Update("engine1", DG1.Item(5, 0).Value)
            rs.Update("engine2", DG1.Item(6, 0).Value)
            rs.Update("disdt", DG1.Item(7, 0).Value)
            rs.Update("recdt", DG1.Item(8, 0).Value)
            rs.Update("status", DG1.Item(9, 0).Value)
            rs.Update("model", DG1.Item(10, 0).Value)
            rs.Update("plant", DG1.Item(11, 0).Value)
            rs.Update("mcolor", DG1.Item(12, 0).Value)
        End If
        rs.Close()
    End Sub

End Class