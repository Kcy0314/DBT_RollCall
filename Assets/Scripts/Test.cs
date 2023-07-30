using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void CreateClassData()
    {
        Debug.Log("Test CreateClassData");
        List<DateTime> _dateTimes = new List<DateTime>();
        _dateTimes.Add(new DateTime(2023, 7, 28));
        _dateTimes.Add(new DateTime(2023, 3, 14));
        DateTime _from = new DateTime(1, 1, 1, 13, 30, 0);
        DateTime _to = new DateTime(1, 1, 1, 15, 0, 0);
        DataBase.CreateClassData("test", _dateTimes, _from, _to);
    }

    public void CreateStudentData() {
        Debug.Log("Test CreateStudentData");
        List<ClassData> _classes = new List<ClassData>();
        ClassData _class = DataBase.GetClass("test");
        if (!_class.isDefault) {
            _classes.Add(_class);
        }
        DataBase.CreateStudentData("X55688", "¤jX«L", UnityEngine.Random.Range(7, 15), 1, _classes);
    }
}
