Imports DevExpress.Web
Imports System
Imports System.Linq

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    Protected Sub ASPxGridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As ASPxGridViewColumnDataEventArgs)
        Dim dto As DateTimeOffset = CType(e.GetListSourceFieldValue("Date"), DateTimeOffset)
        Dim timeZoneId As String = CStr(e.GetListSourceFieldValue("TimeZoneId"))
        Select Case e.Column.FieldName
            Case "DateTimeOffset"
                e.Value = dto.DateTime & " " & timeZoneId
        End Select
    End Sub
    Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        ConstructDateTimeOffset(e)
    End Sub
    Private Sub ConstructDateTimeOffset(ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim timeZoneInfo As TimeZoneInfo = System.TimeZoneInfo.GetSystemTimeZones().First(Function(x) x.Id = Convert.ToString(e.NewValues("TimeZoneId")))
        Dim dateTime As Date = Date.Parse(Convert.ToString(e.NewValues("DateAndTime")))
        e.NewValues("Date") = New DateTimeOffset(dateTime, timeZoneInfo.BaseUtcOffset)
    End Sub

End Class