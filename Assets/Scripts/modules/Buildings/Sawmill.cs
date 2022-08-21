public class Sawmill : Building
{
    public override void Init()
    {
        this.MaxNumberOfPeon = 1;
        this.Name = "Sawmill";
        this.Level = 1;
        this.Tiredness = 10;
        this.production = 2;
        this.WheatCost = 1;
        this.StoneCost = 1;
        this.WoodCost = 1;
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