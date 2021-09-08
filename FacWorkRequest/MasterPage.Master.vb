Public Class MasterPage
    Inherits UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load



        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If
        ' LB_IP.Text = "IP:" & ipaddress
        Dim ipcookie = New HttpCookie("ipcookie")
        ipcookie("IP_ADDRESS") = ipaddress
        ipcookie.Expires = DateTime.Now.AddHours(2)
        Response.Cookies.Add(ipcookie)



    End Sub

    'Private Sub LoginStatus1_LoggedOut(sender As Object, e As EventArgs) Handles LoginStatus1.LoggedOut
    '    Response.Cookies.Clear()
    '    Response.Redirect("Login.aspx")
    'End Sub
End Class