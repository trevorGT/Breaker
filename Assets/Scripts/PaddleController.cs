using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		h *= 5;
		GetComponent<Rigidbody2D> ().velocity = new Vector2(h, 0);
	}
}