using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    private float nextShootTime;
    // Start is called before the first frame update
    public override void Start()
    {
        nextShootTime = Time.time;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {

        base.Start();
    }
    public override void MoveForward(bool sprint)
    {
        if(sprint == true)
        {
            mover.Move(transform.forward, moveSpeed + 3);
        }
        else
        {
            mover.Move(transform.forward, moveSpeed);
        }
    }
    public override void MoveBackward(bool sprint)
    {
        if(sprint == true)
        {
            mover.Move(transform.forward, -moveSpeed - 3);
        }
        else
        {
            mover.Move(transform.forward, -moveSpeed);
        }
        
    }
    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }
    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
    }
    public override void Shoot()
    {
        if (Time.time >= nextShootTime)
        {
            shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
            nextShootTime = Time.time + secondsPerShot;
        }
    }
    public override void RotateTowards(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

}
