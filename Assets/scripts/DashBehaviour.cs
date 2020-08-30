using System;
using UnityEngine;

public class DashBehaviour : MonoBehaviour
{
    public float dashCooldown;
    public bool canIDash = true;
    public float dashSpeed;
    public Vector2 savedVelocity;
    public Rigidbody2D playerRigidBody;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(playerRigidBody.velocity);
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && canIDash == true)
        {
            //saves velocity prior to dashing
           
            //this part is the actual dash itself
            playerRigidBody.AddForce(new Vector2( dashSpeed, 0),ForceMode2D.Impulse);
            //sets up a cooldown so you have to wait to dash again
            dashCooldown = 2;
        }
    }
}