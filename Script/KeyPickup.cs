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
            if (boardToDestroy != null)
            {
                Destroy(boardToDestroy);
            }

            if (QuestManager.Instance != null)
            {
                QuestManager.Instance.SetKeyCollected();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = true;
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