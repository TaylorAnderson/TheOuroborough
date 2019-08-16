
using System.Collections.Generic;
using System;
using UnityEngine;

public class Snake : SnakeBlock {
  public SnakeBlock blockPrefab;


  public ItemNotification itemNotification;
  //wherein we are the first block
  [HideInInspector]
  public List<SnakeBlock> blocks = new List<SnakeBlock>();
  private SnakeBlock lastBlock;
  public int length = 4;
  private PlayerControls controls;

  private DialogueTrigger currentDialogueTrigger;

  public LayerMask solidLayers;

  public Dictionary<ItemType, int> inventory = new Dictionary<ItemType, int>();

  [HideInInspector] public List<Action> interactSubscribers = new List<Action>();

  [HideInInspector] public List<Quest> quests = new List<Quest>();
  // Start is called before the first frame update
  void Awake() {
    controls = new PlayerControls();
    controls.Gameplay.Left.performed += ctx => Move(Vector2.left);
    controls.Gameplay.Right.performed += ctx => Move(Vector2.right);
    controls.Gameplay.Up.performed += ctx => Move(Vector2.up);
    controls.Gameplay.Down.performed += ctx => Move(Vector2.down);
    controls.Gameplay.Action.performed += ctx => OnActionPressed();
    blocks.Add(this);
    for (int i = 0; i < length; i++) {
      GenerateBlock();
    }
    ItemType[] collectibles = (ItemType[])Enum.GetValues(typeof(ItemType));
    for (int i = 0; i < collectibles.Length; i++) {
      this.inventory[collectibles[i]] = 0;
    }
  }

  public void GetItem(ItemPackage collectible) {
    if (collectible.type == ItemType.None) return;
    this.inventory[collectible.type] = collectible.number;
    this.itemNotification.SetItem(collectible);
  }

  void GenerateBlock() {
    var block = Instantiate(blockPrefab.gameObject).GetComponent<SnakeBlock>();
    blocks.Add(block);
    block.snake = this;
    lastBlock = block;

  }

  public override void OnMoved(SnakeBlock block) {
    for (int i = 1; i < blocks.Count; i++) {
      blocks[i].OnMoved(i == 0 ? null : blocks[i - 1]);
    }
  }

  //normalized movement vector
  void Move(Vector2 movement) {
    var collidingWithSelf = false;
    var hits = Physics2D.RaycastAll(currentPos, movement, unit * 0.8f, snakeBlockMask);
    for (int i = 0; i < hits.Length; i++) {
      if (hits[i].collider.gameObject != this.gameObject) {
        collidingWithSelf = true;
      }
    }
    if (collidingWithSelf) return; //we aint doin none of this shit
    if (movement == Vector2.right) {
      transform.localEulerAngles = Vector3.zero;
      transform.localScale = Vector3.one;
    }
    if (movement == Vector2.down) {
      transform.localScale = Vector3.one + Vector3.down * 2;
      transform.localEulerAngles = Vector3.forward * -90;
    }
    if (movement == Vector2.up) {
      transform.localScale = Vector3.one;
      transform.localEulerAngles = Vector3.forward * 90;
    }
    if (movement == Vector2.left) {
      transform.localEulerAngles = Vector3.zero;
      transform.localScale = Vector3.one + Vector3.left * 2;
    }


    currentPos += (Vector3)movement * unit;
    OnMoved(null);
    while (!IsGrounded()) {

      for (int i = 0; i < blocks.Count; i++) {
        blocks[i].currentPos += Vector3.down * unit;
      }
    }
    this.lastPos = currentPos;
    for (int j = 1; j < blocks.Count; j++) {
      blocks[j].SetSprite();
    }



  }

  public void SubscribeToInteract(Action action) {
    this.interactSubscribers.Add(action);
  }

  public void UnsubscribeFromInteract(Action action) {
    this.interactSubscribers.Remove(action);
  }

  bool IsGrounded() {
    bool atLeastOneGrounded = false;
    for (int i = 0; i < blocks.Count; i++) {
      var filter = new ContactFilter2D();
      filter.layerMask = solidLayers;
      filter.useLayerMask = true;
      if (Physics2D.Linecast(blocks[i].currentPos, blocks[i].currentPos + Vector3.down * unit, solidLayers)) {
        atLeastOneGrounded = true;
      }
    }
    return atLeastOneGrounded;
  }


  void OnActionPressed() {
    if (this.interactSubscribers.Count == 0) return;
    var sub = this.interactSubscribers[this.interactSubscribers.Count - 1];
    sub();
  }

  private void OnTriggerEnter2D(Collider2D other) {

    var trigger = other.GetComponent<DialogueTrigger>();
    if (trigger) {
      trigger.OnPlayerEnter();
    }

    var collectible = other.GetComponent<Collectible>();
    if (collectible) {
      this.inventory[collectible.type]++;
      Destroy(collectible.gameObject);
      //do another cool thing here
    }
  }
  private void OnTriggerExit2D(Collider2D other) {
    var trigger = other.GetComponent<DialogueTrigger>();
    if (trigger) {
      trigger.OnPlayerExit();
    }
  }

  void OnEnable() {
    controls.Gameplay.Enable();
  }

  void OnDisable() {
    controls.Gameplay.Disable();
  }

}
