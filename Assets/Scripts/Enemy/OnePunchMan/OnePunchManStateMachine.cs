using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine
    {
        private OnePunchManController owner;
        private IState currentState;
        protected Dictionary<OnePunchManStates, IState> states = new Dictionary<OnePunchManStates, IState>();

        public OnePunchManStateMachine(OnePunchManController owner)
        {
            this.owner = owner;

            CreateStates();
            SetOwner();
        }

        public void Update() => currentState?.Update();
        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }
        public void ChangeState(OnePunchManStates newState) => ChangeState(states[newState]);
        private void CreateStates()
        {
            states.Add(OnePunchManStates.Idle, new IdleState(this));
            states.Add(OnePunchManStates.Rotating, new RotatingState(this));
            states.Add(OnePunchManStates.Shooting, new ShootingState(this));    
        }
        private void SetOwner()
        {
            foreach (IState state in states.Values)
                state.Owner = owner;
        }
    }
    public enum OnePunchManStates
    {
        Idle,
        Rotating,
        Shooting,
    }
}
