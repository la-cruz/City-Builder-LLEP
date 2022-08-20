using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PeonsManager {
    public static PeonsManager Instance;

    public List<Peon> PeonList = new List<Peon>();

    public static PeonsManager GetInstance() {
        if (Instance == null) {
            Instance = new PeonsManager();
        }

        return Instance;
    }
    
    public void Init()
    {
        Print();
    }

    public void AddPeon(Peon peon)
    {
        Debug.Log("AddPeon");
        PeonList.Add(peon);
    }

    private void GenerateFoolishValue()
    {
        Building house = BuildingsManager.GetInstance().BuildingList[0];
        Peon Jean = new Peon() { Name = "Jean", Home = house };
        Peon Marc = new Peon() { Name = "Marc", Home = house };

        PeonList.Add(Jean);
        PeonList.Add(Marc);

        Debug.Log(house);

        house.AddPeon(Jean);
        house.AddPeon(Marc);
    }

    public void Print(bool withDetails = false)
    {
        Debug.Log("Instance de PeonsManager créée");
        foreach (Peon peon in PeonList)
        {
            Debug.Log(peon.ToString());
        }
    }
}