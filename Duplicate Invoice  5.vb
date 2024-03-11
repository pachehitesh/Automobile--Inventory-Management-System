Public Class Form5

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn1()
        Me.Left = 300
        Me.Top = 100
        rs.Open("Select *from invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                ComboBox1.Items.Add(rs.Fields("invno").Value)
                rs.MoveNext()
            Loop
        End If
        rs.Close()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

   

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        conn1()
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open("delete from temp_invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs1.Open("select *from temp_invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        rs.Open("select *from invoice where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                rs1.AddNew()
                rs1.Fields("DT").Value = rs1.Fields("DT").Value
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
                rs1.Fields("IC").Value = rs.Fields("IC").Value
                'rs1.Fields("hpa").Value = rs.Fields("hpa").Value
                rs1.Update()
                rs.MoveNext()
            Loop
        End If
        rs.Close()
        rs1.Close()
        Form16.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        rs.Open("select *from invoice where invno=" & ComboBox1.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            TextBox3.Text = rs.Fields("cust_name").Value
            TextBox4.Text = rs.Fields("address").Value
        End If
        rs.Close()
    End Sub
End Class