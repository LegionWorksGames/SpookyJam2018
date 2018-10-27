using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueConversation : MonoBehaviour {

	DialogueTrigger[] dialogues;
	int currentDialogue;
	public bool trigger;

	// Use this for initialization
	void Start () {
		dialogues = GetComponents<DialogueTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!DialogueManager.instance.dialogueRunning && trigger)
		{
			Invoke("RunNextDialogue", 1);
			DialogueManager.instance.dialogueRunning = true;
		}
	}
    public void TriggerDialogueConversation()
    {
        trigger = true;
    }


    void RunNextDialogue()
	{
		if (currentDialogue < dialogues.Length)
		{
			dialogues[currentDialogue].TriggerDialogue();
			currentDialogue++;
		}
        else 
        {
            SceneManager.LoadScene("03a Win");
        }
       
	}
}
