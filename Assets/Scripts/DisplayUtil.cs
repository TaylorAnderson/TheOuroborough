using UnityEngine;

public class DisplayUtil {
  // Start is called before the first frame update
  public static Rect GetCameraBounds() {
    var c = Camera.main;
    var o = c.orthographicSize * 2;
    return new Rect(c.transform.position.x - (o * c.aspect) / 2, c.transform.position.y - o / 2, o * c.aspect, o);
  }
}
