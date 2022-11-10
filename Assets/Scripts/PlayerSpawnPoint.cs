using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance != null)
        {
            
                GameManager.instance.playerSpawns.Add(this);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.playerSpawns != null)
            {
                GameManager.instance.playerSpawns.Remove(this);
            }
        }
    }
}
