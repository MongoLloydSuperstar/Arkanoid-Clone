using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBrickController : MonoBehaviour
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
            GameController gameController = FindObjectOfType<GameController>();
            gameController.SendMessage("BricksEmpty");
        }
    }
}
