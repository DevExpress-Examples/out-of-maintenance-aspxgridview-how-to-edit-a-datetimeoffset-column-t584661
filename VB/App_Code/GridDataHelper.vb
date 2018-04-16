Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Web

<DataObject(True)> _
Public Class GridDataHelper


    Private gridDataSet_Renamed As List(Of GridData) = Enumerable.Range(0, 100).Select(Function(x) New GridData With { _
        .ID = x, _
        .Date = New DateTimeOffset(2017, 12, 6, 9, 41, 00, New TimeSpan(0, 0, 0)), _
        .DateAndTime = New Date(2017, 12, 6, 9, 41, 00), _
        .TimeZoneId = "Eastern Standard Time" _
    }).ToList()
    Public ReadOnly Property GridDataSet() As List(Of GridData)
        Get
            If (HttpContext.Current.Session("DataSet") Is Nothing) Then
                HttpContext.Current.Session("DataSet") = gridDataSet_Renamed
                Return gridDataSet_Renamed
            Else
                Return DirectCast(HttpContext.Current.Session("DataSet"), List(Of GridData))
            End If
        End Get
    End Property

    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    Public Function GetGridDataSet() As List(Of GridData)
        Return GridDataSet
    End Function

    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Sub UpdateGridDataSet(ByVal gridData As GridData)
        Dim id As Integer = gridData.ID
        Dim [date] As DateTimeOffset = gridData.Date
        Dim timeZoneId As String = gridData.TimeZoneId
        For Each item In GridDataSet
            If item.ID = id Then
                item.Date = [date]
                item.DateAndTime = [date].DateTime
                item.TimeZoneId = timeZoneId
                Exit For
            End If
        Next item
    End Sub
End Class