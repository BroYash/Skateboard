using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 10f;
    public float turnSpeed = 5f;
    public GameObject spawnPoint;
    public GameObject background;

    private Animator _animator;
    private Rigidbody rb;
    private Collider coll;
    private Skateboard _skateboard;

    [SerializeField] GameObject ragDoll;
    [SerializeField] GameObject characterModel;
    [SerializeField] GameObject skateboardModel;

    [SerializeField]private bool dead;

    private void Awake()
    {
        this.transform.position = this.spawnPoint.transform.position;
        this.transform.Rotate(0, 0, 0);
        
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        _skateboard = FindObjectOfType<Skateboard>();
    }

    void Update()
    {
        if (dead == false)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
            Movement();
        }
    }


    public void Movement()
    {
        float h = Input.GetAxis("Horizontal");

        if(h < 0)
        {
            moveLeft();
        }
        else if (h > 0)
        {
            moveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space) && _skateboard.isGrounded)
        {
            Jump();
        }
    }


    public void Jump()
    {
        if (_skateboard.isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            //.AddForce(0,800, 0);

            _skateboard.isGrounded = false;
        }
    }

    public void moveLeft()
    {
        //rb.velocity = new Vector3(-turnSpeed, rb.velocity.y, rb.velocity.z);
        if (_skateboard.isGrounded)
        {
            rb.AddForce(-500, 0, 0);
        }

    }

    public void moveRight()
    {
        //rb.velocity = new Vector3(turnSpeed, rb.velocity.y, rb.velocity.z);
        if (_skateboard.isGrounded)
        {
            rb.AddForce(500, 0, 0);
        }
    }

    public void ToggleDead()
    {
        background.transform.parent = null;
        skateboardModel.transform.parent = null;
        skateboardModel.GetComponent<Rigidbody>().velocity = rb.velocity;

        dead = true;
        //dead = !dead;
        if (dead)
        {
            CopyTransform(characterModel.transform, ragDoll.transform, rb.velocity);
            ragDoll.SetActive(true);
            characterModel.SetActive(false);
        }
        else
        {
            ragDoll.SetActive(false);
            characterModel.SetActive(true);
        }
    }

    private void CopyTransform(Transform source, Transform destination, Vector3 velocity)
    {
        if (source.childCount != destination.childCount)
        {
            Debug.LogWarning("invalid transform");
            return;
        }
        for(int i = 0; i < source.childCount; i++)
        {
            source = source.GetChild(i);
            destination = destination.GetChild(i);
            destination.position = source.position;
            destination.rotation = source.rotation;
            var rb = destination.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.velocity = velocity;
            }
            CopyTransform(source, destination, velocity);
        }
    }

}
