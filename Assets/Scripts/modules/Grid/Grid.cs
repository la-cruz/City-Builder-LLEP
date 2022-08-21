using UnityEngine;
using System.Collections;

/**
 * Basic class who represents an 2d array[rows,cols] of Tile. 
 */
public class Grid
{
  #region VARIABLES

  public int cols = 0;
  public int rows = 0;

  private Tile[] tiles;

  #endregion

  #region METHODS

  /**
   * Initialize our map of tile.
   */
  public bool Create(int _cols = 0, int _rows = 0)
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
  public void At(out Tile tile, int i, int j)
  {
    if (i >= rows || j >= cols)
    {
      Debug.LogWarning("Try to access to an out of bands case.");
      tile = null;
    }
    else
    {
      At(out tile, i * rows + j);
    }

  }

  /**
   * Get the Tile at a specific index.
   */
  public void At(out Tile tile, int index)
  {
    if (index >= rows * cols)
    {
      Debug.LogWarning("Try to access to an out of bands case.");
      tile = null;
    }
    else
    {
      tile = tiles[index];
    }
  }

  public void UpdateAt(Tile tile, int index)
  {
    tiles[index] = tile;
  }

  public string PrintTile()
  {
    string print = "";
    for (int j = 0; j < cols; j++)
    {
      for (int i = 0; i < rows; i++)
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
