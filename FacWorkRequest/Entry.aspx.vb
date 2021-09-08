Option Strict On
Option Explicit On

Imports System.Data.Entity
Imports System.Drawing
Imports System.IO
Imports System.Configuration
Imports System.Web.Configuration

Public Class Entry
    Inherits Page
    Dim ReadOnly _objCmt As New DbClass

    Dim ReadOnly _pathupload As String = ConfigurationManager.AppSettings("pathupload")
    Dim ReadOnly _pathdrawing As String = ConfigurationManager.AppSettings("pathdrawing")
    Dim ReadOnly _pathspec As String = ConfigurationManager.AppSettings("pathspec")
    Dim ReadOnly _pathother As String = ConfigurationManager.AppSettings("pathother")
    
#Region "Page_Load"
    '===== Page_Load
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Page.IsPostBack Then

                Call Init_Proc()
                Call UserInformation()

                'Getdata for edit
                If Not String.IsNullOrEmpty(Request.QueryString("UPD")) Then
                    If btnSave.Text <> "UPDATE" Then
                        'Getdata("")
                        btnRej.Visible = True

                        Dim arrayWrNo() As String = Split(Request.QueryString("UPD"), ",")
                        Getdata(arrayWrNo(0))

                        btnSave.CssClass = "btn btn-success btn-lg btn-block"
                        btnSave.Text = "UPDATE"
                    End If
                    Exit Sub
                End If

                'Getdata for view
                If Not String.IsNullOrEmpty(Request.QueryString("VEW")) Then
                    If btnSave.Text <> "BACK" Then

                        Dim arrayWrNo() As String = Split(Request.QueryString("VEW"), ",")
                        Getdata(arrayWrNo(0))

                        btnSave.CssClass = "btn btn-success btn-lg btn-block"
                        btnSave.Text = "BACK"
                    End If
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub UserInformation()
        Try
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")

            If reqCookiesLogin IsNot Nothing

                Using db = New DBFACDataContext()

                    'Dim ds = (From c In db.vewOperators Select c Where c.OPID = reqCookiesLogin("OPID").ToString).ToList()
                    Dim ds = db.vewOperators.Where(Function(x) x.OPID = reqCookiesLogin("OPID").ToString()).ToList()
                    If ds.Any()
                        For Each u In ds

                            tbreqname.Value = u.NickName
                            If tbreqname.Value <> ""
                                tbreqname.Disabled = True
                            End If

                            tbdivision.Value = u.Divsion
                            If tbdivision.Value <> ""
                                tbdivision.Disabled = True
                            End If

                            tbdept.Value = u.Department1
                            If tbdept.Value <> ""
                                tbdept.Disabled = True
                            End If

                            tbsection.Value = u.Section
                            If tbsection.Value <> ""
                                tbsection.Disabled = True
                            End If

                            tbprocess.Value = u.Organiztion
                            If tbprocess.Value <> ""
                                tbprocess.Disabled = True
                            End If

                        Next
                    End If
                End Using

                Else 
                    ClientScript.RegisterStartupScript([GetType](), "alert", "ValidateCookie()", True)


            End If
            
        Catch ex As Exception

            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript([GetType](), "alert", "alert(""" & message & """);", True)

        Finally

        End Try
    End Sub

    Protected Sub Callfunction()


        Select Case btnSave.Text
            Case "SAVE"
                ActAdd()
            Case "UPDATE"
                ActUpdate()
            Case "BACK"
                ActView()
        End Select

    End Sub

    Protected Sub CallfunctionCancel()

        ActJobCancel()

    End Sub

#End Region

#Region "PROCEDURE"
    '===== Setting Init
    Private Sub Init_Proc()
        Try


            'get Place Name information from DB
            drplace.DataSource = _objCmt.GetPlace
            drplace.DataTextField = "Name"
            drplace.DataValueField = "PlaceNbr"
            drplace.DataBind()
            drplace.Items.Insert(0, New ListItem("-Select Building-", "0"))

            Dim quodelidate As Date
            Dim expectdate As Date

            quodelidate = _objCmt.DateAddWeekDaysOnly(Now.Date, CInt(_objCmt.GetPurpose("CONG", "0001")))
            expectdate = _objCmt.DateAddWeekDaysOnly(Now.Date, CInt(_objCmt.GetPurpose("CONG", "0002")))

            tbquodelidate.Value = Format(quodelidate, "dd/MM/yyyy")
            tbexpectdate.Value = Format(expectdate, "dd/MM/yyyy")

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


    Protected Sub ddlplace_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drplace.SelectedIndexChanged

       

            Using db As New DBFACDataContext()
                Try
                    tbfloor.DataSource = db.vewFloors.Where(Function(x) x.PlaceNbr = CInt(drplace.SelectedValue)).
                        Select(Function(c) New With{c.NameFloor,c.FloorNbr})

                    tbfloor.DataTextField = "NameFloor"
                    tbfloor.DataValueField = "FloorNbr"
                    tbfloor.DataBind()
                    tbfloor.Items.Insert(0, New ListItem("-Select Floor-", "0"))
                                    



                    'tbfloor.DataSource = From p In db.vewFloors
                    '    Where p.PlaceNbr = CInt(drplace.SelectedValue)
                    '    Select New With {p.NameFloor, p.FloorNbr}
                    'tbfloor.DataTextField = "NameFloor"
                    'tbfloor.DataValueField = "FloorNbr"
                    'tbfloor.DataBind()
                    'tbfloor.Items.Insert(0, New ListItem("-Select Floor-", "0"))

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


    Private Sub ActAdd()
       

        If chk_job1.Checked = False And chk_job2.Checked = False And chk_job3.Checked = False Then
            ClientScript.RegisterStartupScript([GetType](), "alert", "checkjobtype()", True)

            'chk_group.Style = 
            Exit Sub
        End If

        If tbfloor.SelectedValue = "0"

            ClientScript.RegisterStartupScript([GetType](), "alert", "ValidateDropDown()", True)
            Exit Sub
        End If

       

        Try
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            Dim dtResult As New DataTable
            dtResult = _objCmt.LINQResultToDataTable(_objCmt.db.sprWorkRequestNew("ADD", GetChkBox, tbjobname.Value.Trim,
                                                                                CType(drplace.SelectedValue, Integer?),
                                                                                CType(tbfloor.SelectedValue, Integer?),
                                                                                tbprocess.Value.Trim,
                                                                                tbdivision.Value, tbdept.Value,
                                                                                tbsection.Value,
                                                                                tbtel.Value,
                                                                                _objCmt.GetCoverDate(
                                                                                    tbquodelidate.Value.ToString()),
                                                                                _objCmt.GetCoverDate(
                                                                                    tbexpectdate.Value.ToString()),
                                                                                tbdetailjob.Value,
                                                                                reqCookiesLogin("OPID").ToString,
                                                                                GetEmail(
                                                                                    reqCookiesLogin("OPID").ToString),
                                                                                ipcookie("IP_ADDRESS")))


            For Each row As DataRow In dtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then




                    If FileUpload(row.Item("RunningNo").ToString.Trim) = False Then
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "alert('Error');", True)
                    End If



                    'check file upload
                    If FileUpload1.HasFile
                        uploadfile_1(row.Item("RunningNo").ToString())
                    Else 
                        lblMessage1.Text = "* please upload file drawing"
                        lblMessage1.CssClass = "text-danger"

                        FileUpload1.BorderColor = Color.Red
                        'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "checkuploadfile()", True)
                        Exit Sub
                    End If

                    If FileUpload2.HasFile
                        uploadfile_2(row.Item("RunningNo").ToString())
                    End If
                    If FileUpload3.HasFile
                        uploadfile_3(row.Item("RunningNo").ToString())
                    End If




                    ClientScript.RegisterStartupScript([GetType](), "alert", "InsertComplete()", True)

                Else


                    ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script",
                                                            "alert('Error-Step-Insert row.Item(Msg).ToString <> 0'');",
                                                            True)
                End If
            Next row


        Catch ex As Exception

            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript([GetType](), "alert", "alert(""" & message & """);", True)

        Finally
            _objCmt.db.Dispose()
        End Try

    End Sub


    Private Sub ActJobCancel()


        Try

            Dim arrayWrNo() As String = Split(Request.QueryString("UPD"), ",")
            Dim wrNo = arrayWrNo(0)

            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")
            Dim dtResult As New DataTable

            dtResult = _objCmt.LINQResultToDataTable(_objCmt.db.sprWorkRequestUPDAndDEL("DEL", wrNo, 0,
                                                                                  "",
                                                                                  0, 0, "", "", "", "", "",
                                                                                  _objCmt.GetCoverDate(
                                                                                     Format(DateTime.Now, "dd/MM/yyyy")),
                                                                                  _objCmt.GetCoverDate(
                                                                                      Format(DateTime.Now, "dd/MM/yyyy")),
                                                                                  "",
                                                                                  reqCookiesLogin("OPID").ToString,
                                                                                  "",
                                                                                  ipcookie("IP_ADDRESS")))

            For Each row As DataRow In dtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then
                    ClientScript.RegisterStartupScript([GetType](), "alert", "CancelComplete()", True)
                Else
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script",
                                                            "alert('Error-Step-JobCancel row.Item(Msg).ToString <> 0'');",
                                                            True)
                End If
            Next row


        Catch ex As Exception

            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript([GetType](), "alert", "alert(""" & message & """);", True)

        Finally
            _objCmt.db.Dispose()
        End Try





    End Sub


    Private Sub ActUpdate()


        If chk_job1.Checked = False And chk_job2.Checked = False And chk_job3.Checked = False Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "checkjobtype()", True)
            Exit Sub
        End If



        If tbfloor.SelectedValue = "0"
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "ValidateDropDown()", True)
            Exit Sub
        End If

        'check file upload
        If FileUpload1.HasFile
            'uploadfile_1()
        End If
        If FileUpload2.HasFile
            'uploadfile_2()
        End If
        If FileUpload3.HasFile
            'uploadfile_3()
        End If


        Try
            Dim dtResult As New DataTable
            'Dim coll As NameValueCollection = Request.QueryString
            'Dim wrNo = ""
            'For Each key As String In coll.AllKeys
            '    wrNo = coll(key)
            'Next

            Dim arrayWrNo() As String = Split(Request.QueryString("UPD"), ",")
            Dim wrNo = arrayWrNo(0)


            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim ipcookie As HttpCookie = Request.Cookies("ipcookie")

            dtResult = _objCmt.LINQResultToDataTable(_objCmt.db.sprWorkRequestUPDAndDEL("UPD", wrNo,
                                                                                      GetChkBox, tbjobname.Value.Trim,
                                                                                      CType(drplace.SelectedValue,
                                                                                            Integer?),
                                                                                      CType(tbfloor.SelectedValue,
                                                                                            Integer?),
                                                                                      tbprocess.Value.Trim,
                                                                                      tbdivision.Value, tbdept.Value,
                                                                                      tbsection.Value,
                                                                                      tbtel.Value,
                                                                                      _objCmt.GetCoverDate(
                                                                                          tbquodelidate.Value.ToString()),
                                                                                      _objCmt.GetCoverDate(
                                                                                          tbexpectdate.Value.ToString()),
                                                                                      tbdetailjob.Value,
                                                                                      reqCookiesLogin("OPID"),
                                                                                      GetEmail(reqCookiesLogin("OPID")),
                                                                                      ipcookie("IP_ADDRESS")))


            For Each row As DataRow In dtResult.Rows
                If CInt(row.Item("Msg").ToString) = 0 Then

                    'add function upload for update
                    FileUploadUpdate(wrNo)


                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "UpdateComplete()", True)
                    Response.Redirect(arrayWrNo(1))


                Else
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script",
                                                            "alert('Error-Step-Update row.Item(Msg).ToString <> 0');",
                                                            True)
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

    Private Sub ActView()

        Dim arrayWrNo() As String = Split(Request.QueryString("VEW"), ",")
        Response.Redirect(arrayWrNo(1))
    End Sub

    '===== btnDel_Click
    Private Shared Function GetFiles(sourceFolder As String, filter As String, _
                             searchOption As SearchOption) As String()
        ' ArrayList will hold all file names
        Dim alFiles = New ArrayList()
 
        ' Create an array of filter string
        Dim multipleFilters() As String = filter.Split(CType("|", Char))
 
        ' for each filter find mathing file names
        For Each fileFilter As String In multipleFilters
            ' add found file names to array list
            alFiles.AddRange(Directory.GetFiles(sourceFolder, fileFilter, searchOption))
        Next
 
        ' returns string array of relevant file names
        Return CType(alFiles.ToArray(Type.GetType("System.String")), String())
    End Function
    'Getdata for preview
    Private Sub Getdata(getWrNo As String)

        Dim wrNo = ""

        If GetWrNo = "" Then
            Dim coll As NameValueCollection = Request.QueryString
            For Each key As String In coll.AllKeys
                wrNo = coll(key)
            Next
        Else
            wrNo = GetWrNo
        End If

        lbwrno_detail.Text = wrNo

        Using db As New DBFACDataContext()
            Try
                'select condition

                Dim getdata = db.vewWorkRequests.Where(Function(x) x.WRNo = wrNo).ToList()
                'Dim getdata = From d In db.vewWorkRequests
                '        Where d.WRNo = wrNo
                '        Select d

                If getdata.Count <> 0 Then

                    For Each p In getdata

                        tbjobname.Value = p.JobName.Trim()

                        Select Case p.JobType

                            Case 1
                                chk_job1.Checked = True
                            Case 2
                                chk_job2.Checked = True
                            Case 3
                                chk_job3.Checked = True

                        End Select

                        Dim quotationDeliveryDate = CDate(p.QuotationDeliveryDate.ToString())
                        Dim expectedDate = CDate(p.ExpectedDate.ToString())

                        drplace.SelectedValue = p.PlaceNbr.ToString
                        tbprocess.Value = p.Process
                        tbdivision.Value = p.Division
                        tbdept.Value = p.Dept
                        tbsection.Value = p.Section
                        tbtel.Value = p.Tel
                        tbexpectdate.Value = expectedDate.ToString("dd/MM/yyyy")
                        tbquodelidate.Value = quotationDeliveryDate.ToString("dd/MM/yyyy")
                        tbdetailjob.Value = p.JobDetail
                        tbreqname.Value = p.NickName


                        tbfloor.DataSource = From s In db.vewFloors
                            Where s.PlaceNbr = CInt(drplace.SelectedValue)
                            Select New With {s.NameFloor, s.FloorNbr}
                        tbfloor.DataTextField = "NameFloor"
                        tbfloor.DataValueField = "FloorNbr"
                        tbfloor.DataBind()
                        tbfloor.Items.Insert(0, New ListItem("-Select Floor-", "0"))

                        tbfloor.SelectedValue = p.FloorNbr.ToString

                    Next

                    Dim dirpathdrawing As String = _pathupload +  wrNo.Trim() + "\" + _pathdrawing + "\"

                    Dim dirpathspec As String = _pathupload +  wrNo.Trim() + "\" + _pathspec + "\"

                    Dim dirpathother As String = _pathupload +  wrNo.Trim() + "\" + _pathother + "\"



                    


                    Dim sFilesdrawing() As String = GetFiles(dirpathdrawing, _
                                                      "*.pdf|*.jpg|*.png", _
                                                      SearchOption.AllDirectories)

                    Dim sFilesspec() As String = GetFiles(dirpathspec, _
                                                             "*.pdf|*.jpg|*.png", _
                                                             SearchOption.AllDirectories)

                    Dim sFilesother() As String = GetFiles(dirpathother, _
                                                             "*.pdf|*.jpg|*.png", _
                                                             SearchOption.AllDirectories)

                    If sFilesdrawing.Length <> 0 Then
                        lbnamefile1.Visible = True
                        lnkdownload1.Visible = True
                    End If

                    If sFilesspec.Length <> 0 Then
                        lbnamefile2.Visible = True
                        lnkdownload2.Visible = True
                    End If

                    If sFilesother.Length <> 0 Then
                        lbnamefile3.Visible = True
                        lnkdownload3.Visible = True
                    End If


                    'Dim filedownload = db.FileAttaches.Where(Function(x) x.WRNo = wrNo And x.Grp = "REQ").ToList()

                    ''Dim filedownload = From f in db.FileAttaches
                    ''        where f.WRNo = wrNo And
                    ''              f.Grp = "REQ"
                    ''        Select f

                    'If filedownload.Count <> 0 Then
                    '    For Each o In filedownload
                    '        Select Case o.Seq
                    '            'file drawing
                    '            Case 1
                    '                lbnamefile1.Visible = True
                    '                lnkdownload1.Visible = True
                    '            Case 2
                    '                lbnamefile2.Visible = True
                    '                lnkdownload2.Visible = True
                    '            Case 3
                    '                lbnamefile3.Visible = True
                    '                lnkdownload3.Visible = True

                    '        End Select
                    '    Next
                    'End If


                Else

                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Nodata()", True)

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
    '--upload to folder drawing
    Private Sub uploadfile_1(rnno As string)
        Dim validateColor As New Color
        validateColor = ColorTranslator.fromHTML("#a94442") 'Red color
       ' Const pathupload As String = "\\10.29.1.90\facupload\"
        Try


            If FileUpload1.HasFile Then



                Dim fileExtension As String = Path.GetExtension(FileUpload1.FileName)
                


                If _
                    fileExtension.ToLower() <> ".jpg" AndAlso fileExtension.ToLower() <> ".pdf" AndAlso
                    fileExtension.ToLower() <> ".png" AndAlso fileExtension.ToLower() <> ".jpeg" Then
                    lblMessage1.Text = "Only PDF,PNG,JPG,JPEG file allowed"
                    lblMessage1.CssClass = "h6"
                    lblMessage1.ForeColor = validateColor
                Else
                    Dim fileSize As Integer = FileUpload1.PostedFile.ContentLength

                    If fileSize > 5242880 Then
                        lblMessage1.Text = "Maximum size 5(MB) exceeded "
                        lblMessage1.ForeColor = validateColor
                    Else

                        'directory drawing
                        Dim dirInfo As New DirectoryInfo(_pathupload +  rnno.Trim() + "\" + _pathdrawing)

                        If Not dirInfo.Exists Then
                            dirInfo.Create()
                        End If

                        FileUpload1.SaveAs(dirInfo.ToString() +"\"+ FileUpload1.FileName)
                        lblMessage1.Text = "File Uploaded successfully"
                        lblMessage1.ForeColor = Color.Green

                        'Dim upcookie1 = New HttpCookie("upcookie1")
                        'upcookie1.Expires= Date.Now.AddDays(-1)
                        'upcookie1("namepath_0001") = (Server.MapPath("~/Upload/" & gid.ToString() & FileUpload1.FileName))
                        'upcookie1("nametype_0001") = fileExtension.ToLower.ToString()
                        'upcookie1("namefile_0001") = FileUpload1.FileName
                        ''upcookie1.Expires= DateTime.Now.AddHours(2)
                        'Response.Cookies.Add(upcookie1)


                    End If
                End If
            Else
                lblMessage1.Text = "File not uploaded"
                lblMessage1.ForeColor = validateColor
            End If
        Catch ex As Exception
            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript([GetType](), "alert", "alert(""" & message & """);", True)
        End Try

    End Sub

    '--upload to folder spec
    Private Sub uploadfile_2(rnno As string)
        Dim validateColor As New Color
        validateColor = ColorTranslator.fromHTML("#a94442") 'Red color
        
        Try


            If FileUpload2.HasFile Then
                Dim fileExtension As String = Path.GetExtension(FileUpload2.FileName)
                Dim gid As Guid
                gid = Guid.NewGuid()


                If _
                    fileExtension.ToLower() <> ".jpg" AndAlso fileExtension.ToLower() <> ".pdf" AndAlso
                    fileExtension.ToLower() <> ".png" AndAlso fileExtension.ToLower() <> ".jpeg" Then
                    lblMessage2.Text = "Only PDF,PNG,JPG,JPEG file allowed"
                    lblMessage2.CssClass = "h6"
                    lblMessage2.ForeColor = validateColor
                Else
                    Dim fileSize As Integer = FileUpload2.PostedFile.ContentLength

                    If fileSize > 5242880 Then
                        lblMessage2.Text = "Maximum size 5(MB) exceeded "
                        lblMessage2.ForeColor = validateColor
                    Else

                        'directory Spec
                        Dim dirInfo As New DirectoryInfo(_pathupload +  rnno.Trim() + "\" + _pathspec)

                        If Not dirInfo.Exists Then
                            dirInfo.Create()
                        End If

                        FileUpload2.SaveAs(dirInfo.ToString() +"\"+ FileUpload2.FileName)
                        lblMessage2.Text = "File Uploaded successfully"
                        lblMessage2.ForeColor = Color.Green

                        'Dim upcookie2 = New HttpCookie("upcookie2")
                        'upcookie2.Expires= Date.Now.AddDays(-1)
                        'upcookie2("namepath_0002") =
                        '    (Server.MapPath("~/Upload/" & gid.ToString() & FileUpload2.FileName))
                        'upcookie2("nametype_0002") = fileExtension.ToLower.ToString()
                        'upcookie2("namefile_0002") = FileUpload2.FileName
                        ''upcookie2.Expires = DateTime.Now.AddHours(2)
                        'Response.Cookies.Add(upcookie2)

                        'Session("namepath_0002") = (Server.MapPath("~/Upload/" & gid.ToString() & FileUpload2.FileName))
                        'Session("nametype_0002") = fileExtension.ToLower.ToString()
                        'Session("namefile_0002") = FileUpload2.FileName

                    End If
                End If
            Else
                lblMessage2.Text = "File not uploaded"
                lblMessage2.ForeColor = validateColor
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
    '--upload to folder other
    Private Sub uploadfile_3(rnno As string)
        Dim validateColor As New Color
        validateColor = ColorTranslator.fromHTML("#a94442") 'Red color
        Const pathupload As String = "\\10.29.1.90\facupload\"
        Try


            If FileUpload3.HasFile Then
                Dim fileExtension As String = Path.GetExtension(FileUpload3.FileName)
                Dim gid As Guid
                gid = Guid.NewGuid()


                If _
                    fileExtension.ToLower() <> ".jpg" AndAlso fileExtension.ToLower() <> ".pdf" AndAlso
                    fileExtension.ToLower() <> ".png" AndAlso fileExtension.ToLower() <> ".jpeg" Then
                    lblMessage3.Text = "Only PDF,PNG,JPG,JPEG file allowed"
                    lblMessage3.CssClass = "h6"
                    lblMessage3.ForeColor = validateColor
                Else
                    Dim fileSize As Integer = FileUpload3.PostedFile.ContentLength

                    If fileSize > 5242880 Then
                        lblMessage3.Text = "Maximum size 5(MB) exceeded "
                        lblMessage3.ForeColor = validateColor
                    Else

                        'directory Spec
                        Dim dirInfo As New DirectoryInfo(pathupload +  rnno.Trim() + "\" + _pathother)

                        If Not dirInfo.Exists Then
                            dirInfo.Create()
                        End If

                        FileUpload3.SaveAs(dirInfo.ToString() +"\"+ FileUpload3.FileName)
                        lblMessage3.Text = "File Uploaded successfully"
                        lblMessage3.ForeColor = Color.Green


                        'Dim upcookie3 = New HttpCookie("upcookie3")
                        'upcookie3.Expires= Date.Now.AddDays(-1)
                        'upcookie3("namepath_0003") =(Server.MapPath("~/Upload/" & gid.ToString() & FileUpload3.FileName))
                        'upcookie3("nametype_0003") = fileExtension.ToLower.ToString()
                        'upcookie3("namefile_0003") = FileUpload3.FileName
                        
                        'Response.Cookies.Add(upcookie3)


                    End If
                End If
            Else
                lblMessage3.Text = "File not uploaded"
                lblMessage3.ForeColor = validateColor
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
    Private Shared Function GetContentType(fileExtension As String) As String
        If String.IsNullOrEmpty(fileExtension) Then Return String.Empty
        Dim contentType As String = String.Empty

        Select Case fileExtension
            Case ".htm", ".html"
                contentType = "text/HTML"
            Case ".txt"
                contentType = "text/plain"
            Case ".doc", ".rtf", ".docx"
                contentType = "Application/msword"
            Case ".xls", ".xlsx"
                contentType = "Application/x-msexcel"
            Case ".jpg", ".jpeg"
                contentType = "image/jpeg"
            Case ".gif"
                contentType = "image/GIF"
            Case ".pdf"
                contentType = "application/pdf"
        End Select

        Return contentType
    End Function
    Private Function GetFile() As Stream
        Dim fileStream As FileStream = New FileStream(Server.MapPath("~/Files/Lincoln.txt"), FileMode.Open, FileAccess.Read)
        Return fileStream
    End Function

    Protected Sub DownloadFile1()

        Try
            'Mcno = Request.QueryString("emcno")


            Dim coll As NameValueCollection = Request.QueryString
            Dim wrNo = ""
            For Each key As String In coll.AllKeys
                wrNo = coll(key)
            Next
            Dim arrayWrNo() As String = Split(wrNo, ",")


            Dim dirpathdrawing As String = _pathupload +  arrayWrNo(0) + "\" + _pathdrawing + "\"

           ' Dim fileName As String = "Lincoln.txt"

            Dim sFilesdrawing() As String = GetFiles(dirpathdrawing, _
                                                     "*.pdf|*.jpg|*.png", _
                                                     SearchOption.AllDirectories)
            Dim fileName As String
            For Each f As String In sFilesdrawing
                fileName = f.ToString()
            Next

            
            Dim fi = New FileInfo(fileName)
            Dim justFileName As String = fi.Name
            Dim fileExtension As String = justFileName
            'Response.Clear()
            'Response.BufferOutput = True
            'Response.ContentType = GetContentType(fileExtension)
            'Response.AppendHeader("Content-Disposition", "attachment; filename=" & justFileName)
            'Const bufferLength As Integer = 10000
            'Dim buffer As Byte() = New Byte(9999) {}
            'Dim length As Integer = 0
            'Dim download As Stream = Nothing

          
            '    download = GetFile()

            '    Do

            '        If Response.IsClientConnected Then
            '            length = download.Read(buffer, 0, bufferLength)
            '            Response.OutputStream.Write(buffer, 0, length)
            '            buffer = New Byte(9999) {}
            '        Else
            '            length = -1
            '        End If
            '    Loop While length > 0

            '    Response.Flush()
            '    Response.[End]()
           



            Response.ContentType = GetContentType(fileExtension)
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & justFileName)
            Response.TransmitFile(dirpathdrawing & justFileName)
            Response.[End]()

            'Using db As New DBFACDataContext

            '    Dim file = db.FileAttaches.FirstOrDefault(Function(f) f.WRNo = (arrayWrNo(0)) And f.Seq = 1)

            '    If file IsNot Nothing Then
            '        Response.ContentType = file.Extension
            '        Response.AddHeader("content-disposition",
            '                           "attachment; filename=" & file.WRNo & "_Drawing" & file.Extension)
            '        Response.BinaryWrite(file.FileAttach)
            '        Response.Flush()
            '        Response.[End]()
            '    End If
            'End Using
        Catch unusedThreadAbortException As Threading.ThreadAbortException
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

    Protected Sub DownloadFile2()

        Try
            'Mcno = Request.QueryString("emcno")
            Dim coll As NameValueCollection = Request.QueryString
            Dim wrNo = ""
            For Each key As String In coll.AllKeys
                wrNo = coll(key)
            Next
            Dim arrayWrNo() As String = Split(wrNo, ",")
            Using db As New DBFACDataContext


                Dim file = db.FileAttaches.FirstOrDefault(Function(f) f.WRNo = (arrayWrNo(0)) And f.Seq = 2)

                If file IsNot Nothing Then
                    Response.ContentType = file.Extension
                    Response.AddHeader("content-disposition",
                                       "attachment; filename=" & file.WRNo & "_Spec" & file.Extension)
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

    Protected Sub DownloadFile3()

        Try
            'Mcno = Request.QueryString("emcno")
            Dim coll As NameValueCollection = Request.QueryString
            Dim wrNo = ""
            For Each key As String In coll.AllKeys
                wrNo = coll(key)
            Next
            Dim arrayWrNo() As String = Split(wrNo, ",")
            Using db As New DBFACDataContext


                Dim file = db.FileAttaches.FirstOrDefault(Function(f) f.WRNo = (arrayWrNo(0)) And f.Seq = 3)

                If file IsNot Nothing Then
                    Response.ContentType = file.Extension
                    Response.AddHeader("content-disposition",
                                       "attachment; filename=" & file.WRNo & "_Other" & file.Extension)
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

#End Region

#Region "Function"


    Private Function GetEmail(opid As String) As String
        Dim email As String = String.Empty
        Dim ds As New List(Of vewOperator)
        ds = _objCmt.GetOperator(opid)
        If ds.Any() Then
            email = ds(0).Email.ToString.Trim
        End If
        Return email
    End Function

    Private Function GetChkBox() As Integer
        If chk_job1.Checked = True Then
            Return 1
        ElseIf chk_job2.Checked = True Then
            Return 2
        ElseIf chk_job3.Checked = True Then
            Return 3
        End If
        Return GetChkBox()
    End Function

    Function FileUpload(runningNo As String) As Boolean

        Try

            Dim path00001 As String
            Dim path00002 As String
            Dim path00003 As String

            Dim type00001 As String
            Dim type00002 As String
            Dim type00003 As String

            Dim file00001 As String
            Dim file00002 As String
            Dim file00003 As String


            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")
            Dim reqCookies1 As HttpCookie = Request.Cookies("upcookie1")

            If reqCookies1 IsNot Nothing Then
                path00001 = reqCookies1("namepath_0001").ToString()
                type00001 = reqCookies1("nametype_0001").ToString()
                file00001 = reqCookies1("namefile_0001").ToString()

                _objCmt.LINQResultToDataTable(_objCmt.db.sprFileAttach("REQ", RunningNo, 1, ConverFileUpLoad(path00001),
                                                                     file00001,
                                                                     type00001, "", DateTime.Now, 0,
                                                                     reqCookiesLogin("OPID").ToString))

            End If

            Dim reqCookies2 As HttpCookie = Request.Cookies("upcookie2")

            If reqCookies2 IsNot Nothing Then
                path00002 = reqCookies2("namepath_0002").ToString()
                type00002 = reqCookies2("nametype_0002").ToString()
                file00002 = reqCookies2("namefile_0002").ToString()

                _objCmt.LINQResultToDataTable(_objCmt.db.sprFileAttach("REQ", RunningNo, 2, ConverFileUpLoad(path00002),
                                                                     file00002,
                                                                     type00002, "", DateTime.Now, 0,
                                                                     reqCookiesLogin("OPID").ToString))

            End If

            Dim reqCookies3 As HttpCookie = Request.Cookies("upcookie3")

            If reqCookies3 IsNot Nothing Then
                path00003 = reqCookies3("namepath_0003").ToString()
                type00003 = reqCookies3("nametype_0003").ToString()
                file00003 = reqCookies3("namefile_0003").ToString()

                _objCmt.LINQResultToDataTable(_objCmt.db.sprFileAttach("REQ", RunningNo, 3, ConverFileUpLoad(path00003),
                                                                     file00003,
                                                                     type00003, "", DateTime.Now, 0,
                                                                     reqCookiesLogin("OPID").ToString))

            End If


            Return True

        Catch ex As Exception
            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

            Return False

        Finally

        End Try
    End Function

    Private Sub FileUploadUpdate(wrno As String)

        Try

            Dim path00001 As String
            Dim path00002 As String
            Dim path00003 As String

            Dim type00001 As String
            Dim type00002 As String
            Dim type00003 As String

            Dim file00001 As String
            Dim file00002 As String
            Dim file00003 As String


            Dim reqCookies1 As HttpCookie = Request.Cookies("upcookie1")
            Dim reqCookiesLogin As HttpCookie = Request.Cookies("logincookie")

            If reqCookies1 IsNot Nothing Then
                path00001 = reqCookies1("namepath_0001").ToString()
                type00001 = reqCookies1("nametype_0001").ToString()
                file00001 = reqCookies1("namefile_0001").ToString()


                Using db As New DBFACDataContext
                    Try


                        Dim ul1 As FileAttach = db.FileAttaches.FirstOrDefault(Function (x) x.WRNo = wrno And x.Seq = 1) 
                        If ul1 IsNot Nothing Then
                            ul1.FileAttach = ConverFileUpLoad(path00001)
                            ul1.FileName = file00001
                            ul1.Extension = type00001
                            ul1.UpdDate = DateTime.Now
                            ul1.OPID = reqCookiesLogin("OPID").ToString()

                            db.SubmitChanges()
                            db.Dispose()
                        else

                            Dim grp =
                                    db.FileAttaches.Where(Function(p) p.WRNo Is wrno).[Select](Function(p) p.Grp).ToList()


                            Dim i = New FileAttach()
                            i.WRNo = wrno
                            i.Seq = 1
                            i.Grp = grp.Item(0).ToString()
                            i.FileAttach = ConverFileUpLoad(path00001)
                            i.FileName = file00001
                            i.Extension = type00001
                            i.SupplierName = ""
                            i.QuotationAmt = 0
                            i.OPID = reqCookiesLogin("OPID").ToString()
                            i.UpdDate = DateTime.Now
                            db.FileAttaches.InsertOnSubmit(i)
                            db.SubmitChanges()
                        End If


                    Catch ex As Exception

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
                'DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprFileAttach("REQ", RunningNo, 1, ConverFileUpLoad(path00001), file00001,
                '                                                                type00001, "", DateTime.Now, 0, reqCookiesLogin("OPID").ToString))

            End If

            Dim reqCookies2 As HttpCookie = Request.Cookies("upcookie2")

            If reqCookies2 IsNot Nothing Then
                path00002 = reqCookies2("namepath_0002").ToString()
                type00002 = reqCookies2("nametype_0002").ToString()
                file00002 = reqCookies2("namefile_0002").ToString()

                Using db As New DBFACDataContext
                    Try


                        Dim ul2 As FileAttach = db.FileAttaches.FirstOrDefault(Function(x) x.WRNo = wrno And x.Seq = 2)
                               

                        If ul2 IsNot Nothing Then
                            ul2.FileAttach = ConverFileUpLoad(path00002)
                            ul2.FileName = file00002
                            ul2.Extension = type00002
                            ul2.UpdDate = DateTime.Now
                            ul2.OPID = reqCookiesLogin("OPID").ToString()

                            db.SubmitChanges()
                            db.Dispose()
                        Else


                            Dim grp = db.FileAttaches.Where(Function(p) p.WRNo Is wrno).[Select](Function(p) p.Grp).ToList()


                            Dim i = New FileAttach()
                            i.WRNo = wrno
                            i.Seq = 2
                            i.Grp = grp.Item(0).ToString()
                            i.FileAttach = ConverFileUpLoad(path00002)
                            i.FileName = file00002
                            i.Extension = type00002
                            i.SupplierName = ""
                            i.QuotationAmt = 0
                            i.OPID = reqCookiesLogin("OPID").ToString()
                            i.UpdDate = DateTime.Now
                            db.FileAttaches.InsertOnSubmit(i)
                            db.SubmitChanges()

                        End If


                    Catch ex As Exception

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

            End If

            Dim reqCookies3 As HttpCookie = Request.Cookies("upcookie3")

            If reqCookies3 IsNot Nothing Then
                path00003 = reqCookies3("namepath_0003").ToString()
                type00003 = reqCookies3("nametype_0003").ToString()
                file00003 = reqCookies3("namefile_0003").ToString()

                Using db As New DBFACDataContext
                    Try


                        Dim ul3 As FileAttach = db.FileAttaches.FirstOrDefault(Function(x) x.WRNo = wrno And x.Seq = 3)
                                
                        If ul3 IsNot Nothing Then
                            ul3.FileAttach = ConverFileUpLoad(path00003)
                            ul3.FileName = file00003
                            ul3.Extension = type00003
                            ul3.UpdDate = DateTime.Now
                            ul3.OPID = reqCookiesLogin("OPID").ToString()

                            db.SubmitChanges()
                            db.Dispose()
                        else
                            Dim grp = db.FileAttaches.Where(Function(p) p.WRNo Is wrno).[Select](Function(p) p.Grp).ToList()


                            Dim i = New FileAttach()
                            i.WRNo = wrno
                            i.Seq = 3
                            i.Grp = grp.Item(0).ToString()
                            i.FileAttach = ConverFileUpLoad(path00003)
                            i.FileName = file00003
                            i.Extension = type00003
                            i.SupplierName = ""
                            i.QuotationAmt = 0
                            i.OPID = reqCookiesLogin("OPID").ToString()
                            i.UpdDate = DateTime.Now
                            db.FileAttaches.InsertOnSubmit(i)
                            db.SubmitChanges()
                        End If


                    Catch ex As Exception

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
            End If


            Return

        Catch ex As Exception
            'Write Error to Log.txt
            LogError(ex)


            Dim message As String = $"Message: {ex.Message}\n\n"
            message &= $"StackTrace: {ex.StackTrace.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"Source: {ex.Source.Replace(Environment.NewLine, String.Empty)}\n\n"
            message &= $"TargetSite: {ex.TargetSite.ToString().Replace(Environment.NewLine, String.Empty)}"

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert(""" & message & """);", True)

            Return

        Finally

        End Try
    End Sub
    'Private Function GetGrpFileAttach(ByVal wrno As String) As List(Of wrno)
    '    Using db As FileAttach = New FileAttach()
    '        Return (From c In db.FileAttach Where c. Is customerID Select c).ToList()
    '    End Using
    'End Function
    Private Shared Function ConverFileUpLoad(nameupload As String) As Byte()
        Dim filePathupload As String
        Dim fsupload As FileStream
        Dim brupload As BinaryReader
        Dim bytesupload As Byte()

        If nameupload IsNot Nothing Then
            filePathupload = nameupload
            fsupload = New FileStream(filePathupload, FileMode.Open, FileAccess.Read)
            brupload = New BinaryReader(fsupload)
            bytesupload = brupload.ReadBytes(Convert.ToInt32(fsupload.Length))
            brupload.Close()
            fsupload.Close()
        End If

        Return bytesupload
    End Function

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