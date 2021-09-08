Option Explicit On
Option Strict On
Public Class ReportExport
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Page.IsPostBack Then
                'Export work request wrno export
                If Not String.IsNullOrEmpty(Request.QueryString("findwrno")) Then
                    'call function export
                    '
                End If

                'Export report iso
                If Not String.IsNullOrEmpty(Request.QueryString("dtmonth")) Then
                    'call function export
                    '
                End If

                'Export report iso fac
                If Not String.IsNullOrEmpty(Request.QueryString("dtmonthfac")) Then
                    'call function export
                    '
                End If


            End If
        End If
    End Sub
End Class