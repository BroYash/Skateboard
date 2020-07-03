using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    private Vector3 currentRail;

    bool grindOn = false;

    [SerializeField] private playerMovement playermovement;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "obsticle")
        {
            Debug.Log("you hit an obstacle");
            playermovement.enabled = false;
            //FindObjectOfType<gamemanager>().EndGame();
            //make skateboard box small
        }
        if (collisionInfo.collider.tag == "grind" && (animator.GetBool("grind")))
        {
            Debug.Log("Start grind link");
            //lock player to top of rail until player presses up button or when rail ends

            player.transform.position = collisionInfo.gameObject.transform.position;

            //set boolean to lock transform or have grind with no lock
            currentRail = new Vector3(collisionInfo.gameObject.transform.position.x, collisionInfo.gameObject.transform.position.y, gameObject.transform.position.z * 1);
            grindOn = true;
            
        }
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grindOn && (animator.GetBool("grind"))){
            player.transform.position = new Vector3(currentRail.x, currentRail.y + 3.5f, player.position.z);
        }
        else
        {
            grindOn = false;
        }
    }

}
