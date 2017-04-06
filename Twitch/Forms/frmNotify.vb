Public Class frmNotify

    Private Sub frmNotify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Sets the start position to manual and then sets the screen postion to the bottom right of the screen
        Me.StartPosition = FormStartPosition.Manual
        Dim working_area As Rectangle =
    SystemInformation.WorkingArea
        Dim x As Integer =
            working_area.Left +
            working_area.Width -
            Me.Width
        Dim y As Integer =
            working_area.Top +
            working_area.Height -
            Me.Height
        Me.Location = New Point(x, y)
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Creates a new thread to close the form because you cant close the form on the load sub of the form you are trying to close
        Dim ThreadClose As New Threading.Thread(AddressOf CloseForm)
        ThreadClose.IsBackground = True
        ThreadClose.Start()
    End Sub
    Private Sub CloseForm()
        'Waits 5 seconds and then close the form
        Threading.Thread.Sleep(6000)
        Me.Close()
    End Sub
End Class