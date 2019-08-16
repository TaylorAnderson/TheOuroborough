using UnityEngine;

public class CameraGrid : MonoBehaviour {
  private float startX;
  private float startY;
  public float widthInUnits;
  public float heightInUnits;

  public Color gridColor;
  [ExecuteInEditMode]

  private void OnDrawGizmos() {
    startX = transform.position.x;
    startY = transform.position.y;
    var camBounds = DisplayUtil.GetCameraBounds();
    var realGridWidth = widthInUnits * camBounds.width;
    var realGridHeight = heightInUnits * camBounds.height;
    Gizmos.color = gridColor;
    for (int i = 0; i < widthInUnits + 1; i++) {
      Gizmos.DrawLine(new Vector3(i * camBounds.width + startX, startY, 0), new Vector3(i * camBounds.width + startX, realGridHeight + startY, 0));
    }

    for (int j = 0; j < heightInUnits + 1; j++) {
      Gizmos.DrawLine(new Vector3(startX, j * camBounds.height + startY, 0), new Vector3(realGridWidth + startX, j * camBounds.height + startY, 0));
    }
  }
}
