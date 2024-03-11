Public Class Form11

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 300
        Me.Top = 125
        conn1()
        rs.Open("select distinct model from stock", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                ListBox1.Items.Add(rs.Fields("model").Value)
                rs.MoveNext()
            Loop
        End If
        rs.Close()
        DG1.Columns.Add("f1", "Frame1")
        DG1.Columns.Add("f2", "Frame2")
        DG1.Columns.Add("e1", "Engine1")
        DG1.Columns.Add("e2", "Engine2")
        DG1.Columns.Add("mcolor", "M_Color")
       
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        DG1.Refresh()
        DG1.Rows.Clear()
        rs.Open("select *from stock where model=" & "'" & ListBox1.Text & "'" & " and status='False'", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim x As Integer
        Dim i As Integer
        x = rs.RecordCount
        TextBox1.Text = x

        Do While Not rs.EOF
            DG1.Rows.Add()
            DG1.Item(0, i).Value = rs.Fields("frame1").Value
            DG1.Item(1, i).Value = rs.Fields("frame2").Value
            DG1.Item(2, i).Value = rs.Fields("engine1").Value
            DG1.Item(3, i).Value = rs.Fields("engine2").Value
            DG1.Item(4, i).Value = rs.Fields("mcolor").Value

            rs.MoveNext()
            i = i + 1
        Loop
        rs.Close()

    End Sub

    Private Sub ListBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.Click
        rs.Open("select *from stock where model=" & "'" & ListBox1.Text & "'" & " and status='False' and mcolor=" & "'" & ListBox2.Text & "'", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Dim x As Integer

        x = rs.RecordCount
        TextBox1.Text = x
        rs.Close()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class