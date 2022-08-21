public class Mine : Building
{
    public override void Init()
    {
        this.MaxNumberOfPeon = 1;
        this.Name = "Mine";
        this.Level = 1;
        this.Tiredness = 10;
        this.production = 1;
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

        RessourcesManager.GetInstance().AddStone(currentProduction);

        return currentProduction;
    }
}