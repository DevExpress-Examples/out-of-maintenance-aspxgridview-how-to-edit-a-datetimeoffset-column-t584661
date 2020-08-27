<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.17.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPxGridView - How to edit DateTimeOffset</title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" KeyFieldName="ID"
                    OnCustomUnboundColumnData="ASPxGridView1_CustomUnboundColumnData"
                    OnRowUpdating="ASPxGridView1_RowUpdating">
                    <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                    <Columns>
                        <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0"></dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" ReadOnly="true">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DateTimeOffset" UnboundType="String" VisibleIndex="5" Caption="Date, time and offset">
                            <EditItemTemplate>
                                <dx:ASPxDateEdit FieldName="DateAndTime" ID="ASPxDateEdit1" runat="server" Value='<%# Bind("DateAndTime") %>'
                                    DisplayFormatString="MM/dd/yyyy hh:mm tt" EditFormatString="MM/dd/yyyy hh:mm tt">
                                    <TimeSectionProperties Visible="true"></TimeSectionProperties>
                                </dx:ASPxDateEdit>
                                <dx:ASPxComboBox FieldName="TimeZoneId" ID="ASPxComboBox1" runat="server" ValueType="System.String" DataSourceID="ObjectDataSource2"
                                     TextField="DisplayName" ValueField="Id" Value='<%# Bind("TimeZoneId") %>'></dx:ASPxComboBox>
                            </EditItemTemplate>
                        </dx:GridViewDataTextColumn>
				</Columns>
                </dx:ASPxGridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="GridData" SelectMethod="GetGridDataSet" TypeName="GridDataHelper" UpdateMethod="UpdateGridDataSet" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetTimeZones" TypeName="TimeZoneDataHelper" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    </form>
</body>
</html>
