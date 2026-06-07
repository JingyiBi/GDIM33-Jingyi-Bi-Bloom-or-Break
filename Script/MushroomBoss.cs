using UnityEngine;

public class MushroomBoss : MonoBehaviour
{
    public DialogueData dialogueTame;
    public DialogueData dialogueDefeat;
    public MonoBehaviour bossAttackAI;
    public Animator animator;          

    [Header("UI")]
    public GameObject pressQPrompt;     

    public void OnPlayerMadeChoice(bool isTame)
    {
        if (isTame)
        {
            FindObjectOfType<DialogueController>().StartDialogue(dialogueTame);
        }
        else
        {
            if (animator != null) animator.SetTrigger("GoFerocious");

            if (pressQPrompt != null) pressQPrompt.SetActive(false);
            
            Collider2D[] colliders = GetComponents<Collider2D>();
            foreach (Collider2D col in colliders)
            {
                if (col.isTrigger) col.enabled = false;
            }

            if (bossAttackAI != null) bossAttackAI.enabled = true;

            
            BossDamage damageScript = GetComponent<BossDamage>();
            if (damageScript != null) damageScript.enabled = true;

            FindObjectOfType<DialogueController>().StartDialogue(dialogueDefeat);
        }
    }
}