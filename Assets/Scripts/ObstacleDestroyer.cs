using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{

    public GameObject obstacleDestructionPoint;

    // Start is called before the first frame update
    void Start()
    {
        obstacleDestructionPoint = GameObject.Find("ObstacleDestructionPoint");
  
    }

    // Update is called once per frame
    
}
