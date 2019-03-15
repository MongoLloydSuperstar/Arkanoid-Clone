using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBallController : MonoBehaviour 
{

    private void Awake()
    {
        if (FindObjectsOfType<ParentBrickController>().Length != 1) {
            Debug.LogError("There is more/less than one ParentBrickController!", gameObject);
        }
    }

    private void BricksLeft()
    {
        int bricksLeft = transform.childCount;
        if (bricksLeft <= 0) {
            GameObject gameController = GameObject.FindWithTag("GameController");
            gameController.SendMessage("BallEmpty");
        }
    }

    
}
