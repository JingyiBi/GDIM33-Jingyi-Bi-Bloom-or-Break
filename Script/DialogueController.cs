using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public void StartDialogue(DialogueData data)
    {
        if (data != null && data.sentences.Length > 0)
        {
           
            Debug.Log("os: " + data.sentences[0]);
        }
    }
}