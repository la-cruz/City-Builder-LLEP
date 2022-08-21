using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private static UiManager Instance;

    public Text WheatCount;

    public Text StoneCount;

    public Text WoodCount;

    public Text PeonCount;

    public GameObject InformationPanel;

    public static UiManager GetInstance()
    {
      if (Instance == null)
      {
        Instance = new UiManager();
      }

      return Instance;
    }

    void Awake()
    {
      if (Instance == null)
      {
        Instance = this;
      }
      else
      {
        Destroy(this);
      }
    }

    private void Start()
    {
        if (InformationPanel == null)
        {
          Debug.LogWarning("Add Information Panel prefab to this script.");
        }
    }

    private void Update() {
        WheatCount.text = RessourcesManager.GetInstance().Wheat.ToString();
        StoneCount.text = RessourcesManager.GetInstance().Stone.ToString();
        WoodCount.text = RessourcesManager.GetInstance().Wood.ToString();

        PeonCount.text = PeonsManager.GetInstance().GetCurrentPeonCount().ToString();
    }

    public void ShowInformationPanel()
    {
      InformationPanel.SetActive(true);
    }

    public void HideInformationPanel()
    {
      InformationPanel.SetActive(false);
    }

    public void UpdateInformationPanel(Building building)
    {
      if (building == null)
      {
        HideInformationPanel();
        return;
      }

      var canvas = InformationPanel.transform.GetChild(0);

      // Update type and lvl
      var typeGameObject = canvas.transform.GetChild(2);
      var typeText = typeGameObject.GetComponent<Text>();
      var buildingType = building.GetType().ToString();
      typeText.text = buildingType + " Lvl " + building.Level;

      // Update number of peon
      var peonGameObject = canvas.transform.GetChild(3);
      var peonText = peonGameObject.GetComponent<Text>();
      peonText.text = building.CurrentNumberOfPeon() + "/ " + building.MaxNumberOfPeon + " peons";

      // Update number of product
      var prodGameObject = canvas.transform.GetChild(4);
      var prodText = prodGameObject.GetComponent<Text>();
      if (buildingType == "House")
      {
          prodText.text = "";
      }
      else
      {
          prodText.text = "+ " + building.production;
          if (buildingType == "Farm")
          {
              prodText.text += " wheats";
          }
          if (buildingType == "Mine")
          {
            prodText.text += " stones";
          }
          if (buildingType == "Sawmill")
          {
            prodText.text += " woods";
          }
    }
  }
}
