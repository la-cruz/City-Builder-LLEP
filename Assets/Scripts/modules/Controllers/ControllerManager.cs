using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            BuildingsManager.GetInstance();
            PeonsManager.GetInstance();

            // For testing
/*            Farm ferme = new Farm();

            BuildingsManager.GetInstance().AddBuilding(ferme);
            foreach (Peon peon in PeonsManager.GetInstance().PeonList)
            {
                ferme.AddPeon(peon);
                peon.Workplace = ferme;
            }
*/

        } else {
            Destroy(this);
        }
    }
}