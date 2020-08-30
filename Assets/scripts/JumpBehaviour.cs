using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isSpacePressed; 
    
    
    // Start is called before the first frame update
    void Awake()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpacePressed = false;
        }
    }

    private void FixedUpdate()
    {
        if (isSpacePressed && isGrounded)
        {
            playerRigidBody.AddForce(Vector2.up*jumpForce*Time.deltaTime,ForceMode2D.Impulse);
            isGrounded = false;
        }
       
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
        
    }
}
