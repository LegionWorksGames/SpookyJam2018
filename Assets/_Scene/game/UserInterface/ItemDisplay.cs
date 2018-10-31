using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

	PlayerController player;
	[SerializeField] Image mirror, wand, flashlight;
	[SerializeField] Sprite bigLight;
	bool hasBigLight;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		mirror.gameObject.SetActive(false);
		wand.gameObject.SetActive(false);
		hasBigLight = player.HasBigLight;
	}
	
	// Update is called once per frame
	void Update () {
		if (player)
		{
			if (mirror.gameObject.activeSelf != player.HasMirror)
			{
				mirror.gameObject.SetActive(player.HasMirror);
			}
			if (wand.gameObject.activeSelf != player.HasWand)
			{
				wand.gameObject.SetActive(player.HasWand);
			}
			if (!hasBigLight && player.HasBigLight)
			{
				flashlight.sprite = bigLight;
				hasBigLight = true;
			}
		}
	}
}
