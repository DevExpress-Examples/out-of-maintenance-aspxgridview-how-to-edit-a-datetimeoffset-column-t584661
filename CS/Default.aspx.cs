using DevExpress.Web;
using System;
using System.Linq;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
    }
    protected void ASPxGridView1_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e) {
        DateTimeOffset dto = (DateTimeOffset)e.GetListSourceFieldValue("Date");
        string timeZoneId = (string)e.GetListSourceFieldValue("TimeZoneId");
        switch(e.Column.FieldName) {
            case "DateTimeOffset":
                e.Value = dto.DateTime + " " + timeZoneId;
                break;
        }
    }
    protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
        ConstructDateTimeOffset(e);
    }
    void ConstructDateTimeOffset(DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.GetSystemTimeZones().First(x => x.Id == Convert.ToString(e.NewValues["TimeZoneId"]));
        DateTime dateTime = DateTime.Parse(Convert.ToString(e.NewValues["DateAndTime"]));
        e.NewValues["Date"] = new DateTimeOffset(dateTime, timeZoneInfo.BaseUtcOffset);
    }
    
}