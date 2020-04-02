using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject player;
    public GameObject pooledObject;
    public int pooledAmount;

    List<GameObject> pooledObjects;


    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }


    public GameObject GetPooledObjects()
    {
        for(int i = 0; i<pooledObjects.Count; i++)
        {
            if( !pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }



        return null;
    }

    /*
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

        
    }

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    
    void Start()
    {

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i<pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
            
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Tag doesnt exists");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        Debug.Log(objectToSpawn.transform.position.z);

        poolDictionary[tag].Enqueue(objectToSpawn);


        if ( player.transform.position.z > objectToSpawn.transform.position.z +5f)
        {
           objectToSpawn.SetActive(false);
           poolDictionary[tag].Enqueue(objectToSpawn);


        }
        return objectToSpawn;
     
    }
    */


}
