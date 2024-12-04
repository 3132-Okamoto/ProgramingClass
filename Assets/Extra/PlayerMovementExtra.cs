using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementExtra : MonoBehaviour
{
    public PlayerMoveSupportExtra support;
    public float speed = 10.0f;
    public int maxCoin;

    private Rigidbody2D rb = null;
    private float xSpeed;
    private float ySpeed;
    private bool clear_flag = false;
    //intŒ^‚Ì•Ï”coin‚ğéŒ¾‚µA0‚É‰Šú‰»


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

        if (maxCoin <= 0 || maxCoin > 20)
        {
            ;
        }
        else if (false/*false‚ğÁ‚µ‚Ä‚±‚±‚ÉğŒ‚ğ‘‚­*/ && !clear_flag)
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
            //‚±‚±‚ğ‘‚­
        }
    }
}