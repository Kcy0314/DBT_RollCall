using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public static class DataBase
{
    static string testPath = "TestDataBase.xml";

    #region Class
    static string classXmlPath = "ClassDataBase.xml";

    public static void WriteXml(ClassData p_class)
    {
        if(!File.Exists(classXmlPath))
        {
            XmlDocument _xml = new XmlDocument();
            _xml.CreateXmlDeclaration("1.0", "UTF-8", "");
            XmlElement _class = _xml.CreateElement("Class");

            XmlElement _name = _xml.CreateElement("Name");
            _name.Value = p_class.name;

            XmlElement _days = _xml.CreateElement("Days");
            for(int i = 0; i < p_class.days.Count; i++)
            {
                XmlElement _day = _xml.CreateElement("Day");
                _day.Value = GetDayStr(p_class.days[i]);
                _days.AppendChild(_day);
            }

            XmlElement _timeFrom = _xml.CreateElement("Time From");
            _timeFrom.Value = GetTimeStr(p_class.timeFrom);

            XmlElement _timeTo = _xml.CreateElement("Time To");
            _timeTo.Value = GetTimeStr(p_class.timeTo);
            

            _class.AppendChild(_name);
            _class.AppendChild(_days);
            _class.AppendChild(_timeFrom);
            _class.AppendChild(_timeTo);
            _xml.AppendChild(_class);
            _xml.Save(classXmlPath);
        }
        else
        {
            //XmlDocument xml = new XmlDocument();
            //xml.Load(classXmlPath);
        }
    }

    public static void CreateClassData(string p_name, List<DateTime> p_days, DateTime p_timeFrom, DateTime p_timeTo)
    {
        ClassData _classData = new ClassData(p_name, p_days, p_timeFrom, p_timeTo);
        WriteXml(_classData);
    }
    #endregion

    #region Student
    public static void CreateStudentData()
    {
    
    }
    #endregion

    #region tool
    private static string GetTimeStr(DateTime p_time)
    {
        string _h = p_time.Hour.ToString("D2");
        string _m = p_time.Minute.ToString("D2");
        return _h + "-" + _m;
    }

    private static string GetDayStr(DateTime p_day)
    {
        string _y = p_day.Year.ToString("D4");
        string _m = p_day.Month.ToString("D2");
        string _d = p_day.Day.ToString("D2");
        return _y + "-" + _m + "-" + _d;
    }
    #endregion
}
