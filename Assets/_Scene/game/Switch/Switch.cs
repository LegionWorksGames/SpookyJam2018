using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    Animator anim;
    [SerializeField] GameObject wall;
    public bool switchOn;
	bool firstSwitch;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();	
	}

    private void Update()
    {
        anim.SetBool("on", switchOn);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		
        if (collision.gameObject.tag == "Player")
        {
			switchOn = !switchOn;
			if (switchOn)
            {
                wall.SetActive(false);
            }
            else
            {
                wall.SetActive(true);
            }
			if (!firstSwitch)
			{
				GetComponent<DialogueTrigger>().TriggerDialogue();
				firstSwitch = true;
			}
		}
    }
}
