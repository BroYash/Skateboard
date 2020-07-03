using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float rotationspeed = 240f;
    public float gravity = 20f;
    public float jumpSpeed = 10f;

    private Animator _animator;
    private CharacterController _characterController;
    private Vector3 _moveDir = new Vector3();

    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (v < 0)
            v = 0;

        transform.Rotate(0, h * rotationspeed * Time.deltaTime, 0);

        if (_characterController.isGrounded)
        {
            bool move = (v > 0) || (h != 0);

            //_animator.SetBool("run", move);

            _moveDir = Vector3.forward * (v);
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= speed;
            _animator.SetBool("jump", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                _moveDir.y = jumpSpeed;

                _animator.SetBool("jump", true);
            }
            //Debug.Log("Player is grounded");
        }

        _moveDir.y -= gravity * Time.deltaTime;
        _characterController.Move(_moveDir * Time.deltaTime);
    }
}
