using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFlashLight : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		print("hit");
		if (col.tag == "Player")
		{
			col.GetComponent<PlayerController>().HasBigLight = true;
			Destroy(gameObject);
		}
	}
}
