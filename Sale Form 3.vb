Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 270
        Me.Top = 50
        conn1()
        rs.Open("select  distinct MNAME from MODEL_LIST", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        If Not rs.EOF Then
            rs.MoveFirst()
            Do While Not rs.EOF
                ComboBox2.Items.Add(rs.Fields("MNAME").Value)
                rs.MoveNext()
            Loop
        End If
        rs.Close()

        DG1.Columns.Add("f1", "Frame1")
        DG1.Columns.Add("f2", "Frame2")
        DG1.Columns.Add("e1", "engine1")
        DG1.Columns.Add("e2", "engine2")
        DG1.Columns.Add("model", "Model")
        DG1.Columns.Add("cost", "cost")

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        
    End Sub

    Private Sub DG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.Click

        TextBox2.Text = DG1.Item(0, DG1.CurrentRow.Index).Value()
        TextBox14.Text = DG1.Item(1, DG1.CurrentRow.Index).Value()
        TextBox3.Text = DG1.Item(2, DG1.CurrentRow.Index).Value()
        TextBox15.Text = DG1.Item(3, DG1.CurrentRow.Index).Value()
        TextBox1.Text = DG1.Item(4, DG1.CurrentRow.Index).Value()
        rs.Open("select *from model_list where mname=" & "'" & TextBox1.Text & "'", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            TextBox4.Text = rs.Fields("rate").Value
        End If
        rs.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim rs1 As ADODB.Recordset
        rs1 = New ADODB.Recordset
        rs1.Open("delete from temp_invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim ANS As Byte
        ANS = MsgBox("Do U want to Save ?", MsgBoxStyle.YesNo)
        If ANS = 6 Then
            rs.Open("select *from invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            rs.AddNew()
            rs.Fields("DT").Value = CDate(DTP1.Text)
            rs.Fields("CUST_CODE").Value = TextBox5.Text
            rs.Fields("INVNO").Value = TextBox7.Text
            rs.Fields("CUST_NAME").Value = TextBox8.Text
            rs.Fields("ADDRESS").Value = TextBox9.Text
            rs.Fields("MODEL").Value = TextBox1.Text
            rs.Fields("FRAME1").Value = TextBox2.Text
            rs.Fields("FRAME2").Value = TextBox14.Text
            rs.Fields("ENGINE1").Value = TextBox3.Text
            rs.Fields("ENGINE2").Value = TextBox15.Text
            rs.Fields("COST").Value = 30000
            rs.Fields("RTORGE").Value = TextBox11.Text
            rs.Fields("RTOHC").Value = TextBox13.Text
            rs.Fields("IC").Value = TextBox12.Text
            rs.Fields("hpa").Value = Val(TextBox6.Text)
            rs.Update()
            rs.Close()

            rs.Open("select *from stock where engine2=" & TextBox15.Text, db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            If Not rs.EOF Then
                rs.Update("status", True)
            End If
            rs.Close()

            rs1.Open("select *from temp_invoice", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            rs1.AddNew()
            rs1.Fields("DT").Value = DTP1.Text
            rs1.Fields("CUST_CODE").Value = TextBox5.Text
            rs1.Fields("INVNO").Value = TextBox7.Text
            rs1.Fields("CUST_NAME").Value = TextBox8.Text
            rs1.Fields("ADDRESS").Value = TextBox9.Text
            rs1.Fields("MODEL").Value = TextBox1.Text
            rs1.Fields("FRAME1").Value = TextBox2.Text
            rs1.Fields("FRAME2").Value = TextBox14.Text
            rs1.Fields("ENGINE1").Value = TextBox3.Text
            rs1.Fields("ENGINE2").Value = TextBox15.Text
            rs1.Fields("COST").Value = TextBox4.Text
            rs1.Fields("RTORGE").Value = TextBox11.Text
            rs1.Fields("RTOHC").Value = TextBox13.Text
            rs1.Fields("IC").Value = TextBox12.Text
            'rs.Fields("hpa").Value = Val(TextBox6.Text)
            rs1.Update()
            rs1.Close()

        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form16.Show()
    End Sub

    
    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub ComboBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Click
       
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        DG1.Refresh()
        DG1.Rows.Clear()
        rs.Open("select *from stock where model=" & "'" & ComboBox2.Text & "'" & " and status=" & "'" & "False" & "'", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            Dim x As Integer
            Dim i As Integer
            x = rs.RecordCount
            TextBox1.Text = rs.Fields("MODEL").Value
            Do While Not rs.EOF
                DG1.Rows.Add()
                DG1.Item(0, i).Value = rs.Fields("frame1").Value
                DG1.Item(1, i).Value = rs.Fields("frame2").Value
                DG1.Item(2, i).Value = rs.Fields("engine1").Value
                DG1.Item(3, i).Value = rs.Fields("engine2").Value
                DG1.Item(4, i).Value = rs.Fields("model").Value
                ' DG1.Item(5, i).Value = rs.Fields("rate").Value

                rs.MoveNext()
                i = i + 1

            Loop
        End If

        rs.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        rs.Open("select *from invoice order by invno", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.MoveLast()
            TextBox5.Text = rs.Fields("cust_code").Value + 1
            TextBox7.Text = rs.Fields("invno").Value + 1
        Else
            TextBox5.Text = 1
            TextBox7.Text = 1
        End If
        rs.Close()

    End Sub
End Class