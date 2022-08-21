using UnityEngine;
using System;
using System.Collections.Generic;

public class RessourcesManager: MonoBehaviour
{
    private static RessourcesManager Instance;
    private House House = new House();
    private bool HouseInitied = false;
    private Farm Farm = new Farm();
    private bool FarmInitied = false;
    private Mine Mine = new Mine();
    private bool MineInitied = false;
    private Sawmill Sawmill = new Sawmill();
    private bool SawmillInitied = false;

    public int Wheat = 100;
    public int Stone = 100;
    public int Wood = 100;

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

    public bool canConstructHouse() {
        if (!this.HouseInitied) {
            this.House.Init();
            this.HouseInitied = true;
        };
        return this.Wheat >= this.House.WheatCost && this.Stone >= this.House.StoneCost && this.Wood >= this.House.WoodCost;
    }

    public bool canConstructFarm() {
        if (!this.FarmInitied) {
            this.Farm.Init();
            this.FarmInitied = true;
        };
        return this.Wheat >= this.Farm.WheatCost && this.Stone >= this.Farm.StoneCost && this.Wood >= this.Farm.WoodCost;
    }

    public bool canConstructSawmill() {
        if (!this.SawmillInitied) {
            this.Sawmill.Init();
            this.SawmillInitied = true;
        };
        return this.Wheat >= this.Sawmill.WheatCost && this.Stone >= this.Sawmill.StoneCost && this.Wood >= this.Sawmill.WoodCost;
    }

    public bool canConstructMine() {
        if (!this.MineInitied) {
            this.Mine.Init();
            this.MineInitied = true;
        };
        return this.Wheat >= this.Mine.WheatCost && this.Stone >= this.Mine.StoneCost && this.Wood >= this.Mine.WoodCost;
    }
}