// Copyright Kcy.
// Friendly sponsor for dbt6666.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    private void Awake() {
        DataBase.LoadClassData();
        DataBase.LoadStudentData();
    }
}
