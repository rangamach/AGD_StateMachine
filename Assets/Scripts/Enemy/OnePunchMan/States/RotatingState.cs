using StatePattern.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class RotatingState : IState
    {
        public OnePunchManController Owner { get; set; }
        private OnePunchManStateMachine stateMachine;
        private float targetRotation;

        public RotatingState(OnePunchManStateMachine machine) => this.stateMachine = machine;

        public void OnStateEnter() => targetRotation = (Owner.Rotation.eulerAngles.y + 180) % 360;
        public void Update()
        {
            Owner.SetRotation(CalculateRotation());
            if (IsRotationComplete())
                stateMachine.ChangeState(OnePunchManStates.Idle);
        }
        private Vector3 CalculateRotation() => Vector3.up * Mathf.MoveTowardsAngle(Owner.Rotation.eulerAngles.y, targetRotation, Owner.Data.RotationSpeed * Time.deltaTime);

        private bool IsRotationComplete() => Mathf.Abs(Mathf.Abs(Owner.Rotation.eulerAngles.y) - Mathf.Abs(targetRotation)) < Owner.Data.RotationThreshold;
        public void OnStateExit() => targetRotation = 0;
    }

}