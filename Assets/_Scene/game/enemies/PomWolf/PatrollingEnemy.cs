using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour {
	Transform currentTarget;
	public GameObject Targets;
	public int currentTargetInt = 0;
	public Transform[] targetsList;
	public float Speed = 5;
	Animator anim;
	Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
		this.anim = GetComponent<Animator>();
		this.rbody = GetComponent<Rigidbody2D>();
		var temp = this.Targets.GetComponentsInChildren<Transform>();
		List<Transform> t = new List<Transform>();
		for(int i = 0; i < temp.Length; i++){
			if(i > 0){
				t.Add(temp[i]);
			}
		}
		t.Sort((Transform a, Transform b) => {
			return a.name.CompareTo(b.name);
		});
		this.targetsList = t.ToArray();guiText
		this.currentTarget = this.targetsList[0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 facing = currentTarget.position - transform.position;
		facing.Normalize();
		anim.SetFloat("horizontal", facing.x);
		anim.SetFloat("vertical", facing.y);
		if(Mathf.Abs((transform.position - currentTarget.position).magnitude) > .1){
			rbody.MovePosition(transform.position + facing * this.Speed * Time.deltaTime);
		}
		else{
			this.currentTargetInt++;
			if(this.currentTargetInt >= this.targetsList.Length)
				this.currentTargetInt = 0;
			this.currentTarget = this.targetsList[this.currentTargetInt];
		}
		
	}
}
