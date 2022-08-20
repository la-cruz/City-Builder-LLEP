public class Farm : Building
{
    public Farm()
    {
        this.MaxNumberOfPeon = 2;
        this.Name = "Farm";
        this.Level = 1;
    }

    public int WheatProduction { get; set; }

    public override int Product()
    {
        if (this.CurrentNumberOfPeon == 0) {
            return 0;
        } 

        return this.WheatProduction * this.Level;
    }
}