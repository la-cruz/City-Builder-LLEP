using UnityEngine;
using System.Collections;

public class Peon {
    public int Age;

    public int Hunger;

    public float Tiredness = 0;

    public bool IsAtHome = true;

    public Building Home;

    public Building Workplace;

    public string Name;

    public Peon() {
        ControllerManager.Instance.StartCoroutine(workCycle());
    }

    public void GoToHome() {
        Debug.Log(Name + " rentre chez lui");
        IsAtHome = true;
        
    }

    public void GoToWork() {

        if (Workplace == null)
        {
          return;
        }
        Debug.Log(Name + " va au travail");
        IsAtHome = false;
    }

    public override string ToString()
    {
        return Name;
    }

    IEnumerator workCycle()
    {
        for (;;) {
            yield return new WaitForSeconds(5f);

            if (!IsAtHome) {
                Workplace.Product();
                Tiredness += Workplace.Tiredness;
                if (Tiredness >= 100) {
                    Tiredness = 100;
                    GoToHome();
                }
            } else {
                Tiredness += Home.Tiredness;
                if (Tiredness <= 0) {
                    Tiredness = 0;
                    GoToWork();
                }
            }
        }
    }
}