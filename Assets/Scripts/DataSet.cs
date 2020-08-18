using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSet : MonoBehaviour
{
    public static int coin;
    public static int selectedPlayer;
    public static bool inPlay;
    
    void Start()
    {
        inPlay = false;
        coin = PlayerPrefs.GetInt("coin",0);
        selectedPlayer = PlayerPrefs.GetInt("player",0);
    }

}
