using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("StartingDialogue", 0.5f);
	}

	private void StartingDialogue()
	{
		GetComponent<DialogueTrigger>().TriggerDialogue();
	}
}
