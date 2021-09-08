Imports System.Globalization
Imports System.Reflection

Public Class DbClass
    Public db As New DBFACDataContext

    Public Sub New()
    End Sub
    ' get Operators information from DB
    Public Function GetOperators(pstrOPID As String, pstrPW As String) As List(Of vewOperator)
        Dim DtRet As List(Of vewOperator)
        Try
            db = New DBFACDataContext
            DtRet = (From c In db.vewOperators Select c Where c.OPID = pstrOPID And c.PW = pstrPW).ToList()
        Catch ex As Exception
            Throw ex
        End Try
        ' return value
        Return DtRet
    End Function
    ' get Item Name information from DB
    Public Function GetPurpose(pstrGroup As String, pstrCode As String) As String
        Dim strRet As String
        Try

            Dim ds = (From c In db.vewPurposes Select c Where c.GroupCode = pstrGroup And c.Code = pstrCode).ToList()
            If ds.Count() > 0 Then
                strRet = ds(0).Value1
            End If

        Catch ex As Exception
            Throw ex
        End Try
        ' return value
        Return strRet
    End Function

    ' get Place Name information from DB
    Public Function GetPlace() As List(Of vewPlace)
        Dim DtRet As List(Of vewPlace)
        Try

            DtRet = (From c In db.vewPlaces Select c).ToList

        Catch ex As Exception
            Throw ex
        End Try
        ' return value
        Return DtRet
    End Function

    ' get OperatorReqFlow information from DB
    Public Function GetOperator(pstrOPID As String) As List(Of vewOperator)
        Dim DtRet As List(Of vewOperator)
        Try
            DtRet = (From c In db.vewOperators Select c Where c.OPID = pstrOPID).ToList
        Catch ex As Exception
            Throw ex
        End Try
        ' return value
        Return DtRet
    End Function


    ' get Place Name information from DB
    Public Function GetGroupID(OPID As String) As DataTable
        Dim DtRet As DataTable
        Try

            ' DtRet = db.sprOperatorReqFlow(OPID.ToString)
            DtRet = LINQResultToDataTable(db.sprOperatorReqFlow(OPID.ToString))

        Catch ex As Exception
            Throw ex
        End Try
        ' return value
        Return DtRet
    End Function

    Public Function LINQResultToDataTable (Of T)(Linqlist As IEnumerable(Of T)) As DataTable
        Dim dt = New DataTable()
        Dim columns As PropertyInfo() = Nothing
        If Linqlist Is Nothing Then Return dt

        For Each Record As T In Linqlist

            If columns Is Nothing Then
                columns = (CType(Record.[GetType](), Type)).GetProperties()

                For Each GetProperty As PropertyInfo In columns
                    Dim colType As Type = GetProperty.PropertyType

                    If (colType.IsGenericType) AndAlso (colType.GetGenericTypeDefinition() = GetType(Nullable(Of ))) _
                        Then
                        colType = colType.GetGenericArguments()(0)
                    End If

                    dt.Columns.Add(New DataColumn(GetProperty.Name, colType))
                Next
            End If

            Dim dr As DataRow = dt.NewRow()

            For Each pinfo As PropertyInfo In columns
                dr(pinfo.Name) =
                    If(pinfo.GetValue(Record, Nothing) Is Nothing, DBNull.Value, pinfo.GetValue(Record, Nothing))
            Next
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function DateAddWeekDaysOnly(dDate As DateTime, iAddDays As Int32) As DateTime
        If iAddDays <> 0 Then
            Dim iIncrement As Int32 = If(iAddDays > 0, 1, - 1)
            Dim iCounter As Int32
            Do
                dDate = dDate.AddDays(iIncrement)
                If dDate.DayOfWeek <> DayOfWeek.Saturday AndAlso dDate.DayOfWeek <> DayOfWeek.Sunday Then _
                    iCounter += iIncrement
            Loop Until iCounter = iAddDays
        End If

        Return dDate
    End Function

    Public Function GetCoverDate(DateCovert As String) As Date

        Dim covertDate As Date = Date.ParseExact(DateCovert, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)

        Return covertDate
    End Function


    Public Function GetCoverDateTime(DateCover As String) As DateTime

        Dim CoverDate As DateTime = Date.ParseExact(DateCover, "dd/MM/yyyy hh:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Return CoverDate

    End Function


End Class
