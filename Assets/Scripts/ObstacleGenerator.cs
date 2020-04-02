using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public GameObject theObstacle;
    public GameObject camera;



    public GameObject player;

    public Transform generationPoint;

    public float distanceBetween;

    private float obstacleWidthX;
    private float obstacleWidthZ;

    private Vector3 pos;

    public ObjectPooler objectPooler;

    // Start is called before the frame update
    void Start()
    {
        obstacleWidthX = theObstacle.GetComponent<BoxCollider>().size.x;
        obstacleWidthZ = theObstacle.GetComponent<BoxCollider>().size.z;

    }

    // Update is called once per frame
    void Update()
    {
            pos = new Vector3(Random.Range(-6.5f, 6.5f) + obstacleWidthX , 1, player.transform.position.z + Random.Range(10f,100f) + obstacleWidthZ + 50f );
            GameObject newObs = objectPooler.GetPooledObjects();
            newObs.transform.position = pos;
            newObs.SetActive(true);
   
    }
}
