Module Module1
    Public db As ADODB.Connection
    Public rs As ADODB.Recordset
    Public Sub conn1()
        db = New ADODB.Connection
        rs = New ADODB.Recordset
        db.ConnectionString = ("provider=msdaora;user id=system;password=tiger")
        db.Open()
        db.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    End Sub
End Module
