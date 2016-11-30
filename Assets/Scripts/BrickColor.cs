using UnityEngine;
using System.Collections;

public class BrickColor : Brick
{
    public GameColor color;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
//             BallController ballCtl = col.gameObject.GetComponent<BallController>();
//             if (ballCtl.Color == color)
//             {
//                 Hurt(ballCtl.damage);
//             }
        }
    }
}
