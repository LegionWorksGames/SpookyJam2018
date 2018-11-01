using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicEnemy : MonoBehaviour {

	public float MoveSpeed = 4;
	Animator anim;
	Rigidbody2D rbody;
	public Vector3 facing;
	float speed;
	public float Range = 5;
	public float ThisPlayerDistance;
	Transform player;
	// Use this for initialization
	void Start()
	{
		facing = new Vector3(0, 1, 0);
		speed = 0;
		anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody2D>();
		this.player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 lookDirection = this.player.position - transform.position;
		this.ThisPlayerDistance = Mathf.Abs(lookDirection.magnitude);
		if (this.ThisPlayerDistance < this.Range)
		{
			float x = -Input.GetAxisRaw("Horizontal");
			float y = -Input.GetAxisRaw("Vertical");
			if (x != 0 || y != 0)
				getTransformVector(x, y);
			else
				this.speed = 0;
			handleAnimator();
			move();
		}
	}
	void getTransformVector(float x, float y)
	{
		this.facing = new Vector2(x, y).normalized;
		this.speed = this.facing.magnitude;
	}
	void handleAnimator()
	{
		anim.SetFloat("vertical", this.facing.y);
		anim.SetFloat("horizontal", this.facing.x);
		anim.SetFloat("speed", this.speed);
	}

	void move()
	{
		if (this.speed > 0)
		{
			rbody.MovePosition(transform.position + this.facing * this.MoveSpeed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			GameManager.instance.PlayerHit();
	}
}
