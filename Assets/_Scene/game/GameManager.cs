using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public int lives = 3;
	public bool invulnerable;

	//Awake is always called before any Start functions
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		lives = 3;
	}

	public void PlayerHit()
	{
		// Give player 3 lives
		if (!invulnerable)
		{
			lives--;
			if (lives <= 0)
			{
				lives = 3;
				LevelManager.GameOver();
			}
			else
			{
				StartCoroutine(InvulnerableTime());
			}
		}		
	}
	IEnumerator InvulnerableTime()
	{
		invulnerable = true;
		yield return new WaitForSeconds(0.5f);
		invulnerable = false;
	}
}
