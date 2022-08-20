/**
 * Wrapper used to store an State to simplify potential extension.
 */
public class Tile
{
  /**
   * Represents each case of state for our tile.
   */
  public enum State
  {
    None = 0,
    Empty,
    Occuped
  }

  public State state = State.None;
}
