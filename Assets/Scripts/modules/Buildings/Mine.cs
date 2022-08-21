using UnityEngine;

public class Mine : Building
{
    public Mine()
    {
      this.MaxNumberOfPeon = 1;
      this.Name = "Mine";
      this.Level = 1;
      this.Tiredness = 10;
      this.production = 1;
      this.WheatCost = 10;
      this.StoneCost = 0;
      this.WoodCost = 45;
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

        RessourcesManager.GetInstance().AddStone(currentProduction);

        return currentProduction;
    }
}