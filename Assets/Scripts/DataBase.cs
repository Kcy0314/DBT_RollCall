// Copyright Kcy.
// Friendly sponsor for dbt6666.

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
        XmlDocument _xml = new XmlDocument();
        XmlElement _root;
        if (!File.Exists(classXmlPath))
        {
            _xml.CreateXmlDeclaration("1.0", "UTF-8", "");
             _root = _xml.CreateElement("Data");
        }
        else
        {
            _xml.Load(classXmlPath);
            _root = _xml.DocumentElement;
            foreach (XmlNode _element in _root.ChildNodes)
            {
                string _className = _element.Attributes[0].Value;
                if(_className == p_class.name)
                {
                    UnityEngine.Debug.Log($"Class[{_className}] already exists");
                    return;
                }
            }
        }
        WriteNewClass(p_class, _xml, _root);
    }

    private static void WriteNewClass(ClassData p_class, XmlDocument p_xml, XmlElement p_root)
    {
        XmlElement _class = p_xml.CreateElement("Class");
        _class.SetAttribute("Name", p_class.name);

        XmlElement _days = p_xml.CreateElement("Days");
        for (int i = 0; i < p_class.days.Count; i++)
        {
            XmlElement _day = p_xml.CreateElement("Day");
            _day.InnerText = GetDayStr(p_class.days[i]);
            _days.AppendChild(_day);
        }

        XmlElement _timeFrom = p_xml.CreateElement("TimeFrom");
        _timeFrom.InnerText = GetTimeStr(p_class.timeFrom);

        XmlElement _timeTo = p_xml.CreateElement("TimeTo");
        _timeTo.InnerText = GetTimeStr(p_class.timeTo);

        _class.AppendChild(_days);
        _class.AppendChild(_timeFrom);
        _class.AppendChild(_timeTo);
        p_root.AppendChild(_class);
        p_xml.AppendChild(p_root);
        p_xml.Save(classXmlPath);
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
