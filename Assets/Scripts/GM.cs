using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData {
  public Sprite sprite;
  public string name;
}
[System.Serializable]
public class ItemDataTemp {
  public ItemType type;
  public ItemData data;
}
public class GM : MonoBehaviour {
  public static GM instance;
  [HideInInspector]
  public Dictionary<ItemType, ItemData> itemData = new Dictionary<ItemType, ItemData>();

  public List<ItemDataTemp> itemDataList;

  public Snake player;

  private void Awake() {
    GM.instance = this;
    for (int i = 0; i < itemDataList.Count; i++) {
      itemData[itemDataList[i].type] = itemDataList[i].data;
    }
  }

}
