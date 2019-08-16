
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MyBox;


[System.Serializable]
public class ItemPackage {
  public ItemType type;
  public int number;
}

[System.Serializable]
public class Quest {
  public UnityEvent OnComplete;
  public List<string> response;
  public ItemPackage reward;

  [HideInInspector]
  public bool started = false;
  [HideInInspector]
  public bool complete = false;
  [HideInInspector]
  public bool rewardGiven = false;
}

[System.Serializable]
public class CollectQuest : Quest {
  public ItemPackage collectibleToDeliver;
}

[System.Serializable]
public class DeliveryQuest : CollectQuest {
  public Person recipient;
}



public enum QuestType {
  Collectible,
  Delivery,
}



public class Person : MonoBehaviour {
  public DialogueTrigger dialogueTrigger;

  public List<string> messages;
  public QuestType questType;

  [ConditionalField("questType", false, QuestType.Collectible)]
  public CollectQuest collectQuest;
  [ConditionalField("questType", false, QuestType.Delivery)]
  public DeliveryQuest deliveryQuest;

  [HideInInspector]
  public Quest quest;

  // Start is called before the first frame update
  void Start() {
    quest = questType == QuestType.Delivery ? deliveryQuest : collectQuest;
    transform.GetComponentInChildren<DialogueTrigger>().GetMessages += OnDialogueTriggered;

    dialogueTrigger.dialogueComplete += OnDialogueComplete;
  }

  // Update is called once per frame
  void Update() {

  }

  void OnDialogueComplete() {
    if (quest.complete && !quest.rewardGiven) {
      GM.instance.player.GetItem(quest.reward);
      GM.instance.player.quests.Remove(quest);
    }
    if (questType == QuestType.Delivery && !quest.started) {
      quest.started = true;
      GM.instance.player.GetItem(((DeliveryQuest)quest).collectibleToDeliver);
      GM.instance.player.quests.Add(quest);
    }
  }

  protected virtual List<string> OnDialogueTriggered(Snake snake) {

    if (questType == QuestType.Collectible) {
      var colQuest = (CollectQuest)quest;
      if (snake.inventory[colQuest.collectibleToDeliver.type] == colQuest.collectibleToDeliver.number && !quest.complete) {
        collectQuest.OnComplete.Invoke();
        quest.complete = true;
        GM.instance.player.quests.Remove(quest);
        return collectQuest.response;
      }
      else if (!GM.instance.player.quests.Contains(quest)) {
        GM.instance.player.quests.Add(quest);
      }
    }
    return messages;
  }
}
