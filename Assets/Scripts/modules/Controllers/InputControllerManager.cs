using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerManager : MonoBehaviour
{
  #region VARIABLES

  private static InputControllerManager Instance;

  public BuildingsSelection buildingsSelection;

  #endregion

  #region UNITY_METHODS

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hit))
      {
        Transform objectHit = hit.transform;
        if (objectHit.gameObject.transform.parent.gameObject.transform.parent.name == "GridManager")
        {
          TriggerGrid(objectHit.gameObject.transform.parent.gameObject.name);
        }
        else
        {
          // Detect other think...
          Debug.Log("object hit name : " + objectHit.gameObject.name);
        }
      }
    }

    if(Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }
  }
  #endregion

  #region METHODS
  public static InputControllerManager GetInstance()
  {
    if (Instance == null)
    {
      Instance = new InputControllerManager();
    }
    return Instance;
  }

  private void TriggerGrid(string gridName)
  {
    int index;
    int.TryParse(gridName, out index);

    GridManager.GetInstance().UpdateGridAt(index, buildingsSelection.buildingSelected);
  }

  #endregion
}
