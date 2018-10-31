using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour {

	[SerializeField] Image[] hearts;
	int health;

	// Use this for initialization
	void Start () {
		UpdateHeartDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		if (health != GameManager.instance.lives)
			UpdateHeartDisplay();
	}

	void UpdateHeartDisplay()
	{
		health = GameManager.instance.lives;
		switch (health)
		{
			case 0:
				hearts[0].color = new Color(1, 1, 1, 0.25f);
				hearts[1].color = new Color(1, 1, 1, 0.25f);
				hearts[2].color = new Color(1, 1, 1, 0.25f);
				break;
			case 1:
				hearts[0].color = new Color(1, 1, 1, 1);
				hearts[1].color = new Color(1, 1, 1, 0.25f);
				hearts[2].color = new Color(1, 1, 1, 0.25f);
				break;
			case 2:
				hearts[0].color = new Color(1, 1, 1, 1);
				hearts[1].color = new Color(1, 1, 1, 1);
				hearts[2].color = new Color(1, 1, 1, 0.25f);
				break;
			case 3:
				hearts[0].color = new Color(1, 1, 1, 1);
				hearts[1].color = new Color(1, 1, 1, 1);
				hearts[2].color = new Color(1, 1, 1, 1);
				break;
			default:
				Debug.LogWarning("Out of range");
				break;
		}
	}
}
