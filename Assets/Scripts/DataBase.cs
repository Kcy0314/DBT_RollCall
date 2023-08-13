// Copyright Kcy.
// Friendly sponsor for dbt6666.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public static class DataBase {
    static string testPath = "TestDataBase.xml";

    #region Class
    static string classXmlPath = "ClassDataBase.xml";
    private static Dictionary<string, ClassData> ClassDict = new Dictionary<string, ClassData>();

    public static void LoadClassData() {
        if (!File.Exists(classXmlPath)) { return; }
        XmlDocument _xml = new XmlDocument();
        _xml.Load(classXmlPath);
        XmlElement _root = _xml.DocumentElement;
        foreach (XmlElement _element in _root.ChildNodes) {
            string _className = _element.Attributes["Name"].Value;
            List<DateTime> _days = new List<DateTime>();
            DateTime _timeFrom = default, _timeTo = default;
            foreach (XmlElement _node in _element.ChildNodes) {
                if (_node.Name == "Days") {
                    foreach (XmlElement _dayData in _node.ChildNodes) {
                        DateTime _day = GetDay(_dayData.InnerText);
                        _days.Add(_day);
                    }
                }
                if(_node.Name== "TimeFrom") {
                    _timeFrom = GetTime(_node.InnerText);
                }
                if(_node.Name== "TimeTo") {
                    _timeTo = GetTime(_node.InnerText);
                }
            }
            ClassData _classData = new ClassData(_className, _days, _timeFrom, _timeTo);
            ClassDict.Add(_classData.name, _classData);
        }

#if UNITY_EDITOR
        Debug.Log("LoadClassData");
        foreach (var _class in ClassDict.Values) {
            Debug.Log(_class);
        }
#endif
    }

    private static bool WriteXml(ClassData p_class) {
        XmlDocument _xml = new XmlDocument();
        XmlElement _root;
        if (!File.Exists(classXmlPath)) {
            _xml.CreateXmlDeclaration("1.0", "UTF-8", "");
            _root = _xml.CreateElement("Data");
        } else {
            _xml.Load(classXmlPath);
            _root = _xml.DocumentElement;
            foreach (XmlNode _element in _root.ChildNodes) {
                string _className = _element.Attributes["Name"].Value;
                if (_className == p_class.name) {
                    Debug.LogError($"Class[{_className}] already exists");
                    return false;
                }
            }
        }
        WriteNewClass(p_class, _xml, _root);
        return true;
    }

    private static void WriteNewClass(ClassData p_class, XmlDocument p_xml, XmlElement p_root) {
        XmlElement _class = p_xml.CreateElement("Class");
        _class.SetAttribute("Name", p_class.name);

        XmlElement _days = p_xml.CreateElement("Days");
        for (int i = 0; i < p_class.days.Count; i++) {
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

    public static void CreateClassData(string p_name, List<DateTime> p_days, DateTime p_timeFrom, DateTime p_timeTo) {
        ClassData _classData = new ClassData(p_name, p_days, p_timeFrom, p_timeTo);
        if (WriteXml(_classData)) {
            ClassDict.Add(_classData.name, _classData);
        }
    }

    // TODO: 修改班級資料
    // TODO: 刪除班級資料

    public static ClassData GetClass(string p_name) {
        if (ClassDict.TryGetValue(p_name, out ClassData _classData)) {
            return _classData;
        } else {
            Debug.LogError($"GetClass Fail! Class[{p_name}] not in Dict");
            return default;
        }
    }
    #endregion

    #region Student
    static string studentXmlPath = "StudentDataBase.xml";
    private static Dictionary<string, StudentData> StudentDict = new Dictionary<string, StudentData>();

    public static void LoadStudentData() {
        if (!File.Exists(studentXmlPath)) { return; }
        XmlDocument _xml = new XmlDocument();
        _xml.Load(studentXmlPath);
        XmlElement _root = _xml.DocumentElement;
        foreach (XmlElement _element in _root.ChildNodes) {
            string _studentName = _element.Attributes["Name"].Value;
            string _studentId = _element.Attributes["Id"].Value;
            int _studentAge = int.Parse(_element.Attributes["Age"].Value);
            int _studentGender = int.Parse(_element.Attributes["Gender"].Value);
            List<ClassData> _studentClasses = new List<ClassData>();
            foreach (XmlElement _node in _element.ChildNodes) {
                if (_node.Name == "Classes") {
                    foreach (XmlElement _classNode in _node.ChildNodes) {
                        _studentClasses.Add(GetClass(_classNode.InnerText));
                    }
                }
            }
            StudentData _studentData = new StudentData(_studentId, _studentName, _studentAge, _studentGender, _studentClasses);
            StudentDict.Add(_studentData.id, _studentData);
        }

#if UNITY_EDITOR
        Debug.Log("LoadStudentData");
        foreach (var _student in StudentDict.Values) {
            Debug.Log(_student);
        }
#endif
    }

    private static bool WriteXml(StudentData p_student) {
        XmlDocument _xml = new XmlDocument();
        XmlElement _root;
        if (!File.Exists(studentXmlPath)) {
            _xml.CreateXmlDeclaration("1.0", "UTF-8", "");
            _root = _xml.CreateElement("Data");
        } else {
            _xml.Load(studentXmlPath);
            _root = _xml.DocumentElement;
            foreach (XmlNode _element in _root.ChildNodes) {
                string _studentId = _element.Attributes["Id"].Value;
                if (_studentId == p_student.id) {
                    Debug.LogError($"Student[{_studentId}] already exists");
                    return false;
                }
            }
        }
        WriteNewStudent(p_student, _xml, _root);
        return true;
    }

    private static void WriteNewStudent(StudentData p_student, XmlDocument p_xml, XmlElement p_root) {
        XmlElement _student = p_xml.CreateElement("Student");
        _student.SetAttribute("Name", p_student.name);
        _student.SetAttribute("Id", p_student.id);
        _student.SetAttribute("Age", p_student.age.ToString());
        _student.SetAttribute("Gender", p_student.gender.ToString());

        XmlElement _classes = p_xml.CreateElement("Classes");
        for (int i = 0; i < p_student.classes.Count; i++) {
            XmlElement _class = p_xml.CreateElement("Class");
            _class.InnerText = p_student.classes[i].name;
            _classes.AppendChild(_class);
        }

        _student.AppendChild(_classes);
        p_root.AppendChild(_student);
        p_xml.AppendChild(p_root);
        p_xml.Save(studentXmlPath);
    }

    public static void CreateStudentData(string p_id, string p_name, int p_age, int p_gender, List<ClassData> p_classes = null) {
        StudentData _studentData = new StudentData(p_id, p_name, p_age, p_gender, p_classes);
        if (WriteXml(_studentData)) {
            StudentDict.Add(_studentData.id, _studentData);
        }
    }

    // TODO: 修改學生資料
    // TODO: 刪除學生資料

    public static StudentData GetStudent(string p_id) {
        if (StudentDict.TryGetValue(p_id, out StudentData _studentData)) {
            return _studentData;
        } else {
            Debug.LogError($"GetStudent Fail! Id[{p_id}] not in Dict");
            return default;
        }
    }
    #endregion

    #region tool
    private static string GetDayStr(DateTime p_day) {
        string _y = p_day.Year.ToString("D4");
        string _m = p_day.Month.ToString("D2");
        string _d = p_day.Day.ToString("D2");
        return _y + "-" + _m + "-" + _d;
    }

    private static string GetTimeStr(DateTime p_time) {
        string _h = p_time.Hour.ToString("D2");
        string _m = p_time.Minute.ToString("D2");
        return _h + "-" + _m;
    }

    private static DateTime GetDay(string p_day) {
        string[] _data = p_day.Split('-');
        int _y, _m, _d;
        int.TryParse(_data[0], out _y);
        int.TryParse(_data[1], out _m);
        int.TryParse(_data[2], out _d);
        return new DateTime(_y, _m, _d);
    }

    private static DateTime GetTime(string p_time) {
        string[] _data = p_time.Split('-');
        int _h, _m;
        int.TryParse(_data[0], out _h);
        int.TryParse(_data[1], out _m);
        return new DateTime(1, 1, 1, _h, _m, 0);
    }
    #endregion
}
