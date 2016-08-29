using UnityEngine;
using System.Collections;

	public class Brick : MonoBehaviour {
	public int life = 1;
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

		life = Mathf.Clamp(life - damage, 0, life);

		if (life <= 0)
			Dead ();
	}

	protected virtual void Dead()
	{
		Destroy (gameObject);
		// todo plus score and play animation
	}
}
