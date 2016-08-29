using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int totalScore = 0;
	public int totalLive = 3;

	private int level;
	public float levelStartDelay = 2f;
	private Text levelText;
	private GameObject levelImage;
	private bool doingSetup;
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
		Debug.Log ("test");
		level++;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text>();
		levelText.text = "Level " + level;
		levelImage.SetActive (true);
		doingSetup = true;

		Invoke ("HideLevelImage", levelStartDelay);
	}

	private void HideLevelImage()
	{
		levelImage.SetActive (false);
		doingSetup = false;
	}
}