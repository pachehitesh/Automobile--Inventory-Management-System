Public Class Form10

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        'If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        'If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Static i As Integer
        Invoice_entry.Rows.Add()
        Invoice_entry.Item(0, i).Value = TextBox5.Text
        Invoice_entry.Item(1, i).Value = TextBox6.Text
        Invoice_entry.Item(2, i).Value = TextBox7.Text
        Invoice_entry.Item(3, i).Value = TextBox8.Text
        Invoice_entry.Item(5, i).Value = ComboBox2.Text

        If Mid(TextBox5.Text, 4, 2) = "27" Then

            Invoice_entry.Item(4, i).Value = "CD DAWN"
        End If

        If Mid(TextBox5.Text, 4, 2) = "13" Then
            Invoice_entry.Item(4, i).Value = "CD 100"
        End If

        If Mid(TextBox5.Text, 4, 2) = "14" Then
            Invoice_entry.Item(4, i).Value = "CD 100 SS"
        End If

        If Mid(TextBox5.Text, 4, 2) = "20" Then
            Invoice_entry.Item(4, i).Value = "SPLENDOR"
        End If

        If Mid(TextBox5.Text, 4, 2) = "16" Then
            Invoice_entry.Item(4, i).Value = "SPLENDOR PLUS"
        End If

        If Mid(TextBox5.Text, 4, 2) = "23" Then
            Invoice_entry.Item(4, i).Value = "SPLENDOR DISC"
        End If

        If Mid(TextBox5.Text, 4, 2) = "15" Then
            Invoice_entry.Item(4, i).Value = "SPLENDOR PLUS DISC"
        End If

        If Mid(TextBox5.Text, 4, 2) = "09" Then
            Invoice_entry.Item(4, i).Value = "PASSION PULS"
        End If

        If Mid(TextBox5.Text, 4, 2) = "08" Then
            Invoice_entry.Item(4, i).Value = "PASSION PLUS DISC"
        End If

        If Mid(TextBox5.Text, 4, 2) = "62" Then
            Invoice_entry.Item(4, i).Value = "AMBITION DRUM"
        End If

        If Mid(TextBox5.Text, 4, 2) = "60" Then
            Invoice_entry.Item(4, i).Value = "AMBITION DISC"
        End If

        If Mid(TextBox5.Text, 4, 2) = "65" Then
            Invoice_entry.Item(4, i).Value = "AMBITION SELF START"
        End If

        If Mid(TextBox5.Text, 4, 2) = "46" Then
            Invoice_entry.Item(4, i).Value = "CBZ DISC"
        End If
        If Mid(TextBox5.Text, 4, 2) = "47" Then
            Invoice_entry.Item(4, i).Value = "CBZ SELF START"
        End If

        If Mid(TextBox5.Text, 4, 2) = "70" Then
            Invoice_entry.Item(4, i).Value = "KARIZMA"
        End If

        i = i + 1
    End Sub

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Invoice_entry.RowHeadersVisible = True

        Invoice_entry.Columns.Add("Date", "Frame No. 1")
        Invoice_entry.Columns.Add("Invoice No.", "Frame No. 2")
        Invoice_entry.Columns.Add("Date of Dispatch", "Engine No 1")
        Invoice_entry.Columns.Add("Date of Receipt", "Engine No. 2")
        Invoice_entry.Columns.Add("Date of Receipt", "Model Name")
        Invoice_entry.Columns.Add("MCOLOR", "Model_Color")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        conn1()
        rs.Open("select *from  stock", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)

        Dim i As Integer

        For i = 0 To Invoice_entry.Rows.Count - 2

            If (Len(TextBox5.Text) = 6 And Len(TextBox6.Text) = 5 And Len(TextBox7.Text) = 6 And Len(TextBox8.Text) = 5) Then
                rs.AddNew()
                rs.Fields("dt").Value = CDate(dtp1.Text)
                rs.Fields("invno").Value = TextBox2.Text
                rs.Fields("disdt").Value = dtp2.Text
                rs.Fields("recdt").Value = dtp3.Text
                rs.Fields("frame1").Value = Invoice_entry.Item(0, i).Value
                rs.Fields("frame2").Value = Invoice_entry.Item(1, i).Value
                rs.Fields("engine1").Value = Invoice_entry.Item(2, i).Value
                rs.Fields("engine2").Value = Invoice_entry.Item(3, i).Value
                rs.Fields("model").Value = Invoice_entry.Item(4, i).Value
                rs.Fields("plant").Value = ComboBox1.Text
                rs.Fields("mcolor").Value = Invoice_entry.Item(5, i).Value
                rs.Fields("status").Value = "False"
                rs.Update()
            End If
        Next i

        rs.Close()
        TextBox2.Text = " "
        TextBox5.Text = " "
        TextBox6.Text = " "
        TextBox7.Text = " "
        TextBox8.Text = " "
        ComboBox1.Text = " "
        Invoice_entry.Rows.Clear()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        TextBox7.Text = Mid(TextBox5.Text, 1, 5) & "E"
    End Sub

End Class