Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Report
    Inherits Page

#Region "Page_Load"

    '===== Page_Load
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Call Init_Proc()
        End If
    End Sub

#End Region

#Region "PROCEDURE"

    '===== Setting Init
    Private Sub Init_Proc()
        Try

            'dt = objrun.ViewWorkRequest()
            'If dt.Rows.Count > 0 Then
            '    GridView1.DataSource = dt
            '    GridView1.DataBind()

            'End If

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('" & ex.ToString & "');", True)
        End Try
    End Sub

#End Region

#Region "EVENT"

    Protected Sub ImageButton10_Click(sender As Object, e As ImageClickEventArgs)

        Dim ImgPV = DirectCast(sender, ImageButton)
        Dim ImgWrNo As String = ImgPV.CommandArgument.ToString

        Dim cryRpt = New ReportDocument()
        Dim crtableLogoninfos = New TableLogOnInfos()
        Dim crtableLogoninfo = New TableLogOnInfo()
        Dim crConnectionInfo = New ConnectionInfo()
        'Dim CrTables As Tables

        cryRpt.Load(MapPath("Report\WorkRequest.rpt"))
        cryRpt.SetParameterValue("WRNO", ImgWrNo)

        'crConnectionInfo.ServerName = XmlControl.GetFieldValue("WorkRequest", "datasource")
        'crConnectionInfo.DatabaseName = XmlControl.GetFieldValue("WorkRequest", "catalog")
        'crConnectionInfo.UserID = XmlControl.GetFieldValue("WorkRequest", "user")
        'crConnectionInfo.Password = XmlControl.GetFieldValue("WorkRequest", "password")
        'CrTables = cryRpt.Database.Tables
        'For Each CrTable As CrystalDecisions.CrystalReports.Engine.Table In CrTables
        '    crtableLogoninfo = CrTable.LogOnInfo
        '    crtableLogoninfo.ConnectionInfo = crConnectionInfo
        '    CrTable.ApplyLogOnInfo(crtableLogoninfo)
        'Next

        cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True,
                                    ImgWrNo + "_" + Now.Date.ToString("ddMMyyyy"))
    End Sub

#End Region
End Class