using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSet : MonoBehaviour
{
    public static int coin;
    public static int selectedPlayer;
    
    void Start()
    {
        coin = PlayerPrefs.GetInt("coin",0);
        selectedPlayer = 0;
    }

}
