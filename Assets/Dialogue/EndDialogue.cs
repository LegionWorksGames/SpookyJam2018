using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogue : MonoBehaviour {

    bool runOnce;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(!runOnce)
            {
                GetComponent<DialogueConversation>().TriggerDialogueConversation();
                runOnce = true;
            }
                
        }
    }
}
