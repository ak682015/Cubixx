using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public GameObject player;
    //public Camera camera;
    public GameObject ground;

    private bool checkRot = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( player.transform.position.x == -10.5  && !checkRot )
        {
            Debug.Log("Yup");
            Rotate();
        }
    }

    private void Rotate()
    {
        if ( !checkRot )
        {
            ground.transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);
           // player.transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);
            //camera.transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);
            checkRot = true;
        }


    }
}
