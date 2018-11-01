using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingEnemy : MonoBehaviour {

	public float Speed = 5;
	Animator anim;
	Rigidbody2D rbody;
	[SerializeField] Vector2 startFacing;
	Vector3 startPosition;
	Vector3 currentFacing;
	bool charging;
	// Use this for initialization
	void Start()
	{
		this.anim = GetComponent<Animator>();
		this.rbody = GetComponent<Rigidbody2D>();
		currentFacing = startFacing;
		startPosition = transform.position;
	}
	void Update()
	{
		if (charging)
		{
			print("Doing This");
			currentFacing = startFacing;
			rbody.MovePosition(transform.position + new Vector3(startFacing.x, startFacing.y, 0) * this.Speed * Time.deltaTime);
		}
		float distance = Vector3.Distance(transform.position, startPosition);
		if (distance > 0.05f && !charging)
		{
			currentFacing = startPosition - transform.position;
			currentFacing.Normalize();
			rbody.MovePosition(transform.position + currentFacing * 1 * Time.deltaTime);
		}
		else if (distance <= 0.15f && !charging)
		{
			transform.position = startPosition;
			currentFacing = startFacing;
		}
		anim.SetFloat("horizontal", currentFacing.x);
		anim.SetFloat("vertical", currentFacing.y);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (startPosition == transform.position)
		{			
			// Cast a ray straight down.
			RaycastHit2D hit = Physics2D.Raycast(transform.position, startFacing);			
			// If it hits something...
			if (hit.collider != null)
			{
				if (hit.collider.CompareTag("Player"))
				{
					charging = true;
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
			GameManager.instance.PlayerHit();
		charging = false;
	}
}
