Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class AdminJoblist
    Inherits Page
    Dim ReadOnly objCMT As New DbClass

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else

            If Not IsPostBack Then
                Dim appcookie = New HttpCookie("appcookie")

                BindGrid()

                If Not String.IsNullOrEmpty(Request.QueryString("APP1")) Then
                    ActAccept()
                End If

                If Not String.IsNullOrEmpty(Request.QueryString("APP7")) Then
                    ActRecive()
                End If

                If Not String.IsNullOrEmpty(Request.QueryString("APP2")) Then

                    appcookie("APP2") = Request.QueryString("APP2")
                    appcookie.Expires.Add(new TimeSpan(2, 0, 0))
                    Response.Cookies.Add(appcookie)

                    openModalSurveyDetails()
                End If




                'Show Modal Quotation
                If Not String.IsNullOrEmpty(Request.QueryString("APP3")) Then
                    OpenModalQuotation()
                End If


                If Not String.IsNullOrEmpty(Request.QueryString("APP4")) Then

                    appcookie("APP4") = Request.QueryString("APP4")
                    appcookie.Expires.Add(new TimeSpan(2, 0, 0))
                    Response.Cookies.Add(appcookie)
                    openModalworking()

                End If


                If Not String.IsNullOrEmpty(Request.QueryString("APP5")) Then

                    ActEndjob

                End If

                If Not String.IsNullOrEmpty(Request.QueryString("APP6")) Then
                    ActInspection

                End If



                If Not String.IsNullOrEmpty(Request.QueryString("APP9")) Then
                    ActContactVendor()

                End If

                If Not String.IsNullOrEmpty(Request.QueryString("APP11")) Then
                    ActApprove()

                End If

                'Save plan click
                If _
                    Not String.IsNullOrEmpty(Request.QueryString("dtfrm")) And
                    Not String.IsNullOrEmpty(Request.QueryString("dtto")) Then

                    SaveWorkingpaln

                End If


                'set servey click
                If Not String.IsNullOrEmpty(Request.QueryString("dtsur")) Then

                    ActSurvey()

                End If

                If Not String.IsNullOrEmpty(Request.QueryString("RPT")) Then
                    ActReport()
                End If


            End If
        End If
        'BindGrid()
    End Sub

    'Protected Sub ShowPopup()
    '    Dim title As String = "Greetings"
    '    Dim body As String = "Welcome to ASPSnippets.com"
    '    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "ShowPopup('" & title & "', '" & body & "');", True)
    'End Sub
    Private Sub BindGrid()
        Using db As New DBFACDataContext()
            Try
                Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
                Dim opid as String = reqCookiesLogin("OPID").ToString()

                Dim dsfac = (From c In db.vewOperatorFacs Select c Where c.OPID = opid).ToList()
                If dsfac.Any() Then
                    Dim dtResult As New DataTable
                    dtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequestListsFac(opid,CType(ddlsearch.SelectedValue, Integer?),tbSearch.Value))
                    gvDetails.DataSource = dtResult
                    gvDetails.DataBind()

                Else
                    Dim ds = (From c In db.vewWorkRequestLists Select c Where c.Seq >= 6 And c.Seq <> 9999 Order By c.Seq, c.WRNo).ToList()
                    If ds.Any() Then
                        gvDetails.DataSource = ds
                        gvDetails.DataBind()
                    End If

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

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)


        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim jobName As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "JobName"))


            Select Case jobName.Length
                Case > 20

                    e.Row.Cells(1).Text = jobName.Substring(0, 20)
                    e.Row.Cells(1).ToolTip = e.Row.Cells(1).Text

            End Select
        End If
    End Sub

    'Protected Sub gvDetails_DataBound(sender As Object, e As EventArgs) Handles gvDetails.DataBound
    '    Dim row = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
    '    Try
    '        For i As Integer = 0 To gvDetails.Columns.Count - 3
    '            Dim cell = New TableHeaderCell()
    '            Dim txtSearch = New TextBox()
    '            txtSearch.Attributes("placeholder") = gvDetails.Columns(i).HeaderText
    '            txtSearch.CssClass = "search_textbox form-control input-sm"
    '            cell.Controls.Add(txtSearch)
    '            row.Controls.Add(cell)
    '        Next
    '        If gvDetails.HeaderRow IsNot Nothing Then
    '            gvDetails.HeaderRow.Parent.Controls.AddAt(1, row)
    '        End If

    '    Catch ex As Exception
    '        'Write Error to Log.txt
    '        LogError(ex)


    '        Dim message As String = $"Message: {ex.Message}\n\n"
    '        message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
    '        message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
    '        message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

    '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
    '    Finally
    '        'db.Dispose()
    '    End Try
    'End Sub
  
    Protected Sub openModalQuotation
        ' GetData
        'lbwrno.Text = Request.QueryString("APP3")
        'Get_list_UP_Quotation
        'lbwrno.CssClass = "text-danger"
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "openModalsetQuotation()", True)
    End Sub


    Protected Sub openModalworking
        ' GetData
        lbwrno_workingdate.Text = Request.QueryString("APP4")
        lbwrno_workingdate.CssClass = "text-danger"
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "setplanworking()", True)
    End Sub

    Protected Sub openModalSurveyDetails
        ' GetData
        lbwrno_workingdate.Text = Request.QueryString("APP2")
        lbwrno_workingdate.CssClass = "text-danger"
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "setsurveydetails()", True)
    End Sub

   
    'Public Shared Function Get_list_UP_Quotation(ByVal name As String) As String

    'End Function
    
    Protected Sub Get_list_UP_Quotation
        Using db = New DBFACDataContext()
            Try

                Dim wrnoList as String = Request.QueryString("APP3")


                Dim ds = From f In db.FileAttaches
                        Where
                        f.WRNo = wrnoList And
                        f.Grp = "QUO"
                        Order By f.Seq
                        Select 
                        f.FileNbr,
                        f.Grp,
                        f.WRNo,
                        f.Seq,
                        f.FileAttach,
                        f.FileName,
                        f.Extension,
                        f.SupplierName,
                        f.QuotationDate,
                        f.QuotationAmt,
                        f.OPID,
                        f.UpdDate

                If ds.Any() Then

                    For Each lsq In ds

                        Select Case lsq.Seq
                            Case 1
                                lbls1.Text = CType(lsq.UpdDate, String)
                                trlist1.Visible = True
                                tb_lssupplier_1.Value = lsq.SupplierName
                                lbnamefile1.Text = lsq.FileName
                                tb_lsprice1.Value = CType(lsq.QuotationAmt, String)

                                If Not lsq.QuotationDate Is Nothing Then
                                    tb_lsdate1.Value = CType(lsq.QuotationDate, String)
                                End If
                            Case 2
                                lbls2.Text = CType(lsq.UpdDate, String)
                                trlist2.Visible = True
                                tb_lssupplier_2.Value = lsq.SupplierName
                                lbnamefile2.Text = lsq.FileName
                                tb_lsprice2.Value = CType(lsq.QuotationAmt, String)

                                If Not lsq.QuotationDate Is Nothing Then
                                    tb_lsdate2.Value = CType(lsq.QuotationDate, String)
                                End If

                            Case 3
                                lbls3.Text = CType(lsq.UpdDate, String)
                                trlist3.Visible = True
                                tb_lssupplier_3.Value = lsq.SupplierName
                                lbnamefile3.Text = lsq.FileName
                                tb_lsprice3.Value = CType(lsq.QuotationAmt, String)

                                If Not lsq.QuotationDate Is Nothing Then
                                    tb_lsdate3.Value = CType(lsq.QuotationDate, String)
                                End If
                            Case 4
                                lbls4.Text = CType(lsq.UpdDate, String)
                                trlist4.Visible = True
                                tb_lssupplier_4.Value = lsq.SupplierName
                                lbnamefile4.Text = lsq.FileName
                                tb_lsprice4.Value = CType(lsq.QuotationAmt, String)
                                If Not lsq.QuotationDate Is Nothing Then
                                    tb_lsdate4.Value = CType(lsq.QuotationDate, String)
                                End If
                            Case 5
                                lbls5.Text = CType(lsq.UpdDate, String)
                                trlist5.Visible = True
                                tb_lssupplier_5.Value = lsq.SupplierName
                                lbnamefile5.Text = lsq.FileName
                                tb_lsprice5.Value = CType(lsq.QuotationAmt, String)
                                If Not lsq.QuotationDate Is Nothing Then
                                    tb_lsdate5.Value = CType(lsq.QuotationDate, String)
                                End If

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

    Protected Sub DownloadFile1(sender As Object, e As EventArgs)
        Using db = New DBFACDataContext
            Try
                'Mcno = Request.QueryString("emcno")

                Dim wrnoList as String = Request.QueryString("APP3")


                Dim file = From f In db.FileAttaches
                        Where
                        f.WRNo = wrnoList And
                        f.Grp = "QUO" And
                        f.Seq = 1
                        Order By f.Seq
                        Select 
                        f.FileNbr,
                        f.Grp,
                        f.WRNo,
                        f.Seq,
                        f.FileAttach,
                        f.FileName,
                        f.Extension,
                        f.SupplierName,
                        f.QuotationDate,
                        f.QuotationAmt,
                        f.OPID,
                        f.UpdDate

                If file.Any()
                    For Each f In file

                        Response.ContentType = f.Extension
                        Response.AddHeader("content-disposition", "attachment; filename=" & f.FileName.Trim())
                        Response.BinaryWrite(f.FileAttach)
                        Response.Flush()
                        Response.[End]()


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
     

    Protected Sub DownloadFile2()
        Using db = New DBFACDataContext
            Try
                'Mcno = Request.QueryString("emcno")

                Dim wrnoList as String = Request.QueryString("APP3")


                Dim file = From f In db.FileAttaches
                        Where
                        f.WRNo = wrnoList And
                        f.Grp = "QUO" And
                        f.Seq = 2
                        Order By f.Seq
                        Select 
                        f.FileNbr,
                        f.Grp,
                        f.WRNo,
                        f.Seq,
                        f.FileAttach,
                        f.FileName,
                        f.Extension,
                        f.SupplierName,
                        f.QuotationDate,
                        f.QuotationAmt,
                        f.OPID,
                        f.UpdDate

                If file.Any()
                    For Each f In file

                        Response.ContentType = f.Extension
                        Response.AddHeader("content-disposition", "attachment; filename=" & f.FileName.Trim())
                        Response.BinaryWrite(f.FileAttach)
                        Response.Flush()
                        Response.[End]()


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

    Protected Sub FunctionSearch()
        Dim msgsearch As String

                Using db As New DBFACDataContext()
                    Try
                        Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
                        Dim opid as String = reqCookiesLogin("OPID").ToString()

                        Dim dsfac = db.vewOperatorFacs.Where(Function(x)x.OPID = opid).Select(Function(t)t.OPID).ToList()
                        If dsfac.Any() Then
                            Dim dtResult As New DataTable
                            dtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequestListsFac(opid,CType(ddlsearch.SelectedValue, Integer?),tbsearch.Value))
                            gvDetails.DataSource = dtResult
                            gvDetails.DataBind()

                        Else
                            Dim ds = (From c In db.vewWorkRequestLists Select c Where c.Seq >= 6 And c.Seq <> 9999 Order By c.Seq, c.WRNo).ToList()
                            If ds.Any() Then
                                gvDetails.DataSource = ds
                                gvDetails.DataBind()
                            End If

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
    Protected Sub DownloadFile3()
        Using db = New DBFACDataContext
            Try
                'Mcno = Request.QueryString("emcno")

                Dim wrnoList as String = Request.QueryString("APP3")


                Dim file = From f In db.FileAttaches
                        Where
                        f.WRNo = wrnoList And
                        f.Grp = "QUO" And
                        f.Seq = 3
                        Order By f.Seq
                        Select 
                        f.FileNbr,
                        f.Grp,
                        f.WRNo,
                        f.Seq,
                        f.FileAttach,
                        f.FileName,
                        f.Extension,
                        f.SupplierName,
                        f.QuotationDate,
                        f.QuotationAmt,
                        f.OPID,
                        f.UpdDate

                If file.Any()
                    For Each f In file

                        Response.ContentType = f.Extension
                        Response.AddHeader("content-disposition", "attachment; filename=" & f.FileName.Trim())
                        Response.BinaryWrite(f.FileAttach)
                        Response.Flush()
                        Response.[End]()


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

    Protected Sub DownloadFile4()
        Using db = New DBFACDataContext
            Try
                'Mcno = Request.QueryString("emcno")

                Dim wrnoList as String = Request.QueryString("APP3")


                Dim file = From f In db.FileAttaches
                        Where
                        f.WRNo = wrnoList And
                        f.Grp = "QUO" And
                        f.Seq = 4
                        Order By f.Seq
                        Select 
                        f.FileNbr,
                        f.Grp,
                        f.WRNo,
                        f.Seq,
                        f.FileAttach,
                        f.FileName,
                        f.Extension,
                        f.SupplierName,
                        f.QuotationDate,
                        f.QuotationAmt,
                        f.OPID,
                        f.UpdDate

                If file.Any()
                    For Each f In file

                        Response.ContentType = f.Extension
                        Response.AddHeader("content-disposition", "attachment; filename=" & f.FileName.Trim())
                        Response.BinaryWrite(f.FileAttach)
                        Response.Flush()
                        Response.[End]()


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

    Protected Sub DownloadFile5()
        Using db = New DBFACDataContext
            Try
                'Mcno = Request.QueryString("emcno")

                Dim wrnoList as String = Request.QueryString("APP3")


                Dim file = From f In db.FileAttaches
                        Where
                        f.WRNo = wrnoList And
                        f.Grp = "QUO" And
                        f.Seq = 5
                        Order By f.Seq
                        Select 
                        f.FileNbr,
                        f.Grp,
                        f.WRNo,
                        f.Seq,
                        f.FileAttach,
                        f.FileName,
                        f.Extension,
                        f.SupplierName,
                        f.QuotationDate,
                        f.QuotationAmt,
                        f.OPID,
                        f.UpdDate

                If file.Any()
                    For Each f In file

                        Response.ContentType = f.Extension
                        Response.AddHeader("content-disposition", "attachment; filename=" & f.FileName.Trim())
                        Response.BinaryWrite(f.FileAttach)
                        Response.Flush()
                        Response.[End]()


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

    Protected Sub ActReport()
        Try
            Dim coll As NameValueCollection = Request.QueryString
            Dim wrNo = ""
            For Each key As String In coll.AllKeys
                wrNo = coll(key)
            Next


            Dim cryRpt = New ReportDocument()
            Dim crtableLogoninfo = New TableLogOnInfo()
            Dim crConnectionInfo = New ConnectionInfo()
            Dim CrTables As Tables

            cryRpt.Load(MapPath("Report\RptWorkRequest.rpt"))
            cryRpt.SetParameterValue("WRNO", wrNo)

            crConnectionInfo.ServerName = objCMT.GetPurpose("DB", "0001")
            crConnectionInfo.DatabaseName = objCMT.GetPurpose("DB", "0002")
            crConnectionInfo.UserID = objCMT.GetPurpose("DB", "0003")
            crConnectionInfo.Password = objCMT.GetPurpose("DB", "0004")
            CrTables = cryRpt.Database.Tables
            For Each CrTable As Table In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next

            cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True,
                                        wrNo + "_" + Now.Date.ToString("ddMMyyyy"))

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

    Private Sub ActAccept()
        Try
            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")

            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).Substring(0, 3).ToString,
                                                                             WRNo,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    'check vew step [vewWRnoChange]

                    'step rename folder in path 


                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "AcceptComplete()", True)

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

    Protected Sub ActRecive()
        Try
            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next

            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).Substring(0, 3).ToString,
                                                                             WRNo,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "ReceiveComplete()", True)

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

    Protected Sub ActEndJob()
        Try
            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next

            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).Substring(0, 3).ToString,
                                                                             WRNo,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "EndjobComplete()", True)

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
    Protected Sub ActInspection()
        Try
            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next

            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).Substring(0, 3).ToString,
                                                                             WRNo,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "InspectionComplete()", True)

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
    Protected Sub ActApprove()
        Try
            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next

            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).Substring(0, 3).ToString,
                                                                             WRNo,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

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
    Protected Sub ActContactVendor()
        Try
            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next

            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).Substring(0, 3).ToString,
                                                                             WRNo,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "ContactComplete()", True)

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

    Protected Sub ActSurvey()
        Try

            Dim remark as String = Request.QueryString("remarksur")
            Dim DtResult As New DataTable
            Dim appcookie As HttpCookie = Request.Cookies("appcookie")
            Dim surwrno As String = appcookie("APP2")
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert(" & surwrno + "CCC" & ");", True)
            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest("APP", surwrno,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                ' System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert(" & row.Item("Msg").ToString & ");", True)
                If CInt(row.Item("Msg").ToString) = 0 Then

                    ' Update Survey Date
                    DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequestUPDSurvey(surwrno,
                                                                                              objCMT.GetCoverDate(
                                                                                                  Request.QueryString(
                                                                                                      "dtsur")), remark))


                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "SurveyComplete()", True)

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

    Protected Sub SaveWorkingpaln()

        Try


            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next
            Dim appcookie As HttpCookie = Request.Cookies("appcookie")
            Dim swrno as string = appcookie("APP4")
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")

            DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest("APP", swrno,
                                                                             reqCookiesLogin("OPID").ToString,
                                                                             ipcookie("IP_ADDRESS")))


            For Each row As DataRow In DtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then
                    ' Update Add Row Start Plan & End Plan
                    DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequestUPDPlan(swrno,
                                                                                            objCMT.GetCoverDate(
                                                                                                Request.QueryString(
                                                                                                    "dtfrm")),
                                                                                            objCMT.GetCoverDate(
                                                                                                Request.QueryString(
                                                                                                    "dtto"))))

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "SetplanComplete()", True)


                    'Else
                    '    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('Error');", True)
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


    Protected Sub uploadfile_1()
        Dim validateColor As New Color
        validateColor = ColorTranslator.FromHtml("#a94442") 'Red color


        Dim upadmcookie1 = New HttpCookie("upadmcookie1")
        Request.Cookies.Remove("upadmcookie1")


        If FileUpload1.HasFile Then
            Dim fileExtension As String = Path.GetExtension(FileUpload1.FileName)
            Dim GID As Guid
            GID = Guid.NewGuid()



            If _
                fileExtension.ToLower() <> ".jpg" AndAlso fileExtension.ToLower() <> ".pdf" AndAlso
                fileExtension.ToLower() <> ".png" AndAlso fileExtension.ToLower() <> ".jpeg" Then
                lblMessage1.Text = "Only PDF,PNG,JPG,JPEG file allowed"
                lblMessage1.CssClass = "h6"
                lblMessage1.ForeColor = validateColor
                OpenModalQuotation()
            Else
                Dim fileSize As Integer = FileUpload1.PostedFile.ContentLength

                If fileSize > 5242880 Then
                    lblMessage1.Text = "Maximum size 5(MB) exceeded "
                    lblMessage1.ForeColor = validateColor
                    OpenModalQuotation()
                Else

                    FileUpload1.SaveAs(Server.MapPath("~/Upload/" & GID.ToString() & FileUpload1.FileName))
                    lblMessage1.Text = "File Uploaded successfully"
                    lblMessage1.ForeColor = Color.Green


                    upadmcookie1("namepath_0001") =
                        (Server.MapPath("~/Upload/" & GID.ToString() & FileUpload1.FileName))
                    upadmcookie1("nametype_0001") = fileExtension.ToLower.ToString()
                    upadmcookie1("namefile_0001") = FileUpload1.FileName
                    upadmcookie1.Expires = DateTime.Now.AddMinutes(5)
                    Response.Cookies.Add(upadmcookie1)


                End If
            End If



        End If
    End Sub

    Protected Sub uploadfile_2()
        Dim validateColor As New Color
        validateColor = ColorTranslator.FromHtml("#a94442") 'Red color


        Dim upadmcookie2 = New HttpCookie("upadmcookie2")
        Request.Cookies.Remove("upadmcookie2")



        If FileUpload2.HasFile Then
            Dim fileExtension As String = Path.GetExtension(FileUpload2.FileName)
            Dim GID As Guid
            GID = Guid.NewGuid()


            If _
                fileExtension.ToLower() <> ".jpg" AndAlso fileExtension.ToLower() <> ".pdf" AndAlso
                fileExtension.ToLower() <> ".png" AndAlso fileExtension.ToLower() <> ".jpeg" Then
                lblMessage2.Text = "Only PDF,PNG,JPG,JPEG file allowed"
                lblMessage2.CssClass = "h6"
                lblMessage2.ForeColor = validateColor
                OpenModalQuotation()
            Else
                Dim fileSize As Integer = FileUpload2.PostedFile.ContentLength

                If fileSize > 5242880 Then
                    lblMessage2.Text = "Maximum size 5(MB) exceeded "
                    lblMessage2.ForeColor = validateColor
                    OpenModalQuotation()
                Else
                    FileUpload2.SaveAs(Server.MapPath("~/Upload/" & GID.ToString() & FileUpload2.FileName))
                    lblMessage2.Text = "File Uploaded successfully"
                    lblMessage2.ForeColor = Color.Green

                    'Dim upadmcookie2 = New HttpCookie("upadmcookie2")
                    upadmcookie2("namepath_0002") =
                        (Server.MapPath("~/Upload/" & gid.ToString() & FileUpload2.FileName))
                    upadmcookie2("nametype_0002") = fileExtension.ToLower.ToString()
                    upadmcookie2("namefile_0002") = FileUpload2.FileName
                    upadmcookie2.Expires = DateTime.Now.AddHours(2)
                    Response.Cookies.Add(upadmcookie2)


                End If
            End If

        End If
    End Sub

    Protected Sub uploadfile_3()
        Dim validateColor As New Color
        validateColor = ColorTranslator.FromHtml("#a94442") 'Red color



        Dim upadmcookie3 = New HttpCookie("upadmcookie3")
        Request.Cookies.Remove("upadmcookie3")


        If FileUpload3.HasFile Then
            Dim fileExtension As String = Path.GetExtension(FileUpload3.FileName)
            Dim GID As Guid
            GID = Guid.NewGuid()


            If _
                fileExtension.ToLower() <> ".jpg" AndAlso fileExtension.ToLower() <> ".pdf" AndAlso
                fileExtension.ToLower() <> ".png" AndAlso fileExtension.ToLower() <> ".jpeg" Then
                lblMessage3.Text = "Only PDF,PNG,JPG,JPEG file allowed"
                lblMessage3.CssClass = "h6"
                lblMessage3.ForeColor = validateColor
                OpenModalQuotation()
            Else
                Dim fileSize As Integer = FileUpload3.PostedFile.ContentLength

                If fileSize > 5242880 Then
                    lblMessage3.Text = "Maximum size 5(MB) exceeded "
                    lblMessage3.ForeColor = validateColor
                    OpenModalQuotation()
                Else
                    FileUpload3.SaveAs(Server.MapPath("~/Upload/" & GID.ToString() & FileUpload3.FileName))
                    lblMessage3.Text = "File Uploaded successfully"
                    lblMessage3.ForeColor = Color.Green

                    'Dim upadmcookie3 = New HttpCookie("upadmcookie3")
                    upadmcookie3("namepath_0003") =
                        (Server.MapPath("~/Upload/" & gid.ToString() & FileUpload3.FileName))
                    upadmcookie3("nametype_0003") = fileExtension.ToLower.ToString()
                    upadmcookie3("namefile_0003") = FileUpload3.FileName
                    upadmcookie3.Expires = DateTime.Now.AddHours(2)
                    Response.Cookies.Add(upadmcookie3)


                End If
            End If
        End If
    End Sub

    Protected Sub uploadfile_4()
        Dim validateColor As New Color
        validateColor = ColorTranslator.FromHtml("#a94442") 'Red color


        Dim upadmcookie4 = New HttpCookie("upadmcookie4")
        Request.Cookies.Remove("upadmcookie4")


        If FileUpload4.HasFile Then
            Dim fileExtension As String = Path.GetExtension(FileUpload4.FileName)
            Dim GID As Guid
            GID = Guid.NewGuid()


            If _
                fileExtension.ToLower() <> ".jpg" AndAlso fileExtension.ToLower() <> ".pdf" AndAlso
                fileExtension.ToLower() <> ".png" AndAlso fileExtension.ToLower() <> ".jpeg" Then
                lblMessage4.Text = "Only PDF,PNG,JPG,JPEG file allowed"
                lblMessage4.CssClass = "h6"
                lblMessage4.ForeColor = validateColor
                OpenModalQuotation()
            Else
                Dim fileSize As Integer = FileUpload4.PostedFile.ContentLength

                If fileSize > 5242880 Then
                    lblMessage4.Text = "Maximum size 5(MB) exceeded "
                    lblMessage4.ForeColor = validateColor
                    OpenModalQuotation()
                Else
                    FileUpload4.SaveAs(Server.MapPath("~/Upload/" & GID.ToString() & FileUpload4.FileName))
                    lblMessage4.Text = "File Uploaded successfully"
                    lblMessage4.ForeColor = Color.Green

                    'Dim upadmcookie4 = New HttpCookie("upadmcookie4")
                    upadmcookie4("namepath_0004") =
                        (Server.MapPath("~/Upload/" & gid.ToString() & FileUpload4.FileName))
                    upadmcookie4("nametype_0004") = fileExtension.ToLower.ToString()
                    upadmcookie4("namefile_0004") = FileUpload4.FileName
                    upadmcookie4.Expires = DateTime.Now.AddHours(2)
                    Response.Cookies.Add(upadmcookie4)


                End If
            End If

        End If
    End Sub

    Protected Sub uploadfile_5()
        Dim validateColor As New Color
        validateColor = ColorTranslator.FromHtml("#a94442") 'Red color


        Dim upadmcookie5 = New HttpCookie("upadmcookie5")
        Request.Cookies.Remove("upadmcookie5")


        If FileUpload5.HasFile Then
            Dim fileExtension As String = Path.GetExtension(FileUpload5.FileName)
            Dim GID As Guid
            GID = Guid.NewGuid()


            If _
                fileExtension.ToLower() <> ".jpg" AndAlso fileExtension.ToLower() <> ".pdf" AndAlso
                fileExtension.ToLower() <> ".png" AndAlso fileExtension.ToLower() <> ".jpeg" Then
                lblMessage5.Text = "Only PDF,PNG,JPG,JPEG file allowed"
                lblMessage5.CssClass = "h6"
                lblMessage5.ForeColor = validateColor
                OpenModalQuotation()
            Else
                Dim fileSize As Integer = FileUpload5.PostedFile.ContentLength

                If fileSize > 5242880 Then
                    lblMessage5.Text = "Maximum size 5(MB) exceeded "
                    lblMessage5.ForeColor = validateColor
                    OpenModalQuotation()
                Else
                    FileUpload5.SaveAs(Server.MapPath("~/Upload/" & GID.ToString() & FileUpload5.FileName))
                    lblMessage5.Text = "File Uploaded successfully"
                    lblMessage5.ForeColor = Color.Green

                    'Dim upadmcookie5 = New HttpCookie("upadmcookie5")
                    upadmcookie5("namepath_0005") =
                        (Server.MapPath("~/Upload/" & gid.ToString() & FileUpload5.FileName))
                    upadmcookie5("nametype_0005") = fileExtension.ToLower.ToString()
                    upadmcookie5("namefile_0005") = FileUpload5.FileName
                    upadmcookie5.Expires = DateTime.Now.AddHours(2)
                    Response.Cookies.Add(upadmcookie5)


                End If
            End If
        End If
    End Sub


#Region "Function"

    Function FileUpload(RunningNo As String) As Boolean
        Dim flagStatus = False

        Try

            Dim DtResult As New DataTable
            Dim img As Byte() = Nothing
            Dim datenull As Nullable(Of DateTime) = Nothing
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            '-- Att File 1
            Dim reqadmcookie1 As HttpCookie = Request.Cookies("upadmcookie1")

            If Not reqadmcookie1 Is Nothing Then
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 1,
                                                                                ConverFileUpLoad(
                                                                                    reqadmcookie1("namepath_0001")),
                                                                                reqadmcookie1("namefile_0001"),
                                                                                reqadmcookie1("nametype_0001"),
                                                                                tbsupplier1.Value.Trim, DateTime.Now,
                                                                                CDec(tbprice1.Value.Trim),
                                                                                reqCookiesLogin("OPID")))
                flagStatus = True

            Else
                'DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 1, New Binary(img), "",
                '                                                                "", tbsupplier1.Value.Trim,
                '                                                                datenull, 0, reqCookiesLogin("OPID")))
                flagStatus = False
            End If

            '-- Att File 2
            Dim reqadmcookie2 As HttpCookie = Request.Cookies("upadmcookie2")

            If Not reqadmcookie2 Is Nothing Then
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 2,
                                                                                ConverFileUpLoad(
                                                                                    reqadmcookie2("namepath_0002")),
                                                                                reqadmcookie2("namefile_0002"),
                                                                                reqadmcookie2("nametype_0002"),
                                                                                tbsupplier2.Value.Trim, DateTime.Now,
                                                                                CDec(tbprice2.Value.Trim),
                                                                                reqCookiesLogin("OPID")))
                flagStatus = True
            Else
                'DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 2, New Binary(img), "",
                '                                                              "", tbsupplier2.Value.Trim,
                '                                                              datenull, 0, reqCookiesLogin("OPID")))
                flagStatus = False
            End If


            '-- Att File 3
            Dim reqadmcookie3 As HttpCookie = Request.Cookies("upadmcookie3")
            If Not reqadmcookie3 Is Nothing Then
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 3,
                                                                               ConverFileUpLoad(
                                                                                   reqadmcookie3("namepath_0003")),
                                                                               reqadmcookie3("namefile_0003"),
                                                                               reqadmcookie3("nametype_0003"),
                                                                               tbsupplier3.Value.Trim, DateTime.Now,
                                                                               CDec(tbprice3.Value.Trim),
                                                                               reqCookiesLogin("OPID")))
                flagStatus = True
            Else
                'DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 3, New Binary(img), "",
                '                                                               "", tbsupplier3.Value.Trim,
                '                                                               datenull, 0, reqCookiesLogin("OPID")))
                flagStatus = False
            End If

            '-- Att File 4
            Dim reqadmcookie4 As HttpCookie = Request.Cookies("upadmcookie4")
            If Not reqadmcookie4 Is Nothing Then
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 4,
                                                                               ConverFileUpLoad(
                                                                                   reqadmcookie4("namepath_0004")),
                                                                               reqadmcookie4("namefile_0004"),
                                                                               reqadmcookie4("nametype_0004"),
                                                                               tbsupplier4.Value.Trim, DateTime.Now,
                                                                               CDec(tbprice4.Value.Trim),
                                                                               reqCookiesLogin("OPID")))
                flagStatus = True
            Else
                'DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 4, New Binary(img), "",
                '                                                               "", tbsupplier4.Value.Trim,
                '                                                               datenull, 0, reqCookiesLogin("OPID")))
                flagStatus = False
            End If


            '-- Att File 5
            Dim reqadmcookie5 As HttpCookie = Request.Cookies("upadmcookie5")
            If Not reqadmcookie5 Is Nothing Then
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 5,
                                                                                ConverFileUpLoad(
                                                                                    reqadmcookie5("namepath_0005")),
                                                                                reqadmcookie5("namefile_0005"),
                                                                                reqadmcookie5("nametype_0005"),
                                                                                tbsupplier5.Value.Trim, DateTime.Now,
                                                                                CDec(tbprice5.Value.Trim),
                                                                                reqCookiesLogin("OPID")))
                flagStatus = True
            Else
                'DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("QUO", RunningNo, 5, New Binary(img), "",
                '                                                              "", tbsupplier5.Value.Trim,
                '                                                              datenull, 0, reqCookiesLogin("OPID")))
                flagStatus = False
            End If

            Return flagStatus
        Catch ex As Exception
            LogError(ex)
            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Return flagStatus
        Finally

        End Try
    End Function

    Function ConverFileUpLoad(nameupload As String) As Byte()
        Dim filePathupload As String
        Dim filenameupload As String
        Dim fsupload As FileStream
        Dim brupload As BinaryReader
        Dim bytesupload As Byte()

        If nameupload IsNot Nothing Then
            filePathupload = nameupload
            filenameupload = Path.GetFileName(filePathupload)
            fsupload = New FileStream(filePathupload, FileMode.Open, FileAccess.Read)
            brupload = New BinaryReader(fsupload)
            bytesupload = brupload.ReadBytes(Convert.ToInt32(fsupload.Length))
            brupload.Close()
            fsupload.Close()
        End If

        Return bytesupload
    End Function


    Protected Sub Lsdel1(sender As Object, e As EventArgs)
        Using db As New DBFACDataContext
            Try
                Dim wrnoList as String = Request.QueryString("APP3")
                Dim delqs = From d In db.FileAttaches
                        Where
                        d.WRNo = wrnoList And
                        d.Grp = "QUO" And
                        CLng(d.Seq) = 1
                        Order By
                        d.Seq
                        Select d
                For Each del In delqs
                    db.FileAttaches.DeleteOnSubmit(del)
                Next
                db.SubmitChanges()


            Catch ex As Exception

                LogError(ex)
                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

                lbmessage_ls.Text = "Delete Upload file list 1. Successful"
                trlist1.Visible = False
                OpenModalQuotation()

            End Try
        End Using
    End Sub

    Protected Sub Lsdel2(sender As Object, e As EventArgs)
        Using db As New DBFACDataContext
            Try
                Dim wrnoList as String = Request.QueryString("APP3")
                Dim delqs = From d In db.FileAttaches
                        Where
                        d.WRNo = wrnoList And
                        d.Grp = "QUO" And
                        CLng(d.Seq) = 2
                        Order By
                        d.Seq
                        Select d
                For Each del In delqs
                    db.FileAttaches.DeleteOnSubmit(del)
                Next
                db.SubmitChanges()


            Catch ex As Exception

                LogError(ex)
                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

                lbmessage_ls.Text = "Delete Upload file list 2. Successful"
                trlist2.Visible = False
                OpenModalQuotation()
            End Try
        End Using
    End Sub

    Protected Sub Lsdel3(sender As Object, e As EventArgs)
        Using db As New DBFACDataContext
            Try
                Dim wrnoList as String = Request.QueryString("APP3")
                Dim delqs = From d In db.FileAttaches
                        Where
                        d.WRNo = wrnoList And
                        d.Grp = "QUO" And
                        CLng(d.Seq) = 3
                        Order By
                        d.Seq
                        Select d
                For Each del In delqs
                    db.FileAttaches.DeleteOnSubmit(del)
                Next
                db.SubmitChanges()


            Catch ex As Exception

                LogError(ex)
                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

                lbmessage_ls.Text = "Delete Upload file list 3. Successful"
                trlist3.Visible = False
                OpenModalQuotation()
            End Try
        End Using
    End Sub

    Protected Sub Lsdel4(sender As Object, e As EventArgs)
        Using db As New DBFACDataContext
            Try
                Dim wrnoList as String = Request.QueryString("APP3")
                Dim delqs = From d In db.FileAttaches
                        Where
                        d.WRNo = wrnoList And
                        d.Grp = "QUO" And
                        CLng(d.Seq) = 4
                        Order By
                        d.Seq
                        Select d
                For Each del In delqs
                    db.FileAttaches.DeleteOnSubmit(del)
                Next
                db.SubmitChanges()


            Catch ex As Exception

                LogError(ex)
                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

                lbmessage_ls.Text = "Delete Upload file list 4. Successful"
                trlist4.Visible = False
                OpenModalQuotation()
            End Try
        End Using
    End Sub

    Protected Sub Lsdel5(sender As Object, e As EventArgs)
        Using db As New DBFACDataContext
            Try
                Dim wrnoList as String = Request.QueryString("APP3")
                Dim delqs = From d In db.FileAttaches
                        Where
                        d.WRNo = wrnoList And
                        d.Grp = "QUO" And
                        CLng(d.Seq) = 5
                        Order By
                        d.Seq
                        Select d
                For Each del In delqs
                    db.FileAttaches.DeleteOnSubmit(del)
                Next
                db.SubmitChanges()


            Catch ex As Exception

                LogError(ex)
                Dim message As String = $"Message: {ex.Message}\n\n"
                message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

                lbmessage_ls.Text = "Delete Upload file list 5. Successful"
                trlist5.Visible = False
                OpenModalQuotation()
            End Try
        End Using
    End Sub

    Protected Sub gvDetails_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDetails.RowDataBound
        Try

            Using db = New DBFACDataContext()

                Dim lnk_detail = CType(e.Row.FindControl("lnk_detail"), HyperLink)
                Dim lnk_rec = CType(e.Row.FindControl("lnk_rec"), HyperLink)
                Dim lnk_accept = CType(e.Row.FindControl("lnk_accept"), HyperLink)
                Dim lnk_survey = CType(e.Row.FindControl("lnk_survey"), HyperLink)
                Dim lnk_quotation = CType(e.Row.FindControl("lnk_quotation"), HyperLink)
                Dim lnk_working = CType(e.Row.FindControl("lnk_working"), HyperLink)
                Dim lnk_end = CType(e.Row.FindControl("lnk_end"), HyperLink)
                Dim lnk_app_inspec = CType(e.Row.FindControl("lnk_app_inspec"), HyperLink)
                Dim lnk_rpt = CType(e.Row.FindControl("lnk_rpt"), HyperLink)
                Dim lnk_contact = CType(e.Row.FindControl("lnk_contact"), HyperLink)
                Dim lnk_status = CType(e.Row.FindControl("lnk_status"), HyperLink)
                Dim lnk_app = CType(e.Row.FindControl("lnk_app"), HyperLink)
                Dim lnk_edit = CType(e.Row.FindControl("lnk_edit"), HyperLink)

                Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")

                Dim wrno As String
                wrno = e.Row.Cells(0).Text

                Dim ds = (From c In db.vewWorkRequests Select c Where c.WRNo = wrno).ToList()
                If ds.Any() Then
                    For Each o In ds

                        'Getdata Status show badge
                        Dim dsStyle As New List(Of vewStyle)
                        dsStyle =
                            (From f In db.vewStyles Select f
                                Where _
                                    f.GrpPage = "AdminJoblist" And f.Seq = o.Seq And
                                    f.SecurityRole = CInt(reqCookiesLogin("Role"))).ToList()
                        If dsStyle.Any() Then
                            For Each z In dsStyle
                                'Action Show
                                lnk_detail.Visible = z.Action1.Value
                                lnk_rec.Visible = z.Action2.Value
                                lnk_accept.Visible = z.Action3.Value
                                lnk_survey.Visible = z.Action4.Value
                                lnk_quotation.Visible = z.Action5.Value
                                lnk_working.Visible = z.Action6.Value
                                lnk_end.Visible = z.Action7.Value
                                lnk_app_inspec.Visible = z.Action8.Value
                                lnk_app_inspec.Visible = z.Action8.Value
                                lnk_contact.Visible = z.Action9.Value
                                lnk_rpt.Visible = z.Action10.Value
                                lnk_status.Visible = z.Action11.Value
                                lnk_app.Visible = z.Action12.Value
                                lnk_edit.Visible = z.Action13.Value

                                'Status Show
                                lnk_status.Text = z.Status_Text.Trim
                                lnk_status.CssClass = z.Status_CssClass.Trim()
                                lnk_status.Enabled = z.Status_Enabled.Value
                                lnk_status.ToolTip = z.Status_ToolTip.Trim

                            Next
                        End If

                    Next

                End If

            End Using
        Catch ex As Exception

            LogError(ex)
            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

        Finally

        End Try
    End Sub

    Private Sub lnkquosave_Click(sender As Object, e As EventArgs) Handles lnkquosave.Click
        Try

            'Check value before save 
            If tbsupplier1.Value = String.Empty Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "clearMyField()", True)
                Exit Sub
            End If

            Dim DtResult As New DataTable
            Dim coll As NameValueCollection = Request.QueryString
            Dim WRNo = ""
            For Each key As String In coll.AllKeys
                WRNo = coll(key)
            Next
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            uploadfile_5()
            uploadfile_4()
            uploadfile_3()
            uploadfile_2()
            uploadfile_1()



            Call FileUpload(WRNo)

            'If FileUpload(WRNo) = True Then

            Using db = New DBFACDataContext
                    Dim ds = From f In db.vewWorkRequests
                             Where f.WRNo = WRNo And f.Seq = 11
                    If ds.Any Then
                        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "QuotationComplete()", True)
                        Exit Sub
                    End If
                End Using

                DtResult =
                    objCMT.LINQResultToDataTable(objCMT.db.sprWorkRequest(coll.AllKeys(0).Substring(0, 3).ToString, WRNo,
                                                                            reqCookiesLogin("OPID"),
                                                                          CType(ipcookie("IP_ADDRESS"), String)))

                For Each row As DataRow In DtResult.Rows
                    Try
                    If CInt(row.Item("Msg").ToString) = 0 Then
                        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "QuotationComplete()", True)
                    End If
                Catch ex As Exception
                        LogError(ex)
                        Dim message As String = $"Message: {ex.Message}\n\n"
                        message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
                        message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
                        message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

                        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
                    End Try

                Next row

            'Else
            '    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "QuotationComplete()", True)
            'End If


        Catch ex As Exception
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

        BindGrid()
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FunctionSearch()
    End Sub
End Class