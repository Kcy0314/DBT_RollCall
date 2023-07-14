// Copyright Kcy.
// Friendly sponsor for dbt6666.

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StudentData
{
    public string Id => id;
    public string Name => name;
    public int Age => age;
    public List<ClassData> Classes => classes;

    [SerializeField] private string id;
    [SerializeField] private string name;
    [SerializeField] private int age;
    [SerializeField] private List<ClassData> classes;

    public StudentData(string p_id, string p_name, int p_age, List<ClassData> p_classes)
    {
        id = p_id;
        name = p_name;
        age = p_age;
        classes = p_classes;
    }

}
