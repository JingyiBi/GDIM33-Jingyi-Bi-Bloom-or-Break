using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("Boss health settings")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Boss hearts UI array")]
    public GameObject[] bossHearts; 

    [Header("Audio")]
    public AudioClip takeDamageSound;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        if (!GetComponent<BossDamage>().enabled) return;

        if (takeDamageSound != null)
        {
            AudioSource.PlayClipAtPoint(takeDamageSound, transform.position);
        }

        currentHealth -= damage;
        UpdateHeartsUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < bossHearts.Length; i++)
        {
            if (i < currentHealth) bossHearts[i].SetActive(true);
            else bossHearts[i].SetActive(false);
        }
    }

    void Die()
    {
        MushroomBoss bossScript = GetComponent<MushroomBoss>();
        if (bossScript != null && bossScript.nextLevelArrow != null)
        {
            bossScript.nextLevelArrow.SetActive(true);
        }

        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.UpdateQuest(QuestState.Completed);
        }

        Destroy(gameObject); 
    }
}