using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public int lives = 3;

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
		lives--;
		if (lives <= 0)
		{
			lives = 3;
			LevelManager.GameOver();
		}
	}
}
