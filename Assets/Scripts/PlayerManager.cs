using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public List<ShopItems> PlayerList;

    public Button select;
    public Button selected;
    public Button price;


    int indexPlayer;
    void Start()
    {
        indexPlayer = DataSet.selectedPlayer;
        showPlayer();
        
        getUnlockedPlayerData();
    }


    public void Left()
    {
        indexPlayer--;
        indexPlayer = Mathf.Clamp(indexPlayer,0, PlayerList.Count-1);
        showPlayer();
        changeButton(indexPlayer);
    }


    public void Right()
    {
        indexPlayer++;
        indexPlayer = Mathf.Clamp(indexPlayer, 0, PlayerList.Count-1);
        showPlayer();
        changeButton(indexPlayer);
    }


    void showPlayer()
    {
        for (int i = 0; i < PlayerList.Count; i++)
        {
            if (i == indexPlayer)
            {
                PlayerList[i].player.SetActive(true);
            }
            else
            {
                PlayerList[i].player.SetActive(false);
            }

        }
       
    }

     
    void changeButton(int indexPlayer)
    {
        if (indexPlayer == DataSet.selectedPlayer)
        {
            selected.gameObject.SetActive(true);
            select.gameObject.SetActive(false);
            price.gameObject.SetActive(false);
        }
        else
        {
            if (PlayerList[indexPlayer].isUnlocked)
            {
                selected.gameObject.SetActive(false);
                select.gameObject.SetActive(true);
                price.gameObject.SetActive(false);
            }
            else
            {
                if (!PlayerList[indexPlayer].isUnlocked)
                {
                    print(indexPlayer);
                    selected.gameObject.SetActive(false);
                    select.gameObject.SetActive(false);
                    price.gameObject.SetActive(true);
                }
            }
        }
    }

    void getUnlockedPlayerData()
    {
        for (int j = 0; j <= 7; j++)
        {
            if (PlayerPrefs.GetInt(j.ToString()) == 1)
            {
                PlayerList[j].isUnlocked = true;
            }
        }
    }

   public void selectPlayer()
    {
        if(PlayerList[indexPlayer].isUnlocked)
        {
            selected.gameObject.SetActive(true);
            select.gameObject.SetActive(false);
            price.gameObject.SetActive(false);
            DataSet.selectedPlayer = indexPlayer;
        }

    }

    public void buyPlayer()
    {
        if (DataSet.coin>=1000)
        {
            selected.gameObject.SetActive(false);
            select.gameObject.SetActive(true);
            price.gameObject.SetActive(false);
            PlayerList[indexPlayer].isUnlocked = true;
            DataSet.coin -= 1000;
            changeButton(indexPlayer);
        }
    }
}
