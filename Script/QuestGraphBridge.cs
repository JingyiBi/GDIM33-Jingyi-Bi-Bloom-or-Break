using UnityEngine;

public class QuestGraphBridge : MonoBehaviour
{
    public void CatDialogueFinished()
    {
        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.UpdateQuest(QuestState.FindBoss);
        }
    }

    public void UnlockPlayerAttack()
    {
        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.UnlockAttack();
        }
    }
}