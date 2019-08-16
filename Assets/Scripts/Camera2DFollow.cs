using UnityEngine;
using CreativeSpore.SuperTilemapEditor;
namespace UnityStandardAssets._2D {
  public class Camera2DFollow : MonoBehaviour {
    public Transform target;
    public STETilemap tilemap;

    private Vector3 currentPos;
    private Rect bounds;

    // Use this for initialization
    private void Start() {
      bounds = DisplayUtil.GetCameraBounds();
      currentPos = transform.position;
    }


    // Update is called once per frame
    private void Update() {
      bounds.x = currentPos.x;
      bounds.y = currentPos.y;






      if (target.position.x < currentPos.x - bounds.width / 2) {
        currentPos.x -= bounds.width;
      }
      if (target.position.x > currentPos.x + bounds.width / 2) {
        currentPos.x += bounds.width;
      }
      if (target.position.y < currentPos.y - bounds.height / 2) {
        currentPos.y -= bounds.height;
      }
      if (target.position.y > currentPos.y + bounds.height / 2) {
        currentPos.y += bounds.height;
      }

      transform.position = Vector3.Lerp(transform.position, currentPos, 0.08f);
    }
  }
}
