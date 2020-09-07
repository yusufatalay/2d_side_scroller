using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class JumpBehaviour : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private int jumpCount;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            if (isGrounded)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x,0);
                playerRigidBody.AddForce(new Vector2(0, jumpForce));
                jumpCount++;
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0);
                    playerRigidBody.AddForce(new Vector2(0, jumpForce));
                    jumpCount++;
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("wall"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
        
    }
}
