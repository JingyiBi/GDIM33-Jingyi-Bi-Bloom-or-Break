using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("攻击设置")]
    
    public KeyCode attackKey = KeyCode.Mouse1; 
    public float attackRange = 1.5f;      
    public Transform attackPoint;         

    void Update()
    {
        
        if (Input.GetKeyDown(attackKey))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (attackPoint == null) return;

        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            // 如果打到的是 Boss
            if (enemy.CompareTag("Boss"))
            {
                BossHealth bossHealth = enemy.GetComponent<BossHealth>();
                if (bossHealth != null)
                {
                    bossHealth.TakeDamage(1); 
                }
            }
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
