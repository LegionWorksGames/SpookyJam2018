using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	public float Speed = 10;
	public Vector3 Direction = new Vector3(-1, 0, 0);
	public Transform Daddy;
	public float RangeFromDaddy;
	public TargetType target = TargetType.player;
	Rigidbody2D rbody;
	// Use this for initialization
	public void init(Transform d, float rd, Vector3 ld){
		this.Daddy = d;
		this.RangeFromDaddy = rd;
		this.Direction = ld;
	}
	void Start () {
		this.rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rbody.MovePosition(transform.position + this.Direction * this.Speed * Time.deltaTime);
		if(Mathf.Abs((transform.position - this.Daddy.position).magnitude) > this.RangeFromDaddy)
			Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(this.target == TargetType.player){
			if(col.tag == "Player"){
				PlayerController player = col.GetComponent<PlayerController>();
				if(player.HasMirror){
					this.Direction = player.facing;
					this.target = TargetType.enemy;
				}
				else
					GameManager.instance.PlayerHit();
			}
		}
		else if(this.target == TargetType.enemy){
			if(col.tag == "Enemy"){
				Destroy(col.gameObject);
			}
			Destroy(gameObject);
		} 
	}
}

public enum TargetType{
	player, enemy
}
