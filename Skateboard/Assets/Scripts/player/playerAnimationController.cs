using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour
{
    private Animator animator;
    [SerializeField]private  Skateboard skateboard;
    [SerializeField]private playerController pc;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skateboard.isGrounded)
        {
            animator.SetTrigger("idle");
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }

        if (Input.GetKeyDown("k") && skateboard.isGrounded == false)
        {
            int r = Random.Range(0, 2);
            if (r == 0)
            {
                animator.SetTrigger("kickflip");
            }
            else if (r == 1)
            {
                animator.SetTrigger("360");
            }
        }
    }

}


