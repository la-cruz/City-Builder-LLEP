using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
  public uint cols = 5;
  public uint rows = 5;

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
  public bool GenerateGrid(uint rows = 10, uint cols = 10)
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

    for (uint i = 0; i < rows; i++)
    {
      for (uint j = 0; j < cols; j++)
      {
        Tile tile = new Tile();
        grid.At(tile, i, j);


        if (i == rows / 2 && j == cols / 2)
        {
          tile.state = 2;

          Vector3 offsetPos = new Vector3(i * offsetTile, 0, j * offsetTile);
          var prefabParent = new GameObject();
          prefabParent.transform.parent = gameObject.transform;
          prefabParent.transform.position = offsetPos;
          prefabParent.name = (i * rows + j).ToString();
          var newHouse = Instantiate(prefabs[2], prefabParent.transform);
          var houseComponent = newHouse.GetComponent<House>();
          if(houseComponent)
          {
            houseComponent.Init();
            BuildingsManager.GetInstance().AddBuilding(houseComponent);
          }

        }
        else if (tile.state == -1)
        {
          tile.state = 0;

          Vector3 offsetPos = new Vector3(i * offsetTile, 0, j * offsetTile);
          var prefabParent = new GameObject();
          prefabParent.transform.parent = gameObject.transform;
          prefabParent.transform.position = offsetPos;
          prefabParent.name = (i * rows + j).ToString();
          Instantiate(prefabs[0], prefabParent.transform);
        }
      }
    }



    return true;
  }

  public void UpdateGridAt(int index)
  {
    Debug.Log("index : " + index);
    Debug.Log("UpdateGridAt : " + gameObject.transform.GetChild(index).gameObject.name);
    var tile = gameObject.transform.GetChild(index).gameObject;
    if (tile)
    {
      var tileToDestroy = tile.transform.GetChild(0).gameObject;
      Destroy(tileToDestroy);
      Instantiate(prefabs[1], tile.transform.position, Quaternion.identity, tile.transform);
    }
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
