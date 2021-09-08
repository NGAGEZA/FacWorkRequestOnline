Public Class FlowSetup
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        Call BindGrid()
        'End If
    End Sub

    Private Sub BindGrid()
        Using db As New DBFACDataContext
            Try

                gvflow.DataSource = From c In db.vewOperatorReqFlows
                    Select New With {c.GroupID, c.OPID, c.NameEng, c.ID}
                gvflow.DataBind()
                db.Dispose()
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

    Protected Sub FlowInsert()

        'Using db As New DBFACDataContext()
        '    Try


        '        Dim flowset As New OperatorReqFlow() With {
        '                .GroupID = tbreqopno.Value,
        '                .OPID = tbopno.Value,
        '                .UpdDate = DateTime.Now
        '                }
        '        db.OperatorReqFlows.InsertOnSubmit(flowset)
        '        db.SubmitChanges()
        '        db.Dispose()
        '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "InsertComplete()", True)
        '    Catch ex As Exception
        '        Dim message As String = String.Format("Message: {0}\n\n", ex.Message)
        '        message &= String.Format("StackTrace: {0}\n\n", ex.StackTrace.Replace(Environment.NewLine, String.Empty))
        '        message &= String.Format("Source: {0}\n\n", ex.Source.Replace(Environment.NewLine, String.Empty))
        '        message &= String.Format("TargetSite: {0}", ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty))

        '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
        '    Finally
        '        db.Dispose()
        '    End Try
        'End Using
        'BindGrid()
    End Sub


    Protected Sub gvflow_DataBound(sender As Object, e As EventArgs)
        Dim row = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)

        For i = 0 To gvflow.Columns.Count - 1
            Dim cell = New TableHeaderCell()
            Dim txtSearch = New TextBox()
            txtSearch.Attributes("placeholder") = gvflow.Columns(i).HeaderText
            txtSearch.CssClass = "search_textbox form-control input-sm"
            cell.Controls.Add(txtSearch)
            row.Controls.Add(cell)
        Next

        gvflow.HeaderRow.Parent.Controls.AddAt(1, row)
    End Sub

    Protected Sub GetDataGridview(sender As Object, e As EventArgs)
        'Dim clickedRow As GridViewRow = TryCast((CType(sender, LinkButton)).NamingContainer, GridViewRow)
        'OpidRole = clickedRow.Cells(1).Text.Trim()
        'SeqNo = clickedRow.Cells(5).Text.Trim()

        'Session("OPIDRole") = OPIDRole
        'Session("SeqNo") = SeqNO
        'Using db As New DBFACDataContext
        '    Try
        '        Dim getdata = From f In db.OperatorReqFlows
        '                      Where f.OPIDRole = OPIDRole And f.SeqNo = Seqno
        '                      Select f

        '        If getdata.Any() Then

        '            lnksave.Text = "Update"
        '            lnksave.CssClass = "btn btn-danger"
        '            lbhead1.Text = "Update"
        '            lbhead2.Text = "Update"

        '            For Each r In getdata

        '                'ddlflowtype.SelectedItem.Text = r.RoleType
        '                tbreqopno.Value = r.OPIDRole.Trim()
        '                tbopno.Value = r.OPIDFlow.Trim()
        '                tbname.Value = r.Name.Trim()
        '                tbemail.Value = r.EmailAddress.Trim()

        '            Next

        '        End If

        '    Catch ex As Exception
        '        Dim message As String = String.Format("Message: {0}\n\n", ex.Message)
        '        message &= String.Format("StackTrace: {0}\n\n", ex.StackTrace.Replace(Environment.NewLine, String.Empty))
        '        message &= String.Format("Source: {0}\n\n", ex.Source.Replace(Environment.NewLine, String.Empty))
        '        message &= String.Format("TargetSite: {0}", ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty))

        '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
        '    Finally
        '        db.Dispose()
        '    End Try
        'End Using
    End Sub

    Protected Sub Updateflow()
        'Dim getIdRole As String = Session("OPIDRole")
        'Dim getSeqno As String = Session("SeqNo")
        'Using db As New DBFACDataContext
        '    Try
        '        Dim q As OperatorReqFlows = (From u In db.OperatorRoleDetails Where u.OPIDRole = getIdRole And u.SeqNo = getSeqno Select u).FirstOrDefault()

        '        q.OPIDRole = tbreqopno.Value.Trim()
        '        q.OPIDFlow = tbopno.Value.Trim()
        '        q.Name = tbname.Value.Trim()
        '        q.EmailAddress = tbemail.Value.Trim()
        '        q.UpdDate = DateTime.Now
        '        db.SubmitChanges()
        '        db.Dispose()


        '        BindGrid()
        '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "UpdateComplete()", True)
        '    Catch ex As Exception
        '        Dim message As String = String.Format("Message: {0}\n\n", ex.Message)
        '        message &= String.Format("StackTrace: {0}\n\n", ex.StackTrace.Replace(Environment.NewLine, String.Empty))
        '        message &= String.Format("Source: {0}\n\n", ex.Source.Replace(Environment.NewLine, String.Empty))
        '        message &= String.Format("TargetSite: {0}", ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty))

        '        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)
        '    Finally
        '        db.Dispose()
        '    End Try
        'End Using
    End Sub

    Protected Sub Callfunction()
        Select Case lnksave.Text
            Case "Add"
                FlowInsert()
            Case "Update"
                Updateflow()
        End Select
    End Sub
End Class