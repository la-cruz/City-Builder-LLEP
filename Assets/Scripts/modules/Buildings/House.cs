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
        this.WheatCost = 1;
        this.StoneCost = 1;
        this.WoodCost = 1;

        FillWithPeon();
    }

    public void FillWithPeon() {
        string randomName = "Michel";
        for (int i = 0; i < this.MaxNumberOfPeon; i++)
        {
            randomName += i.ToString();
            Peon peon = new Peon() { Name = randomName, Home = this };
            PeonsManager.GetInstance().AddPeon(peon);
            this.AddPeon(peon, true);
        }
    }

    public override int Product()
    {
        return 0;
    }
}
