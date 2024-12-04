using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSupportExtra : MonoBehaviour
{
    private int[] ct = new int[20];
    private Animator anim = null;
    private bool isGround = false;
    private bool Jump = false;
    private bool isHead = false;
    private float jumpPos = 0.0f;
    private bool canHeight;
    private bool isJump = false;

    public float jumpHeight = 4.0f;
    public float jumpSpeed = 15.0f;
    public float gravity = 7.0f;
    public float ySpeed;
    public PlayerMovementExtra playermovement;
    public CheckingGround ground;
    public CheckingGround head;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject obj = (GameObject)Resources.Load("Coin");
        for (int i = 0; i < 20; i++)
        {
            ct[i] = 1;
        }
        if(playermovement.maxCoin <= 0)
        {
            Debug.Log("No Coin!");
        }
        else if(playermovement.maxCoin > 20)
        {
            Debug.Log("Coin Over!");
        }
        else
        {
            for (int j = 0; j < playermovement.maxCoin; j++)
            {
                int x = Random.Range(0, 20);
                if (ct[x] != 0)
                {
                    ct[x]--;
                    int y = Random.Range(0, 40);
                    Instantiate(obj, new Vector2((float)x - 7.5f, (float)y / 10f - 2.5f), Quaternion.identity);
                }
                else
                {
                    j--;
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = ground.IsGround();
        isHead = head.IsGround();
        ySpeed = -gravity;

        anim.SetBool("ground", isGround);
        anim.SetBool("jump", Jump);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("run", true);
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("run", true);
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        else
        {
            anim.SetBool("run", false);
        }

        if (isGround && !isJump)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;
                isJump = true;
            }
        }
        else if (isJump)
        {
            canHeight = transform.position.y < jumpPos + jumpHeight;
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && canHeight && !isHead)
            {
                ySpeed = jumpSpeed;
            }
            else
            {
                isJump = false;
            }
        }
    }
}