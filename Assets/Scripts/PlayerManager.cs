using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public List<ShopItems> PlayerList;

    public Button select;
    public Button selected;
    public Button price;
    public GameObject[] sepratedObj;

    int indexPlayer;
    void Start()
    {
        indexPlayer = PlayerPrefs.GetInt("player",0);
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
                foreach (var obj in sepratedObj)
                {
                    obj.GetComponent<MeshRenderer>().material = PlayerList[indexPlayer].player.GetComponent<MeshRenderer>().material;
                }
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
            PlayerPrefs.SetInt("player", DataSet.selectedPlayer);
            foreach(var obj in sepratedObj)
            {
                obj.GetComponent<MeshRenderer>().material = PlayerList[indexPlayer].player.GetComponent<MeshRenderer>().material;
            }
        }

    }

    public void buyPlayer()
    {
        if (DataSet.coin>=500)
        {
            selected.gameObject.SetActive(false);
            select.gameObject.SetActive(true);
            price.gameObject.SetActive(false);
            PlayerList[indexPlayer].isUnlocked = true;
            DataSet.coin -= 500;
            changeButton(indexPlayer);
        }
    }
}
