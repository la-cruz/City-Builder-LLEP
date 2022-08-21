using UnityEngine;

public class Farm : Building
{
    public override void Init()
    {
        this.MaxNumberOfPeon = 2;
        this.Name = "Farm";
        this.Level = 1;
        this.Tiredness = 20;
        this.production = 3;

        // Peon peon = PeonsManager.GetInstance().PeonList[0];

        // peon.Workplace = this;
        // this.AddPeon(peon);
    }

    public override int Product()
    {
        if (this.CurrentNumberOfPeon() == 0) {
            return 0;
        }

        int currentProduction = this.production * this.Level;

        RessourcesManager.GetInstance().AddWheat(currentProduction);

        return currentProduction;
    }
}