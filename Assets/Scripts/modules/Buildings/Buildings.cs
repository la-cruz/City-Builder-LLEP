using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building
{
    public Building()
    {
        Name = "None";
        MaxNumberOfPeon = 0;
        Level = 1;
    }

    public Building(string name)
    {
        Name = name;
        MaxNumberOfPeon = 0;
        Level = 1;
    }

    public Building(int maxNumberOfPeon)
    {
        Name = "None";
        MaxNumberOfPeon = maxNumberOfPeon;
        Level = 1;
    }

    public Building(string name, int maxNumberOfPeon)
    {
        Name = name;
        MaxNumberOfPeon = maxNumberOfPeon;
        Level = 1;
    }

    public int MaxNumberOfPeon;

    public List<Peon> Peons = new List<Peon>();

    public string Name;

    public int Level;

    public float Tiredness;

    public int CurrentNumberOfPeon()
    {
        return Peons.Count;
    }

    public void AddPeon(Peon peon)
    {
        if (CurrentNumberOfPeon() < MaxNumberOfPeon) {
            Debug.Log("Peon " + peon.Name + " added");
            Peons.Add(peon);
        }

    }

    public virtual int Product() 
    {
        return 0;
    }

    public override string ToString()
    {
        return Name + " Lv" + Level;
    }
}
