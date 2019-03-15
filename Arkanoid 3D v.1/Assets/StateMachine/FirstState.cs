using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManaging;
using System;

public class FirstState : State<PaddleController>
{
    private static FirstState instance;

    private FirstState()
    {
        if (instance != null) {
            return;
        }

        instance = this;
    }

    public static FirstState Instance
    {
        get
        {
            if (instance == null) {
                new FirstState();
            }

            return instance;
        }
    }

    public override void EnterState(PaddleController _owner)
    {
        Debug.Log("Entering FirstState");
    }

    public override void ExitState(PaddleController _owner)
    {
        Debug.Log("Exiting FirstState");
    }

    public override void UpdateState(PaddleController _owner)
    {

        
    }
}
