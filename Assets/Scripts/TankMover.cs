using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    public override void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.position + moveVector);
    }

    public override void Rotate(float rotateSpeed)
    {
        float rSpeed = rotateSpeed * Time.deltaTime;
        rigidBody.transform.Rotate(0, rSpeed, 0);
    }
}
