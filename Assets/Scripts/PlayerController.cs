using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey();
    public KeyCode moveBackwardKey();
    public KeyCode rotateClockwiseKey();
    public KeyCode rotateCounterClockwiseKey();
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
        base.Update();
    }
    public override void ProcessInputs()
    {
        if(ProcessInputs.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }
        if (ProcessInputs.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }
        if (ProcessInputs.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }
        if (ProcessInputs.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
    }
}
