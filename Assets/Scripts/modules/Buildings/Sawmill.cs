public class Sawmill : Building
{
    public Sawmill()
    {
        this.MaxNumberOfPeon = 1;
        this.Name = "Sawmill";
        this.Level = 1;
    }

    public int WoodProduction { get; set; }

    public override int Product() 
    {
        if (this.CurrentNumberOfPeon == 0) {
            return 0;
        } 

        return this.WoodProduction * this.Level;
    }
}