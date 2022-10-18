using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState {Idle, Guard, Chase, Flee, Patrol, Attack, Scan, BackToPost };
    public AIState currentState;
    public float lastStateChangeTime;
    public GameObject target;
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
        DoSeekState();
    }
    public override void ProcessInputs()
    {

    }
    public virtual void ChangeState(AIState newState)
    {
        currentState = newState;
        lastStateChangeTime = Time.time;
    }
    public void DoSeekState()
    {
       Seek(target);
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
}
