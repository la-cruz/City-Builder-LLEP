public class Sawmill : Building
{
    public Sawmill()
    {
        this.MaxNumberOfPeon = 1;
        this.Name = "Sawmill";
        this.Level = 1;
        this.Tiredness = 10;
    }

    public int WoodProduction;

    public override int Product() 
    {
        if (this.CurrentNumberOfPeon() == 0) {
            return 0;
        }

        int production = this.WoodProduction * this.Level;

        RessourcesManager.GetInstance().AddWood(production);

        return production;
    }
}