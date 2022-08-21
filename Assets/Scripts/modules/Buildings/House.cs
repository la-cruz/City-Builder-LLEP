using UnityEngine;

public class House : Building
{
    public House()
    {
      this.MaxNumberOfPeon = 3;
      this.Name = "House";
      this.Level = 1;
      this.Tiredness = -10;
      this.production = 0;
      this.WheatCost = 0;
      this.StoneCost = 20;
      this.WoodCost = 10;
    }

    public override void Init()
    {
        FillWithPeon();

        RessourcesManager.GetInstance().RemoveStone(this.StoneCost);
        RessourcesManager.GetInstance().RemoveWheat(this.WheatCost);
        RessourcesManager.GetInstance().RemoveWood(this.WoodCost);
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
