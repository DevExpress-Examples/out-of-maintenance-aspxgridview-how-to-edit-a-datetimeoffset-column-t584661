Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Web

<DataObject(True)> _
Public Class TimeZoneDataHelper
    Public ReadOnly Property TimeZones() As List(Of TimeZoneInfo)
        Get
            Return TimeZoneInfo.GetSystemTimeZones().ToList()
        End Get
    End Property

    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    Public Function GetTimeZones() As List(Of TimeZoneInfo)
        Return TimeZones
    End Function
End Class