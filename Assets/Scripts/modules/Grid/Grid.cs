using UnityEngine;
using System.Collections;

/**
 * Basic class who represents an 2d array[rows,cols] of Tile. 
 */
public class Grid
{
  #region VARIABLES

  public uint cols = 0;
  public uint rows = 0;

  private Tile[] tiles;

  #endregion

  #region METHODS

  /**
   * Initialize our map of tile.
   */
  public bool Create(uint _cols = 0, uint _rows = 0)
  {
    if (tiles != null)
    {
      Debug.LogWarning("We already have a tiles map.");
      return false;
    }

    cols = _cols;
    rows = _rows;

    tiles = new Tile[cols * rows];

    for (uint j = 0; j < cols; j++)
    {
      for (uint i = 0; i < rows; i++)
      {
        tiles[i * rows + j] = new Tile();
      }
    }

    return true;
  }

  /**
   * Clear tiles map, to reuse this object you need to call
   * Create before any other methods.
   */
  public void Clear()
  {
    rows = 0;
    cols = 0;
  }

  /**
   * Get the Tile at a specific position.
   */
  public bool At(Tile tile, uint i, uint j)
  {
    if (i >= rows || j >= cols)
    {
      Debug.LogWarning("Try to access to an out of bands case.");
      return false;
    }

    return At(tile, i * rows + j);
  }

  /**
   * Get the Tile at a specific index.
   */
  public bool At(Tile tile, uint index)
  {
    if (index >= rows * cols)
    {
      Debug.LogWarning("Try to access to an out of bands case.");
      return false;
    }

    tile = tiles[index];
    return true;
  }

  public string PrintTile()
  {
    string print = "";
    for (uint j = 0; j < cols; j++)
    {
      for (uint i = 0; i < rows; i++)
      {
        print += tiles[i * rows + j].state + " ";
      }
      print += "\n";
    }

    return print;
  }

  /**
   * Convenient method to print all informations.
   */
  public void Print(bool withDetails = false)
  {
    Debug.Log("cols : " + cols);
    Debug.Log("rows : " + rows);
    Debug.Log("tiles : \n" + PrintTile());
  }
  #endregion
}
