Public Class Form1

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ans As Byte
        ans = MsgBox("Do U want to Save", MsgBoxStyle.YesNo)
        If ans = 6 Then
            rs.Open("select *from model_list", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            rs.AddNew()
            rs.Fields("mname").Value = TextBox1.Text
            rs.Fields("chassisno").Value = TextBox2.Text
            rs.Fields("engno").Value = TextBox3.Text
            rs.Fields("rate").Value = TextBox4.Text
            rs.Update()
            rs.Close()
        End If

        Button2.Enabled = False
        Button1.Enabled = True

    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn1()
        Me.Left = 300
        Me.Top = 125
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button2.Enabled = True
        Button1.Enabled = False
        GroupBox1.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox1.Focus()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        ' If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
        ' e.Handled = True
        ' End If

    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If Len(TextBox2.Text) = 10 And Len(TextBox3.Text) = 10 And Len(TextBox4.Text) > 0 Then
            Button2.Enabled = True
        End If
        TextBox3.Text = Mid(TextBox2.Text, 1, 5) & "E"
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'If Not (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) And Asc(e.KeyChar) <> 8 Then
        '  e.Handled = True
        '  End If
    End Sub

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        Button2.Enabled = True
        If Len(TextBox2.Text) = 10 And Len(TextBox3.Text) = 10 And Len(TextBox4.Text) > 0 Then
        End If
    End Sub

    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        If Len(TextBox2.Text) = 10 And Len(TextBox3.Text) = 10 And Len(TextBox4.Text) > 0 Then
            Button2.Enabled = True
        End If
    End Sub

End Class
