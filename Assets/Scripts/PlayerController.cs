using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode sprintKey;
    public KeyCode shootKey;
    public float playerScore;
    public int playerLives;
    public float scoreToExtraLife;
    // Start is called before the first frame update
    public override void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        ProcessInputs();
        base.Update();
    }
    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Remove(this);
            }
        }
    }
    public void AddScore(float scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        if(playerScore >= scoreToExtraLife)
        {
            playerLives++;
            scoreToExtraLife = scoreToExtraLife + scoreToExtraLife;
        }
    }
    public override void ProcessInputs()
    {
        if(Input.GetKey(moveForwardKey))
        {
            if(Input.GetKey(sprintKey))
            {
                pawn.MoveForward(true);
            }
            else
            {
                pawn.MoveForward(false);
            }
        }
        if (Input.GetKey(moveBackwardKey))
        {
            if (Input.GetKey(sprintKey))
            {
                pawn.MoveBackward(true);
            }
            else
            {
                pawn.MoveBackward(false);
            }
        }
        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }
        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
        if(Input.GetKey(shootKey))
        {
            pawn.Shoot();
        }
    }

}
