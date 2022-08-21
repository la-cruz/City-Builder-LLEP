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

    private void Awake()
    {
      if (Instance == null)
      {
        Instance = this;
      }
    }

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
    }

    public void AddStone(int stoneAdded)
    {
        Stone += stoneAdded;
    }

    public void AddWood(int woodAdded)
    {
        Wood += woodAdded;
    }

    public void RemoveWheat(int wheatRemoved)
    {
        Wheat -= wheatRemoved;
    }

    public void RemoveStone(int stoneRemoved)
    {
        Stone -= stoneRemoved;
    }

    public void RemoveWood(int woodRemoved)
    {
        Wood -= woodRemoved;
    }

    public bool canConstruct(PrefabType prefabType)
    {
      switch (prefabType)
      {
        case PrefabType.Farm:
          return canConstructFarm();
        case PrefabType.House:
          return canConstructHouse();
        case PrefabType.Sawmill:
          return canConstructSawmill();
        case PrefabType.Mine:
          return canConstructMine();
        case PrefabType.None:
        case PrefabType.Tile:
        default:
          return false;
      }
    }

    public bool canConstructHouse() {
        return this.Wheat >= this.House.WheatCost && this.Stone >= this.House.StoneCost && this.Wood >= this.House.WoodCost;
    }

    public bool canConstructFarm() {
        return this.Wheat >= this.Farm.WheatCost && this.Stone >= this.Farm.StoneCost && this.Wood >= this.Farm.WoodCost;
    }

    public bool canConstructSawmill() {
        return this.Wheat >= this.Sawmill.WheatCost && this.Stone >= this.Sawmill.StoneCost && this.Wood >= this.Sawmill.WoodCost;
    }

    public bool canConstructMine() {
        return this.Wheat >= this.Mine.WheatCost && this.Stone >= this.Mine.StoneCost && this.Wood >= this.Mine.WoodCost;
    }
}