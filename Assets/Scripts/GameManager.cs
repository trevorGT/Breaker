using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public int score = 0;
	public int life = 3;
	public float levelStartDelay = 2f;

	private int level;
	private Text levelText;
	private GameObject levelImage;
	//private bool doingSetup;
	private Text scoreText;
	private Text lifeText;
	// Use this for initialization
	void Start ()
	{
		OnLevelIsLoaded (0);
	}
	
	// Update is called once perø frame
	void Update ()
	{
	
	}

	public void OnLevelIsLoaded(int level)
	{
		Debug.Log ("test" + level);
		level++;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text>();
		levelText.text = "Level " + level;
		levelImage.SetActive (true);
		//doingSetup = true;

		Invoke ("HideLevelImage", levelStartDelay);

		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		lifeText = GameObject.Find ("LifeText").GetComponent<Text>();
	}

	private void HideLevelImage()
	{
		levelImage.SetActive (false);
		//doingSetup = false;
	}

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreText.text = "Score:" + score;
		}
	}

	public int Life
	{
		get { return life; }
		set
		{
			life = value; 
			lifeText.text = "Life:" + life;
			CheckIsLevelFaild ();
		}
	}

	void CheckIsLevelFaild()
	{
		if (life < 1)
		{
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}
}