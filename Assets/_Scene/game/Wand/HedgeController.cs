using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgeController : MonoBehaviour {

	CompositeCollider2D col;
	Renderer rend;
	public bool active;
	bool playerOnHedge;
	PlayerController player;

	// Use this for initialization
	void Start () {
		col = GetComponent<CompositeCollider2D>();
		rend = GetComponent<Renderer>();
		rend.enabled = active;
		col.isTrigger = !active;
		player = FindObjectOfType<PlayerController>();//.GetComponent<CapsuleCollider2D>();
	}

	void Update()
	{
		//print(gameObject.name + " " + col.bounds.Contains(player.transform.position));
		// print(gameObject.name + " " + Physics2D.IsTouching(col, player));
	}
	public bool PlayerInHedge()
	{
		print(gameObject.name + " switched " + playerOnHedge);
		return playerOnHedge;
		// print(gameObject.name + " " + col.bounds.Contains(player.transform.position));
		//return Physics2D.IsTouching(col, player.GetComponent<CapsuleCollider2D>());
	}

	public void SwitchHedges()
	{
		active = !active;
		rend.enabled = active;
		col.isTrigger = !active;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			print("Entered");
			playerOnHedge = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			print("exit");
			playerOnHedge = false;
		}
	}
}
