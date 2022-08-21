using UnityEngine;

public class Farm : Building
{
    public Farm()
    {
      this.MaxNumberOfPeon = 2;
      this.Name = "Farm";
      this.Level = 1;
      this.Tiredness = 20;
      this.production = 3;
      this.WheatCost = 10;
      this.StoneCost = 0;
      this.WoodCost = 30;
    }

    public override void Init()
    {
        RessourcesManager.GetInstance().RemoveStone(this.StoneCost);
        RessourcesManager.GetInstance().RemoveWheat(this.WheatCost);
        RessourcesManager.GetInstance().RemoveWood(this.WoodCost);
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