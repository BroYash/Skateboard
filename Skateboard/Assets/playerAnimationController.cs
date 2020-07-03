using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour
{
    private Animator animator;
    private CharacterController _characterController;

    public string playerCombo = "";
    public int comboCount = 0;

    private bool comboStart = false;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_characterController.isGrounded)
        {
            animator.SetTrigger("idle");
        }
        /*
        if ((Input.GetKey("j")) && (Input.GetKey("l")))
        {

            animator.SetBool("grind", true);
        }
        else
        {
            animator.SetBool("grind", false);
        }*/


        if (Input.GetKeyDown("k") && _characterController.isGrounded == false)
        {
            comboStart = true;
            Time.timeScale = 0.01f;
        }
        if (comboStart)
        {
            combo();
        }
    }

    public void combo()
    {
        //when trick button is pressed trick is true
        //player must do a trick
        if (Input.GetKeyDown("j"))
        {
            playerCombo += "j";
            comboCount += 1;
        }
        if (Input.GetKeyDown("i"))
        {
            playerCombo += "i";
            comboCount += 1;
        }
        if (Input.GetKeyDown("l"))
        {
            playerCombo += "l";
            comboCount += 1;
        }
        if (comboCount >= 3)
        {
            Debug.Log("player combo" + playerCombo);
            comboCount = 0;
            checkCombo();

            playerCombo = "";
        }
    }

    public void checkCombo()
    {

        if (playerCombo == "jil")
        {
            animator.SetTrigger("kickflip");
        }
        if (playerCombo == "jlj")
        {
            animator.SetTrigger("360");
        }
        Time.timeScale = 1;
        comboStart = false;
    }
}


