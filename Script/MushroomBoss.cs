using UnityEngine;

public class MushroomBoss : MonoBehaviour
{
    public DialogueData dialogueTame;
    public DialogueData dialogueDefeat;
    public MonoBehaviour bossAttackAI;
    public Animator animator;          

    [Header("UI")]
    public GameObject pressQPrompt;     
    public GameObject playerHealthUI; 
    public GameObject bossHealthUI;   

    [Header("Tame Puzzle")]
    public GameObject tamePuzzleGroup; 

    void Start()
    {
        if (playerHealthUI != null) playerHealthUI.SetActive(false);
        if (bossHealthUI != null) bossHealthUI.SetActive(false);

        
        if (tamePuzzleGroup != null) tamePuzzleGroup.SetActive(false);
    }

    public void OnPlayerMadeChoice(bool isTame)
    {
        if (isTame)
        {
            Debug.Log("💥 成功按下了Tame！准备激活物品！文件夹是否为空：" + (tamePuzzleGroup == null));
            if (tamePuzzleGroup != null) tamePuzzleGroup.SetActive(true);

            
            FindObjectOfType<DialogueController>().StartDialogue(dialogueTame);
        }
        else
        {
            Debug.Log("💥 选择了击败！准备激活物品！文件夹是否为空：" + (tamePuzzleGroup == null));
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

            if (playerHealthUI != null) playerHealthUI.SetActive(true);
            if (bossHealthUI != null) bossHealthUI.SetActive(true);

            FindObjectOfType<DialogueController>().StartDialogue(dialogueDefeat);
        }
    }
}