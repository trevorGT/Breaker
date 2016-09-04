using UnityEngine;
using System.Collections;

public class BrickBomb : Brick {
	public float bombRadius = 1f;
	public int bombDamage = 2;
	private ParticleSystem explosionFX;
	// Use this for initialization
	void Start () 
	{
		explosionFX = GameObject.FindGameObjectWithTag("ExplosionFX").GetComponent<ParticleSystem>();
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
			if (br != null && br.tag == "Brick")
			{
				br.Hurt (bombDamage);
			}
		}

		explosionFX.transform.position = transform.position;
		explosionFX.Play ();
	}
	
	protected override void Dead()
	{
		Explore();
		base.Dead ();
	}
}
