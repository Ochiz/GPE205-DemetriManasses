using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance != null)
        {
            
            
                GameManager.instance.aiSpawns.Add(this);
            
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
            if (GameManager.instance.aiSpawns != null)
            {
                GameManager.instance.aiSpawns.Remove(this);
            }
        }
    }
}
