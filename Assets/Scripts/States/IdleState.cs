using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class IdleState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private float timer;

<<<<<<< Updated upstream:Assets/Scripts/Enemy/OnePunchMan/States/IdleState.cs
        public IdleState(OnePunchManStateMachine machine) => this.stateMachine = machine;
=======
        public IdleState(IStateMachine stateMachine) => this.stateMachine = stateMachine;
>>>>>>> Stashed changes:Assets/Scripts/States/IdleState.cs

        public void OnStateEnter() => ResetTimer();
        public void Update()
        {
            timer -= Time.deltaTime;
<<<<<<< Updated upstream:Assets/Scripts/Enemy/OnePunchMan/States/IdleState.cs
            if(timer<=0)
                stateMachine.ChangeState(OnePunchManStates.Rotating);
=======
            if (timer <= 0)
                stateMachine.ChangeState(States.ROTATING);
>>>>>>> Stashed changes:Assets/Scripts/States/IdleState.cs
        }
        public void OnStateExit() => timer = 0;
        private void ResetTimer() => timer = Owner.Data.IdleTime;
    }

}