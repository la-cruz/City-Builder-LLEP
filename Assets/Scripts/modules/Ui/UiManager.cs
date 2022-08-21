using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    public Text WheatCount;

    public Text StoneCount;

    public Text WoodCount;

    public Text PeonCount;

    private RessourcesManager RessourcesManager;

    private PeonsManager PeonsManager;

    private void Start() {
        RessourcesManager = RessourcesManager.GetInstance();
        PeonsManager = PeonsManager.GetInstance();
    }

    private void Update() {
        WheatCount.text = "Blé : " + RessourcesManager.Wheat;
        StoneCount.text = "Pierre : " + RessourcesManager.Stone;
        WoodCount.text = "Bois : " + RessourcesManager.Wood;

        PeonCount.text = "Population : " + PeonsManager.GetCurrentPeonCount();
    }
}