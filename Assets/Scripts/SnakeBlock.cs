using UnityEngine;

public class SnakeBlock : MonoBehaviour {
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
  [HideInInspector]
  public Vector3 currentPos;
  protected float unit = 0.5f;
  // Start is called before the first frame update
  void Start() {
    this.lastPos = transform.position;
    this.currentPos = transform.position;

  }

  // Update is called once per frame
  void Update() {
    this.transform.position = Vector3.Lerp(transform.position, this.currentPos, 0.4f);

  }
  public virtual void OnMoved(SnakeBlock block) {
    this.lastPos = this.currentPos;
    if (block == null) {
      this.currentPos = snake.lastPos;
    }
    else {
      this.currentPos = block.lastPos;
    }



  }

  public void SetSprite() {
    if (!sprite) {
      sprite = GetComponent<SpriteRenderer>();
    }

    var index = this.snake.blocks.IndexOf(this);

    if (index < this.snake.blocks.Count - 1) {
      var lastBlock = this.snake.blocks[index - 1];
      var nextBlock = this.snake.blocks[index + 1];

      var thisPos = currentPos;
      var prevPos = lastBlock.currentPos;
      var nextPos = nextBlock.currentPos;

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
      var blockInFront = snake.blocks[snake.blocks.Count - 2];
      var blockInFrontPos = blockInFront.currentPos;
      var thisPos = currentPos;
      if (blockInFrontPos.x > thisPos.x) {
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
