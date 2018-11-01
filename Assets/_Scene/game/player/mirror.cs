using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		print("hit");
		if(col.tag == "Player"){
			col.GetComponent<PlayerController>().HasMirror = true;
			GetComponent<DialogueTrigger>().TriggerDialogue();
			Destroy(gameObject);
		}
	}
}
