public class Sawmill : Building
{
    public Sawmill()
    {
      this.MaxNumberOfPeon = 1;
      this.Name = "Sawmill";
      this.Level = 1;
      this.Tiredness = 10;
      this.production = 2;
      this.WheatCost = 10;
      this.StoneCost = 0;
      this.WoodCost = 10;
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

        RessourcesManager.GetInstance().AddWood(currentProduction);

        return currentProduction;
    }
}