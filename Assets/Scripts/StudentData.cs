// Copyright Kcy.
// Friendly sponsor for dbt6666.

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StudentData {
    public string id { get; private set; }
    public string name { get; private set; }
    public int age { get; private set; }
    public int gender { get; private set; }
    public List<ClassData> classes { get; private set; }
    public bool isDefault => name == null || name == "";

    public StudentData(string p_id, string p_name, int p_age, int p_gender, List<ClassData> p_classes = null) {
        id = p_id;
        name = p_name;
        age = p_age;
        gender = p_gender;
        if (p_classes != null) {
            classes = p_classes;
        } else {
            classes = new List<ClassData>();
        }
    }

    public override string ToString() {
        string _classesStr = "";
        foreach (ClassData _class in classes) {
            _classesStr += _class.name;
            _classesStr += ", ";
        }
        return $"Student[{name}]: Id[{id}], Age[{age}], Gender[{gender}]\n" +
            $"\t{_classesStr}";
    }
}
