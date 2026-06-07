using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("Boss health settings")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Boss hearts UI array")]
    public GameObject[] bossHearts; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        
        if (!GetComponent<BossDamage>().enabled) return;

        currentHealth -= damage;
        UpdateHeartsUI();

        Debug.Log("Boss blood: " + currentHealth);

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
        Debug.Log("Boss defeated!");
        
        Destroy(gameObject); 
    }
}
