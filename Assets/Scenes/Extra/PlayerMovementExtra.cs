using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementExtra : MonoBehaviour
{
    //Don't Change
    public PlayerMoveSupportExtra support;
    public float speed = 10.0f;
    public int maxCoin;

    private Rigidbody2D rb = null;
    private float xSpeed;
    private float ySpeed;
    private bool clear_flag = false;
    //Change
    private int coin = 0;

    //Don't Change
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ySpeed = support.ySpeed;

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
        
        if (coin >= maxCoin && !clear_flag && maxCoin > 0 && maxCoin <= 20)
        {
            clear_flag = true;
            Debug.Log("clear");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag=="Coin")
        {
            collider.tag = "CoinGot";
            Destroy(collider.gameObject);
            //Change
            coin++;
            Debug.Log(coin);
        }
    }
}