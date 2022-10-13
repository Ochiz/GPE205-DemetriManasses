using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }
    public override void MoveForward()
    {
        Debug.log("hi");
    }
    public override void MoveBackward()
    {
        Debug.log("hi2");
    }
    public override void RotateClockwise()
    {
        Debug.log("hi3");
    }
    public override void RotateCounterClockwise()
    {
        Debug.log("hi4");
    }
}
