using UnityEngine;
using System.Collections;

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
      GenerateGrid(rows, cols);
      Print();
    }
    else
    {
      Destroy(this);
    }
  }

  #endregion

  #region METHODS

  /**
   * Generate a new Grid only if there is not grid already created.
   */
  public bool GenerateGrid(uint rows = 10, uint cols = 10)
  {
    return grid.Create(rows, cols);
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
