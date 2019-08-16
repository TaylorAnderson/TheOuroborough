
using System;
using System.Collections.Generic;
using UnityEngine;


public delegate List<string> DialogueTriggered(Snake snake);

public class DialogueTrigger : MonoBehaviour {
  private SpriteRenderer parent;
  private SpriteRenderer dialoguePrompt;
  public GameObject dialoguePromptPrefab;
  public GameObject dialogueBoxPrefab;
  [HideInInspector]
  public bool inRange = false; // touched by Snake.cs

  public DialogueTriggered GetMessages;
  public bool dialogueShown = false;
  private DialogueBox currentDialogueBox;
  public Action dialogueComplete;

  // Start is called before the first frame update
  void Start() {
    parent = transform.parent.GetComponent<SpriteRenderer>();

    dialoguePrompt = Instantiate(dialoguePromptPrefab).GetComponent<SpriteRenderer>();
    dialoguePrompt.transform.parent = parent.transform;

    dialoguePrompt.transform.position = parent.transform.position + Vector3.up * (parent.bounds.size.y / 2 + dialoguePrompt.bounds.size.y);
    dialoguePrompt.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update() {
    dialoguePrompt.gameObject.SetActive(inRange && !dialogueShown && GM.instance.player.interactSubscribers[GM.instance.player.interactSubscribers.Count - 1] == this.OnActionPressed);
  }


  public void OnPlayerEnter() {
    GM.instance.player.SubscribeToInteract(OnActionPressed);
    inRange = true;
  }
  public void OnPlayerExit() {
    GM.instance.player.UnsubscribeFromInteract(OnActionPressed);
    inRange = false;
    Debug.Log("hello");
  }

  public void OnActionPressed() {
    if (GetMessages != null && !dialogueShown) {
      dialogueShown = true;
      var messages = GetMessages(GM.instance.player);
      var dialogueBox = Instantiate(dialogueBoxPrefab).GetComponent<DialogueBox>();
      this.currentDialogueBox = dialogueBox;
      dialogueBox.Init(messages);
      var pos = parent.transform.position + Vector3.up * (parent.bounds.size.y + 1);
      var roundedX = Mathf.Round(pos.x) + 0.1f;
      var roundedY = Mathf.Round(pos.y) + 0.1f;
      dialogueBox.transform.position = Vector3.right * roundedX + Vector3.up * roundedY;
      dialogueBox.finishedReadingCallback += OnFinishedReading;



    }
    if (dialogueShown) {
      currentDialogueBox.Advance();
    }
  }
  void OnFinishedReading() {
    dialogueShown = false;
    if (dialogueComplete != null) {
      dialogueComplete();
    }
  }
  float RoundToInterval(float number, float interval) {
    return Mathf.Round(number / interval) * interval;
  }
}
