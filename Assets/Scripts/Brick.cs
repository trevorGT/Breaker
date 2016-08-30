using UnityEngine;
using System.Collections;

	public class Brick : MonoBehaviour {
	public int health = 1;
	public int score = 1;
	public bool isFix = false;
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
			BallController ballCtl = col.gameObject.GetComponent<BallController> ();
			Hurt (ballCtl.damage);
		}
	}

	public void Hurt(int damage = 1)
	{
		if (isFix)
			return;

		health = Mathf.Clamp(health - damage, 0, health);

		if (health <= 0)
			Dead ();
	}

	protected virtual void Dead()
	{
		// todo plus score and play animation
		GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		gm.Score += score;
		Destroy (gameObject);
	}
}
