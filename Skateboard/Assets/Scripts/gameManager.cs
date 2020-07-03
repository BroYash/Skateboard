using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private bool gameEnded = false;
    public void EndGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("Game over");
            //Invoke("Restart", restartDelay);
            //restart game
        }
    }


}
