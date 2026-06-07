using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public int damageAmount = 1;

   
    void Start()
    {
       
        this.enabled = false; 
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (!this.enabled) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}