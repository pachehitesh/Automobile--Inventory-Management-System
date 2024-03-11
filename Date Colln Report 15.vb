Public Class Form15

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conn1()
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        Dim d1 As Date
        Dim d2 As Date
        Dim d3 As Date
        d1 = DateTimePicker1.Value
        d2 = DateTimePicker2.Value

        rs1.Open("delete from temp_invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs1.Open("select *from temp_invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs.Open("select *from invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                d3 = rs.Fields("dt").Value

                If d3.Year >= d1.Year And d3.Year <= d2.Year Then
                    If d3.Month >= d1.Month And d3.Month <= d2.Year Then
                        If d3.Day >= d1.Day And d3.Day <= d2.Day Then
                            rs1.AddNew()
                            rs1.Fields("DT").Value = rs.Fields("DT").Value
                            rs1.Fields("CUST_CODE").Value = rs.Fields("CUST_CODE").Value
                            rs1.Fields("INVNO").Value = rs.Fields("INVNO").Value
                            rs1.Fields("CUST_NAME").Value = rs.Fields("CUST_NAME").Value
                            rs1.Fields("ADDRESS").Value = rs.Fields("ADDRESS").Value
                            rs1.Fields("MODEL").Value = rs.Fields("MODEL").Value
                            rs1.Fields("FRAME1").Value = rs.Fields("FRAME1").Value
                            rs1.Fields("FRAME2").Value = rs.Fields("FRAME2").Value
                            rs1.Fields("ENGINE1").Value = rs.Fields("ENGINE1").Value
                            rs1.Fields("ENGINE2").Value = rs.Fields("ENGINE2").Value
                            rs1.Fields("COST").Value = rs.Fields("COST").Value
                            rs1.Fields("RTORGE").Value = rs.Fields("RTORGE").Value
                            rs1.Fields("RTOHC").Value = rs.Fields("RTOHC").Value
                            'rs1.Fields("IC").Value = rs.Fields("IC").Value
                            ' rs.Fields("hpa").Value = rs.Fields("hpa").Value
                            rs1.Update()
                        End If
                    End If
                End If



                rs.MoveNext()
            Loop
        End If
        rs.Close()
        rs1.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn1()

    End Sub
End Class