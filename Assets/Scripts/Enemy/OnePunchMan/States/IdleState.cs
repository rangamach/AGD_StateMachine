using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class IdleState : IState
    {
        public OnePunchManController Owner { get; set; }
        private OnePunchManStateMachine stateMachine;
        private float timer;

        public IdleState(OnePunchManStateMachine machine) => this.stateMachine = machine;

        public void OnStateEnter() => ResetTimer();
        public void Update()
        {
            timer -= Time.deltaTime;
            if(timer<=0)
                stateMachine.ChangeState(OnePunchManStates.Rotating);
        }
        public void OnStateExit() => timer = 0;
        private void ResetTimer() => timer = Owner.Data.IdleTime;
    }

}