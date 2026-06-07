using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [Header("Board to Destroy")]
    public GameObject boardToDestroy; 

    private bool canPickUp = false;   

    void Update()
    {
        
        if (canPickUp && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("get key, destroy board!");

            
            if (boardToDestroy != null)
            {
                Destroy(boardToDestroy);
            }

            
            Destroy(gameObject);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = true;
            Debug.Log("Press F to pick up the key.");
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }
}