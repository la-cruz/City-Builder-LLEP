using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour
{
    public Building()
    {
        Name = "None";
        MaxNumberOfPeon = 0;
        Level = 1;
    }

    public int MaxNumberOfPeon;

    public List<Peon> Peons = new List<Peon>();

    public string Name;

    public int Level;

    public float Tiredness;

    public int production = 0;

    public int CurrentNumberOfPeon()
    {
        return Peons.Count;
    }

    public List<Peon> CurrentNumberOfWorkingPeon()
    {
        return Peons.FindAll(IsWorkingPredicate);
    }

    private static bool IsWorkingPredicate(Peon peon)
    {
        return peon.IsAtHome;
    }

    public void AddPeon(Peon peon, bool isAddedToHome = false)
    {
        if (CurrentNumberOfPeon() < MaxNumberOfPeon) {
            Debug.Log("Peon " + peon.Name + " added");
            Peons.Add(peon);
            if (!isAddedToHome) {
                peon.Workplace = this;
            }
        }
    }

    public void RemovePeon(Peon peon)
    {
        if (CurrentNumberOfPeon() > 0)
        {
            Debug.Log("Peon " + peon.Name + " removed");
            Peons.Remove(peon);
        }
    }

    public virtual int Product() 
    {
        return production;
    }

    public virtual void Init() {}

    public override string ToString()
    {
        return Name + " Lv" + Level;
    }
}
