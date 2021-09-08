Imports System.Data.SqlClient
Imports System.Web.Script.Services
Imports System.Web.Services

Public Class AutoComplete
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    <WebMethod>
    <ScriptMethod(ResponseFormat := ResponseFormat.Json)>
    Public Shared Function GetSupplier(prefix As String) As String()
        Dim supplier = New List(Of String)()

        Using conn = New SqlConnection()
            conn.ConnectionString =
                ConfigurationManager.ConnectionStrings("WorkRequestConnectionString").ConnectionString
            Using cmd = New SqlCommand()
                cmd.CommandText = "select SupplierCode, SupplierNameUNI from Supplier where " &
                                  "SupplierNameUNI like @SearchText + '%'"
                cmd.Parameters.AddWithValue("@SearchText", prefix)
                cmd.Connection = conn
                conn.Open()

                Using sdr As SqlDataReader = cmd.ExecuteReader()

                    While sdr.Read()
                        supplier.Add(String.Format("{0}-{1}", sdr("SupplierNameUNI"), sdr("SupplierCode")))
                    End While

                End Using

                conn.Close()
            End Using

            Return supplier.ToArray()
        End Using
    End Function

    <WebMethod>
    <ScriptMethod(ResponseFormat := ResponseFormat.Json)>
    Public Shared Function GetPRDetail(prefix As String) As String()
        Dim getprno = New List(Of String)()

        Using conn = New SqlConnection()
            conn.ConnectionString =
                ConfigurationManager.ConnectionStrings("WorkRequestConnectionString").ConnectionString
            Using cmd = New SqlCommand()
                cmd.CommandText = "SELECT Specification,PRNo FROM vewPRDetail where " & "PRNo  like @SearchText + '%'"
                cmd.Parameters.AddWithValue("@SearchText", prefix)
                cmd.Connection = conn
                conn.Open()

                Using sdr As SqlDataReader = cmd.ExecuteReader()

                    While sdr.Read()
                        getprno.Add(String.Format("{0}-{1}", sdr("PRNo"), sdr("Specification")))
                    End While

                End Using

                conn.Close()
            End Using

            Return getprno.ToArray()
        End Using
    End Function
End Class