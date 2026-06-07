using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("state")]
    public string currentRoute = "None"; 
    public int questStage = 0; 

    [Header("buff states")]
    public bool hasKey = false;      
    public bool hasTameItem = false;  
    public bool hasDefeatBuff = false;

    [Header("UI")]
    public GameObject choiceUI; 

    
    public void SelectTameRoute()
    {
        currentRoute = "Tame";
        questStage = 1; 
        if (choiceUI != null) choiceUI.SetActive(false); 
        Debug.Log("【player choose Tame]");
    }

    
    public void SelectDefeatRoute()
    {
        currentRoute = "Defeat";
        questStage = 1; 
        if (choiceUI != null) choiceUI.SetActive(false); 
        Debug.Log("【player choose Defeat]");
    }
}