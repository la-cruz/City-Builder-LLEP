using UnityEngine;

public class House : Building
{
    public void Init()
    {
        Debug.Log("start");
        this.MaxNumberOfPeon = 3;
        this.Name = "House";
        this.Level = 1;
        this.Tiredness = -10;

        string randoomName = "Michel";
        for (int i = 0; i < this.MaxNumberOfPeon; i++)
        {
            randoomName += i.ToString();
            PeonsManager.GetInstance().AddPeon(new Peon() { Name = randoomName, Home = this });
        }
        Debug.Log("end");

  }

  public override int Product()
    {
        return 0;
    }
}
