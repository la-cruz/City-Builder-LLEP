public class House : Building
{
    public House()
    {
        this.MaxNumberOfPeon = 6;
        this.Name = "House";
        this.Level = 1;
    }

    public override int Product() 
    {
        return 0;
    }
}