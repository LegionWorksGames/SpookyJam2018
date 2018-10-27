using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : MonoBehaviour {
	public GameObject Fireball;
	public GameObject FireballEmitter;
	public float FireRate = 10;
	public float Range = 5;
	public float DespawnRange = 50;
	public float fireCooldown = 0;
	Transform player;
	public float ThisPlayerDistance;
	void Start(){
		this.player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void Update () {
		Vector3 lookDirection = this.player.position - transform.position;
		this.ThisPlayerDistance = Mathf.Abs(lookDirection.magnitude);
		if(this.fireCooldown > 0 )
			this.fireCooldown -= Time.deltaTime;
		if(this.fireCooldown < 0)
			this.fireCooldown = 0;
		if(this.ThisPlayerDistance < this.Range){
			if(this.fireCooldown == 0){
				spawnFireball(lookDirection);
				this.fireCooldown = this.FireRate;
			}
		}		
	}
	void spawnFireball(Vector3 lookDirection){
		GameObject f = GameObject.Instantiate(this.Fireball, this.FireballEmitter.transform.position, Quaternion.identity);
		f.GetComponent<Fireball>().init(this.transform, this.DespawnRange, lookDirection.normalized);
	}
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position, this.Range);
	}
}
