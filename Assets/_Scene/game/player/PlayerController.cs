using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public bool HasMirror = false;
	public bool HasWand = false;
	public float MoveSpeed = 5;
    bool continuousMovement, canMove = true;
	Animator anim;
    AudioSource audioSource;
	Rigidbody2D rbody;
	public Vector3 facing;
	float speed;
	// Use this for initialization
	void Start () {
		facing = new Vector3(0, 1, 0);
		speed = 0;
		anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		if(x != 0 || y != 0)
			getTransformVector(x, y);
		else
			this.speed = 0;
		if (canMove)
		{
			handleAnimator();
			move();
		}
		if (HasWand && Input.GetButtonDown("Activate"))
		{
			UseWand();
		}
	}
	void getTransformVector(float x, float y){
		this.facing = new Vector2(x, y).normalized;
		this.speed = this.facing.magnitude;
	}
	void handleAnimator(){
		anim.SetFloat("vertical", this.facing.y);
		anim.SetFloat("horizontal", this.facing.x);
		anim.SetFloat("speed", this.speed);
	}

	void move(){
		if(this.speed > 0)
        {
            if(continuousMovement == false)
            {
                audioSource.Play();
            }
            continuousMovement = true;
            rbody.MovePosition(transform.position + this.facing * this.MoveSpeed * Time.deltaTime);
        }
        else
        {
            continuousMovement = false;
            audioSource.Stop();
        }
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		
		if (coll.gameObject.tag == "Enemy")
		{
			print("Doing This");
			Vector2 dir = transform.position - coll.transform.position;
			dir.Normalize();
			rbody.AddForce(dir * 20, ForceMode2D.Impulse);
			StartCoroutine(KnockBack());
		}
	}
	IEnumerator KnockBack()
	{
		canMove = false;
		yield return new WaitForSeconds(0.05f);
		rbody.velocity = Vector2.zero;
		canMove = true;
	}

	void UseWand()
	{
		HedgeController[] hedges = FindObjectsOfType<HedgeController>();
		if (!hedges[0].PlayerInHedge() && !hedges[1].PlayerInHedge())
		{
			hedges[0].SwitchHedges();
			hedges[1].SwitchHedges();
		}
	}
}
