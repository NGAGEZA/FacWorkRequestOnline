Option Strict On
Option Explicit On
Public Class Login
    Inherits Page
    Dim ReadOnly objCMT As New DbClass

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Page.User.Identity.IsAuthenticated Then

            Response.Redirect(FormsAuthentication.DefaultUrl)

        End If


        'If Not Me.IsPostBack Then

        '    If HttpContext.Current.User.Identity.IsAuthenticated Then
        '        FormsAuthentication.SignOut
        '        Response.Redirect(Request.RawUrl)
        '    End If
        'End If
    End Sub


    '===== Login
    Protected Sub Validatelogin
        Try
            If Not String.IsNullOrEmpty(Request.QueryString("UIDCODE")) Then
                Try
                    Dim dtResult As New DataTable
                    dtResult =
                        objCMT.LINQResultToDataTable(
                            objCMT.db.sprDecryptCode(Request.QueryString("UIDCODE").ToString.Trim))
                    For Each row As DataRow In dtResult.Rows

                        If String.IsNullOrEmpty(row.Item("UIDCode").ToString) Then
                            ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('Error');",
                                                                    True)
                        Else
                            MsgBox(row.Item("UIDCode").ToString)
                            ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('OK');", True)
                        End If

                    Next row

                Catch ex As Exception
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script",
                                                            "alert('" & ex.ToString & "');", True)
                End Try
            End If

            Dim ds As New List(Of vewOperator)
            ds = objCMT.GetOperators(Request.Form("opno").ToString.Trim, Request.Form("password").ToString.Trim)

            If ds.Any() Then


              


                Dim logincookie = New HttpCookie("logincookie")
                Dim exp As DateTime = DateTime.Now.AddMinutes(60)
                logincookie.Values.Add("OPID" , ds(0).OPID.ToString.Trim)
                logincookie.Values.Add("Role" , ds(0).SecurityRole.ToString.Trim)
                logincookie.Values.Add("Level" , ds(0).SecurityLevel.ToString.Trim)
                logincookie.Values.Add("GrpID" , ds(0).GroupID.ToString.Trim)
                logincookie.Values.Add("SubGrpID",  ds(0).SubGroupID.ToString.Trim)
                logincookie.Values.Add("Nickname",ds(0).NickName.ToString().Trim())
                logincookie.Values.Add("Created", now.ToString)
                logincookie.Values.Add("Expires", now.AddMinutes(60).ToString)


                logincookie.Expires = exp
                Response.Cookies.Add(logincookie)
               

                Dim nickname As String = ds(0).NickName.ToString().Trim()
                If Not String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then


                   
                    FormsAuthentication.SetAuthCookie(nickname, True)
                    'Response.Redirect(Request.QueryString("ReturnUrl"))
                    Response.Redirect("Menu.aspx")

                Else
                    FormsAuthentication.RedirectFromLoginPage(nickname, True)
                End If
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "LoginNotComplete()", True)
            End If

        Catch ex As Exception
            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
        Finally

        End Try
    End Sub

    Private Sub Login_Init(sender As Object, e As EventArgs) Handles Me.Init

        Form.DefaultButton = btnlogin.FindControl("btnlogin").UniqueID
       
    End Sub
End Class