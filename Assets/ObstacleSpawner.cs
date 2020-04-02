using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    ObjectPooler objectPooler;
    private Vector3 pos;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = new Vector3(Random.Range(-7.5f, 7.5f), 1, Random.Range(10f, 1000f));
        objectPooler.SpawnFromPool("Obstacle", pos, Quaternion.identity);
    }
}
