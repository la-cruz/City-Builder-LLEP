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

    public void AddBuilding(Building building) 
    {
        Debug.Log("Building " + building.ToString() + " added");
        BuildingList.Add(building);
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