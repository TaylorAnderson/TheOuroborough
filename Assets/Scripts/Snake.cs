using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : SnakeBlock
{
    public SnakeBlock blockPrefab;
    //wherein we are the first block
    [HideInInspector]
    public List<SnakeBlock> blocks = new List<SnakeBlock>();
    private SnakeBlock lastBlock;
    [HideInInspector]
    public int length = 4;
    private PlayerControls controls;
    
    public LayerMask solidLayers;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Left.performed += ctx => OnLeftPressed();
        controls.Gameplay.Right.performed += ctx => OnRightPressed();
        controls.Gameplay.Up.performed += ctx => OnUpPressed();
        controls.Gameplay.Down.performed += ctx => OnDownPressed();
        blocks.Add(this);
        for (int i = 0; i < length; i++) {
            GenerateBlock();
        }
    }

    void GenerateBlock() {
      var block = Instantiate(blockPrefab.gameObject).GetComponent<SnakeBlock>();
      blocks.Add(block);
      block.snake = this;
      lastBlock = block;
      OnMoved(null);
      
    }

    public override void OnMoved(SnakeBlock block) {
      for (int i = 1; i < blocks.Count; i++) {
          blocks[i].OnMoved(i == 0 ? null : blocks[i-1]);
      }
    }

    void CheckForFall() {

    }


  

    //normalized movement vector
    void Move(Vector2 movement) {

      var collidingWithSelf = Physics2D.Linecast(transform.position + ((Vector3) movement * unit)/1.9f, transform.position + (Vector3) movement*unit, snakeBlockMask);
      if (collidingWithSelf) return; //we aint doin none of this shit
      if (movement == Vector2.right) {
        transform.localEulerAngles = Vector3.zero;
        transform.localScale = Vector3.one;
      }
      if (movement == Vector2.down) {
        transform.localScale = Vector3.one + Vector3.down*2;
        transform.localEulerAngles = Vector3.forward * -90;
      }
      if (movement == Vector2.up) {
        transform.localScale = Vector3.one;
        transform.localEulerAngles = Vector3.forward * 90;
      }
      if (movement == Vector2.left) {
        transform.localEulerAngles = Vector3.zero;
        transform.localScale = Vector3.one + Vector3.left*2;
      }
      
      
      transform.position += (Vector3) movement * unit;
      OnMoved(null);
      while(!IsGrounded()) {
 
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].transform.position += Vector3.down * unit;
        }
      }
      this.lastPos = transform.position;
      for (int j = 1; j < blocks.Count; j++) {
        blocks[j].SetSprite();
      }

      

    }

    bool IsGrounded(){
      bool atLeastOneGrounded = false;
      for (int i = 0; i < blocks.Count; i++){
        var filter = new ContactFilter2D();
        filter.layerMask = solidLayers;
        filter.useLayerMask = true;
        if (Physics2D.Linecast(blocks[i].transform.position, blocks[i].transform.position + Vector3.down * unit, solidLayers)) {
          atLeastOneGrounded = true;
        }
      }
      return atLeastOneGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnLeftPressed() {
      Move(Vector2.left);
      transform.localEulerAngles = Vector3.zero;
      transform.localScale = Vector3.one + Vector3.left*2;
    }
    void OnRightPressed() {
      Move(Vector2.right);
      transform.localEulerAngles = Vector3.zero;
      transform.localScale = Vector3.one;
    }
    void OnDownPressed() {
      Move(Vector2.down);
      transform.localScale = Vector3.one + Vector3.down*2;
      transform.localEulerAngles = Vector3.forward * -90;
    }
    void OnUpPressed() {
      Move(Vector2.up);
      transform.localScale = Vector3.one;
      transform.localEulerAngles = Vector3.forward * 90;
    }

    void OnEnable() {
      controls.Gameplay.Enable();
    }
    void OnDisable() {
      controls.Gameplay.Disable();
    }

}
