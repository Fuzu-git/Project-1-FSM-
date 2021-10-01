using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleState : State
{
    public bool canSeeThePlayer;
    public ChaseState chaseState; 
    public override State RunCurrentState()
    {
        if (canSeeThePlayer)
        {
            return chaseState; 
        }
        else
        {
            return this; 
        }
    }
}
