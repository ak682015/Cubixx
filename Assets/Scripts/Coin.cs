using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    MeshRenderer mesh;
    private void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player") )
        {
           DataSet.coin += coinValue ;
            StartCoroutine(meshcollide());
            PlayerPrefs.SetInt("coin", DataSet.coin);
        }
    }

    IEnumerator meshcollide()
    {
        mesh.enabled = false;
        yield return new WaitForSeconds(2f);
        mesh.enabled = true;
    }
}
