Public Class Form19

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Shell("C:\oraclexe\app\oracle\product\10.2.0\server\BIN\Backup.bat")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Shell("C:\oraclexe\app\oracle\product\10.2.0\server\BIN\restore.bat")

    End Sub
End Class