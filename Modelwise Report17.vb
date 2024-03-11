Public Class Form17

    Private Sub Form17_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn1()
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open("delete from temp_stock", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs1.Open("select from temp_stock", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        rs.Open("select *from stock  where model=" & "'" & ComboBox1.Text & "'" & " order by model", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF

                rs1.AddNew()
                rs1.Fields("dt").Value = rs1.Fields("dt").Value
                rs1.Fields("invno").Value = TextBox2.Text
                rs1.Fields("disdt").Value = dtp2.Text
                rs1.Fields("recdt").Value = dtp3.Text
                rs1.Fields("frame1").Value = Invoice_entry.Item(0, i).Value
                rs1.Fields("frame2").Value = Invoice_entry.Item(1, i).Value
                rs1.Fields("engine1").Value = Invoice_entry.Item(2, i).Value
                rs1.Fields("engine2").Value = Invoice_entry.Item(3, i).Value
                rs1.Fields("model").Value = Invoice_entry.Item(4, i).Value
                rs1.Fields("plant").Value = ComboBox1.Text
                rs1.Fields("mcolor").Value = Invoice_entry.Item(5, i).Value
                rs1.Fields("status").Value = "False"
                rs1.Update()
                rs.MoveNext()
            Loop

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class