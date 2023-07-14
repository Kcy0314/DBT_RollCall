using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private StudentDataBase studentDataBase;

    public void CreateStudentData()
    {
        Debug.Log("Test CreateStudentData");
        StudentData _student = new StudentData("A123456789", "TestName", Random.Range(7, 15), new List<ClassData>());
        if(!studentDataBase.AddStudentData(_student))
        {
        //Εγ₯ά°T®§
        }

    }
}
