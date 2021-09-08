Public Class CChart
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Page.IsPostBack Then
                'view chart date
                If _
                    Not String.IsNullOrEmpty(Request.QueryString("dtfrm")) And
                    Not String.IsNullOrEmpty(Request.QueryString("dtto")) Then
                    'call function chart

                End If
            End If
        End If
    End Sub
End Class