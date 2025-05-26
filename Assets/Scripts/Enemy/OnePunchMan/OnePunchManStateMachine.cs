using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine : IStateMachine
    {
        private OnePunchManController owner;
        private IState currentState;
<<<<<<< Updated upstream
        protected Dictionary<OnePunchManStates, IState> states = new Dictionary<OnePunchManStates, IState>();
=======
        protected Dictionary<States, IState> States = new Dictionary<States, IState>();
>>>>>>> Stashed changes

        public OnePunchManStateMachine(OnePunchManController owner)
        {
            this.owner = owner;

            CreateStates();
            SetOwner();
        }

<<<<<<< Updated upstream
=======
        private void CreateStates()
        {
            States.Add(global::States.IDLE, new IdleState(this));
            States.Add(global::States.ROTATING, new RotatingState(this));
            States.Add(global::States.SHOOTING, new ShootingState(this));
        }

        private void SetOwner()
        {
            foreach(IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

>>>>>>> Stashed changes
        public void Update() => currentState?.Update();
        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }
<<<<<<< Updated upstream
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
=======

        public void ChangeState(States newState) => ChangeState(States[newState]);
>>>>>>> Stashed changes
    }
}
