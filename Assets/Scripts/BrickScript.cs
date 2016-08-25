using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	public int life = 1;
	public bool isFix = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (isFix)
			return;

		life--;
		if (life == 0)
			Destroy (gameObject);
	}
}
