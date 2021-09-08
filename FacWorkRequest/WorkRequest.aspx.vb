Option Strict On
Option Explicit On

Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class WorkRequest
    Inherits Page
    Dim ReadOnly objCMT As New DbClass

   

#Region "Page_Load"
    '===== Page_Load
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Page.IsPostBack Then

                
                Init_Proc()


                'Getdata for Delete
                If Not String.IsNullOrEmpty(Request.QueryString("DEL")) Then
                    ActDel()
                End If

                If Not String.IsNullOrEmpty(Request.QueryString("APP")) Then
                    ActAPP()
                End If

                If Not String.IsNullOrEmpty(Request.QueryString("REJ")) Then
                    ActREJ()
                End If

                'Show Modal Quotation
                If Not String.IsNullOrEmpty(Request.QueryString("PRSET")) Then
                    OpenModalPR

                End If

                If Not String.IsNullOrEmpty(Request.QueryString("QUO")) Then
                    OpenModalViewQuotation
                End If

                If Not String.IsNullOrEmpty(Request.QueryString("RPT")) Then
                    ActReport()
                End If

                'search work request date
                If _
                    Not String.IsNullOrEmpty(Request.QueryString("dtfrm")) And
                    Not String.IsNullOrEmpty(Request.QueryString("dtto")) Then

                    Finddata
                End If

                'search work request wrno
                If Not String.IsNullOrEmpty(Request.QueryString("findwrno")) Then

                    Finddatawrno
                End If

            End If
        End If
    End Sub

    '===== Setting Init
    Private Sub Init_Proc()
        Try
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            If not Request.Cookies("logincookie") Is Nothing Then
                UserInformation()
                GetDataWorkReqtest()
            Else
               
                    FormsAuthentication.RedirectToLoginPage()
               
            End If

           
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


#End Region

#Region "Function"

    Private Sub UserInformation()
        Try
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Using db = New DBFACDataContext()
                Dim ds = (From c In db.vewOperators Select c Where c.OPID = reqCookiesLogin("OPID").ToString).ToList()
                If ds.Any() Then
                    Label1.Text = ds(0).NickName
                    Label2.Text = ds(0).Position
                    Label3.Text = ds(0).Divsion
                    Label4.Text = ds(0).Department1
                    Label5.Text = ds(0).Section
                End If
            End Using
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

    Protected Sub ActDel()
        Try




            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequestUPDAndDEL(coll.AllKeys(0).ToString, WRNo, 0,
                                                                                      "",
                                                                                      0, 0, "", "", "", "", "",
                                                                                      objCMT.GetCoverDate(
                                                                                         Format(DateTime.Now, "dd/MM/yyyy")),
                                                                                      objCMT.GetCoverDate(
                                                                                          Format(DateTime.Now, "dd/MM/yyyy")),
                                                                                      "",
                                                                                      reqCookiesLogin("OPID").ToString,
                                                                                      "",
                                                                                      ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    GetDataWorkReqtest()
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "DeleteComplete()", True)

                Else
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('Error');", True)
                End If
            Next row

        Catch ex As Exception

            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
        Finally

        End Try


    End Sub


    Protected Sub ActAPP()
        Try
            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")


            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).ToString, WRNo,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    GetDataWorkReqtest()
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "ApproveComplete()", True)

                Else
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('Error');", True)
                End If
            Next row

        Catch ex As Exception

            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

        Finally

        End Try
    End Sub

    Protected Sub ActReport()
        Try
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next


            Dim cryRpt = New ReportDocument()
            Dim crtableLogoninfo = New TableLogOnInfo()
            Dim crConnectionInfo = New ConnectionInfo()
            Dim crTables As Tables

            cryRpt.Load(MapPath("Report\RptWorkRequest.rpt"))
            cryRpt.SetParameterValue("WRNO", WRNo)

            crConnectionInfo.ServerName = objCMT.GetPurpose("DB", "0001")
            crConnectionInfo.DatabaseName = objCMT.GetPurpose("DB", "0002")
            crConnectionInfo.UserID = objCMT.GetPurpose("DB", "0003")
            crConnectionInfo.Password = objCMT.GetPurpose("DB", "0004")
            crTables = cryRpt.Database.Tables
            For Each CrTable As Table In crTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next

            cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True,
                                        WRNo + "_" + Now.Date.ToString("ddMMyyyy"))


        Catch ex As Exception

            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

        Finally

        End Try
    End Sub


    Protected Sub ActREJ()
        Try
            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).ToString, WRNo,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    GetDataWorkReqtest()
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "RejectComplete()", True)

                Else
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('Error');", True)
                End If
            Next row

        Catch ex As Exception

            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

        Finally

        End Try
    End Sub


    Private Sub GetDataWorkReqtest()

      
            Using db = New DBFACDataContext()
                Try
                    Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
                Dim ds As New List(Of vewWorkRequest)
                Dim ds1 As New List(Of vewWorkRequest_Special_1)

                If CInt(reqCookiesLogin("Level")) = 1 Then
                    ds1 = db.vewWorkRequest_Special_1s.Where(Function(s) s.PlaceNbr = 5 Or s.PlaceNbr = 9 Or s.PlaceNbr = 15).ToList()


                ElseIf CInt(reqCookiesLogin("Role")) = 1 Then
                    ds = db.vewWorkRequests.Where(Function(s) s.GroupID = CInt(reqCookiesLogin("GrpID")) And
                                                             s.SubGroupID = CInt(reqCookiesLogin("SubGrpID")) And
                                                             s.UserOPID = reqCookiesLogin("OPID")).OrderBy(Function(o) o.Seq).ToList()

                    '(From c In db.vewWorkRequests Select c
                    '    Where _
                    '        c.GroupID = CInt(reqCookiesLogin("GrpID")) And
                    '        c.SubGroupID = CInt(reqCookiesLogin("SubGrpID")) And
                    '        c.UserOPID = CStr(reqCookiesLogin("OPID")) Order By c.UpdDate Descending).ToList()
                ElseIf CInt(reqCookiesLogin("Role")) = 2 Then
                    ds = db.vewWorkRequests.Where(Function(s) s.GroupID = CInt(reqCookiesLogin("GrpID")) And
                                                                      s.SubGroupID = CInt(reqCookiesLogin("SubGrpID"))).OrderBy(Function(o) o.Seq).ToList()
                    '(From c In db.vewWorkRequests Select c
                    '    Where _
                    '        c.GroupID = CInt(reqCookiesLogin("GrpID")) And
                    '        c.SubGroupID = CInt(reqCookiesLogin("SubGrpID")) Order By c.UpdDate Descending).ToList()
                ElseIf CInt(reqCookiesLogin("Role")) = 3 Then
                    ds = db.vewWorkRequests.Where(Function(s) s.GroupID = CInt(reqCookiesLogin("GrpID"))).OrderBy(Function(o) o.Seq).ToList()
                    '(From c In db.vewWorkRequests Select c Where c.GroupID = CInt(reqCookiesLogin("GrpID"))
                    ' Order By c.UpdDate Descending).ToList()

                End If

                If ds.Count <> 0 Then
                    gvDetails.DataSource = ds
                    gvDetails.DataBind()
                ElseIf ds1.Count <> 0 Then
                    gvDetails.DataSource = ds1
                    gvDetails.DataBind()
                Else
                    gvDetails.DataSource = ds
                    gvDetails.DataBind()
                End If

            Catch ex As Exception
                    'Write Error to Log.txt
                    LogError(ex)


                    Dim message As String = $"Message: {ex.Message}\n\n"
                    message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                    message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                    message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
                Finally
                db.Dispose()
                End Try
                
               


            End Using
       

           
    End Sub

#End Region

#Region "Event"

    Protected Sub gvDetails_DataBound(sender As Object, e As EventArgs) Handles gvDetails.DataBound

        Try
            Dim row = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)

            For i = 0 To gvDetails.Columns.Count - 1 ' -4 คือลบช่องหลังออกไม่ให้ค้นหาได้
                Dim cell = New TableHeaderCell()
                Dim txtSearch = New TextBox()
                txtSearch.Attributes("placeholder") = gvDetails.Columns(i).HeaderText
                txtSearch.CssClass = "search_textbox form-control input-sm"
                cell.Controls.Add(txtSearch)
                row.Controls.Add(cell)
            Next
            ' gvDetails.HeaderRow.Parent.Controls.AddAt(1, row)

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

    Protected Sub gvDetails_RowDataBound(sender As Object, e As GridViewRowEventArgs)
   

            Using db = New DBFACDataContext()

                Try
                     If e.Row.RowType = DataControlRowType.DataRow Then

                    Dim jobDetail As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "JobDetail"))
                    'Jobdetail fix length 20
                    Select Case jobDetail.Length
                        Case > 20
                            e.Row.Cells(4).ToolTip = e.Row.Cells(4).Text
                            e.Row.Cells(4).Text = jobDetail.Substring(0, 20) + " ..."
                    End Select

                End If

                Dim lnkEdit = CType(e.Row.FindControl("lnk_edit"), HyperLink)
                Dim lnkDel = CType(e.Row.FindControl("lnk_del"), HyperLink)
                Dim lnkView = CType(e.Row.FindControl("lnk_view"), HyperLink)
                Dim lnkReject = CType(e.Row.FindControl("lnk_reject"), HyperLink)
                Dim lnkQuotation = CType(e.Row.FindControl("lnk_quotation"), HyperLink)
                Dim lnkPr = CType(e.Row.FindControl("lnk_pr"), HyperLink)
                Dim lnkApprove = CType(e.Row.FindControl("lnk_approve"), HyperLink)
                Dim lnkRpt = CType(e.Row.FindControl("lnk_rpt"), HyperLink)
                Dim lnkApp = CType(e.Row.FindControl("lnk_app"), HyperLink)



                Dim wrno As String
                wrno = e.Row.Cells(0).Text


                Dim ds = db.vewWorkRequests.Where(Function(c)c.WRNo = wrno).ToList()
                'Dim ds = (From c In db.vewWorkRequests Select c Where c.WRNo = wrno).ToList()
                If ds.Count <> 0 Then
                    For Each o In ds
                        Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
                        'Getdata Status show badge
                        'Dim dsStyle As New List(Of vewStyle)

                        'dsStyle =(From f In db.vewStyles Select f Where _
                        '            f.GrpPage = "WorkRequest" And f.Seq = o.Seq And
                        '            f.SecurityRole = CInt(reqCookiesLogin("Role"))).ToList()



                        Dim dsStyle As New List(Of vewStyle)
                        If CInt(reqCookiesLogin("Level")) = 1 Then
                            dsStyle = db.vewStyles.Where(Function(x) x.GrpPage = "WorkRequest" And x.Seq = o.Seq And x.SecurityRole = 90).ToList()
                        Else
                            dsStyle = db.vewStyles.Where(Function(x) x.GrpPage = "WorkRequest" And x.Seq = o.Seq And x.SecurityRole = CInt(reqCookiesLogin("Role"))).ToList()
                        End If


                        If dsStyle.Count <> 0 Then
                            For Each z In dsStyle
                                'Action Show
                                lnkEdit.Visible = z.Action1.Value
                                lnkDel.Visible = z.Action2.Value
                                lnkView.Visible = z.Action3.Value
                                lnkReject.Visible = z.Action4.Value
                                lnkQuotation.Visible = z.Action5.Value
                                lnkPr.Visible = z.Action6.Value
                                lnkRpt.Visible = z.Action10.Value
                                lnkApp.Visible = z.Action12.Value


                                'Status Show
                                lnkApprove.Text = z.Status_Text.Trim
                                lnkApprove.CssClass = z.Status_CssClass.Trim()
                                lnkApprove.Enabled = z.Status_Enabled.Value
                                lnkApprove.ToolTip = z.Status_ToolTip.Trim
                            Next



                        End If


                        'Getdata quotation show badge
                        If o.Seq >= 8 Then


                            'Dim dsquo = (From c In db.vewQuotationCnts Select c Where c.WRNo = wrno).Count()

                            Dim dsquo = db.vewQuotationCnts.Count(Function (x) x.WRNo = wrno)
                            Dim countQuo As Integer
                            countQuo = dsquo
                            Dim lnkHyqoutation = CType(e.Row.FindControl("lnk_quotation"), HyperLink)
                            lnkHyqoutation.Text =
                                "<i class='fa fa-clone' aria-hidden='true'></i> <span class='badge badge-warning'>" &
                                countQuo & "</span>"
                            lnkHyqoutation.CssClass = "btn btn-info tooltips"
                            lnkHyqoutation.ToolTip = "You have Quotation " & countQuo
                        End If


                    Next

                End If
                Catch ex As Exception

                    'Write Error to Log.txt
                    LogError(ex)


                    Dim message As String = $"Message: {ex.Message}\n\n"
                    message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                    message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                    message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

                Finally

                    db.Dispose()
                End Try

               

            End Using
       

           
    End Sub


    Private Sub OpenModalPr()
        ' GetData
        lbwrno.Text = Request.QueryString("PRSET")
        Get_list_UP_PR
        lbwrno.CssClass = "text-danger"

        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "openModalsetpr()", True)
    End Sub


    Private Sub OpenModalViewQuotation()
        ' GetData
        lbwrno_quotation.Text = Request.QueryString("QUO")
        lbwrno_quotation.CssClass = "text-danger"
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "openModalviewquotation()", True)
        GetdataQuotation()
    End Sub


    Private Sub Finddata()
        Using db = New DBFACDataContext()
            Try

                Dim dtfrm = Request.QueryString("dtfrm")
                Dim dtto = Request.QueryString("dtto")
                Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")

                Dim ds As New List(Of vewWorkRequest)

                If CInt(reqCookiesLogin("Role")) = 1 Then
                    'ds = db.vewWorkRequests.Where(Function(c) c.GroupID = CInt(reqCookiesLogin("GrpID")) And c.SubGroupID = CInt(reqCookiesLogin("SubGrpID")) And c.UserOPID = CStr(reqCookiesLogin("OPID")) And c.CreateDate <= DateTime.Now And c.CreateDate >= DateTime.Now


                    ds =
                        (From c In db.vewWorkRequests Select c
                        Where _
                            c.GroupID = CInt(reqCookiesLogin("GrpID")) And
                            c.SubGroupID = CInt(reqCookiesLogin("SubGrpID")) And
                            c.UserOPID = CStr(reqCookiesLogin("OPID")) And
                            (c.CreateDate >= CType(dtfrm, Date?) And c.CreateDate <= CType(dtto, Date?))
                        Order By c.UpdDate Descending).ToList()
                ElseIf CInt(reqCookiesLogin("Role")) = 2 Then
                    ds =
                        (From c In db.vewWorkRequests Select c
                            Where _
                                c.GroupID = CInt(reqCookiesLogin("GrpID")) And
                                c.SubGroupID = CInt(reqCookiesLogin("SubGrpID")) And
                                (c.CreateDate >= CType(dtfrm, Date?) And c.CreateDate <= CType(dtto, Date?))
                            Order By c.UpdDate Descending).ToList()
                ElseIf CInt(reqCookiesLogin("Role")) = 3 Then
                    ds =
                        (From c In db.vewWorkRequests Select c
                            Where _
                                c.GroupID = CInt(reqCookiesLogin("GrpID")) And
                                (c.CreateDate >= CType(dtfrm, Date?) And c.CreateDate <= CType(dtto, Date?))
                            Order By c.UpdDate Descending).ToList()

                End If


                If ds.Count <> 0 Then
                    gvDetails.DataSource = ds
                    gvDetails.DataBind()
                Else
                    gvDetails.DataSource = ds
                    gvDetails.DataBind()
                End If


            Catch ex As Exception
                'Write Error to Log.txt
                LogError(ex)


                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

            End Try
        End Using
    End Sub

    Protected Sub Finddatawrno()
        Using db = New DBFACDataContext()
            Try

                Dim findwrno = Request.QueryString("findwrno")
                Dim ds As New List(Of vewWorkRequest)
                Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
                If CInt(reqCookiesLogin("Role")) = 1 Then
                    ds =
                        (From c In db.vewWorkRequests Select c
                            Where _
                                c.GroupID = CInt(reqCookiesLogin("GrpID")) And
                                c.SubGroupID = CInt(reqCookiesLogin("SubGrpID")) And
                                c.UserOPID = CStr(reqCookiesLogin("OPID")) And (c.WRNo = findwrno)
                            Order By c.UpdDate Descending).ToList()
                ElseIf CInt(reqCookiesLogin("Role")) = 2 Then
                    ds =
                        (From c In db.vewWorkRequests Select c
                            Where _
                                c.GroupID = CInt(reqCookiesLogin("GrpID")) And
                                c.SubGroupID = CInt(reqCookiesLogin("SubGrpID")) And (c.WRNo = findwrno)
                            Order By c.UpdDate Descending).ToList()
                ElseIf CInt(reqCookiesLogin("Role")) = 3 Then
                    ds =
                        (From c In db.vewWorkRequests Select c
                            Where c.GroupID = CInt(reqCookiesLogin("GrpID")) And (c.WRNo = findwrno)
                            Order By c.UpdDate Descending).ToList()

                End If

                'Dim ds = From f In db.vewWorkRequests Where (f.WRNo = findwrno)
                If ds.Any() Then
                    gvDetails.DataSource = ds
                    gvDetails.DataBind()
                Else
                    gvDetails.DataSource = ds
                    gvDetails.DataBind()
                End If


            Catch ex As Exception
                'Write Error to Log.txt
                LogError(ex)


                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

            End Try
        End Using
    End Sub

    Protected Sub GetdataQuotation()
        Using db = New DBFACDataContext()
            Try
                Dim wrnoquo As String = Request.QueryString("QUO")

                Dim ds = From f In db.vewQuotationCnts Where (f.WRNo = wrnoquo)
                If ds.Any() Then
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                Else
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                End If


            Catch ex As Exception
                'Write Error to Log.txt
                LogError(ex)


                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

            End Try
        End Using
    End Sub

    Protected Sub DownloadFile()

        Try

            Dim coll As NameValueCollection = Request.QueryString
            Dim wrNo = ""
            For Each key As String In coll.AllKeys
                wrNo = coll(key)
            Next
            Using db As New DBFACDataContext


                Dim file = db.vewQuotationCnts.FirstOrDefault(Function(f) f.WRNo.Equals(wrNo))

                If file IsNot Nothing Then
                    Response.ContentType = file.Extension
                    Response.AddHeader("content-disposition", "attachment; filename=" & file.FileName)
                    Response.BinaryWrite(file.FileAttach)
                    Response.Flush()
                    Response.[End]()
                End If
            End Using
        Catch ex As Exception
            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

        Finally

        End Try
    End Sub

    Protected Sub Savepr()
        Try

            'Check value before save 
            If tbprno1.Value = String.Empty Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "clearMyField()", True)
                Exit Sub
            End If

            Dim dtResult As New DataTable
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            dtResult = objCMT.LINQResultToDataTable(objCMT.db.sprPREntry(lbwrno.Text, reqCookiesLogin("OPID").ToString,
                                                                         tbprno1.Value, tbprno2.Value, tbprno3.Value,
                                                                         tbprno4.Value, tbprno5.Value))
            For Each row As DataRow In dtResult.Rows

                If CInt(row.Item("Msg").ToString) = 0 Then

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "InsertComplete()", True)
                Else
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('Error');", True)
                End If
            Next row

        Catch ex As Exception

            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)


        Finally

        End Try
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)

        gvDetails.PageIndex = e.NewPageIndex

        GetDataWorkReqtest
    End Sub

    Protected Sub Get_list_UP_PR()
        Using db = New DBFACDataContext()
            Try

                Dim wrnoList as String = Request.QueryString("PRSET")

                Dim ds = From f In db.WorkStatus
                         where
                        f.WRNo = wrnoList
                         Order By f.Seq
                         Select
                         f.WRNo,
                         f.PRNo,
                         f.Seq

                If ds.Any() Then

                    For Each lsq In ds

                        Select Case lsq.Seq
                            Case 1
                                tbprno1.Value = lsq.PRNo.Trim()
                               
                            Case 2
                                tbprno2.Value = lsq.PRNo.Trim()

                            Case 3
                                tbprno3.Value = lsq.PRNo.Trim()

                            Case 4
                                tbprno4.Value = lsq.PRNo.Trim()

                            Case 5
                                tbprno5.Value = lsq.PRNo.Trim()


                        End Select

                    Next


                End If


            Catch ex As Exception
                'Write Error to Log.txt
                LogError(ex)


                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

            End Try
        End Using
    End Sub

#End Region

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
End Class