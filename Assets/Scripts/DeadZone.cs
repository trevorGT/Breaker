using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ball")
		{
			Destroy (col.gameObject);
			GameObject paddle = GameObject.Find ("Paddle");
			PaddleController paddleController = paddle.GetComponent<PaddleController> ();
			paddleController.SpawnBall ();

			GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
			gm.Life -= 1;
		}
	}
}