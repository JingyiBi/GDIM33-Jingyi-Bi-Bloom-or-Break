using UnityEngine;

public class MushroomBoss : MonoBehaviour
{
    public DialogueData dialogueTame;   
    public DialogueData dialogueDefeat; 
    
    [Header("Ending Config")]
    public DialogueData dialogueThanks; 
    public GameObject nextLevelArrow;   

    public MonoBehaviour bossAttackAI;
    public Animator animator;          

    [Header("UI Prompt Management")]
    public GameObject pressQPrompt;     
    public GameObject pressFPrompt;     

    [Header("Health UI")]
    public GameObject playerHealthUI; 
    public GameObject bossHealthUI;   

    [Header("Tame Route Puzzle")]
    public GameObject tamePuzzleGroup; 

    [Header("Audio")]
    public AudioClip bossRoarSound;
    public AudioClip bossVanishSound;

    private bool isWaitingForFruit = false; 
    private bool playerHasFruit = false;    
    private bool playerNearBoss = false;    
    private bool hasMadeChoice = false; 

    void Start()
    {
        if (playerHealthUI != null) playerHealthUI.SetActive(false);
        if (bossHealthUI != null) bossHealthUI.SetActive(false);
        if (tamePuzzleGroup != null) tamePuzzleGroup.SetActive(false);
        if (nextLevelArrow != null) nextLevelArrow.SetActive(false);
        if (pressFPrompt != null) pressFPrompt.SetActive(false); 
    }

    void Update()
    {
        if (hasMadeChoice && pressQPrompt != null && pressQPrompt.activeSelf)
        {
            pressQPrompt.SetActive(false);
        }

        if (isWaitingForFruit && playerHasFruit && playerNearBoss)
        {
            if (pressFPrompt != null) pressFPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                FinishTameQuest();
            }
        }
        else
        {
            if (pressFPrompt != null) pressFPrompt.SetActive(false);
        }
    }

    public void ReceiveFruitFromPlayer()
    {
        playerHasFruit = true;
    }

    private void FinishTameQuest()
    {
        if (pressFPrompt != null) pressFPrompt.SetActive(false); 

        if (bossVanishSound != null)
        {
            AudioSource.PlayClipAtPoint(bossVanishSound, Camera.main.transform.position);
        }

        if (dialogueThanks != null) 
        {
            FindObjectOfType<DialogueController>().StartDialogue(dialogueThanks);
        }
        if (nextLevelArrow != null) nextLevelArrow.SetActive(true);

        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.UpdateQuest(QuestState.Completed);
        }

        gameObject.SetActive(false); 
    }

    public void OnPlayerMadeChoice(bool isTame)
    {
        hasMadeChoice = true; 
        
        if (pressQPrompt != null) pressQPrompt.SetActive(false); 

        if (isTame)
        {
            if (QuestManager.Instance != null)
            {
                QuestManager.Instance.UpdateQuest(QuestState.TamePath);
            }

            if (tamePuzzleGroup != null) tamePuzzleGroup.SetActive(true);
            FindObjectOfType<DialogueController>().StartDialogue(dialogueTame);
            isWaitingForFruit = true; 
        }
        else
        {
            if (QuestManager.Instance != null)
            {
                QuestManager.Instance.UpdateQuest(QuestState.DefeatPath);
                QuestManager.Instance.UnlockAttack();
            }

            if (bossRoarSound != null)
            {
                AudioSource.PlayClipAtPoint(bossRoarSound, Camera.main.transform.position);
            }

            if (animator != null) animator.SetTrigger("GoFerocious");
            
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerNearBoss = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) playerNearBoss = false;
    }
}