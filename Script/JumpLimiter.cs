using UnityEngine;

public class JumpLimiter : MonoBehaviour
{
    public int maxJumps = 2; 
    private int jumpCount = 0;

    
    public bool CanJump()
    {
        return jumpCount < maxJumps;
    }

   
    public void AddJumpCount()
    {
        jumpCount++;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 确保你的地面物体 Tag 设为了 "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}