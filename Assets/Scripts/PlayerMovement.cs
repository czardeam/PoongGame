using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] bool isAI;
    [SerializeField] GameObject ball;

    Rigidbody2D rb;
    Vector2 playerMove;





    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxis("Vertical"));
    }

    private void AIControl()
    {
        if (ball.transform.position.y > transform.position.y  + 0.7f)
        {
            playerMove = new Vector2(0,1);
        }
        else if (ball.transform.position.y < transform.position.y - 0.7f)
        {
            playerMove = new Vector2(0,-1);
        }
        else
        {
            playerMove = new Vector2(0,0);
        }

    }
    
     private void FixedUpdate()
    {
        rb.linearVelocity = playerMove * movementSpeed;
    }

}
