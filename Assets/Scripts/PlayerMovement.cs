using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] bool isAI;
    [SerializeField] GameObject ball;

    Rigidbody2D rb;
    Vector2 playerMove;
    private float aiSpeed = 5f;





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


     private void FixedUpdate()
    {
        rb.linearVelocity = playerMove * movementSpeed;
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxis("Vertical"));
    }

    private void AIControl()
    {
        // Hedeflenen Y pozisyonunu hesapla
    float targetY = ball.transform.position.y;

    // Hedefe doğru yumuşak hareket et
    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, targetY), aiSpeed * Time.deltaTime);
}
    
    

}
