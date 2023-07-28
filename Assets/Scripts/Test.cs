using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void CreateClassData()
    {
        Debug.Log("Test CreateClassData");
        //StudentData _student = new StudentData("A123456789", "TestName", Random.Range(7, 15), new List<ClassData>());
        List<DateTime> dateTimes = new List<DateTime>();
        dateTimes.Add(new DateTime(2023, 7, 28));
        dateTimes.Add(new DateTime(2023, 3, 14));
        DateTime _from = new DateTime(1, 1, 1, 13, 30, 0);
        DateTime _to = new DateTime(1, 1, 1, 15, 0, 0);
        DataBase.CreateClassData("test", dateTimes, _from, _to);

    }
}
