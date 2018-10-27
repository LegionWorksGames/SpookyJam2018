using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Animator anim;
	Vector2 facing;
	float speed;
	// Use this for initialization
	void Start () {
		facing = new Vector2(0, 1);
		speed = 0;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		if(x != 0 || y != 0)
			getTransformVector(x, y);
		else
			this.speed = 0;
		anim.SetFloat("vertical", this.facing.y);
		anim.SetFloat("horizontal", this.facing.x);
		anim.SetFloat("speed", this.speed);
	}
	void getTransformVector(float x, float y){
		this.facing = new Vector2(x, y).normalized;
		this.speed = this.facing.magnitude;
	}
}
