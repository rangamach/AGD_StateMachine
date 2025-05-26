using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrollingState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;
        private int currentWaypoint = -1;
        private Vector3 destination;

        public PatrollingState(IStateMachine machine) => this.stateMachine = machine;

        public void OnStateEnter()
        {
            SetNextWaypoint();
            destination = GetNextWaypoint();
        }
        private void SetNextWaypoint()
        {
            if (currentWaypoint == Owner.Data.PatrollingPoints.Count - 1)
                currentWaypoint = 0;
            else
                currentWaypoint++;
        }
        private void MoveTowardsNextWaypoint()
        {
            Owner.Agent.isStopped = false;
            Owner.Agent.SetDestination(destination);
        }
        private Vector3 GetNextWaypoint() => Owner.Data.PatrollingPoints[currentWaypoint];
        public void Update()
        {
            if (ReachedDestination())
                stateMachine.ChangeState(States.IDLE);
        }
        private bool ReachedDestination() => Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance;
        public void OnStateExit()
        {

        }
    }

}

