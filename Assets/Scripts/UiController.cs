using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public GameObject HomeUI;
    public TextMeshProUGUI coins;

    private void Update()
    {
       coins.text = DataSet.coin.ToString();
    }


    public void startGame()
    {
        HomeUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
