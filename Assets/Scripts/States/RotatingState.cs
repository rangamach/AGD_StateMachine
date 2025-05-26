using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class RotatingState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private float targetRotation;

<<<<<<< Updated upstream:Assets/Scripts/Enemy/OnePunchMan/States/RotatingState.cs
        public RotatingState(OnePunchManStateMachine machine) => this.stateMachine = machine;
=======
        public RotatingState(IStateMachine stateMachine) => this.stateMachine = stateMachine;
>>>>>>> Stashed changes:Assets/Scripts/States/RotatingState.cs

        public void OnStateEnter() => targetRotation = (Owner.Rotation.eulerAngles.y + 180) % 360;
        public void Update()
        {
            Owner.SetRotation(CalculateRotation());
            if (IsRotationComplete())
<<<<<<< Updated upstream:Assets/Scripts/Enemy/OnePunchMan/States/RotatingState.cs
                stateMachine.ChangeState(OnePunchManStates.Idle);
=======
                stateMachine.ChangeState(States.IDLE);
>>>>>>> Stashed changes:Assets/Scripts/States/RotatingState.cs
        }
        private Vector3 CalculateRotation() => Vector3.up * Mathf.MoveTowardsAngle(Owner.Rotation.eulerAngles.y, targetRotation, Owner.Data.RotationSpeed * Time.deltaTime);

        private bool IsRotationComplete() => Mathf.Abs(Mathf.Abs(Owner.Rotation.eulerAngles.y) - Mathf.Abs(targetRotation)) < Owner.Data.RotationThreshold;
        public void OnStateExit() => targetRotation = 0;
    }

}