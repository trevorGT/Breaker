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
    private Rigidbody2D rgb2D;
    private Vector2 ballVelocity;
	// Use this for initialization
	void Awake ()
    {
        rgb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if (rgb2D.velocity != ballVelocity)
        {
            ballVelocity = rgb2D.velocity;
            print(ballVelocity);
        }
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

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
        {
            rgb2D.velocity = GetBounceVelocity(contact.normal, ballVelocity);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        print("OnCollisionExit2D");
    }

    Vector2 GetBounceVelocity(Vector2 normal, Vector2 velocity)
    {
        float bounceVelocityX, bounceVelocityY;
        bounceVelocityX = velocity.x;
        bounceVelocityY = velocity.y;

        if (normal.x != 0)
        {
            bounceVelocityX = velocity.x * -1 + normal.x * 0.5f;
        }

        if (normal.y != 0)
        {
            bounceVelocityY = velocity.y * -1 + normal.y * 0.5f;
        }

        return new Vector2(bounceVelocityX, bounceVelocityY);
    }

    
}
