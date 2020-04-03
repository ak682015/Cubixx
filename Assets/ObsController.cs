using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsController : MonoBehaviour
{
    Vector3 obsposition, groundposition;
    int rankey;
    public GameObject ground;
    private int key = 0;
    public float distance;
    public Dictionary<int, Queue<GameObject>> obsDict;
    public List<GameObject> obsPrefab;

    Queue<GameObject> groundQueue;
    void Awake()
    {
        obsposition = new Vector3(0f, 0f, distance);
        groundposition = new Vector3(0f, 0f, 100f);
        groundQueue = new Queue<GameObject>();
        obsDict = new Dictionary<int, Queue<GameObject>>();

        foreach (GameObject obj in obsPrefab)
        {
            key++;
            Queue<GameObject> objpool = new Queue<GameObject>();

            for (int i = 0; i < 10; i++)
            {
                GameObject go = Instantiate(obj, obj.transform.position, obj.transform.rotation);
                go.SetActive(false);
                objpool.Enqueue(go);
            }
            obsDict.Add(key, objpool);
        }

        for(int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(ground, ground.transform.position, ground.transform.rotation);
            go.SetActive(false);
            groundQueue.Enqueue(go);
        }
    }

    public void SpawnObs()
    {
        Vector3 temppos;
        rankey = Random.Range(1, obsPrefab.Count + 1);
        GameObject go = obsDict[rankey].Dequeue();
        go.SetActive(true);
        temppos = go.transform.position;
        temppos.z = obsposition.z;
        go.transform.position = temppos;
        obsposition = obsposition + new Vector3(0f, 0f, distance);
        obsDict[rankey].Enqueue(go);
    }


    public void GroundSpawn()
    {
        Vector3 tempposs;
        GameObject go = groundQueue.Dequeue();
        go.SetActive(true);
        tempposs = go.transform.position;
        tempposs.z = groundposition.z;
        go.transform.position = tempposs;
        groundposition = groundposition + new Vector3(0f, 0f, 100f);
        groundQueue.Enqueue(go);
    }
}
