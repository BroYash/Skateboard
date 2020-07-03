using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    public float forwardForce;
    public float sidwaysForce;
    public float jumpForce;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector3(0, 0, 1) * forwardForce;
        if (animator.GetBool("grind") == false)
        {
            basicMovement();
        }

    }





    private void basicMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); //.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(rb.velocity.x, verticalInput * jumpForce, 1 * forwardForce);
        rb.velocity = new Vector3(horizontalInput * sidwaysForce, rb.velocity.y, 1 * forwardForce);

    }


}
