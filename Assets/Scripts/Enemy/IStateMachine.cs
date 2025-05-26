using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    public void ChangeState(States newState);  
}
public enum States
{
    IDLE,
    ROTATING,
    SHOOTING,
    PATROLLING,
    CHASING,
}
