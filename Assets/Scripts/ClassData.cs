// Copyright Kcy.
// Friendly sponsor for dbt6666.

using System;
using System.Collections.Generic;

public struct ClassData
{
    public string name { get; private set; }
    public List<StudentData> students { get; private set; }
    public List<DateTime> days { get; private set; }
    public DateTime timeFrom { get; private set; }
    public DateTime timeTo { get; private set; }

    public ClassData(string p_name, List<DateTime> p_days, DateTime p_timeFrom, DateTime p_timeTo)
    {
        name = p_name;
        days = p_days;
        timeFrom = p_timeFrom;
        timeTo = p_timeTo;

        students = new List<StudentData>();
    }
}
