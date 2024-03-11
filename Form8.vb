Public Class Form8

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        rs.Open("select *from passwd where userid=" & "'" & TextBox1.Text & "'" & " and pw=" & "'" & TextBox2.Text & "'", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        If Not rs.EOF Then
            rs.Close()
            Me.Close()
            Form2.Show()
        Else
            MsgBox("Invalid UserID or Password")
            rs.Close()
        End If


    End Sub

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn1()
    End Sub
End Class