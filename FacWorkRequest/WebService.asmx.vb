Imports System.ComponentModel
Imports System.Globalization
Imports System.Web.Script.Services
Imports System.Web.Services

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<ScriptService> _
<WebService(Namespace := "http://tempuri.org/")> _
<WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)>
Public Class WebService
    Inherits Services.WebService
    Dim ReadOnly objCMT As New DbClass
    Dim ReadOnly dtfi As DateTimeFormatInfo = New DateTimeFormatInfo

    <WebMethod>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod>
    Public Function getData_ChartSummary(StartRange As String, EndRange As String) As List(Of ChartSummary)

        Dim DtResult As New DataTable
        Dim dataList = New List(Of ChartSummary)()
        Dim MonthYear = ""
        Dim TotalRequest = 0
        Dim TotalFinish = 0
        Dim TotalRemain = 0
        Dim AccumulateRequest = 0
        Dim AccumulateFinish = 0

        Try
            Using db = New DBFACDataContext()
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprChartSummary(CDate(StartRange.ToString(dtfi)),
                                                                                  CDate(EndRange.ToString(dtfi))))
                For Each row As DataRow In DtResult.Rows
                    MonthYear = row.Item(0).ToString.Trim
                    TotalRequest = row.Item(1).ToString
                    TotalFinish = row.Item(2).ToString
                    TotalRemain = row.Item(3).ToString
                    AccumulateRequest = row.Item(4).ToString
                    AccumulateFinish = row.Item(5).ToString
                    dataList.Add(New ChartSummary(MonthYear, TotalRequest, TotalFinish, TotalRemain, AccumulateRequest,
                                                  AccumulateFinish))
                Next row

            End Using

        Catch ex As Exception

        End Try

        Return dataList
    End Function

    <WebMethod>
    Public Function getData_ChartSummaryByRole(StartRange As String, EndRange As String, Role As String) _
        As List(Of ChartSummary)

        Dim DtResult As New DataTable
        Dim dataList = New List(Of ChartSummary)()
        Dim MonthYear = ""
        Dim TotalRequest = 0
        Dim TotalFinish = 0
        Dim TotalRemain = 0
        Dim AccumulateRequest = 0
        Dim AccumulateFinish = 0

        Try
            Using db = New DBFACDataContext()
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprChartSummaryByRole(CDate(StartRange.ToString(dtfi)),
                                                                                        CDate(EndRange.ToString(dtfi)),
                                                                                        CInt(Role)))
                For Each row As DataRow In DtResult.Rows
                    MonthYear = row.Item(0).ToString.Trim
                    TotalRequest = row.Item(1).ToString
                    TotalFinish = row.Item(2).ToString
                    TotalRemain = row.Item(3).ToString
                    AccumulateRequest = row.Item(4).ToString
                    AccumulateFinish = row.Item(5).ToString
                    dataList.Add(New ChartSummary(MonthYear, TotalRequest, TotalFinish, TotalRemain, AccumulateRequest,
                                                  AccumulateFinish))
                Next row

            End Using

        Catch ex As Exception

        End Try

        Return dataList
    End Function

    <WebMethod>
    Public Function getData_ChartSummaryByDept(StartRange As String, EndRange As String, Role As String) _
        As List(Of ChartSummary)

        Dim DtResult As New DataTable
        Dim dataList = New List(Of ChartSummary)()
        Dim MonthYear = ""
        Dim TotalRequest = 0
        Dim TotalFinish = 0
        Dim TotalRemain = 0
        Dim AccumulateRequest = 0
        Dim AccumulateFinish = 0

        Try
            Using db = New DBFACDataContext()
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprChartSummaryByDept(CDate(StartRange.ToString(dtfi)),
                                                                                        CDate(EndRange.ToString(dtfi)),
                                                                                        CInt(Role)))
                For Each row As DataRow In DtResult.Rows
                    MonthYear = row.Item(0).ToString.Trim
                    TotalRequest = row.Item(1).ToString
                    TotalFinish = row.Item(2).ToString
                    TotalRemain = row.Item(3).ToString
                    AccumulateRequest = row.Item(4).ToString
                    AccumulateFinish = row.Item(5).ToString
                    dataList.Add(New ChartSummary(MonthYear, TotalRequest, TotalFinish, TotalRemain, AccumulateRequest,
                                                  AccumulateFinish))
                Next row

            End Using

        Catch ex As Exception

        End Try

        Return dataList
    End Function

    <WebMethod>
    Public Function getData_ChartSummaryByDeptTotal(StartRange As String, EndRange As String) As List(Of ChartSummary)

        Dim DtResult As New DataTable
        Dim dataList = New List(Of ChartSummary)()
        Dim MonthYear = ""
        Dim TotalRequest = 0
        Dim TotalFinish = 0
        Dim TotalRemain = 0
        Dim AccumulateRequest = 0
        Dim AccumulateFinish = 0

        Try
            Using db = New DBFACDataContext()
                DtResult =
                    objCMT.LINQResultToDataTable(objCMT.db.sprChartSummaryByDeptTotal(CDate(StartRange.ToString(dtfi)),
                                                                                      CDate(EndRange.ToString(dtfi))))
                For Each row As DataRow In DtResult.Rows
                    MonthYear = row.Item(0).ToString.Trim
                    TotalRequest = row.Item(1).ToString
                    TotalFinish = row.Item(2).ToString
                    TotalRemain = row.Item(3).ToString
                    AccumulateRequest = row.Item(4).ToString
                    AccumulateFinish = row.Item(5).ToString
                    dataList.Add(New ChartSummary(MonthYear, TotalRequest, TotalFinish, TotalRemain, AccumulateRequest,
                                                  AccumulateFinish))
                Next row

            End Using

        Catch ex As Exception

        End Try

        Return dataList
    End Function

    Public Class ChartSummary
        Public MonthYear As String = ""
        Public TotalRequest As Integer = 0
        Public TotalFinish As Integer = 0
        Public TotalRemain As Integer = 0
        Public AccumulateRequest As Integer = 0
        Public AccumulateFinish As Integer = 0

        Public Sub New(MonthYear As String, TotalRequest As Integer, TotalFinish As Integer, TotalRemain As Integer,
                       AccumulateRequest As Integer, AccumulateFinish As Integer)
            MyBase.New()
            Me.MonthYear = MonthYear
            Me.TotalRequest = TotalRequest
            Me.TotalFinish = TotalFinish
            Me.TotalRemain = TotalRemain
            Me.AccumulateRequest = AccumulateRequest
            Me.AccumulateFinish = AccumulateFinish
        End Sub
    End Class

    '*******************************************************************************************************

    <WebMethod>
    Public Function getData_ChartSummaryByStatus(StartRange As String, EndRange As String, Role As String) _
        As List(Of PieSummary)

        Dim DtResult As New DataTable
        Dim dataList = New List(Of PieSummary)()
        Dim Process As String
        Dim Total = 0

        Try
            Using db = New DBFACDataContext()
                DtResult = objCMT.LINQResultToDataTable(objCMT.db.sprChartSummaryByStatus(
                    CDate(StartRange.ToString(dtfi)), CDate(EndRange.ToString(dtfi)), CInt(Role)))
                For Each row As DataRow In DtResult.Rows
                    Process = row.Item(1).ToString.Trim
                    Total = row.Item(2).ToString

                    dataList.Add(New PieSummary(Process, Total))
                Next row

            End Using

        Catch ex As Exception

        End Try

        Return dataList
    End Function

    <WebMethod>
    Public Function getData_ChartSummaryByStatusTotal(StartRange As String, EndRange As String) As List(Of PieSummary)

        Dim DtResult As New DataTable
        Dim dataList = New List(Of PieSummary)()
        Dim Process As String
        Dim Total = 0


        Try
            Using db = New DBFACDataContext()
                DtResult =
                    objCMT.LINQResultToDataTable(objCMT.db.sprChartSummaryByStatusTotal(CDate(StartRange.ToString(dtfi)),
                                                                                        CDate(EndRange.ToString(dtfi))))

                For Each row As DataRow In DtResult.Rows
                    Process = row.Item(1).ToString.Trim
                    Total = row.Item(2).ToString

                    dataList.Add(New PieSummary(Process, Total))
                Next row

            End Using

        Catch ex As Exception

        End Try

        Return dataList
    End Function

    Public Class PieSummary
        Public Process As String
        Public Total As Integer = 0

        Public Sub New(Process As String, Total As Integer)
            MyBase.New()
            Me.Process = Process
            Me.Total = Total
        End Sub
    End Class
End Class