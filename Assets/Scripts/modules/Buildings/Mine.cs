public class Mine : Building
{
    public Mine()
    {
        this.MaxNumberOfPeon = 1;
        this.Name = "Mine";
        this.Level = 1;
    }

    public int StoneProduction { get; set; }

    public override int Product()
    {
        if (this.CurrentNumberOfPeon == 0) {
            return 0;
        } 

        return this.StoneProduction * this.Level;
    }
}