using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    public Animator animator;

    public string playerCombo = "";
    public int comboCount = 0;

    private bool comboStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("j")) && (Input.GetKey("l")))
        {

            animator.SetBool("grind", true);
        }
        else
        {
            animator.SetBool("grind", false);
        }


        if (Input.GetKeyDown("k"))
        {
            comboStart = true;
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
        if (playerCombo == "jlj")
        {
            animator.SetTrigger("hspincw");
        }
        if (playerCombo == "jil")
        {
            animator.SetTrigger("vspincw");
        }
        //reverse version of spins
        if (playerCombo == "lij")
        {
            animator.SetTrigger("hspinacw");
        }
        if (playerCombo == "ljl")
        {
            animator.SetTrigger("vspinacw");
        }
        comboStart = false;
    }
}
