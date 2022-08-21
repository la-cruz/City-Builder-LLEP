using UnityEngine;

public class House : Building
{
    public override void Init()
    {
        this.MaxNumberOfPeon = 3;
        this.Name = "House";
        this.Level = 1;
        this.Tiredness = -10;
        this.production = 0;

        FillWithPeon();
    }

    public void FillWithPeon() {
        string randomName = "Michel";
        for (int i = 0; i < this.MaxNumberOfPeon; i++)
        {
            randomName += i.ToString();
            PeonsManager.GetInstance().AddPeon(new Peon() { Name = randomName, Home = this });
        }
    }

    public override int Product()
    {
        return 0;
    }
}
