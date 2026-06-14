using UnityEngine;
using TMPro; 

public enum QuestState
{
    TalkToCat,
    FindBoss,
    ChoosePath,
    TamePath,
    DefeatPath,
    Completed
}

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public TextMeshProUGUI questText; 

    private QuestState currentState;
    private bool hasKey = false;
    private bool hasFruit = false;
    private bool isAttackUnlocked = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateQuest(QuestState.TalkToCat);
    }

    public void UpdateQuest(QuestState newState)
    {
        currentState = newState;
        UpdateUI();
    }

    public void SetKeyCollected()
    {
        hasKey = true;
        UpdateUI();
    }

    public void SetFruitCollected()
    {
        hasFruit = true;
        UpdateUI();
    }

    public void UnlockAttack()
    {
        isAttackUnlocked = true;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (questText == null) return;

        string questInfo = "";

        switch (currentState)
        {
            case QuestState.TalkToCat:
                questInfo = "Main Quest:\n- Talk to the Cat NPC.";
                break;

            case QuestState.FindBoss:
                questInfo = "Main Quest:\n- Explore the area and locate the Boss.";
                break;

            case QuestState.ChoosePath:
                questInfo = "Main Quest:\n- Interact with the Boss and choose your path.";
                break;

            case QuestState.TamePath:
                questInfo = "Main Quest (Tame):\n";
                questInfo += hasKey ? " [X] Find the Key\n" : " [ ] Find the Key\n";
                questInfo += hasFruit ? " [X] Find the Fruit" : " [ ] Find the Fruit";
                
                if (hasKey && hasFruit)
                {
                    questInfo = "Main Quest (Tame):\n- Return to the Boss and deliver the Fruit.";
                }
                break;

            case QuestState.DefeatPath:
                questInfo = "Main Quest (Defeat):\n- Defeat the ferocious Mushroom Boss!";
                break;

            case QuestState.Completed:
                questInfo = "Main Quest:\n- Follow the arrow to find the door to the next level.";
                break;
        }

    

        questText.text = questInfo;
    }
}