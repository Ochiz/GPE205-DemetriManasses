using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState {Idle, Guard, Chase, Flee, Patrol, Attack, Scan, BackToPost, ChooseTarget };
    public AIState currentState;
    private float lastStateChangeTime;
    public GameObject target;
    public float fleeDistance;
    public Transform[] waypoints;
    public float waypointStopDistance;
    private int currentWaypoint = 0;
    // Start is called before the first frame update
    public override void Start()
    {
        ChangeState(AIState.Idle);
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
        base.Update();
    }

    public void MakeDecisions()
    {
        switch (currentState)
        {
            case AIState.Idle:
                DoIdleState();
                if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.Chase:
                DoAttackState();
                if (!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIState.Idle);
                }
                break;
            case AIState.Flee:
                DoFleeState();
                break;

        }

    }

    public override void ProcessInputs()
    {

    }

    public virtual void ChangeState(AIState newState)
    {
        currentState = newState;
        lastStateChangeTime = Time.time;
    }

    public void DoAttackState()
    {
       Seek(target);
       Shoot();
    }

    public void Seek(GameObject target)
    {
        pawn.RotateTowards(target.transform.position);
        pawn.MoveForward(false);
    }

    public void Seek(Vector3 targetPosition)
    {
        pawn.RotateTowards(targetPosition);
        pawn.MoveForward(false);
    }

    public void Seek(Pawn targetPawn)
    {
        Seek(targetPawn.transform);
    }

    public void Seek(Transform targetTransform)
    {
        Seek(targetTransform.position);
    }

    public void Seek(Controller targetController)
    {
        Seek(targetController.pawn);
    }

    protected virtual void DoIdleState()
    {

    }

    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Shoot()
    {
        pawn.Shoot();
    }

    protected void Flee()
    {
        float targetDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
        float percentOfFleeDistance = targetDistance / fleeDistance;
        percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);
        float flippedPercentOfFleeDistance = 1 - percentOfFleeDistance;
        //need to finish
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
        Seek(pawn.transform.position + fleeVector);
    }
    public void DoFleeState()
    {
        Flee();
    }
    protected void Patrol()
    {
        if(waypoints.Length > currentWaypoint)
        {
            Seek(waypoints[currentWaypoint]);
            if(Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            RestartPatrol();
        }
    }
    protected void RestartPatrol()
    {
        currentWaypoint = 0;
    }
    public void targetPlayerOne()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.players != null)
            {
                if(GameManager.instance.players.Count > 0)
                {
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }
    protected void targetNearestTank()
    {
        Pawn[] allTanks = FindObjectsOfType<Pawn>();
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        foreach (Pawn tank in allTanks)
        {
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
            {
                closestTank = tank;
                closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
            }
        }
        target = closestTank.gameObject;
    }
    protected void targetLowestHealthTank()
    {

    }
    protected bool IsHasTarget()
    {
        return (target != null);
    }
    protected void ChooseTarget()
    {
       
    }
    public void DoChooseTargetState()
    {
        ChooseTarget();
    }
}
