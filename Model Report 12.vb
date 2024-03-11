Public Class Form12

    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn1()
        rs.Open("select *from model_list", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                ComboBox1.Items.Add(rs.Fields("mname").Value)
                rs.MoveNext()
            Loop
        End If
        rs.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open("delete from temp_stock", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs1.Open("select *from temp_stock", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        rs.Open("select *from stock", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                Dim x As String
                x = rs.Fields("model").Value
                If ComboBox1.Text = x Then
                    If rs.Fields("status").Value = "False" Then
                        rs1.AddNew()
                        rs1.Fields("dt").Value = rs.Fields("dt").Value
                        rs1.Fields("invno").Value = rs.Fields("invno").Value
                        rs1.Fields("disdt").Value = rs.Fields("disdt").Value
                        rs1.Fields("recdt").Value = rs.Fields("recdt").Value
                        rs1.Fields("frame1").Value = rs.Fields("frame1").Value
                        rs1.Fields("frame2").Value = rs.Fields("frame2").Value
                        rs1.Fields("engine1").Value = rs.Fields("engine1").Value
                        rs1.Fields("engine2").Value = rs.Fields("engine2").Value
                        rs1.Fields("model").Value = rs.Fields("model").Value
                        rs1.Fields("plant").Value = rs.Fields("plant").Value
                        rs1.Fields("mcolor").Value = rs.Fields("mcolor").Value
                        rs1.Fields("status").Value = rs.Fields("status").Value
                        rs1.Update()
                    End If


                End If
                rs.MoveNext()
            Loop
        End If
        rs.Close()
        rs1.Close()
        Form17.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class