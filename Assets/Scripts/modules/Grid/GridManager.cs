using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum PrefabType
{
  None = -1,
  Tile = 0,
  Farm = 1,
  House = 2,
  Sawmill = 3,
  Mine = 4,
}

/**
 * Singleton class used to manage Grid for external system. Contains only
 * an instance and methods to access of a Grid.
 */
public class GridManager : MonoBehaviour
{
  #region VARIABLES

  /**
   * Basic instance used later for any action on the grid.
   */
  private static GridManager Instance;

  /**
   * Internal stored grid.
   */
  private Grid grid = new Grid();

  /**
   * Dimensions of our grid.
   */
  public int cols = 5;
  public int rows = 5;

  /**
   * Represent the offset needed betwwen each tile.
   */
  public float offsetTile = 6;

  public List<GameObject> prefabs;

  #endregion

  #region UNITY_METHODS

  /**
   * Naive approach to generate our Singleton, we should switch to an
   * "lazzy loading" approach later.
   */
  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      if (GenerateGrid(rows, cols))
      {
        InstantiateGridPrefab();
      }

      Print();
    }
    else
    {
      Destroy(this);
    }
  }

  #endregion

  #region METHODS

  public static GridManager GetInstance()
  {
    if (Instance == null)
    {
      Instance = new GridManager();
    }

    return Instance;
  }

  /**
   * Generate a new Grid only if there is not grid already created.
   */
  public bool GenerateGrid(int rows = 10, int cols = 10)
  {
    return grid.Create(rows, cols);
  }

  /**
   * Instantiate all prefab object from the grid.
   * Need to call GenerateGrid() before this method.
   */
  public bool InstantiateGridPrefab()
  {
    if (grid == null)
    {
      Debug.LogWarning("Need to call Generate Grid before this method.");
      return false;
    }

    // Check prefabs initialization
    if (prefabs.Count == 0)
    {
      Debug.LogWarning("prefabs lists need to have at least the tile default prefab.");
      return false;
    }

    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < cols; j++)
      {
        Tile tile;
        grid.At(out tile, i, j);

        if (i == rows / 2 && j == cols / 2)
        {
          tile.state = 2;

          Vector3 offsetPos = new Vector3(i * offsetTile, 0, j * offsetTile);
          var prefabParent = new GameObject();
          prefabParent.transform.parent = gameObject.transform;
          prefabParent.transform.position = offsetPos;
          prefabParent.name = (i * rows + j).ToString();
          InstantiatePrefab(prefabParent.transform, PrefabType.House);
        }
        else if (tile.state == -1)
        {
          tile.state = 0;

          Vector3 offsetPos = new Vector3(i * offsetTile, 0, j * offsetTile);
          var prefabParent = new GameObject();
          prefabParent.transform.parent = gameObject.transform;
          prefabParent.transform.position = offsetPos;
          prefabParent.name = (i * rows + j).ToString();
          InstantiatePrefab(prefabParent.transform, PrefabType.Tile);
        }
      }
    }

    return true;
  }

  private void InstantiatePrefab(Transform transform, PrefabType prefabType)
  {
    var newBuilding = Instantiate(prefabs[((int)prefabType)], transform);
    var buildingComponent = newBuilding.GetComponent<Building>();
    if(buildingComponent)
    {
      buildingComponent.Init();
      BuildingsManager.GetInstance().AddBuilding(buildingComponent);
    }
  }

  public void UpdateGridAt(int index, PrefabType prefabType)
  {
    var tileWrapper = gameObject.transform.GetChild(index).gameObject;
    if (tileWrapper == null)
    {
      Debug.Log("tile wrapper is null");
      return;
    }

    Tile tileComponent;
    grid.At(out tileComponent, index);
    if (tileComponent != null)
    {
      var tile = tileWrapper.transform.GetChild(0).gameObject;
      var buildingComponent = tile.GetComponent<Building>();

      // Want to display the panel information
      if (prefabType == PrefabType.None || prefabType == PrefabType.Tile)
      {
        UiManager.GetInstance().ShowInformationPanel();
        UiManager.GetInstance().UpdateInformationPanel(buildingComponent);
      }
      // Want to add new building
      else
      {
        if (tileComponent.state < 1)
        {
          UiManager.GetInstance().HideInformationPanel();
          // Destroy the previous building
          var tileToDestroy = tileWrapper.transform.GetChild(0).gameObject;
          Destroy(tileToDestroy);
          InstantiatePrefab(tileWrapper.transform, prefabType);
          tileComponent.state = ((int)prefabType);
        }
      }
    }
    else
    {
      Debug.Log("Don't find the corresponding tile current index");
    }
  }

  /**
   * Print Building info
   */
  void PrintBuidlingInfo(Building building)
  {
    string debugInfo = "";
    debugInfo += "building : " + building.GetType().ToString() + "\n";
    debugInfo += "level : " + building.Level + "\n";
    debugInfo += "Peon List :\n";
    foreach (var peon in building.Peons)
    {
      debugInfo += "  " + peon.Name + "\n";
    }

    Debug.LogWarning(debugInfo);
  }

  /**
   * Convenient method to print all informations.
   */
  public void Print(bool withDetails = false)
  {
    Debug.Log(Instance);
    grid.Print();
  }
  #endregion
}
