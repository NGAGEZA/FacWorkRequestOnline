Option Strict On
Option Explicit On


Imports System.IO

Public Class Menu
    Inherits Page

#Region "Page_Load"
    '===== Page_Load
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'If Not Me.Page.User.Identity.IsAuthenticated Then
        '    FormsAuthentication.RedirectToLoginPage()
        'End If
        If Not Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not IsPostBack Then
                Init_Proc()


            End If
        End If


    End Sub

#End Region

#Region "PROCEDURE"
    '===== Setting Init
    Private Sub Init_Proc()
        Try
            'Request.Cookies["userName"].Value
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")

            Dim loginLevel as String 
            dim lbalert As  String

            Dim expire As String  
          
            If reqCookiesLogin IsNot Nothing
                loginLevel =  reqCookiesLogin("Level").ToString()
                expire = reqCookiesLogin("Expires").ToString()

                If loginLevel <> "undefined" Then
                
                    Select Case loginLevel
                        Case "0"
                            WorkReq.Visible = True
                            Report.Visible = True
                            Admin.Visible = False
                            'Maintenance.Visible = False
                        Case "1"
                            WorkReq.Visible = True
                            Report.Visible = True
                            Admin.Visible = False
                            'Maintenance.Visible = False

                        Case "9"
                            WorkReq.Visible = True
                            Report.Visible = True
                            Admin.Visible = True
                            'Maintenance.Visible = True

                        Case Else
                            WorkReq.Visible = False
                            Report.Visible = False
                            Admin.Visible = False
                            'Maintenance.Visible = False

                    End Select
            
                End If



            Else 
                'Response.Redirect("Login.aspx")
                'Dim exp As DateTime = DateTime.Now.AddDays(-1)
                'Dim expCookie As HttpCookie = Request.Cookies("logincookie")
                ''Set the Expiry date to past date.
                'expCookie.Expires = exp
                ''Update the Cookie in Browser.
                'Response.Cookies.Add(expCookie)
            End If
           
            'Dim loginLevel as String = If(reqCookiesLogin IsNot Nothing, reqCookiesLogin.Value.Split("="c)(1), "undefined")
           ' Dim opno as String = If(opnocookie IsNot Nothing, opnocookie.Value.Split("="c)(1), "undefined")

           

           

           

        Catch ex As Exception
            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)


        End Try
    End Sub

    Private Sub LogError(ex As Exception)
        Dim message As String = $"Time: {DateTime.Now:dd/MM/yyyy hh:mm:ss tt}"
        message += Environment.NewLine
        message += "-----------------------------------------------------------"
        message += Environment.NewLine
        message += $"Message: {ex.Message}"
        message += Environment.NewLine
        message += $"StackTrace: {ex.StackTrace}"
        message += Environment.NewLine
        message += $"Source: {ex.Source}"
        message += Environment.NewLine
        message += $"TargetSite: {ex.TargetSite}"
        message += Environment.NewLine
        message += "-----------------------------------------------------------"
        message += Environment.NewLine
        Dim path As String = Server.MapPath("~/Error/ErrorLog.txt")

        Using writer = New StreamWriter(path, True)
            writer.WriteLine(message)
            writer.Close()
        End Using
    End Sub

#End Region
End Class