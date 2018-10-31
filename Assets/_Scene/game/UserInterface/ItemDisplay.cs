using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

	PlayerController player;
	[SerializeField] Image mirror;
	bool hasMirror;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		mirror.enabled = hasMirror;
	}
	
	// Update is called once per frame
	void Update () {
		if (player)
		{
			if (hasMirror != player.HasMirror)
			{
				hasMirror = player.HasMirror;
				mirror.enabled = hasMirror;
			}
		}
	}
}
