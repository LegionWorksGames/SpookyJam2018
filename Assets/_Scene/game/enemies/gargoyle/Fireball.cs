using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	public float Speed = 10;
	public Vector3 Direction = new Vector3(-1, 0, 0);
	Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
		this.rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rbody.MovePosition(transform.position + this.Direction * this.Speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			LevelManager.GameOver();
		}
		Destroy(gameObject);
	}
}
