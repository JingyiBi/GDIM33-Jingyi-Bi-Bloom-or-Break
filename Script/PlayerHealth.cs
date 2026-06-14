using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 5;       
    private int currentHealth;

    [Header("UI Hearts")]
    public GameObject[] hearts;       

    [Header("Invincibility")]
    public float invincibilityTime = 1f;
    private float invincibilityTimer = 0f;

    [Header("Audio")]
    public AudioClip takeDamageSound;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI(); 
    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincibilityTimer > 0) return;

        if (takeDamageSound != null)
        {
            AudioSource.PlayClipAtPoint(takeDamageSound, transform.position);
        }

        currentHealth -= damage;
        invincibilityTimer = invincibilityTime; 

        UpdateHeartsUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}