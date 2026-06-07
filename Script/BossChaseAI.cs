using UnityEngine;

public class BossChaseAI : MonoBehaviour
{
    [Header("chase speed")]
    public float speed = 2.5f; 

    
    private float customScaleX = 8.2141f;
    private float customScaleY = 9.1117f;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        if (player != null)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            
            if (player.position.x > transform.position.x)
            {
                
                transform.localScale = new Vector3(customScaleX, customScaleY, 1); 
            }
            else if (player.position.x < transform.position.x)
            {
                
                transform.localScale = new Vector3(-customScaleX, customScaleY, 1); 
            }
        }
    }
}