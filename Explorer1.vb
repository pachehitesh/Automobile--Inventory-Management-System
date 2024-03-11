Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Explorer1

    Private Sub TreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect

    End Sub

    Private Sub TreeView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView.Click
        If TreeView.SelectedNode.Text = "New Model Entry" Then
            Form1.Show()
        End If
        If TreeView.SelectedNode.Text = "Stock Status" Then
            Form11.Show()

        End If

        If TreeView.SelectedNode.Text = ("Purchase") Then
            Form10.Show()
        End If

        If TreeView.SelectedNode.Text = ("Sale") Then
            Form3.Show()
        End If

        If TreeView.SelectedNode.Text = ("Purchase Edit") Then
            Form9.Show()
        End If
        If TreeView.SelectedNode.Text = ("Sale Edit") Then
            Form7.Show()
        End If
        If TreeView.SelectedNode.Text = ("Modelwise Stock Report") Then
            Form12.Show()
        End If

        If TreeView.SelectedNode.Text = ("Modelwise Sale Report") Then
            Form13.Show()
        End If
        If TreeView.SelectedNode.Text = ("Datewise Collection Report") Then
            Form15.Show()
        End If
    End Sub
End Class
