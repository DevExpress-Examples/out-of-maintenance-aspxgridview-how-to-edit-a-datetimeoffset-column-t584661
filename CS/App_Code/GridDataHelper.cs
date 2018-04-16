using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

[DataObject(true)]
public class GridDataHelper {

    List<GridData> gridDataSet = Enumerable
                                   .Range(0, 100)
                                   .Select(x => new GridData {
                                       ID = x,
                                       Date = new DateTimeOffset(2017, 12, 6, 9, 41, 00, new TimeSpan(0, 0, 0)),
                                       DateAndTime = new DateTime(2017, 12, 6, 9, 41, 00),
                                       TimeZoneId = "Eastern Standard Time"
                                   })
                                   .ToList();
    public List<GridData> GridDataSet {
        get {
            if((HttpContext.Current.Session["DataSet"] == null)) {
                HttpContext.Current.Session["DataSet"] = gridDataSet;
                return gridDataSet;
            } else {
                return (List<GridData>)HttpContext.Current.Session["DataSet"];
            }
        }
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public List<GridData> GetGridDataSet() {
        return GridDataSet;
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public void UpdateGridDataSet(GridData gridData) {
        int id = gridData.ID;
        DateTimeOffset date = gridData.Date;
        string timeZoneId = gridData.TimeZoneId;
        foreach(var item in GridDataSet) {
            if(item.ID == id) {
                item.Date = date;
                item.DateAndTime = date.DateTime;
                item.TimeZoneId = timeZoneId;
                break;
            }
        }
    }
}