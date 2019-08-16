using UnityEngine;
using UnityEngine.UI;
public class ItemNotification : MonoBehaviour {
  public SuperTextMesh textMesh;
  public Image icon;
  public HorizontalLayoutGroup layoutGroup;
  public ContentSizeFitter contentSizeFitter;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }
  public void SetItem(ItemPackage pack) {
    var data = GM.instance.itemData[pack.type];
    icon.sprite = data.sprite;
    if (pack.number == 1) {
      textMesh.text = "You got a " + data.name + "!";
    }
    else {
      textMesh.text = "You got " + pack.number + " " + data.name + "s!";
    }

    GM.instance.player.SubscribeToInteract(OnActionPressed);
    this.gameObject.SetActive(true);

    textMesh.Rebuild();



  }
  public void OnActionPressed() {
    this.gameObject.SetActive(false);
    GM.instance.player.UnsubscribeFromInteract(OnActionPressed);
  }
}
