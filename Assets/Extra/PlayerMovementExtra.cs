using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementExtra : MonoBehaviour
{
    public PlayerMoveSupportExtra support;
    public float speed = 10.0f;

    private Rigidbody2D rb = null;
    private float xSpeed;
    private float ySpeed;
    private int coin=0;
    private bool clear = false;
    public int MaxCoin;


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
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            xSpeed = speed;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            xSpeed = -speed;
        }
        else
        {
            xSpeed = 0.0f;
        }

        rb.velocity = new Vector2(xSpeed, ySpeed);
        if (coin >= MaxCoin && !clear)
        {
            clear = true;
            Debug.Log("clear");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag=="Coin")
        {
            collider.tag = "CoinGot";
            Destroy(collider.gameObject);
            coin++;
        }
    }
}