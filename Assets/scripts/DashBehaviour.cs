using System;
using UnityEngine;

public class DashBehaviour : MonoBehaviour
{
    [Header("Dash Settings")] [SerializeField]
    private float dashingSpeed;

    [SerializeField] private float dashTime;
    [SerializeField] private float startDashTime;
    [SerializeField] private int direction;

    public float dashCooldown;
    public bool canIDash = true;


    public Rigidbody2D playerRigidBody;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update()
    {
        if (dashCooldown > 0)
        {
            canIDash = false;
            dashCooldown -= Time.deltaTime;
            //if I put saved velocity here, it will continue to move at savedVelocity until dashCooldown = 0? so it can't go here? right?
        }

        if (dashCooldown <= 0)
        {
            canIDash = true;
            //if I put savedVelocity here it doesn't return to savedVelocity until dashCooldown <=0 so... it doesn't go here either right...?
        }

        if (canIDash == true)
        {
           
            if (direction == 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightArrow) &&
                    Input.GetKeyDown(KeyCode.UpArrow))
                {
                    direction = 5;
                }
                else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.LeftArrow) &&
                         Input.GetKeyDown(KeyCode.UpArrow))
                {
                    direction = 6;
                }
                else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightArrow) &&
                         Input.GetKeyDown(KeyCode.DownArrow))
                {
                    direction = 7;
                }
                else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.LeftArrow) &&
                         Input.GetKeyDown(KeyCode.DownArrow))
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
                            dashCooldown = 2;
                            break;
                        case 2:
                            playerRigidBody.velocity = Vector2.right * dashingSpeed;
                            dashCooldown = 2;
                            break;
                        case 3:
                            playerRigidBody.velocity = Vector2.up * dashingSpeed;
                            dashCooldown = 2;
                            break;
                        case 4:
                            playerRigidBody.velocity = Vector2.down * dashingSpeed;
                            dashCooldown = 2;
                            break;
                        case 5:
                            playerRigidBody.velocity = new Vector2(1, 1) * dashingSpeed;
                            dashCooldown = 2;
                            break;
                        case 6:
                            playerRigidBody.velocity = new Vector2(-1, 1) * dashingSpeed;
                            dashCooldown = 2;
                            break;
                        case 7:
                            playerRigidBody.velocity = new Vector2(1, -1) * dashingSpeed;
                            dashCooldown = 2;
                            break;
                        case 8:
                            playerRigidBody.velocity = new Vector2(-1, -1) * dashingSpeed;
                            dashCooldown = 2;
                            break;
                    }
                }
            }

            
        }
    }
}