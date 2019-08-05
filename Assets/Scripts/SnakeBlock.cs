using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBlock : MonoBehaviour
{
    [HideInInspector]
    public Vector2 lastPos = new Vector2();
    public Snake snake;

    public Sprite topLeftCorner;
    public Sprite topRightCorner;
    public Sprite bottomLeftCorner;
    public Sprite bottomRightCorner;
    public Sprite horizontal;
    public Sprite vertical;
    public Sprite tail;
    public LayerMask snakeBlockMask;
    private SpriteRenderer sprite;
    protected float unit = 8f/16f;
    // Start is called before the first frame update
    void Start() {
        this.lastPos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnMoved(SnakeBlock block) {
      this.lastPos = transform.position;
      if (block == null) {
        this.transform.position = snake.lastPos;
      }
      else {
        this.transform.position = block.lastPos;
      }


      
    }

    public void SetSprite() {

      var index = this.snake.blocks.IndexOf(this);

      if (index < this.snake.blocks.Count-1) {
        var lastBlock = this.snake.blocks[index-1];
        var nextBlock = this.snake.blocks[index+1];

        var thisPos = transform.position;
        var prevPos = lastBlock.transform.position;
        var nextPos = nextBlock.transform.position;

        if ((prevPos.y > thisPos.y && nextPos.x > thisPos.x) || (nextPos.y > thisPos.y && prevPos.x > thisPos.x)) {
          sprite.sprite = bottomLeftCorner;
        }
        if ((prevPos.y < thisPos.y && nextPos.x > thisPos.x) || (nextPos.y < thisPos.y && prevPos.x > thisPos.x)) {
          sprite.sprite = topLeftCorner;
        }
        if ((prevPos.y > thisPos.y && nextPos.x < thisPos.x) || (nextPos.y > thisPos.y && prevPos.x < thisPos.x)) {
          sprite.sprite = bottomRightCorner;
        }
        if ((prevPos.y < thisPos.y && nextPos.x < thisPos.x) || (nextPos.y < thisPos.y && prevPos.x < thisPos.x)) {
          sprite.sprite = topRightCorner;
        }
        if (Mathf.Abs(thisPos.y - prevPos.y) < 0.1f && Mathf.Abs(thisPos.y - nextPos.y) < 0.1f) {
          sprite.sprite = horizontal;
        }
        if (Mathf.Abs(thisPos.x - prevPos.x) < 0.1f && Mathf.Abs(thisPos.x - nextPos.x) < 0.1f) {
          sprite.sprite = vertical;
        }
      }
      else {
        sprite.sprite = tail;
        var blockInFront = snake.blocks[snake.blocks.Count-2];
        var blockInFrontPos = blockInFront.transform.position;
        var thisPos = transform.position;
        if (blockInFrontPos.x > thisPos.x){
          this.transform.localEulerAngles = Vector3.zero;
          this.transform.localScale = Vector3.one;
        }
        if (blockInFrontPos.x < thisPos.x) {
          this.transform.localEulerAngles = Vector3.zero;
          this.transform.localScale = Vector3.one + Vector3.left * 2;
        }
        if (blockInFrontPos.y > thisPos.y) {
          this.transform.localEulerAngles = Vector3.forward * 90;
          this.transform.localScale = Vector3.one;
        }
        if (blockInFrontPos.y < thisPos.y) {
          this.transform.localEulerAngles = Vector3.forward * 90;
          this.transform.localScale = Vector3.one + Vector3.left * 2;
        }

      }
    }
}
