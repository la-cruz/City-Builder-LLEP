public class Mine : Building
{
    public Mine()
    {
        this.MaxNumberOfPeon = 1;
        this.Name = "Mine";
        this.Level = 1;
        this.Tiredness = 10;
    }

    public int StoneProduction = 1;

    public override int Product()
    {
        if (this.CurrentNumberOfPeon() == 0) {
            return 0;
        }

        int production = this.StoneProduction * this.Level;

        RessourcesManager.GetInstance().AddStone(production);

        return production;
    }
}