using UnityEngine;

public class Farm : Building
{
    public Farm()
    {
        this.MaxNumberOfPeon = 2;
        this.Name = "Farm";
        this.Level = 1;
        this.Tiredness = 20;
    }

    public int WheatProduction = 3;

    public override int Product()
    {
        if (this.CurrentNumberOfPeon() == 0) {
            return 0;
        }

        int production = this.WheatProduction * this.Level;

        RessourcesManager.GetInstance().AddWheat(production);

        return production;
    }
}