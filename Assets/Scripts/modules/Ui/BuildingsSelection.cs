using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuildingsSelection : MonoBehaviour
{
    public PrefabType buildingSelected = PrefabType.Tile;
    public Button houseBtn;
    public Button farmBtn;
    public Button sawmillBtn;
    public Button mineBtn;
    
    public PrefabType getBuildingSelected() {
        return this.buildingSelected;
    }

    public void setBuildingSelected(int enumValue) {
        this.buildingSelected = (PrefabType) enumValue;
    }
}
