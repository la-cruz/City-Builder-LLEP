using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuildingsSelection : MonoBehaviour
{
    public PrefabType buildingSelected = PrefabType.None;
    public Button HouseBtn;
    public Button FarmBtn;
    public Button SawmillBtn;
    public Button MineBtn;

    private RessourcesManager RessourcesManager;
    private Color selectedColor = new Color(0.9372549f, 0.8235294f, 0.3137255f);

    void Start() {
        RessourcesManager = RessourcesManager.GetInstance();
    }

    void Update() {
        HouseBtn.interactable = RessourcesManager.canConstructHouse();
        FarmBtn.interactable = RessourcesManager.canConstructFarm();
        SawmillBtn.interactable = RessourcesManager.canConstructSawmill();
        MineBtn.interactable = RessourcesManager.canConstructMine();
    }
    
    public PrefabType getBuildingSelected() {
        return this.buildingSelected;
    }

    public void setBuildingSelected(int enumValue) {
        this.resetSelectedButton();
        if (this.buildingSelected == (PrefabType) enumValue) {
            this.buildingSelected = PrefabType.Tile;
        } else {
            this.buildingSelected = (PrefabType) enumValue;
        }
        this.setSelectedButton();
    }

    private void resetSelectedButton() {
        HouseBtn.GetComponent<Image>().color = Color.white;
        FarmBtn.GetComponent<Image>().color = Color.white;
        SawmillBtn.GetComponent<Image>().color = Color.white;
        MineBtn.GetComponent<Image>().color = Color.white;
    }

    private void setSelectedButton() {
        switch (this.buildingSelected) {
            case PrefabType.Farm :
                FarmBtn.GetComponent<Image>().color = this.selectedColor;
                break;
            case PrefabType.House :
                HouseBtn.GetComponent<Image>().color = this.selectedColor;
                break;
            case PrefabType.Sawmill :
                SawmillBtn.GetComponent<Image>().color = this.selectedColor;
                break;
            case PrefabType.Mine :
                MineBtn.GetComponent<Image>().color = this.selectedColor;
                break;
            default :
                break;
        }
    }
}
