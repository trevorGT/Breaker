using UnityEngine;
using System.Collections;

public enum GameColor
{
	GC_NONE = 0,
	GC_RED = 1,
	GC_GREEN = 2,
	GC_BLUE = 3
};

public class BallController : MonoBehaviour
{
	public int damage;
	private GameColor color;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameColor Color
	{
		get { return color; }
		set 
		{
			color = value;
			GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
		}
	}
}
