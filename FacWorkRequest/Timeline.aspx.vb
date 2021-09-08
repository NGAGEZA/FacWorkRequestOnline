'Option Strict On
Option Explicit On

Imports System.Drawing

Public Class Timeline
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Page.IsPostBack Then
                ViewState("Filter") = "0"
                Timeline()
            End If
        End If
        'If Not IsPostBack Then
        '    ViewState("Filter") = "0"
        '    Timeline()
        'End If
    End Sub

    Protected Sub Timeline()
        Using db = New DBFACDataContext()
            Try
                if ViewState("Filter").ToString() <> "0"

                    Dim ds = From f In db.vewWorkRequestStatus 
                            Order By f.UpdDate Descending
                            Select f
                            Where f.Seq = CInt(ViewState("Filter").ToString())
                    If ds.Any() Then
                        gvtimeline.DataSource = ds
                        gvtimeline.DataBind()
                        BindingStatusList
                    else
                        gvtimeline.DataSource = ds
                        gvtimeline.DataBind()
                    End If


                Else

                    Dim ds = From f In db.vewWorkRequestStatus 
                            Order By f.UpdDate Descending
                            Select f
                            Where f.Seq <> 20 And f.Seq <> 9999
                    If ds.Any() Then
                        gvtimeline.DataSource = ds
                        gvtimeline.DataBind()
                        BindingStatusList
                    else
                        gvtimeline.DataSource = ds
                        gvtimeline.DataBind()
                    End If

                End If


            Catch ex As Exception

                Dim message As String = String.Format("Message: {0}\n\n", ex.Message)
                message &= String.Format("StackTrace: {0}\n\n", ex.StackTrace.Replace(Environment.NewLine, String.Empty))
                message &= String.Format("Source: {0}\n\n", ex.Source.Replace(Environment.NewLine, String.Empty))
                message &= String.Format("TargetSite: {0}",
                                         ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty))

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
            Finally
                db.Dispose()

            End Try
        End Using
    End Sub

    Protected Sub Timer1_Tick()

        Timeline()
    End Sub

    Private Sub BindingStatusList()
        Try
            Dim ddlstatus = DirectCast(gvtimeline.HeaderRow.FindControl("ddlstatus"), DropDownList)
            Using db As New DBFACDataContext()
                ddlstatus.DataSource = From s In db.vewWorkRequestStatus
                    Where s.Seq <> 20 And
                          s.Seq <> 9999
                    Group s By
                        s.Seq,
                            s.Status
                        Into g = Group
                    Order By
                        Seq,
                        Status
                    Select
                        Seq,
                            Status

                ddlstatus.DataTextField = "Status"
                ddlstatus.DataValueField = "Seq"
                ddlstatus.DataBind()
                ddlstatus.Items.Insert(0, New ListItem("Select ALL", "0"))

                ddlstatus.Items.FindByValue(ViewState("Filter").ToString()).Selected = True
            End Using
        Catch ex As Exception

            Dim message As String = String.Format("Message: {0}\n\n", ex.Message)
            message &= String.Format("StackTrace: {0}\n\n", ex.StackTrace.Replace(Environment.NewLine, String.Empty))
            message &= String.Format("Source: {0}\n\n", ex.Source.Replace(Environment.NewLine, String.Empty))
            message &= String.Format("TargetSite: {0}",
                                     ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty))

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

        Finally

        End Try
    End Sub

    Protected Sub StatusChanged(sender As Object, e As EventArgs)

        Dim ddlstatus = DirectCast(sender, DropDownList)

        ViewState("Filter") = ddlstatus.SelectedValue

        Timeline()
    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)


        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Seq"))
            Dim JobName As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "JobName"))
            Dim Vendor As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SupplierName"))

            Select Case JobName.Length
                Case > 20

                    e.Row.Cells(1).Text = Mid(JobName, 1, 20)

            End Select

            Dim finalString As string = Replace(Vendor, "@", "<br>")


            e.Row.Cells(3).Text = finalString


            'Select Case Vendor.Contains("@")
            '    Case 
            'End Select


            Select Case Status
                'New WorkRequest 
                Case "5"
                    e.Row.Cells(4).CssClass = ""
                    e.Row.ForeColor = Color.MediumVioletRed

                    'Area Survey
                Case "6"
                    e.Row.Cells(4).CssClass = "success"
                    e.Row.ForeColor = Color.SaddleBrown

                    'Wait Quotation
                Case "7"
                    e.Row.Cells(4).CssClass = "default"
                    e.Row.ForeColor = Color.Black

                    'Wait Requester Approve
                Case "8"
                    e.Row.Cells(4).CssClass = "warning"
                    e.Row.ForeColor = Color.Orange

                    'Approve & Wait PR
                Case "9"
                    e.Row.Cells(4).CssClass = "info"
                    e.Row.ForeColor = Color.DeepSkyBlue

                    'PR Open & Wait PO
                Case "10"
                    e.Row.Cells(4).CssClass = "danger"
                    e.Row.ForeColor = Color.Red

                    'PR & PO Open
                Case "11"
                    e.Row.ForeColor = Color.Salmon

                    'Job On Working
                Case "12"
                    e.Row.ForeColor = Color.Blue

                    'Wait Requester Inspection
                Case "14"
                    e.Row.ForeColor = Color.Purple

                    'Wait Facility Inspection
                Case "16"
                    e.Row.ForeColor = Color.DeepPink

                    'Wait Invoice
                Case "18"
                    e.Row.ForeColor = Color.Green
            End Select
            ' If Status = "Wait Invoice" Then
            '     e.Row.Attributes("style") = "background-color: #28b779"
            'End If
        End If
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)

        gvtimeline.PageIndex = e.NewPageIndex

        Timeline
    End Sub
End Class