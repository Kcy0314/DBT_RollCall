// Copyright Kcy.
// Friendly sponsor for dbt6666.

using System;
using System.Collections.Generic;

public struct ClassData {
    public string name { get; private set; }
    public Dictionary<string, StudentData> students { get; private set; }
    public List<DateTime> days { get; private set; }
    public DateTime timeFrom { get; private set; }
    public DateTime timeTo { get; private set; }
    public bool isDefault => name == null || name == "";

    public ClassData(string p_name, List<DateTime> p_days, DateTime p_timeFrom, DateTime p_timeTo) {
        name = p_name;
        days = p_days;
        timeFrom = p_timeFrom;
        timeTo = p_timeTo;

        students = new Dictionary<string, StudentData>();
    }

    public void AddStudent(StudentData p_student) {
        students.Add(p_student.id, p_student);
    }

    public override string ToString() {
        string _daysStr = "Days: [", _studentsStr = "Students: [";
        foreach (DateTime _day in days) {
            _daysStr += _day.ToString("d");
            _daysStr += ", ";
        }
        foreach (StudentData _student in students.Values) {
            _studentsStr += _student.name;
            _studentsStr += ", ";
        }
        _daysStr += "]"; _studentsStr += "]";
        return $"Class[{name}]: " +
            $"{timeFrom.Hour.ToString("D2")}:{timeFrom.Minute.ToString("D2")} ~ " +
            $"{timeTo.Hour.ToString("D2")}:{timeTo.Minute.ToString("D2")}\n" +
            $"\t{_daysStr}\n" +
            $"\t{_studentsStr}";
    }
}
