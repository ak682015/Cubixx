using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Camera camera;
    public Material obstacleMaterial;

    public Color[] bgColor;
    public Color[] obstacleColor;
   
    void Start()
    {
        changeColor();
    }

    void changeColor()
    {
        int i;
        i = Random.Range(0, bgColor.Length);
        camera.backgroundColor = bgColor[i];
        obstacleMaterial.SetColor("_BaseColor",obstacleColor[i]);
    }
}
