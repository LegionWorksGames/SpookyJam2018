using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : MonoBehaviour {
	public GameObject Fireball;
	public GameObject FireballEmitter;
	public float FireRate = 10;
	float fireCooldown = 0;
	// Update is called once per frame
	void Update () {
		this.fireCooldown += Time.deltaTime;
		if(this.fireCooldown >= this.FireRate){
			//spawn fireball
			GameObject.Instantiate(this.Fireball, this.FireballEmitter.transform.position, Quaternion.identity);
			this.fireCooldown = 0;
		}
	}
}
