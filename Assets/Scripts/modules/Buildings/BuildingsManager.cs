using UnityEngine;
using System;
using System.Collections.Generic;

public class BuildingsManager : MonoBehaviour {
    private static BuildingsManager Instance;

    public List<Building> BuildingList { get; set; } = new List<Building>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            GenerateFoolishValue();
            Print();
        } else {
            Destroy(this);
        }
    }

    private void GenerateFoolishValue()
    {
        this.BuildingList.Add(new House());
        this.BuildingList.Add(new Farm());
        this.BuildingList.Add(new House());
        this.BuildingList.Add(new Mine());
    }

    public void Print(bool withDetails = false)
    {
        Debug.Log("Instance de BuildingsManager créée");
        Debug.Log(Instance);
        foreach (Building buildings in BuildingList)
        {
            Debug.Log(buildings.ToString());
        }
    }
}