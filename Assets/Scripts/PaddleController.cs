using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float paddleSpeed = .2f;
	public GameObject ballPrefab;
	private GameObject newBall = null;
	public float ballForce = 200f;
	// Use this for initialization
	void Start ()
	{
		SpawnBall ();
	}

	public void SpawnBall()
	{
		if (ballPrefab == null)
		{
			Debug.Log ("add Ball Prefab!");
			return;
		}

		Vector3 ballPosition = GetBallInitPosition();
		newBall = Instantiate(ballPrefab, ballPosition, Quaternion.identity) as GameObject	;
		newBall.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void FixedUpdate()
	{
		//transform.Translate (paddleSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"), 0, 0);
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		var pos = transform.position;
		pos.x = Mathf.Clamp (xPos, -2f, 2f);
		transform.position = pos;

		if (newBall)
		{
			Rigidbody2D ballRigidbody = newBall.GetComponent<Rigidbody2D> ();
			//ballRigidbody.position = GetBallInitPosition();
			if (Input.GetButtonDown ("Jump"))
			{
				//ballRigidbody.isKinematic = false;
				newBall.transform.parent = null;

				Rigidbody2D rgb2d = newBall.GetComponent<Rigidbody2D> ();
                //rgb2d.AddForce (new Vector2 (0, ballForce));
				rgb2d.velocity = new Vector2(0, 6);
                newBall = null;
			}
		}
	}

	Vector3 GetBallInitPosition()
	{
		return transform.position + new Vector3 (0, 0.4f, 0);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		foreach (ContactPoint2D contact in col.contacts)
		{
			if (contact.otherCollider == GetComponent<BoxCollider2D>())
			{
                float calc = contact.point.x - transform.position.x;
                //contact.collider.GetComponent<Rigidbody2D> ().AddForce(new Vector2(ballForce * calc, 0.0f));
            }
		}
	}
}