using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerMoveSupport support;
    public float speed = 10.0f;

    private Rigidbody2D rb = null;
    private float xSpeed;
    private float ySpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Don't Change
        ySpeed = support.ySpeed;

        //Change
        if (false/*false‚ğÁ‚µ‚Ä‚±‚±‚ÉğŒ‚ğ‘‚­*/)
        {
            xSpeed = speed;
        }

        rb.velocity = new Vector2(xSpeed, ySpeed);
    }
}