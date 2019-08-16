using System.Collections.Generic;
using UnityEngine;

public delegate void FinishReading();
public class DialogueBox : MonoBehaviour {

  private SuperTextMesh textMesh;
  public SpriteRenderer boxSprite;
  private List<string> messages;
  private int messageIndex = 0;
  public GameObject box;
  public FinishReading finishedReadingCallback;
  // Start is called before the first frame update
  void Start() {
    var camBounds = DisplayUtil.GetCameraBounds();
    while (boxSprite.transform.position.x - boxSprite.bounds.size.x / 2 < camBounds.xMin) {
      box.transform.position += Vector3.right * 0.1f;
    }
    while (boxSprite.transform.position.x + boxSprite.bounds.size.x / 2 > camBounds.xMax) {
      box.transform.position += Vector3.left * 0.1f;
    }
  }

  // Update is called once per frame
  void Update() {

  }

  public void Init(List<string> messages) {
    textMesh = GetComponentInChildren<SuperTextMesh>();
    this.messages = messages;
    textMesh.text = messages[0];
  }
  public void Advance() {
    if (textMesh.reading) {
      textMesh.SkipToEnd();
    }
    else {
      if (messageIndex < messages.Count - 1) {
        messageIndex++;
        textMesh.text = messages[messageIndex];
        textMesh.Rebuild();
      }
      else {
        if (finishedReadingCallback != null) {
          finishedReadingCallback();
        }
        Destroy(this.gameObject);
      }

    }
  }
}
