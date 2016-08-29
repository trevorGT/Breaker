using UnityEngine;
using System.Collections;

public class DyeSet: MonoBehaviour
{
	public GameColor color;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ball")
		{
			BallController ballCtl = other.gameObject.GetComponent<BallController> ();
			ballCtl.Color = color;
		}
	}
}
