using UnityEngine;
using System;
using System.Collections.Generic;

public class BuildingsManager {
    public static BuildingsManager Instance;

    public List<Building> BuildingList { get; set; } = new List<Building>();

    public static BuildingsManager GetInstance() {
        if (Instance == null) {
            Instance = new BuildingsManager();
        }

        return Instance;
    }

    public void Init() {
        GenerateFoolishValue();
        Print();
    }

    public void AddBuilding(Building building) 
    {
        Debug.Log("Building " + building.ToString() + " added");
        BuildingList.Add(building);
    }

    private void GenerateFoolishValue()
    {
        this.BuildingList.Add(new House());
    }

    public void Print(bool withDetails = false)
    {
        Debug.Log("Instance de BuildingsManager créée");
        foreach (Building buildings in BuildingList)
        {
            Debug.Log(buildings.ToString());
        }
    }
}