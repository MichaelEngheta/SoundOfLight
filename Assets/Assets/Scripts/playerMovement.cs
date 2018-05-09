﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    private Rigidbody2D rb2D;


    private float xMove;
    public float movementSpeed;

    //vertical movement(jump)
    public float jumpHeight;
    public float jumpMultiplier;
    public float lowJumpMultiplier;
    public bool jumping;
    public float upwardJumpMultiplier;
    public bool isGrounded;


	// Use this for initialization
	void Start () {
        //this gives us access to the Rigidbody2D
        //of the gameObject this script is attached to
        rb2D = GetComponent<Rigidbody2D>();
        movementSpeed = 8;
        jumpHeight = 7;
        jumpMultiplier = 2.75f;
        lowJumpMultiplier = 2;
        upwardJumpMultiplier = 1.5f;
	}

    //The difference between Update and FixedUpdate
    //is that FixedUpdate is not dependent on the 
    //hardware. Meanwhile, Update is. Essentially,
    //the faster the computer, the more Update calls
    //are called. 
    private void FixedUpdate()
    {
        //https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-character-controllers?playlist=17120
        //Input.GetAxis returns -1 if the player presses
        //the left arrow and returns 1 if the player presses
        //the right arrow. We multiply this value to 
        //movementSpeed to affect the direction the player
        //goes to.
        xMove = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(xMove*movementSpeed, rb2D.velocity.y);

        Debug.Log(rb2D.velocity.y);
        //https://www.youtube.com/watch?v=7KiK0Aqtmzc
        //essentially increases gravity on the way down
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb2D.velocity = Vector2.up * jumpHeight * upwardJumpMultiplier;
            isGrounded = false;
        }

        if (rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


    //If the collider under the player's feet comes in contact
    //with a platform tagged as ground, isGrounded is set to 
    //true
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}