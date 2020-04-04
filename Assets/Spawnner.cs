using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public ObsController obsController;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            obsController.SpawnObs();
        }

        obsController.GroundSpawn();
        obsController.GroundSpawn();
        obsController.GroundSpawn();
        obsController.GroundSpawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obsController.SpawnObs();
        }
    }
}
