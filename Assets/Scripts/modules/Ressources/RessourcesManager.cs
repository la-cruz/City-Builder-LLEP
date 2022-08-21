using UnityEngine;
using System;
using System.Collections.Generic;

public class RessourcesManager
{
    private static RessourcesManager Instance;

    public int Wheat = 0;
    public int Stone = 0;
    public int Wood = 0;

    public static RessourcesManager GetInstance()
    {
        if (Instance == null) {
            Instance = new RessourcesManager();
        }

        return Instance;
    }

    public void AddWheat(int wheatAdded)
    {
        Wheat += wheatAdded;

        Debug.Log("Blé total : " + Wheat);
    }

    public void AddStone(int stoneAdded)
    {
        Stone += stoneAdded;
    }

    public void AddWood(int woodAdded)
    {
        Wood += woodAdded;
    }
}