using UnityEngine;

public class FruitPickup : MonoBehaviour
{
    public MushroomBoss bossScript;
    public GameObject keyObject; 
    public GameObject promptPickUp;  
    public GameObject promptNeedKey; 
    
    [Header("Audio")]
    public AudioClip pickupSound; 

    private bool canPickUp = false;

    void Start()
    {
        if (promptPickUp != null) promptPickUp.SetActive(false);
        if (promptNeedKey != null) promptNeedKey.SetActive(false);
    }

    void Update()
    {
        if (canPickUp && keyObject == null && Input.GetKeyDown(KeyCode.F))
        {
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            }

            if (bossScript != null)
            {
                bossScript.ReceiveFruitFromPlayer();
            }

            if (QuestManager.Instance != null)
            {
                QuestManager.Instance.SetFruitCollected();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (keyObject == null)
            {
                canPickUp = true;
                if (promptPickUp != null) promptPickUp.SetActive(true);     
                if (promptNeedKey != null) promptNeedKey.SetActive(false);  
            }
            else
            {
                canPickUp = false;
                if (promptPickUp != null) promptPickUp.SetActive(false);    
                if (promptNeedKey != null) promptNeedKey.SetActive(true);   
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = false;
            if (promptPickUp != null) promptPickUp.SetActive(false);
            if (promptNeedKey != null) promptNeedKey.SetActive(false);
        }
    }
}