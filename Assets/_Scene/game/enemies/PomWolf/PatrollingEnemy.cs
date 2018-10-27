using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour {
	public Transform CurrentTarget;
	public float Speed = 5;
	Animator anim;
	Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
		this.anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 facing = CurrentTarget.position - transform.position;
		facing.Normalize();
		anim.SetFloat("horizontal", facing.x);
		anim.SetFloat("vertical", facing.y);
		rbody.MovePosition(transform.position + facing * this.Speed * Time.deltaTime);
	}
}
