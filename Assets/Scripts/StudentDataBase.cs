// Copyright Kcy.
// Friendly sponsor for dbt6666.

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StudentDataBase : ScriptableObject
{
    private Dictionary<string, StudentData> studentMap = new Dictionary<string, StudentData>();
    public List<StudentData> Students = new List<StudentData>();

    public bool AddStudentData(StudentData p_student)
    {
        if(!studentMap.ContainsKey(p_student.Id))
        {
            studentMap.Add(p_student.Id, p_student);
            Students.Add(p_student);
            return true;
        }
        Debug.Log("AddStudentData Fail! Student already in database.");
        return false;
    }
}
