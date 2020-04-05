using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGround : MonoBehaviour
{
    public ObsController obsController;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            obsController.GroundSpawn();        }
    }
}
