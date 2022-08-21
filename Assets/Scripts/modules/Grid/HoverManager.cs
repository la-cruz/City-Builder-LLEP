using UnityEngine;

public class HoverManager : MonoBehaviour {
private void OnMouseEnter() {
    gameObject.transform.position += new Vector3(0, 0.5f, 0);
  }

  private void OnMouseExit() {
    gameObject.transform.position += new Vector3(0, -0.5f, 0);
  }
}