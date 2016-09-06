using UnityEngine;
using System.Collections;

public enum GameColor
{
	GC_NONE = 0,
	GC_RED = 1,
	GC_GREEN = 2,
	GC_BLUE = 3
};

public enum GameDirection
{
	GD_HORIZONTAL = 0,
	GD_VERTICAL = 1,
	GD_BOTH
}

public class BallController : MonoBehaviour
{
	public int damage;
	public Vector2 velocityLimit = new Vector2(10f, 10f);
	public Vector2 speedUp = new Vector2 (0.5f, 0.5f);
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
        }
		print ("ballVelocity:" + rgb2D.velocity);
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
			rgb2D.velocity = GetBounceVelocity(contact.normal, ballVelocity, col.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        print("OnCollisionExit2D");
    }

	Vector2 GetBounceVelocity(Vector2 normal, Vector2 velocity, GameObject colObject)
    {
		Vector2 bounceVelocity, absVelocity;

		bounceVelocity.x = normal.x != 0 ? -velocity.x : velocity.x;
		bounceVelocity.y = normal.y != 0 ? -velocity.y : velocity.y;

		bounceVelocity.x += GetSpeedUpValue(normal, colObject.tag, GameDirection.GD_HORIZONTAL);
		bounceVelocity.y += GetSpeedUpValue(normal, colObject.tag, GameDirection.GD_VERTICAL);
		// velocity limit
		absVelocity.x = Mathf.Abs(bounceVelocity.x);
		absVelocity.y = Mathf.Abs(bounceVelocity.y);
		
		absVelocity.x = Mathf.Clamp (absVelocity.y, 0, velocityLimit.x);
		absVelocity.y = Mathf.Clamp (absVelocity.y, 0, velocityLimit.y);

		bounceVelocity.x = Mathf.Sign (bounceVelocity.x) * absVelocity.x;
		bounceVelocity.y = Mathf.Sign (bounceVelocity.y) * absVelocity.y;

		return bounceVelocity;
    }

	float GetSpeedUpValue(Vector2 normal, string colTag, GameDirection direction)
	{
		float ret = 0;

		//if (colTag == "Paddle" && normal.y == 1)
		//{
			switch (direction)
			{
			case GameDirection.GD_HORIZONTAL:
				ret += speedUp.x * normal.x;
				break;
			case GameDirection.GD_VERTICAL:
				ret += speedUp.y * normal.y;
				break;
			}
		//}
		return ret;
	}
}