using UnityEngine;
using System.Collections;

public class BombBrick : Brick {
	public float bombRadius = 1f;
	public int bombDamage = 2;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Explore()
	{
		Collider2D[] brickes = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Brick"));

		foreach (Collider2D col in brickes)
		{
			Brick br = col.GetComponent<Brick> ();

			Debug.Log ("br" + br);
			if (br != null && br.tag == "Brick")
			{
				br.Hurt (bombDamage);
			}
		}
	}
	
	protected override void Dead()
	{
		Explore();
		base.Dead ();
	}
}
