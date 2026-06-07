using UnityEngine;
using UnityEngine.UI; // 依然需要UI命名空间
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("heart")]
    public int maxHealth = 5;       
    private int currentHealth;

    [Header("heart ")]
    
    public GameObject[] hearts;       

    [Header("invincibility")]
    public float invincibilityTime = 1f;
    private float invincibilityTimer = 0f;

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

        currentHealth -= damage;
        invincibilityTimer = invincibilityTime; 

        
        UpdateHeartsUI();

        Debug.Log("remaining health: " + currentHealth);

        
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
        Debug.Log("Player died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}