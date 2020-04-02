using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public ObjectPooler objectPooler;
    public GameObject player;

    private Vector3 pos;

    private void Start()
    {
        //objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = new Vector3(Random.Range(-7.5f, 7.5f), 1, player.transform.position.z + Random.Range(10f,500f));

        //objectPooler.SpawnFromPool("Obstacle", pos, Quaternion.identity);

        GameObject newObs = objectPooler.GetPooledObjects();
        newObs.transform.position = pos;
        newObs.SetActive(true);

        Debug.Log(newObs.transform.position.z);
        Debug.Log(player.transform.position.z);


    }


}
