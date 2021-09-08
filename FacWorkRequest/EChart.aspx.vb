Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EChart
    Inherits Page
    Dim ReadOnly objCMT As New DbClass

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

                    Try

                        Dim ArrayStart() As String = Split(Request.QueryString("dtfrm"), "/")
                        Dim ArrayEnd() As String = Split(Request.QueryString("dtto"), "/")

                        Dim StartMonth = CInt(ArrayStart(0))
                        Dim StartYear = CInt(ArrayStart(1))
                        Dim EndMonth = CInt(ArrayEnd(0))
                        Dim EndYear = CInt(ArrayEnd(1))

                        Dim cryRpt = New ReportDocument()
                        Dim crtableLogoninfo = New TableLogOnInfo()
                        Dim crConnectionInfo = New ConnectionInfo()
                        Dim CrTables As Tables

                        cryRpt.Load(MapPath("Report\RptMonthWorkRequest.rpt"))
                        cryRpt.SetParameterValue("StartMonth", StartMonth)
                        cryRpt.SetParameterValue("StartYear", StartYear)
                        cryRpt.SetParameterValue("EndMonth", EndMonth)
                        cryRpt.SetParameterValue("EndYear", EndYear)

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
                                                    "WorkRequestReport_" + Now.Date.ToString("ddMMyyyy"))

                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script",
                                                                "alert('" & ex.ToString & "');", True)
                    End Try


                End If
            End If
        End If
    End Sub
End Class