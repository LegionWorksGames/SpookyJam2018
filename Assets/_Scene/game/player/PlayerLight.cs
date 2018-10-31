using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour {

	PlayerController player;
	[SerializeField] Sprite[] lights;
	SpriteMask mask;
	SpriteRenderer light;
	bool bigLight = false;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		mask = GetComponent<SpriteMask>();
		light = GetComponentInChildren<SpriteRenderer>();
	}

	void Update()
	{
		if (!bigLight && player.HasBigLight)
		{
			mask.sprite = lights[0];
			light.sprite = lights[1];
			bigLight = true;
		}
	}
}
