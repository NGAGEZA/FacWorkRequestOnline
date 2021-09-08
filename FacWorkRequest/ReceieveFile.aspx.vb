Imports System.IO
Imports iTextSharp.text.pdf
Imports Newtonsoft.Json

Public Class ReceieveFile
    Inherits Page
    Dim objCMT As New DbClass

    Public Class CustomResponse
        Public Property Url As String
    End Class

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Dim NameFile As String = objCMT.GetPurpose("FUNC", Request.QueryString("ID"))
        Dim PathTemp As String = Server.MapPath("upload\temp\")
        Dim pathFull As String = Server.MapPath("upload\" + Request.QueryString("ID").ToString + "\")

        Response.Clear()
        Response.ContentType = "application/json"


        If Request.Files.Count > 0 Then
            Try
                For i = 0 To Request.Files.Count - 1
                    'Dim g As Guid = Guid.NewGuid()
                    Dim file = Request.Files(i)
                    Dim extension As String = file.ContentType
                    Dim NameFormart As String = Date.Now.ToString("ddMMyyyy_HHMMss") + "_" + file.FileName

                    PathTemp += NameFormart
                    file.SaveAs(PathTemp)

                    'Done
                    If extension = "application/pdf" Then
                        Dim reader As New PdfReader(PathTemp)
                        Dim _
                            stamper As _
                                New PdfStamper(reader, New FileStream(pathFull + NameFormart, FileMode.Create),
                                               PdfWriter.VERSION_1_5)
                        stamper.FormFlattening = True
                        stamper.SetFullCompression()
                        stamper.Close()
                    End If

                    Dim json = JsonConvert.SerializeObject(New CustomResponse With {.Url = pathFull + NameFormart})
                    Response.Write(json)

                    If Request.QueryString("ID") = "0001" Then
                        Session("namefile_0001_temp") = PathTemp
                        Session("namefile_0001") = pathFull + NameFormart.ToString()
                    ElseIf Request.QueryString("ID") = "0002" Then
                        Session("namefile_0002_temp") = PathTemp
                        Session("namefile_0002") = pathFull + NameFormart.ToString()
                    ElseIf Request.QueryString("ID") = "0003" Then
                        Session("namefile_0003_temp") = PathTemp
                        Session("namefile_0003") = pathFull + NameFormart.ToString()
                    End If

                Next

            Catch ex As Exception
                Dim jsonError As String = JsonConvert.SerializeObject(ex)
                Response.Write(jsonError)
            End Try

        Else
            Dim jsonError As String = JsonConvert.SerializeObject(New Exception("No Any Files."))
            Response.Write(jsonError)
            Response.[End]()
        End If

        Response.[End]()
    End Sub


    'Protected Sub Compress(sender As Object, e As EventArgs)
    '    If fuUpload.HasFile Then
    '        If fuUpload.PostedFile.ContentLength > 0 Then
    '            Dim pdfFile As String = fuUpload.PostedFile.FileName
    '            Dim reader As New PdfReader(pdfFile)
    '            Dim stamper As New PdfStamper(reader, New FileStream("C:\Users\dharmendra\Desktop\test1.pdf", FileMode.Create), PdfWriter.VERSION_1_5)
    '            stamper.FormFlattening = True
    '            stamper.SetFullCompression()
    '            stamper.Close()
    '        End If
    '    End If
    'End Sub
End Class