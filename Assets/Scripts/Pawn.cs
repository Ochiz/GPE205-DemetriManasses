using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public Mover mover;
    public float fireRate;
    public Shooter shooter;
    public GameObject shellPrefab;
    public float fireForce;
    public float damageDone;
    public float shellLifespan;
    protected float secondsPerShot;
    public Health health;
    public PlayerController playerController;
    // Start is called before the first frame update
    public virtual void Start()
    {
        secondsPerShot = 1 / fireRate;
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public abstract void MoveForward(bool sprint);
    public abstract void MoveBackward(bool sprint);
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPosition);
}
