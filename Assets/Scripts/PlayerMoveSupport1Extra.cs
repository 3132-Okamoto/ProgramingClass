using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSupportExtra : MonoBehaviour
{
    private Animator anim = null;
    private bool isGround = false;
    private bool Jump = false;
    private bool isHead = false;
    private float jumpPos = 0.0f;
    private bool canHeight;
    private bool isJump = false;

    public float jumpHeight = 4.0f;
    public float jumpSpeed = 15.0f;
    public float gravity=7.0f;
    public float ySpeed;
    public PlayerMovementExtra playermovement;
    public CheckingGround ground;
    public CheckingGround head;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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