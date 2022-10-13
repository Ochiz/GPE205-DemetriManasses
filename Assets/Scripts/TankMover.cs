using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    public override void Start()
    {
        rigidBody = GetComponent<RigidBidy>();
    }

    // Update is called once per frame
    public override void move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.position + moveVector);
    }
}
