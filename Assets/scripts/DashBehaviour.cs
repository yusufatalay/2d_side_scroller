using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;

    [Header("Dash Settings")] [SerializeField] private float dashingSpeed;

    [SerializeField] private float dashTime;
    [SerializeField] private float startDashTime;
    [SerializeField] private int direction;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 5;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 6;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 7;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 8;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }
            else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                playerRigidBody.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                switch (direction)
                {
                    case 1:
                        playerRigidBody.velocity = Vector2.left * dashingSpeed;
                        break;
                    case 2:
                        playerRigidBody.velocity = Vector2.right * dashingSpeed;
                        break;
                    case 3:
                        playerRigidBody.velocity = Vector2.up * dashingSpeed;
                        break;
                    case 4:
                        playerRigidBody.velocity = Vector2.down * dashingSpeed;
                        break;
                    case 5:
                        playerRigidBody.velocity = new Vector2(1,1) * dashingSpeed;
                        break;
                    case 6:
                        playerRigidBody.velocity = new Vector2(-1,1) * dashingSpeed;
                        break;
                    case 7:
                        playerRigidBody.velocity = new Vector2(1,-1) * dashingSpeed;
                        break;
                    case 8:
                        playerRigidBody.velocity = new Vector2(-1,-1) * dashingSpeed;
                        break;
                }
                
            }
        }
    }
}