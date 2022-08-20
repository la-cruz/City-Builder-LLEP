using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int MaxNumberOfPeon { get; set; }

    public int CurrentNumberOfPeon { get; set; }

    public string Name { get; set; }

    public int Level { get; set; }

    public virtual int Product() 
    {
        return 0;
    }

    public override string ToString()
    {
        return Name + " Lv" + Level;
    }
}
