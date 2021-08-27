<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128533911/17.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T584661)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [GridData.cs](./CS/App_Code/GridData.cs) (VB: [GridData.vb](./VB/App_Code/GridData.vb))
* [GridDataHelper.cs](./CS/App_Code/GridDataHelper.cs) (VB: [GridDataHelper.vb](./VB/App_Code/GridDataHelper.vb))
* [TimeZoneDataHelper.cs](./CS/App_Code/TimeZoneDataHelper.cs) (VB: [TimeZoneDataHelper.vb](./VB/App_Code/TimeZoneDataHelper.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to edit a DateTimeOffset column
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t584661/)**
<!-- run online end -->


<p>This example demonstrates how to edit the <a href="https://msdn.microsoft.com/en-us/library/system.datetimeoffset(v=vs.110).aspx">DateTimeOffset structure</a> using the <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.class">ASPxGridView</a> control. The DateTimeOffset represents a date-time data structure which defines a point relative to the UTC time zone. Our ASPxDateEdit editor doesn't support the DateTimeOffset type out of the box. However, it is possible to implement this task with two editors: the <a href="https://documentation.devexpress.com/AspNet/11628/ASP-NET-WebForms-Controls/Data-Editors/Editor-Types/ASPxDateEdit/Overview/ASPxDateEdit-Overview">ASPxDateEdit</a> is used to edit Date and Time parts of a DateTimeOffset value, and the <a href="https://documentation.devexpress.com/AspNet/11418/ASP-NET-WebForms-Controls/Data-Editors/Editor-Types/ASPxComboBox/Overview/ASPxComboBox-Overview">ASPxComboBox</a> is used to edit a time zone. Put these editors into the EditItemTemplate of a column which displays values from the DateTimeOffset field. When a row is updated, it is necessary to combine modified values into the DateTimeOffset structure manually. You can get them via the <strong>e.NewValues</strong> collection in the <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.RowUpdating.event">RowUpdating</a> event handler. In this example, the <strong>UpdateGridDataSet</strong> method is used to save the DateTimeOffset value to a data object.</p>

<br/>


