using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

[DataObject(true)]
public class TimeZoneDataHelper {
    public List<TimeZoneInfo> TimeZones {
        get { return TimeZoneInfo.GetSystemTimeZones().ToList(); }
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public List<TimeZoneInfo> GetTimeZones() {
        return TimeZones;
    }
}